using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnetToServer : MonoBehaviourPunCallbacks
{


    // Start is called before the first frame update
    void Start()
    {
        //Yhdistää photonin palvelimeen.
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        //Yhdistää lobbyyn
        PhotonNetwork.JoinLobby();

        
    }

    public override void OnJoinedLobby(){
        
        SceneManager.LoadScene("Lobby");
        

    }



    
}
