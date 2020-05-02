using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private Button _shootButton;

    private void OnMouseDown()
    {
        _shootButton.interactable = true;
        Destroy(gameObject, 0.1f);
    }
}
