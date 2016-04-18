using UnityEngine;
using System.Collections;

public class AreaAttack : MonoBehaviour {

    private float _attackForce;
    private float _stunTime;
    private float _winModifier;
    private float _loseModifier;
    private float _neutralModifier;
    private float _upPower;

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

    public void Initialize(int playerID, float attackForce, float stunTime, float winModifier, float loseModifier, float neutralModifier, ShapeType attackingShape, float upPower)
    {
        _spawnerID = playerID;
        _attackForce = attackForce;
        _stunTime = stunTime;
        _attackingShape = attackingShape;
        _winModifier = winModifier;
        _loseModifier = loseModifier;
        _neutralModifier = neutralModifier;
        _upPower = upPower;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        var shapeShiferHit = other.gameObject.GetComponentInParent<ShapeShifter>();
        if(shapeShiferHit == null)
        {
            return;
        }
        // TODO: Change topdown movement to TopDownMovement;
        else if (shapeShiferHit.PlayerID != _spawnerID && !_hitSuccess)
        {
            var hit = shapeShiferHit.gameObject;

            var forceDirection = Vector3.ProjectOnPlane((hit.transform.position - transform.position).normalized, new Vector3(0, 1, 0));
            
            var shapeMod = GetShapeMultiplier(_attackingShape, hit.GetComponent<ShapeShifter>().CurrentShape);
            hit.GetComponent<Stunnable>().Stun(Mathf.Clamp(_stunTime/shapeMod*shapeMod, 0, _stunTime));
            hit.GetComponent<Rigidbody>().velocity = Vector3.zero;
            var force = _attackForce * shapeMod * forceDirection;
            force += new Vector3(0, 1, 0) * _upPower;
            Debug.Log(force);
            hit.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
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
