using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBGhadgev1
{
    class amounInWord
    {
        //double n;
        int i,i2;

        public static string mk_Currancy(string s)
        {
            decimal d = 0;
            decimal.TryParse(s, out d);
            if (d == 0)
            { return s; }
            s = decimal.Round(d, 2).ToString();
            int ij = s.IndexOf('.');
            if (ij == -1)
            { s += ".00"; return s; }
            if (s.Length - ij == 2)
            { s += "0"; return s; }
            if (s.Length - ij > 3)
            { s = s.Substring(0, ij + 3); }

            string s2 = "",temp="";
            int lencount = 0;
            for (int i = s.Length - 1; i >= 0;i-- )
            {   
            if (lencount == 6)
            {
                if (s.Length > 7)
                {
                    s2 = "," + temp + s2;
                    temp = "";
                }

            }
                
                if (lencount == 8)
            {
                
                    s2 = "," + temp + s2;
                    temp = "";
               

            }
            if (lencount == 10)
            {
                s2 = "," + temp + s2;
                temp = "";
            }
            if (lencount == 12)
            {
                s2= "," + temp + s2;
                temp = "";
            }
            temp = s[i].ToString() + temp;
            lencount++;
            }
            s2 =  temp + s2;
            return s2;
        }


        public  void splitAmount(double n)
        {
            String s = Convert.ToString(n);
            int p = s.IndexOf('.');
              string s1=n.ToString();
            if (p != -1) {
                s1= s.Substring(0,p );
               string s2 = s.Substring(p + 1);
               if (s2.Length == 1)
               {
                   i2 = Convert.ToInt32(s2);
                   i2 = i2 * 10;
               }
               else { i2 = Convert.ToInt32(s2); }
              
            }
          
            i = Convert.ToInt32(s1);

           

            

            

        }

        public string unitplace(int n)
        {
            int m;
            m = n % 10;
            switch (m)
            { 
                case 1:
                    return " One";
                    
                    
                case 2:
                    return " Two";
                    

                case 3:
                    return " Three";
                    

                case 4:
                    return " Four";
                    
                case 5:
                    return " Five";
                    
                case 6:
                    return " Six";
                   
                case 7:
                    return " Seven";
                   
                case 8:
                    return " Eight";
                    
                case 9:
                    return " Nine";
              
              }
            return "";
        }

        public string tensplace(int n)
        {
            //int m = n % 100;
            if (n / 10 == 0)
            {
             return   " "+unitplace(n);
            }
            switch (n)
            { 
                case 11:
                    return " Eleven";
                    
                case 12:
                    return " Twelve";
                   
                case 13:
                    return " Thirteen";
                 
                case 14:
                    return " Fourteen";
                  
                case 15:
                    return " Fifteen";
                   
                case 16:

                    return " Sixteen";
                  
                case 17:
                    return " Seventeen";
                   
                case 18:

                    return " Eighteen";
                   
                case 19:

                    return " Nineteen";
                  
                case 10:

                    return " Ten";
                case 20:
                    return " Twenty";
                case 30:
                    return " Thirty";

                case 40:
                    return " Fourty";
                case 50:
                    return " Fifty";
                case 60:
                    return " Sixty";
                case 70:
                    return " Seventy";
                case 80:
                    return " Eighty";
                case 90:
                    return " Ninety";

                default:

                    return tensplace((n / 10) * 10) +
                      unitplace(n % 10);
                    
            }
           
         
        }

        String Final = "";
        public string AmtToword(int n)
        {
            //n = i;
            int x = n / 10000000;
            if (x !=0)
            {
                if (x.ToString().Length > 2)
                {
                    AmtToword(x);

                }
                else 
                {
                    Final += tensplace(x);

                    Final += " crore";
                    AmtToword(n%10000000);
                    return Final;
                }
            }
                x = n / 100000;

                if (x != 0)
                {
                    if (x.ToString().Length > 2)
                    {
                        AmtToword(x);

                    }
                    else
                    {
                        Final += tensplace(x);

                        Final += " Lakh";
                        AmtToword(n % 100000);
                        return Final;
                    }
                }
                x = n / 1000;
                if (x != 0)
                {
                    if (x.ToString().Length > 2)
                    {
                        AmtToword(x);

                    }
                    else
                    {
                        Final += tensplace(x);

                        Final += " Thousand";
                        AmtToword(n % 1000);
                        return Final;
                    }
                }
                x = n / 100;
                if (x != 0)
                {
                    if (x.ToString().Length > 2)
                    {
                        AmtToword(x);

                    }
                    else
                    {
                        Final += tensplace(x);

                        Final += " Hundred";
                        AmtToword(n % 100);
                        return Final;
                    }
                }
                Final += tensplace(n);
                return Final;
            
        }

        public string Toword( double  Amount)
        {
            splitAmount(Amount);
            AmtToword(i);
            Final += @" Rupees &";
            //if (i2 < 10)
            //{ i2 = i2 * 10; }
            Final += tensplace(i2);

            Final += " Paise Only";

            return Final;

        }

    }
}
