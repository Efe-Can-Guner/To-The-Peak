using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ManualButtonRestart : MonoBehaviour
{
    [Header("Restart Butonu")]
    public RectTransform restartButtonRect;
    public GameObject gameOverPanel;

    [Header("Home / Menü Butonu")]
    public RectTransform homeButtonRect;

    [Header("Ortak")]
    public Canvas canvas;

    void Update()
    {
    
        if (gameOverPanel == null || !gameOverPanel.activeInHierarchy)
            return;

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

        if (!tapped)
            return;

       
        if (restartButtonRect != null &&
            RectTransformUtility.RectangleContainsScreenPoint(restartButtonRect, screenPos, canvas.worldCamera))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

      
        if (homeButtonRect != null &&
            RectTransformUtility.RectangleContainsScreenPoint(homeButtonRect, screenPos, canvas.worldCamera))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenü");
            return;
        }
    }
}