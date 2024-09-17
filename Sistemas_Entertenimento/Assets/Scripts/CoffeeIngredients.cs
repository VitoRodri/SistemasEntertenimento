using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CoffeeIngredients : MonoBehaviour
{
    public Collection<bool> ingredients = new Collection<bool>();

    private void Start()
    {
        ingredients.Add(false); //dark
        ingredients.Add(false); //milk
        ingredients.Add(false); //sugar
        ingredients.Add(false); //milk+sugar
    }

    public int Ingredient()
    {
        if (ingredients[1] & ingredients[2])
        {
            ingredients[3] = true;
            ingredients[1] = false;
            ingredients[2] = false;
        }

        for (int i=0; i < ingredients.Count; i++)
        {
            if (ingredients[i] == true)
            {
                ingredients[i] = false;
                return i;
            }
            
        }
        return 0;
    }
}
