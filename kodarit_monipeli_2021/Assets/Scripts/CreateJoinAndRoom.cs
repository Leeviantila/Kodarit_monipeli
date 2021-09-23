using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;


public class CreateJoinAndRoom : MonoBehaviourPunCallbacks
{

    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    
   public void CreateRoom(){
       // Huoneen luominen nimellä "parametri"

       PhotonNetwork.CreateRoom(createInput.text);
    
   } 

    public void JoinRoom(){
        // Liitytään huoneeseen nimellä "parametri"

        PhotonNetwork.JoinRoom(joinInput.text);

    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");

    }






}
