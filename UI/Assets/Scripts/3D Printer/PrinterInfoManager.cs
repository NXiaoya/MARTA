using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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