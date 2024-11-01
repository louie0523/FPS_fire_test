using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DstoryEffect : MonoBehaviour
{
    public float destroyTime = 1.5f;

    float currentTime = 0;
    void Update()
    {
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
        currentTime = Time.deltaTime;
    }
}
