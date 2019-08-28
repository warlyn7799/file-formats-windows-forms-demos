#region Copyright Syncfusion Inc. 2001 - 2019
//
//  Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Functions;
using System.IO;
using Syncfusion.Licensing;

namespace EssentialPDFSamples
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : MetroForm
    {
        # region Private Members
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        # endregion

        # region Constructor
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.MinimizeBox = true;
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.button1.Location = new System.Drawing.Point(289, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "PDF";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 93);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click the button to view an PDF document generated by Essential PDF.  Please note" +
                " that Adobe Reader or its equivalent is required to view the resultant document." +
                "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = System.Drawing.Image.FromFile(GetFullTemplatePath("pdf_header.png", true));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 91);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(376, 209);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
             this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(GetFullTemplatePath("syncfusion.ico", true));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphic Brushes";
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
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        # endregion

        # region Events
        private void button1_Click(object sender, System.EventArgs e)
        {
            //Create a new instance of PdfDocument.
            PdfDocument document = new PdfDocument();
            
            // Change page size.
            document.PageSettings = new PdfPageSettings(new SizeF(300, 400));

            // Add a new page to the document.
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            # region Graphic Brushes
            PdfImage image = PdfImage.FromFile(GetFullTemplatePath("simple.jpg", true));
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 8f, PdfFontStyle.Bold);
            PdfBrush textBrush = PdfBrushes.Black;

            graphics.DrawString("PDF Graphic Brushes", font, textBrush, new PointF(80, 10));

            # region SolidBrush
            // Draw ellipse with solid brush.
            RectangleF rectangle = new RectangleF(20, 20, 50, 50);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            graphics.DrawEllipse(brush, rectangle);

            graphics.TranslateTransform(60, 0);
            brush = new PdfSolidBrush(Color.Green);
            graphics.DrawEllipse(brush, rectangle);

            graphics.TranslateTransform(60, 0);
            brush.Color = Color.Red;
            graphics.DrawEllipse(brush, rectangle);
            #endregion

            # region TilingBrush

            // Draw ellipse with tiling brush.
            graphics.TranslateTransform(-120, 60);

            PdfTilingBrush tilingBrush = new PdfTilingBrush(new SizeF(10, 10));
            RectangleF rect = new RectangleF(0, 0, 10, 10);

            // Draw image on to the tiling brush.
            tilingBrush.Graphics.DrawImage(image, rect);

            // Draw ellipse using tiling brush.
            graphics.DrawEllipse(tilingBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            tilingBrush = new PdfTilingBrush(rect);
            // Draw shapes inside tiling brush.
            tilingBrush.Graphics.DrawEllipse(PdfPens.Yellow, rect);
            tilingBrush.Graphics.DrawLine(PdfPens.Green, 0, 0, 10, 10);
            tilingBrush.Graphics.DrawLine(PdfPens.Red, 0, 10, 10, 0);
            graphics.DrawEllipse(tilingBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            rect = new RectangleF(0, 0, 20, 20);
            PdfTilingBrush tilingBrushNew = new PdfTilingBrush(rect);
            tilingBrushNew.Graphics.DrawEllipse(tilingBrush, rect);
            graphics.DrawEllipse(tilingBrushNew, rectangle);
            # endregion

            # region LinearGradientBrush
            // Draw ellipse with linear gradient brush.
            graphics.TranslateTransform(-120, 60);
            PdfColor color1 = Color.Red;
            PdfColor color2 = Color.Yellow;

            // Create a new linear gradient brush.
            PdfGradientBrush gradientBrush = new PdfLinearGradientBrush(rectangle.Location, (PointF)rectangle.Size, color1, color2);

            // Format before draw.
            gradientBrush.AntiAlias = false;
            gradientBrush.Background = Color.Green;
            graphics.DrawEllipse(gradientBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            color2 = Color.Green;
            gradientBrush = new PdfLinearGradientBrush(rectangle, color1, color2, 30f);
            gradientBrush.AntiAlias = true;
            graphics.DrawEllipse(gradientBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            color1 = Color.Yellow;
            gradientBrush = new PdfLinearGradientBrush(rectangle, color1, color2, PdfLinearGradientMode.ForwardDiagonal);
            graphics.DrawEllipse(gradientBrush, rectangle);

            # endregion

            #region RadialGradientBrush
            // Draw ellipse with radial gradient brush.
            graphics.TranslateTransform(-120, 60);
            color1 = Color.Red;
            color2 = Color.Yellow;

            PointF point = new PointF(25, 25);

            // Create a new radial gradient brush.
            gradientBrush = new PdfRadialGradientBrush(point, 50f, point, 5f, color1, color2);

            // Format before draw.
            gradientBrush.AntiAlias = false;
            gradientBrush.Background = Color.Green;
            graphics.DrawEllipse(gradientBrush, rectangle);
            # endregion

            graphics.TranslateTransform(0, -180f);
            PdfBrush onlyBrush = new PdfSolidBrush(Color.Black);
            graphics.DrawString("PdfBrushes class", font, onlyBrush, new PointF(200, 10));

            Type type = typeof(PdfBrushes);
            object[] parameters = null;
            System.Reflection.PropertyInfo[] properties = type.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                onlyBrush = (PdfSolidBrush)properties[i].GetValue(null, parameters);
                graphics.DrawRectangle(onlyBrush, new RectangleF(200, 30, 50, 2));
                graphics.TranslateTransform(0, 2);
            }
            # endregion

            # region PdfColorSpace
            // Add a new page to the document.
            page = document.Pages.Add();
            PdfGraphics g = page.Graphics;

            //Set DeviceRGB Colorspace.
            document.ColorSpace = PdfColorSpace.RGB;
            page.Graphics.DrawString("Device RGB", font, textBrush, new PointF(10, 20));
            PdfBrush brush1 = PdfBrushes.Green;
            g.DrawRectangle(brush1, new RectangleF(20, 40, 30, 30));

            //Set DeviceCMYK Colorspace.
            document.ColorSpace = PdfColorSpace.CMYK;
            page.Graphics.DrawString("Device CMYK", font, textBrush, new PointF(90, 20));
            g.DrawEllipse(brush1, new RectangleF(100, 40, 30, 30));

            //Set DeviceGray Colorspace.
            document.ColorSpace = PdfColorSpace.GrayScale;
            page.Graphics.DrawString("Device Gray", font, textBrush, new PointF(170, 20));
            g.DrawPie(brush1, new RectangleF(180, 40, 30, 30), 0, 45);
            # endregion

            # region CIE Based Color Space

            # region CalRGB Color
            document.ColorSpace = PdfColorSpace.RGB;
            
            // Add a new page to the document.
            page = document.Pages.Add();
            g = page.Graphics;
            g.DrawString("CalRGB Color", font, textBrush, new PointF(10, 20));

            rect = new RectangleF(20, 30, 30, 30);

            // Create a new instance of PdfCalRGBColorSpace class.
            PdfCalRGBColorSpace calRgbCS = new PdfCalRGBColorSpace();
            calRgbCS.Gamma = new double[] { 1.6, 1.1, 2.5 };
            calRgbCS.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            calRgbCS.WhitePoint = new double[] { 0.2, 1, 0.8 };

            // Create a new instance of PdfCalRGBColor class.
            PdfCalRGBColor calRGBColor = new PdfCalRGBColor(calRgbCS);
            calRGBColor.Red = 0;
            calRGBColor.Green = 1;
            calRGBColor.Blue = 0;

            // Create brush from CalRGBColor.
            PdfBrush colorSpaceBrush = new PdfSolidBrush(calRGBColor);

            // Draw using CalRGBColor brush.
            g.DrawRectangle(colorSpaceBrush, rect);
            # endregion

            # region CalGray Color
            g.DrawString("CalGray Color", font, textBrush, new PointF(90, 20));
            rect = new RectangleF(100, 30, 30, 30);

            // Create a new instance of PdfCalGrayColorSpace class.
            PdfCalGrayColorSpace calGrayCS = new PdfCalGrayColorSpace();
            calGrayCS.Gamma = 0.7;
            calGrayCS.WhitePoint = new double[] { 0.2, 1, 0.8 };

            // Create a new instance of PdfCalGrayColor class.
            PdfCalGrayColor calGrayColor = new PdfCalGrayColor(calGrayCS);
            calGrayColor.Gray = 0.1;

            // Create brush from PdfCalGrayColor.
            colorSpaceBrush = new PdfSolidBrush(calGrayColor);

            // Draw using PdfCalGrayColor brush.
            g.DrawRectangle(colorSpaceBrush, rect);
            # endregion

            # region Lab Color
            g.DrawString("Lab Color", font, textBrush, new PointF(170, 20));

            rect = new RectangleF(180, 30, 30, 30);

            // Create a new instance of PdfLabColorSpace class.
            PdfLabColorSpace labCS = new PdfLabColorSpace();
            labCS.Range = new double[] { 0.2, 1, 0.8, 23.5 };
            labCS.WhitePoint = new double[] { 0.2, 1, 0.8 };

            // Create a new instance of PdfLabColor class.
            PdfLabColor labColor = new PdfLabColor(labCS);
            labColor.L = 90;
            labColor.A = 0.5;
            labColor.B = 20;

            // Create brush using PdfLabColor.
            colorSpaceBrush = new PdfSolidBrush(labColor);

            // Draw using PdfLabColor brush.
            g.DrawRectangle(colorSpaceBrush, rect);
            # endregion

            # region ICC Color
            g.DrawString("ICC Color", font, textBrush, new PointF(10, 100));
            rect = new RectangleF(20, 110, 30, 30);

            PdfCalRGBColorSpace calRgbCS3 = new PdfCalRGBColorSpace();
            calRgbCS3.Gamma = new double[] { 7.6, 5.1, 8.5 };
            calRgbCS3.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            calRgbCS3.WhitePoint = new double[] { 0.7, 1, 0.8 };

            // Read the ICC profile.
            FileStream fs = new FileStream(GetFullTemplatePath("rgb.icc", false), FileMode.Open, FileAccess.Read);
            byte[] profileData = new byte[fs.Length];
            fs.Read(profileData, 0, profileData.Length);
            fs.Close();

            // Create a new instance of PdfICCColorSpace class.
            PdfICCColorSpace iccCS = new PdfICCColorSpace();

            // Update colorspace.
            iccCS.ProfileData = profileData;
            iccCS.AlternateColorSpace = calRgbCS3;
            iccCS.ColorComponents = 3;
            iccCS.Range = new double[] { 0.0, 1.0, 0.0, 1.0, 0.0, 1.0 };

            // Create a new instance of PdfICCColor class.
            PdfICCColor iccColor = new PdfICCColor(iccCS);
            iccColor.ColorComponents = new double[] { 1, 0, 1 };

            // Create brush using PdfICCColor.
            colorSpaceBrush = new PdfSolidBrush(iccColor);

            // Draw using PdfICCColor brush.
            g.DrawRectangle(colorSpaceBrush, rect);
            # endregion

            # region Separation Color
            g.DrawString("Separation Color", font, textBrush, new PointF(90, 100));
            rect = new RectangleF(100, 110, 30, 30);

            PdfExponentialInterpolationFunction function = new PdfExponentialInterpolationFunction(true);
            float[] numArray = new float[3];
            numArray[0] = 90f;
            numArray[1] = 0.5f;
            numArray[2] = 20f;
            function.C1 = numArray;

            PdfLabColorSpace calLabCS8 = new PdfLabColorSpace();
            calLabCS8.Range = new double[] { 0.2, 1, 0.8, 23.5 };
            calLabCS8.WhitePoint = new double[] { 0.2, 1, 0.8 };

            // Create a new instance of PdfSeparationColorSpace class.
            PdfSeparationColorSpace separationCS = new PdfSeparationColorSpace();
            // Update colorspace.
            separationCS.AlternateColorSpaces = calLabCS8;
            separationCS.TintTransform = function;
            separationCS.Colorant = "PANTONE Orange 021 C";

            // Create a new instance of PdfSeparationColor class.
            PdfSeparationColor separationColor = new PdfSeparationColor(separationCS);
            separationColor.Tint = 0.7;
            
            // Create brush using PdfSeparationColor.
            colorSpaceBrush = new PdfSolidBrush(separationColor);

            // Draw using PdfSeparationColor brush.
            g.DrawRectangle(colorSpaceBrush, rect);
            # endregion

            # region Indexed Color
            g.DrawString("Indexed Color", font, textBrush, new PointF(170, 100));
            rect = new RectangleF(180, 110, 30, 30);

            // Create a new instance of PdfIndexedColorSpace class.
            PdfIndexedColorSpace indexedCS = new PdfIndexedColorSpace();
            // Update colorspace.
            indexedCS.BaseColorSpace = new PdfDeviceColorSpace(PdfColorSpace.RGB);
            indexedCS.MaxColorIndex = 3;
            indexedCS.IndexedColorTable = new byte[] { 150, 0, 222, 255, 0, 0, 0, 255, 0, 0, 0, 255 };

            // Create a new instance of PdfIndexedColor class.
            PdfIndexedColor indexedColor = new PdfIndexedColor(indexedCS);
            indexedColor.SelectColorIndex = 3;

            // Create brush from PdfIndexedColor.
            colorSpaceBrush = new PdfSolidBrush(indexedColor);

            // Draw using PdfIndexedColor brush.
            g.DrawRectangle(colorSpaceBrush, rect);
            # endregion

            # endregion

            // Save and close the document.
            document.Save("Sample.pdf");
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process.Start("Sample.pdf");
                this.Close();
            }
            else
            {
                // Exit
                this.Close();
            }
        }
        # endregion

        # region Helpher Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
            string fullPath = @"..\..\..\..\..\..\..\Common\";
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
        #endregion
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
            string licenseKeyFile = "..\\Common\\SyncfusionLicense.txt";
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