using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera defaultCamera;
    public Camera followCamera;
    public Transform player;
    public Vector3 followOffset = new Vector3(0, 1.8f, -3f);  // Back and up

    private bool usingFollowCam = false;

    void Start()
    {
        defaultCamera.enabled = true;
        followCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !usingFollowCam)
        {
            SwitchToFollowCam();
        }

        if (Input.GetKeyDown(KeyCode.F) && usingFollowCam)
        {
            SwitchToDefaultCam();
        }

        if (usingFollowCam && player != null)
        {
            // World-space offset: always behind the player regardless of rotation
            Vector3 offsetPosition = player.position + player.rotation * followOffset;
            followCamera.transform.position = offsetPosition;

            // Optional: look at the player's eye level
            followCamera.transform.LookAt(player.position + Vector3.up * 1.5f);
        }
    }

    private void SwitchToFollowCam()
    {
        usingFollowCam = true;
        defaultCamera.enabled = false;
        followCamera.enabled = true;
    }

    private void SwitchToDefaultCam()
    {
        usingFollowCam = false;
        defaultCamera.enabled = true;
        followCamera.enabled = false;
    }
}