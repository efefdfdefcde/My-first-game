using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Start()
    {
        PauseMenu._cursorAction += CursorStatus;
        DeathScreen._cursorAction += CursorStatus;
        CursorStatus(false);
    }

    private void CursorStatus(bool status)
    {
        if (status)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }

    private void OnDestroy()
    {
        PauseMenu._cursorAction -= CursorStatus;
        DeathScreen._cursorAction -= CursorStatus;
        Cursor.visible = true;
    }

}
