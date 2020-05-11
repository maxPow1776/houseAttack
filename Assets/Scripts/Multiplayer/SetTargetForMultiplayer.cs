using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTargetForMultiplayer : MonoBehaviour
{
    public GameObject Player;
    public Button ShootButton;


    private void OnMouseDown()
    {
        if (Player != null)
        {
            var fightWithEnemy = Player.GetComponent<FightWithEnemy>();
            if (fightWithEnemy != null)
            {
                fightWithEnemy.Target = gameObject;
                fightWithEnemy.StartFight();
            }
        }
        ShootButton.interactable = false;
    }
}
