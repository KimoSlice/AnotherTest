
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlateManager2 : MonoBehaviour
{

    public static PlateManager2 instance;
    [SerializeField]
    int totalCorrectPlacementsNeed; //This is the total number of boxes that needs to be placed correctly before the door will open.
    [SerializeField]
    int currentCorrectPlacements; //Current number of boxes that are placed on the correct pad
    [SerializeField]
    int placements = 0; //This is overall attempted placements. This increments everytime a box is placed on a pad

    public List<GameObject> pads;
    //public List<GameObject> boxes;
    //public List<GameObject> differentType;

    public Text canvasText;

    public UnityEvent completeEvent; //The event you want to call when all boxes are placed. This can be anything. 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalCorrectPlacementsNeed = pads.Count; //Set the total number of correct placements needed to be the number of pads in the pads list. 
        currentCorrectPlacements = 0; //Start off with 0 correct placements
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Increase the number of attempted placements
    /// </summary>
    public void IncreasePlacement()
    {
        placements++;

        if (placements == totalCorrectPlacementsNeed) //Update the UI board
        {
            canvasText.text = currentCorrectPlacements.ToString();
        }
    }

    /// <summary>
    /// Decrease the number of attempted placements
    /// </summary>
    public void DecreasePlacement()
    {
        placements--;
    }

    /// <summary>
    /// Increase the number of CORRECT placements
    /// </summary>
    public void IncreaseCorrectPlacements()
    {
        currentCorrectPlacements++;

        if (currentCorrectPlacements == totalCorrectPlacementsNeed)
        {
            Debug.Log("ALL BOXES PLACED CORRECTLY");
            completeEvent.Invoke();
        }
    }

    /// <summary>
    /// Decrease the number of incorrect placements
    /// </summary>
    public void DecreaseCorrectPlacements()
    {
        currentCorrectPlacements--;
    }

}