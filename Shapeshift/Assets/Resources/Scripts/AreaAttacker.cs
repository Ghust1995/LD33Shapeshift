using UnityEngine;
using System.Collections;

public class AreaAttacker : MultiplayerBehaviour {

    Rigidbody2D rigidbody;

    [SerializeField]
    float StartLag = 0.5f;

    [SerializeField]
    float MoveLag = 1.0f;

    [SerializeField]
    float EndLag = 0.0f;

    [SerializeField]
    float Cooldown = 2.0f;

    float timeSinceLast = 0.0f;

    private bool isAttacking = false;


    public GameObject areaAttackPrefab;

    AreaAttack areaAttack;

    [SerializeField]
    public float ATTACK_FORCE;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButton(AxisString("Attack")) && timeSinceLast > Cooldown)
        {
            StartAttack();
        }
        if(!isAttacking)
        {
            timeSinceLast += Time.deltaTime;
        }        
    }

    void StartAttack()
    {
        Debug.Log("Starting attack");

        timeSinceLast = 0.0f;
        isAttacking = true;
        Invoke("Attack", StartLag);
    }

    void Attack()
    {
        Debug.Log("Attacking");

        var aa = (GameObject)Instantiate(areaAttackPrefab, transform.position, transform.rotation);
        areaAttack = aa.GetComponent<AreaAttack>();
        areaAttack.Initialize(PlayerID, ATTACK_FORCE);
        Invoke("EndAttack", MoveLag);
    }

    void EndAttack()
    {
        Debug.Log("Ending Attack");

        Destroy(areaAttack.gameObject);
        Invoke("EndAttackLag", EndLag);
    }

    void EndAttackLag()
    {
        Debug.Log("Ending Attack Lag");
        isAttacking = false;
    }
}
