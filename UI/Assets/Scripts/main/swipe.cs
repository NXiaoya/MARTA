using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipe : MonoBehaviour
{
    public GameObject scrollbar; 
    public GameObject PrinterEnter;
    public GameObject SolderingEnter; 
    public GameObject CEdataEnter;
    private float scroll_pos = 0.5f;
    float[] pos;
    private bool runIt = false;
    private float time;
    private Button takeTheBtn;
    int btnNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        if (runIt)
        {
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }


        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                Debug.Log("Current Selected Level" + i);
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.5f, 0.5f), 0.1f);
                    }
                }
                switch (i){
                case 0:
                    Showprinter();
                    break;
                case 1:
                    ShowSolder();
                    break;
                case 2:
                   ShowCE();
                    break;

                default:
                    Debug.LogWarning("can not locate current step");
                    break;
                }
            }
        }


    }
    public void Showprinter(){
        PrinterEnter.SetActive(true);
        SolderingEnter.SetActive(false);
        CEdataEnter.SetActive(false);
    }
     public void ShowSolder(){
        PrinterEnter.SetActive(false);
        SolderingEnter.SetActive(true);
        CEdataEnter.SetActive(false);
    }
     public void ShowCE(){
        PrinterEnter.SetActive(false);
        SolderingEnter.SetActive(false);
        CEdataEnter.SetActive(true);
    }

}