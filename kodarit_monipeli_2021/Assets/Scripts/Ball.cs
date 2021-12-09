using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Ball : MonoBehaviourPunCallbacks
{
    public TMP_Text SininnenTeksti;
    public TMP_Text PunainnenTeksti;
    public int _SininenPisteet = 0;
    public int _PunainenPisteet = 0;
    

    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    
    }

    private void UpdateScoreText(){
        
        _PunainenPisteet = (int)PhotonNetwork.CurrentRoom.CustomProperties["PunainenPisteet"];
        _SininenPisteet = (int)PhotonNetwork.CurrentRoom.CustomProperties["SininenPisteet"];
        
        PunainnenTeksti.text = "Punainen joukkue" + _PunainenPisteet;
        SininnenTeksti.text = "Sininen joukkue" + _SininenPisteet;
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        UpdateScoreText();
        
    }

    void OnTriggerEnter(Collider other) {
        
        Vector3 startPoint = new Vector3(0, 1, 0);

        if(other.tag == "SininenMaali"){

            _PunainenPisteet += 1;
            PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() {{"PunainenPisteet", _PunainenPisteet}});
            PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() {{"SiniinenPisteet", _SininenPisteet}});
            
        }

        if(other.tag == "PunainenMaali"){

            _SininenPisteet += 1;

        }
        
        transform.position = startPoint;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        
    }


}
