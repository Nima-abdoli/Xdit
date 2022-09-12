using System;
using Terminal.Gui;
using System.Diagnostics;

namespace Xdit
{
    class Program
    {

        private static TextView _textView;

        private static StatusBar StatBar;

        private static Platforms platform; 
        private static string FileLocation;

        static void Main(string[] args)
        {
            OsLook();

            Application.Init();

            Toplevel top = Application.Top;

            ColorScheme colorScheme = new ColorScheme();
            colorScheme = Colors.TopLevel;

            Window win = new Window("XDIT v0.0.1"){
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

            _textView.Text = System.IO.File.ReadAllText (args[0]);

            // run Terminl_gui 
            Application.Run();

            // Reset Terminal after program closed so the terminal will not be messy 
            ResetEnvirment();


        }// End of Main

        static void beeper(){
            Console.Beep();
        }// will be deleted no use maybe some use

        private static void Quit ()
		{
            //Environment.Exit(0);
			Application.RequestStop ();
		}

        // Check for which platform(Os, kernel) are used.  
        private static void OsLook()
        {
           if (OperatingSystem.IsWindows())
            {
                platform = Platforms.Windows;
            }
           else
            {
                platform = Platforms.linux;
            }
        }// end of OsLook Method.
        
        private static void ResetEnvirment()
        {
            if (platform == Platforms.linux)
            {
                Process.Start("/bin/reset","");
            }
            else 
            if (platform == Platforms.Windows)
            {
                Console.Clear(); // no use but do it.
            }
        }// End of ResetEnvirment method


    }// end of class Programm

    enum Platforms
        {
            Windows = 1,
            linux,
        }// end of Platforms enumerator
        
}// end of namespcae Xdit
