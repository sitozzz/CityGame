using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMenu : MonoBehaviour {
    public Animator slideMenu;
	// Use this for initialization
	void Start () {

        slideMenu.SetBool("isHidden", true);
		
	}
    public void arrowClick()
    {
        if (slideMenu.GetBool("isHidden") == false)
        {
            slideMenu.SetBool("isHidden", true);
        }
        else
        {
            slideMenu.SetBool("isHidden", false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
