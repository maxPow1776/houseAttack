using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int Hp;

    public virtual void Death()
    {
        if (gameObject.GetComponent<PlayerController>())
        {
            SceneManager.LoadScene("FirstLevel", LoadSceneMode.Single);
        }
        if (gameObject.GetComponent<EnemyController>() || gameObject.GetComponent<AutoMove>())
        {
            Destroy(gameObject);
        }
    }
}
