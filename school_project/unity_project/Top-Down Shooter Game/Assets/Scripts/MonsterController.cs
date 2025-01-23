using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    private Animator animator;
    BoxCollider2D collider;
    Rigidbody2D rigid;

    public float speed;
    public Rigidbody2D target;
    public float originalSpeed;
    private bool cooltime = false;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        if (tag == "Green Slime")
        {
            maxHealth = 2;
            currentHealth = 2;
            damage = 5;
            speed = 1.0f;
            originalSpeed = speed;
        }
        else if (tag == "Poison Slime")
        {
            maxHealth = 3;
            currentHealth = 3;
            damage = 7;
            speed = 1.3f;
            originalSpeed = speed;
        }
        else if (tag == "Fire Slime")
        {
            maxHealth = 4;
            currentHealth = 4;
            damage = 8;
            speed = 1.7f;
            originalSpeed = speed;
        }
    }

    private void Update()
    {
        if (cooltime)
        {
            speed = 0;
            return;
        }

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        animator.SetFloat("MoveX", nextVec.x);
        animator.SetFloat("MoveY", nextVec.y);
        rigid.MovePosition(rigid.position + nextVec);

        if (currentHealth <= 0)
        {
            speed = 0;
            animator.SetTrigger("Die");
            collider.enabled = false;
        }
    }

    public void changeHealth(int hp)
    {
        currentHealth += hp;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null && !cooltime)
        {
            StartCoroutine(ResetToRunAfterDelay(2.0f));
            cooltime = true;
            animator.SetTrigger("Attack");
            Debug.Log("Get Damage" + damage);
            player.changeHealth(-damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int power = GameManager.Instance.player.power;
        GameManager gameManager = GameManager.Instance;
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            currentHealth -= power;
            if (currentHealth <= 0)
            {
                Destroy(gameObject, 0.8f);
                GameManager.Instance.KilledMonster(gameObject);
            }
        }
    }

    IEnumerator ResetToRunAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("Run");
        speed = originalSpeed;
        cooltime = false;
    }
}