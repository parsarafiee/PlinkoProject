using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneScipt : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "LoseZone")
        {
            FindObjectOfType<AudioManager>().Play("Playlose");

        }
        if (this.gameObject.tag == "winZone")
        {
            FindObjectOfType<AudioManager>().Play("PlayWin");

        }
    }
}
