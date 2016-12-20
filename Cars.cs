using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignmentProgram
{
    /// <summary>
    /// Seat assigning based on user input
    /// </summary>
    class Cars
    {
        
        public int NumberOfPassengers { get; set; }

        public string PassengerName { get; set; }

        public int TotalPassengers { get; set; }

        bool seats = false;

        public int totalAssignedFirstClass, totalAssignedSecondClass, totalAssignedThirdClass, totalAssignedFourthClass;

        public int AssigningSeats()
        {
            
            int selectedCar = 0;

            //checking seat availability in Cars
            //then offering options if full
            //displaying error messages for unavailable seats

            bool check = true;
                Console.WriteLine("Please type 1) for First class or 2) for Standard class.");
                do
                {
                    if (Int32.TryParse(Console.ReadLine(), out selectedCar))
                    {
                        
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Please type 1 or 2 for First or Standard class");
                        check = false;
                    }
                } while (selectedCar < 1 || selectedCar > 2); 
             if (selectedCar == 1)
             {
                 CheckAvailability();
             }
             else
             {
                 AssignSecondClass();
             }
             //Console.ReadLine();
            return selectedCar;
        }

        private void CheckAvailability()
        {
           
                if (NumberOfPassengers > 32 && NumberOfPassengers < 132)
                {
                    Console.WriteLine("Sorry First class is full. Do you want a Standard class ticket? Y/N");
                    if (Console.ReadLine().Equals("N"))
                    {
                        Console.WriteLine("Thank you. Please check the Timetable for the next Train");

                    }
                    else
                    {
                        AssignSecondClass();
                    }
                } 
                else
                {
                    AssignFirstClass();
                }                
        }

        public void AssignSecondClass()
        {
            
            // checking seat availability and assigning Cars to passengers
             
            if (NumberOfPassengers < 32)
                {
                AssignCompartmentB();              
                }
            else
                if (NumberOfPassengers < 50)
                {
                    AssignStandardC();                 
                }
            else
                if (NumberOfPassengers < 50)
                {
                    AssignStandardD();                
                }                       
        }

        private void AssignStandardD()
        {
            // assigning seat numbers and outputting the information
          int i=0;
          for (i = 0; i < 50; i++)
              do
              {
                  Console.WriteLine("Seat number is D{0}", i);
                  seats = true;
                  i++; totalAssignedFourthClass++;
              } while (i < NumberOfPassengers);
                   
        }

        private void AssignStandardC()
        {
            // assigning seat numbers and outputting the information
            int i=0;
            do
            {
                Console.WriteLine("Seat number is C{0}", i);
                seats = true;
                i++; totalAssignedThirdClass++;
            } while (i < NumberOfPassengers);
            
        }

        private void AssignCompartmentB()
        {
            // assigning seat numbers and outputting the information
            int i=0;
            do
            {
                Console.WriteLine("Seat number is B{0}", i);
                seats = true;
                i++; totalAssignedSecondClass++;
            } while (i < NumberOfPassengers);
            
        }



        private void AssignFirstClass()
        {
            // assigning seat numbers and outputting the information

            int i=0;           
                do
                {
                    Console.WriteLine("Seat number is A{0}", i);                    
                    seats = true;
                    i++; totalAssignedFirstClass++;
                } while (i < NumberOfPassengers);
                       
        }

        public int AvailableSeats()
        {
            int available = 0, result;

            result =+ NumberOfPassengers;
            available = 164 - result;                           
            Console.WriteLine("\nAvailable seats are {0}\n", available);
            
            return available;
        }
    }
}
