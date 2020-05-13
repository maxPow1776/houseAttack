using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class AmmunationForMultiplayer : MonoBehaviour
{
    [SerializeField] private Button _shootButton;

    private void OnMouseDown()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            _shootButton.interactable = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
