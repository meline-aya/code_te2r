using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;




public class OxygenBar : MonoBehaviour
{
    public GameObject LifeCam;
    public GameObject DeadCam;


    Animator animator;



    public float health = 100f;
    public float maxHealth = 100f;
    public Image HealthBarBlue;
    float time;
    public float TimeInterval = 1f;
    float tick;
    bool Inv = false;
    public Color bleutamere;

    void Awake()
    {
        time = (int)Time.time;
        tick = TimeInterval;
    }


    private void Start()
    {
        LifeCam.SetActive(true);
        DeadCam.SetActive(false);
        animator.SetBool("death", false);



        //animator = GetComponent<Animator>();
        //deathHash = Animator.StringToHash("death");
    }


    // Update is called once per frame
    void Update()
    {
        //bool avance = animator.GetBool(deathHash);



        time = (int)Time.time;
        health = health - 0.01f;
        if (time != 0 && !Inv)
            HealthBarBlue.fillAmount = health / maxHealth;
        
        if (HealthBarBlue.fillAmount <= 0)
        {
            //SceneManager.LoadScene("LoseScene");  PASSER AU MENU DE MORT
            LifeCam.SetActive(false);
            DeadCam.SetActive(true);
            animator.SetBool("death", true);
        }
    }

    public void TakeOxygen()
    {
        health += 20f;
        if (health > 100f)
            health = 100f;
        HealthBarBlue.fillAmount = health / maxHealth;
    }

    public void Invincibility()
    {
        HealthBarBlue.fillAmount = 1f;
        Inv = true;
    }


    public void Attack()
    {
        HealthBarBlue.color = new Color(255, 0, 0);
        health -= 20f;
        HealthBarBlue.fillAmount = health / maxHealth;
        HealthBarBlue.color = bleutamere;
    }
}
