using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{

    SerialPort arduino = new SerialPort("COM4", 9600);
    public string serialmonitor;
    // Start is called before the first frame update
    void Start()
    {
        arduino.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        serialmonitor = arduino.ReadLine();
        if(serialmonitor=="Button 2 pressed")
        {
            Application.Quit();
        }
    }
}
