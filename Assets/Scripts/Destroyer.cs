using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float DestroyTime, DestroyTimer;
    void Update()
    {
        DestroyTimer += Time.deltaTime;
        if (DestroyTime <= DestroyTimer)
        {
            Destroy(gameObject);
        }
    }
}
