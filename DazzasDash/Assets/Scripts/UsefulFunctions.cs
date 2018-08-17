using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulFunctions : MonoBehaviour
{

    public static string SetDollaryDooText(int amount)
    {
        string dollaryDooString;

        if (amount < 10)
        {
            dollaryDooString = "0000" + amount.ToString();
        }
        else if (amount < 100 && amount > 10)
        {
            dollaryDooString = "000" + amount.ToString();
        }
        else if (amount < 1000 && amount > 100)
        {
            dollaryDooString = "00" + amount.ToString();
        }
        else if (amount < 10000 && amount > 1000)
        {
            dollaryDooString = "0" + amount.ToString();
        }
        else
        {
            dollaryDooString = amount.ToString();
        }

        return dollaryDooString;
    }
}
