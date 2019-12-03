using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class loginscript : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    private string Username;
    private string Password;
    private string[] Lines;
   

    void LoginButton()
    {
        bool UN = false;
        bool PW = false;
        if (Username != "")
        { // if (System.IO.File.Exists(@"" ZIMBIRTISI olcak bir de))
            UN = true;
        }
        //else {Debug.LogWarning("username incorrect"); } 
        else
        { Debug.LogWarning("Username Field Empty"); }

        if (Password != "")
        {
            PW = true;
        }
        else
        {
            Debug.LogWarning("Password Field Empty");
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (username.GetComponent<InputField>().isFocused)
                {//clicks on the next one basically
                    password.GetComponent<InputField>().Select();
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (Username != "" && Password != "")
                    {
                        LoginButton();
                    }
                }

                Username = username.GetComponent<InputField>().text;
                Password = password.GetComponent<InputField>().text;
            }
        }
    }
}
