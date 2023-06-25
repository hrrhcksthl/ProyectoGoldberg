using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour{
public InputField nameField;
public InputField passwordField;

public Button submitButton;

public void CallRegister(){
    StartCoroutine(Register());
}
 IEnumerator Register(){
   WWWForm form = new WWWForm();
   form.AddField("name", nameField.text);
   form.AddField("password", passwordField.text);
   //WWW www = new WWW("http://localhost/sqlconnect/register.php",form);
   WWW www = new WWW("http://localhost:41062/sqlconnect/register.php", form);
   yield return www; 
   if(www.text == "0"){
       Debug.Log("User Created Successfully.");
       UnityEngine.SceneManagement.SceneManager.LoadScene(0);
   }
   else 
   {
       Debug.Log("User creation failed. Error #"+ www.text);
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
