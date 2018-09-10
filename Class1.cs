using System;
using System.Activities;
using System.ComponentModel;
using System.Data;
using System.Windows.Markup;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using Entities;
using WorkflowBLL;
using Spire.Xls;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Activities.Presentation.PropertyEditing;
using System.Windows;

namespace CustomActivity
{


    //internal class Editor : UITypeEditor
    //{
    //    //public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
    //    //{
    //    //    MyEditorUIDialog myEditorUIDialog = new MyEditorUIDialog();

    //    //    myEditorUIDialog.ShowDialog();

    //    //    return myEditorUIDialog.Value;
    //    //}

    //    public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
    //    {
    //        if (provider != null)
    //        {
    //            IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

    //            if (service != null)
    //            {
    //                using (Form1 dialog = new Form1())
    //                {
    //                    DialogResult result = dialog.ShowDialog();
    //                    if (result == DialogResult.OK)
    //                        value = dialog.Value;
    //                }
    //            }
    //        }

    //        return value;
    //    }

    //    public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
    //    {
    //        return UITypeEditorEditStyle.Modal;
    //    }

    //    public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
    //    {
    //        // No special thumbnail will be shown for the grid.
    //        return false;
    //    }
    //}

    public class ResetPwdByL2 : NativeActivity
    {
        public OutArgument<string> NewPassword { get; set; }
        //public OutArgument<bool> Status { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            NewPassword.Set(context, System.Web.Security.Membership.GeneratePassword(8, 1));
            //Status.Set(context, true);
        }
    }

    public class ResetPwdByUser:NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> NewPassword { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> ConfirmPassword { get; set; }

        public OutArgument<string> Message { get; set; }

        //public OutArgument<bool> Status { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            if (NewPassword.Get(context).ToString() == "" || ConfirmPassword.Get(context).ToString() == "")
            {
                Message.Set(context, "Password cannot be Empty");
                //Status.Set(context, false);
            }
            else if (NewPassword.Get(context).ToString()!= ConfirmPassword.Get(context).ToString())
            {
                Message.Set(context, "Passwords Don't Match");
                //Status.Set(context, false);
            }
            else
            {
                Message.Set(context, "Password changed successfully");
                //Status.Set(context, true);
            }
        }
    }

    public class AssignActivity : NativeActivity
    {
        private InArgument<int> value = new InArgument<int>();


        [RequiredArgument]
        [DefaultValue(null)]
    
        public InArgument<int> Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        public OutArgument<int> Result { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Value.Get(context));
        }
    }

    public class CheckMissingSAP_WCActivity:NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> WorkCenter { get; set; }

        public OutArgument<bool> Result { get; set; } 

        protected override void Execute(NativeActivityContext context)
        {
            BLL bll = new BLL();
            if(bll.CheckForSAPMapping(WorkCenter.Get(context)))
            {
                Console.WriteLine("Workcenter present");
                Result.Set(context, true);
            }
            else
            {
                Result.Set(context, false);
            }
        }
    }



    public class InsertNewSAP_WCActivity : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> WorkCenter { get; set; }
        protected override void Execute(NativeActivityContext context)
        {
            BLL bll = new BLL();
            string oldSAP = bll.GetSAP_WC_MAP();

            string zoneIn = "", inventoryStatusIn = "", productGroupIn = "", facility = "";

            Workbook workbook = new Workbook();
            workbook.LoadFromFile(ConfigurationManager.AppSettings["GMESDataConfiguration"]);
            Worksheet sheet = workbook.Worksheets["SAPWorkCentreMapping"];
            int columnCount = sheet.Columns.Count();
            foreach (CellRange range in sheet.Columns[0])
            {
                if (range.Text == WorkCenter.Get(context))
                {
                    CellRange sourceRange = sheet.Range[range.Row, 1, range.Row, columnCount];

                    zoneIn = sourceRange.Cells[0].Value;
                    inventoryStatusIn = sourceRange.Cells[1].Value;
                    productGroupIn = sourceRange.Cells[2].Value;
                    facility = sourceRange.Cells[3].Value;
                }
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(oldSAP);
            //create title node
            int max = -99;
            // XmlReader rdr = XmlReader.Create(new System.IO.StringReader(oldSAP));



            //while (rdr.Read())
            //{
            //    if (rdr.NodeType == XmlNodeType. && rdr.Name== "ValidFrom")
            //    {

            //        //int seq = int.Parse(rdr.Value);
            //        rdr.
            //        rdr.ReadInnerXml();
            //        //int seq = int.Parse(rdr.ReadElementContentAsInt().ToString());
            //        rdr.ReadElementContentAsInt();
            //        rdr.ReadElementContentAsInt();
            //        if (max < (rdr.ReadElementContentAsInt()))
            //        {
            //            max = rdr.ReadElementContentAsInt();
            //        }

            //    }
            //}

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(oldSAP);

            XmlNodeList xNodeList = xml.SelectNodes("/ArrayOfRow/Row");
            foreach (XmlNode xNode in xNodeList)
            {
                int seq = int.Parse(xNode["SequenceNo"].InnerText);
                if (max < seq)
                    max = seq;
            }

            XmlNode nodeRow = xmlDoc.CreateNode(XmlNodeType.Element, "Row", null); ;
            //add value for it
            XmlNode nodeSequenceNo = xmlDoc.CreateElement("SequenceNo");
            nodeSequenceNo.InnerText = (max+1).ToString();
            
            XmlNode nodeValidFrom = xmlDoc.CreateElement("ValidFrom");
            nodeValidFrom.InnerText = "1905-01-01T00:00:00";

            XmlNode nodeValidTo = xmlDoc.CreateElement("ValidTo");
            nodeValidTo.InnerText = "2035-12-31T23:59:59.099";

            XmlNode nodeValues = xmlDoc.CreateNode(XmlNodeType.Element, "Values", null);

            XmlElement nodePropertyBagItem1 = xmlDoc.CreateElement("PropertyBagItem");
            nodePropertyBagItem1.SetAttribute("Key", "c8be3c34-4e02-4495-9db6-09d98a26110c");
            XmlElement nodeValue1 = xmlDoc.CreateElement("Value");
            nodeValue1.SetAttribute("xsi:type", "xsd:string");
            nodeValue1.InnerText = zoneIn;
            nodePropertyBagItem1.AppendChild(nodeValue1);
            nodeValues.AppendChild(nodePropertyBagItem1);

            XmlElement nodePropertyBagItem2 = xmlDoc.CreateElement("PropertyBagItem");
            nodePropertyBagItem2.SetAttribute("Key", "f9d37b0c-87e2-44ad-8080-72166c354fe0");
            XmlElement nodeValue2 = xmlDoc.CreateElement("Value");
            nodeValue2.SetAttribute("xsi:type", "xsd:string");
            nodeValue2.InnerText = inventoryStatusIn;
            nodePropertyBagItem2.AppendChild(nodeValue2);
            nodeValues.AppendChild(nodePropertyBagItem2);

            XmlElement nodePropertyBagItem3 = xmlDoc.CreateElement("PropertyBagItem");
            nodePropertyBagItem3.SetAttribute("Key", "b3e5fa3f-def4-4362-860b-0b6ad0cc5c99");
            XmlElement nodeValue3 = xmlDoc.CreateElement("Value");
            nodeValue3.SetAttribute("xsi:type", "xsd:string");
            nodeValue3.InnerText = productGroupIn;
            nodePropertyBagItem3.AppendChild(nodeValue3);
            nodeValues.AppendChild(nodePropertyBagItem3);

            XmlElement nodePropertyBagItem4 = xmlDoc.CreateElement("PropertyBagItem");
            nodePropertyBagItem4.SetAttribute("Key", "e83bd37b-06b7-4da5-944c-945679df9ddb");
            XmlElement nodeValue4 = xmlDoc.CreateElement("Value");
            nodeValue4.SetAttribute("xsi:type", "xsd:string");
            nodeValue4.InnerText = facility;
            nodePropertyBagItem4.AppendChild(nodeValue4);
            nodeValues.AppendChild(nodePropertyBagItem4);
            
            nodeRow.AppendChild(nodeSequenceNo);
            nodeRow.AppendChild(nodeValidFrom);
            nodeRow.AppendChild(nodeValidTo);
            nodeRow.AppendChild(nodeValues);
            xmlDoc.DocumentElement.AppendChild(nodeRow);


            string str=xmlDoc.InnerXml.ToString();
            Console.WriteLine(str);
        }
    }

    public class CheckXSLTMissing : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> XSLTFileName { get; set; }

        public OutArgument<bool> Result { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            string path = @"D:\Maps\External\" + XSLTFileName.Get(context);
            if (File.Exists(path))
            {
                Result.Set(context, true);
            }
            else
            {
                Result.Set(context, false);
            }
        }
    }

    public class CopyMissingXSLTActivity : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> XSLTFileName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            string sourcePath = ConfigurationManager.AppSettings["XSLTSourcePath"] + XSLTFileName.Get(context);
            string destPath = ConfigurationManager.AppSettings["XSLTDestinationPath"] + XSLTFileName.Get(context);
            File.Copy(sourcePath, destPath);
        }
    }

    public class LOIPROFailActivity : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> ERPMaterialStock { get; set; }


        protected override void Execute(NativeActivityContext context)
        {
            BLL bll = new BLL();
            if(bll.CheckERPTableFOREntry(ERPMaterialStock.Get(context)) == null)
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(@"C:\Users\28199\Desktop\GMES Data Configuration Template_TR_Final_Updated_sneha.xlsm");
                Worksheet sheet = workbook.Worksheets["ERPMaterialStock"];
                int columnCount = sheet.Columns.Count();
                foreach (CellRange range in sheet.Columns[1])
                {
                    if (range.Text == ERPMaterialStock.Get(context))
                    {
                        CellRange sourceRange = sheet.Range[range.Row, 1, range.Row, columnCount];
                        ERPMaterial erp = new ERPMaterial
                        {
                            ERPStockType = sourceRange.Cells[0].Value,
                            ERPMaterialStock = sourceRange.Cells[1].Value,
                            ERPPlant = sourceRange.Cells[2].Value,
                            ERPSystem = sourceRange.Cells[3].Value
                        };

                        bll.InsertERPMaterial(erp);
                    }
                }
            }
        }
    }

    public class LogActivity : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<DateTime> LogDateFrom { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<DateTime> LogDateTo { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<int> Tolerence { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Path { get; set; }

        public OutArgument<ArrayList> Result { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine("Hello");
            ArrayList arr = new ArrayList();

            int counter = 0;
            string logDatePattern = @"\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}";

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(Path.Get(context));

            string fullFile = file.ReadToEnd();
            ArrayList indexes = new ArrayList();
            ArrayList values = new ArrayList();
            foreach (Match match in Regex.Matches(fullFile, logDatePattern, RegexOptions.Singleline))//.Cast<Match>().Select(m => m.Value).ToArray())
            {
                indexes.Add(match.Index);
                
                values.Add(match.Value);
            }

            //for (int i = 0; i < indexes.Count - 1; i++)
            //{

            //    Console.WriteLine(fullFile.Substring(int.Parse(indexes[i].ToString()), int.Parse(indexes[i+1].ToString()) - int.Parse(indexes[i].ToString())));
            //}

            for (int i = 0; i < indexes.Count - 1; i++)
            {
                if(DateTime.Parse(fullFile.Substring(int.Parse(indexes[i].ToString()), 19)).CompareTo(LogDateFrom.Get(context)) >= 0 && DateTime.Parse(fullFile.Substring(int.Parse(indexes[i].ToString()), 19)).CompareTo(LogDateTo.Get(context)) <= 0)
                {
                    arr.Add(fullFile.Substring(int.Parse(indexes[i].ToString()), int.Parse(indexes[i + 1].ToString()) - int.Parse(indexes[i].ToString())));
                    counter++;
                }
            }
            if (DateTime.Parse(fullFile.Substring(int.Parse(indexes[indexes.Count - 1].ToString()), 19)).CompareTo(LogDateFrom.Get(context)) >= 0 && DateTime.Parse(fullFile.Substring(int.Parse(indexes[indexes.Count - 1].ToString()), 19)).CompareTo(LogDateTo.Get(context)) <= 0)
            {
                arr.Add(fullFile.Substring(int.Parse(indexes[indexes.Count - 1].ToString()), fullFile.Length - int.Parse(indexes[indexes.Count - 1].ToString())));
                counter++;
            }
            //Console.WriteLine(fullFile.Substring(int.Parse(indexes[indexes.Count - 1].ToString()), fullFile.Length - int.Parse(indexes[indexes.Count - 1].ToString())));
            file.Close();
            Console.WriteLine("There were {0} logs.", counter);
            Result.Set(context, arr);
        }
    }



    public class ItemOrderActivity : NativeActivity
    {
        [DefaultValue(null)]
        public InArgument<int> ItemId { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> ItemName { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<double> ItemQty { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> ItemUnit { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<List<ItemOrder>> CurrentList { get; set; }

        public OutArgument<List<ItemOrder>> Result { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            List<ItemOrder> list = new List<ItemOrder>();
            list = CurrentList.Get(context);
            list.Add(new ItemOrder() {
                ItemId = 1,
                ItemName = ItemName.Get(context),
                ItemQty=ItemQty.Get(context),
                ItemUnit=ItemUnit.Get(context)
            });
            Result.Set(context, list);
        }
    }

    public class ItemOrderCancelActivity : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> ItemName { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<List<ItemOrder>> CurrentList { get; set; }

        public OutArgument<List<ItemOrder>> Result { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            List<ItemOrder> list = new List<ItemOrder>();
            list = CurrentList.Get(context);
            foreach (var item in list)
            {
                if (item.ItemName.Equals(ItemName.Get(context)))
                {
                    list.Remove(item);
                }
            }
            Result.Set(context, list);
        }
    }



    [Designer(typeof(SampleActivityDesigner))]
    public class SampleActivity : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<ArrayList> Items { get; set; }

        //[RequiredArgument]
        //[DefaultValue(null)]
        //public InArgument<List<Inputs>> ItemName { get; set; }
        
        public OutArgument<List<Outputs>> Result { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            
        }
    }
}
