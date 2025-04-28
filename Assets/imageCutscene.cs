using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Needed for Coroutine

public class ImageCutscene : MonoBehaviour
{
    public RawImage displayImage;       // RawImage that shows the cutscene
    public Texture[] cutsceneTextures;  // PNG Textures for cutscene
    public float imageDisplayTime = 2f; // How long to display each image
    public GameObject startScreen;      // StartScreen to show after cutscene

    private int currentImageIndex = 0;
    private float timer = 0f;

    void Start()
    {
        if (cutsceneTextures.Length > 0 && displayImage != null)
        {
            displayImage.texture = cutsceneTextures[0];
        }

        if (startScreen != null)
        {
            startScreen.SetActive(false); // Hide StartScreen at beginning
        }
    }

    void Update()
    {
        if (cutsceneTextures.Length == 0 || displayImage == null)
            return;

        timer += Time.deltaTime;

        if (timer >= imageDisplayTime)
        {
            timer = 0f;
            currentImageIndex++;

            if (currentImageIndex < cutsceneTextures.Length)
            {
                displayImage.texture = cutsceneTextures[currentImageIndex];
            }
            else
            {
                Debug.Log("[ImageCutscene] Cutscene finished.");

                displayImage.gameObject.SetActive(false); // Hide the RawImage
                if (startScreen != null)
                {
                    startScreen.SetActive(true); // Show StartScreen
                }

                // DO NOT touch gameStarted here! Player must click Play manually.
            }
        }
    }
}