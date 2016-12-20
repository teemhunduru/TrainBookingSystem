using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignmentProgram
{
    /// <summary>
    /// Check train availability
    /// </summary>
    class Train
    {

        public int selection { get; set; }

        public int Selection()
        {
            //checking if Trains are not full
            int result = 0;
            
                if (selection <= 4 || selection >= 1)
                {
                    result = selection; 
                    Console.WriteLine("There are some available seats. Please continue");                    
                }
                else
                {
                    Console.WriteLine("Sorry the train is full. Please check the Timetable for the next Train");
                }
                Console.ReadLine();
            return result;
        }
        
    }
}
