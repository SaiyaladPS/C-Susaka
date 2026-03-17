using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCEL_BANK
{
    class Program
    {
        class BANK
        {
            double amount;
            public void Deposit(double money)
            {
                amount = amount + money;
                Console.WriteLine("your balance is {0:N0}", amount);
            }

            public bool Withdraw(double money)
            {
                bool check;
                if (amount - money < 50000)
                {
                    Console.WriteLine("your balance is not enough");
                    check = false;
                }
                else
                {
                    amount = amount - money;
                    Console.WriteLine("your balance is {0:N0} kip", amount);
                    check = true;
                }
                return check;
            }

            public void CheckBalance()
            {
                Console.WriteLine("your balance is {0:N0} kip", amount);
            }

            // --- แก้ไข: ให้คืนค่า bool เหมือน Withdraw เพื่อเอาไปเช็คตอนวนลูป ---
            public bool Transfer(BANK toAccount, double money)
            {
                bool check;
                if (amount - money < 50000)
                {
                    Console.WriteLine("Transfer failed: your balance is not enough (minimum 50,000 kip remaining)");
                    check = false; // โอนไม่สำเร็จ
                }
                else
                {
                    this.amount -= money;       // หักเงินเรา
                    toAccount.amount += money; // เพิ่มเงินให้เพื่อน
                    Console.WriteLine("Transfer Success!");
                    check = true; // โอนสำเร็จ
                }
                return check;
            }
        }

        static void Main(string[] args)
        {
            int number;
            Console.Write("Enter Number of Account: ");
            number = int.Parse(Console.ReadLine());

            BANK[] b = new BANK[number];
            for (int i = 0; i < number; i++)
            {
                b[i] = new BANK();
            }

            int choice;
            int accNo;
            double money;

            do
            {
                Console.WriteLine("\n+=====MENU=====+");
                Console.WriteLine("1. To Deposit");
                Console.WriteLine("2. To Withdraw");
                Console.WriteLine("3. To Check Balance");
                Console.WriteLine("4. To Transfer");
                Console.WriteLine("0. To Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Welcome to Deposit your account");
                    Console.Write("Enter your account number: ");
                    accNo = int.Parse(Console.ReadLine());
                    Console.Write("Enter your money: ");
                    money = double.Parse(Console.ReadLine());
                    b[accNo].Deposit(money);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Welcome to Withdraw your account");
                    Console.Write("Enter your account number: ");
                    accNo = int.Parse(Console.ReadLine());
                    Console.Write("Enter your money: ");
                    money = double.Parse(Console.ReadLine());
                    b[accNo].Withdraw(money);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Welcome to Check your Balance");
                    Console.Write("Enter your account number: ");
                    accNo = int.Parse(Console.ReadLine());
                    b[accNo].CheckBalance();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Welcome to Transfer");
                    Console.Write("Enter YOUR account number (From): ");
                    int fromAcc = int.Parse(Console.ReadLine());
                    Console.Write("Enter TARGET account number (To): ");
                    int toAcc = int.Parse(Console.ReadLine());

                    bool isSuccess; // ตัวแปรสำหรับเก็บสถานะว่าโอนผ่านไหม

                    // --- เพิ่มลูป do..while เพื่อบังคับให้กรอกใหม่จนกว่าจะโอนผ่าน ---
                    do
                    {
                        Console.Write("Enter money to transfer: ");
                        money = double.Parse(Console.ReadLine());

                        // เรียกใช้ Transfer และเก็บค่า true/false ไว้ใน isSuccess
                        isSuccess = b[fromAcc].Transfer(b[toAcc], money);

                        if (isSuccess == false)
                        {
                            Console.WriteLine("--> Please enter a new amount.");
                        }

                    } while (isSuccess == false); // ถ้าไม่ผ่าน (false) ให้วนกลับไปถามยอดเงินใหม่

                    // --- เมื่อโอนเสร็จ (หลุดลูป) แสดงบัญชีทั้งสองอัน ---
                    Console.WriteLine("\n--- Summary after Transfer ---");
                    Console.Write("Account [{0}] ", fromAcc);
                    b[fromAcc].CheckBalance();

                    Console.Write("Account [{0}] ", toAcc);
                    b[toAcc].CheckBalance();
                    Console.WriteLine("------------------------------");
                }

            } while (choice != 0);
        }
    }
}