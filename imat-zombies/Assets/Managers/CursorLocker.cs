using UnityEngine;

public static class CursorLocker
{
    public static void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void UnLockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}