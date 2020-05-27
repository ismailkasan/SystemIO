using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace SystemIO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "File Controller";

        }
        [HttpGet("AppendText")]
        public List<string> AppendText()
        {
            List<string> list = new List<string>();
            string path = @"./Example/test.txt";
            // This text is added only once to the file.
            if (!System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine("This");
                sw.WriteLine("is Extra");
                sw.WriteLine("Text");
            }

            // Open the file to read from.
            using (StreamReader sr = System.IO.File.OpenText(path))
            {

                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    list.Add(s);
                }
            }
            return list;

        }

        [HttpGet("Copy")]
        public string Copy()
        {
            /*if there is a file same name in destination directory,throw runtime exception. To awoid this */
            /*for overwrite to file on destination directory, set third parameters true*/
            System.IO.File.Copy(@"./Example/test.txt", @"./Properties/testCopy.txt", true);
            return "File Copied";
        }

        [HttpGet("Create")]
        public List<string> Create()
        {
            List<string> list = new List<string>();
            string path = @"./Example/MyTest.txt";

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = System.IO.File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = System.IO.File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        list.Add(s);
                    }
                }
            }
            catch
            {
                throw;
            }
            return list;
        }

        [HttpGet("GetAttributes")]
        public string GetAttributes()
        {
            var fileAttributes = System.IO.File.GetAttributes(@"./Example");
            return Enum.GetName(typeof(FileAttributes), fileAttributes);
        }

        [HttpGet("FileInfo")]
        public List<string> FileInfo()
        {
            List<string> list = new List<string>();
            string path = @"./Example/test.txt";
            FileInfo d = new FileInfo(path);

            list.Add("Öznitelikler: " + d.Attributes);
            list.Add("Oluşturulma tarihi: " + d.CreationTime);
            list.Add("Var mı? " + d.Exists);
            list.Add("Uzantı: " + d.Extension);
            list.Add("Tam adress: " + d.FullName);
            list.Add("Son erişim zamanı: " + d.LastAccessTime);
            list.Add("Son değişiklik zamanı: " + d.LastWriteTime);
            list.Add("Boyut: " + d.Length);
            list.Add("Klasör adı: " + d.Name);
            list.Add("Bulunduğu klasör: " + d.DirectoryName);
            return list;

        }

        [HttpGet("FileStreamExample")]
        public List<char> FileStreamExample()
        {
            /* A file on disk is opened with the FileStream class. Operation is done with the StreamReader and StreamWriter classes.*/
            /* We can do text-based and byte-based jobs on files.*/
            /* A FileStream object can be created in many different ways.*/
            /* Examples:*/

            /*When we are done with the file, the resources held by the FileStream object are emptied with the Close () */
            /* method of the FileStream class and other processes become available to the file.*/
            /*Using the Close () method:*/

            string adress = @"./Example/test.txt";
            FileStream FSnesnesi1 = new FileStream(adress, FileMode.OpenOrCreate);
            FSnesnesi1.Close();

            FileStream FSnesnesi2 = new FileStream(adress, FileMode.OpenOrCreate, FileAccess.Write);
            FSnesnesi2.Close();

            FileStream FSnesnesi3 = new FileStream(adress, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            FSnesnesi3.Close();

            FileInfo FInesnesi1 = new FileInfo(adress);
            FileStream FSnesnesi4 = FInesnesi1.OpenRead();
            FSnesnesi4.Close();

            FileInfo FInesnesi2 = new FileInfo(adress);
            FileStream FSnesnesi5 = FInesnesi2.OpenWrite();
            FSnesnesi5.Close();

            /* Write and read with the FileStream class*/

            List<char> list = new List<char>();
            FileStream fs = new FileStream(adress, FileMode.Open);
            int ReadedByte;
            while ((ReadedByte = fs.ReadByte()) != -1)
                list.Add((char)ReadedByte);

            return list;

        }

        [HttpGet("FileStreamRead")]
        public byte[] FileStreamRead()
        {
            string adress = @"./Example/test.txt";
            /* Write and read with the FileStream class*/
            FileStream fs = new FileStream(adress, FileMode.Open);
            Byte[] readed = new Byte[5];
            fs.Read(readed, 0, 5);
            return readed;
        }

        [HttpGet("FileStreamWrite/{content}")]
        public string FileStreamWrite(string content)
        {
            string address = @"./Example/test.txt";
            FileStream d = new FileStream(address, FileMode.Create, FileAccess.Write);

            foreach (char a in content)
                d.WriteByte((byte)a);
            d.Flush();
            return "File Writed";
        }
        [HttpGet("FileStreamWriteByte/{content}")]
        public string FileStreamWriteByte(string content)
        {
            string address = @"./Example/test.txt";
            FileStream d = new FileStream(address, FileMode.Create, FileAccess.Write);
            byte[] bytes = Encoding.ASCII.GetBytes(content);

            d.Write(bytes, 0, 5);
            d.Flush();
            return "File Writed";
        }


        [HttpGet("StreamReaderExample")]
        public string StreamReaderExample()
        {
            /*Unlike the FileStream class, the StreamReader class deals with text, not bytes. Methods for creating a StreamReader object:*/

            string address = @"./Example/test.txt";
            FileStream fs = new FileStream(address, FileMode.Open);
            StreamReader sr1 = new StreamReader(fs);
            sr1.Close();
            StreamReader sr2 = new StreamReader(address);
            sr2.Close();
            FileInfo fi = new FileInfo(address);
            FileStream fs2 = fi.OpenRead();
            StreamReader sr3 = new StreamReader(fs2);

            sr3.Close();
            return "Create StreamReader";
        }

        [HttpGet("StreamReaderRead")]
        public List<string> StreamReaderRead()
        {
            /*Unlike the FileStream class, the StreamReader class deals with text, not bytes. Methods for creating a StreamReader object:*/

            string address = @"./Example/test.txt";
            FileStream fs = new FileStream(address, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            List<string> list = new List<string>();
            string content = sr.ReadLine();
            string all = sr.ReadToEnd();
            int id = sr.Read();

            char[] charArray = new char[15];
            sr.Read(charArray, 0, 10);
            string charsStr = new string(charArray);

            list.Add("Content : " + content);
            list.Add("all : " + all);
            list.Add("id : " + id.ToString());
            list.Add("char to string : " +  charsStr) ;
            sr.Close();
            return list;
        }
    }

}