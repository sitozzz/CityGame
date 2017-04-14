using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleSript : ClientScript{
    public Text Console;

    // Use this for initialization
   
    void Start () {
        
        

    }
     void Update()
    {
        Console.text = SendMessageFromSocket();

    }
   
    
}
