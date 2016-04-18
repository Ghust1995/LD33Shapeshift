using UnityEngine;
using System.Collections;

public class AreaAttacker : MultiplayerBehaviour {

    Rigidbody rigidBody;

    [SerializeField]
    float StartLag = 0.5f;

    [SerializeField]
    float MoveLag = 1.0f;

    [SerializeField]
    float EndLag = 0.0f;

    [SerializeField]
    float Cooldown = 2.0f;

    float timeSinceLast = 0.0f;

    private bool _isAttacking = false;
    public bool IsAttacking
    {
        get
        {
            return _isAttacking;
        }
    }


    public GameObject areaAttackPrefab;
    public GameObject missPrefab;

    AreaAttack areaAttack;
    MissMark missObject;

    [SerializeField]
    public float ATTACK_FORCE;

    [SerializeField]
    public float UP_FORCE;

    [SerializeField]
    public float STUN_TIME;

    [SerializeField]
    public float WIN_MODIFIER;

    [SerializeField]
    public float LOSE_MODIFIER;

    [SerializeField]
    public float NEUTRAL_MODIFIER;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        timeSinceLast = Cooldown;
    }


    // Update is called once per frame
    void Update ()
    {
		
        GetComponent<Animator>().SetFloat("Cooldown", timeSinceLast - Cooldown);
        if (Input.GetButton(AxisString("Attack")) && timeSinceLast > Cooldown && GameManager.gameStart)
        {
            StartAttack();
        }
        if(!_isAttacking)
        {
            timeSinceLast += Time.deltaTime;
        }        
    }

    void StartAttack()
    {
        //Debug.Log("Starting attack");
        timeSinceLast = 0.0f;
        _isAttacking = true;
        //GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 15, ForceMode.Impulse);
        Invoke("Attack", StartLag);
    }

    void Attack()
    {
        //Debug.Log("Attacking");
        GetComponent<Rigidbody>().AddForce(Vector3.up * -40, ForceMode.Impulse);
        var aa = (GameObject)Instantiate(areaAttackPrefab, transform.position, transform.rotation);
        areaAttack = aa.GetComponent<AreaAttack>();
        areaAttack.Initialize(PlayerID, ATTACK_FORCE, STUN_TIME, WIN_MODIFIER, LOSE_MODIFIER, NEUTRAL_MODIFIER, GetComponent<ShapeShifter>().CurrentShape, UP_FORCE);
        Invoke("EndAttack", MoveLag);
    }

    bool hitMiss;
    void EndAttack()
    {
        //Debug.Log("Ending Attack");
        hitMiss = !areaAttack.HitSuccess;
        Destroy(areaAttack.gameObject);
        Invoke("EndAttackLag", EndLag);
    }

    void EndAttackLag()
    {
        //Debug.Log("Ending Attack Lag");
        if (hitMiss)
        {
            GetComponent<ShapeShifter>().ShiftShape();
            var mm = (GameObject)Instantiate(missPrefab, transform.position + Vector3.up, Quaternion.identity);
            missObject = mm.GetComponent<MissMark>();
            missObject.thingToFollow = transform;

        }
        _isAttacking = false;
    }
}
