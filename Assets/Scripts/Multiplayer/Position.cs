using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour//, IPunObservable
{
    public bool IsEmpty = true;

    /*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(IsEmpty);
        } else
        {
            IsEmpty = (bool)stream.ReceiveNext();
        }
    }*/
}
