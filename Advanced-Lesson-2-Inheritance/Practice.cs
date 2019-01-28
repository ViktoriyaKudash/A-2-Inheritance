using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Practice
    {
        /// <summary>
        /// A.L2.P1/1. Создать консольное приложение, которое может выводить 
        /// на печатать введенный текст  одним из трех способов: 
        /// консоль, файл, картинка. 
        /// </summary>
        public static void A_L2_P1_1()
        {
            Console.WriteLine("Введите текст ");
            string text = Console.ReadLine();
            Console.WriteLine("Choose print tupe : ");
            Console.WriteLine("1-console : ");
            Console.WriteLine("2-file : ");
            Console.WriteLine("3-picture : ");
            string type = Console.ReadLine();

            IPrinter printer = null;


            switch (type)
            {
                case "1":
                    var printer1 = new ConsolePrinter( ConsoleColor.Blue);
                    printer1.Print(text);
                    break;
                case "2":
                    var printer2 = new FilePrinter( "test");
                    printer2.Print(text);
                    break;

                case "3":
                  var printer3 = new BitmapPrinter("BitmapPrinerExample");
                    printer3.Print(text);
                    Console.WriteLine("You have choosen printing  into picture ");
                    break;
            }

        }
        public interface IPrinter
        {
            void Print(string text);
        }


        


        class ConsolePrinter : IPrinter
        {
            private ConsoleColor _color;
            public ConsolePrinter( ConsoleColor color) 
            {
                _color = color;
            }
            public void Print(string text)
            {
                Console.ForegroundColor = _color;
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }

        class FilePrinter : IPrinter
        {
            private string _filename;
            public FilePrinter(string textx)
            {
                _filename = textx;
            }

           

            public void Print(string text)
            {
                System.IO.File.AppendAllText($@"D:\\{_filename}.txt", text);
                throw new NotImplementedException();
               
            }
        }

        public class BitmapPrinter : IPrinter
        {
            public string _fileName { get; private set; } 
            public void Print(string str) 
            {
                Bitmap bitmap = new Bitmap(1000, 1000);

                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                float x = 150.0F;
                float y = 50.0F;

                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);
                bitmap.Save($@"D:\\{_fileName}.png");

            }
            public BitmapPrinter(string fileName) : base()
            {
                _fileName = fileName;
            }

        }
    }
}