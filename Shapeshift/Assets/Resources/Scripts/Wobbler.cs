using UnityEngine;
using System.Collections;

public class Wobbler : MultiplayerBehaviour {
    [SerializeField]
    float radius;

    [SerializeField]
    float h = 1;

    [SerializeField]
    float v = 1;

    Vector3 center;

    [SerializeField]
    float speed;

    float time = 0;

    void Start()
    {
        center = transform.position + new Vector3(0, -radius, 0);
    }

    // Update is called once per frame
    void Update () {

        var d = new Vector3(
           Input.GetAxis(AxisString("Horizontal")) * h, -Input.GetAxis(AxisString("Vertical")) * v, 0);
            
        d = Vector3.ClampMagnitude(d, 0.5f) * 2;
        Debug.Log(d);

        // transform.position = center + radius * new Vector3(Mathf.Cos(speed * time) * h, Mathf.Sin(speed * time) * v, 0);

        transform.position = center + radius * d;
        time += Time.deltaTime;
	}
}
