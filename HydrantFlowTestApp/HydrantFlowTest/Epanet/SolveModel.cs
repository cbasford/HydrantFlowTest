using FlowTestLibrary.Models;
using FlowTestLibrary.Epanet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace FlowTestLibrary.Epanet
{
    public class Simulation
    {

        /// <summary>
        /// Runs two model simulations, for static and test condition
        /// </summary>
        /// <param name="testData"></param>
        /// <returns>true if everything ran successfully</returns>
        public bool Model(List<FlowTestDataModel> testData)  //FlowTestDataModel test
        {
            bool valid = true;

            // todo set time and load scada

            // Solve static run
            if ( valid ) valid = SolveModel(testData, "static");
            // Load results to database
            foreach (var v in testData)
            {
                GlobalConfig.Connection.UpdateModelData(v);
            }

            // Solve test run
            if ( valid ) valid = SolveModel(testData, "flow");
            // Load results to database
            foreach (var v in testData)
            {
                GlobalConfig.Connection.UpdateModelData(v);
                float f = v.ModelTestPsi;
            }

            // Create drawdown curve
            //Get primary residual hydrant
            int flowTestId = 0;
            int hydrantIndex = 0;
            foreach (FlowTestDataModel f in testData)
            {
                if ( f.AssetRole == "Primary Residual")
                {
                    StringBuilder s = new StringBuilder();
                    s.AppendFormat( "Hn" + f.AssetId.ToString());
                    int err = Epa.ENgetnodeindex(s.ToString(), ref hydrantIndex);
                    flowTestId = f.FlowTestId;
                }
            }

            // Call model 
            //if (valid) valid = SolveDrawdown(hydrantIndex, flowTestId);

            return valid;
        }

        //private static bool SolveDrawdown(int hydrantIndex, int flowTestId)
        //{
        //    Drawdown drawDown = new Drawdown();
        //    bool valid = true;
        //    float flow = 0F;
        //    int err = 0;
        //    float psi = 100;
        //    float increment = 100F;
        //    while (psi > 20)
        //    {
        //        if (err < 100) err = Epa.ENsetnodevalue(hydrantIndex, Epa.EN_BASEDEMAND, flow);
        //        if (err < 100) err = Epa.ENsolveH();
        //        if (err < 100) err = Epa.ENgetnodevalue(hydrantIndex, Epa.EN_PRESSURE, ref psi);
        //        //MessageBox.Show(flow + "    " + psi);
        //        flow = flow + increment;
        //        //TODO Need a bailout here
        //    }
        //    flow = flow - increment;

        //    // Get flow at 20 psi
        //    // This could be more efficient but solves quickly enough
        //    while (Math.Abs(psi - 20) > .1)
        //    {
        //        increment = increment / 2;
        //        if (psi - 20 < 0)
        //        {
        //            flow = flow - increment;
        //        }
        //        else
        //        {
        //            flow = flow + increment;
        //        }

        //        if (err < 100) err = Epa.ENsetnodevalue(hydrantIndex, Epa.EN_BASEDEMAND, flow);
        //        if (err < 100) err = Epa.ENsolveH();
        //        if (err < 100) err = Epa.ENgetnodevalue(hydrantIndex, Epa.EN_PRESSURE, ref psi);
        //        //MessageBox.Show(flow + "    " + psi);
        //        increment = increment / 2;
        //        if (psi - 20 < 0)
        //        {
        //            flow = flow - increment;
        //        }
        //        else
        //        {
        //            flow = flow + increment;
        //        }

        //        //drawDown.
        //    }

        //    if (err >= 100) valid = false;
        //    return valid;
        //}


        private static bool SolveModel(List<FlowTestDataModel> testData, string solution)
        {
            int err = 0;
            bool valid = true;
            float value = 0;
            int nodeIndex = 0;
            List<int> flowHydIndex = new List<int>();
            StringBuilder nodeId = new StringBuilder();

            if ( solution == "flow")
            {
                // Set emitter coeff for flow hydrants
                foreach (var v in testData)
                {
                    if (v.AssetRole == "Flow" && solution == "flow")
                    {
                        // Get node index
                        nodeId.AppendFormat("Hy" + v.AssetId.ToString());
                        if ( err <= 10 ) err = Epa.ENgetnodeindex(nodeId.ToString(), ref nodeIndex);
                        if (err <= 10) err = Epa.ENsetnodevalue(nodeIndex, Epa.EN_EMITTER, v.Multiplier);
                        flowHydIndex.Add(nodeIndex);
                        nodeId.Clear();
                    }
                    if (v.AssetRole == "Valve Closed" )
                    {
                        // todo close pipe
                    }
                }
            }

            // Solve model
            if (err <= 10) err = Epa.ENsolveH();

            foreach (var v in testData)
            {

                // Get node names of hydrants and blowoffs 
                switch (v.Asset)
                {
                    case "hydrant":
                        nodeId.AppendFormat("Hy" + v.AssetId.ToString());
                        break;
                    case "blowoff":
                        nodeId.AppendFormat("Bo" + v.AssetId.ToString());
                        break;
                    case "valve":
                        nodeId.AppendFormat("Va" + v.AssetId.ToString());
                        break;
                    default:
                        // todo Get servive
                        nodeId.AppendFormat("Skip");
                        break;
                }
                if (err <= 10) err = Epa.ENgetnodeindex(nodeId.ToString(), ref nodeIndex);                                                   

                if (v.AssetRole == "Primary Residual" || v.AssetRole == "Secondary Residual")
                {
                    if (err <= 10) err = Epa.ENgetnodevalue(nodeIndex, Epa.EN_PRESSURE, ref value);
                    if ( solution == "static")
                    {
                        v.ModelStaticPsi = value;
                        if (err <= 10) err = Epa.ENgetnodevalue(nodeIndex, Epa.EN_ELEVATION, ref value);
                        v.Elevation = value;
                    }
                    else
                    {
                        v.ModelTestPsi = value;
                        if (err <= 10) err = Epa.ENgetnodevalue(nodeIndex, Epa.EN_ELEVATION, ref value);
                        v.Elevation = value;
                    }

                }
                else if ( v.AssetRole == "Flow")
                {
                    if (err <= 10) err = Epa.ENgetnodevalue(nodeIndex, Epa.EN_DEMAND, ref value);
                    v.ModelFlow = value;
                    if (err <= 10) err = Epa.ENgetnodevalue(nodeIndex, Epa.EN_ELEVATION, ref value);
                    v.Elevation = value;
                }

                nodeId.Clear();
            }

            // close nozzles
            foreach ( int indx in flowHydIndex)
            {
                if (err <= 10) err = Epa.ENsetnodevalue(indx, Epa.EN_EMITTER, 0);
            }

            if (err > 10) valid = false;

            return valid;
        }

    }
}
