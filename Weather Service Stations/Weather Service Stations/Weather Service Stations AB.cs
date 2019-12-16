using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Service_Stations
{

    class Program
    {
 
        private static String[] strWeatherStation = new String[10];
        private static double[] dbltemperature = new double[14];
        private static int intRecordCount = 0;
       

        static void Main(string[] args)
        {
            //Background and Font colour changed
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.Clear();
            System.Console.ForegroundColor = ConsoleColor.Green;

            //Date and Time introduced to the Main Menu
            DateTime now = DateTime.Now;
            Console.WriteLine((now.ToLongDateString()).PadLeft(119));
            Console.WriteLine((now.ToLongTimeString()).PadLeft(119));


            {
                MainMenu();
            }
        }
        // Code for Writing the Main Menu
        private static void MainMenu()
        {
            int intMenuChoice = 0;
            try
            {
                do
                {
                    Console.WriteLine((" MainMenu").PadLeft(57));
                    System.Console.WriteLine(("").PadRight(120, '_'));
                    Console.WriteLine("\n 1. Accept Information             ");
                    Console.WriteLine("\n 2. Display Information        ");
                    Console.WriteLine("\n 3. Exit       ");
                    Console.WriteLine("\n Please select a menu option   ");
                    intMenuChoice = Convert.ToInt32(Console.ReadLine());
                    switch (intMenuChoice)
                    {
                        case 1:
                            Input(); break;

                        case 2:
                            Display(); break;

                        case 3:
                            HaltProgram(); break;
                        default:
                            System.Console.WriteLine("");
                            Console.WriteLine("Error: INVALID MENU CHOICE, PLEASE RE-ENTER");
                            System.Console.ReadLine();
                            break;
                    }

                } while (intMenuChoice != 3);
            }
            catch ( Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
              

                  
                intMenuChoice = 0;
            }
        }




        private static void Input()

        {

            //Code for writng date/time on the Accepting Information
            System.Console.Clear();
            DateTime now1 = DateTime.Now;
            Console.WriteLine((now1.ToLongDateString()).PadLeft(119));
            Console.WriteLine((now1.ToLongTimeString()).PadLeft(119));

            //Code for Writing Weather infromation 
            System.Console.Write((" ACCEPTING INFORMATION \n ").PadLeft(65));  
            System.Console.WriteLine(("").PadRight(119, '_'));
            System.Console.Write("  \nEnter Location: ");

            strWeatherStation[intRecordCount] = Console.ReadLine();





            while (strWeatherStation[intRecordCount].ToLower() != "exit" || intRecordCount == 30)
            {
                System.Console.Write("Enter Weather Temperature reading: ");


                dbltemperature[intRecordCount] = Convert.ToDouble(Console.ReadLine());
                System.Console.WriteLine("");
                if ((dbltemperature[intRecordCount] < -20 || (dbltemperature[intRecordCount] > 40)))
                {
                    System.Console.WriteLine(" Outside range! Please enter a number between -20 and 40. Press enter to continure");
                    System.Console.ReadLine();
                    MainMenu();
                }
                
                    intRecordCount++;

                    if (intRecordCount == 30)
                    {
                        System.Console.WriteLine("Records limit reached");
                    }
                    else
                    {
                        System.Console.Write("Enter location: ");

                        strWeatherStation[intRecordCount] = Console.ReadLine();
                    }
                }
            }
        
        //Code for working out the Average of all temperatures
        private static double Average()
        {
            double db1Average;
            double dblTotal = 0;
            if (intRecordCount == 0) //no records entered
            {
                return 0;
            }
            else
            {
                int intLoopCount;
                for (intLoopCount = 0; intLoopCount < intRecordCount; intLoopCount++)
                {
                    dblTotal = dblTotal + dbltemperature[intLoopCount];
                }

                db1Average = dblTotal / intRecordCount;
                return db1Average;
            }

        }

        //Code for working out the highest temperature 
        private static String Highest()
        {
            int Max = 0;

            if (intRecordCount == 0) //no records entered
            {
                return "No records entered ";
            }
            else
            {
                int intLoopCount = 0;

                for (intLoopCount = 0; intLoopCount < intRecordCount; intLoopCount++)
                {
                    if (dbltemperature[intLoopCount] > dbltemperature[Max])
                    {
                        Max = intLoopCount;
                    }
                }
                return strWeatherStation[Max] + " with reading of " + dbltemperature[Max];
            }
        }
        //Code for displaying Weather Service information 
        private static void Display()
        {
        //Code for the date and time on the Display slide
            System.Console.Clear();
            DateTime now2 = DateTime.Now;
            Console.WriteLine((now2.ToLongDateString()).PadLeft(119));
            Console.WriteLine((now2.ToLongTimeString()).PadLeft(119));

            if (intRecordCount == 0) //no records entered
            {
                Console.WriteLine("\n\nNo records entered\n");
            }
            else
            {
                int intLoopCount;

                
                System.Console.Clear();

                DateTime now3 = DateTime.Now; 
                Console.WriteLine((now3.ToLongDateString()).PadLeft(119));
                Console.WriteLine((now3.ToLongTimeString()).PadLeft(119));

                Console.WriteLine(" Display Information  ");
                System.Console.WriteLine(("").PadRight(119, '_'));
                Console.WriteLine("\n\n\nLocation".PadRight(20) + "Reading");
                Console.WriteLine("==============================");

                for (intLoopCount = 0; intLoopCount < intRecordCount; intLoopCount++)
                {
                    Console.WriteLine(strWeatherStation[intLoopCount].PadRight(20) + dbltemperature[intLoopCount]);
                }
                Console.WriteLine("==============================");
                Console.WriteLine("No. of Readings: " + intRecordCount);
                System.Console.WriteLine("");
                Console.WriteLine("Highest Reading: " + Highest());
                System.Console.WriteLine("");
                Console.WriteLine("Average Reading: " + Math.Round(Average(), 2));
                Console.WriteLine("\n\n");
            }
        }


        //Halt Procedure
        private static void HaltProgram()
        {

            System.Console.Clear();
            DateTime now4 = DateTime.Now;
            Console.WriteLine((now4.ToLongDateString()).PadLeft(119));
            Console.WriteLine((now4.ToLongTimeString()).PadLeft(119));

            string strResponse = "";
     
            Console.WriteLine("Do you wish to exit?  Yes/No");
            strResponse = System.Console.ReadLine();
            if (strResponse == "Yes")
            {
                Console.WriteLine();
                Console.WriteLine("Good Bye");
                Console.WriteLine();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
            else if (strResponse == "yes")
            {
                Console.WriteLine();
                Console.WriteLine("Good Bye");
                Console.WriteLine();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
            else
            {
                MainMenu();
            }

        }

        //End Halt

    }
}

