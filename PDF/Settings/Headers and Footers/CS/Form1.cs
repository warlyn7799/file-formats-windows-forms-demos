#region Copyright Syncfusion Inc. 2001 - 2023
//
//  Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Syncfusion.Pdf;
using Syncfusion.Windows.Forms;
using Syncfusion.Pdf.Graphics;
using System.IO;
using System.Text;
using Syncfusion.Licensing;

namespace EssentialPDFSamples
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : MetroForm
    {
        private bool m_paginateStart = true;
        RectangleF bounds;
        private RectangleF m_columnBounds;
        private Label label1;
        private Button button1;
        private PictureBox pictureBox1;
       
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.MinimizeBox = true;
            Application.EnableVisualStyles();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 53);
            this.label1.TabIndex = 27;
            this.label1.Text = "Click the button to view an PDF document generated by Essential PDF.  Please note" +
                " that Adobe Reader or its equivalent is required to view the resultant document." +
                "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
           //
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(281, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 26;
            this.button1.Text = "PDF";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = System.Drawing.Image.FromFile(GetFullTemplatePath("pdf_header.png", true));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 90);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            //this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 196);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(GetFullTemplatePath("syncfusion.ico", true));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Headers and Footers";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //Create a PDF document
            PdfDocument doc = new PdfDocument();
            
            //Add a page
            PdfPage page = doc.Pages.Add();
            RectangleF rect = new RectangleF(0, 0, page.GetClientSize().Width,50);
         
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            PdfPen pen = new PdfPen(Color.Black, 1f);
            
            //Create font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11.5f);

             Font ttf = new Font("Calibri", 14f, FontStyle.Bold);
            PdfTrueTypeFont heading = new PdfTrueTypeFont(ttf, true);

            //Adding Header
            this.AddHeader(doc, "Syncfusion Essential PDF", "Header and Footer Demo");
           
            //Adding Footer
            this.AddFooter(doc, "@Copyright 2015");

            //Set formats
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Justify;
#if NETCORE
            string path = @"..\..\..\..\..\..\..\Common\Data\PDF\Essential studio.txt";
#else
            string path = @"..\..\..\..\..\..\Common\Data\PDF\Essential studio.txt";
#endif
            StreamReader reader = new StreamReader(path, Encoding.ASCII);
            string text = reader.ReadToEnd();
            reader.Close();
            RectangleF column = new RectangleF(0, 20, page.Graphics.ClientSize.Width / 2f - 10f, page.Graphics.ClientSize.Height);
            bounds = column;
            m_columnBounds = column;
            
            //Create text element to control the text flow
            PdfTextElement element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
            layoutFormat.Break = PdfLayoutBreakType.FitPage;
            layoutFormat.Layout = PdfLayoutType.Paginate;
          
            //Get the remaining text that flows beyond the boundary.
            PdfTextLayoutResult result = element.Draw(page, bounds,layoutFormat);

#if NETCORE
            path = @"..\..\..\..\..\..\..\Common\Data\Essential PDF.txt";
#else
            path = @"..\..\..\..\..\..\Common\Data\Essential PDF.txt";
#endif
            reader = new StreamReader(path, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Close();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;
            
            // Next paragraph flow from last line of the previous paragraph.
            bounds.Y = result.LastLineBounds.Y + 35f;

            //Raise the event when the text flows to next page.
            element.BeginPageLayout += new BeginPageLayoutEventHandler(BeginPageLayout2);
            
            //Raise the event when the text reaches the end of the page.
            element.EndPageLayout += new EndPageLayoutEventHandler(EndPageLayout2);
            result.Page.Graphics.DrawString("Essential PDF",heading,PdfBrushes.DarkBlue,new PointF(bounds.X, bounds.Y));

            bounds.Y = result.LastLineBounds.Y + 60f;
            result= element.Draw(result.Page,new RectangleF(bounds.X, bounds.Y, bounds.Width,-1),layoutFormat);
#if NETCORE
            PdfImage image = new PdfBitmap(@"..\..\..\..\..\..\..\Common\Images\PDF\Essen PDF.gif");
#else
            PdfImage image = new PdfBitmap(@"..\..\..\..\..\..\Common\Images\PDF\Essen PDF.gif");
#endif
            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X,bounds.Y));
            result.Page.Graphics.DrawString("Essential DocIO", heading, PdfBrushes.DarkBlue, new PointF(bounds.X, bounds.Y+image.Height-20));
#if NETCORE
            path = @"..\..\..\..\..\..\..\Common\Data\Essential DocIO.txt";
#else
            path = @"..\..\..\..\..\..\Common\Data\Essential DocIO.txt";
