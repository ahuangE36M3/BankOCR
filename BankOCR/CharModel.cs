using System.Runtime.CompilerServices;

namespace BankOCR
{
    public class CharModel
    {
        //private int number;
        private string[] displayNumber;

        //public CharModel(int num, string[] display)
        public CharModel(string[] display)
        {
            //number = num;
            displayNumber = display;
        }

        public override string ToString()
        {
            string str = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                str+=displayNumber[i];
                
                if (i < 3)
                {
                    str += "\n";
                }
            }

            return str;
        }

        public static bool operator == (CharModel obj1, CharModel obj2)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!obj1.displayNumber[i].Equals(obj2.displayNumber[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator != (CharModel obj1, CharModel obj2)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!obj1.displayNumber[i].Equals(obj2.displayNumber[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var item = obj as CharModel;

            if (item == null)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                if (!this.displayNumber[i].Equals(item.displayNumber[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DiffByOneStroke(object obj)
        {
            int diffCount = 0;
            var item = obj as CharModel;

            if (item == null)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                if (!this.displayNumber[i].Equals(item.displayNumber[i]))
                {
                    diffCount++;
                    if (diffCount >= 2)
                    {
                        return false;
                    }
                }
            }

            if (diffCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}