using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreatureSpawner : MonoBehaviourPunCallbacks
{
    public GameObject[] creaturePrefabs;
    public Transform[] spawnPoints;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            int i = 0;
            foreach (GameObject gameobject in creaturePrefabs)
            {
                Transform spawnPoint = spawnPoints[i];
                PhotonNetwork.Instantiate(gameobject.name,spawnPoint.position,Quaternion.identity,0);
                i++;
            }
        }
    }
}
