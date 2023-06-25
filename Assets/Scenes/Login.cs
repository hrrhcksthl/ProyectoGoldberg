using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
public InputField nameField;
public InputField passwordField;

public Button submitButton;

public void CallLogin(){
    StartCoroutine(LoginPlayer());
}

IEnumerator LoginPlayer(){
 WWWForm form = new WWWForm();
   form.AddField("name", nameField.text);
   form.AddField("password", passwordField.text);
   //WWW www = new WWW("http://localhost/sqlconnect/login.php",form);
   WWW www = new WWW("http://localhost:41062/sqlconnect/login.php", form);
   yield return www;
    if(www.text[0]== '0'){
        DBManager.username = nameField.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
    else{
       Debug.Log("User login failed. Error #"+ www.text ); 
    }
}
public void verifyInputs(){
     submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >=4);
 }

 public void GoToMenu()
   {
       UnityEngine.SceneManagement.SceneManager.LoadScene(0);

   }


}
