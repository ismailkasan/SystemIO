
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace SystemIO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Directory Controller";
        }

        [HttpGet("CreateDirectory")]
        public string CreateDirectory()
        {
            Directory.CreateDirectory(@"./Example");
            return "Directory Created";
        }

        [HttpGet("CreateUpDirectory")]
        public string CreateUpDirectory()
        {
            Directory.CreateDirectory(@"../UpExample");
            return "Up Directory Created";
        }

        [HttpGet("DeleteDirectory")]
        public string DeleteDirectory()
        {
            Directory.Delete(@"../UpExample", true);
            return "Directory Deleted";
        }

        [HttpGet("DirectoryExist")]
        public bool DirectoryExist()
        {
            return Directory.Exists(@"./Example");
        }

        [HttpGet("GetCurrentDirectory")]
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        [HttpGet("GetDirectories")]
        public string[] GetDirectories()
        {
            return Directory.GetDirectories(@"../SystemIO");
        }

        [HttpGet("GetDirectoryRoot")]
        public string GetDirectoryRoot()
        {
            return Directory.GetDirectoryRoot("home/ismail/Desktop/Demolar/netCore/SystemIO");
        }

        [HttpGet("GetFiles")]
        public string[] GetFiles()
        {
            return Directory.GetFiles(@"./Controllers", "H*");
        }

        [HttpGet("GetFileSystemEntries")]
        public string[] GetFileSystemEntries()
        {
            return Directory.GetFileSystemEntries(@"../SystemIO");
        }

        [HttpGet("GetLastAccessTime")]
        public DateTime GetLastAccessTime()
        {
            return Directory.GetLastAccessTime(@"../SystemIO");
        }

        [HttpGet("GetLogicalDrives")]
        public string[] GetLogicalDrives()
        {
            return Directory.GetLogicalDrives();
        }

        [HttpGet("GetParent")]
        public string GetParent()
        {
            return Directory.GetParent(@"../SystemIO").Name;
        }

    }

}