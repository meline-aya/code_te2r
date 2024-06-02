using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    Inventaire Inventaire_script;

    void Start()
    {
        Inventaire_script = GameObject.Find ("Inventory").GetComponent<Inventaire> ();
    }
    public void Selection()
    {
        // Récupérer numéro du slot :
        int nrSlot = transform.parent.GetSiblingIndex ();
        // Décrémenter :
        Inventaire_script.slot[nrSlot] -= 1;
        Inventaire_script.UpdateTXT(nrSlot, Inventaire_script.slot[nrSlot].ToString());
    }
}
