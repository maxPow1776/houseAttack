using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTargetForBomb : MonoBehaviour
{
    [SerializeField] private GameObject[] _players;
    [SerializeField] private Button _bombButton;


    private void OnMouseDown()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            if (_players[i] != null)
            {
                var throwBomb = _players[i].GetComponent<ThrowBomb>();
                if (throwBomb != null)
                {
                    throwBomb.Target = gameObject;
                    throwBomb.StartFight();
                }
            }
        }
        _bombButton.interactable = false;
    }
}
