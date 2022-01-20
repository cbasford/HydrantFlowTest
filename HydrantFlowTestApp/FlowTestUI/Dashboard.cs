using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowTestLibrary;
using FlowTestLibrary.Epanet;
using FlowTestLibrary.Models;

namespace FlowTestUI
{
    public partial class Dashboard : Form
    {
        private List<RequestModel> request = GlobalConfig.Connection.GetRequest_All(true);
        private List<CustomerModel> customer = GlobalConfig.Connection.GetCustomer_All();
        private List<RequestTypeModel> requestType = GlobalConfig.Connection.GetRequestTypes();

        public Dashboard()
        {
            InitializeComponent();
            // Default view to open requests
            openRequestRadioButton.Checked = true;
            bool bVal = ModelApps.OpenModel();
            if (!bVal) MessageBox.Show("error opening model");
            //bool bVal = ModelApps.OpenModel();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            requestListView.View = System.Windows.Forms.View.Details;
            CreateRequestListView();

            //customerComboBox.DataSource = customer;
            //customerComboBox.DisplayMember = "FullName";
            //customerComboBox.Refresh();

            requestTypeComboBox.DataSource = requestType;
            requestTypeComboBox.DisplayMember = "RequestType";
        }

        private void CreateRequestListView()
        {
            bool IsClosed;
            if (openRequestRadioButton.Checked)
            {
                IsClosed = false;
            }
            else
            {
                IsClosed = true;
            }

            requestListView.Clear();
            request.RemoveAll(request => request.Id >= 0);

            List<RequestModel> req = GlobalConfig.Connection.GetRequest_All(IsClosed);
            foreach (RequestModel re in req)
            {
                request.Add(re);
            }



            // Set the view to show details.
            requestListView.View = System.Windows.Forms.View.Details;
            // Allow the user to edit item text.
            requestListView.LabelEdit = false;
            // Allow the user to rearrange columns.
            requestListView.AllowColumnReorder = true;
            // Display check boxes.
            requestListView.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            requestListView.FullRowSelect = true;
            // Display grid lines.
            requestListView.GridLines = true;
            // Sort the items in the list in ascending order.
            requestListView.Sorting = SortOrder.Ascending;
            //requestListView.Sorting();

            requestListView.Columns.Add("Id", 35, System.Windows.Forms.HorizontalAlignment.Center);
            requestListView.Columns.Add("Category", 95, System.Windows.Forms.HorizontalAlignment.Left);
            requestListView.Columns.Add("Title", 130, System.Windows.Forms.HorizontalAlignment.Left);
            requestListView.Columns.Add("RequestDate", 80, System.Windows.Forms.HorizontalAlignment.Center);
            requestListView.Columns.Add("DaysOpen", 50, System.Windows.Forms.HorizontalAlignment.Center);   //*****************

            foreach (RequestModel r in request)
            {
                AddListViewItem(r.Id.ToString(), r.RequestType, r.Title, r.RequestDateOnly, r.DaysOpen.ToString());  //*************
            }

            // Add the ListView to the control collection.
            this.Controls.Add(requestListView);
        }

        private void AddListViewItem(string id, string requestType, string title, string requestDate, string DaysOpen)  //*********
        {
            ListViewItem eachRow = new ListViewItem(id, 0);
            ListViewItem.ListViewSubItem rowRequestType = new ListViewItem.ListViewSubItem(eachRow, requestType);
            ListViewItem.ListViewSubItem rowTitle = new ListViewItem.ListViewSubItem(eachRow, title);
            ListViewItem.ListViewSubItem rowDate = new ListViewItem.ListViewSubItem(eachRow, requestDate);
            ListViewItem.ListViewSubItem rowOpendays = new ListViewItem.ListViewSubItem(eachRow, DaysOpen);  //*******

            eachRow.SubItems.Add(rowRequestType);
            eachRow.SubItems.Add(rowTitle);
            eachRow.SubItems.Add(rowDate);
            eachRow.SubItems.Add(DaysOpen);  //***********

            requestListView.Items.Add(eachRow);
        }


