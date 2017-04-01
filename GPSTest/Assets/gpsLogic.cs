using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class gpsLogic : MonoBehaviour {

    [SerializeField]
    public logicScript logicScript;
    float lastLatitude;
    float lastLongitude;
    int locationChangedTimes = -1;
    int updates = 0;
    // Update is called once per frame
    void Update () {
        
       
        }

    IEnumerator Start()
        {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;


        logicScript.PrintToConsole("Starting");
        // Start service before querying location
        Input.location.Start(0.5f);

        // Wait until service initializes
        int maxWait = 20;
        logicScript.PrintToConsole("Wait init");
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
            yield return new WaitForSeconds(1);
            maxWait--;
            }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
            {
            print("Timed out");
            logicScript.PrintToConsole("Time out");
            yield break;
            }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
            {
            print("Unable to determine device location");
            logicScript.PrintToConsole("Unable to determine device location");
            yield break;
            }
        else
            {
            // Access granted and location value could be retrieved
            }
        InvokeRepeating("updateCoords", 1f, 1f);
        // Stop service if there is no need to query location updates continuously
        }
    void updateCoords()
        {
        updates++;
        logicScript.ClearConsole();
        if (lastLatitude != Input.location.lastData.latitude || lastLongitude != Input.location.lastData.longitude)
            {
            locationChangedTimes += 1;
            }
        lastLatitude = Input.location.lastData.latitude;
        lastLongitude = Input.location.lastData.longitude;
        logicScript.PrintToConsole("Updates: " + updates + "\nStatus: " + Input.location.status + "\nLocation: " + Input.location.lastData.latitude + "\nLongitude: " + Input.location.lastData.longitude + "\nAltitude: " + Input.location.lastData.altitude + "\nAccuracy: " + Input.location.lastData.horizontalAccuracy + "\nLocChanged: " + locationChangedTimes.ToString());
        }
    
    }
