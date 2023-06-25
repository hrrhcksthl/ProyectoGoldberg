using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public Text playerDisplay;
    private void start(){
    if(DBManager.LoggedIn){
        playerDisplay.text = "Player:  "+ DBManager.username;
    }
    }
   public void GoToRegister()
   {
       SceneManager.LoadScene(1);

   }

    public void GoToLogin()
   {
       SceneManager.LoadScene(2);

   }

    public void GoToChatBot()
    {
        SceneManager.LoadScene(7);
    }
    public void GoToGolverg()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToBoliche()
    {
        SceneManager.LoadScene(6);
    }
  
}
