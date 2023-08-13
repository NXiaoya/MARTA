using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrinterInfoManager : MonoBehaviour
{
    [SerializeField] private GameObject ContinueButton;   


    public void StartAnimation()
    {
        ContinueButton.SetActive(false);

    }

    public void EndAnimation()
    {
        ContinueButton.SetActive(true);

    }

 
}