        private void requestListView_MouseClick(object sender, MouseEventArgs e)
        {

            ClearAllTextBoxes();
            ListViewHitTestInfo hit = requestListView.HitTest(e.Location);

            // Get request id from the list box, then find it in the request model
            string s = requestListView.Items[requestListView.SelectedIndices[0]].SubItems[0].Text;
            int requestId = Int32.Parse(s);

            foreach (RequestModel r in request)
            {
                if (r.Id == requestId)
                {
                    // Populate text boxes
                    requestTitleTextBox.Text = r.Title;
                    requestTypeTextBox.Text = r.RequestType;
                    requestCustNoteTextBox.Text = r.CustomerNotes;
                    requestWwNoteTextBox.Text = r.WwNotes;
                    flowTestIdTextBox.Text = r.FlowTestId.ToString();
                    requestOpenDateTextBox.Text = r.RequestDate.ToString();
                    requestIdTextBox.Text = r.Id.ToString();
                    requestCloseDateTextBox.Text = r.CloseDate.ToString();

                    requestStatusCheckBox.Checked = r.IsClosed;

                    foreach (CustomerModel cm in customer)
                    {
                        if (cm.Id == r.CustomerId)
                        {
                            requestCustomerTextBox.Text = cm.FullName;

                            break;
                        }
                    }

                    // todo set map
                    string baseDir = GlobalConfig.FilePath("filePath");
                    string fileName = baseDir + "\\SiteMap\\Site" + flowTestIdTextBox.Text + ".jpg";
                    try
                    {
                        flowTestPictureBox.Image = System.Drawing.Image.FromFile(fileName);
                    }
                    catch
                    {
                        string catchFile = baseDir + "\\NullImage.jpg";
                        flowTestPictureBox.Image = System.Drawing.Image.FromFile(catchFile);
                    }

                    flowTestPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Populate flow test data if it exists
                    if (r.FlowTestId > 0)
                    {
                        FlowTestModel thisTest = GetFlowTest(r.FlowTestId);
                        CreateFlowTestRowsView(thisTest);
                    }

                }

            }
        }



        
        private void CreateFlowTestRowsView(FlowTestModel flowTest)
        {
            flowTestDataListView.Clear();
            // Get data
            List<FlowTestDataModel> testData = GlobalConfig.Connection.GetFlowTestData(flowTest.Id);
            flowTestDataListView.View = System.Windows.Forms.View.Details;
            flowTestDataListView.LabelEdit = false;
            flowTestDataListView.AllowColumnReorder = true;
            flowTestDataListView.CheckBoxes = false;
            flowTestDataListView.FullRowSelect = true;
            flowTestDataListView.GridLines = true;
            flowTestDataListView.Sorting = SortOrder.Ascending;

            flowTestDataListView.Columns.Add("Id", 35, System.Windows.Forms.HorizontalAlignment.Center);
            flowTestDataListView.Columns.Add("AssetRole", 100, System.Windows.Forms.HorizontalAlignment.Left);
            flowTestDataListView.Columns.Add("Asset", 55, System.Windows.Forms.HorizontalAlignment.Left);
            flowTestDataListView.Columns.Add("AssetId", 55, System.Windows.Forms.HorizontalAlignment.Center);
            flowTestDataListView.Columns.Add("Nozzles", 75, System.Windows.Forms.HorizontalAlignment.Center);
            flowTestDataListView.Columns.Add("StaticPsi", 55, System.Windows.Forms.HorizontalAlignment.Center);
            flowTestDataListView.Columns.Add("TestPsi", 55, System.Windows.Forms.HorizontalAlignment.Center);

            //new code
            flowTestDataListView.Columns.Add("ModelStaticPsi", 85, System.Windows.Forms.HorizontalAlignment.Center);
            flowTestDataListView.Columns.Add("ModelTestPsi", 85, System.Windows.Forms.HorizontalAlignment.Center);
            flowTestDataListView.Columns.Add("ModelFlow", 65, System.Windows.Forms.HorizontalAlignment.Center);
            // end new code

            int primaryResHydrant = 0;
            foreach (FlowTestDataModel dm in testData)
            {
                //AddFlowTestRows(dm.Id.ToString(), dm.AssetRole, dm.Asset, dm.AssetId.ToString(), dm.Nozzles, dm.StaticPsi.ToString(), dm.TestPsi.ToString(), dm.ModelStaticPsi.ToString(),
                //    dm.ModelTestPsi.ToString(), dm.ModelFlow.ToString());

                AddFlowTestRows(dm.Id.ToString(), dm.AssetRole, dm.Asset, dm.AssetId.ToString(), dm.Nozzles, dm.StaticPsi.ToString(), dm.TestPsi.ToString());

                if (dm.AssetRole == "Primary Residual")
                {
                    primaryResHydrant = dm.AssetId;
                    hydrantIdTextBox.Text = dm.AssetId.ToString();
                }
            }

            this.Controls.Add(flowTestDataListView);
            
            //Create chart
            //System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            //FirstSeries();
        }

