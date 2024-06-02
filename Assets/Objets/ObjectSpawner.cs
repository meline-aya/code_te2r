using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsPrefabs;
    int nbPlayer;
    int number_first = 2;
    int number_second = 3;
    int number_third = 2;
    int number_fourth = 2;

    //Liste de position pour les boites
    List<(double,double,double)> list = new List<(double, double, double)>
    {
        (700,42,521),
        (676,48,485),
        (592,39,525),
        (661,41,465),
        (587,40,503),
        (603,37,465),
        (400,46,477),
        (250,43,477),
        (300,43,300),
        (700,44,300),
        (720,38,250),
        (645,41,200),
        (670,47,210),
        (690,47,210),
        (800,41,210),
        (800,44,300),
        (750,43,300),
        (569.7, 40.98, 820.3),
        (630.43, 35.72, 567),
        (651.9, 40.14, 501.9),
        (671.18, 44.39, 468.06),
        (649.28, 35.93, 451.16),
        (717, 36.16, 242.16),
        (572.34, 38.77, 165.05),
        (643.6, 35.16, 169.61),
        (757.4, 75.8, 89.4),
        (806.5, 54.47, 89.4),
        (839.52, 42.46, 207.9),
        (865.17, 43.86, 207.9),
        (919.29, 36.36, 300.44),
        (887.36, 40.98, 467.35),
        (948.85, 42.37, 700),
        (952.59, 37.71, 744.1),
        (945.2, 37.6, 751.39),
        (945.2, 37.6, 794.27),
        (954.12, 35.9, 848.34)
    };
    //Fait spawn les objets sur la map
    
    void Start()
    {
        nbPlayer = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log(nbPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            for(int i = 0; i < number_first*nbPlayer; i++)
            {
                int randomNumber = UnityEngine.Random.Range(0,list.Count);
                PhotonNetwork.Instantiate("Cube rouge",(new Vector3((float)list[randomNumber].Item1, (float)list[randomNumber].Item2, (float)list[randomNumber].Item3)),Quaternion.identity,0);
                list.RemoveAt(randomNumber);
            }
            for(int i = 0; i < number_second*nbPlayer; i++)
            {
                int randomNumber = UnityEngine.Random.Range(0,list.Count);
                PhotonNetwork.Instantiate("Cube vert",(new Vector3((float)list[randomNumber].Item1, (float)list[randomNumber].Item2, (float)list[randomNumber].Item3)),Quaternion.identity,0);
                list.RemoveAt(randomNumber);
            }
            for(int i = 0; i < number_third*nbPlayer; i++)
            {
                int randomNumber = UnityEngine.Random.Range(0,list.Count);
                PhotonNetwork.Instantiate("Cube bleu",(new Vector3((float)list[randomNumber].Item1, (float)list[randomNumber].Item2, (float)list[randomNumber].Item3)),Quaternion.identity,0);
                list.RemoveAt(randomNumber);
            }
            for(int i = 0; i < number_fourth*nbPlayer; i++)
            {
                int randomNumber = UnityEngine.Random.Range(0,list.Count);
                PhotonNetwork.Instantiate("Cube rose",(new Vector3((float)list[randomNumber].Item1, (float)list[randomNumber].Item2, (float)list[randomNumber].Item3)),Quaternion.identity,0);
                list.RemoveAt(randomNumber);
            }
            for(int i = 0; i < number_first*nbPlayer; i++)
            {
                int randomNumber = UnityEngine.Random.Range(0,list.Count);
                PhotonNetwork.Instantiate("Oxygen bottle",(new Vector3((float)list[randomNumber].Item1, (float)list[randomNumber].Item2, (float)list[randomNumber].Item3)),Quaternion.identity,0);
                list.RemoveAt(randomNumber);
            }
            int randomNum = UnityEngine.Random.Range(0,list.Count);
            PhotonNetwork.Instantiate("Gold bottle",(new Vector3((float)list[randomNum].Item1, (float)list[randomNum].Item2, (float)list[randomNum].Item3)),Quaternion.identity,0);
            list.RemoveAt(randomNum);
        }
    }
}
