#region Copyright Syncfusion Inc. 2001 - 2022
//
//  Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
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
        # region Private Members
        private Label label1;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label2;
        #endregion

        #region Constructor
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 52);
            this.label1.TabIndex = 27;
            this.label1.Text = "Click the button to view an PDF document generated by Essential PDF.  Please note" +
    " that Adobe Reader or its equivalent is required to view the resultant document." +
    " ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(288, 200);
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
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Image = System.Drawing.Image.FromFile(GetFullTemplatePath("pdf_header.png", true));
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 89);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 44);
            this.label2.TabIndex = 29;
            this.label2.Text = "Note: In this sample, we have used the Tahoma font from the system to draw Thai characters. So please make sure to install the font for it to work properly.";
            // 
            // Form1
            // 
            // this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(GetFullTemplatePath("syncfusion.ico", true));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Complex Script";
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
        # endregion

        # region Events
        private void button1_Click(object sender, System.EventArgs e)
        {
            string inputText = @"เอกสาร PDF มีการใช้อย่างแพร่หลายเป็นเวลาหลายปีและนับสิบ ๆ แถมฟรี ผู้อ่าน 
PDF เชิงพาณิชย์บรรณาธิการและห้องสมุดพร้อมใช้งาน อย่างไรก็ตามแม้จะมี
ความนิยมนี้ก็ยังคงยากที่จะหาคำแนะนำกระชับรูปแบบ PDF พื้นเมือง
การทำความเข้าใจการทำงานภายในของ PDF ทำให้สามารถสร้างได้แบบไดนามิก
เอกสาร PDF ตัวอย่างเช่นเว็บเซิร์ฟเวอร์สามารถดึงข้อมูลจากฐานข้อมูล
ใช้เพื่อกำหนดใบกำกับสินค้าและให้บริการกับลูกค้าได้ทันที";

            //Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            //Add a new page to the document.
            PdfPage page = document.Pages.Add();

            //Create font.
            PdfFont font = new PdfTrueTypeFont(new Font("Tahoma", 14), true);

            //Create brush.
            PdfBrush brush = new PdfSolidBrush(Color.Black);

            //Get page client size.          
            SizeF clipBounds = page.Graphics.ClientSize;

            RectangleF rect = new RectangleF(0, 0, clipBounds.Width, clipBounds.Height);

            //Create a new instance of the PdfStringFormat class.
            PdfStringFormat format = new PdfStringFormat();

            //Set the property for complex text layout.
            format.ComplexScript = true;

            //Draw the text.
            page.Graphics.DrawString(inputText, font, brush, rect, format);

            //Save the document.
            document.Save("sample.pdf");

            //Close the document.
            document.Close(true);

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
        #endregion

        # region Helpher Methods
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
        # endregion
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

            string licenseKeyFile = @"Common\\SyncfusionLicense.txt";

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
