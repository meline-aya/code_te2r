using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public Text playerName;
    public Text IsReady;
    public GameObject leftArrowButton;
    public GameObject rightArrowButton;
    public GameObject Ready;
    public ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Image playerAvatar;
    public Sprite[] avatars;
    Player player;
    public ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
    public int Color;
    public void Start()
    {
        playerProperties["playerAvatar"] = 0;
        playerProperties["Color"] = 0;
        customProperties["IsReady"] = false;
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        PhotonNetwork.SetPlayerCustomProperties(customProperties);
    }
    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }
    public void ApplyLocalChanges()
    {
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
        Ready.SetActive(true);
        IsReady.text = "";
    }

    public void Prout()
    {
        IsReady.text = "Ready !";
    }

    public bool CanGo()
    {
        if (leftArrowButton == null)
            return true;
        return !leftArrowButton.activeSelf;
    }

    public void OnClickLeftArrow()
    {
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public void OnClickRightArrow()
    {
        if ((int)playerProperties["playerAvatar"] == avatars.Length - 1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer,ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
            UpdatePlayertkt(targetPlayer);
        }
    }
    void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
        }
    }

    void UpdatePlayertkt(Player player)
    {
        if (player.CustomProperties.ContainsKey("IsReady"))
        {
            customProperties["IsReady"] = (bool)player.CustomProperties["IsReady"];
        }
        else
        {
            customProperties["IsReady"] = false;
        }
        if (player.CustomProperties.ContainsKey("Color") && player.CustomProperties.ContainsKey("playerAvatar"))
        {
            customProperties["Color"] = (int)player.CustomProperties["playerAvatar"];
        }
        else
        {
            customProperties["Color"] = 0;
        }
    }
    
    public void OnClickReady()
    {
        leftArrowButton.SetActive(false);
        rightArrowButton.SetActive(false);
        Ready.SetActive(false);
        customProperties["IsReady"] = true;
        PhotonNetwork.SetPlayerCustomProperties(customProperties);
        Color = (int)playerProperties["playerAvatar"];
        playerProperties["Color"] = (int)playerProperties["playerAvatar"];
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void CantClickReady()
    {
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
        Ready.SetActive(true);
        customProperties["IsReady"] = false;
        PhotonNetwork.SetPlayerCustomProperties(customProperties);
    }
}
