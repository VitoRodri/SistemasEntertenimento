using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

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
    private GameObject character_clone;
    private GameObject screen;
    private GameObject slide_temp;
    private Slider slide;
    private GameObject milk_button;
    private Button milk;
    // Start is called before the first frame update
    void Start()
    {
        arduino.Open ();
        character = GameObject.Find("npc");
        screen = GameObject.Find("GameScreen");
        slide_temp = GameObject.Find("Slider");
        slide = slide_temp.GetComponent<Slider>();
        milk_button = GameObject.Find("Milk");
        milk= milk_button.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        

        serialmonitor = arduino.ReadLine();
        if (serialmonitor == "Button 2 pressed")
        {
            coffee_ingredients.ingredients[1] = true;
            milk.interactable = false;

        }
        else if (serialmonitor == "Button 1 pressed")
        {
            coffee_ingredients.ingredients[2] = true;
        }
        else if (serialmonitor == "Button 3 pressed")
        {
            milk.interactable = true;
            npc = character.GetComponent<Character>();

            color = arduino.ReadLine();
            ingredient = coffee_ingredients.Ingredient();
            order = coffee.Coffee(ingredient, color, temp);
            Debug.Log(order);

            bool result = Evaluate();
            if (result == true)
            {
                arduino.Write("win");
                character_clone = Instantiate(character, screen.transform);
                Destroy(character);
                character = character_clone;
                character.name = "npc";


            }
            else
            {
                arduino.Write("lose");
                
            }

        }
        else if (int.TryParse(serialmonitor, out temp) == true)
        {
            slide.value = temp;
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
