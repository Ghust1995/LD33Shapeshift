using UnityEngine;
using System.Collections;

public class GameManager : MultiplayerBehaviour {

	public static bool gameStart = false;    
	public GameObject PlayerPrefab;

	public void EnableControls(){
		gameStart = true;
	}

	void Start(){
		PlayerPrefab = Resources.Load<GameObject>("Prefabs/player");
	}

	void Update(){
		if (Input.GetButtonDown(AxisString("Attack")) && !GameManager.gameStart){
				Debug.Log(PlayerPrefab);
				GameObject.Find("CameraHolder1").GetComponent<Animator>().SetTrigger("A is Pressed");
				GameObject instantiated = Instantiate(PlayerPrefab, new Vector3(2, -3, 0), Quaternion.identity) as GameObject;
				instantiated.gameObject.name = "player1";
				instantiated = Instantiate(PlayerPrefab, new Vector3(-2, -3, 0), Quaternion.identity) as GameObject;
				instantiated.gameObject.name = "player2";
			}
	}
}
