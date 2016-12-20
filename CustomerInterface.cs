using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AssignmentProgram
{
    /// <summary>
    /// <Reference>
    /// VLE Anglia Ruskin, Broadhaven hotel program
    /// Author:- Ian Brown
    class CustomerInterface
    {
        /// <summary>
        /// Displaying all the Menu choices
        /// </summary>        
        
        public  string path = Directory.GetCurrentDirectory()+"\\Train.txt";
        
        static int nextBookingId;
        
        Train train;
        public CustomerInterface()
        {
            train = new Train();
            while(DisplayMenu());
            
        }

        public int NewBookingNumber()
        {

            //generating a booking number for easy access to records
            Random randomNo = new Random();
            nextBookingId = randomNo.Next(int.MaxValue - 300);
            int result = nextBookingId;
            nextBookingId += 1;
            return result;
        }
        
       public bool DisplayMenu()
        {

            //initial greeting and selection choices
            bool carryOn = true;
            Console.Clear();
            Console.WriteLine("OLD TIME RAIL!\nBooking Number:-{0}", NewBookingNumber());
            Console.WriteLine("");
            Console.WriteLine("Please select from the following choices");
            Console.WriteLine("1. Booking for passenger(s)");            
            Console.WriteLine("2. Display bookings");
            Console.WriteLine("0. Exit");
            

            bool validInput = false;

            do
            {
                validInput = true;
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        BookInPassengers();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        DisplayBookings();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        carryOn = false;
                        Console.WriteLine("\nThank you. Bye!");
                        break;
                    default:
                        Console.WriteLine("\nError! Please enter a valid keystroke.");
                        validInput = false;
                        break;

                }
            } while (!validInput);
            return carryOn;
        }       
            
       
     private void DisplayBookings()
     {
         // Reference:- Anglia ruskin university VLE, Files program
         // Reference:- https://msdn.microsoft.com/en-GB/library/ezwyzy7b.aspx

         Console.WriteLine(File.Exists(path) ? " \nFILE EXISTS.\n" : "File does not exist.");

        try
        {           
            StreamReader reader = new StreamReader(path);            
            string[] myBookings; 
            string lines;            
           
            while (!reader.EndOfStream)
            {
                lines = reader.ReadLine();
                myBookings = lines.Split(',');// refer to the each line and split it by comma seperated so that you can isolate each paramerters.
                Console.WriteLine("Booking:- {0}", lines);        
            }
            Console.ReadLine();
            reader.Close();         
        }
         catch (FileNotFoundException e)
        {
            
            Console.WriteLine("File not found. Detailed message:{0} {1}", path, e.Message);
        }
         catch (IOException e)
        {
             Console.WriteLine("Generic File exception. Detailed message: {0}",
             e.Message);
        }
          
     }

     public string BookInPassengers()
     {
         Console.Clear();

         string mystring2txt = "";
         Cars numOfPassengers = new Cars();
         Baggage baggages = new Baggage();

         mystring2txt += NewBookingNumber();
         mystring2txt += ",";
         mystring2txt += numOfPassengers.PassengerName = AskForInfoString("Passenger Name:- ");
         mystring2txt += ",";
         mystring2txt += numOfPassengers.NumberOfPassengers = AskForInfoInt("How many Passengers:- ");
         mystring2txt += ",";
         mystring2txt += DateAndTime();
         mystring2txt += ",";
         mystring2txt += JourneySelection();
         mystring2txt += ",";
         mystring2txt += numOfPassengers.AssigningSeats();
         mystring2txt += ",";
         mystring2txt += numOfPassengers.AvailableSeats();
         mystring2txt += ",";
         mystring2txt += baggages.baggage = AskForInfoInt("Number of luggage:- ");
         mystring2txt += ",";
         mystring2txt += baggages.Assign();
         Console.WriteLine("Successfully wrote to file");
         Console.ReadLine();

         try
         {
             StreamWriter writer = File.AppendText(path);

             writer.WriteLine(mystring2txt);

             writer.Close();
         }
         catch (IOException e)
         {
             Console.WriteLine("File write exception - {0}", e.Message);
         }

         return mystring2txt;
         

     }

     public int JourneySelection()
     {
         //Route selection
         //Need to add a check train avalability
         int selection, result;

         Train checks = new Train();

         Console.Clear();
         Console.WriteLine("1) Towards Endline Station OR 2) Towards Beggin Station");
         //selection = Convert.ToInt32(Console.ReadLine());         
         bool check = true;
         do
         {
             if (Int32.TryParse(Console.ReadLine(), out selection))
             {

                 check = true;
             }
             else
             {
                 Console.WriteLine("Please type 1) Towards Endline Station OR 2) Towards Beggin Station ");
                 check = false;
             } 
         } while (selection < 1 || selection > 2);
        
         if (selection == 1)
         {
             result = checks.Selection();
             DisplayJourneyToMenu();
         }
         else
         {
             result = checks.Selection();
             DisplayJourneyFromMenu();
         }
         
         return result;          
         
     }

     
    public bool DateAndTime()
    {

        // Time and day selection
        bool carryOn = true;
        Console.Clear();
        Console.WriteLine("1) Saturday AM");
        Console.WriteLine("2) Saturday PM");
        Console.WriteLine("3) Sunday AM");
        Console.WriteLine("4) Sunday PM");

        bool validInput = false;               
       
        do
        {
            validInput = true;
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                default:
                    Console.WriteLine("Please enter a valid numeric keystroke");
                    validInput = false;
                    break;
            }
        } while (!validInput);

        return carryOn;       
    }

   private bool DisplayJourneyToMenu()
    {
       //Train stops selection for the first route
        bool carryOn = true;
        //Console.Clear();
        Console.WriteLine("Please choose your journey from the following!");
        Console.WriteLine("1. Beggin to Suddean Halt");
        Console.WriteLine("2. Beggin to Multhy Pass");
        Console.WriteLine("3. Beggin to Conn Junction");
        Console.WriteLine("4. Beggin to Endline Station");
        Console.WriteLine("5. Suddean Halt to Multhy Pass");
        Console.WriteLine("6. Suddean Halt to Conn Junction");
        Console.WriteLine("7. Suddean Halt to Endline Station");
        Console.WriteLine("8. Multhy Pass to Conn Junction");
        Console.WriteLine("9. Multhy Pass to Endline Station");
        Console.WriteLine("0. Conn Junction to Endline Station");
        Console.WriteLine("Please enter your selection 0-9\n");

        bool validInput = false;

        do
        {
            validInput = true;
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
                    break;
                case ConsoleKey.D9:
                    break;
                case ConsoleKey.D0:
                    break;
                default:
                    Console.WriteLine("Please enter a valid numeric keystroke");
                    validInput = false;
                    break;

            }
        } while (!validInput);

        Console.ReadLine();
        return carryOn;

    }

    private bool DisplayJourneyFromMenu()
    {
        bool carryOn = true;

        //Train stops selection for the second route
        //Console.Clear();
        Console.WriteLine("Please choose your journey from the following!");
        Console.WriteLine("1. Endline Station to Beggin Terminal");
        Console.WriteLine("2. Endline Station to Suddean Halt");
        Console.WriteLine("3. Endline Station to Multhy Pass");
        Console.WriteLine("4. Endline Station to Conn Junction");
        Console.WriteLine("5. Conn Junction to Beggin Terminal");
        Console.WriteLine("6. Conn Junction to Suddean Halt");
        Console.WriteLine("7. Conn Junction to Multhy Pass");
        Console.WriteLine("8. Multhy Pass to Beggin Terminal");
        Console.WriteLine("9. Multhy Pass to Suddean Halt");
        Console.WriteLine("0. Suddean Halt to Beggin Terminal");
        Console.WriteLine("Please enter your selection 0-9\n");

        bool validInput = false;

        do
        {
            validInput = true;
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
                    break;
                case ConsoleKey.D9:
                    break;
                case ConsoleKey.D0:
                    break;
                default:
                    Console.WriteLine("Please enter a valid numeric keystroke");
                    validInput = false;
                    break;

            }
        } while (!validInput);

        Console.ReadLine();
        return carryOn;
    }
               

    
     bool AskForInfoBool(string message)
     {
         //validating user input
         bool result = false;
         ConsoleKeyInfo userInput;
         bool success = false;
         Console.WriteLine(message);
         while (!success)
         {
             userInput = Console.ReadKey();
             if (userInput.Key == ConsoleKey.Y)
             {
                 result = true;
                 success = true;
             }
             else if (userInput.Key == ConsoleKey.N)
             {
                 result = false;
                 success = true;
             }
             else
             {
                 Console.WriteLine("\nThat input was not understood");
             }
         }
         return result;
     }

     string AskForInfoString(string message)
     {
         //validating user input
         string result = "";
         string userInput;

         Console.WriteLine(message);

         userInput = Console.ReadLine();

         return userInput;
     }

     int AskForInfoInt(string message)
     {
         //validating user input
         int result = 0;
         string userInput;
         bool success = false;
         Console.WriteLine(message);
         while (!success)
         {
             userInput = Console.ReadLine();
             if (!Int32.TryParse(userInput, out result))
             {
                 Console.WriteLine("That input was not understood");
             }
             else
             {
                 success = true;
             }
         }
         return result;
     }
 
    }
}
