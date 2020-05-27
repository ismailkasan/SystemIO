using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace SystemIO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectoryInfoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "DirectoryInfo Controller";
        }

        [HttpGet("DirectoryInfo")]
        public List<string> DirectoryInfo()
        {
            List<string> list = new List<string>();
            string path = @"./Example";
            DirectoryInfo d = new DirectoryInfo(path);

            list.Add("Özellikler: " + d.Attributes);
            list.Add("Oluşturulma tarihi: " + d.CreationTime);
            list.Add("Var mı? " + d.Exists);
            list.Add("Uzantı: " + d.Extension);
            list.Add("Tam adres: " + d.FullName);
            list.Add("Son erişim zamanı: " + d.LastAccessTime);
            list.Add("Son değişiklik zamanı: " + d.LastWriteTime);
            list.Add("Klasör adı: " + d.Name);
            list.Add("Bir üst klasör: " + d.Parent);
            list.Add("Kök dizin: " + d.Root);
            return list;

        }
       

    }

}