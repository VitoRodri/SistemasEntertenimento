using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private CofeeType coffee;
    private GameObject SceneManager;
    public Speech text;
    private string color;
    private string[] colours = { "Black", "Green", "Red", "Blue", "White" };
    private string[] greet= {"Hi There! A","Just a", ""};
    private string[] bye={".",", please",", thanks"};
    public string coffee_order;
    private Image image;
    void Start()
    {
        SceneManager=GameObject.Find("SceneManager");
        coffee = SceneManager.GetComponent<CofeeType>();
        image=GetComponentInChildren<Image>();
        
        
        int number_image = Random.Range(1, 4);
        int number_name = Random.Range(0, 4);
        int number_type = Random.Range(0, 5);
        int number_temp = Random.Range(1, 100);
        int number_greet = Random.Range(0, 3);
        int number_bye = Random.Range(0, 3);
        image.sprite = Picture(number_image);
        color = colours[number_type];
        coffee_order = coffee.Coffee(number_name,color,number_temp);
        text.TextBubble(greet[number_greet]+coffee_order+bye[number_bye]);
        Debug.Log(coffee_order);
        
        
    }
    public string Order()
    {
        return coffee_order;
    }

    private Sprite Picture(int n)
    {
        return Resources.Load<Sprite>("Images/Criatures/Blop_"+n);
    }
}
