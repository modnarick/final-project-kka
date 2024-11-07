using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarDebugDelete : MonoBehaviour
{
    public void DeleteCircles()
    {
        // Find all GameObjects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        // Loop through all objects and check their name
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Circle(Clone)")
            {
                // Destroy the object if its name matches "Circle(Clone)"
                Destroy(obj);
            }
        }
    }
}