        //private void FirstSeries()
        //{
        //    // Get data for hydrant 33
        //    int hydNo;
        //    try
        //    {
        //        hydNo = Int32.Parse(hydrantIdTextBox.Text);
        //    }
        //    catch
        //    {
        //        hydNo = 33;
        //    }
        //    List<HydrantPressureModel> hydPsi = new List<HydrantPressureModel>();
        //    hydPsi = GlobalConfig.Connection.GetHydrantPsi(hydNo);


        //    // get min psir
        //    double minYaxis = 200;
        //    foreach (HydrantPressureModel h in hydPsi)
        //    {
        //        if (h.Pressure < minYaxis)
        //            minYaxis = h.Pressure;
        //    }
        //    // floor minimum pressure to nearest 20
        //    minYaxis = 10 * Math.Floor(minYaxis / 10);



        //    // chartArea
        //    System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

        //    hydrantPressureChart.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;//x axis
        //                                                                         //chart1.ChartAreas[0].AxisY.LabelStyle.Format = "P";  //percent
        //                                                                         //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
        //    hydrantPressureChart.ChartAreas[0].AxisX.IsStartedFromZero = true;
        //    hydrantPressureChart.ChartAreas[0].AxisX.Interval = 2;
        //    hydrantPressureChart.ChartAreas[0].Axes[1].MajorGrid.Enabled = true;//y axis
        //    //hydrantPressureChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
        //    //hydrantPressureChart.ChartAreas[0].AxisY.IsStartedFromZero = true;
        //    hydrantPressureChart.ChartAreas[0].AxisY.Minimum = minYaxis;



        //    System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
        //    title1.BackColor = System.Drawing.Color.Transparent;
        //    title1.Name = "Title1";
        //    title1.Text = "Hydrant " + hydNo.ToString();
        //    this.hydrantPressureChart.Titles.RemoveAt(0);
        //    this.hydrantPressureChart.Titles.Add(title1);


        //    //Series
        //    System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
        //    hydrantPressureChart.Series.Add(series1);
        //    //Series style
        //    //series1.ChartType = SeriesChartType.Line;  // type
        //    series1.ChartType = SeriesChartType.Point;
        //    series1.BorderWidth = 2;
        //    series1.Color = System.Drawing.Color.Green;
        //    series1.LegendText = "Hyd " + hydNo.ToString();





        //    foreach (HydrantPressureModel h in hydPsi)
        //    {

        //        //series1.Points.AddXY(s[x], v);
        //        //MessageBox.Show(xVal[x].ToString() + "  " + v.ToString());
        //        series1.Points.AddXY(h.DecimalHour, h.Pressure);

        //    }

        //}




        private FlowTestModel GetFlowTest(int id)
        {
            List<FlowTestModel> flowTest = GlobalConfig.Connection.GetFlowTest_All();
            foreach (FlowTestModel f in flowTest)
            {
                if (f.Id == id)
                {
                    return f;
                }
            }

            return null;
        }


        private void ClearAllTextBoxes()
        {
            requestIdTextBox.Text = null;
            requestOpenDateTextBox.Text = null;
            requestCloseDateTextBox.Text = null;
            requestCustNoteTextBox.Text = null;
            requestWwNoteTextBox.Text = null;
            requestCustomerTextBox.Text = null;
            requestTitleTextBox.Text = null;
            requestTypeTextBox.Text = null;
            requestStatusCheckBox.Checked = false;

            customerComboBox.Text = null;
            requestTypeComboBox = null;
            requestTitleTextBox = null;
            customerNoteTextBox = null;

            // todo clear flow test data
            //flowTestDataListView.Clear();
            //flowTestDataIdTextBox.Text = null;
            //assetRoleCobmoBox.Text = null;
            //assetTypeComboBox.Text = null;
            //assetNumberTextBox.Text = null;
            //nozzleComboBox.Text = null;
            //staticPressureTextBox.Text = null;
            //testPressureTextBox.Text = null;

            //hydrantPressureChart.Series.Clear();

        }


