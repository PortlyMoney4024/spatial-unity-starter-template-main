using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueborly : MonoBehaviour
{
    public float rotateSpeed = 50f;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
}
