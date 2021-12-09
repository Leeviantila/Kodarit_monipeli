using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;


public class CreateJoinAndRoom : MonoBehaviourPunCallbacks
{

    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    
   public void CreateRoom(){


       RoomOptions roomOptions = new RoomOptions();
       ExitGames.Client.Photon.Hashtable roomCustomProps = new ExitGames.Client.Photon.Hashtable();
       roomCustomProps.Add("PunainenPisteet", 0);
       roomCustomProps.Add("SininenPisteet", 0);
       roomOptions.CustomRoomProperties = roomCustomProps;
       // Huoneen luominen nimellä "parametri"

        PhotonNetwork.CreateRoom(createInput.text, roomOptions);

        
    
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
