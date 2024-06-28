# I. Purpose of the .NET (v.4.8) WindowForm As Mini-Project

This is mini project using FTP lib in .NET C# to view and download book as PDF to find official book you want

	https://www.gutenberg.org/
 FTP download File using Index Number:
 
 	https://gutenberg.pglaf.org/
Requirement: 
- Visual Studio IDE
- C# Window Form (.NET v.4.8)

# II. Introduction To UI
This is the default list that already added to application.

![1.png : Intro to the UI for view and download book](https://github.com/BunlongCHEA/.NET_FTPDownloadBookFrom_Gutenberg/blob/master/Img_README/1.png)

## Step 1: Add New Book To List
To add new book to list, 
$ Follow this FTP form below, 
	
	ftp://gutenberg.pglaf.org/{index1}/{index2}/{index3}/{index4}/{Book_Full_Index}/{Book_Full_Index}-h/images/

**Example:** John Gutenberg, First Master Printer - has index 50000, then the link should:

	ftp://gutenberg.pglaf.org/5/1/0/0/51000/51000-h/images/cover.jpg

$ Pass the FTP link above to the SearchBox, so that the book will display on UI:

![2.png : Add new book with FTP link](https://github.com/BunlongCHEA/.NET_FTPDownloadBookFrom_Gutenberg/blob/master/Img_README/2.png)

$ You can find index for the book you want to download throught this website:
	
	https://gutenberg.pglaf.org/

![3.png : Gutenberg website with index download file](https://github.com/BunlongCHEA/.NET_FTPDownloadBookFrom_Gutenberg/blob/master/Img_README/3.png)

## Step 2: Mouse Double Click On Book
You can double click on any book that already add to the list for view first:

![4.png : DOUBLE Mouse click to view book file](https://github.com/BunlongCHEA/.NET_FTPDownloadBookFrom_Gutenberg/blob/master/Img_README/4.png)
## Step 3: Download Book As PDF
Click on button download and choose local directory for save as PDF book:

![5.png : Download book as PDF file](https://github.com/BunlongCHEA/.NET_FTPDownloadBookFrom_Gutenberg/blob/master/Img_README/5.png)

This is the end of the Mini-Project, Thank you for reading...
