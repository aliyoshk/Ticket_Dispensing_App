using System;
using System.Collections.Generic;
using System.Text;

namespace TicketDispensingApp
{
    class TicketDispensing
    {
        int amountToRemit;
        int[] customerNo = new int[100];
        string[] customerName = new string[100];
        string[] address = new string[100];
        int[] amount = new int[100];
        int commission;
        int counter = 0;

        int customerNum;
        public int[] sum = new int[100];

        public bool VerifyUserTicket(int num)
        {
            bool found = false;

            for (int i = 0; i < counter; i++)
            {
                if (num == customerNo[i])
                {
                    found = true;
                    break;
                }
                else
                {
                    found = false;
                }
            }
            return found;
        }


        public void validateInput(char ch)
        {
            if (ch == 'b' || ch == 'B')
            {
                BuyTicket();
            }

            else if (ch == 'v' || ch == 'V')
            {
                VerifyTicket();
            }

            else if (ch == 'a' || ch == 'a')
            {
                AmountGenerated();
            }

            else
            {
                Console.WriteLine("Invalid Option!!! TRY AGAIN");
            }
            Console.WriteLine("\n");
            displayOptions();
        } // End of Validate Inputs

        public void displayOptions()
        {
            char choice;
            Console.WriteLine("\t\t\t\tWelcome to NURTW (OWODA) Ticket Dispensing App");
            Console.WriteLine("PLEASE SELECT ONE OF THE FOLLOWING OPTIONS");
            Console.WriteLine("B: TO BOOK TICKET\nV: TO VERIFY USER TICKET\nA: TO VIEW ALL GENERATED");
            choice = Console.ReadLine()[0];

            validateInput(choice);
        } // End of Display Options Method


        public void BuyTicket()
        {
            Console.WriteLine("\n\t\tTICKET RESERVATION MENU\nENTER YOUR FULL NAME");
            customerName[counter] = Console.ReadLine();

            Console.WriteLine("ENTER CUSTOMER'S ADDRESS'");
            address[counter] = Console.ReadLine();


            TicketType();

            customerNo[counter] = 76540000 + counter;

            Console.WriteLine("\nTICKET BOOKED SUCCESSFUL");
            Console.WriteLine("\t\t\t\tTRANSACTION RECEIPTS");
            Console.WriteLine("CUSTOMER NAME: " + customerName[counter] + "\nTICKET ID IS: " 
                + customerNo[counter] + "\nTRANSPORT FARE: " + amount[counter]);

            counter = counter + 1;
            Console.WriteLine("\nEnter any Key to continue\n");
            Console.ReadKey();
            displayOptions();

        } // End of Buy ticket Method

        public int TicketType()
        {
            char type;
            amount[counter] = 0;
            Console.WriteLine("CHOOSE TICKET TYPE");
            Console.WriteLine("D: FOR DAILY");
            Console.WriteLine("M: FOR MONTHLY");
            type = Console.ReadLine()[0];

            if (type == 'd' || type == 'D')
            {
                amount[counter] = 300;
            }
            else if (type == 'M' || type == 'm')
            {
                amount[counter] = 300 * 30 / 2;
            }
            else
            {
                Console.WriteLine("NO SUCH TICKET");
            }

            return amount[counter];
        }

        public void VerifyTicket()
        {
            string sCustomerNum;
            Console.WriteLine("\n\t\tTICKET VERIFICATION MENU\nENTER TICKET NUMBER");
            sCustomerNum = Console.ReadLine();
            customerNum = Int32.Parse(sCustomerNum);


            if (VerifyUserTicket(customerNum) == true)
            {
                Console.WriteLine("TICKET VERIFIED");
                Console.WriteLine("CUSTOMER NAME: " + customerName[customerNum - 76540000] + "\nCUSTOMER ADDRESS: " + address[customerNum - 76540000] +
                "\nAMOUNT PAID " + amount[customerNum - 76540000] + "\nTICKET NUMBER: " + customerNo[customerNum - 76540000] + "\n");

                Console.WriteLine("\n");
                Console.WriteLine("\nEnter any Key to continue\n");
                Console.ReadKey();
                displayOptions();
            }

            else
            {
                Console.WriteLine("INVALID TICKET NUMBER");
                Console.WriteLine("\nEnter any Key to continue\n");
                Console.ReadKey();
                displayOptions();
            }
        }// End of Verify Ticket Method

        public void AmountGenerated()
        {
            Console.WriteLine("\t\tTOTAL SALES AMOUNT");
            for (int i = 0; i < counter; i++)
            {
                commission = amount[i] * 65 / 100;
                amountToRemit = amount[i] - commission;
                Console.WriteLine("Ticket Reference: " + customerNo[i] + "\nCustomer Name: " 
                    + customerName[i] + "\nCustomer Address " + address[i] + "\nAmount Paid: "
                    + amount[i] + "\nAmount to Remit is: " + commission + "\nYour Percentage is: " + amountToRemit + "\n");
            }
            SumTicket();

        }// End of Amount Generated Method

        public void SumTicket()
        {
            int sum = 0;
            Array.ForEach(amount, delegate (int i)
            {
                sum += i;

            });
            Console.WriteLine("\nThe Total Sales is: " + sum + "\nTotal Amount to Remit is " + (sum - commission));
        }
    }
}
