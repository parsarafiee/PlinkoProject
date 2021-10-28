using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class population : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject cylinder;
    public int numberOfCylinder;
    public Vector3 loc1;
    public Follow mainCam;
    [Space(10)]

    public GameObject backgroundPrefab;
    public Vector2 backgroundScale;
    public GameObject rightAndLeftBoxPref;
    public GameObject bottomBox;

    public GameObject finalZonePref;
    public int howManyZone;

    private void Awake()
    {
        // 
        GameObject backgroundObj = Instantiate(backgroundPrefab, Vector3.zero, Quaternion.identity);
        backgroundObj.transform.localScale = new Vector3(backgroundScale.x, backgroundScale.y, 0.2f);

        // generate right and left edges for the plinko 

        GameObject rightBuddy = Instantiate(rightAndLeftBoxPref, new Vector3(backgroundScale.x / 2, 0, 0), Quaternion.identity);
        GameObject leftBuddy = Instantiate(rightAndLeftBoxPref, new Vector3(-backgroundScale.x / 2, 0, 0), Quaternion.identity);
        // 0.2 for x  and 0.7 for  z  is the best size for the side boxes otherwise it get a bit weird
        rightBuddy.transform.localScale = new Vector3(0.2f, backgroundScale.y, 0.7f);
        leftBuddy.transform.localScale = new Vector3(0.2f, backgroundScale.y, 0.7f);

        // respawn the player on the top of the plinko

        Vector3 respawnPosPlayer = new Vector3(0, backgroundScale.y / 2, -0.3f);
        BallPlayerr player = Instantiate(playerPrefab, respawnPosPlayer, Quaternion.identity).GetComponent<BallPlayerr>();
        mainCam.player = player.transform;

        //   make  Plinko's bottom 

        GameObject bottomEnd = Instantiate(bottomBox, new Vector3(0, (-backgroundScale.y / 2) - 0.5f, -1), Quaternion.identity);
        bottomEnd.transform.localScale = new Vector3(backgroundScale.x, 1, 4);

        //   make the trigger zones randomly on Plinko's bottom 

        Vector3 FirstZoneLocation = new Vector3(-((backgroundScale.x / 2) - 1), -backgroundScale.y / 2, -1);
        Vector3 SecondZoneLocation = new Vector3(((backgroundScale.x / 2) - 1), -backgroundScale.y / 2, -1);

        float DisFir_Sec_loc = Vector3.Distance(FirstZoneLocation, SecondZoneLocation);
        float spaceBetweenZones = DisFir_Sec_loc / (howManyZone - 1);
        int randomZonToWIn = Random.Range(0, (int)backgroundScale.x / 2);

        for (int i = 0; i < howManyZone; i++)
        {
            GameObject zoneFinal = Instantiate(finalZonePref, FirstZoneLocation, Quaternion.identity);
            FirstZoneLocation.x += spaceBetweenZones;
            if (randomZonToWIn == i)
            {   //
                zoneFinal.GetComponent<MeshRenderer>().material.color = Color.red;
                zoneFinal.gameObject.tag = "winZone";
            }
        }

    }
    void Start()
    {




        // random cylander all over the background 
        for (int i = 0; i < numberOfCylinder; i++)
        {
            Vector3 loc = new Vector3(Random.Range(-((backgroundScale.x / 2)), (backgroundScale.x / 2)), Random.Range(-((backgroundScale.y / 2) - 1f), (backgroundScale.y / 2) - 1f), -0.35f);
            GameObject b = Instantiate(cylinder, loc, Quaternion.Euler(-90f, 0, 0));

            // respawn all the cylanders with different random colors 
            b.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));


        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
