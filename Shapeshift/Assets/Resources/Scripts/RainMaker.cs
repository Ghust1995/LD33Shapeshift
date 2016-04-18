    using UnityEngine;
    using System.Collections;

public class RainMaker : MonoBehaviour
{

    public Mesh[] meshes;
    public Color[] colors = { Color.blue, Color.red, Color.green };
    public GameObject rainDropPrefab;

    public float rainFrequency;

    private bool isInvoking = true;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("MakeItRain", 0f, 1 / rainFrequency);
    }

    void Update()
    {
        if(!GameManager.gameStart && !GameManager.gameStarting && !isInvoking)
        {
            isInvoking = true;
            InvokeRepeating("MakeItRain", 0f, 1 / rainFrequency);
        }
        else if(GameManager.gameStart || GameManager.gameStarting)
        {
            isInvoking = false;
            CancelInvoke("MakeItRain");
        }
    }

    void MakeItRain()
    {
        GameObject instantiated = Instantiate(rainDropPrefab, new Vector3(Random.Range(0f, 25f), Random.Range(0f, 10f), Random.Range(0f, 20f)), Quaternion.identity) as GameObject;
        instantiated.transform.SetParent(GameObject.Find("Rain Maker").transform, false);
        int r = Random.Range(0, 3);
        instantiated.GetComponent<MeshFilter>().mesh = meshes[r];
        instantiated.GetComponent<MeshRenderer>().material.color = colors[r];
        instantiated.GetComponent<Rigidbody>().AddTorque(300 * Random.insideUnitSphere);
    }
}
