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
    [SerializeField] private GameObject Printer;
    [SerializeField] private Animator ScreenAnimator;
    [SerializeField] private Animator PrinterAnimator;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choices;
    [SerializeField] public GameObject[] Hints;
    [SerializeField] public GameObject[] LCDHints;
    [SerializeField] public GameObject[] AnimationTrigger;
    [SerializeField] private GameObject ScreenImage;
    [SerializeField] public GameObject PrintModel;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private GameObject StartButton;


    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private static DialogueManeger instance;

    private const string Laptop_TAG = "ChangeLaptop";
    private const string ShowPT_TAG = "show3DPrinter";



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

        dialoguePanel.SetActive(false);
        Printer.SetActive(false);

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
        dialoguePanel.SetActive(true);//Open the intruction panel

        currentStory.BindExternalFunction("ShowHints", (int Hintsnumber) =>
        {
            int index = Hintsnumber;
            if (Hints != null && Hints.Length > 0)
            {
                // Activate the first element in Hints array
                Hints[index].gameObject.SetActive(true);
                Debug.Log("Show hint " + index);
            }

            ContinueButton.SetActive(false);
        });
        currentStory.BindExternalFunction("LCDHints", (int Hintsnumber) =>
        {
            int index = Hintsnumber;
            if (LCDHints != null && LCDHints.Length > 0)
            {
                // Activate the first element in Hints array
                LCDHints[index].gameObject.SetActive(true);
                Debug.Log("Show LCD hint " + index);
            }

            ContinueButton.SetActive(false);

        });
        currentStory.BindExternalFunction("PrinterSetupAnimation", (string AnimationName) =>
        {
            Printer.SetActive(true);
            ContinueButton.SetActive(false);
            PrinterAnimator.Play(AnimationName);

        });
        currentStory.BindExternalFunction("PrinterSetupAnimationTrigger", (int TriggerNum) =>
        {
            int index = TriggerNum;
            if (AnimationTrigger != null && AnimationTrigger.Length > 0)
            {
                // Activate the first element in Hints array
                AnimationTrigger[index].gameObject.SetActive(true);
                Debug.Log("Show printer animation trigger " + index);
            }

            ContinueButton.SetActive(false);

        });
        currentStory.BindExternalFunction("ChooseModel", (string ModelName) =>
        {
            PrintModel.SetActive(true);
        });
        //ContinueStory();//Call the function to contine the story

    }


    private void ExitDialogueMode()
    {
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
                    ScreenImage.SetActive(true);
                    ScreenAnimator.Play(tagValue);
                    break;
                case ShowPT_TAG:
                    Printer.SetActive(true);
                    ContinueButton.SetActive(false);
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
        string savedState = "step" + (choiceIndex + 1);//get the current story progress
        Debug.Log(savedState);
        LoadSteps(savedState);
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
        if (currentStory)
        {
            if (PlayerPrefs.HasKey("inkSavePrinter"))
            {
                var savedState = PlayerPrefs.GetString("inkSavePrinter");
                LoadSteps(savedState);
                currentStory.ChoosePathString(savedState);
                ContinueButton.SetActive(true);
                ContinueStory();
                Debug.Log("You have load progress at " + savedState);
            }
        }
        else
        {
            EnterDialogueMode(inkJSON);
            StartButton.SetActive(false);
            if (PlayerPrefs.HasKey("inkSavePrinter"))
            {
                var savedState = PlayerPrefs.GetString("inkSavePrinter");
                LoadSteps(savedState);
                currentStory.ChoosePathString(savedState);
                ContinueButton.SetActive(true);
                ContinueStory();
                Debug.Log("You have load progress at " + savedState);
            }
        }

    }

    public void showContinueButton()
    {
        ContinueButton.SetActive(true);
    }

    public void HideContinueButton()
    {
        ContinueButton.SetActive(false);
    }

    public void LoadSteps(String currentStep)
    {

        switch (currentStep)
        {
            case "step1":
                Debug.Log("Initialize in step 1");
                Printer.SetActive(false);
                break;
            case "step2":
                Debug.Log("Initialize in step 2");
                Printer.SetActive(true);
                break;
            case "step3":
                Debug.Log("Initialize in step 3");
                Printer.SetActive(true);
                break;
            case "step4":
                Debug.Log("Initialize in step 4");
                Printer.SetActive(true);
                break;
            case "step5":
                Debug.Log("Initialize in step 5");
                Printer.SetActive(true);
                break;
            case "step6":
                Debug.Log("Initialize in step 5");
                Printer.SetActive(true);
                PrinterAnimator.Play("CompletePrinting");
                break;
            case "step7":
                Debug.Log("Initialize in step 5");
                Printer.SetActive(true);
                break;



            default:
                Debug.LogWarning("can not locate current step");
                break;
        }


    }

}
