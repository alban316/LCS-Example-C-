using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {

        public static int LesserOf (int a, int b)
        {
            return (a < b ? a : b);
        }


        static void Main(string[] args)
        {
            string phrase_b = "The quick brown";
            string phrase_a = "quick brown fox";

            //string phrase_a = "GGGGHHHHWHWHWHAAAWERWER";
            //string phrase_b = "WHAT";

            //string phrase_a = "some data";
            //string phrase_b = "data";

            char[] char_a = phrase_a.ToCharArray();
            char[] char_b = phrase_b.ToCharArray();


            string sub = "";
            List<string> match = new List<string>();

            for (int i = 0; i < char_a.Length; i++) //first string
            {
                for (int j = 0; j < char_b.Length; j++) //second string
                {
                    char a = char_a[i];
                    char b = char_b[j];
                    int k = 1;
                    int remaining = LesserOf(char_b.Length - j, char_a.Length - i);

                    while (a == b && k <= remaining) //equal char? loop until no more equals
                    {
                        sub += a; //concatenate this char to prev matched chars

                        if (k < remaining)
                        {
                            a = char_a[i + k];
                            b = char_b[j + k];
                        }
                        
                        k++;
                    }

                    if (!String.IsNullOrEmpty(sub))
                    {
                        match.Add(sub); //no more matches, add this sequence of chars (string!) to list
                    }

                    sub = "";
                }


            }


            //list all the matched substrings
            foreach (var item in match)
            {
                Console.WriteLine(item);
            }

            //now just show the longest...
            Console.WriteLine("\n{0}", match.OrderByDescending(m => m.Length).First());


            Console.ReadKey(true);

        }
    }
}
