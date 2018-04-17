using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueDetect : MonoBehaviour {

    #region Varibales

    private bool HaColisionadoConElJugador = false;
    public int PuntosGanados = 1;
    #endregion
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!HaColisionadoConElJugador && collision.gameObject.tag == "Player")
        {
            Debug.Log("Colision Afectada");
            HaColisionadoConElJugador = true;

            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", PuntosGanados);
        }
        
    }
}
