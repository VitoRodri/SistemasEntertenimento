using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour
{
    public Text order;
    public void TextBubble(string n)
    {
        order.text = n;
    }

    
}
