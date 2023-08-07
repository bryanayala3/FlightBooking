using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_BryanAyala
{
    internal class Seat
    {
        //Variables
        public string namePassenger;
        public string seatNumber;
        public String[,] bookedSeat = new String[,] { { "A0", "" }, { "A1", "" }, { "A3", "" }, { "B0", "" }, { "B1", "" }, { "B2", "" }, { "C0", "" }, { "C1", "" }, { "C2", "" }, { "D0", "" }, { "D1", "" }, { "D2", "" } };


        //Constructor

        public Seat() 
        {
            namePassenger = "";
        }

        public string namePas()
        { 
            return namePassenger;
        }
        /*public string showAll()
        {

            return bookedSeat[0, 0] + bookedSeat[0,1];
        }*/
    }
}
