using System;

namespace POS
{
    class Payment
    {
        //Pull receipt
        //prompt payment type
        //If statement for payment calc type
        public string paymentSelection { get; set; }
        private double currentTotal = Receipt.Total;
        private int paymentOption;
        private string change;


        enum PaymentMethod
        {
            Cash = 1,
            Credit = 2,
            Check = 3
        }

        private void ChooseCash()
        {
            double cashInserted;
            Console.WriteLine($"Amount owed: $" + "{0:0.00}", currentTotal);
            Console.Write($"Amount tendered: $");
            string amountEntered = Console.ReadLine();
            bool validInput = double.TryParse(amountEntered, out cashInserted);
            if (!validInput)
            {
                while (!validInput)
                {
                    Console.WriteLine("Invalid Cash Entry. Please enter US Currency");
                    amountEntered = Console.ReadLine();
                    double.TryParse(amountEntered, out cashInserted);
                    if (currentTotal > cashInserted)
                    {
                        Console.WriteLine($"Please enter amount greater than {currentTotal.ToString("###.##")}");
                        amountEntered = Console.ReadLine();
                        double additionalCash;
                        if (!double.TryParse(amountEntered, out additionalCash))
                        {
                            continue;
                        }
                        else if (double.TryParse(amountEntered, out additionalCash))
                        {
                            cashInserted = cashInserted + additionalCash;
                            if (cashInserted > currentTotal)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Looks like your having some trouble. Please reach out to the nearest attendant:");
                                continue;
                            }
                        }
                    }
                }
            }
            while (double.TryParse(amountEntered, out cashInserted) && cashInserted < currentTotal)
            {
                currentTotal -= cashInserted;
                Console.WriteLine("Balance remaining: $" + "{0:0.00}", currentTotal);
                ChoosePayment();
                //Console.WriteLine($"The amount your enter {cashInserted.ToString("###.##")} is less than your current total {currentTotal.ToString("###.##")}");
                //Console.WriteLine($"Please enter the difference {(cashInserted - currentTotal).ToString("###.##")}");
                //amountEntered = Console.ReadLine();
                //double additionalCash;
                //if (!double.TryParse(amountEntered, out additionalCash))
                //{
                //    continue;
                //}
                //else if (double.TryParse(amountEntered, out additionalCash))
                //{
                //    cashInserted = cashInserted + additionalCash;
                //    if (cashInserted > currentTotal)
                //    {
                //        break;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Looks like your having some trouble. Please reach out to the nearest attendant:");
                //        continue;
                //    }
                //}
            }
            change = (cashInserted - currentTotal).ToString("###.##");

            Console.WriteLine($"You submitted: ${cashInserted}" + Environment.NewLine + $"Your change: {change} ");

            if (currentTotal <= 0) 
                FinishEverything();

        }
        

        private void ChooseCredit()
        {
            string creditCardEntry;
            int creditCardNumber;
            do
            {
                Console.Write("Please enter last 4 digits of card number: ");
                creditCardEntry = Console.ReadLine();
                int.TryParse(creditCardEntry, out creditCardNumber);

            } while ((!int.TryParse(creditCardEntry, out creditCardNumber) || creditCardEntry.Length != 4));

            string creditExpMonthEntry;
            int creditExpMonth;
            string creditExpYearEntry;
            int creditExpYear;
            Console.WriteLine("Please enter expiration (MM/YY)");
            do
            {
                Console.Write("MM: ");
                creditExpMonthEntry = Console.ReadLine();
                int.TryParse(creditExpMonthEntry, out creditExpMonth);

            } while ((!int.TryParse(creditExpMonthEntry, out creditExpMonth)) || creditExpMonthEntry.Length != 2 || creditExpMonth > 12 || creditExpMonth < 1);
            do
            {
                Console.Write("YY (18-30): ");
                creditExpYearEntry = Console.ReadLine();
                int.TryParse(creditExpYearEntry, out creditExpYear);

            } while ((!int.TryParse(creditExpYearEntry, out creditExpYear)) || creditExpYearEntry.Length != 2
            || creditExpYear > 30 || creditExpYear < 18);


            string cvvEntry;
            int cvv;
            do
            {
                Console.Write("Enter CVV (3 Digit Number):  ");
                cvvEntry = Console.ReadLine();
                int.TryParse(cvvEntry, out cvv);

            } while ((!int.TryParse(cvvEntry, out cvv)) || cvvEntry.Length != 3);

            Console.WriteLine("Credit Authorized");

            if (currentTotal <= 0)
                FinishEverything();
        }

        private void ChooseCheck()
        {
            string checkNumberEntry;
            int checkNumber;

            do
            {
                Console.WriteLine("Enter 3 to 4 digit check number:  ");
                checkNumberEntry = Console.ReadLine();
                int.TryParse(checkNumberEntry, out checkNumber);

            } while ((!int.TryParse(checkNumberEntry, out checkNumber) || checkNumberEntry.Length > 4 || checkNumberEntry.Length < 3));

            if (currentTotal <= 0)
                FinishEverything();

        }

        public void ChoosePayment()
        {
            
            //do
            //{
            Console.WriteLine("Select your payment method: ");
            Console.WriteLine(" 1 - Cash" + Environment.NewLine + " 2 - Credit" + Environment.NewLine + " 3 - Check");
            Console.Write("Selection: ");
            //paymentSelection = Console.ReadLine();
            ConsoleKeyInfo paymentMethod = Console.ReadKey();
            Console.WriteLine();
            //int.TryParse(paymentSelection, out paymentOption);

            //} while (paymentOption > 3 || paymentOption < 1);

            if (!(paymentMethod.KeyChar.Equals('1') | paymentMethod.KeyChar.Equals('2') | paymentMethod.KeyChar.Equals('3')))
                ChoosePayment();
            else if (paymentMethod.KeyChar.Equals('1'))
            {
                ChooseCash();
            }
            else if (paymentMethod.KeyChar.Equals('2'))
            {
                ChooseCredit();
            }
            else if (paymentMethod.KeyChar.Equals('3'))
            {
                ChooseCheck();
            }
        }

        void FinishEverything()
        {
            Console.WriteLine("Thank you for using Omaha POS System.");
        }
    }
}
