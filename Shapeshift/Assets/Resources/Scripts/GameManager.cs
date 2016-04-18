using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MultiplayerBehaviour
{

    public static bool gameStart = false;
    public static bool gameStarting = false;
    public GameObject PlayerPrefab;
    public static int score1, score2;
    public static GameObject easter1, easter2;

    public void EnableControls()
    {
        gameStart = true;
    }

    void Start()
    {
        PlayerPrefab = Resources.Load<GameObject>("Prefabs/player");
        score1 = 0;
        score2 = 0;
        easter1 = GameObject.Find("EasterEgg1").gameObject;
        easter2 = GameObject.Find("EasterEgg2").gameObject;
        easter1.gameObject.SetActive(false);
        easter2.gameObject.SetActive(false);
        GameObject.Find("Player Scores").GetComponent<Text>().text = GameManager.score1 + "-" + GameManager.score2;
    }

    void Update()
    {
        if (!GameManager.gameStart && !gameStarting)
        {
            if (Input.GetButtonDown(AxisString("Attack")))
            {
                gameStarting = true;
                GetComponent<Animator>().SetTrigger("A is Pressed");
                GameObject instantiated = Instantiate(PlayerPrefab, new Vector3(-2, -3, 0), Quaternion.identity) as GameObject;
                Destroy(GameObject.Find("player2"));
                Destroy(GameObject.Find("player1"));
                instantiated.gameObject.name = "player1";
                instantiated = Instantiate(PlayerPrefab, new Vector3(2, -3, 0), Quaternion.identity) as GameObject;
                instantiated.gameObject.name = "player2";
            }
            if (Input.GetButtonDown("Exit"))
            {
                Application.Quit();
            }
        }
    }
}
