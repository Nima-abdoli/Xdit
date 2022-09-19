using System;
using Terminal.Gui;
using System.Diagnostics;
using System.IO;

namespace Xdit
{
    public class FileHandling
    {

        #region Public Property

        // Save Complete location of file based on platform
        public string FileLocation{get; set;}

        // Save the path of directory where app called from terminal.
        public string WorkingDirectory{get; set;}

        //get file text
        public string FileText{get; set;}

        #endregion end Public Property

        #region Private Property

        // save argument thay come to app
        private string[] ArgsIn{get; set;}

        // make sure that working directory is in top of directories hierarchy or not. for complaication may occur in diffrent path format in diffrent platform 
        public bool IsRoot; 

        //instance of platform class to determine os and platform that app run in.
        private Platforms _platform = new Platforms();

        // instance for platform enum
        private PlatformsEnum _platfromsEnum;

        #endregion end Private Property
        
        // constructor to get argument from terminal(entry) and handle all diffrent scenario that will happend to entry argument.
        public FileHandling(string[] args)
        {
            // get the directory of where app called or run.
            WorkingDirectory = Environment.CurrentDirectory;

            // Check for Platfrom Type
            _platfromsEnum = _platform.OsLook();
            
            // check if there is argument in array.
            if (args.Length != 0)
            {   
                // this may be deleted in test always get file but maybe app have other argument to
                ArgsIn = args;
                // path to the file.
                FileLocation = WorkingDirectory + fileNameTrim(ArgsIn[0]);

                FileText = openFile();
            }
        }// end of FileHandling Constructor.

        // TODO : need linux and window file handling
        // trim the file path. windows use format like this {.\file.ext} thepoint must be deleted. linux handle it in other way.
        string fileNameTrim(string fileName)
        {
            if (_platfromsEnum == PlatformsEnum.Windows)
            {
                return fileName.Trim('.');
            }
            else if (_platfromsEnum == PlatformsEnum.linux)
            {
                return  "/" + fileName;
            }
            else
            {
                return null;
            }
                
        }// end of fileNameTrim  

        // read text from file.
        public string openFile()
        {
            return File.ReadAllText(FileLocation);
        }

        public void SaveFile(string TextToSave)
        {
            Mainc.LogEnding("From FileHandling * " + WorkingDirectory + @"\testFile.txt");
            Mainc.LogEnding("From FileHandling ** " + FileLocation);
            //Mainc.LogEnding("Args handl *** " + ArgsIn[0]);

            if (_platfromsEnum == PlatformsEnum.Windows)
            {
                File.WriteAllText(WorkingDirectory + @"\testFile.txt",TextToSave);
            }
            else if (_platfromsEnum == PlatformsEnum.linux)
            {
                File.WriteAllText(WorkingDirectory + @"/testFile.txt",TextToSave);
            }
        }

    }// end of FileHandling Class
}// end of Xdit Namespace