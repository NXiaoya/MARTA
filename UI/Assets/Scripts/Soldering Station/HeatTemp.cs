using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(TextMeshProUGUI))]
public class IntegerCounter : MonoBehaviour
{
    public TextMeshProUGUI countText;
    [SerializeField] private GameObject ContinueButton;
    
    GameObject HighlightObject;
    private int targetCount = 350;
    private float timeToCount = 2f;

   public void HighlightSwitch()
        {
            HighlightObject = GameObject.Find("swiitch");
            Outline outlineComponent =HighlightObject.GetComponent<Outline>();
            if (outlineComponent != null)
            {
                HighlightObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Outline outline = HighlightObject.AddComponent<Outline>();
                outline.enabled = true;
                HighlightObject.GetComponent<Outline>().OutlineColor = Color.blue;
                HighlightObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }

        }

        public void HighlightPumpTrigger()
        {
            HighlightObject = GameObject.Find("Trigger:1");
            Outline outlineComponent = HighlightObject.GetComponent<Outline>();
            if (outlineComponent != null)
            {
                HighlightObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Outline outline = HighlightObject.AddComponent<Outline>();
                outline.enabled = true;
                HighlightObject.GetComponent<Outline>().OutlineColor = Color.blue;
                HighlightObject.GetComponent<Outline>().OutlineWidth = 7.0f;
            }

        }  

        public void HighlightSponge()
        {
            HighlightObject = GameObject.Find("sponge_high_poly");
            Outline outlineComponent = HighlightObject.GetComponent<Outline>();//get component outline
            if (outlineComponent != null)//the outline of this component has already been added
            {
                HighlightObject.GetComponent<Outline>().enabled = true;//enable outline
            }
            else
            {
                Outline outline = HighlightObject.AddComponent<Outline>();//add component outline
                outline.enabled = true;
                HighlightObject.GetComponent<Outline>().OutlineColor = Color.yellow;//outline color
                HighlightObject.GetComponent<Outline>().OutlineWidth = 7.0f;//outline width
            }

        } 
        public void HighlightOff(){
            HighlightObject.GetComponent<Outline>().enabled = false;
        } 

    private System.Collections.IEnumerator CountAndChangeText()
    {
        int startCount = 0;
        float elapsedTime = 0f;
        HighlightObject.GetComponent<Outline>().enabled = false;

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

    
    public void StartAnimation()
    {
        ContinueButton.SetActive(false);

    }

    public void EndAnimation()
    {
        ContinueButton.SetActive(true);

    }

}