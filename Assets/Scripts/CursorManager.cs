using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private bool isCursorLocked;
    private bool canToggleCursorLock = true;

    private void Start()
    {
        if (isCursorLocked == true)
        LockCursor();
    }

    private void Update()
    {
        // Check if the left control (Ctrl) key is pressed to toggle cursor lock
        if (Input.GetKeyDown(KeyCode.LeftControl) && canToggleCursorLock)
        {
            ToggleCursorLock();
        }

        // Check if the Escape key was released to allow toggling cursor lock again
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            canToggleCursorLock = true;
        }
    }

    private void ToggleCursorLock()
    {
        isCursorLocked = !isCursorLocked;
        if (isCursorLocked)
        {
            LockCursor();
        }
        else
        {
            UnlockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
