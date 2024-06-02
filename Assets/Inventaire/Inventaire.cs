using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventaire : MonoBehaviour
{
    bool activation = false;
    GameObject P;
    public int[] slot;

    void Start()
    {
        GetComponent<Canvas> ().enabled = false;
        P = transform.GetChild (0).gameObject;
        slot = new int[P.transform.childCount];
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activation = !activation;
            GetComponent<Canvas> ().enabled = activation;
        }
    }

    public void UpdateTXT(int nrslot, string txt)
    {
        P.transform.GetChild(nrslot).GetChild(1).GetComponent<Text>().text = txt;
    }
}
