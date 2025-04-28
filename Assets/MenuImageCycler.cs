using UnityEngine;
using UnityEngine.UI; // Needed for RawImage

public class MenuImageCycler : MonoBehaviour
{
    public RawImage menuRawImage; // Assign your RawImage here
    public Texture[] textures;    // Assign your textures here

    private int currentTextureIndex = 0;

    void OnMouseDown()
    {
        CycleImage();
    }

    public void CycleImage()
    {
        if (textures.Length == 0)
        {
            Debug.LogWarning("[MenuImageCycler] No textures assigned!");
            return;
        }

        currentTextureIndex = (currentTextureIndex + 1) % textures.Length; // Loop through
        menuRawImage.texture = textures[currentTextureIndex];
        Debug.Log("[MenuImageCycler] Changed to texture index: " + currentTextureIndex);
    }
}