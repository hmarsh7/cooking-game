using UnityEngine;
using System.Collections;

public class StartGameManager : MonoBehaviour
{
    public GameObject StartScreen;
    private CanvasGroup canvasGroup;

    public float fadeDuration = 1.0f;

    public static bool gameStarted = false;

    void Start() {
        canvasGroup = StartScreen.GetComponent<CanvasGroup>();
    }
    public void StartGame() {
       StartCoroutine(FadeOutStartScreen());
    }

    IEnumerator FadeOutStartScreen() {
        float elapsed = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsed < fadeDuration) {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        StartScreen.SetActive(false);

        gameStarted = true;
    }
}
