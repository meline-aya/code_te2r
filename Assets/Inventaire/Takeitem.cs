using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Takeitem : MonoBehaviour
{
    Inventaire Inventaire_script;
    public OxygenBar HealthBarBlue;
    public Text text;
    public GameObject win;
    public GameObject loose;
    bool TakeIt = false;
    bool Winbg = false;
    private Collider coll;
    private PhotonView p;
    int number_first = 1;
    int number_second = 2;
    int number_third = 1;
    int number_fourth = 1;

    void Awake()
    {
        Inventaire_script = GameObject.Find("Inventory").GetComponent<Inventaire> ();
        p = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && TakeIt && coll != null && p.IsMine)
        {
            switch (coll.gameObject.tag)
            {
                case "slot" :
                Invent(0,number_first,coll);
                break;
                case "slot (1)" :
                Invent(1,number_second,coll);
                break;
                case "slot (2)" :
                Invent(2,number_third,coll);
                break;
                case "slot (3)" :
                Invent(3,number_fourth,coll);
                break;
            }
            TakeIt = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && Winbg && p.IsMine)
        {
            win.SetActive(true);
        }
    }

    //Fonction qui ajoute dans l'inventaire
    public void Invent(int i, int num, Collider col)
    {
        if (Inventaire_script.slot[i] < num)
        {
            Inventaire_script.slot[i] += 1;
            Inventaire_script.UpdateTXT(i,Inventaire_script.slot[i].ToString() + "/" + num);
            PhotonNetwork.Destroy(col.gameObject.transform.parent.gameObject);
            text.text = "";
        }
        else 
        {
            text.text = "You already have enough";
        }
    }

    
    void OnTriggerEnter (Collider col)
    {
        if (p.IsMine)
        {
            switch (col.gameObject.tag)
            {
                case "slot" : case "slot (1)" : case "slot (2)" : case "slot (3)" :
                text.text = "Press E to take the box";
                coll = col;
                TakeIt = true;
                break;

                case "Oxygen" :
                HealthBarBlue.TakeOxygen();
                PhotonNetwork.Destroy(col.gameObject);
                break;

                case "GoldBottle" :
                HealthBarBlue.Invincibility();
                PhotonNetwork.Destroy(col.gameObject);
                break;

                case "Rocket" :
                if (Inventaire_script.slot[0] == number_first && Inventaire_script.slot[1] == number_second && Inventaire_script.slot[2] == number_third && Inventaire_script.slot[3] == number_fourth)
                {
                    text.text = "Press F to win the game";
                    Winbg = true;
                }
                else 
                {
                    text.text = "Keep looking for boxes !";
                }
                break;

                case "Mechant":
                HealthBarBlue.Attack();
                break;
            }
        }
    }

    void OnTriggerExit()
    {
        if (p.IsMine)
        {   
            if (text.text != "")
            text.text = "";
            TakeIt = false;
            Winbg = false;
            coll = null;
        }
    }
}