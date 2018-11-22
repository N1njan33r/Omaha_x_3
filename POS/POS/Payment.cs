﻿using System;

namespace POS
{
    class Payment
    {
        //Pull reciept
        //prompt payment type
        //If statement for payment calc type
        public string paymentSelection { get; set; }
        private double currentTotal = Reciept.Total;
        private int paymentOption;
        private string change;


        public enum PaymentMethod
        {
            Cash = 1,
            Credit = 2,
            Check = 3
        }

        private void ChooseCash()
        {
            double cashInserted;
            Console.WriteLine($"Please enter amount owed: {currentTotal}");
            string amountEntered = Console.ReadLine();
            double.TryParse(amountEntered, out cashInserted);
            if (!double.TryParse(amountEntered, out cashInserted))
            {
                while (!double.TryParse(amountEntered, out cashInserted))
                {
                    Console.WriteLine("Invalid Cash Entery. Please enter US Currency");
                    amountEntered = Console.ReadLine();
                    double.TryParse(amountEntered, out cashInserted);
                    if (currentTotal > cashInserted)
                    {
                        Console.WriteLine($"Please enter amount greated than {currentTotal.ToString("###.##")}");
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
                                Console.WriteLine("Looks like your having some trouble. Please reach out to the nearest attenedant:");
                                continue;
                            }
                        }

                    }
                }
            }
            while (double.TryParse(amountEntered, out cashInserted) && cashInserted < currentTotal)
            {
                Console.WriteLine($"The amount your enter {cashInserted.ToString("###.##")} is less than your current total {currentTotal.ToString("###.##")}");
                Console.WriteLine($"Please enter the difference {(cashInserted - currentTotal).ToString("###.##")}");
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
                        Console.WriteLine("Looks like your having some trouble. Please reach out to the nearest attenedant:");
                        continue;
                    }
                }
            }

            change = (cashInserted - currentTotal).ToString("###.##");

            Console.WriteLine($"You submitted: {cashInserted} n/" +
                $"Your change: {change} ");

        }
    
        private void ChooseCredit()
        {
            string creditCardEntry;
            int creditCardNumber;
            do
            {
                Console.Write("Please enter the last 4 digits of your Credit Card Number:  ");
                creditCardEntry = Console.ReadLine();
                int.TryParse(creditCardEntry, out creditCardNumber);

            } while ((!int.TryParse(creditCardEntry, out creditCardNumber) || creditCardEntry.Length != 4));

            string creditExpMonthEntry;
            int creditExpMonth;
            string creditExpYearEntry;
            int creditExpYear;
            Console.WriteLine("Please enter the Month and Year your card expires (MM/YY)");
            do
            {
                Console.WriteLine("MM: ");
                creditExpMonthEntry = Console.ReadLine();
                int.TryParse(creditExpMonthEntry, out creditExpMonth);

            } while ((!int.TryParse(creditExpMonthEntry, out creditExpMonth)) || creditExpMonthEntry.Length != 2 || creditExpMonth > 12 || creditExpMonth < 1);
            do
            {
                Console.WriteLine("YY (18-30): ");
                creditExpYearEntry = Console.ReadLine();
                int.TryParse(creditExpYearEntry, out creditExpYear);

            } while ((!int.TryParse(creditExpYearEntry, out creditExpYear)) || creditExpYearEntry.Length != 2
            || creditExpYear > 30 || creditExpYear < 18);


            string cvvEntry;
            int cvv;
            do
            {
                Console.WriteLine("Enter CVV (3 Digit Number):  ");
                cvvEntry = Console.ReadLine();
                int.TryParse(cvvEntry, out cvv);

            } while ((!int.TryParse(cvvEntry, out cvv)) || cvvEntry.Length != 3);

            Console.WriteLine("Credit Authorized");
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

        }

        public void ChoosePayment()
        {
            
            do
            {
            Console.WriteLine("Select your payment method using 1, 2, or 3: ");
            Console.WriteLine("1. Cash /n 2. Credit /n 3. Check");
            paymentSelection = Console.ReadLine();
            int.TryParse(paymentSelection, out paymentOption);
            } while (paymentOption > 3 || paymentOption < 1);

            if (paymentOption == (int)PaymentMethod.Cash)
            {
                ChooseCash();
            }
            else if (paymentOption == (int)PaymentMethod.Credit)
            {
                ChooseCredit();
            }
            else if (paymentOption == (int)PaymentMethod.Check)
            {
                ChooseCheck();

            }



        }

    }
}
