using UnityEngine;
using System.Collections;

public class AreaAttack : MonoBehaviour {

    private float _attackForce;
    private float _stunTime;
    private float _winModifier;
    private float _loseModifier;
    private float _neutralModifier;

    private ShapeType _attackingShape;


    private int _spawnerID;
    // Use this for initialization
	void Awake () {
        gameObject.SetActive(false);
	}

    public void Initialize(int playerID, float attackForce, float stunTime, float winModifier, float loseModifier, float neutralModifier, ShapeType attackingShape)
    {
        _spawnerID = playerID;
        _attackForce = attackForce;
        _stunTime = stunTime;
        _attackingShape = attackingShape;
        _winModifier = winModifier;
        _loseModifier = loseModifier;
        _neutralModifier = neutralModifier;
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
            var shapeMod = GetShapeMultiplier(_attackingShape, other.GetComponent<ShapeShifter>().CurrentShape);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(_attackForce * shapeMod * forceDirection, ForceMode2D.Impulse);
        }
    }

    float GetShapeMultiplier(ShapeType atacker, ShapeType defender)
    {
        int result = (atacker - defender) % 3;

        switch(result)
        {
            case 0: // attacker = defender
                return _neutralModifier;
            case 1:
                return _winModifier;
            case 2:
                return _winModifier;
        }

        return 0;
    }
}
