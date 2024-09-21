using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    private int ingredient = 0;
    private string color = "Red";
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
        character = GameObject.Find("npc");
        screen = GameObject.Find("GameScreen");
        slide_temp = GameObject.Find("Slider");
        milk_button = GameObject.Find("Milk");
        milk = milk_button.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        slide = slide_temp.GetComponent<Slider>();
        slide.value = temp;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
           
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            coffee_ingredients.ingredients[1] = true;
            milk.interactable = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            coffee_ingredients.ingredients[2] = true;
            milk.interactable = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            npc = character.GetComponent<Character>();

            ingredient = coffee_ingredients.Ingredient();
            coffee.Coffee_Color_player(color);
            order = coffee.Coffee(ingredient, color, temp);
            Debug.Log(order);

            bool result = Evaluate();
            if (result == true)
            {

                character_clone = Instantiate(character, screen.transform);
                Destroy(character);
                character = character_clone;
                character.name = "npc";

            }
            else
            {
                

            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            color = "brown";
            coffee.Coffee_Color_player(color);
            temp = temp+10;
            character_clone=Instantiate(character,screen.transform);
            Destroy(character);
            character = character_clone;
            character.name = "npc";

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