#endif
            reader = new StreamReader(path, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Close();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;

            bounds.Y = result.LastLineBounds.Y  + image.Height+20;
            bounds.X = bounds.Width + 20f;

           
            result = element.Draw(result.Page, new RectangleF(bounds.X, bounds.Y, bounds.Width, -1), layoutFormat);

#if NETCORE
            image = new PdfBitmap(@"..\..\..\..\..\..\..\Common\Images\PDF\Essen DocIO.gif");
#else
            image = new PdfBitmap(@"..\..\..\..\..\..\Common\Images\PDF\Essen DocIO.gif");
#endif
            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X, bounds.Y));

#if NETCORE
            path = @"..\..\..\..\..\..\..\Common\Data\Essential XlsIO.txt";
#else
            path = @"..\..\..\..\..\..\Common\Data\Essential XlsIO.txt";
#endif
            reader = new StreamReader(path, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Close();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;

            result.Page.Graphics.DrawString("Essential XlsIO", heading, PdfBrushes.DarkBlue, new PointF(bounds.X, bounds.Y + image.Height-20));

            bounds.Y = result.LastLineBounds.Y + image.Height+20;
            bounds.X = bounds.Width + 20f;
            result = element.Draw(result.Page, new RectangleF(bounds.X, bounds.Y, bounds.Width, -1), layoutFormat);

#if NETCORE
            image = new PdfBitmap(@"..\..\..\..\..\..\..\Common\Images\PDF\Essen XlsIO.gif");
#else
            image = new PdfBitmap(@"..\..\..\..\..\..\Common\Images\PDF\Essen XlsIO.gif");
#endif
            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X, bounds.Y));
            doc.Save("Sample.pdf");

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.pdf")
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                System.Diagnostics.Process.Start("Sample.pdf");
#endif
                this.Close();
            }
            else
            {
                // Exit
                this.Close();
            }
        }

        private void EndPageLayout2(object sender, EndPageLayoutEventArgs e)
        {
            EndTextPageLayoutEventArgs args = (EndTextPageLayoutEventArgs)e;
            PdfTextLayoutResult tlr = args.Result;
            RectangleF bounds = tlr.Bounds;
            args.NextPage = tlr.Page;   
        }
        private void BeginPageLayout2(object sender, BeginPageLayoutEventArgs e)
        {
            
            RectangleF bounds = e.Bounds;

           // First column.
            if (!m_paginateStart)
            {
                bounds.X = bounds.Width + 20f;
                bounds.Y = 10f;
            }
            else
            {
                // Second column.
                bounds.X = 0f;
                m_paginateStart = false;
            }

            e.Bounds = bounds;
            m_columnBounds = bounds;
        }

        private void AddHeader(PdfDocument doc, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);
           
            //Create page template
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 24);
            float doubleHeight = font.Height * 2;
            Color activeColor = Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(110f, 35f);
            //Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 5);

#if NETCORE
            PdfImage img = new PdfBitmap(@"..\..\..\..\..\..\..\Common\Images\PDF\logo.png");
#else
            PdfImage img = new PdfBitmap(@"..\..\..\..\..\..\Common\Images\PDF\logo.png");
#endif

            //Draw the image in the Header.
            header.Graphics.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);
            
            //Set formattings for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            
            //Draw title
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(Color.Gray);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Draw description
            header.Graphics.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            //Draw some lines in the header
            pen = new PdfPen(Color.DarkBlue, 0.7f);
            header.Graphics.DrawLine(pen, 0, 0, header.Width, 0);
            pen = new PdfPen(Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, 03, header.Width+3, 03);
            pen = new PdfPen(Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, header.Height - 3, header.Width, header.Height - 3);
            header.Graphics.DrawLine(pen, 0, header.Height , header.Width, header.Height );

            //Add header template at the top.
            doc.Template.Top = header;

        }

        private void AddFooter(PdfDocument doc, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);
           
            //Create a page template
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8);
           
            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);

            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            footer.Graphics.DrawString(footerText, font, brush, new RectangleF(0, 18, footer.Width, footer.Height), format);
            
            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Right;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Create page number field
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

            //Create page count field
            PdfPageCountField count = new PdfPageCountField(font, brush);

            PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;
            compositeField.Draw(footer.Graphics, new PointF(470, 40));
           
            //Add the footer template at the bottom
            doc.Template.Bottom = footer;

        }
      /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
            string fullPath = @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
    }
	/// <summary>
    /// Represents a class that is used to find the licensing file for Syncfusion controls.
    /// </summary>
    public class DemoCommon
    {

        /// <summary>
        /// Finds the license key from the Common folder.
        /// </summary>
        /// <returns>Returns the license key.</returns>
        public static string FindLicenseKey()
        {

            string licenseKeyFile = "Common\\SyncfusionLicense.txt";

            for (int n = 0; n < 20; n++)
            {
                if (!System.IO.File.Exists(licenseKeyFile))
                {
                    licenseKeyFile = @"..\" + licenseKeyFile;
                    continue;
                }
                return System.IO.File.ReadAllText(licenseKeyFile);
            }
            return string.Empty;
        }
    }
}
