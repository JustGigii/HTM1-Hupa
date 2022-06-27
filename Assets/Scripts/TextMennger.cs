using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMennger : MonoBehaviour
{
    public string[] text;

    private MissoinMennger main;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        main = GameObject.Find("Mannger").GetComponent<MissoinMennger>();

    }


    public void NextSentence()
    {
        if (index+1 >= text.Length)
            return;
        index++;
        LoadText();
    }
    public void BackSentence()
    {
        if (index-1 < 0)
            return;
        index--;
        LoadText();
    }

    // Update is called once per frame
    public void LoadText()
    {
        main.mainText.color = Color.black;

        if (text[index].Contains("אזהרה")|| text[index].Contains("זהירות"))
            main.mainText.color = Color.red;

        main.mainText.text = text[index];
    }
    public void RestIndex()
    {
        index = 0;
    }
        
}
