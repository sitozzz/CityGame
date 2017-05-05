﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Compass : ClientScript
{
    [SerializeField]
    public GameObject AimButton;
    public GameObject JustButton;
    public Button button;
    public Button aimbutton;
    public Transform Player;
    public Transform target;
    public RectTransform compass;
    public Quaternion MissionDirection;
    public int distance;
    public int angle;
    private const int maxDistance = 10000;
    public string msgToServer;
   
    void Start()
    {
      
    }

    public void FindAim()
    {
        ParseData(ServerMessage("FindAim " + Instace.longtitudeP + " " + Instace.lattitudeP));
        ChangeMissionDirection(angle);
        Fill(distance);
    }

    public void AimFounded()
    {
        msgToServer = ServerMessage("AimFounded");
        if (msgToServer == "true")
        {
            button.enabled = true;
        }
    }
    public void Parsinng()
    {
        //ServerMessage("coord" + " " + longtitudeP + " " + lattitudeP);
        //ParseData(ServerMessage("coord" + " " + longtitudeP + " " + lattitudeP));

        ParseData(ServerMessage("coord " + Instace.longtitudeP + " " + Instace.lattitudeP));
        ChangeMissionDirection(angle);
        Fill(distance);
    }


    public void TreshFounded()
    {
        msgToServer = "true";//ServerMessage("TreshFounded");
        if (msgToServer == "true")
        {
            JustButton = GameObject.Find("Button");
            button = JustButton.transform.gameObject.GetComponent<Button>();
            button.interactable = false;

            AimButton = GameObject.Find("AimButton");
            aimbutton = AimButton.transform.gameObject.GetComponent<Button>();
            aimbutton.interactable = true;
            //button.interactable = false; 
            //  AimButton.SetActive(true);
                }
    }

    public void Fill(int distance)
    {
        //Максимальная Дистанция 10000 метров 
        if (distance > maxDistance)
        {
            distance = maxDistance;
        }
        Filling.SetSettings(maxDistance, maxDistance - distance);
    }

    public void ChangeMissionDirection(int angle)
    {
        compass.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ParseData(string distanceAndAngle)
    {
        int space = distanceAndAngle.IndexOf(" ");
        if (space == -1) { throw new System.Exception("Строка не содержит пробела"); }
        distance = int.Parse(distanceAndAngle.Substring(0, space));
        angle = int.Parse(distanceAndAngle.Substring(space + 1, distanceAndAngle.Length - (space + 1)));
        //Debug.Log(distance + " " + angle);
    }

}



/*Filling.SetSettings(100, 50); // кроме макс. значения, так же указываем текущее, это полезно когда настройки загружаются
Filling.SetDefault(10); // по умолчанию, нужно указать только макс. возможное значение
Debug.Log("Текущее значение: " + Filling.currentValue);*/

/*Vector3 dir = target.position;
        MissionDirection = Quaternion.LookRotation(dir);
        MissionDirection.z = -MissionDirection.y;
        MissionDirection.x = 0;//Блок поворота по x
        MissionDirection.y = 0;//Блок поворота по y
        compass.localRotation = MissionDirection;*/

/*// прибавить или убавить
   if (Input.GetMouseButtonDown(0))
   {
       Filling.AdjustCurrentValue(10);
   }
   else if (Input.GetMouseButtonDown(1))
   {
       Filling.AdjustCurrentValue(-10);
   }*/




