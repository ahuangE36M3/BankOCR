using System;
using System.Collections.Generic;

namespace BankOCR
{
    public class AccountController
    {
        private CharModel _aChar;
        private AccountNumModel _accountNum;
        

        public void ParseFile(string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);
            int length = lines.Length;
            int index = 0;
            
            Console.WriteLine("Start Parsing File: ");

            for (; index < length; index += 4)
            {
                //int[] accountNum = new int[9];

                _accountNum = new AccountNumModel(new string[]
                {
                    lines[index],
                    lines[index + 1],
                    lines[index + 2]
                });

                DisplayAccountNumAndStatus(_accountNum);
            }
            Console.WriteLine("Finish Parsing File. Enter any key to terminate.");
            Console.ReadLine();
        }

        private void DisplayAccountNumAndStatus(AccountNumModel accountNum)
        {
            Console.Write(_accountNum.ToString());
            Console.Write(" ");

            if (accountNum.Status == AccountNumModel.AccountStatus.Error)
            {
                Console.Write("ERR\n");
                //ShowPossibleAccountNum(accountNum);
            }
            else if (accountNum.Status == AccountNumModel.AccountStatus.Illegal)
            {
                Console.Write("ILL\n");
                //ShowPossibleAccountNum(accountNum);
            }
            else
            {
                Console.WriteLine("");
            }

        }

        //this is not working
        private void ShowPossibleAccountNum(int[] accountNum)
        {
            Console.WriteLine("AMB");
            List<AccountNumModel> possible = new List<AccountNumModel>();
            //line 0: replace space with _

        }
    }
}