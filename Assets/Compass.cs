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
    public GameObject GhostSkill;
    public GameObject Console;
    public Text console;
    public Button button;
    public Button aimbutton;
    public Button ghostButton;
    public Transform Player;
    public Transform target;
    public RectTransform compass;
    public Quaternion MissionDirection;
    public int distance;
    public int angle;
    private const int maxDistance = 1000;
    public string msgToServer;
    public string aimName;

    void Start()
    {
        JustButton = GameObject.Find("Console");
        console = JustButton.transform.gameObject.GetComponent<Text>();
        if (LogInScript.NickName.achivment == "1")
        {
            TreshFounded("Usual_TRUE");
        }
        Input.compass.enabled = true;
        Input.location.Start();
        console.text = "Zdarova";
        GhostSkill = GameObject.Find("Ghost");
        ghostButton = GhostSkill.transform.gameObject.GetComponent<Button>();
        ghostButton.interactable = false;

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
        
        msgToServer = ServerMessage(LogInScript.NickName.nick + " " + "coord " + Instace.longtitudeP + " " + Instace.lattitudeP);
        //Проверка игрового предмета №1
        TreshFounded(msgToServer);
        //Провера игрового предмета №2
        GhostFounded(msgToServer);
        if (msgToServer != "Usual_TRUE"|| msgToServer != "Ghost_TRUE")
        {
            ParseData(msgToServer);  
        }
    }

    void Update()
    {
        ChangeMissionDirection(angle - Input.compass.magneticHeading/*trueHeading */);
        Fill(distance);
    }
    public void TreshFounded(string s)
    {
        if (s == "Usual_TRUE")
        {
            JustButton = GameObject.Find("Button");
            button = JustButton.transform.gameObject.GetComponent<Button>();
            button.interactable = false;
            AimButton = GameObject.Find("AimButton");
            aimbutton = AimButton.transform.gameObject.GetComponent<Button>();
            aimbutton.interactable = true;
                }
    }
    public void GhostFounded(string s)
    {
        if(s == "Ghost_TRUE")
        {
            GhostSkill = GameObject.Find("Ghost");
            ghostButton = GhostSkill.transform.gameObject.GetComponent<Button>();
            ghostButton.interactable = true;
        }

    }
    public void Ghost()
    {
        msgToServer = ServerMessage(LogInScript.NickName.nick + " " + "Ghost " +"VJUH");
        if(msgToServer == "Вы_успешно_скрыли_свои_координаты ")
        {
            console.text = "Вы успешно скрыли свое местоположение";
        }

    }
    public void Fill(int distance)
    {
        //Максимальная Дистанция 1000 метров 
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
    //Парсинг ответов от сервера
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
        console.text = word[0];
        if (word[0] != "Ваша_цель_скрыла_свои_координаты ")
        {
            console.text = "Текущая цель: " + word[2];
            distance = int.Parse(word[0]);
            angle = int.Parse(word[1]);
        }
        else
        {
            console.text = "Ваша цель скрыла свои координаты";
        }
        
    }

}


