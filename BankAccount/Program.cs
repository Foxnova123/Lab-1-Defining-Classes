using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class BankAccount
    {
        private int id;
        private decimal balance;

        public int Id;
        public decimal Balance;

        public BankAccount()
        {

        }
        public BankAccount(int id)
        {
            Id = id;
        }
        public BankAccount(int id, decimal balance)
        {
            Id = id;
            ; Balance = balance;
        }
        public void deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Can't deposite Negative amount");
            }
            else Balance = Balance + amount;
        }
        public void withdraw(decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("We looking for alien brain and we found ! you , yes you");
            }
            else if (amount < 0)
            {
                Console.Write("Cant with draw negative amount");
            }
        }
        public override string ToString()
        {
            Console.WriteLine("Id:{0}", Id);
            Console.WriteLine("Balance:{0}", Balance);
            return base.ToString();
        }
    }
    class Person
    {
        string name;
        int age;
        List<BankAccount> accounts;

        public Person(string n, int a)
        {
            name = n;
            age = a;
        }
        public Person(string n, int a, List<BankAccount> acc)
        {
            name = n;
            age = a;
            accounts = acc;
        }
        public decimal Getbalance()
        {

            decimal sum;
            sum = accounts.Sum(x => x.Balance);
            return sum;
        }
    }
    class Program
    {
        List<BankAccount> accounts;
        public Program()
        {
            accounts = new List<BankAccount>();
        }
        public void ShowMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. End");
            Console.WriteLine("=== END ===");
        }
        public bool IsIdExists(int id)
        {

            return accounts.Exists(x => x.Id == id);
        }

        public void AddBankAccount(int id)
        {
            accounts.Add(new BankAccount(id));

        }
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.ShowMenu();

            Console.WriteLine("Enter your command: ");
            int chooseMenu = Convert.ToInt32(Console.ReadLine());
            int chooseId;
            int chooseAmount;
            Console.WriteLine("Command: {0}", chooseMenu);
            while (chooseMenu != 4)
            {
                if (chooseMenu > 4 || chooseMenu < 0)
                {
                    Console.WriteLine("Invalid command");
                }
                else
                {
                    switch (chooseMenu)
                    {
                        case 1:
                            Console.WriteLine("Please enter ID:");
                            chooseId = Convert.ToInt32(Console.ReadLine());
                            if (myProgram.IsIdExists(chooseId))
                            {
                                Console.WriteLine("Account already exists...");
                            }
                            else
                            {
                                Console.WriteLine("Account created successfully...");

                                myProgram.AddBankAccount(chooseId);
                            }
                            break;
                        case 2:
                            Console.Write("Please enter ID: ");
                            chooseId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Please enter amount: ");
                            chooseAmount = Convert.ToInt32(Console.ReadLine());
                            if (!myProgram.IsIdExists(chooseId))
                            {
                                Console.WriteLine("Account does not exist");
                            }
                            else
                            {
                                myProgram.accounts.Find(x => x.Id == chooseId).deposit(chooseAmount);
                                Console.WriteLine("After deposit");
                                myProgram.accounts.Find(x => x.Id == chooseId).ToString();
                            }
                            break;
                        case 3:
                            Console.Write("Please enter ID: ");
                            chooseId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Please enter amount: ");
                            chooseAmount = Convert.ToInt32(Console.ReadLine());
                            if (!myProgram.IsIdExists(chooseId))
                            {
                                Console.WriteLine("Account does not exist");
                            }
                            else
                            {
                                myProgram.accounts.Find(x => x.Id == chooseId).withdraw(chooseAmount);
                                Console.WriteLine("After withdraw");
                                myProgram.accounts.Find(x => x.Id == chooseId).ToString();
                            }
                            break;
                        case 4: break;
                        default:
                            break;
                            if (chooseMenu == 4) break;

                    }

                    Console.WriteLine("Enter your  command");
                    chooseMenu = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("END PROGRAM");

                List<BankAccount> listAccounts = new List<BankAccount>();
                listAccounts.Add(new BankAccount(1, 10));
                listAccounts.Add(new BankAccount(2, 10));
                listAccounts.Add(new BankAccount(3, 10));
                listAccounts.Add(new BankAccount(4, 10));
                listAccounts.Add(new BankAccount(5, 10));

                Person myPerson = new Person("Peter", 10, listAccounts);
                Console.WriteLine("Sum: {0}", myPerson.Getbalance());


                Console.Read();
            }
        }
    }
}
