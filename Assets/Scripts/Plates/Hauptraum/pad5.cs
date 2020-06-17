using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad5 : MonoBehaviour
{
    public int padId;
    int objectsOnPad = 0;

    /// <summary>
    /// Called whenever a collision occurs with this pad
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pickupable>() != null) //If a box is placed...
        {
            objectsOnPad++;


            if (other.gameObject.GetComponent<Pickupable>().ReturnBoxId() == padId) //If the box has the same number as the pad, then its the correct box...
            {

                PlateManager5.instance.IncreaseCorrectPlacements(); //so increment the correct placements

            }

            PlateManager5.instance.IncreasePlacement(); //Increase the number of placement attempts (does not have to be a correct placement)
        }
    }

    /// <summary>
    /// Called when a colliding objects stops colliding with the pad
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Pickupable>() != null) //If it is a box that has stopped colliding...
        {
            objectsOnPad--; //...then reduce the number of colliding objects...
            PlateManager5.instance.DecreasePlacement();


            if (other.gameObject.GetComponent<Pickupable>().ReturnBoxId() == padId) //...If the box that has stopped colliding is the correct box for this pad...
            {

                PlateManager5.instance.DecreaseCorrectPlacements(); //...then decrease the number of corectly placed pads 
            }
        }

    }
}
