using UnityEngine;
using System.Collections;

public class AreaAttacker : MultiplayerBehaviour {

    Rigidbody2D rigidBody;

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

    AreaAttack areaAttack;

    [SerializeField]
    public float ATTACK_FORCE;

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
        rigidBody = GetComponent<Rigidbody2D>();
        timeSinceLast = Cooldown;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButton(AxisString("Attack")) && timeSinceLast > Cooldown)
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
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Invoke("Attack", StartLag);
    }

    void Attack()
    {
        //Debug.Log("Attacking");

        var aa = (GameObject)Instantiate(areaAttackPrefab, transform.position, transform.rotation);
        areaAttack = aa.GetComponent<AreaAttack>();
        areaAttack.Initialize(PlayerID, ATTACK_FORCE, STUN_TIME, WIN_MODIFIER, LOSE_MODIFIER, NEUTRAL_MODIFIER, GetComponent<ShapeShifter>().CurrentShape);
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
        if(hitMiss)
        {
            GetComponent<ShapeShifter>().ShiftShape();
        }
        _isAttacking = false;
    }
}
