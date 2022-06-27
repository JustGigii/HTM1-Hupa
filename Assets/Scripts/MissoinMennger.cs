using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using WearHFPlugin;
using System;
using TMPro;

public class MissoinMennger : MonoBehaviour
{

    public VideoPlayer mainVideo;
    public TextMeshProUGUI mainText;
    public Image mainImage;
    public List<VideoClip> videoClips;

    private List<GameObject> tasks;
    private int index;
    private bool isVideo;
    private WearHF m_wearHf;
    // Start is called before the first frame update
    void Start()
    {
        m_wearHf = GameObject.Find("WearHF Manager").GetComponent<WearHF>();
        m_wearHf.AddVoiceCommand("Check", Check);
        m_wearHf.AddVoiceCommand("Rewind", Rewind);
        m_wearHf.AddVoiceCommand("preview", preview);
        m_wearHf.AddVoiceCommand("next", NextSentence);
        m_wearHf.AddVoiceCommand("back", BackSentence);
        
        

        LoadTasks();
        loadWachable();
        index = 0;

    }

    private void Rewind(string obj)
    {
        mainVideo.frame = 0;
        mainVideo.Play();
    }

    void loadWachable()
    {
        if (tasks[index].GetComponent<ImageMangger>() != null)
        {
            // mainImage.sprite = tasks[index].GetComponent<Image>().sprite;
            mainVideo.gameObject.SetActive(false);
            mainImage.gameObject.SetActive(true);
            mainText.gameObject.SetActive(false);
            isVideo = false;
            ImageMangger imager = tasks[index].GetComponent<ImageMangger>();
            imager.RestIndex();
            imager.LoadImage();
            return;
        }
        mainVideo.clip = videoClips[index-1];
        mainVideo.gameObject.SetActive(true);
        mainText.gameObject.SetActive(true);
        mainImage.gameObject.SetActive(false);
        TextMennger texter = tasks[index].GetComponent<TextMennger>();
        isVideo = true;
        texter.RestIndex();
        texter.LoadText();
    }
    void LoadTasks()
    {
        tasks = new List<GameObject>();
        GameObject MainTask = GameObject.Find("Tasks");
        foreach (Transform task in MainTask.transform)
        {
            tasks.Add(task.gameObject);

        }
    }

    public void Check(string obj)
    {
        if (index >= tasks.Count - 1)
            return;
        index++;
        loadWachable();
    }
    public void preview(string obj)
    {
        if (index <= 0)
            index = 1;
        index--;
        loadWachable();
    }
    public void NextSentence(string obj)
    {
        if (isVideo)
        {
            TextMennger texter = tasks[index].GetComponent<TextMennger>();
            texter.NextSentence();
            return;
        }
        ImageMangger imager = tasks[index].GetComponent<ImageMangger>();
        imager.NextSentence();
    }
    public void BackSentence(string obj)
    {
        if (isVideo)
        {
            TextMennger texter = tasks[index].GetComponent<TextMennger>();
            texter.BackSentence();
            return;
        }
        ImageMangger imager = tasks[index].GetComponent<ImageMangger>();
        imager.BackSentence();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
