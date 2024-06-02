using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
{
    public OxygenBar oxygenBar;
    
    void LateUpdate()
    {
        if (oxygenBar.HealthBarBlue.fillAmount <= 0.9)
        {
            
        }
    }
}
