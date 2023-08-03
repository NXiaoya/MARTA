using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using System;

public class DialogueManeger : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject ContinueButton;
    [SerializeField] private GameObject Laptop;
    [SerializeField] private GameObject Printer;
    [SerializeField] private GameObject PrinterInfo;
    [SerializeField] private Animator ScreenAnimator;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choices;


    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private Boolean DialogueIsPlay;
    private static DialogueManeger instance;

    private const string Laptop_TAG = "ChangeLaptop";
    private const string ShowLT_TAG = "ShowLaptop";
    private const string ShowPT_TAG = "show3DPrinter";

    GameObject panel;
    GameObject knob;
    GameObject reset;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Doalogue Maneger");
        }
        instance = this;
    }

    public static DialogueManeger GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        DialogueIsPlay = false;
        dialoguePanel.SetActive(false);
        Laptop.SetActive(false);
        Printer.SetActive(false);

        //get all the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        panel = GameObject.Find("Control Panel");
        knob = GameObject.Find("Control knob");
        reset = GameObject.Find("Reset Button");
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);//Create a new ink story
        DialogueIsPlay = true;
        dialoguePanel.SetActive(true);//Open the intruction panel

        ContinueStory();//Call the function to contine the story

    }


    private void ExitDialogueMode()
    {
        DialogueIsPlay = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)//check if the stroy can run normally
        {
            HandleTags(currentStory.currentTags);//check tags
            dialogueText.text = currentStory.Continue();//display the text
            DisplayChoices();//display choices if they exsists
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //loop each tag
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag cound not be parsed" + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case Laptop_TAG:
                    ScreenAnimator.Play(tagValue);
                    break;
                case ShowLT_TAG:
                    Laptop.SetActive(true);
                    break;
                case ShowPT_TAG:
                    Laptop.SetActive(false);
                    Printer.SetActive(true);
                    PrinterInfo.SetActive(true);
                    ContinueButton.SetActive(false);
                    // panel.SetActive(true);
                    // knob.SetActive(false);
                    // reset.SetActive(false);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled" + tag);
                    break;
            }
        }

    }

    public void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices given than UI");
        }

        int index = 0;
        //enable and initialize UI

        foreach (Choice choice in currentChoices)//iterate over each choice
        {
            choices[index].gameObject.SetActive(true);//enable UI
            choicesText[index].text = choice.text;//assign text to current choice
            index++;//add the idex to next choice
            ContinueButton.SetActive(false);
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);//Disable the unused choice UI
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);//pass the choice index
        ContinueStory();//continue training
        ContinueButton.SetActive(true);
    }

    public void SaveProgress()
    {
        string savedState = currentStory.state.currentPathString;//get the current story progress
        if (savedState.Length > 5)
        {
            // index of string array and number of characters accepted
            savedState = savedState.Substring(0, 5);
        }
        Debug.Log("You have saved progress at " + savedState);
        PlayerPrefs.SetString("inkSavePrinter", savedState);//('key name',value)
    }

    public void LoadProgress()
    {
        if (PlayerPrefs.HasKey("inkSavePrinter"))
        {
            var savedState = PlayerPrefs.GetString("inkSavePrinter");
            Laptop.SetActive(false);
            Printer.SetActive(false);
            currentStory.ChoosePathString(savedState);
            ContinueButton.SetActive(true);
            ContinueStory();
            Debug.Log("You have load progress at " + savedState);
        }
    }

}
