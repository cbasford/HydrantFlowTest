namespace DataAccessLibrary.DataModels
{
	public class FlowTestDataModel
	{
		public int Id { get; set; }
		public int? FlowTestId { get; set; }
		public int? AssetRoleId { get; set; }
		public int AssetTypeId { get; set; }
		public int? AssetNumber { get; set; }
		public int? HydrantNozzleId { get; set; }
		public float? StaticPsi { get; set; }
		public float? ResidualPsi { get; set; }
		public float? FlowGpm { get; set; }
		public float? ModelStaticPsi { get; set; }
		public float? ModelResidualPsi { get; set; }
		public float? ModelFlowGpm { get; set; }
		public float? Elevation { get; set; }
		public float? ErrorStaticPsi { get; set; }
		public float? ErrorResidualPsi { get; set; }
		public float? ErrorFlowGpm { get; set; }
		public float? CorrectedErrorResidualPsi { get; set; }
	}
}
