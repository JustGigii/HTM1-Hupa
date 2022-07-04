using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WearHFPlugin;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeSeince : MonoBehaviour
{
    private WearHF m_wearHf;
    private bool isAnimation;
    private int index;


    public Sprite[] arrText;
    public GameObject background;
    public GameObject textimg;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;

        m_wearHf = GameObject.Find("WearHF Manager").GetComponent<WearHF>();
        m_wearHf.AddVoiceCommand("start", Start);
        if (gameObject.name.Equals("Text"))

        isAnimation = false;
    }

    public void next(string obj)
    {
        if (index++ == 0 && arrText is object)
        {
            textimg.GetComponent<Image>().sprite = arrText[index];
            m_wearHf.AddVoiceCommand("Continue", next);
            return;
        }

        m_wearHf.ClearCommands();
            SceneManager.LoadSceneAsync("video");
    }
    public void Continue(string obj)
    {
 

        m_wearHf.ClearCommands();
        SceneManager.LoadSceneAsync("video");
    }

    public void Start(string obj)
    {

            Animation anim = background.GetComponent<Animation>();
            anim.Play();
            isAnimation = true;
            StartCoroutine(Waiting());
            m_wearHf.AddVoiceCommand("next", next);
            isAnimation = true;
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        textimg.GetComponent<Image>().sprite = arrText[0];
        Animation anim = textimg.GetComponent<Animation>();
        anim.Play();
        isAnimation = true;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
