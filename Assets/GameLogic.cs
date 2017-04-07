using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GameLogic : MonoBehaviour {
    [SerializeField]
    GameObject infoPanel;

    JSONDatabaseHandler databaseHandler;
    InputField inputLogin;
    InputField inputEmail;
    InputField inputPassword;
    GameObject currentPanel;

    Text infoPanelText;
    // Use this for initialization
    void Start () {
		infoPanelText = infoPanel.transform.FindChild("Text").GetComponent<Text>();
        databaseHandler = this.GetComponent<JSONDatabaseHandler>();
        }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeInfoPanel(string text, bool enabled=true)
        {
        infoPanelText.text = text;
        infoPanel.SetActive(enabled);
        }

    public void reassignInputs(GameObject panel)
        {
        currentPanel = panel;
        try { inputLogin = currentPanel.transform.FindChild("panelInputs").FindChild("inputLogin").gameObject.GetComponent<InputField>();  } catch { print("Login input wasn't reassigned"); };
        try { inputEmail = currentPanel.transform.FindChild("panelInputs").FindChild("inputEmail").gameObject.GetComponent<InputField>();  } catch { print("Email input wasn't reassigned"); };
        try { inputPassword = currentPanel.transform.FindChild("panelInputs").FindChild("inputPassword").gameObject.GetComponent<InputField>();  } catch { print("Password input wasn't reassigned"); };

        }
    public bool validateEmail(string email)
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

    public bool validateLogin(string login)
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

    public bool validatePassword(string pswd)
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

    public void signUp()
        {
        try
            {
            reassignInputs(GameObject.Find("panelSignup"));
            if (!validateLogin(inputLogin.text))
                {
                changeInfoPanel("Invalid login");
                return;
                }
            if (!validateEmail(inputEmail.text))
                {
                changeInfoPanel("Invalid email");
                return;
                }
            if (!validatePassword(inputPassword.text))
                {
                changeInfoPanel("Invalid password");
                return;
                };
            switch (databaseHandler.checkIfLoginAndEmailAvalible(inputLogin.text, inputEmail.text))
                {
                case 0:
                    break;
                case 1:
                    changeInfoPanel("Login already is use");
                    return;
                case 2:
                    changeInfoPanel("Email already is use");
                    return;
                }
            changeInfoPanel("Signing up...");
            JSONObject jsonPlayer = new JSONObject();
            jsonPlayer.AddField("login", inputLogin.text);
            jsonPlayer.AddField("email", inputEmail.text);
            jsonPlayer.AddField("password", inputPassword.text);
            JSONObject playersArray = databaseHandler.database["players"];
            playersArray.Add(jsonPlayer);
            databaseHandler.saveJsonDatabase();
            changeInfoPanel("Successfully signed up");
            }
        catch
            {
            changeInfoPanel("Error while signing up");
            }

        }

    public void signIn()
        {
        reassignInputs(GameObject.Find("panelAuth"));
        if (!validateLogin(inputLogin.text))
            {
            changeInfoPanel("Invalid login");
            return;
            }
        if (!validatePassword(inputPassword.text))
            {
            changeInfoPanel("Invalid password");
            return;
            }
        if (databaseHandler.findPlayerInDb(inputLogin.text, inputPassword.text))
            {
            changeInfoPanel("Successfully signed in");
            }
        else
            {
            changeInfoPanel("Wrong combination of login and password");
            }
        }

    }
