using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadProgressControl : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI PrinterState;
     [SerializeField] private TextMeshProUGUI SolderState;
    // Start is called before the first frame update
    void Start()
    {
        PrinterState.text= "Not Saved";
        SolderState.text= "Not Saved";
    }

    // Update is called once per frame
    void Update()
    {
         if (PlayerPrefs.HasKey("inkSaveSolder"))
        {
            var savedState = PlayerPrefs.GetString("inkSaveSolder");
            SolderState.text = savedState;
        }

         if (PlayerPrefs.HasKey("inkSavePrinter"))
        {
            var savedState = PlayerPrefs.GetString("inkSavePrinter");
            PrinterState.text = savedState;
        }
    }

    public void EnterPrinter(){
        SceneManager.LoadScene("3D Printer");
        Debug.Log("Jump to scene 3D Printer");
        PlayerPrefs.SetString("Progress", "true");//('key name',value)

    }

    public void EnterSolder(){
        SceneManager.LoadScene("Soldering Station");
        Debug.Log("Jump to scene Soldering Station");
        PlayerPrefs.SetString("Progress", "true");//('key name',value)
    }
}
