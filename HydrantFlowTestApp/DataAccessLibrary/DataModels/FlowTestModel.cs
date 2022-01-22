using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.DataModels
{
	public class FlowTestModel
	{
		public int Id { get; set; }
		public int? FlowValveStatusId { get; set; }
		public int? ModelVersionId { get; set; }
		public bool? Status { get; set; }
		[MaxLength(35)]
		public string TestName { get; set; }
		public DateTime? TestDate { get; set; }
		public DateTime? PlanFlowDate { get; set; }
		[MaxLength(50)]
		public string Summary { get; set; }
		public int? Workorder { get; set; }
		[MaxLength(25)]
		public string TestBy { get; set; }
		[MaxLength(255)]
		public string DisplayMap { get; set; }
		[MaxLength(255)]
		public string SiteMap { get; set; }
		[MaxLength(255)]
		public string SimlMap { get; set; }
		public float? TotalFlowGpm { get; set; }
		[MaxLength(255)]
		public string TestDataFile { get; set; }
		public float? MaxErrorStaticPsi { get; set; }
		public float? AvgErrorStaticPsi { get; set; }
		public float? MaxErrorResidualPsi { get; set; }
		public float? AvgErrorResidualPsi { get; set; }
		public float? FlowErrorGpm { get; set; }
		public float? VarErrorStaticPsi { get; set; }
		public float? VarErrorResidualPsi { get; set; }
		[MaxLength(50)]
		public string ModelRevisionDate { get; set; }
		public char? Calculate { get; set; }
		public int MapScale { get; set; }
		public float? CalcFlowAt20 { get; set; }
		public List<FlowTestDataModel> TestData { get; set; } = new List<FlowTestDataModel>();
	}
}
