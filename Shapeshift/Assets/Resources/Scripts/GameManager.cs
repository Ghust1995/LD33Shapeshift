using UnityEngine;
using System.Collections;

public class GameManager : MultiplayerBehaviour {

	public static bool gameStart = false;
    public static bool gameStarting = false;
    public GameObject PlayerPrefab;

	public void EnableControls(){
		gameStart = true;
	}

	void Start(){
		PlayerPrefab = Resources.Load<GameObject>("Prefabs/player");
	}

	void Update(){
		if (Input.GetButtonDown(AxisString("Attack")) && !GameManager.gameStart && !gameStarting) {
                gameStarting = true;

                GetComponent<Animator>().SetTrigger("A is Pressed");
				GameObject instantiated = Instantiate(PlayerPrefab, new Vector3(2, -3, 0), Quaternion.identity) as GameObject;            
                Destroy(GameObject.Find("player2"));
                Destroy(GameObject.Find("player1"));
                instantiated.gameObject.name = "player1";
				instantiated = Instantiate(PlayerPrefab, new Vector3(-2, -3, 0), Quaternion.identity) as GameObject;
				instantiated.gameObject.name = "player2";
			}
	}
}
