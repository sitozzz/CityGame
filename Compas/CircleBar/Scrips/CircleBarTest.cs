// пример использования

using UnityEngine;
using System.Collections;
using System;


public class CircleBarTest : ClientScript {

	void Start () 
	{
		CircleBar.SetDefault(100); 

		CircleBar.SetSettings(100, 50);
        
        //Debug.Log("Текущее значение: " + CircleBar.currentValue);
    }

	void Update()
	{
        //if (answer != "")
        //{


        //    Debug.Log("Hui "+//answer);
        //}
        // int scale = Convert.ToInt32(answer);

        /*   if(scale >= 5000)
           {
               CircleBar.AdjustCurrentValue(0);
           }
           else if(scale < 5000 && scale >= 2000)
           {
               CircleBar.AdjustCurrentValue(10);

           }
           else if (scale < 2000 && scale >= 1000)
           {
               CircleBar.AdjustCurrentValue(20);

           }
           else if (scale < 1000 && scale >= 500)
           {
               CircleBar.AdjustCurrentValue(30);

           }
           else if (scale < 500 && scale >= 250)
           {
               CircleBar.AdjustCurrentValue(40);

           }
           else if (scale < 250 && scale >= 100)
           {
               CircleBar.AdjustCurrentValue(50);

           }
           else if (scale < 100 )
           {
               CircleBar.AdjustCurrentValue(60);

           }
           */
        //CircleBar.AdjustCurrentValue(10);

    }
}
