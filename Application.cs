using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsperational_Quotes
{
    class Application
    {

        
        
        static void Main(string[] args)
        {

            string[]  people = null;
            string[]  action = null;
            string[]  conseq = null;
            string[] quoter = null;
            string loopString = "";
            Console.WriteLine("press x to exit");

            while (loopString != "x")
            {
                ReadFiles(ref people, ref action, ref conseq, ref quoter);

                GenerateQuote(ref people, ref action, ref conseq, ref quoter);
                
                loopString = Console.ReadLine();
            }
        }



        private static void GenerateQuote(ref string[] people, ref string[] action, ref string[] conseq, ref string[] quoter)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            int randomPeople;

            if (rnd.Next(0, 100) < rnd.Next(0, 100) * 2) //half the time select one of the first five people tags
            {
                randomPeople = rnd.Next(0, 5);
            }
            else
            {
                randomPeople = rnd.Next(5, people.Length);
            }
            
            
            int randomAction = rnd.Next(0, action.Length );
            int randomConseq = rnd.Next(0, conseq.Length );
            int randomQuoter = rnd.Next(0, quoter.Length);

            sb.Append(people[randomPeople]);
            sb.Append(" ");
            sb.Append(action[randomAction]);
            sb.Append(" ");
            sb.Append(conseq[randomConseq]);
            sb.Append(". - ");
            sb.Append(quoter[randomQuoter]);

            Console.WriteLine(sb);



        }






        private static void ReadFiles(ref string[] people, ref string[] action, ref string[] conseq, ref string[] quoter)
        {

            try
            {
                using (StreamReader sr = new StreamReader("Person.txt"))
                {
                    String line = sr.ReadToEnd();
                    //people = line.Split((char)13);
                    people = line.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                people = null;
            }

            try
            {
                using (StreamReader sr = new StreamReader("Action.txt"))
                {
                    String line = sr.ReadToEnd();
                    //action = line.Split((char)13);
                    action = line.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                action = null;
            }

            try
            {
                using (StreamReader sr = new StreamReader("Conseq.txt"))
                {
                    String line = sr.ReadToEnd();
                    //conseq = line.Split((char)13);
                    conseq = line.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                conseq = null;
            }

            try
            {
                using (StreamReader sr = new StreamReader("Quoter.txt"))
                {
                    String line = sr.ReadToEnd();
                    //conseq = line.Split((char)13);
                    quoter = line.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                quoter = null;
            } 

        }



    }
}
