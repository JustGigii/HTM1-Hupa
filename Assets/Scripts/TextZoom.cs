using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WearHFPlugin;

public class TextZoom : MonoBehaviour
{
    public Text[] textViewCount;
    public float[] Space;
    public int index;
    public string[] texts;


    private List<Text> textOnScreen;
    private WearHF m_wearHf;
    private int last;

    // Start is called before the first frame update
    void Start()
    {
        last = 0;
        textOnScreen = new List<Text>();
        m_wearHf = GameObject.Find("WearHF Manager").GetComponent<WearHF>();
        m_wearHf.AddVoiceCommand("Zoom In", zoomIn);
        m_wearHf.AddVoiceCommand("Zoom Out", zoomOut);
        m_wearHf.AddVoiceCommand("Next", GoNext);
        m_wearHf.AddVoiceCommand("Back", GoBack);
        initialize();
        initializetText("");
    }

    private void initialize()
    {
        Text gameObjectText;


        if (index == 0 || textViewCount[index - 1] is null)
        {
            gameObjectText = DefultView();
            return;
        }


        gameObjectText = GameObject.Instantiate<Text>(textViewCount[index - 1]);
        textOnScreen.Add(gameObjectText);
        gameObjectText.transform.SetParent(this.transform);
        gameObjectText.rectTransform.position = new Vector3(this.transform.position.x, this.transform.position.y + gameObjectText.rectTransform.position.y, 0);


        Vector3 place = gameObjectText.rectTransform.position;


        for (int i = 1; i < index; i++)
        {
            gameObjectText = GameObject.Instantiate<Text>(textViewCount[index - 1]);
            textOnScreen.Add(gameObjectText);
            gameObjectText.transform.SetParent(this.transform);
            gameObjectText.rectTransform.position = new Vector3(place.x, place.y - Space[index - 1] * (i), 0);
        }

    }

    private Text DefultView()
    {
        Text gameObjectText = GameObject.Instantiate<Text>(textViewCount[0]);
        textOnScreen.Add(gameObjectText);
        gameObjectText.transform.SetParent(this.transform);
        gameObjectText.rectTransform.position = new Vector3(this.transform.position.x, this.transform.position.y + gameObjectText.rectTransform.position.y, 0);
        return gameObjectText;
    }

    void DestroyText()
    {
        for (int i = 0; i < textOnScreen.Count; i++)
        {
            Destroy(textOnScreen[i].gameObject);

        }
        textOnScreen.Clear();
    }

    private int populteText(int stop)
    {
        for (int i = 0; i < index; i++)
        {
            if (last + i > texts.Length - 1)
            {
                textOnScreen[i].text = "";
                stop = i;
            }
            else
            { 
            string text = texts[i + last];
            textOnScreen[i].text = text;
            }
        }

        return stop;
    }
    void initializetText(string state)
    {
        int stop = index;
        switch (state)
        {
            case "back":
                last = last - index * 2;
                break;

            case "pop":
                last = last - index;
                break;
            default:
                break;
        }

        last = (last < 0) ? 0 : last;
        stop = populteText(stop);
        last += stop;
    }
    public void GoNext(string obj)
    {
        if (last < texts.Length)
            initializetText("");
    }
    public void GoBack(string obj)
    {
        initializetText("back");
    }

    public void zoomIn(string obj)
    {
        if (index <= 1)
            return;
        index--;
        DestroyText();
        initialize();
        initializetText("pop");

    }
    public void zoomOut(string obj)
    {

        if (index >= 4)
            return;
        index++;
        DestroyText();
        initialize();
        initializetText("pop");

    }

    //public void OnClick(int number)
    //{
    //    index = number;
    //    DestroyText();
    //    initialize();
    //}
    // Update is called once per frame
    //void Update()
    //{

    //}
}
