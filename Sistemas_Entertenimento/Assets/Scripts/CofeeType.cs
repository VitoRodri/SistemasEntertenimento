using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofeeType : MonoBehaviour
{
    private string[] coffee_name = { "black_coffee", "milk_coffee" };
    private int value;

    public string Coffee(bool milk)
    {
        if (milk == true)
        {
            value = 1;
        }
        else
        {
            value = 0;
        }

        return coffee_name[value];
    }
}
