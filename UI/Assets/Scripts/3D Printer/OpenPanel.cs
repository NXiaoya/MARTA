using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;
    GameObject button;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    void Start()
    {
        button = GameObject.Find("Start");
    }

    public void OnPanel()
    {
        
            button.SetActive(false);
            DialogueManeger.GetInstance().EnterDialogueMode(inkJSON);
        
    }
}
