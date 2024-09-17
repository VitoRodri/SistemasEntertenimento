using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{

    SerialPort arduino = new SerialPort("COM4", 9600);
    public string serialmonitor;
    private bool milk=false;
    public CofeeType coffee;
    // Start is called before the first frame update
    void Start()
    {
        arduino.Open ();

    }

    // Update is called once per frame
    void Update()
    {
        serialmonitor = arduino.ReadLine();
        arduino.ReadTimeout = 15;
        if (serialmonitor=="Button 2 pressed")
        {
            arduino.Write("2");
            milk = true;
            
        }
        else if (serialmonitor=="Button 1 pressed")
        {
            UnityEditor.EditorApplication.isPlaying = false;
        } 
        else if (serialmonitor=="Button 3 pressed")
        {
            Debug.Log(coffee.Coffee(milk));
            milk = false;
        }
    }
}
