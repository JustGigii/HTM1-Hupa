using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageMangger : MonoBehaviour
{
    public Sprite[] images;

    private MissoinMennger main;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        main = GameObject.Find("Mannger").GetComponent<MissoinMennger>();
        LoadImage();
    }


    public void NextSentence()
    {
        if (index + 1 >= images.Length)
            return;
        index++;
        LoadImage();
    }
    public void BackSentence()
    {
        if (index - 1 < 0)
            return;
        index--;
        LoadImage();
    }

    // Update is called once per frame
    public void LoadImage()
    {
        main.mainImage.sprite = images[index];
    }
    public void RestIndex()
    {
        index = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
