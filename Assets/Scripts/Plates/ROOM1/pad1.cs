using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Assigned to pressure pads that a box can be dropped on
/// </summary>
public class pad1 : MonoBehaviour
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

                PlateManager1.instance.IncreaseCorrectPlacements(); //so increment the correct placements

            }

            PlateManager1.instance.IncreasePlacement(); //Increase the number of placement attempts (does not have to be a correct placement)
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
            PlateManager1.instance.DecreasePlacement();


            if (other.gameObject.GetComponent<Pickupable>().ReturnBoxId() == padId) //...If the box that has stopped colliding is the correct box for this pad...
            {

                PlateManager1.instance.DecreaseCorrectPlacements(); //...then decrease the number of corectly placed pads 
            }
        }

    }
}