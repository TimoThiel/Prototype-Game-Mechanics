using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] private float secondsToDestroy = 1f;

    private void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }
}


