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

        public void WriteXML(object o, string filename)
        {
            this.CreateFolder();
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(o.GetType());

			filename = filename + ".xml";
			string path = folderPath + @"\" + filename;
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, o);
            file.Close();
        }

        public T ReadXML<T>(string filename)
        {
            // Now we can read the serialized book ...
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

			filename = filename + ".xml";
			string path = folderPath + @"\" + filename;
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            T obj = (T)reader.Deserialize(file);
            file.Close();

            return obj;
        }

        public bool CheckFileExist(string filename)
		{
			filename = filename + ".xml";
			return File.Exists(folderPath + @"\" + filename);
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
