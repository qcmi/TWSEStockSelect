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

        public void WriteXML(object o)
        {
    
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(o.GetType());

            string path = folderPath + @"\data.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, o);
            file.Close();
        }

        public T ReadXML<T>()
        {
            // Now we can read the serialized book ...
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(T));
            string path = folderPath + @"\data.xml";
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            T obj = (T)reader.Deserialize(file);
            file.Close();

            return obj;
        }

        public bool CheckFileExist()
		{
			return File.Exists(folderPath + @"\data.xml");
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
