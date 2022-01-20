using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing;
using Microsoft.Office.Core;
using FlowTestLibrary.Models;


namespace FlowTestLibrary
{
    public class Program
    {
        public static void Main()    //string[] args)
        {
            //MakePdf();
            FlowTestModel flowTest = new FlowTestModel();
            FlowTestDataModel flowTestData = new FlowTestDataModel();
            FlowTestLibrary.Methods.AddData(flowTest, flowTestData);
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

            //NEED A BREAK HERE TO ACKNOWLEDGE WORD................................
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


            // Save the file
            //object sv2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/_mydocAsPdf.pdf";
            object sv2 = "J:\\HydraulicModel\\FlowRequest\\_mydocAsPdf.pdf";
            object fileFormat = Word.WdSaveFormat.wdFormatPDF;
            oWordDoc.SaveAs2(ref sv2, ref fileFormat);
            //oWordDoc.Close(); // if you want to get headache uncomment this :P
            oWordDoc = null;
            oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
            oWord = null;

            // force quit from Word to prevent "Save As" dialog
            foreach (System.Diagnostics.Process item in System.Diagnostics.Process.GetProcesses())
            {
                Console.WriteLine(item.ProcessName.ToString());
                if (item.ProcessName == "WINWORD")
                    item.Kill();
            }

        }


    }
}