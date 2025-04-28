using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Only needed if you want to load next scene after

public class ImageCutscene : MonoBehaviour
{
    public RawImage displayImage; // Assign your RawImage UI element
    public Texture[] cutsceneTextures; // Assign your PNG images (Textures)
    public float imageDisplayTime = 2f; // How long each image stays on screen

    private int currentImageIndex = 0;
    private float timer = 0f;

    void Start()
    {
        if (cutsceneTextures.Length > 0 && displayImage != null)
        {
            displayImage.texture = cutsceneTextures[0];
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
                Debug.Log("[Cutscene] Cutscene finished.");
                // Optional: Load next scene
                // SceneManager.LoadScene("YourNextSceneName");
                displayImage.gameObject.SetActive(false); // Hide image if done
            }
        }
    }
}