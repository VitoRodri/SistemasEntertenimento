using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofeeType : MonoBehaviour
{
    //Added ingredients ex: milk, sugar, ...
    private string[] coffee_name = { "dark", "milk","sweet","sweet_milk" };
    //Color of the coffee ex: green - matcha, ...
    private string[] coffee_type = { "coffee_beans","matcha","strawberries" };
    //Coffee temperature
    private string[] coffee_temp = { "hot","medium","cold","iced" };


    private int nomenclature;
    private int type;
    private int temp=0;


    public string Coffee(int ingredient, string color)
    {
        nomenclature = ingredient;
        type=Coffee_Color(color);

        string coffee_order = coffee_name[nomenclature] + coffee_type[type] + coffee_temp[temp];

        return coffee_order;
    }

    private int Coffee_Color(string color)
    {
        if (color == "Red")
        {
            return 2;
        }
        else if (color == "Green")
        {
            return 1;
        }
        else if (color == "Blue")
        {
            return 0;
        }
        else
        {
            return 0;
        }
        
    }
}
