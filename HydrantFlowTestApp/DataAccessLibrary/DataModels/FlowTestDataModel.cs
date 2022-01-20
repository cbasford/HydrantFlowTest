namespace DataAccessLibrary.DataModels
{
	public class FlowTestDataModel
	{
		public int Id { get; set; }
		public int FlowTestId { get; set; }
		public string AssetRole { get; set; }
		public int AssetRoleId { get; set; }
		public string Asset { get; set; }
		public int AssetTypeId { get; set; }
		public int AssetId { get; set; }
		public string Nozzles { get; set; }
		public int NozzleId { get; set; }
		public float StaticPsi { get; set; }
		public float TestPsi { get; set; }
		public float Flow { get; set; }
		public float ModelStaticPsi { get; set; }
		public float ModelTestPsi { get; set; }
		public float ModelFlow { get; set; }
		public float Elevation { get; set; }
		public float DischargeCoeff { get; set; }
		public float Multiplier { get; set; }
	}
}
