using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_DownloadFileFromInternet
{
    public partial class Form1 : Form
    {
        private List<string> ftpFile = new List<string>
        {
            //Must follow this form of link for now
            ("ftp://gutenberg.pglaf.org/5/0/0/0/50000/50000-h/images/cover.jpg"),
            ("ftp://gutenberg.pglaf.org/5/0/0/0/50001/50001-h/images/cover.jpg"),
            ("ftp://gutenberg.pglaf.org/5/0/0/0/50002/50002-h/images/cover.jpg")
        };

        private ImageList imageListBooks;

        public Form1()
        {
            InitializeComponent();

            //Create UI ImageList when there is a new book create
            if (imageListBooks == null)
            {
                imageListBooks = new ImageList();
                imageListBooks.ImageSize = new Size(100,150);
                imageListBooks.TransparentColor = Color.Transparent;
            }
            bookListView.LargeImageList = imageListBooks;
            
            LoadFTPBook();
        }

        private void bookListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Select the book you want and open it to read and download (in next window form)
            if (bookListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedBook = bookListView.SelectedItems[0];
                string title = selectedBook.Text;
                Image imgCover = imageListBooks.Images[selectedBook.ImageIndex];
                string oriUrl = selectedBook.Tag.ToString();
                string contentUrl = $"{oriUrl}0.txt";

                // Check if the content URL is valid
                if (!IsFtpFileExists(contentUrl))
                {
                    // Use the alternative URL if the first one doesn't exist
                    contentUrl = $"{oriUrl}8.txt";
                }

                //picBox.Image = imgCover;

                ReadDownloadBook readDownload = new ReadDownloadBook(imgCover, title, contentUrl);
                readDownload.Show();
            }
        }

        private bool IsFtpFileExists(string url)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                //request.Credentials = new NetworkCredential("anonymous", "anonymous");

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is FtpWebResponse response && response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                throw;
            }
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            string url = txtBox_link.Text;
            if (!string.IsNullOrEmpty(url))
            {
                AddBookToListView(url);
            }
        }

        public void LoadFTPBook()
        {
            foreach (var url in ftpFile)
            {
                AddBookToListView(url);
            }
        }

        private void AddBookToListView(string url)
        {
            try
            {
                int lastIndex = url.LastIndexOf('-') + 1;
                string baseUrl = url.Substring(0, lastIndex);
                //MessageBox.Show(baseUrl);

                //Extract the book number for title
                string titleNum = ExtractBookNumber(url);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        //Add image to cover book
                        Image cover = Image.FromStream(responseStream);
                        imageListBooks.Images.Add(cover);
                        //Index start from 0, so get all count of the book that add to list and -1
                        int imageIndex = imageListBooks.Images.Count - 1;

                        ListViewItem item = new ListViewItem
                        {
                            ImageIndex = imageIndex,
                            Text = titleNum,
                            Tag = baseUrl
                        };
                        bookListView.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error list book at {url}: {ex.Message}");
            }
        }

        private string ExtractBookNumber(string url)
        {
            //Find the last occurrence of the first hyphen(-) and the start of the link
            int lastIndex = url.LastIndexOf('-');
            int startIndex = url.LastIndexOf('/', lastIndex - 1) + 1;

            //Extract the book number for title book
            return url.Substring(startIndex, lastIndex - startIndex);
        }

        //public void IntegerPress(KeyPressEventArgs kp, TextBox t)
        //{
        //    //check if KeyChar is digit and textbox is empty 
        //    if (char.IsDigit(kp.KeyChar) && t.Text.Length == 0)
        //    {
        //        //allow digit to be enter
        //        kp.Handled = false;
        //    }
        //    else if (kp.KeyChar == '\b') //allow backspace
        //    {
        //        kp.Handled = false;
        //    }
        //    else
        //    {
        //        kp.Handled = true;
        //    }
        //}
    }
}