        private void generateReportButton_Click(object sender, EventArgs e)
        {



        }

        private void createFlowTestButton_Click(object sender, EventArgs e)
        {

            int flowTestId = 0;
            switch (flowTestIdTextBox.Text)
            {
                case null:
                    flowTestId = 0;
                    break;
                case "0":
                    flowTestId = 0;
                    break;
                default:
                    flowTestId = Int32.Parse(flowTestIdTextBox.Text);
                    break;
            }

            if (flowTestId == 0)
            {
                // Create new flow test
                // Get the request object that created the flowtest
                foreach (RequestModel r in request)
                {

                    if (r.Id == Int32.Parse(requestIdTextBox.Text))
                    {
                        // Now create the test record in sql server and return the id
                        GlobalConfig.Connection.CreateFlowTest(r);
                        flowTestIdTextBox.Text = r.FlowTestId.ToString();
                        //// Open flow test form
                        FlowTestModel thisTest = GetFlowTest(r.FlowTestId);
                        CreateFlowTestRowsView(thisTest);
                        //FlowTestForm frm = new FlowTestForm(thisTest);
                        //frm.Show();
                        break;
                    }
                }
            }
            else
            {
                // Jump to existing flow test
                //FlowTestModel thisTest = GetFlowTest(flowTestId);
                //CreateFlowTestRowsView(thisTest);

            }
        }




        //private void CreateFlowTestRowsView(FlowTestModel flowTest)
        //{
        //    flowTestDataListView.Clear();
        //    // Get data
        //    List<FlowTestDataModel> testData = GlobalConfig.Connection.GetFlowTestData(flowTest.Id);
        //    flowTestDataListView.View = System.Windows.Forms.View.Details;
        //    flowTestDataListView.LabelEdit = false;
        //    flowTestDataListView.AllowColumnReorder = true;
        //    flowTestDataListView.CheckBoxes = false;
        //    flowTestDataListView.FullRowSelect = true;
        //    flowTestDataListView.GridLines = true;
        //    flowTestDataListView.Sorting = SortOrder.Ascending;

        //    flowTestDataListView.Columns.Add("Id", 35, System.Windows.Forms.HorizontalAlignment.Center);
        //    flowTestDataListView.Columns.Add("AssetRole", 100, System.Windows.Forms.HorizontalAlignment.Left);
        //    flowTestDataListView.Columns.Add("Asset", 55, System.Windows.Forms.HorizontalAlignment.Left);
        //    flowTestDataListView.Columns.Add("AssetId", 55, System.Windows.Forms.HorizontalAlignment.Center);
        //    flowTestDataListView.Columns.Add("Nozzles", 75, System.Windows.Forms.HorizontalAlignment.Center);
        //    flowTestDataListView.Columns.Add("StaticPsi", 55, System.Windows.Forms.HorizontalAlignment.Center);
        //    flowTestDataListView.Columns.Add("TestPsi", 55, System.Windows.Forms.HorizontalAlignment.Center);

        //    //new code
        //    flowTestDataListView.Columns.Add("ModelStaticPsi", 85, System.Windows.Forms.HorizontalAlignment.Center);
        //    flowTestDataListView.Columns.Add("ModelTestPsi", 85, System.Windows.Forms.HorizontalAlignment.Center);
        //    flowTestDataListView.Columns.Add("ModelFlow", 65, System.Windows.Forms.HorizontalAlignment.Center);
        //    // end new code

        //    int primaryResHydrant = 0;
        //    //foreach (FlowTestDataModel dm in testData)
        //    //{
        //    //    AddFlowTestRows(dm.Id.ToString(), dm.AssetRole, dm.Asset, dm.AssetId.ToString(), dm.Nozzles, dm.StaticPsi.ToString(), dm.TestPsi.ToString(), dm.ModelStaticPsi.ToString(),
        //    //        dm.ModelTestPsi.ToString(), dm.ModelFlow.ToString());
        //    //    if (dm.AssetRole == "Primary Residual")
        //    //    {
        //    //        primaryResHydrant = dm.AssetId;
        //    //        hydrantIdTextBox.Text = dm.AssetId.ToString();
        //    //    }
        //    //}

        //    this.Controls.Add(flowTestDataListView);


