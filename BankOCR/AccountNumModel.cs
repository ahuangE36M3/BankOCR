using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCR
{
    class AccountNumModel
    {
        private CharModel[] AccountNumChars { get; }
        private int[] AccountNum { get; set; }
        public AccountStatus Status { get; set; }

        public AccountNumModel(int[] numbers)
        {
            AccountNumChars = new CharModel[9];
            AccountNum = new int[9];
            Status = ValidateAccountNumber(AccountNum);
        }

        public AccountNumModel(string[] linesOfPrints)
        {
            AccountNumChars = new CharModel[9];
            AccountNum = new int[9];
            ParseOneAccountEntry(linesOfPrints);
            Status = ValidateAccountNumber(AccountNum);
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (int digit in AccountNum)
            {
                if (digit != 10)
                {
                    result += digit.ToString();
                }
                else
                {
                    result += "?";
                }
            }

            return result;
        }

        private AccountStatus ValidateAccountNumber(int[] accountNum)
        {
            int sum = 0;
            int factor = accountNum.Length;
            foreach (int digit in accountNum)
            {
                ///////////add if digit is 10 then it would be a ILL state
                if (digit == 10)
                {
                    return AccountStatus.Illegal;
                }
                sum = sum + (digit * factor);
                factor--;
            }

            if (sum % 11 == 0)
            {
                return AccountStatus.Good;
            }

            return AccountStatus.Error;
        }

        private void ParseOneAccountEntry(string[] lines)
        {
            int x = 0;
            int y = 0;
            int[] response = new int[(lines[1].Length / 3)];
            //manage emtpy string
            int index = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    lines[index] = "                           ";
                }
                index++;
            }

            //start parsing
            for (; x < 27; x += 3)
            {
                string[] letter = new String[]
                {
                    lines[y].Substring(x, 3),
                    lines[y+1].Substring(x, 3),
                    lines[y+2].Substring(x, 3),
                };
                var aChar = new CharModel(letter);
                int digit = letterToNum(aChar);
                AccountNumChars[(x / 3)] = aChar;
                AccountNum[(x / 3)] = digit;
            }
        }

        private int letterToNum(CharModel a)
        {
            int result = 10;
            if (a == _zero)
            {
                result = 0;
            }
            if (a == _one)
            {
                result = 1;
            }
            if (a == _two)
            {
                result = 2;
            }
            if (a == _three)
            {
                result = 3;
            }
            if (a == _four)
            {
                result = 4;
            }
            if (a == _five)
            {
                result = 5;
            }
            if (a == _six)
            {
                result = 6;
            }
            if (a == _seven)
            {
                result = 7;
            }
            if (a == _eight)
            {
                result = 8;
            }
            if (a == _nine)
            {
                result = 9;
            }
            return result;
        }

        public enum AccountStatus { Good, Error, Illegal };

        private readonly CharModel _zero = new CharModel(new string[]
        {
            " _ ",
            "| |",
            "|_|"
        });
        private readonly CharModel _one = new CharModel(new string[]
        {
            "   ",
            "  |",
            "  |"
        });
        private readonly CharModel _two = new CharModel(new string[]
        {
            " _ ",
            " _|",
            "|_ "
        });
        private readonly CharModel _three = new CharModel(new string[]
        {
            " _ ",
            " _|",
            " _|"
        });
        private readonly CharModel _four = new CharModel(new string[]
        {
            "   ",
            "|_|",
            "  |"
        });
        private readonly CharModel _five = new CharModel(new string[]
        {
            " _ ",
            "|_ ",
            " _|"
        });
        private readonly CharModel _six = new CharModel(new string[]
        {
            " _ ",
            "|_ ",
            "|_|"
        });
        private readonly CharModel _seven = new CharModel(new string[]
        {
            " _ ",
            "  |",
            "  |"
        });
        private readonly CharModel _eight = new CharModel(new string[]
        {
            " _ ",
            "|_|",
            "|_|"
        });
        private readonly CharModel _nine = new CharModel(new string[]
        {
            " _ ",
            "|_|",
            " _|"
        });
    }
}
