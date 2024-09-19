using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private int ingredient = 0;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        character = GameObject.Find("npc");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            coffee_ingredients.ingredients[1] = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            coffee_ingredients.ingredients[2] = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            npc = character.GetComponent<Character>();

            ingredient = coffee_ingredients.Ingredient();
            order = coffee.Coffee(ingredient, color, temp);
            Debug.Log(order);

            bool result = Evaluate();
            if (result == true)
            {

                Instantiate(character);
                Destroy(character);
                character = GameObject.Find("npc(Clone)");
                character.name = "npc";

            }
            else
            {
                

            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(character);
            Destroy(character);
            character = GameObject.Find("npc(Clone)");
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
