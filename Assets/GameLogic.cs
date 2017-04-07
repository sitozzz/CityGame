using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

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
        try
            {
            ReassignInputs(GameObject.Find("panelSignup"));
            if (!ValidateLogin(inputLogin.text))
                {
                ChangeInfoPanel("Invalid login");
                return;
                }
            if (!ValidateEmail(inputEmail.text))
                {
                ChangeInfoPanel("Invalid email");
                return;
                }
            if (!ValidatePassword(inputPassword.text))
                {
                ChangeInfoPanel("Invalid password");
                return;
                };
            switch (databaseHandler.CheckIfLoginAndEmailAvalible(inputLogin.text, inputEmail.text))
                {
                case 0:
                    break;
                case 1:
                    ChangeInfoPanel("Login already is use");
                    return;
                case 2:
                    ChangeInfoPanel("Email already is use");
                    return;
                }
            ChangeInfoPanel("Signing up...");
            JSONObject jsonPlayer = new JSONObject();
            jsonPlayer.AddField("login", inputLogin.text);
            jsonPlayer.AddField("email", inputEmail.text);
            jsonPlayer.AddField("password", inputPassword.text);
            JSONObject playersArray = databaseHandler.database["players"];
            playersArray.Add(jsonPlayer);
            databaseHandler.SaveJsonDatabase();
            ChangeInfoPanel("Successfully signed up");
            }
        catch
            {
            ChangeInfoPanel("Error while signing up");
            }

        }

    public void SignIn()
        {
        ReassignInputs(GameObject.Find("panelAuth"));
        if (!ValidateLogin(inputLogin.text))
            {
            ChangeInfoPanel("Invalid login");
            return;
            }
        if (!ValidatePassword(inputPassword.text))
            {
            ChangeInfoPanel("Invalid password");
            return;
            }
        if (databaseHandler.FindPlayerInDb(inputLogin.text, inputPassword.text))
            {
            ChangeInfoPanel("Successfully signed in");
            Invoke("LoadGame", 1);
            }
        else
            {
            ChangeInfoPanel("Wrong combination of login and password");
            }
        }

    void LoadGame()
        {
        SceneManager.LoadScene("playing");
        }

    }
