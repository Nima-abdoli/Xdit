using System;
using Terminal.Gui;
using System.Diagnostics;

namespace Xdit
{
    public class MainClasss
    {
        #region Private property and variable
        
        // opened file save in this var
        static string StrForTextView = "";

        // instance of Textview from Terminal gui library
        private static TextView _textView;

        // instance of Statusbar from Terminal gui library
        private static StatusBar StatBar;

        // instance of platform class to determine os and platform that app run in.
        private static Platforms _platform = new Platforms();
        
        // get the name of platform from platform class that send enum and enum. can use better design maybe be deleted in future.
        private static string Os;

        // instance for platform enum 
        private static PlatformsEnum _platformsEnum;

        // instance of FileHandling class that open, save , write and ... files
        static private FileHandling file;
        #endregion end Private property
        
        #region Main Function
        static void Main(string[] args)
        {
            _platformsEnum = _platform.OsLook();
            file = new FileHandling(args);

            Application.Init();

            Toplevel top = Application.Top;

            ColorScheme colorScheme = new ColorScheme();
            colorScheme = Colors.TopLevel;

            Window win = new Window("XDIT v0.2.1"){
                X = 0 ,
                Y = 0 ,
                ColorScheme = colorScheme,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            StatBar = new StatusBar(new StatusItem[] {
                new StatusItem(Key.F2,"~F2~ Save",() => beeper()),
                new StatusItem(Key.F3,"~F3~ nothing",() => beeper()),
                new StatusItem(Key.F4,"~F4~ Exit",() => Quit()),
            });


            _textView = new TextView () {
                X = 0,
                Y = 0,
                Width = Dim.Fill (),
                Height = Dim.Fill (),

            };

            top.Add(win);
            win.Add(_textView);
            top.Add(StatBar);

            StrForTextView = file.FileLocation + "\n" + args[0];

            if (file.FileLocation != null)
            {
                //_textView.Text = System.IO.File.ReadAllText (file.FileLocation);
                _textView.Text = StrForTextView;
            }

            // run Terminl_gui 
            Application.Run();

            // Reset Terminal after program closed so the terminal will not be messy 
            ResetEnvirment();
            
            System.Console.WriteLine("------------------------------------------");
            System.Console.WriteLine(" File Location : "+file.FileLocation);
            System.Console.WriteLine("------");
            System.Console.WriteLine(" Working Directory : " + file.WorkingDirectory);
            System.Console.WriteLine("------");
            System.Console.WriteLine("Platform : " + Os);

        }// End of MainClasss
        #endregion end main
        
        #region Misc Function
        static void beeper(){
            Console.Beep();
        }// will be deleted no use maybe some use

        private static void Quit ()
		{
            //Environment.Exit(0);
			Application.RequestStop ();
		}
        
        private static void ResetEnvirment()
        {
            if (_platformsEnum == PlatformsEnum.linux)
            {
                Process.Start("/bin/reset","");
                Os = "linux";
            }
            else 
            if (_platformsEnum == PlatformsEnum.Windows)
            {
                Console.Clear(); // no use but do it.
                Os = "windows";
            }
        }// End of ResetEnvirment method
        #endregion End Misc Function

    }// end of class Main

}// end of namespcae Xdit