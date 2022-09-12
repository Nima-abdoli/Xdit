using System;
using Terminal.Gui;
using System.Diagnostics;
using System.IO;

namespace Xdit
{
    public class FileHandling
    {
        public string FileLocation{get; set;}
        public string WorkingDirectory{get; set;}


        private string[] ArgsIn{get; set;}
        public bool IsRoot;
        
        public FileHandling(string[] args)
        {
            WorkingDirectory = Environment.CurrentDirectory;
            
            if (args.Length != 0)
            {
                ArgsIn = args;
                FileLocation = WorkingDirectory + fileNameTrim(ArgsIn[0]);
            }
        }


        string fileNameTrim(string fileName)
        {
                return fileName.Trim('.');
        }    
    }
}