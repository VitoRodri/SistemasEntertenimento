using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofeeType : MonoBehaviour
{
    //Added ingredients ex: milk, sugar, ...
    private string[] coffee_name = { " dark ", "milk","sweet","sweet_milk" };
    //Color of the coffee ex: green - matcha, ...
    private string[] coffee_type = { " beans ","matcha","strawberries", "blueberry","white_chocolate", "special" };
    //Coffee temperature
    private string[] coffee_temp = { " hot ","medium","cold","iced", "evaporated" };


    private int nomenclature;
    private int type;
    private int temperature;


    public string Coffee(int ingredient, string color, int temp)
    {
        nomenclature = ingredient;
        type=Coffee_Color(color);
        temperature = Coffee_Temperature(temp);

        string coffee_order = coffee_name[nomenclature] + coffee_type[type] + coffee_temp[temperature];

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
            return 3;
        }
        else if (color == "Black")
        {
            return 0;
        }
        else if (color == "White")
        {
            return 4;
        }
        else
        {
            return 5;
        }
        
    }

    private int Coffee_Temperature(int temp)
    {
        if (temp<=20)
        {
            return 3;
        }
        else if (temp>20 & temp <=40)
        {
            return 2;
        }
        else if (temp>40 & temp <= 60)
        {
            return 1;
        }
        else if (temp>60 & temp <= 80)
        {
            return 0;
        }
        else
        {
            return 4;
        }
        
    }
}
