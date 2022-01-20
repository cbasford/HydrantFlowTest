using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTestLibrary.Models
{
    public class FlowTestModel
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public bool TestCurrent { get; set; }
        public List<FlowTestDataModel> TestData { get; set; } = new List<FlowTestDataModel>();
        //public List<RequestModel> Requests { get; set; } = new List<RequestModel>();
    }
}
