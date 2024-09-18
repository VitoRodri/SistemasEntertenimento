using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{

    SerialPort arduino = new SerialPort("COM4", 9600);
    public string serialmonitor;
    private int ingredient=0;
    private string color = "brown";
    private int temp = 0;
    public CofeeType coffee;
    public CoffeeIngredients coffee_ingredients;
    // Start is called before the first frame update
    void Start()
    {
        arduino.Open ();

    }

    // Update is called once per frame
    void Update()
    {
        serialmonitor = arduino.ReadLine();

        if (serialmonitor == "Button 2 pressed")
        {
            coffee_ingredients.ingredients[1] = true;


        }
        else if (serialmonitor == "Button 1 pressed")
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else if (serialmonitor == "Button 3 pressed")
        {
            new WaitForSecondsRealtime(6);
            color = arduino.ReadLine();
            ingredient = coffee_ingredients.Ingredient();
            Debug.Log(coffee.Coffee(ingredient, color, temp));

        }
        else if (int.TryParse(serialmonitor, out temp) == true)
        {
            Debug.Log(temp);
        }
        
    }
}
