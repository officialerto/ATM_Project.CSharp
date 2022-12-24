using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    //Abstraction
    public cardHolder(String cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getlastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        cardNum = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void main(string[] args)
    {

        void printOptions()
        {
            Console.WriteLine("Please Choose from One of the Following Options.. ");
            Console.WriteLine("1. Deposit ");
            Console.WriteLine("2. Withdraw ");
            Console.WriteLine("3. Show Balance ");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }


        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw?");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if (currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532717281852795", 1234, "John", "Griffith", 150.13));
        cardHolders.Add(new cardHolder("1852739527395953", 3212, "Ashley", "Jones", 56.23));
        cardHolders.Add(new cardHolder("4532772818527395", 4564, "Frida", "Griffith", 345.67));
        cardHolders.Add(new cardHolder("3275728185739595", 7777, "Muneeb", "Harding", 678.13));
        cardHolders.Add(new cardHolder("4538182739545327", 7594, "Dawn", "Smith", 12.46));

        //Prompt User
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please Insert Your Debit Card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not Recognized. Please Try Again."); }
            }
            catch { Console.WriteLine("Card not Recognized. Please Try Again."); }

            Console.WriteLine("Please Enter Your Pin: ");

            int userPin = 0;

            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //Check against our db
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Card not Recognized. Please Try Again."); }
                }
                catch { Console.WriteLine("Incorrect pin. Please Try Again."); }

            }

        }
    }



}

