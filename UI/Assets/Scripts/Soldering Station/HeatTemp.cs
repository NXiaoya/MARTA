using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(TextMeshProUGUI))]
public class IntegerCounter : MonoBehaviour
{
    public TextMeshProUGUI countText;
    GameObject SwitchB;
    private int targetCount = 350;
    private float timeToCount = 2f;

   public void HighlightSwitch()
        {
            SwitchB = GameObject.Find("swiitch");
            Outline outlineComponent = SwitchB.GetComponent<Outline>();
            if (outlineComponent != null)
            {
                SwitchB.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Outline outline = SwitchB.AddComponent<Outline>();
                outline.enabled = true;
                SwitchB.GetComponent<Outline>().OutlineColor = Color.blue;
                SwitchB.GetComponent<Outline>().OutlineWidth = 7.0f;
            }

        }

    private System.Collections.IEnumerator CountAndChangeText()
    {
        int startCount = 0;
        float elapsedTime = 0f;
        SwitchB.GetComponent<Outline>().enabled = false;

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