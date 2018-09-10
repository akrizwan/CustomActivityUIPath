

using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    [Activity]
    [Designer(typeof(PdfGeneratorDesigner))]
    public class PDFGenerator : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Content { get; set; }

        public InArgument<string> Location { get; set; }

        public InArgument<string> Title { get; set; }

        [RequiredArgument]
        [DefaultValue("Untitiled")]
        public InArgument<string> FileName { get; set; }


        public OutArgument<string> GeneratedFilePath { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            string St = Content.Get(context);
            string Path = Location.Get(context) + FileName.Get(context) + ".pdf";
            // string PdfFile = FileName.Get(context);
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
                FileStream fs = new FileStream(Path, FileMode.Create);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, fs);
                pdfDoc.Open();
                var buildDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                try
                {
                    Image jpg2 = Image.GetInstance(new Uri(System.IO.Path.GetFullPath(System.IO.Path.Combine(buildDir, "ITC.jpg"))));

                    jpg2.ScaleToFit(340f, 220f);
                    jpg2.SpacingBefore = 200f;
                    jpg2.SpacingAfter = 200f;
                    jpg2.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(jpg2);
                }
                catch (Exception)
                {
                    
                }
                String title = Title.Get(context);
                Paragraph header = new Paragraph(title, FontFactory.GetFont("Verdana", 30, Font.UNDERLINE));
                header.SpacingBefore = 400;
                header.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(header);
                pdfDoc.NewPage();


                string para = string.Empty;
                lvl1: if (St.Contains("@image"))
                {
                    para = St.Substring(0, St.IndexOf("@image"));
                    Paragraph Text = new Paragraph(para);
                    pdfDoc.Add(Text);
                    int pFrom = St.IndexOf("@image") + "@image".Length;
                    int pTo = St.IndexOf("@/image");
                    String urlString = St.Substring(pFrom, pTo - pFrom);
                    Image jpg1 = Image.GetInstance(urlString);
                    jpg1.ScaleToFit(340f, 220f);
                    jpg1.SpacingBefore = 200f;
                    jpg1.SpacingAfter = 200f;
                    jpg1.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(jpg1);
                    St = St.Remove(0, St.IndexOf("@/image") + "@/image".Length + 1);
                    goto lvl1;
                }
                else
                {
                    Paragraph Text = new Paragraph(St);
                    pdfDoc.Add(Text);
                }

                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                pdfWriter.Close();
                fs.Close();

                GeneratedFilePath.Set(context, Path);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
