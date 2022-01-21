using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLibrary.DataAccess;

using HydrantFlowTest.Models;

namespace HydrantFlowTest
{
    public class Methods
    {
        public static void AddData(FlowTestModel flowTest, FlowTestDataModel flowtestData)
        {
            // Add flow test
            flowTest.Id = 1;
            flowTest.TestDate = System.DateTime.Now;
            flowTest.TestName = "100 Main St";

            // Add flow test data
            flowtestData.Id = 1;
            flowtestData.FlowTestId = 1;
            flowtestData.Asset = "hyd";
            flowtestData.AssetId = 100;
            flowtestData.AssetRole = "flow";
            flowtestData.StaticPsi = 50;
            flowtestData.TestPsi = 40;
            flowtestData.Flow = 1200;

            flowtestData.Id = 2;
            flowtestData.FlowTestId = 1;
            flowtestData.Asset = "hyd";
            flowtestData.AssetId = 200;
            flowtestData.AssetRole = "res";
            flowtestData.StaticPsi = 50;
            flowtestData.TestPsi = 40;


        }
    }
}
