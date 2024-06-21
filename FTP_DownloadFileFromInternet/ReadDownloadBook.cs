using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_DownloadFileFromInternet
{
    public partial class ReadDownloadBook : Form
    {
        private System.Drawing.Image coverBook;
        private string contentUrl;
        private string title;

        public ReadDownloadBook(System.Drawing.Image coverBook, string title, string contentUrl)
        {
            InitializeComponent();
            //Save all data to this variable
            this.coverBook = coverBook;
            this.contentUrl = contentUrl;
            this.title = title;

            //Initial picture cover book to display
            //this.coverPic.Location = new Point(10, 10);
            this.coverPic.Size = new Size(200, 300);
            this.coverPic.SizeMode = PictureBoxSizeMode.Zoom;
            this.coverPic.Image = coverBook;

            //Display content of the book
            ReadContent(contentUrl);
        }

        private void ReadContent(string contentUrl)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(contentUrl);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                //Read the content of book and display on view readContent
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    readContent.Text = content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error load content at {contentUrl}: {ex.Message}");
            }
        }

        private void download_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"{title}.pdf"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string titlePdf = saveFile.FileName;
                DownloadAsPDF(coverBook, titlePdf, readContent.Text);
            }
        }

        private void DownloadAsPDF(System.Drawing.Image coverBook, string titlePdf, string readContent)
        {
            try
            {
                using (PdfWriter writer = new PdfWriter(titlePdf))
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    //Add cover to the pdf first, then will include text to the pdf later
                    using (MemoryStream ms = new MemoryStream())
                    {
                        //coverBook.Save(ms, coverBook.RawFormat);
                        coverBook.Save(ms, ImageFormat.Png);
                        byte[] imageByte = ms.ToArray();
                        iText.Layout.Element.Image pdfImg = new iText.Layout.Element.Image(
                            ImageDataFactory.Create(imageByte));

                        //PageSize pageSize = pdf.GetDefaultPageSize();
                        //pdfImg.SetFixedPosition(0, 0);
                        //pdfImg.SetWidth(pageSize.GetWidth());
                        //pdfImg.SetHeight(pageSize.GetHeight());
                        pdfImg.SetMaxHeight(1000); //Set the max height for the image
                        pdfImg.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        document.Add(pdfImg);
                    }

                    if (!string.IsNullOrEmpty(readContent))
                    {
                        //Add content to pdf
                        document.Add(new Paragraph(readContent).
                            SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED));
                    }
                    document.Close();
                    MessageBox.Show($"Download PDF Successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}");
            }

        }
    }
}
