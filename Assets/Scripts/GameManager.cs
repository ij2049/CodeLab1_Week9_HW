using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LocationScriptableObject currentLocation;
    
    public Text locationNameText;
    public Text locationDescription;

    public GameObject buttonNorth;
    public GameObject buttonSouth;
    public GameObject buttonWest;
    public GameObject buttonEast;
    
    void Start()
    {
        UpdateLocation();
    }

    public void MoveDirection(int dir)
    {
        switch (dir)
        {
            case 0:
                currentLocation = currentLocation.locationNorth;
                break;
            case 1:
                currentLocation = currentLocation.locationSouth;
                break;
            case 2:
                currentLocation = currentLocation.locationWest;
                break;
            case 3:
                currentLocation = currentLocation.locationEast;
                break;
                
        }

        UpdateLocation();
    }

    private void UpdateLocation()
    {
        locationNameText.text = currentLocation.locationName;
        locationDescription.text = currentLocation.description;

        if (currentLocation.locationEast == null)
        {
            buttonEast.SetActive(false);
        }
        else
        {
            currentLocation.locationEast.locationWest = currentLocation;
            buttonEast.SetActive(true);
        }

        if (currentLocation.locationNorth == null)
        {
            buttonNorth.SetActive(false);
        }
        else
        {
            currentLocation.locationNorth.locationSouth = currentLocation;
            buttonNorth.SetActive(true);
        }
        
        if (currentLocation.locationSouth == null)
        {
            buttonSouth.SetActive(false);
        }
        else
        {
            currentLocation.locationSouth.locationNorth = currentLocation;
            buttonSouth.SetActive(true);
        }
        
        if (currentLocation.locationWest == null)
        {
            buttonWest.SetActive(false);
        }
        else
        {
            currentLocation.locationWest.locationEast = currentLocation;
            buttonWest.SetActive(true);
        }
        
        
    }
}
