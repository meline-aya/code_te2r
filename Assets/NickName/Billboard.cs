using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Billboard : MonoBehaviour
{
    GameObject cam; //ce n'est pas une camera mais le pseudo de l'autre joueur

    //void Start()
    //{
    //orientation = Quaternion.LookRotation(leftHand.PointerPose.forward, Vector3.up);
    //}

    void Update()
    {
        cam = GameObject.Find("GLASS");

        transform.LookAt(new Vector3(cam.transform.position.x,cam.transform.position.y,cam.transform.position.z));
        transform.Rotate(Vector3.up * 180);
    }
}
