using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_Enterprise
{
    public partial class Method
    {

        public static bool inputControl(string tbText)
        {
            bool result = false;
            bool o = false;
            if (string.IsNullOrEmpty(tbText))
                result = false;
            else
                o = int.TryParse(tbText, out int NumerickValue);
            if (o.Equals(false))
                result = false;
            else
                if (int.Parse(tbText) > 0 && int.Parse(tbText) <= 150)
                result = true;

            return result;
        }
        public static bool MinMax(string Text)
        {
            bool result = false;
            int tbText = 0;
            try
            {
                tbText = int.Parse(Text);
               
            }
            catch (Exception)
            {

                return result;
            }
           
            if (tbText>=1 && tbText <=150)
            {
                result = true;
            }
            return result;
        }
    }
}
