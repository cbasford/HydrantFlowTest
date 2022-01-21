using System;
using System.Collections.Generic;

namespace HydrantFlowTest.Models
{
	public class FlowTestModel
	{
		public int Id { get; set; }
		public string TestName { get; set; }
		public DateTime TestDate { get; set; }
		public bool TestCurrent { get; set; }
		public List<FlowTestDataModel> TestData { get; set; } = new List<FlowTestDataModel>();
	}
}
