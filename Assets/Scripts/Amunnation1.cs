using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amunnation1 : MonoBehaviour
{
    [SerializeField] private Button _bombButton;

    private void OnMouseDown()
    {
        _bombButton.interactable = true;
        Destroy(gameObject, 0.1f);
    }
}
