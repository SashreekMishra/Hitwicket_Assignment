using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public bool hasReached = false;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Doofus") && !hasReached)
        {
            hasReached = true;
            ScoreManager.Instance.UpdateScore();
        }
    }
}
