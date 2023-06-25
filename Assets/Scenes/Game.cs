using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{

    public Text playerDisplay;
   private void Awake(){
       if(DBManager.username == null){
           UnityEngine.SceneManagement.SceneManager.LoadScene(0);
       }
       playerDisplay.text = "Player: "+ DBManager.username;

   }

 
   public void GoToMenuGame()
   {
       UnityEngine.SceneManagement.SceneManager.LoadScene(4);

   }
    
    
}
