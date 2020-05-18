using UnityEngine;

public class SetTargetForMultiplayer : MonoBehaviour
{
    public GameObject Player;

    private void OnMouseDown()
    {
        if (Player != null)
        {
            var fightWithEnemyForMultiplayer = Player.GetComponent<FightWithEnemyForMultiplayer>();
            if (fightWithEnemyForMultiplayer != null)
            {
                fightWithEnemyForMultiplayer.Target = gameObject;
                fightWithEnemyForMultiplayer.StartFight();
            }
        }
    }
}
