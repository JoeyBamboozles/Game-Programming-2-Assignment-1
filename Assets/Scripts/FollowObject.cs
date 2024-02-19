using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 offset;

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        if (objectToFollow != null)
        {
            // Update the position of the TextMeshPro object to match the position of the target GameObject
            transform.position = objectToFollow.transform.position + offset;
        }
    }
}
