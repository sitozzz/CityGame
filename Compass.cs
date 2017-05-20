using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Compass : ClientScript
{
    [SerializeField]
    public GameObject AimButton;
    public GameObject JustButton;
    public GameObject Console;
    public Text console;
    public Button button;
    public Button aimbutton;
    public Transform Player;
    public Transform target;
    public RectTransform compass;
    public Quaternion MissionDirection;
    public int distance;
    public int angle;
   // public string nickN;
    private const int maxDistance = 10000;
    public string msgToServer;
    public string aimName;

    void Start()
    {
        JustButton = GameObject.Find("Console");
        console = JustButton.transform.gameObject.GetComponent<Text>();
        //console.text = "HOBA NA";
        // GiveNickName();
        //nickN =  LogInScript.NickName.nick;
        if (LogInScript.NickName.achivment == "1")
        {
            TreshFounded("1");
        }
        Input.compass.enabled = true;
        Input.location.Start();
        
    }
    
    
    public void FindAim()
    {
        ParseData(ServerMessage(LogInScript.NickName.nick + " FindAim " + Instace.longtitudeP + " " + Instace.lattitudeP));
        ChangeMissionDirection(angle + Input.compass.trueHeading );
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
        msgToServer = ServerMessage(LogInScript.NickName.nick + " " + "coord " + Instace.longtitudeP + " " + Instace.lattitudeP);

        TreshFounded(msgToServer);
        if (msgToServer != "1")
        {
            ParseData(msgToServer);
           // Fill(distance);
           // ChangeMissionDirection(angle + Input.compass.trueHeading);
        }
       
    }

    void Update()
    {
        ChangeMissionDirection(angle - Input.compass.magneticHeading/*trueHeading */);
        Fill(distance);
        
        
    }
    public void TreshFounded(string s)
    {
       
        if (s == "1")
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

    public void ChangeMissionDirection(float angle)
    {
        compass.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ParseData(string distanceAndAngle)
    {
        var word = new List<String>();
        int pos = 0;
        int start = 0;
        do
        {
            pos = distanceAndAngle.IndexOf(' ', start);
            if (pos >= 0)
            {
                word.Add(distanceAndAngle.Substring(start, pos - start).Trim());
                start = pos + 1;
            }
            } while (pos > 0) ;
  
        console.text = "Текущая цель: " + word[2];
        distance = int.Parse(word[0]);
        angle = int.Parse(word[1]);
        
    }

}


