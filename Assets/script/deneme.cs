using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDebugger : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Mouse tıklama pozisyonu: " + Mouse.current.position.ReadValue());
        }
    }
}