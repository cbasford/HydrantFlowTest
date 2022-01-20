using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using DataAccessLibrary.DataModels;

namespace DataAccessLibrary.DataAccess
{
	public class SqlCrud
	{
		public void CreateFlowTestDataModel(FlowTestDataModel flowTestDataModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTestData_Create]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("@FlowTestId", flowTestDataModel.FlowTestId);
			p.Add("@AssetRole", flowTestDataModel.AssetRole);
			p.Add("@AssetRoleId", flowTestDataModel.AssetRoleId);
			p.Add("@Asset", flowTestDataModel.Asset);
			p.Add("@AssetTypeId", flowTestDataModel.AssetTypeId);
			p.Add("@AssetId", flowTestDataModel.AssetId);
			p.Add("@Nozzles", flowTestDataModel.Nozzles);
			p.Add("@NozzleId", flowTestDataModel.NozzleId);
			p.Add("@StaticPsi", flowTestDataModel.StaticPsi);
			p.Add("@TestPsi", flowTestDataModel.TestPsi);
			p.Add("@Flow", flowTestDataModel.Flow);
			p.Add("@ModelStaticPsi", flowTestDataModel.ModelStaticPsi);
			p.Add("@ModelTestPsi", flowTestDataModel.ModelTestPsi);
			p.Add("@ModelFlow", flowTestDataModel.ModelFlow);
			p.Add("@Elevation", flowTestDataModel.Elevation);
			p.Add("@DischargeCoeff", flowTestDataModel.DischargeCoeff);
			p.Add("@Multiplier", flowTestDataModel.Multiplier);

			SqlDataAccess.SaveData(sql, p, connectionString, true);

			flowTestDataModel.Id = p.Get<int>("@Id");
		}

		public async Task CreateFlowTestDataModelAsync(FlowTestDataModel flowTestDataModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTestData_Create]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("@FlowTestId", flowTestDataModel.FlowTestId);
			p.Add("@AssetRole", flowTestDataModel.AssetRole);
			p.Add("@AssetRoleId", flowTestDataModel.AssetRoleId);
			p.Add("@Asset", flowTestDataModel.Asset);
			p.Add("@AssetTypeId", flowTestDataModel.AssetTypeId);
			p.Add("@AssetId", flowTestDataModel.AssetId);
			p.Add("@Nozzles", flowTestDataModel.Nozzles);
			p.Add("@NozzleId", flowTestDataModel.NozzleId);
			p.Add("@StaticPsi", flowTestDataModel.StaticPsi);
			p.Add("@TestPsi", flowTestDataModel.TestPsi);
			p.Add("@Flow", flowTestDataModel.Flow);
			p.Add("@ModelStaticPsi", flowTestDataModel.ModelStaticPsi);
			p.Add("@ModelTestPsi", flowTestDataModel.ModelTestPsi);
			p.Add("@ModelFlow", flowTestDataModel.ModelFlow);
			p.Add("@Elevation", flowTestDataModel.Elevation);
			p.Add("@DischargeCoeff", flowTestDataModel.DischargeCoeff);
			p.Add("@Multiplier", flowTestDataModel.Multiplier);

			await SqlDataAccess.SaveDataAsync(sql, p, connectionString, true);

