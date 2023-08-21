using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mqttControllerList : MonoBehaviour
{
    [Tooltip("Optional name for the controller")]
    public string nameController = "Controller 1";
    public string tagOfTheMQTTReceiver = ""; //to be set on the Inspector panel. It must match one of the mqttReceiverList.cs GameObject
    [Header("   Case Sensitive!!")]
    [Tooltip("the topic to subscribe must contain this value. !!Case Sensitive!! ")]
    public string topicSubscribed = ""; //the topic to subscribe, it need to match a topic from the mqttReceiver

    public mqttReceiverList _eventSender;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver).Length > 0)
        {
            _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<mqttReceiverList>();
        }
        else
        {
            Debug.LogError("At least one GameObject with mqttReceiver component and Tag == tagOfTheMQTTReceiver needs to be provided");
        }
    }

    void OnEnable()
    {
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnDisable()
    {
        _eventSender.OnMessageArrived -= OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(mqttObj mqttObject) //the mqttObj is defined in the mqttReceiverList.cs
    {
        //We need to check the topic of the message to know where to use it 
        if (mqttObject.topic.Contains(topicSubscribed))//check if it is the subcribed topic
        {
            var CEDevice = JsonUtility.FromJson<Root>(mqttObject.msg);
            int Power = CEDevice.ENERGY.ApparentPower;//Get the power from the JSON

            Debug.Log(CEDevice.ENERGY.ApparentPower);
            if (Power > 50)
            {
                gameObject.GetComponent<Image>().color = new Color(255, 0, 0);//change color to busy
            }
            else
            {
                gameObject.GetComponent<Image>().color = new Color(0, 255, 0);//change color to available
            }
        }
    }

    private void Update()
    {

    }

    [System.Serializable]
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ENERGY
    {
        public string TotalStartTime;
        public double Total;
        public int Yesterday;
        public int Today;
        public int Period;
        public int Power;
        public int ApparentPower;
        public int ReactivePower;
        public int Factor;
        public int Voltage;
        public int Current;
    }
    [System.Serializable]
    public class Root
    {
        public string Time;
        public ENERGY ENERGY;
    }
}
