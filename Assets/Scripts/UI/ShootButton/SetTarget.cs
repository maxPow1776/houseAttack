using UnityEngine;
using UnityEngine.UI;

public class SetTarget : MonoBehaviour
{
    [SerializeField] private GameObject[] _players;
    [SerializeField] private Button _shootButton;


    private void OnMouseDown()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            if (_players[i] != null)
            {
                var fightWithEnemy = _players[i].GetComponent<FightWithEnemy>();
                if (fightWithEnemy != null)
                {
                    fightWithEnemy.Target = gameObject;
                    fightWithEnemy.StartFight();
                }
            }
        }
        _shootButton.interactable = false;
    }
}
