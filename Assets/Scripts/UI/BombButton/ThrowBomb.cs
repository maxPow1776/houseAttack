using System.Collections;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    public GameObject Target;
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private GameObject _interface;
    [SerializeField] private GameObject _placeForBomb;

    public void StartFight()
    {
        var bomb = Instantiate(_bombPrefab, _placeForBomb.transform.position, Quaternion.identity);
        var currentBomb = bomb.GetComponent<Bomb>();
        if (currentBomb != null)
        {
            currentBomb.Target = Target;
        }
        var bombButton = _interface.GetComponent<AttackButton>();
        if (bombButton != null)
        {
            bombButton.CancleTarget();
        }
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(2);
        var winPanel = _interface.GetComponent<WinPanel>();
        if (winPanel != null)
            winPanel.CheckEnemies();
    }
}
