using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class WinAndLoose : MonoBehaviour
{
    public GameObject Win;
    public GameObject Loose;
    PhotonView[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = GetComponents<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        int win = -1;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].tag == "Win")
            {
                if (players[i].IsMine)
                {
                    Win.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                }

                win = i;
            }
        }

        if (win > 0 && players[win].IsMine)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (i != win)
                {
                    if (players[i].IsMine)
                    {
                        Loose.SetActive(false);
                    }
                }
            }
        }
    }

    public void OnCLickSpectatorMode()
    {
        
    }

    public void OnClickBacktoTheMenu()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void OnClickLeave()
    {
        Application.Quit();
    }
}


