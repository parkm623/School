using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player instance;

    [SerializeField]
    private Animator animator;
    private Camera characterCamera;
    public GameManager gameManager;

    public float moveSpeed = 5f; 
    private float originalMoveSpeed; 
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject bulletPrefab1;  
    [SerializeField]
    private GameObject bulletPrefab2; 
    [SerializeField]
    private GameObject bulletPrefab3;  
    [SerializeField]
    private float bulletSpeed = 5f;  
    [SerializeField]
    private float shootCooldown = 0.32f;  

    private float lastShootTime = 0f; 
    private bool isShooting = false;  

    public AudioClip shootSound1;
    public AudioClip shootSound2;
    public AudioClip shootSound3;

    AudioSource shootSound;
    public int power;
    public int maxHp;
    public int CurHp;
    public float stamina;
    public float curStamina;

    private float staminaBoost = 0.1f; 

    public Slider hpSlider;
    public Slider steminaSlider;

    private Vector3 originalPosition;
    [SerializeField] public GameData gameData;
    private void Awake()
    {
        characterCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
        shootSound = GetComponent<AudioSource>();
        CurHp = maxHp;
        curStamina = stamina;
        hpSlider.maxValue = maxHp;
        steminaSlider.maxValue = stamina;
        Debug.Log(curStamina);
        power = 1;
        originalPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = CurHp;
        steminaSlider.value = curStamina;
        if (!GameManager.Instance.CheckPause() && GameManager.Instance.CheckPlay())
        {
            HandleMovement();
            HandleShooting();
            if (CurHp <= 0)
            {
                animator.SetTrigger("Die");
                rb.linearVelocity = Vector2.zero;
                GameManager.Instance.SetPlayerDied();
            }
        }
    }

    public void HandleMovement()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDir = new Vector2(moveX, moveY).normalized;



        if (moveDir != Vector2.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (curStamina < 0)
                {
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isWalking", true);
                    rb.linearVelocity = moveDir * moveSpeed;

                }
                else
                {
                    animator.SetBool("isRunning", true);
                    animator.SetBool("isWalking", false);
                    rb.linearVelocity = moveDir * moveSpeed * 1.5f;
                    curStamina -= 0.2f;
                }
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
                rb.linearVelocity = moveDir * moveSpeed;
                if (curStamina < 100)
                {
                    curStamina += staminaBoost;
                }

            }

            animator.SetFloat("MovementX", moveDir.x);
            animator.SetFloat("MovementY", moveDir.y);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            rb.linearVelocity = Vector2.zero;

        }
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButton(0)) 
        {
            if (Time.time >= lastShootTime + shootCooldown) 
            {
                Shoot();
                lastShootTime = Time.time; 
                isShooting = true;
                moveSpeed = originalMoveSpeed * 0.1f;
            }
        }
        else
        {
            isShooting = false;
            animator.SetBool("isShooting", false);
            moveSpeed = originalMoveSpeed;
        }
    }

    private void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 shootDirection = (mousePos - transform.position).normalized;

        switch (power)
        {
            case 1:
                GameObject bullet = Instantiate(bulletPrefab1, transform.position, Quaternion.identity);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.linearVelocity = shootDirection * bulletSpeed;
                float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                shootSound.clip = shootSound1;
                shootSound.volume = 0.5f;
                shootSound.Play();
                break;
            case 2:
                GameObject bullet1 = Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
                Rigidbody2D bulletRb1 = bullet1.GetComponent<Rigidbody2D>();
                bulletRb1.linearVelocity = shootDirection * bulletSpeed;
                float angle1 = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
                bullet1.transform.rotation = Quaternion.Euler(0, 0, angle1 - 90);
                shootSound.clip = shootSound2;
                shootSound.volume = 0.5f;
                shootSound.Play();
                break;
            default:
                GameObject bullet2 = Instantiate(bulletPrefab3, transform.position, Quaternion.identity);
                Rigidbody2D bulletRb2 = bullet2.GetComponent<Rigidbody2D>();
                bulletRb2.linearVelocity = shootDirection * bulletSpeed;
                float angle2 = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
                bullet2.transform.rotation = Quaternion.Euler(0, 0, angle2 - 90);
                shootSound.clip = shootSound3;
                shootSound.volume = 0.5f;
                shootSound.Play();
                break;
        }


        isShooting = true;
        animator.SetBool("isShooting", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetFloat("ShootDirectionX", shootDirection.x);
        animator.SetFloat("ShootDirectionY", shootDirection.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Item
        if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Power":
                    power++;
                    break;
                case "AttackSpeed":
                    shootCooldown -= 0.1f;
                    bulletSpeed += 1;
                    break;
                case "Health":
                    if(CurHp == maxHp)
                    {
                        break;
                    }
                    CurHp += 30;
                    break;
                case "MoveSpeed":
                    originalMoveSpeed += 0.5f;
                    break;
                case "Stamina":
                    staminaBoost += 0.1f;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }

    public void changeHealth(int hp)
    {
        Debug.Log(CurHp);
        CurHp += hp;
        Debug.Log(CurHp);
    }

    public void respawn()
    {
        transform.position = originalPosition;
    }
    public void PlayerSaveGameData()
    {
        gameData.playerHealth = CurHp;
        gameData.playerStamina = curStamina;
        gameData.playerPower = power;
        gameData.playerShootCooldown = shootCooldown;
        gameData.playerBulletSpeed = bulletSpeed;
        gameData.playerMoveSpeed = moveSpeed;
        gameData.playerPosition = originalPosition;
    }
    public void PlayerLoadData()
    {
        CurHp = gameData.playerHealth;
        curStamina = gameData.playerStamina;
        power = gameData.playerPower;
        shootCooldown = gameData.playerShootCooldown;
        bulletSpeed = gameData.playerBulletSpeed;
        moveSpeed = gameData.playerMoveSpeed;
        transform.position = gameData.playerPosition;
    }
}
