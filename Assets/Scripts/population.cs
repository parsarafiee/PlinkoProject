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
    public GameObject buddyPrefab;

    public GameObject finalZonePref;

    private void Awake()
    {
        GameObject backgroundObj = Instantiate(backgroundPrefab, Vector3.zero, Quaternion.identity);
        GameObject rightBuddy = Instantiate(buddyPrefab, new Vector3(backgroundScale.x / 2, 0, 0), Quaternion.identity);
        GameObject leftBuddy = Instantiate(buddyPrefab, new Vector3(-backgroundScale.x / 2, 0, 0), Quaternion.identity);
        backgroundObj.transform.localScale = new Vector3(backgroundScale.x, backgroundScale.y, 0.2f);
        rightBuddy.transform.localScale = new Vector3(0.2f, backgroundScale.y, 0.7f);
        leftBuddy.transform.localScale = new Vector3(0.2f, backgroundScale.y, 0.7f);
        Vector3 spawnLoc = new Vector3(0, backgroundScale.y / 2, -0.3f);
        BallPlayerr player = Instantiate(playerPrefab, spawnLoc, Quaternion.identity).GetComponent<BallPlayerr>();
        mainCam.player = player.transform;


    }
    void Start()
    {
        Vector3 zoneLocation = new Vector3(-((backgroundScale.x/2)-1), -backgroundScale.y / 2, -1);
        int randomZonToWIn = Random.Range(0, (int)backgroundScale.x / 2);
        for (int i = 0; i < (backgroundScale.x/2); i++)
        {    
            GameObject zoneFinal = Instantiate(finalZonePref, zoneLocation, Quaternion.identity);
            zoneLocation.x +=2;
            if (randomZonToWIn==i)
            {
                zoneFinal.GetComponent<MeshRenderer>().material.color = Color.red;
                zoneFinal.tag == "kl";
            }
        }




        for (int i = 0; i < numberOfCylinder; i++)
        {
            Vector3 loc = new Vector3(Random.Range(-((backgroundScale.x / 2)), (backgroundScale.x / 2)), Random.Range(-((backgroundScale.y / 2) - 1f), (backgroundScale.y / 2) - 1f), -0.35f);
            GameObject b = Instantiate(cylinder, loc, Quaternion.Euler(-90f, 0, 0));
            b.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));


        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
