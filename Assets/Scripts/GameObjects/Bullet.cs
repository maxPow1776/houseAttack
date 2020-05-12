using UnityEngine;
using UnityEngine.AI;

public class Bullet : Bomb
{
    public void BulletShoot(GameObject Target)
    {
        this.Target = Target;
    }
}
