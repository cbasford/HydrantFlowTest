using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowTestLibrary.Models;
using System.Windows.Forms;
using FlowTestLibrary.DataAccess;
using FlowTestLibrary;

namespace FlowTestLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "Engineering";

        public void CreateCustomer(CustomerModel customer)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", customer.FirstName);
                p.Add("@LastName", customer.LastName);
                p.Add("@Company", customer.Company);
                p.Add("@Address1", customer.Address1);
                p.Add("@Address2", customer.Address2);
                p.Add("@City", customer.City);
                p.Add("@State", customer.State);
                p.Add("@Zip", customer.Zip);
                p.Add("@Phone", customer.PhoneNumber);
                p.Add("@Email", customer.EmailAddress);
                p.Add("@CreatedDate", customer.CreatedDate.Date);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("task.spCustomer_AddNew", p, commandType: CommandType.StoredProcedure);
                customer.Id = p.Get<int>("@id");
            }

        }

        public void CreateFlowTest(RequestModel request)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Title", request.Title);
                p.Add("@RequestID", request.Id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("task.spFlowTest_AddNew", p, commandType: CommandType.StoredProcedure);
                request.FlowTestId = p.Get<int>("@id");
            }
        }


        public void CreateRequest(RequestModel request)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Title", request.Title);
                p.Add("@RequestDate", request.RequestDate);
                p.Add("@RequestType", request.RequestType);
                p.Add("@CustomerId", request.CustomerId);
                p.Add("@CustomerNotes", request.CustomerNotes);
                //p.Add("@WwNotes", request.WwNotes);
                //p.Add("@FlowTestId", request.FlowTestId);
                p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("task.spRequest_AddNew", p, commandType: CommandType.StoredProcedure);

                request.Id = p.Get<int>("@ID");
           
            }

        }


        public void SaveRequest(RequestModel request)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", request.Id);
                p.Add("@Title", request.Title);
                p.Add("@CustomerID", request.CustomerId);
                p.Add("@IsClosed", request.IsClosed);
                p.Add("@FlowTestID", request.FlowTestId);
                p.Add("@WwNotes", request.WwNotes);
                p.Add("@CloseDate", request.CloseDate);
                connection.Execute("task.spRequest_Update", p, commandType: CommandType.StoredProcedure);
            }

        }

        // todo
        public void SaveFlowTestPoint(FlowTestDataModel data)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@FlowTestId", data.FlowTestId);
                p.Add("@AssetRoleID", data.AssetRoleId);
                p.Add("@AssetTypeID", data.AssetTypeId);
                p.Add("@AssetNumber", data.AssetId);
                p.Add("@HydrantNozzleID", data.NozzleId);
                p.Add("@StaticPsi", data.StaticPsi);
                p.Add("@ResidualPsi", data.TestPsi);
                connection.Execute("task.spFlowPoint_AddNew", p, commandType: CommandType.StoredProcedure);
            }
        }


        public void DeleteFlowTestData(int id)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@ID", id);
                connection.Execute("task.spFlowPoint_Delete", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateFlowTestData(FlowTestDataModel data)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@ID", data.Id);
                p.Add("@AssetRoleID", data.AssetRoleId);
                p.Add("@AssetTypeID", data.AssetTypeId);
                p.Add("@AssetNumber", data.AssetId);
                p.Add("@HydrantNozzleID", data.NozzleId);
                p.Add("@StaticPsi", data.StaticPsi);
                p.Add("@ResidualPsi", data.TestPsi);
    
                connection.Execute("task.spFlowPoint_Update", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateModelData(FlowTestDataModel data)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@ID", data.Id);
                p.Add("@ModelStaticPsi", data.ModelStaticPsi);
                p.Add("@ModelTestPsi", data.ModelTestPsi);
                p.Add("@ModelFlow", data.ModelFlow);
                p.Add("@Elevation", data.Elevation);

                connection.Execute("task.spModelRun_Update", p, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Empties table used to map flow and residual hydrants.
        /// </summary>
        public void ClearMapData()
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();

                connection.Execute("task.sp_ClearGisMapSelection", p, commandType: CommandType.StoredProcedure);
            }
        }


        public void AddMapData(int flowTestId)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@FlowTestId", flowTestId);
                connection.Execute("task.sp_AddGisSelection", p, commandType: CommandType.StoredProcedure);
            }
        }


        public List<CustomerModel> GetCustomer_All()
        {
            List<CustomerModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<CustomerModel>("task.spCustomer_GetAll").ToList();
            }

            return output;
        }

        public List<RequestModel> GetRequest_All(bool IsClosed)
        {
            List<RequestModel> output;
            var p = new DynamicParameters();
            p.Add("@IsClosed", IsClosed);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<RequestModel>("task.spRequest_GetAll", p, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }



        public List<FlowTestModel> GetFlowTest_All()
        {
            List<FlowTestModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<FlowTestModel>("task.spFlowTest_GetAll").ToList();
            }

            return output;
        }

 
        public List<FlowTestDataModel> GetFlowTestData(int DataId)
        {
            //if (DataId is null) DataId = 0;
            List<FlowTestDataModel> output;
            var p = new DynamicParameters();
            p.Add("@FlowTestID", DataId);

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<FlowTestDataModel>("task.spFlowTest_GetData", p, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }


        public List<HydrantPressureModel> GetHydrantPsi(int HydrantId)
        {
            List<HydrantPressureModel> output;
            var p = new DynamicParameters();
            p.Add("@HydrantId", HydrantId);
            // Going to the production database
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("ADOConnectionEng")))
            {
                output = connection.Query<HydrantPressureModel>("task.spHydrantPsi_Get", p, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }






        public List<RequestTypeModel> GetRequestTypes()
        {
            List<RequestTypeModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<RequestTypeModel>("task.spRequestType_GetAll").ToList();
            }

            return output;
        }

        public void CreateFlowTest(FlowTestModel flowTest)
        {
            throw new System.NotImplementedException();
        }

        public List<HydrantPressureModel> GetHydrantPressures(int HydrantId)
        {
            throw new System.NotImplementedException();
        }


    }
}
