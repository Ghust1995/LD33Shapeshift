using UnityEngine;
using System.Collections;

public class Player : MultiplayerBehaviour {
    
	public void Die(){
		GameObject.Find("CameraHolder1").GetComponent<Animator>().SetTrigger("Game Ended");
		gameObject.name = "playerDead";
		GameManager.gameStart = false;
        GameManager.gameStarting = false;
    }

}