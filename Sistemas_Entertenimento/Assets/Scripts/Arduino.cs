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
    private string order;
    public CofeeType coffee;
    public CoffeeIngredients coffee_ingredients;
    private Character npc;
    private GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        arduino.Open ();
        character = GameObject.Find("npc");
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
            coffee_ingredients.ingredients[2] = true;
        }
        else if (serialmonitor == "Button 3 pressed")
        {
            
            npc = character.GetComponent<Character>();

            color = arduino.ReadLine();
            ingredient = coffee_ingredients.Ingredient();
            order = coffee.Coffee(ingredient, color, temp);
            Debug.Log(order);

            bool result = Evaluate();
            if (result == true)
            {
                arduino.Write("win");
                Instantiate(character);
                Destroy(character);
                character = GameObject.Find("npc(Clone)");
                character.name = "npc";


            }
            else
            {
                arduino.Write("lose");
                
            }

        }
        else if (int.TryParse(serialmonitor, out temp) == true)
        {
            Debug.Log(temp);
        }
        
    }

    private bool Evaluate()
    {
        if (order == npc.coffee_order)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