        //    //Create chart
        //    //System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
        //    //firstSeries();
        //}





            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="assetRole"></param>
            /// <param name="asset"></param>
            /// <param name="assetId"></param>
            /// <param name="nozzles"></param>
            /// <param name="staticPsi"></param>
            /// <param name="testPsi"></param>
        private void AddFlowTestRows(string id, string assetRole, string asset, string assetId, string nozzles, string staticPsi, string testPsi)
        {
            ListViewItem eachRow = new ListViewItem(id, 0);
            ListViewItem.ListViewSubItem rowAssetRole = new ListViewItem.ListViewSubItem(eachRow, assetRole);
            ListViewItem.ListViewSubItem rowAsset = new ListViewItem.ListViewSubItem(eachRow, asset);
            ListViewItem.ListViewSubItem rowAssetId = new ListViewItem.ListViewSubItem(eachRow, assetId);
            ListViewItem.ListViewSubItem rowNozzles = new ListViewItem.ListViewSubItem(eachRow, nozzles);
            ListViewItem.ListViewSubItem rowstaticPsi = new ListViewItem.ListViewSubItem(eachRow, staticPsi);
            ListViewItem.ListViewSubItem rowtestPsi = new ListViewItem.ListViewSubItem(eachRow, testPsi);

            eachRow.SubItems.Add(rowAssetRole);
            eachRow.SubItems.Add(rowAsset);
            eachRow.SubItems.Add(rowAssetId);
            eachRow.SubItems.Add(rowNozzles);
            eachRow.SubItems.Add(rowstaticPsi);
            eachRow.SubItems.Add(rowtestPsi);

            flowTestDataListView.Items.Add(eachRow);
        }

        private void openRequestRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CreateRequestListView();
        }

        private void updateRequestButton_Click(object sender, EventArgs e)
        {
            //get current request
            // Get request id from the list box, then find it in the request model
            int requestId;
            try
            {
                string s = requestListView.Items[requestListView.SelectedIndices[0]].SubItems[0].Text;
                requestId = Int32.Parse(s);
            }
            catch
            {
                requestId = 1;
            }

            // set status
            foreach (RequestModel r in request)
            {
                if (r.Id == requestId)
                {
                    r.IsClosed = requestStatusCheckBox.Checked;
                    r.Title = requestTitleTextBox.Text;
                    r.WwNotes = requestWwNoteTextBox.Text;

                    if (requestStatusCheckBox.Checked)
                    {
                        r.CloseDate = DateTime.Now;
                    }
                    else
                    {
                        r.CloseDate = null;
                    }
                    // update database
                    GlobalConfig.Connection.SaveRequest(r);
                    break;
                }
            }

            // Clear requests
            // reload requests
            CreateRequestListView();
        }

        private void newRequestButton_Click(object sender, EventArgs e)
        {

        }

        private void customerComboBox_Enter(object sender, EventArgs e)
        {
            customer.RemoveAll(customer => customer.Id >= 0);
            List<CustomerModel> c = GlobalConfig.Connection.GetCustomer_All();

            foreach (CustomerModel cm in c)
            {
                customer.Add(cm);
            }

            customerComboBox.DataSource = null;
            customerComboBox.DataSource = customer;
            customerComboBox.DisplayMember = "FullName";
            customerComboBox.Refresh();
        }

        private void customerLabel_Click(object sender, EventArgs e)
        {

        }

        private void addRequestButton_Click(object sender, EventArgs e)
        {
            if (flowTestDataIdTextBox.Text == "0")
            {
                MessageBox.Show("You need to create a flow test first");
                // todo addnew flow test in this condition
            }
            request.RemoveAll(request => request.Id >= 0);
            //  TODO Validate entries
            RequestModel request1 = new RequestModel();
            request1.Title = newRequestTitleTextBox.Text;

            string cu = customerComboBox.Text;
            foreach (CustomerModel cus in customer)
            {
                if (cu == cus.FullName) request1.CustomerId = cus.Id;
            }

            request1.CustomerNotes = customerNoteTextBox.Text;
            request1.RequestType = requestTypeComboBox.Text;
            request1.RequestDate = System.DateTime.Now;
            GlobalConfig.Connection.CreateRequest(request1);
            List<RequestModel> c = GlobalConfig.Connection.GetRequest_All(true);

            foreach (RequestModel cm in c)
            {
                request.Add(cm);
            }

            //Refresh request list
            requestListView.Clear();
            CreateRequestListView();
        }
    }
}
