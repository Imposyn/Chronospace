using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform
    public float smoothSpeed = 0.125f; // How quickly the camera follows the player
    public Vector3 offset; // Offset of the camera from the player

    private bool shouldFollow = false;

    void FixedUpdate()
    {
        if (!shouldFollow)
        {
            if (!IsInView(target.position))
            {
                shouldFollow = true;
                SwitchScene();
            }
        }
        else
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target); // Make the camera look at the player
        }
    }

    bool IsInView(Vector3 targetPosition)
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(targetPosition);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 0;
    }

    void SwitchScene()
    {
        SceneManager.LoadScene("Map2");
    }
}