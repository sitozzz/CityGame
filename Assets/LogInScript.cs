using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class LogInScript : ClientScript {
    [SerializeField]
    GameObject infoPanel;

    JSONDatabaseHandler databaseHandler;
    InputField inputLogin;
    InputField inputEmail;
    InputField inputPassword;
    GameObject currentPanel;
    Text infoPanelText;
    public string answServer;
    // Use this for initialization
    void Start () {
		infoPanelText = infoPanel.transform.FindChild("Text").GetComponent<Text>();
       
        }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeInfoPanel(string text, bool enabled=true)
        {
        infoPanelText.text = text;
        infoPanel.SetActive(enabled);
        }

    public void ReassignInputs(GameObject panel)
        {
        currentPanel = panel;
        try { inputLogin = currentPanel.transform.FindChild("panelInputs").FindChild("inputLogin").gameObject.GetComponent<InputField>();  } catch { print("Login input wasn't reassigned"); };
        try { inputEmail = currentPanel.transform.FindChild("panelInputs").FindChild("inputEmail").gameObject.GetComponent<InputField>();  } catch { print("Email input wasn't reassigned"); };
        try { inputPassword = currentPanel.transform.FindChild("panelInputs").FindChild("inputPassword").gameObject.GetComponent<InputField>();  } catch { print("Password input wasn't reassigned"); };

        }
    public bool ValidateEmail(string email)
        {
        int indexAt = email.IndexOf("@");
        if (indexAt == 0 || indexAt == email.Length - 1 || indexAt == -1)
            {
            return false;
            }
        string dEmail = email.Substring(indexAt + 1);
        int indexDot = dEmail.IndexOf(".");
        if (indexDot == 0 || indexDot == dEmail.Length - 1 || indexDot == -1)
            {
            return false;
            }
        print("Email validation succeed+ " + email);
        return true;
        }

    public bool ValidateLogin(string login)
        {
        Regex rx = new Regex(@"^[a-zA-Z0-9]{6,20}$");
        MatchCollection matches = rx.Matches(login);
        if (matches.Count == 0)
            {
            return false;
            }
        print("Login validation succeed+ " + login);
        return true;
        }

    public bool ValidatePassword(string pswd)
        {
        Regex rx = new Regex(@"^[a-zA-Z0-9]{6,20}$");
        MatchCollection matches = rx.Matches(pswd);
        if (matches.Count == 0)
            {
            return false;
            }
        print("Password validation succeed+ " + pswd);
        return true;
        }

    public void SignUp()
        {
       
            ReassignInputs(GameObject.Find("panelSignup"));
            answServer = ServerMessage("regist" + " " + inputEmail.text + " " + inputLogin.text + " " + inputPassword.text);
            if (answServer == "True") { ReassignInputs(GameObject.Find("panelAuth")); }
            else { ChangeInfoPanel("Такой пользователь уже есть"); }

        }

    public void SignIn()
        {
            ReassignInputs(GameObject.Find("panelAuth"));
            answServer = ServerMessage("login" + " " + inputLogin.text + " " + inputPassword.text);
            Debug.Log(answServer);
        if (answServer == "True") { LoadGame(); }

        else if (answServer == "False") { Debug.Log(answServer); ChangeInfoPanel("Вас нету в базе данных"); }
        else if(answServer =="GI") { Debug.Log(answServer); ChangeInfoPanel("GI"); }
        
        }

    void LoadGame()
        {
        SceneManager.LoadScene("playing v2");
        }

    }