			flowTestDataModel.Id = p.Get<int>("@Id");
		}

		public void CreateFlowTestModel(FlowTestModel flowTestModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTest_Create]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("@TestName", flowTestModel.TestName);
			p.Add("@TestDate", flowTestModel.TestDate);
			p.Add("@TestCurrent", flowTestModel.TestCurrent);

			SqlDataAccess.SaveData(sql, p, connectionString, true);

			flowTestModel.Id = p.Get<int>("@Id");

			foreach ( FlowTestDataModel testData in flowTestModel.TestData )
			{
				if ( testData.Id == 0 )
				{
					testData.FlowTestId = flowTestModel.Id;
					CreateFlowTestDataModel(testData, connectionString);
				}
				else
				{
					testData.FlowTestId = flowTestModel.Id;
					UpdateFlowTestDataModel(testData, connectionString);
				}
			}
		}

		public async Task CreateFlowTestModelAsync(FlowTestModel flowTestModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTest_Create]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("@TestName", flowTestModel.TestName);
			p.Add("@TestDate", flowTestModel.TestDate);
			p.Add("@TestCurrent", flowTestModel.TestCurrent);

			await SqlDataAccess.SaveDataAsync(sql, p, connectionString, true);

			flowTestModel.Id = p.Get<int>("@Id");

			foreach ( FlowTestDataModel testData in flowTestModel.TestData )
			{
				if ( testData.Id == 0 )
				{
					testData.FlowTestId = flowTestModel.Id;
					// TODO -- modify for distributed processing to collect the tasks and await all
					await CreateFlowTestDataModelAsync(testData, connectionString);
				}
				else
				{
					testData.FlowTestId = flowTestModel.Id;
					// TODO -- modify for distributed processing to collect the tasks and await all
					await UpdateFlowTestDataModelAsync(testData, connectionString);
				}
			}
		}

		public List<FlowTestDataModel> RetrieveAllFlowTestDataModels(string connectionString)
		{
			List<FlowTestDataModel> output;

			string sql = "[dbo].[spFlowTestData_RetrieveAll]";

			DynamicParameters p = new DynamicParameters();

			output = SqlDataAccess.LoadData<FlowTestDataModel, DynamicParameters>(sql, p, connectionString, true).ToList();

			return output;
		}

		public async Task<List<FlowTestDataModel>> RetrieveAllFlowTestDataModelsAsync(string connectionString)
		{
			List<FlowTestDataModel> output;

			string sql = "[dbo].[spFlowTestData_RetrieveAll]";

			DynamicParameters p = new DynamicParameters();

			output = (await SqlDataAccess.LoadDataAsync<FlowTestDataModel, DynamicParameters>(sql, p, connectionString, true)).ToList();

			return output;
		}

		public FlowTestDataModel RetrieveFlowTestDataModelById(int id, string connectionString)
		{
			FlowTestDataModel output;

			string sql = "[dbo].[spFlowTestData_RetrieveById]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", id);

			output = SqlDataAccess.LoadData<FlowTestDataModel, DynamicParameters>(sql, p, connectionString, true).FirstOrDefault();

			return output;
		}

		public async Task<FlowTestDataModel> RetrieveFlowTestDataModelByIdAsync(int id, string connectionString)
		{
			FlowTestDataModel output;

			string sql = "[dbo].[spFlowTestData_RetrieveById]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", id);

			output = (await SqlDataAccess.LoadDataAsync<FlowTestDataModel, DynamicParameters>(sql, p, connectionString, true)).FirstOrDefault();

			return output;
		}

		public List<FlowTestModel> RetrieveAllFlowTestModels(string connectionString)
		{
			List<FlowTestModel> output;

			string sql = "[dbo].[spFlowTest_RetrieveAll]";

			DynamicParameters p = new DynamicParameters();

			output = SqlDataAccess.LoadData<FlowTestModel, DynamicParameters>(sql, p, connectionString, true).ToList();

			foreach ( FlowTestModel testModel in output )
			{
				List<FlowTestDataModel> flowTestData = RetrieveFlowTestDataModelsByFlowTestId(testModel.Id, connectionString);
				foreach ( FlowTestDataModel testDataModel in flowTestData )
				{
					testModel.TestData.Add(testDataModel);
				}
			}

			return output;
		}

		private List<FlowTestDataModel> RetrieveFlowTestDataModelsByFlowTestId(int flowTestId, string connectionString)
		{
			List<FlowTestDataModel> output;

			string sql = "[dbo].[spFlowTestData_RetrieveByFlowTestId]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@FlowTestId", flowTestId);

			output = SqlDataAccess.LoadData<FlowTestDataModel, DynamicParameters>(sql, p, connectionString, true).ToList();

			return output;
		}

		public async Task<List<FlowTestModel>> RetrieveAllFlowTestModelsAsync(string connectionString)
		{
			List<FlowTestModel> output;

			string sql = "[dbo].[spFlowTest_RetrieveAll]";

			DynamicParameters p = new DynamicParameters();

			output = (await SqlDataAccess.LoadDataAsync<FlowTestModel, DynamicParameters>(sql, p, connectionString, true)).ToList();

			foreach ( FlowTestModel testModel in output )
			{
				// TODO -- modify for distributed processing to collect the tasks and await all
				List<FlowTestDataModel> flowTestData = await RetrieveFlowTestDataModelsByFlowTestIdAsync(testModel.Id, connectionString);
				foreach ( FlowTestDataModel testDataModel in flowTestData )
				{
					testModel.TestData.Add(testDataModel);
				}
			}

			return output;
		}

		private async Task<List<FlowTestDataModel>> RetrieveFlowTestDataModelsByFlowTestIdAsync(int flowTestId, string connectionString)
		{
			List<FlowTestDataModel> output;

			string sql = "[dbo].[spFlowTestData_RetrieveByFlowTestId]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@FlowTestId", flowTestId);

			output = (await SqlDataAccess.LoadDataAsync<FlowTestDataModel, DynamicParameters>(sql, p, connectionString, true)).ToList();

			return output;
		}

		public FlowTestModel RetrieveFlowTestModelById(int id, string connectionString)
		{
			FlowTestModel output;

			string sql = "[dbo].[spFlowTest_RetrieveById]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", id);

			output = SqlDataAccess.LoadData<FlowTestModel, DynamicParameters>(sql, p, connectionString, true).FirstOrDefault();

			List<FlowTestDataModel> flowTestData = RetrieveFlowTestDataModelsByFlowTestId(output.Id, connectionString);
			foreach ( FlowTestDataModel testDataModel in flowTestData )
			{
				output.TestData.Add(testDataModel);
			}

			return output;
		}

		public async Task<FlowTestModel> RetrieveFlowTestModelByIdAsync(int id, string connectionString)
		{
			FlowTestModel output;

			string sql = "[dbo].[spFlowTest_RetrieveById]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", id);

			output = (await SqlDataAccess.LoadDataAsync<FlowTestModel, DynamicParameters>(sql, p, connectionString, true)).FirstOrDefault();

			List<FlowTestDataModel> flowTestData = await RetrieveFlowTestDataModelsByFlowTestIdAsync(output.Id, connectionString);
			foreach ( FlowTestDataModel testDataModel in flowTestData )
			{
				output.TestData.Add(testDataModel);
			}

			return output;
		}

		public void UpdateFlowTestDataModel(FlowTestDataModel flowTestDataModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTestData_Update]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", flowTestDataModel.Id);
			p.Add("@FlowTestId", flowTestDataModel.FlowTestId);
			p.Add("@AssetRole", flowTestDataModel.AssetRole);
			p.Add("@AssetRoleId", flowTestDataModel.AssetRoleId);
			p.Add("@Asset", flowTestDataModel.Asset);
			p.Add("@AssetTypeId", flowTestDataModel.AssetTypeId);
			p.Add("@AssetId", flowTestDataModel.AssetId);
			p.Add("@Nozzles", flowTestDataModel.Nozzles);
			p.Add("@NozzleId", flowTestDataModel.NozzleId);
			p.Add("@StaticPsi", flowTestDataModel.StaticPsi);
			p.Add("@TestPsi", flowTestDataModel.TestPsi);
			p.Add("@Flow", flowTestDataModel.Flow);
			p.Add("@ModelStaticPsi", flowTestDataModel.ModelStaticPsi);
			p.Add("@ModelTestPsi", flowTestDataModel.ModelTestPsi);
			p.Add("@ModelFlow", flowTestDataModel.ModelFlow);
			p.Add("@Elevation", flowTestDataModel.Elevation);
			p.Add("@DischargeCoeff", flowTestDataModel.DischargeCoeff);
			p.Add("@Multiplier", flowTestDataModel.Multiplier);

			SqlDataAccess.SaveData(sql, p, connectionString, true);
		}

		public async Task UpdateFlowTestDataModelAsync(FlowTestDataModel flowTestDataModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTestData_Update]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", flowTestDataModel.Id);
			p.Add("@FlowTestId", flowTestDataModel.FlowTestId);
			p.Add("@AssetRole", flowTestDataModel.AssetRole);
			p.Add("@AssetRoleId", flowTestDataModel.AssetRoleId);
			p.Add("@Asset", flowTestDataModel.Asset);
			p.Add("@AssetTypeId", flowTestDataModel.AssetTypeId);
			p.Add("@AssetId", flowTestDataModel.AssetId);
			p.Add("@Nozzles", flowTestDataModel.Nozzles);
			p.Add("@NozzleId", flowTestDataModel.NozzleId);
			p.Add("@StaticPsi", flowTestDataModel.StaticPsi);
			p.Add("@TestPsi", flowTestDataModel.TestPsi);
			p.Add("@Flow", flowTestDataModel.Flow);
			p.Add("@ModelStaticPsi", flowTestDataModel.ModelStaticPsi);
			p.Add("@ModelTestPsi", flowTestDataModel.ModelTestPsi);
			p.Add("@ModelFlow", flowTestDataModel.ModelFlow);
			p.Add("@Elevation", flowTestDataModel.Elevation);
			p.Add("@DischargeCoeff", flowTestDataModel.DischargeCoeff);
			p.Add("@Multiplier", flowTestDataModel.Multiplier);

			await SqlDataAccess.SaveDataAsync(sql, p, connectionString, true);
		}

		public void UpdateFlowTestModel(FlowTestModel flowTestModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTest_Update]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", flowTestModel.Id);
			p.Add("@TestName", flowTestModel.TestName);
			p.Add("@TestDate", flowTestModel.TestDate);
			p.Add("@TestCurrent", flowTestModel.TestCurrent);

			SqlDataAccess.SaveData(sql, p, connectionString, true);

			foreach ( FlowTestDataModel testData in flowTestModel.TestData )
			{
				if ( testData.Id == 0 )
				{
					testData.FlowTestId = flowTestModel.Id;
					CreateFlowTestDataModel(testData, connectionString);
				}
				else
				{
					testData.FlowTestId = flowTestModel.Id;
					UpdateFlowTestDataModel(testData, connectionString);
				}
			}
		}

		public async Task UpdateFlowTestModelAsync(FlowTestModel flowTestModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTest_Update]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", flowTestModel.Id);
			p.Add("@TestName", flowTestModel.TestName);
			p.Add("@TestDate", flowTestModel.TestDate);
			p.Add("@TestCurrent", flowTestModel.TestCurrent);

			await SqlDataAccess.SaveDataAsync(sql, p, connectionString, true);

			foreach ( FlowTestDataModel testData in flowTestModel.TestData )
			{
				if ( testData.Id == 0 )
				{
					testData.FlowTestId = flowTestModel.Id;
					// TODO -- modify for distributed processing to collect the tasks and await all
					await CreateFlowTestDataModelAsync(testData, connectionString);
				}
				else
				{
					testData.FlowTestId = flowTestModel.Id;
					// TODO -- modify for distributed processing to collect the tasks and await all
					await UpdateFlowTestDataModelAsync(testData, connectionString);
				}
			}
		}

		public void DeleteFlowTestDataModel(FlowTestDataModel flowTestDataModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTestData_Delete]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", flowTestDataModel.Id);

			SqlDataAccess.SaveData(sql, p, connectionString, true);
		}

		public async Task DeleteFlowTestDataModelAsync(FlowTestDataModel flowTestDataModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTestData_Delete]";

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", flowTestDataModel.Id);

			await SqlDataAccess.SaveDataAsync(sql, p, connectionString, true);
		}

		public void DeleteFlowTestModel(FlowTestModel flowTestModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTest_Delete]";

			foreach ( FlowTestDataModel testData in flowTestModel.TestData )
			{
				if ( testData.Id == 0 )
				{
					flowTestModel.TestData.Remove(testData);
				}
				else
				{
					testData.FlowTestId = flowTestModel.Id;
					DeleteFlowTestDataModel(testData, connectionString);
					flowTestModel.TestData.Remove(testData);
				}
			}

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", flowTestModel.Id);

			SqlDataAccess.SaveData(sql, p, connectionString, true);
		}

		public async Task DeleteFlowTestModelAsync(FlowTestModel flowTestModel, string connectionString)
		{
			string sql = "[dbo].[spFlowTest_Delete]";

			foreach ( FlowTestDataModel testData in flowTestModel.TestData )
			{
				if ( testData.Id == 0 )
				{
					flowTestModel.TestData.Remove(testData);
				}
				else
				{
					testData.FlowTestId = flowTestModel.Id;
					// TODO -- modify for distributed processing to collect the tasks and await all
					await DeleteFlowTestDataModelAsync(testData, connectionString);
					flowTestModel.TestData.Remove(testData);
				}
			}

			DynamicParameters p = new DynamicParameters();
			p.Add("@Id", flowTestModel.Id);

			await SqlDataAccess.SaveDataAsync(sql, p, connectionString, true);
		}
	}
}
