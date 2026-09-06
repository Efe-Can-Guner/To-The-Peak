using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ManualPlayButton : MonoBehaviour
{
    public RectTransform buttonRect;   
    public Canvas canvas;               

    void Update()
    {
        bool tapped = false;
        Vector2 screenPos = Vector2.zero;

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            tapped = true;
            screenPos = Mouse.current.position.ReadValue();
        }

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            tapped = true;
            screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
        }

        if (tapped)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(buttonRect, screenPos, canvas.worldCamera))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}