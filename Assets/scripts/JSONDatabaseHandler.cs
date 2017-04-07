using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class JSONDatabaseHandler : MonoBehaviour {
    InputField inputLogin;
    InputField inputEmail;
    InputField inputPassword;
    GameObject currentPanel;
    GameLogic gameLogic;

    public JSONObject database;
    string databasePath;

    // Use this for initialization
    void Start () {
        databasePath = Application.dataPath + "/" + "database.json";

        gameLogic = GameObject.Find("GameSystem").GetComponent<GameLogic>();
        if (database = InitJsonDatabase())
            {
            print("Database loaded successfully");
            }
        else
            {
            print("Unable to load database");
            }


        }
	
	// Update is called once per frame
	void Update () {
	 
	}

    JSONObject InitJsonDatabase()
    {
        try
        {
            StreamReader sr = new StreamReader(databasePath);
            string strFromFile = sr.ReadToEnd();
            sr.Close();
            JSONObject jsonObject = new JSONObject(strFromFile);
            return jsonObject;
        }
        catch 
        {
            return null;
        }
    }

    public bool SaveJsonDatabase()
        {
        try
            {
            StreamWriter sw = new StreamWriter(databasePath);
            sw.Write(database.ToString());
            sw.Close();
            return true;
            }
        catch
            {
            return false;
            }
        
        }

    public int CheckIfLoginAndEmailAvalible(string login, string email)
        {
        foreach (JSONObject player in database["players"].list)
            {
            if (player.GetField("login").str == login)
                {
                return 1;
                }
            if (player.GetField("email").str == email)
                {
                return 2;
                }
            }
        return 0;
        }
   
    public bool FindPlayerInDb(string login, string pswd)
        {
        foreach (JSONObject player in database["players"].list)
            {
            if (player.GetField("login").str == login && player.GetField("password").str == pswd)
                {
                print("Player found!");
                return true;
                }
            }
        return false;
        }

    


}
