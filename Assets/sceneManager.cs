using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    void Update()
    {
        if (FindObjectOfType<zoneScipt>().gameIsDOne ==true )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
    }
}
