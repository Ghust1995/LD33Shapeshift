using UnityEngine;
using System.Collections;

public class AreaAttack : MonoBehaviour {

    private float _attackForce;
    private int _spawnerID;
    // Use this for initialization
	void Awake () {
        gameObject.SetActive(false);
	}

    public void Initialize(int playerID, float attackForce)
    {
        _spawnerID = playerID;
        _attackForce = attackForce;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Change topdown movement to TopDownMovement;
        if (other.gameObject.GetComponent<TopDownMovement>().PlayerID != _spawnerID)
        {
            var forceDirection = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(_attackForce * forceDirection);
        }
    }
}
