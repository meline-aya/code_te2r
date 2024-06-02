using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public GameObject Escap;
    public GameObject Cam;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Escap.activeSelf)
            {
                Escap.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Escap.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    public void OnClickPlay()
    {
        Escap.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnClickBackToMenu()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Lobby");
    }
    
    public void OnClickLeave()
    {
        Application.Quit();
    }
}
