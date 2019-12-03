using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{

    public InputField nameField;
    public InputField passwordField;
    public Button loginbutton;
    readonly string URL = "http://localhost/sqlconnect/register.php";

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        //info sucsesfully geldiyse devam database manager. what is our state right now 
        if (www.text[0]== '0')
        {
            DBManager.username = nameField.text;
            //split info we got back and turn it into an integer
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene(0);
        }

        else
        {
            Debug.Log("user login failed error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        loginbutton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
