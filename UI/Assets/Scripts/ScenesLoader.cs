using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to load
    [SerializeField] RectTransform fader;
     private void Start () {
        fader.gameObject.SetActive (true);

        // SCALE
        LeanTween.scale (fader, new Vector3 (1, 1, 1), 0);
        LeanTween.scale (fader, Vector3.zero, 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete (() => {
            fader.gameObject.SetActive (false);
        });
    }

    public void LoadScene(string sceneName)
    {


        fader.gameObject.SetActive (true);
              // SCALE
        LeanTween.scale (fader, Vector3.zero, 0f);
        LeanTween.scale (fader, new Vector3 (1, 1, 1), 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete (() => {
            SceneManager.LoadScene(sceneName);
        });
        Debug.Log("Jump to scene" + sceneName);
    }
}