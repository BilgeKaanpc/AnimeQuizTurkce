using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class menuControl : MonoBehaviour


{

   
    
    

    

    public void oyna()
    {

        SceneManager.LoadScene(1);
    }

   
   

    public void quit()
    {
        Application.Quit();
    }
}
