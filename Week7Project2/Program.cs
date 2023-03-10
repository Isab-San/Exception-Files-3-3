using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.CompilerServices;

namespace Week7Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             What is not working here? All fixed!
                I don't remember how to get the variables to work with one initialization. So I wont have to keep entering the filePath. Use a class?
                The 'file path is not valid' will not show up. Wait, I tested it and it worked, why did I say that it didnt?
                There needs to be a third option of the file path being a valid one, but it doesn't exist. Use File.Exist!
             */
            Console.WriteLine("Please enter a file path: ");

            /*string filePath = @"" + Console.ReadLine();
            string line;*/

            try
            {
                Variables v = new Variables();
                Utility.ValidFormat(v.filePath, v.line);
                
            }
            /*catch (FormatException f)
            {
                Console.WriteLine("Input was not entered in the correct format");
            }*/
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() + ": " + e.Message);
            }
        }
        public class Variables
        {
            public string filePath;
            public string line;

            public Variables()
            {
                filePath = @"" + Console.ReadLine();
               // line = "";
            }
        }

        public class Utility
        {


            public static void ValidFormat(string filePath, string line)//checks the regex format, then proceeds to the next functions if correct
            {
                //string filePath = @"" + Console.ReadLine();

                var check = new Regex(@"^(?:[\w]\:|\\)([A-Za-z\s\\s0-9\.]+)+\.(txt)$");



                if (check.IsMatch(filePath))
                {
                    Console.WriteLine("File path is valid");
                    Console.WriteLine(File.Exists(filePath) ? "Opening the file..." : "File does not exist.");
                    FileExist(filePath, line);
                }
                else
                {
                    Console.WriteLine("File path is not a valid format!");
                }
            }

            public static void FileExist(string filePath, string line)//reads the file, but is also supposed to check if it exists first.
            {
                //Console.WriteLine("Please re-enter file path to have the contents read");
                //string filePath = @"" + Console.ReadLine();

                StreamReader sr = new StreamReader(filePath);

                //string line;
                do
                {
                    line = sr.ReadLine();
                    Console.WriteLine(line);
                } while (line != null);

                Utility.WordCount(filePath, line);

            }

            public static void WordCount(string filePath, string line) //counts the amount of words in the file
            {
                //Console.WriteLine("Please re-enter the file path to have the amount of words counted");
                //string filePath = @"" + Console.ReadLine();
                //string line;
                int wordsCount = 0;

                using (StreamReader file = File.OpenText(filePath))
                {
                    do
                    {
                        line = file.ReadLine();
                        if (line != null)
                        {
                            wordsCount += line.Split(' ').Length;
                        }
                    } while (line != null);
                }
                Console.WriteLine("There are " + wordsCount + " words in the file");
            }
        }
        
    }
}