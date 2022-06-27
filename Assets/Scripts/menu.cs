using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WearHFPlugin;



public class menu : MonoBehaviour
{
    public string m_scene;
    private WearHF m_wearHf;
    // Start is called before the first frame update
    void Start()
    {
        m_wearHf = GameObject.Find("WearHF Manager").GetComponent<WearHF>();
        Debug.Log(this.gameObject.name);
        m_wearHf.AddVoiceCommand(this.gameObject.name, VoiceCommandCallback);
    }

    void VoiceCommandCallback(string Command)
    {
        m_wearHf.ClearCommands();
        SceneManager.LoadSceneAsync(m_scene);
    }
}
