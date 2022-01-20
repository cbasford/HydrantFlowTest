using FlowTestLibrary.Epanet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowTestLibrary.Epanet
{
    public static class ModelApps
    {
        public static bool OpenModel()
        {
            string path = GlobalConfig.FilePath("filePath");
            string file = GlobalConfig.FileName("fileName");
            string f1 = path + file + ".inp";
            string f2 = path + file + ".rpt";
            string f3 = path + file + ".txt";
            int err = Epa.ENopen(f1, f2, f3);
            if (err == 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Model did not load");
                return false;
            }
        }
    }
}
