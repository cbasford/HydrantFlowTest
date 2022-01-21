using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing;
using Microsoft.Office.Core;

using DataAccessLibrary.DataAccess;

using HydrantFlowTest.Models;

namespace HydrantFlowTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //MakePdf();
            FlowTestModel flowTest = new FlowTestModel();
            FlowTestDataModel flowTestData = new FlowTestDataModel();
            HydrantFlowTest.Methods.AddData(flowTest, flowTestData);
            Test(flowTest, flowTestData);
        }

        private static void Test(FlowTestModel flowTest, FlowTestDataModel flowtestData)
        {
            //OBJECT OF MISSING "NULL VALUE"
            Object oMissing = System.Reflection.Missing.Value;
            //OBJECTS OF FALSE AND TRUE
            Object oTrue = true;
            Object oFalse = false;
            //CREATING OBJECTS OF WORD AND DOCUMENT
            Word.Application oWord = new Word.Application();

            //MAKING THE APPLICATION VISIBLE
            oWord.Visible = true;

            // Create a nre document
            //Word.Document oWordDoc = new Word.Document();

            // Open a template
            Object oTemplatePath = @"J:\HydraulicModel\FlowRequest\ReportTemplate.dotx";
            Word.Document oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing);

            //ADDING A NEW DOCUMENT TO THE APPLICATION
            //oWordDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);


            // **** Update fields in document ****//
            int iTotalFields = 0;
            foreach (Word.Field myMergeField in oWordDoc.Fields)
            {
                iTotalFields++;
                Word.Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                // ONLY GETTING THE MAILMERGE FIELDS
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    // THE TEXT COMES IN THE FORMAT OF
                    // MERGEFIELD  MyFieldName  \\* MERGEFORMAT
                    // THIS HAS TO BE EDITED TO GET ONLY THE FIELDNAME "MyFieldName"
                    Int32 endMerge = fieldText.IndexOf("\\");
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText.Substring(11, endMerge - 11);
                    // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE
                    fieldName = fieldName.Trim();

                    // **** Update fields in document ****//
                    myMergeField.Select();
                    switch ( fieldName )
                    {
                        case "DatePrepared":
                            oWord.Selection.TypeText(System.DateTime.Now.ToString("MM/dd/yyyy"));
                            break;
                        case "CustomerName":
                            oWord.Selection.TypeText("Bugs Bunny");
                            break;
                        case "Company":
                            oWord.Selection.TypeText("ACME Dynamite Corp.");
                            break;
                        case "Address":
                            oWord.Selection.TypeText("120 Main St");
                            break;
                        case "City":
                            oWord.Selection.TypeText("Somewhere");
                            break;
                        case "State":
                            oWord.Selection.TypeText("UT");
                            break;
                        case "Zip":
                            oWord.Selection.TypeText("12345");
                            break;
                        case "Email":
                            oWord.Selection.TypeText("bugs.bunny@acme.com");
                            break;
                        case "Title":
                            oWord.Selection.TypeText("Bugs Bunny and Road Runner");
                            break;
                        case "TestDate":
                            oWord.Selection.TypeText(System.DateTime.Now.ToString());
                            break;
                        case "ResidualHydId":
                            oWord.Selection.TypeText("123");
                            break;
                        case "StaticPsi":
                            oWord.Selection.TypeText("55 psi");
                            break;
                        case "ResidualPsi":
                            oWord.Selection.TypeText("45 psi");
                            break;
                        case "FlowHydId":
                            oWord.Selection.TypeText("321");
                            break;
                        case "Nozzles":
                            oWord.Selection.TypeText("(1) 2-1/5");
                            break;
                        case "PitotPsi":
                            oWord.Selection.TypeText("35 psi");
                            break;
                        case "Flow":
                            oWord.Selection.TypeText("1200 gpm");
                            break;
                        case "FlowAt20":
                            oWord.Selection.TypeText("2500 gpm");
                            break;
                        case "RequestId":
                            oWord.Selection.TypeText("1234");
                            break;
                        case "TestId":
                            oWord.Selection.TypeText("2001");
                            break;
                        default:
                            // Do nothing
                            break;
                    }

                }
            }

            //-------------------

            //SETTING THE FOCUES ON THE PAGE FOOTER
            oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;
            //ENTERING A PARAGRAPH BREAK "ENTER"
            oWord.Selection.TypeParagraph();
            String requestId = "1";
            String testId = "0";
            //INSERTING THE PAGE NUMBERS CENTRALLY ALIGNED IN THE PAGE FOOTER
            oWord.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oWord.ActiveWindow.Selection.Font.Name = "Arial";
            oWord.ActiveWindow.Selection.Font.Size = 8;
            oWord.ActiveWindow.Selection.TypeText("Request ID: " + requestId + ", Test ID: " + testId);
            //INSERTING TAB CHARACTERS
            oWord.ActiveWindow.Selection.TypeText("\t");
            oWord.ActiveWindow.Selection.TypeText("\t");
            oWord.ActiveWindow.Selection.TypeText("Page ");
            Object CurrentPage = Word.WdFieldType.wdFieldPage;
            oWord.ActiveWindow.Selection.Fields.Add(oWord.Selection.Range, ref CurrentPage, ref oMissing, ref oMissing);
            oWord.ActiveWindow.Selection.TypeText(" of ");
            Object TotalPages = Word.WdFieldType.wdFieldNumPages;
            oWord.ActiveWindow.Selection.Fields.Add(oWord.Selection.Range, ref TotalPages, ref oMissing, ref oMissing);
            //SETTING FOCUES BACK TO DOCUMENT
            oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;




            int stopHere = 1;



















            //EMBEDDING LOGOS IN THE DOCUMENT
            //SETTING FOCUES ON THE PAGE HEADER TO EMBED THE WATERMARK
            oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;
            //THE LOGO IS ASSIGNED TO A SHAPE OBJECT SO THAT WE CAN USE ALL THE
            //SHAPE FORMATTING OPTIONS PRESENT FOR THE SHAPE OBJECT
            Word.Shape logoCustom = null;
            //THE PATH OF THE LOGO FILE TO BE EMBEDDED IN THE HEADER
            String logoPath = @"J:\HydraulicModel\FlowRequest\SnowPhoto.jpg";
            logoCustom = oWord.Selection.HeaderFooter.Shapes.AddPicture(logoPath,
                ref oFalse, ref oTrue, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            logoCustom.Select(ref oMissing);
            logoCustom.Name = "CustomLogo";
            logoCustom.Left = (float)Word.WdShapePosition.wdShapeLeft;
            logoCustom.Height = 30;
            logoCustom.Width = 46;
            //SETTING FOCUES BACK TO DOCUMENT
            oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;


            // Add some text in the document
            oWord.Selection.Paragraphs.DecreaseSpacing();
            oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
            oWord.Selection.TypeParagraph();
            oWord.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oWord.ActiveWindow.Selection.Font.Name = "Arial";
            oWord.ActiveWindow.Selection.Font.Size = 8;
            oWord.ActiveWindow.Selection.TypeText(flowTest.TestName.ToString());
            oWord.ActiveWindow.Selection.TypeText("\r");
            oWord.ActiveWindow.Selection.TypeText(flowTest.TestDate.ToString());


            //Word.Shape theImage = null;
            //oWord.Selection.InlineShapes.AddPicture(logoPath);
            //oWord.Selection.InlineShapes.AddHorizontalLine();
















        }




        private static void MakePdf()
        {

            // make sure Word was not opened
            foreach (System.Diagnostics.Process item in System.Diagnostics.Process.GetProcesses())
            {
                if (item.ProcessName == "WINWORD")
                    item.Kill();
            }
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();

            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            ////Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "City of Newport News";
            oPara1.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oPara1.Range.Font.Bold = 0;
            oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();

            //Insert a paragraph at the end of the document.
            Word.Paragraph oPara2;
            oPara1.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara2.Range.Text = "Hydrant Flow Test";
            oPara2.Format.SpaceAfter = 6;
            oPara2.Range.InsertParagraphAfter();

            
            object oRng1 = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oDoc.Application.Selection.InlineShapes.AddHorizontalLineStandard(ref oRng1);

            ////Add some text after the table.
            Word.Paragraph oPara4;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara4.Range.InsertParagraphBefore();
            oPara4.Range.Text = "And here's another table:";
            oPara4.Format.SpaceAfter = 1;
            oPara4.Range.InsertParagraphAfter();

            // Add picture
            //Microsoft.Office.Interop.Word.Section section = oDoc.Sections.Add();
            //oDoc.Application.Selection.InlineShapes.AddPicture(@"J:\HydraulicModel\FlowRequest\SnowPhoto.jpg");

            ////insert and format textbox
            Microsoft.Office.Interop.Word.Section section = oDoc.Sections.Add();
            Microsoft.Office.Interop.Word.Shape textbox = 
                oDoc.Shapes.AddTextbox(Microsoft.Office.Core.
                //x, y, 
                MsoTextOrientation.msoTextOrientationHorizontal, 120, 200, 300, 300);

            /*
            //EMBEDDING LOGOS IN THE DOCUMENT
            //SETTING FOCUES ON THE PAGE HEADER TO EMBED THE WATERMARK
            oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;
            //THE LOGO IS ASSIGNED TO A SHAPE OBJECT SO THAT WE CAN USE ALL THE
            //SHAPE FORMATTING OPTIONS PRESENT FOR THE SHAPE OBJECT
            Word.Shape logoCustom = null;
            //THE PATH OF THE LOGO FILE TO BE EMBEDDED IN THE HEADER
            String logoPath = "C:\\Document and Settings\\MyLogo.jpg";
            logoCustom = oWord.Selection.HeaderFooter.Shapes.AddPicture(logoPath,
                ref oFalse, ref oTrue, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            logoCustom.Select(ref oMissing);
            logoCustom.Name = "CustomLogo";
            logoCustom.Left = (float)Word.WdShapePosition.wdShapeLeft;
            //SETTING FOCUES BACK TO DOCUMENT
            oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
            */


            /*
            foreach (Microsoft.Office.Interop.Word.Shape shape in oDoc.Shapes)
            {
                if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
                {
                    //if (shape.AlternativeText.Contains("MY_FIELD_TO_OVERWRITE_OO1"))
                    //{
                    Console.WriteLine(shape.Name);
                    shape.TextFrame.TextRange.Text = "MY_NEW_FIELD_VALUE";
                    shape.BackgroundStyle = 
                    //}

                }
            }
            */



            ////Insert a paragraph at the end of the document.
            //Word.Paragraph oPara2;
            //oPara1.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            //oPara2.Range.Text = "Hydrant Flow Test";
            //oPara2.Format.SpaceAfter = 6;
            //oPara2.Range.InsertParagraphAfter();

            ////Insert another paragraph.
            //Word.Paragraph oPara3;
            //oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            //oPara1.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
            //oPara3.Range.Text = "TO:";
            //oPara3.Range.Font.Bold = 0;
            //oPara3.Format.SpaceAfter = 24;
            //oPara3.Range.InsertParagraphAfter();

            ////Insert a 3 x 5 table, fill it with data, and make the first row
            ////bold and italic.
            //Word.Table oTable;
            //Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oTable = oDoc.Tables.Add(wrdRng, 3, 5, ref oMissing, ref oMissing);
            //oTable.Range.ParagraphFormat.SpaceAfter = 6;
            //int r, c;
            //string strText;
            //for (r = 1; r <= 3; r++)
            //{
            //    for (c = 1; c <= 5; c++)
            //    {
            //        strText = "r" + r + "c" + c;
            //        oTable.Cell(r, c).Range.Text = strText;
            //    }
            //}
            //oTable.Rows[1].Range.Font.Bold = 1;
            //oTable.Rows[1].Range.Font.Italic = 1;

            ////Add some text after the table.
            //Word.Paragraph oPara4;
            //oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
            //oPara4.Range.InsertParagraphBefore();
            //oPara4.Range.Text = "And here's another table:";
            //oPara4.Format.SpaceAfter = 24;
            //oPara4.Range.InsertParagraphAfter();

            ////Insert a 5 x 2 table, fill it with data, and change the column widths.
            //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oTable = oDoc.Tables.Add(wrdRng, 5, 2, ref oMissing, ref oMissing);
            //oTable.Range.ParagraphFormat.SpaceAfter = 6;
            //for (r = 1; r <= 5; r++)
            //{
            //    for (c = 1; c <= 2; c++)
            //    {
            //        strText = "r" + r + "c" + c;
            //        oTable.Cell(r, c).Range.Text = strText;
            //    }
            //}
            //oTable.Columns[1].Width = oWord.InchesToPoints(2); //Change width of columns 1 & 2
            //oTable.Columns[2].Width = oWord.InchesToPoints(3);

            ////Keep inserting text. When you get to 7 inches from top of the
            ////document, insert a hard page break.
            //object oPos;
            //double dPos = oWord.InchesToPoints(7);
            //oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
            //do
            //{
            //    wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //    wrdRng.ParagraphFormat.SpaceAfter = 6;
            //    wrdRng.InsertAfter("A line of text");
            //    wrdRng.InsertParagraphAfter();
            //    oPos = wrdRng.get_Information(Word.WdInformation.wdVerticalPositionRelativeToPage);
            //}
            //while (dPos >= Convert.ToDouble(oPos));
            //object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
            //object oPageBreak = Word.WdBreakType.wdPageBreak;
            //wrdRng.Collapse(ref oCollapseEnd);
            //wrdRng.InsertBreak(ref oPageBreak);
            //wrdRng.Collapse(ref oCollapseEnd);
            //wrdRng.InsertAfter("We're now on page 2. Here's my chart:");
            //wrdRng.InsertParagraphAfter();

            ////Insert a chart.
            //Word.InlineShape oShape;
            //object oClassType = "MSGraph.Chart.8";
            //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oShape = wrdRng.InlineShapes.AddOLEObject(ref oClassType, ref oMissing,
            //    ref oMissing, ref oMissing, ref oMissing,
            //    ref oMissing, ref oMissing, ref oMissing);

            ////Demonstrate use of late bound oChart and oChartApp objects to
            ////manipulate the chart object with MSGraph.
            //object oChart;
            //object oChartApp;
            //oChart = oShape.OLEFormat.Object;
            //oChartApp = oChart.GetType().InvokeMember("Application", System.Reflection.BindingFlags.GetProperty, null, oChart, null);

            ////Change the chart type to Line.
            //object[] Parameters = new object[1];
            //Parameters[0] = 4; //xlLine = 4
            //oChart.GetType().InvokeMember("ChartType", System.Reflection.BindingFlags.SetProperty, null, oChart, Parameters);

            ////Update the chart image and quit MSGraph.
            //oChartApp.GetType().InvokeMember("Update", System.Reflection.BindingFlags.InvokeMethod, null, oChartApp, null);
            //oChartApp.GetType().InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, oChartApp, null);
            ////... If desired, you can proceed from here using the Microsoft Graph 
            ////Object model on the oChart and oChartApp objects to make additional
            ////changes to the chart.

            ////Set the width of the chart.
            //oShape.Width = oWord.InchesToPoints(6.25f);
            //oShape.Height = oWord.InchesToPoints(3.57f);

            ////Add text after the chart.
            //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //wrdRng.InsertParagraphAfter();
            //wrdRng.InsertAfter("THE END.");
            //object sv2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/mydocAsPdf.pdf";
            //object fileFormat = Word.WdSaveFormat.wdFormatPDF;
            //oDoc.SaveAs2(ref sv2, ref fileFormat);
            // oDoc.Close(); // if you want to get headache uncomment this :P
            oDoc = null;
            oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
            oWord = null;

            // force quit from Word to prevent "Save As" dialog
            foreach (System.Diagnostics.Process item in System.Diagnostics.Process.GetProcesses())
            {
                if (item.ProcessName == "WINWORD")
                    item.Kill();
            }

        }

    }
}