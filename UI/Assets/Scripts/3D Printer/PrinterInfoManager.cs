using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrinterInfoManager : MonoBehaviour
{
    public List<Button> buttonsList = new List<Button>(); //the list of buttons

    void Start()
    {
        for (int i = 0; i < buttonsList.Count; i++) //Add a listener for each button in the list and keep track of the index 
        {
            Debug.Log(i);
            int index = i; //avoid Closure https://stackoverflow.com/questions/271440/captured-variable-in-a-loop-in-c-sharp

            buttonsList[index].onClick.AddListener(() => { diplaybyitem(index); });
        }

    }
    void diplaybyitem(int index)
    {
        Debug.Log(index);

        if (index + 1 < buttonsList.Count)
        {
            buttonsList[index].gameObject.SetActive(false);
            buttonsList[index + 1].gameObject.SetActive(true);
            Debug.Log("You have clicked the button " + index);
        }
        else
        {
            //buttonsList[index].gameObject.SetActive(false);
            //buttonsList[index - 1].gameObject.SetActive(true);
            Debug.Log("You have clicked the button " + index);
        }
    }
}