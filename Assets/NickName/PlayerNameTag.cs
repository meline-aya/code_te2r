using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerNameTag : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nameText;

    void Start()
    {
        if (photonView.IsMine) { return; }
        SetName();
    }

    public void SetName()
    {
        nameText.text = photonView.Owner.NickName;
    }
}
