using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace SystemIO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PathController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Path Controller";

        }

        [HttpGet("PathInfo")]
        public  List<string> PathInfo()
        {
            List<string> list = new List<string>();

            string adres = @"./Example/test.txt";
            list.Add("Uzantı: " + Path.GetExtension(adres));
            string yeniAdres = Path.ChangeExtension(adres, "jpg");
            list.Add("Yeni uzantı: " + Path.GetExtension(yeniAdres));
            string adres2 = @"/Properties";
            list.Add("Yeni adres: " + Path.Combine(adres, adres2));
            list.Add("Klasör: " + Path.GetDirectoryName(adres));
            list.Add("Dosya adı: " + Path.GetFileName(adres));
            list.Add("Uzantısız dosya adı: " + Path.GetFileNameWithoutExtension(adres));
            list.Add("Tam adres: " + Path.GetFullPath(adres));
            list.Add("Kök dizin: " + Path.GetPathRoot(adres));
            list.Add("Geçici dosya adı: " + Path.GetTempFileName());
            list.Add("Geçici dosya dizini: " + Path.GetTempPath());
            list.Add("Dosya uzantısı var mı? " + Path.HasExtension(adres));
            list.Add("Alt dizin ayıracı: " + Path.AltDirectorySeparatorChar);
            list.Add("Dizin ayıracı: " + Path.DirectorySeparatorChar);
         
            char[] dizi = Path.GetInvalidFileNameChars();
            foreach (char b in dizi)
                list.Add(b + " ");
          
            char[] dizi2 = Path.GetInvalidPathChars();
            foreach (char b in dizi)
                list.Add(b + " ");
            list.Add("\nAdres ayırıcı karakter: " + Path.PathSeparator);
            list.Add("Kök dizin ayıracı: " + Path.VolumeSeparatorChar);

            return list;

        }

    }

}