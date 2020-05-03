using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] GameObject[] _enemies;
    [SerializeField] GameObject _winPanel;
    private int _count = 0;

    public void CheckEnemies()
    {
        for(int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                _count = 0;
                break;
            }
            else
            {
                _count++;
            }
        }
        if (_count == 4)
            WinGame();
    }

    public void WinGame()
    {
        _winPanel.SetActive(true);
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("FirsLevel", LoadSceneMode.Single);
    }
}
