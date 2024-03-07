using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CursorFixer : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
