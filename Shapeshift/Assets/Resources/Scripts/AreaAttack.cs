using UnityEngine;
using System.Collections;

public class AreaAttack : MonoBehaviour {

    private float _attackForce;
    private float _stunTime;
    private float _winModifier;
    private float _loseModifier;
    private float _neutralModifier;

    private ShapeType _attackingShape;

    private bool _hitSuccess = false;
    public bool HitSuccess
    {
        get
        {
            return _hitSuccess;
        }
    }

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

    void OnTriggerEnter(Collider other)
    {
        var shapeShiferHit = other.gameObject.GetComponent<ShapeShifter>();
        if(shapeShiferHit == null)
        {
            return;
        }
        // TODO: Change topdown movement to TopDownMovement;
        if (shapeShiferHit.PlayerID != _spawnerID && !_hitSuccess)
        {
            var forceDirection = Vector3.ProjectOnPlane((other.transform.position - transform.position).normalized, new Vector3(0, 1, 0));
            var shapeMod = GetShapeMultiplier(_attackingShape, other.GetComponent<ShapeShifter>().CurrentShape);
            other.gameObject.GetComponent<Stunnable>().Stun(Mathf.Clamp(shapeMod * _stunTime, 0, _stunTime));
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().AddForce(_attackForce * shapeMod * forceDirection, ForceMode.Impulse);
            _hitSuccess = true;
        }
    }

    float GetShapeMultiplier(ShapeType atacker, ShapeType defender)
    {
        int result = (atacker - defender + 3) % 3;

        switch(result)
        {
            case 0: // attacker = defender
                return _neutralModifier;
            case 1:
                return _winModifier;
            case 2:
                return _loseModifier;
        }

        return 0;
    }
}
