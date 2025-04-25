using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;     // The default main camera
    public Camera zoomCamera;     // The zoomed-in camera

    private bool isZoomedIn = false;

    void Start()
    {
        // Start with main camera enabled, zoom camera disabled
        mainCamera.enabled = true;
        zoomCamera.enabled = false;

        // Make sure main camera is tagged correctly
        mainCamera.tag = "MainCamera";
        zoomCamera.tag = "Untagged";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isZoomedIn)
        {
            SwitchToZoomCamera();
        }

        if (Input.GetKeyDown(KeyCode.F) && isZoomedIn)
        {
            SwitchToMainCamera();
        }
    }

    void SwitchToZoomCamera()
    {
        isZoomedIn = true;

        mainCamera.enabled = false;
        zoomCamera.enabled = true;

        mainCamera.tag = "Untagged";
        zoomCamera.tag = "MainCamera";
    }

    void SwitchToMainCamera()
    {
        isZoomedIn = false;

        zoomCamera.enabled = false;
        mainCamera.enabled = true;

        zoomCamera.tag = "Untagged";
        mainCamera.tag = "MainCamera";
    }
}