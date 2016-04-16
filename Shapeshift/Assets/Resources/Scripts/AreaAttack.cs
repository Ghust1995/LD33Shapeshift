using UnityEngine;
using System.Collections;

public class AreaAttack : MonoBehaviour {

    private float _attackForce;
    private float _stunTime;
    private int _spawnerID;
    // Use this for initialization
	void Awake () {
        gameObject.SetActive(false);
	}

    public void Initialize(int playerID, float attackForce, float stunTime)
    {
        _spawnerID = playerID;
        _attackForce = attackForce;
        _stunTime = stunTime;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var shapeShiferHit = other.gameObject.GetComponent<ShapeShifter>();
        // TODO: Change topdown movement to TopDownMovement;
        if (shapeShiferHit.PlayerID != _spawnerID)
        {
            var forceDirection = (other.transform.position - transform.position).normalized;
            Debug.Log("HIT SOMETHING: "+ _attackForce * forceDirection + "--STUN TIME: " + _stunTime);
            other.gameObject.GetComponent<Stunnable>().Stun(_stunTime);

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(_attackForce * forceDirection, ForceMode2D.Impulse);
        }
    }
}
