using System;
using Terminal.Gui;

namespace Xdit
{
    class Program
    {

        private static TextView _textView;

        private static StatusBar StatBar;

        static void Main(string[] args)
        {
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

            _textView.Text = System.IO.File.ReadAllText (@"D:\Developing\C#\Under Developing\Xdit\Program.cs");


            Application.Run();
        }

        static void beeper(){
            Console.Beep();
        }

        private static void Quit ()
		{
			Application.RequestStop ();
		}
        
    }
}
