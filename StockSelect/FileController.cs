using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace StockSelect
{
	public class FileController
	{
		public string Path { get; set; }
		string folderPath = @"\Data";

		public FileController()
		{
			folderPath = Directory.GetCurrentDirectory() + folderPath;
		}

		public void WriteTextFile(List<StockInfo> stock_list)
		{

		}

		public bool CheckFileExist(DateTime Date)
		{
			string sDate = Date.ToShortDateString();
			return File.Exists(@"\Data\" + sDate + ".txt");
		}

		public void CreateFolder()
		{
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
		}
		
	}
}
