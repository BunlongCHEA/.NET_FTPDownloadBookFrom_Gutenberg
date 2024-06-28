This is mini project using FTP lib in .NET C# to view and download book from - https://www.gutenberg.org/ - to find official book you want
How to use:
1. This is the default list that already added to application. 
![1.png : Intro to the UI for view and download book] (https://github.com/BunlongCHEA/.NET_FTPDownloadBookFrom_Gutenberg/blob/master/Img_README/1.png)
2. To add new book to list, you must follow this form - ftp://gutenberg.pglaf.org/{index1}/{index2}/{index3}/{index4}/{Book_Full_Index}/{Book_Full_Index}-h/images/ - 
and you can find index for the book you want to download throught this website - https://gutenberg.pglaf.org/
	* Example: the book - John Gutenberg, First Master Printer - has index 50000, then the link should - https://gutenberg.pglaf.org/5/0/0/0/50000/50000-h/images/
3. Pass the FTP link above to the SearchBox, and add to display on UI
4. Mouse double click on Book you want to read and download
5. Click on button download and choose local directory for save as PDF book
