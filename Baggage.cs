using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignmentProgram
{
    /// <summary>
    /// Allocate Baggage
    /// </summary>
    class Baggage
    {
        
        public int baggage { get; set; }

        int[] totalBaggage = new int[41];
        int totalAssignedBaggage;

        public int Assign()
        {
            //allocating baggage to free spaces
            int i = 0;
                do
                {
                    if (baggage > 0)
                    {
                        Console.WriteLine("Your baggage number is {0}", i);
                        totalAssignedBaggage =+ totalBaggage[i];
                        i++; totalAssignedBaggage++;
                    }
                    else
                    {
                        Console.WriteLine("No baggage allocated. Thank you");
                    }
                    
                } while ( i < baggage) ;

            return totalAssignedBaggage;
        }
    }
}
