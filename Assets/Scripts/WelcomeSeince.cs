using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WearHFPlugin;
using UnityEngine.SceneManagement;

public class WelcomeSeince : MonoBehaviour
{
    private WearHF m_wearHf;
    private bool isAnimation;
    // Start is called before the first frame update
    void Start()
    {
        m_wearHf = GameObject.Find("WearHF Manager").GetComponent<WearHF>();
        m_wearHf.AddVoiceCommand("start", Start);

        isAnimation = false;
    }

    public void Continue(string obj)
    {
        SceneManager.LoadSceneAsync("video");
    }

    public void Start(string obj)
    {
        if(!isAnimation)
        {
            Animation anim = GetComponent<Animation>();
            anim.Play();
            isAnimation = true;
        }

        m_wearHf.AddVoiceCommand("continue", Continue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
