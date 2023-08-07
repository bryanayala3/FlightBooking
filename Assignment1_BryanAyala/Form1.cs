namespace Assignment1_BryanAyala
{

    /*
 * Program ID: AirlineReservation Assignment 1
 * 
 * Prupose: To demostrate abilities to create forms
 * 
 * Revision history:
 * Bryan Ayala January 28, 2023
 */

    public partial class AirlineResevation : Form
    {
        public AirlineResevation()
        {
            InitializeComponent();
        }
        
        
        //Variables and Array to save the information:
                                                     
        String[,] bookedSeat = new String[,] { { "A0", "" }, { "A1", "" }, { "A2", "" }, { "B0", "" }, { "B1", "" }, { "B2", "" }, { "C0", "" }, { "C1", "" }, { "C2", "" }, { "D0", "" }, { "D1", "" }, { "D2", "" }, { "E0", "" }, { "E1", "" }, { "E2", "" } };
        String[] waitingListArray = new String[] { "", "", "", "", "", "", "", "", "", "" };
        string seatMarked;
        bool availableVerification;
        bool availableVerificationSingle;
        ToolTip seatMessage = new ToolTip();


        private void AirlineResevation_Load(object sender, EventArgs e)
        {

            colorSeats();

        }

        //Button to show all register of the reservations

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            showAllBox.Clear();
            statusBox.Clear();
            informationLabel.Text = "";

            for (int i = 0; i < bookedSeat.GetLength(0); i++)
            {
                showAllBox.Text += bookedSeat[i, 0] + " - " + bookedSeat[i, 1]+ "\r\n";
            }
        }

        //button to make a reservation

        private void bookButton_Click(object sender, EventArgs e)
        {
            statusBox.Clear();

            //Verificatrion if the array has empty place

            availableVerification = false;

            for (int i = 0; i < bookedSeat.GetLength(0); i++)
            {
                for (int j = 0; j < bookedSeat.GetLength(1); j++)
                {
                    if (bookedSeat[i, j] == "")
                    {
                        availableVerification = true;
                        break;
                    }
                    
                }
            }

            if (availableVerification)
            {

                //According validation before to make the reservation

                if (nameBox.Text.Length != 0 && rowList.Text != "" && columnList.Text != "")
                {
                    
                    seatMarked = string.Concat(rowList.Text, columnList.Text);

                    int[] index = new int[2];
                    for (int i = 0; i < bookedSeat.GetLength(0); i++)
                    {
                        for (int j = 0; j < bookedSeat.GetLength(1); j++)
                        {
                            if (bookedSeat[i, j] == seatMarked)
                            {
                                index[0] = i;
                                index[1] = j;
                                break;
                            }
                        }
                    }

                    if (bookedSeat[index[0], 1] == "")
                    {
                        bookedSeat[index[0], 1] = nameBox.Text;
                        showAllBox.Clear();

                        for (int i = 0; i < bookedSeat.GetLength(0); i++)
                        {
                            showAllBox.Text += bookedSeat[i, 0] + " - " + bookedSeat[i, 1] + "\r\n";
                        }
                        informationLabel.Text = "Successful booking!";
                        //MessageBox.Show("Booked!", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        colorSeats();
                    }
                    else
                    {
                        informationLabel.Text = "The seat is occuppied. Please select other!";
                        //MessageBox.Show("The seat is occuppied. Please select other!", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                else
                {
                    informationLabel.Text = "Please Enter name and SELECT your seat";
                    //MessageBox.Show("Please Enter name and SELECT your seat", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            //In case of we have full list of reservation the program with the next code it could save data in the waiting List

            else if (!availableVerification && nameBox.Text.Length != 0)
            {
                DialogResult dr = MessageBox.Show("All seats are occupied. Do you want enter to the Waiting List?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    availableVerificationSingle = false;

                    for (int i = 0; i < waitingListArray.Length; i++)
                    {
                        if (waitingListArray[i] == "")
                        {
                            availableVerificationSingle = true;
                        }
                    }

                    int indexSingleArray = Array.IndexOf(waitingListArray, "");

                    if (availableVerificationSingle)
                    {

                         waitingListArray[indexSingleArray] = nameBox.Text;
                         waitingBox.Clear();

                         for (int i = 0; i < waitingListArray.Length; i++)
                         {
                                waitingBox.Text += 1+i + ". " + waitingListArray[i] + "\r\n";
                         }

                        informationLabel.Text = "Added to the waiting list!";
                        //MessageBox.Show("Added to the waiting list!", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        informationLabel.Text = "The waiting list is full";
                        //MessageBox.Show("The waiting list is full", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
            else if (nameBox.Text.Length == 0)
            {
                informationLabel.Text = "Please Enter name";
               // MessageBox.Show("Please Enter name", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //Button to show the waiting List

        private void showWaitingButton_Click(object sender, EventArgs e)
        {
            informationLabel.Text = "";
            statusBox.Clear();
            waitingBox.Clear(); 

            for (int i = 0; i < waitingListArray.Length; i++)
            {
                waitingBox.Text += waitingListArray[i] + "\r\n";
            }
        }

        //Button to add directly to the waiting list

        private void AddWaitingButton_Click(object sender, EventArgs e)
        {
            statusBox.Clear();
            informationLabel.Text = "";

            availableVerification = false;

            for (int i = 0; i < bookedSeat.GetLength(0); i++)
            {
                for (int j = 0; j < bookedSeat.GetLength(1); j++)
                {
                    if (bookedSeat[i, j] == "")
                    {
                        availableVerification = true;
                        break;
                    }

                }
            }

            availableVerificationSingle = false;

            for (int i = 0; i < waitingListArray.Length; i++)
            {
                if (waitingListArray[i] == "")
                {
                    availableVerificationSingle = true;
                }
            }

            int indexSingleArray = Array.IndexOf(waitingListArray, "");

            if (!availableVerification)
            {

                if (availableVerificationSingle)
                {


                    if (nameBox.Text.Length != 0)
                    {
                        waitingListArray[indexSingleArray] = nameBox.Text;
                        waitingBox.Clear();

                        for (int i = 0; i < waitingListArray.Length; i++)
                        {
                            waitingBox.Text += 1+i + ". " + waitingListArray[i] + "\r\n";

                           // System.Windows.Forms.MessageBox.Show(waitingListArray[indexSingleArray].ToString()+i);
                        }
                        informationLabel.Text = "Added to the waiting list!";
                        //MessageBox.Show("Added to the waiting list!", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        informationLabel.Text = "Please Enter name and SELECT your seat";
                        //MessageBox.Show("Please Enter name and SELECT your seat", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    informationLabel.Text = "The waiting list is full";
                    //MessageBox.Show("The waiting list is full", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                informationLabel.Text = "There are available Seats, please choose one!";
            }
        }

        //Status button to know the details of whatever Seat in the aircraft

        private void statusButton_Click(object sender, EventArgs e)
        {
            statusBox.Clear();
            informationLabel.Text = "";

            if (rowList.Text != "" && columnList.Text != "")
            {


                seatMarked = string.Concat(rowList.Text, columnList.Text);

                int[] index = new int[2];
                for (int i = 0; i < bookedSeat.GetLength(0); i++)
                {
                    for (int j = 0; j < bookedSeat.GetLength(1); j++)
                    {
                        if (bookedSeat[i, j] == seatMarked)
                        {
                            index[0] = i;
                            index[1] = j;
                            break;
                        }
                    }
                }

                if (bookedSeat[index[0], 1] != "")
                {
                    statusBox.Text = "The Seat selected is occupied by " + bookedSeat[index[0], 1]; 

                }
                else 
                {
                    statusBox.Text = "The Seat selected is empty";

                }

            }
            else
            {
                
                informationLabel.Text = "Please SELECT your Seat";
            }
        }
        
        //cancel button to delete whatever reservation made and processs to move somebody in the waiting list to the te booking list automatically

        private void cancelButton_Click(object sender, EventArgs e)
        {
            statusBox.Clear();
            informationLabel.Text = "";

            if (rowList.Text != "" && columnList.Text != "")
            {

                seatMarked = string.Concat(rowList.Text, columnList.Text);

                int[] index = new int[2];
                for (int i = 0; i < bookedSeat.GetLength(0); i++)
                {
                    for (int j = 0; j < bookedSeat.GetLength(1); j++)
                    {
                        if (bookedSeat[i, j] == seatMarked)
                        {
                            index[0] = i;
                            index[1] = j;
                            break;
                        }
                    }
                }

                if (bookedSeat[index[0], 1] != "")
                {
                    DialogResult dr = MessageBox.Show("Do you want to cancel this reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {

                        bookedSeat[index[0], 1] = "";
                        showAllBox.Clear();
                        waitingBox.Clear();

                        for (int i = 0; i < bookedSeat.GetLength(0); i++)
                        {
                            showAllBox.Text += bookedSeat[i, 0] + " - " + bookedSeat[i, 1] + "\r\n";
                        }

                        informationLabel.Text = "The Reservation is cancelled!";

                        colorSeats();

                        availableVerificationSingle = false;

                        for (int i = 0; i < waitingListArray.Length; i++)
                        {
                            if (waitingListArray[i] != "")
                            {
                                availableVerificationSingle = true;
                            }
                        }
                        if (availableVerificationSingle)
                        {
                            bookedSeat[index[0], 1] = waitingListArray[0];

                            for (int i=0; i < waitingListArray.Length - 1; i++)
                            {
                                waitingListArray[i] = waitingListArray[i + 1];
                            }

                            waitingListArray[waitingListArray.Length - 1] = "";

                            waitingBox.Clear();
                            
                            for (int i = 0; i < waitingListArray.Length; i++)
                            {
                                waitingBox.Text += 1+i + ". " + waitingListArray[i] + "\r\n";
                            }

                            showAllBox.Clear();

                            for (int i = 0; i < bookedSeat.GetLength(0); i++)
                            {
                                showAllBox.Text += bookedSeat[i, 0] + " - " + bookedSeat[i, 1] + "\r\n";
                            }

                            MessageBox.Show("Waiting List and Booking List are updated", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            colorSeats();

                        }
                        else
                        {
                            MessageBox.Show("The Seat " +seatMarked+ " is available", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                else
                {
                    informationLabel.Text = "The Seat does not have reservation yet";
                }

            }
            else
            {
                informationLabel.Text = "Please SELECT the Seat to cancel the Reservation";
            }

        }

        //Fill all the places in the booking list, only is necessary the name of the customer

        private void fillAllButton_Click(object sender, EventArgs e)
        {
            statusBox.Clear();
            informationLabel.Text = "";

            if (nameBox.Text != "")
            {

                for (int i = 0; i < bookedSeat.GetLength(0); i++)
                {

                    bookedSeat[i, 1] = nameBox.Text;
                    
                    
                }

                showAllBox.Clear();

                for (int i = 0; i < bookedSeat.GetLength(0); i++)
                {
                    showAllBox.Text += bookedSeat[i, 0] + " - " + bookedSeat[i, 1] + "\r\n";
                }

                informationLabel.Text = "All Seats are filled! ";

                colorSeats();

            }
            else
            {
                informationLabel.Text = "Please Enter the reservation Name";
            }
        }
       
        //The next methos is to do change in the graphics Seats. The seats change their description when the mouse howervering over them.
       
        private void A0_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            
            seatMessage.RemoveAll();

            if (bookedSeat[0, 1] != "")
            {

                seatMessage.SetToolTip(A0, bookedSeat[0,1]);

            }
            else
            {
                seatMessage.SetToolTip(A0, "Available");
            }

        }


        private void A1_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[1, 1] != "")
            {

                seatMessage.SetToolTip(A1, bookedSeat[1, 1]);

            }
            else
            {
                seatMessage.SetToolTip(A1, "Available");
            }
        }

        private void A2_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[2, 1] != "")
            {

                seatMessage.SetToolTip(A2, bookedSeat[2, 1]);

            }
            else
            {
                seatMessage.SetToolTip(A2, "Available");
            }
        }

        private void B0_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[3, 1] != "")
            {

                seatMessage.SetToolTip(B0, bookedSeat[3, 1]);

            }
            else
            {
                seatMessage.SetToolTip(B0, "Available");
            }
        }

        private void B1_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[4, 1] != "")
            {

                seatMessage.SetToolTip(B1, bookedSeat[4, 1]);

            }
            else
            {
                seatMessage.SetToolTip(B1, "Available");
            }
        }

        private void B2_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[5, 1] != "")
            {

                seatMessage.SetToolTip(B2, bookedSeat[5, 1]);

            }
            else
            {
                seatMessage.SetToolTip(B2, "Available");
            }
        }

        private void C0_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[6, 1] != "")
            {

                seatMessage.SetToolTip(C0, bookedSeat[6, 1]);

            }
            else
            {
                seatMessage.SetToolTip(C0, "Available");
            }
        }

        private void C1_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[7, 1] != "")
            {

                seatMessage.SetToolTip(C1, bookedSeat[7, 1]);

            }
            else
            {
                seatMessage.SetToolTip(C1, "Available");
            }
        }

        private void C2_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[8, 1] != "")
            {

                seatMessage.SetToolTip(C2, bookedSeat[8, 1]);

            }
            else
            {
                seatMessage.SetToolTip(C2, "Available");
            }
        }

        private void D0_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[9, 1] != "")
            {

                seatMessage.SetToolTip(D0, bookedSeat[9, 1]);

            }
            else
            {
                seatMessage.SetToolTip(D0, "Available");
            }
        }

        private void D1_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[10, 1] != "")
            {

                seatMessage.SetToolTip(D1, bookedSeat[10, 1]);

            }
            else
            {
                seatMessage.SetToolTip(D1, "Available");
            }
        }

        private void D2_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[11, 1] != "")
            {

                seatMessage.SetToolTip(D2, bookedSeat[11, 1]);

            }
            else
            {
                seatMessage.SetToolTip(D2, "Available");
            }
        }

        private void E0_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[12, 1] != "")
            {

                seatMessage.SetToolTip(E0, bookedSeat[12, 1]);

            }
            else
            {
                seatMessage.SetToolTip(E0, "Available");
            }
        }

        private void E1_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[13, 1] != "")
            {

                seatMessage.SetToolTip(E1, bookedSeat[13, 1]);

            }
            else
            {
                seatMessage.SetToolTip(E1, "Available");
            }
        }

        private void E2_MouseEnter(object sender, EventArgs e)
        {
            // Display message
            seatMessage.RemoveAll();

            if (bookedSeat[14, 1] != "")
            {

                seatMessage.SetToolTip(E2, bookedSeat[14, 1]);

            }
            else
            {
                seatMessage.SetToolTip(E2, "Available");
            }
        }

        //Metoho to validate the status of the graphics Seat, then it change their colours, green to availability seats and red to occupied seats
        public void colorSeats()
        {

            for (int i = 0; i < bookedSeat.GetLength(0); i++)
            {
                if (bookedSeat[i, 1] == "")
                {
                    switch (i)
                    {
                        case 0:
                            A0.BackColor = Color.Green;
                            break;

                        case 1:
                            A1.BackColor = Color.Green;
                            break;
                        case 2:
                            A2.BackColor = Color.Green;
                            break;
                        case 3:
                            B0.BackColor = Color.Green;
                            break;
                        case 4:
                            B1.BackColor = Color.Green;
                            break;
                        case 5:
                            B2.BackColor = Color.Green;
                            break;
                        case 6:
                            C0.BackColor = Color.Green;
                            break;
                        case 7:
                            C1.BackColor = Color.Green;
                            break;
                        case 8:
                            C2.BackColor = Color.Green;
                            break;
                        case 9:
                            D0.BackColor = Color.Green;
                            break;
                        case 10:
                            D1.BackColor = Color.Green;
                            break;
                        case 11:
                            D2.BackColor = Color.Green;
                            break;
                        case 12:
                            E0.BackColor = Color.Green;
                            break;
                        case 13:
                            E1.BackColor = Color.Green;
                            break;
                        case 14:
                            E2.BackColor = Color.Green;
                            break;

                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            A0.BackColor = Color.Red;
                            break;

                        case 1:
                            A1.BackColor = Color.Red;
                            break;
                        case 2:
                            A2.BackColor = Color.Red;
                            break;
                        case 3:
                            B0.BackColor = Color.Red;
                            break;
                        case 4:
                            B1.BackColor = Color.Red;
                            break;
                        case 5:
                            B2.BackColor = Color.Red;
                            break;
                        case 6:
                            C0.BackColor = Color.Red;
                            break;
                        case 7:
                            C1.BackColor = Color.Red;
                            break;
                        case 8:
                            C2.BackColor = Color.Red;
                            break;
                        case 9:
                            D0.BackColor = Color.Red;
                            break;
                        case 10:
                            D1.BackColor = Color.Red;
                            break;
                        case 11:
                            D2.BackColor = Color.Red;
                            break;
                        case 12:
                            E0.BackColor = Color.Red;
                            break;
                        case 13:
                            E1.BackColor = Color.Red;
                            break;
                        case 14:
                            E2.BackColor = Color.Red;
                            break;

                    }
                }

                
            }

           


        }
    }
}