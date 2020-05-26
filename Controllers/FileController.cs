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

    }

}