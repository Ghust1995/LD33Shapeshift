using UnityEngine;
using System.Collections;

public class Player : MultiplayerBehaviour {

    public AudioClip MoveSound;

    void Update()
    {
        if(transform.position.y < -10000)
        {
            Destroy(this.gameObject);
        }
    }

    public void Die(){
        if (GameManager.gameStart != false)
        {
            GameObject.Find("CameraHolder1").GetComponent<Animator>().SetTrigger("Game Ended");
            gameObject.name = "playerDead";
            GameManager.gameStart = false;
            GameManager.gameStarting = false;
        }
    }

}