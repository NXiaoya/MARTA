using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using System;

public class DialogueController : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject ContinueButton;
    [SerializeField] private GameObject Station;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choices;
    [SerializeField] private Animator SolderingAnimator;
    private Transform highlight;



    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private Boolean DialogueIsPlay;
    private static DialogueController instance;

    GameObject ObjectHighlight;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Doalogue Maneger");
        }
        instance = this;
    }

    public static DialogueController GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        DialogueIsPlay = false;
        dialoguePanel.SetActive(false);


        //get all the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);//Create a new ink story
        DialogueIsPlay = true;
        dialoguePanel.SetActive(true);//Open the intruction panel

        currentStory.BindExternalFunction("ShowObject", (string objectName) =>
        {
            Station.SetActive(true);
        });

        currentStory.BindExternalFunction("Highlight", (string objectName) =>
        {
            ObjectHighlight = GameObject.Find(objectName);
            Outline outlineComponent = ObjectHighlight.GetComponent<Outline>();
            if (outlineComponent != null)
            {
                ObjectHighlight.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Outline outline = ObjectHighlight.AddComponent<Outline>();
                outline.enabled = true;
                ObjectHighlight.GetComponent<Outline>().OutlineColor = Color.blue;
                ObjectHighlight.GetComponent<Outline>().OutlineWidth = 7.0f;
            }

        });

        currentStory.BindExternalFunction("HighlightOff", (string objectName) =>
        {
            ObjectHighlight = GameObject.Find(objectName);
            ObjectHighlight.GetComponent<Outline>().enabled = false;

        });

         currentStory.BindExternalFunction("SolderAnimation", (string objectName) =>
        {
            ContinueButton.SetActive(false);
            SolderingAnimator.Play(objectName);
            ContinueButton.SetActive(true);
        });

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
            dialogueText.text = currentStory.Continue();//display the text
            DisplayChoices();//display choices if they exsists
        }
        else
        {
            ExitDialogueMode();
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
        PlayerPrefs.SetString("inkSaveState", savedState);//('key name',value)
    }

    public void LoadProgress()
    {
        if (PlayerPrefs.HasKey("inkSaveState"))
        {
            var savedState = PlayerPrefs.GetString("inkSaveState");
            currentStory.ChoosePathString(savedState);
            ContinueButton.SetActive(true);
            ContinueStory();
            Debug.Log("You have load progress at " + savedState);
        }
    }

}
