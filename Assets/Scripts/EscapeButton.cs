using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeButton : MonoBehaviour
{
    [SerializeField] private Button button;
    void Update()
    {
        if (button == null)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            button.onClick.Invoke();
        }
    }
}
