using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


//SOURCE : https://gamedevbeginner.com/how-to-play-audio-in-unity-with-examples/


public class bruits_pas : MonoBehaviour

{
    public OxygenBar oxygen;



    public AudioSource audioSource;
    public AudioClip audioClip;
    //public float timeBetweenShots = 0.25f;
    float timer;
    void Update()
    {

        //tant qu'on veut se déplacer
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && oxygen.HealthBarBlue.fillAmount>0)
        {
            timer += Time.deltaTime;
            if (timer > 0.4) //temps que le bruit de pas se finisse + temps entre deux pas
            {
                audioSource.PlayOneShot(audioClip);
                timer = 0;
            }
        }

        
    }

    /*
    //CHOISIR UN SON ALEATOIREMENT  (voir la conv que j'ai eu avec Tom sur Discord)

    AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
    */
}