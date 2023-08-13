using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LCDInfoManeger : MonoBehaviour
{

    [SerializeField] private GameObject ContinueButton;
    [SerializeField] public GameObject[] Hints;

    public TextMeshProUGUI countText;
    private int targetCount = 215;
    private float timeToCount = 2f;

    public void StartAnimation()
    {
        ContinueButton.SetActive(false);

    }

    public void EndAnimation()
    {
        ContinueButton.SetActive(true);

    }

     public void ShowHint()
    {
        Hints[0].SetActive(true);

    }


    private System.Collections.IEnumerator CountAndChangeText()
    {
        int startCount = 22;
        float elapsedTime = 0f;

        while (elapsedTime < timeToCount)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / timeToCount);
            int currentCount = Mathf.RoundToInt(Mathf.Lerp(startCount, targetCount, t));
            countText.text = currentCount.ToString();
            yield return null;
        }
        Debug.Log("End counting");

        // Ensure the final count is exactly the target count
        countText.text = targetCount.ToString();
    }

}
