using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneScipt : MonoBehaviour
{
    [HideInInspector]public bool gameIsDOne = false;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "LoseZone")
        {
            FindObjectOfType<AudioManager>().Play("Playlose");
            gameIsDOne = true;
        }
        if (this.gameObject.tag == "winZone")
        {
            FindObjectOfType<AudioManager>().Play("PlayWin");
            gameIsDOne = true;
        }
    }
}
