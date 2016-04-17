using UnityEngine;
using System.Collections;

public class Player : MultiplayerBehaviour {
    
	public void Die(){
		GameObject.Find("CameraHolder1").GetComponent<Animator>().SetTrigger("Game Ended");
		if(gameObject.name == "player1")
			Destroy(GameObject.Find("player2"));
		else
			Destroy(GameObject.Find("player1"));
		gameObject.name = "playerDead";
		GameManager.gameStart = false;
	}

}