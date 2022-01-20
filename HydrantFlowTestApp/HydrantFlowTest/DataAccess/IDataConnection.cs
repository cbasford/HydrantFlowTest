using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowTestLibrary.Models;


namespace FlowTestLibrary.DataAccess
{
    public interface IDataConnection
    {
        void CreateCustomer(CustomerModel customer);
        void CreateFlowTest(RequestModel request);
        void CreateRequest(RequestModel request);
        void SaveRequest(RequestModel request);
        void DeleteFlowTestData(int id);
        void SaveFlowTestPoint(FlowTestDataModel data);
        void UpdateFlowTestData(FlowTestDataModel data);
        void UpdateModelData(FlowTestDataModel data);
        void ClearMapData();

        void AddMapData(int flowTestId);


        List<RequestTypeModel> GetRequestTypes();
        List<CustomerModel> GetCustomer_All();
        List<RequestModel> GetRequest_All(bool IsClosed);
        List<FlowTestModel> GetFlowTest_All();
        List<FlowTestDataModel> GetFlowTestData(int DataId);

        List<HydrantPressureModel> GetHydrantPsi(int HydrantId);

    }
}
