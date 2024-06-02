using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Positions : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3[] positions;
    void Start()
    {
        int random_number = Random.Range (0,positions.Length-1);
        transform.position = positions [random_number];
    }
}