using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CofeeType : MonoBehaviour
{
    //Added ingredients ex: milk, sugar, ...
    private string[] coffee_name = { " simple ", " milk "," sweet "," sweet milk " };
    //Color of the coffee ex: green - matcha, ...
    private string[] coffee_type = { "black ","matcha ","strawberry ", "blueberry ","white chocolate ", "special " };
    //Coffee temperature
    private string[] coffee_temp = { " Hot"," Warm"," Cold"," Iced", " Burning" };


    private int nomenclature;
    private int type;
    private int temperature;
    private GameObject coffee_stream;
    private GameObject coffee_mug;
    private GameObject coffee_fill;
    private GameObject coffee_drop;
    private Image drop;
    private Image fill;
    private Slider stream;
    private Slider mug;

    private void Start()
    {
        coffee_stream = GameObject.Find("Coffee_slide");
        coffee_mug = GameObject.Find("Mug_fill");
        stream= coffee_stream.GetComponent<Slider>();
        mug= coffee_mug.GetComponent<Slider>();
        coffee_drop = GameObject.Find("coffee_drop");
        coffee_fill = GameObject.Find("coffee_fill");
        drop= coffee_drop.GetComponent<Image>();
        fill = coffee_fill.GetComponent<Image>();

    }

    public string Coffee(int ingredient, string color, int temp)
    {
        nomenclature = ingredient;
        type=Coffee_Color(color);
        temperature = Coffee_Temperature(temp);

        string coffee_order = coffee_temp[temperature] + coffee_name[nomenclature] + coffee_type[type] + " coffee";

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
    public void Coffee_Color_player(string color)
    {
        if (color == "Red")
        {
            drop.color = new Color(0.9f, 0.6f, 0.6f, 1f);
            fill.color = new Color(0.9f, 0.6f, 0.6f, 1f);
            Drop_fill(stream);
            Drop_fill(mug);
            stream.value = 0f;
        }
        else if (color == "Green")
        {
            drop.color = new Color(0.6f, 0.9f, 0.6f, 1f);
            fill.color = new Color(0.6f, 0.9f, 0.6f, 1f);
            Drop_fill(stream);
            Drop_fill(mug);
            stream.value = 0f;

        }
        else if (color == "Blue")
        {
            drop.color = new Color(0.5f, 0.6f, 0.9f, 1f);
            fill.color = new Color(0.5f, 0.6f, 0.9f, 1f);
            Drop_fill(stream);
            Drop_fill(mug);
            stream.value = 0f;

        }
        else if (color == "Black")
        {
            drop.color = new Color(0.3f, 0.2f, 0.2f, 1f);
            fill.color = new Color(0.3f, 0.2f, 0.2f, 1f);
            Drop_fill(stream);
            Drop_fill(mug);
            stream.value = 0f;

        }
        else if (color == "White")
        {
            drop.color = new Color(0.9f, 0.9f, 0.9f, 1f);
            fill.color = new Color(0.9f, 0.9f, 0.9f, 1f);
            Drop_fill(stream);
            Drop_fill(mug);
            stream.value = 0f;

        }
        else
        {
            drop.color = Color.white;
            fill.color = Color.white;
        }

    }
    private void Drop_fill(Slider s)
    {
        for (float i = 0; i <= 1;)
        {
            s.value = i;
            i = i + 0.01f;
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
