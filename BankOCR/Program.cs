using System;
using System.Dynamic;

namespace BankOCR
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountController accountController = new AccountController();
            accountController.ParseFile(@"C:\Dev\Kata\BankOCR\BankOCR\usecase1.txt");
        }
    }
}