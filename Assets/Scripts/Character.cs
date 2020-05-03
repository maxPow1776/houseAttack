using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int Hp;

    public void Death()
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
