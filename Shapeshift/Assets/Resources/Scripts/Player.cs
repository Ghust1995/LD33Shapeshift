using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MultiplayerBehaviour {
    
	public void Die(){
		if(this.gameObject.name == "player1")
			GameManager.score2++;
		if(this.gameObject.name == "player2")
			GameManager.score1++;
		GameObject.Find("Player Scores").GetComponent<Text>().text = GameManager.score2 + "-" + GameManager.score1;
		if(GameManager.score1>99 || GameManager.score2>99)
			ShowEasterEgg();
		GameObject.Find("CameraHolder1").GetComponent<Animator>().SetTrigger("Game Ended");
		gameObject.name = "playerDead";
		GameManager.gameStart = false;
        GameManager.gameStarting = false;
    }

    public void ShowEasterEgg(){
		GameManager.easter1.gameObject.SetActive(true);
		GameManager.easter2.gameObject.SetActive(true);
    }

}