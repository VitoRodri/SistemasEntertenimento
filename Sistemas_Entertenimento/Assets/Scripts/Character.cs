using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CofeeType coffee;
    private GameObject SceneManager;
    private string color;
    private string[] colours = { "Black", "Green", "Red", "Blue", "White" };
    public string coffee_order;
    void Start()
    {
        SceneManager=GameObject.Find("SceneManager");
        coffee = SceneManager.GetComponent<CofeeType>();
        int number_name = Random.Range(0, 3);
        int number_type = Random.Range(0,4);
        int number_temp = Random.Range(1, 100);
        color = colours[number_type];
        coffee_order = coffee.Coffee(number_name,color,number_temp);
        Debug.Log(coffee_order);
    }
}
