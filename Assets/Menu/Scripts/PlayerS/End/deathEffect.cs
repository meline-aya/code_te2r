using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class deathEffect : MonoBehaviour
{

    public GameObject constant;
    public GameObject debut;
    public GameObject loose;
    public OxygenBar oxygen;
    int waiter;


    // Start is called before the first frame update
    void Awake()
    {
        debut.SetActive(false);
        constant.SetActive(false);
        waiter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (oxygen.HealthBarBlue.fillAmount <= 0)
        {
            if (waiter >= 1000)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                loose.SetActive(true);
            }

            else if (waiter >= 500)
            {
                constant.SetActive(true);
                waiter += 1;
            }
            
            else
            {
                debut.SetActive(true);
                waiter += 1;
            }
        }
    }
    
}
