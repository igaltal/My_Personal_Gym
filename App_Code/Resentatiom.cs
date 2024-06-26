using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


/// <summary>
/// Summary description for Resentatiom
/// </summary>
public static class Resentatiom
{

    public static bool CheckName(string name)
    {
        
        bool check = true;
        if (name.Length < 2)
            check = false;
        else
        {
            if (name.Any(char.IsDigit))
            check = false;
        }
        return check;
  
    }
    public static bool CheckID(string id)
    {

        if (id.Length == 9 && id.All(char.IsDigit) && israelID(id)==true)
            return true;
        else
            return false;
    }


    static bool israelID(string strID)
    {
        int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
        int count = 0;

        if (strID == null)
            return false;

        strID = strID.PadLeft(9, '0');

        for (int i = 0; i < 9; i++)
        {
            int num = int.Parse(strID.Substring(i, 1)) * id_12_digits[i];

            if (num > 9)
                num = (num / 10) + (num % 10);

            count += num;
        }

        return (count % 10 == 0);
    }

    public static int CheckPassword(string pass, string pass2)
    {

        if (pass.Length == pass2.Length)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] != pass2[i])
                {
                    return 3;
                }

            }
            return 1;
        }
        else
            return 0;
    }
    public static bool CheckPhone(string number)
    {

        if ( number.All(char.IsDigit) && number.Length==7)
        return true;

        else
            return false;
    }


    public static bool CheckCorrect(string name)
    {

        int count = 0;
        string b = "!@#$%^&*().,/+-='";
        for (int i = 0; i < name.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                if (b[j] == name[i])
                {
                    count++;
                }

            }

        }
        if (count > 0)
            return false;
        return true;

    }



}

