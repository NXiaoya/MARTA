using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to load
    public mqttReceiverList MQTTReceiver;
    public void BackHome(string sceneName)
    {
        MQTTReceiver.Disconnect();
        SceneManager.LoadScene(sceneName);
        Debug.Log("Jump to scene" + sceneName);
    }
}
