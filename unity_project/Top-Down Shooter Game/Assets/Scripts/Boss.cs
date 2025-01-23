using System.Collections;
using System.Collections.Generic;
//using UnityEngine.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private float maxHp;
    private float curHp;
    public Slider hpSlider;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip razerSound;
    private AudioSource audioSource;

    Animator animator;
    CapsuleCollider2D capsuleCollider;
    SpriteRenderer spriteRenderer;
    private bool isFlashing = false;
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField] private float defDistanceRay = 100;
    public LineRenderer lineRenderer;
    public Transform laserFirePoint;
    Transform m_transform;
    private bool isShooting = false;
    public GameManager gameManager;
    private float bulletSpeed;
    private bool isAlive = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        maxHp = 300;
        curHp = 300;
        m_transform = GetComponent<Transform>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.enabled = false;
        bulletSpeed = 4f;

        if (hpSlider != null)
        {
            hpSlider.maxValue = maxHp;
            hpSlider.value = curHp;
        }
        hpSlider.transform.position = transform.position + new Vector3(0, -1.8f, 0);

        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && fireSound != null)
        {
            audioSource.clip = fireSound;
        }
    }

    void Start()
    {
        Invoke("Think", 2f);
    }

    private void Update()
    {
        hpSlider.value = curHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            curHp -= 10;
            StartCoroutine(FlashYellow());
            Destroy(collision.gameObject);
            if (curHp <= 0)
            {
                gameOver();
            }
        }
    }

    private IEnumerator FlashYellow()
    {
        if (isFlashing) yield break;

        isFlashing = true;
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = originalColor;
        isFlashing = false;
    }

    void gameOver()
    {
        animator.SetTrigger("Die");
        isAlive = false;
        capsuleCollider.enabled = false;
        GameManager.Instance.BossStageClear();
    }

    void Think()
    {
        if (!GameManager.Instance.CheckPause() && GameManager.Instance.CheckPlay())
        {
            if (!GameManager.Instance.CheckPlay()) return;
            if (isShooting) return;
            if (!isAlive) return;
            patternIndex = patternIndex % 5;
            switch (patternIndex)
            {
                case 0:
                    FireForward();
                    break;
                case 1:
                    StartCoroutine(MachineGun());
                    break;
                case 2:
                    Break();
                    break;
                case 3:
                    FireAround();
                    break;
                case 4:
                    ShootLaser180Degrees();
                    break;
            }
            patternIndex++;
        }
    }

    void FireForward()
    {
        Vector3 playerPosition = gameManager.player.transform.position;
        Vector3 bossPosition = transform.position;
        Vector2 shootDirection = (playerPosition - bossPosition).normalized;
        for (int i = 0; i < 4; i++)
        {
            float angleOffset = -10f + (i * 6.66f);
            Vector2 modifiedDirection = Quaternion.Euler(0, 0, angleOffset) * shootDirection;

            GameObject bullet = Instantiate(bulletPrefab, bossPosition, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.linearVelocity = modifiedDirection * bulletSpeed;

            float angle = Mathf.Atan2(modifiedDirection.y, modifiedDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            PlayFireSound();
        }
        Invoke("Think", 2f);
    }

    IEnumerator MachineGun()
    {
        for (int i = 0; i < 30; i++)
        {
            if (isAlive)
            {
                Vector3 playerPosition = gameManager.player.transform.position;
                Vector3 bossPosition = transform.position;
                Vector2 shootDirection = (playerPosition - bossPosition).normalized;

                GameObject bullet = Instantiate(bulletPrefab, bossPosition, Quaternion.identity);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.linearVelocity = shootDirection * bulletSpeed * 1.5f;
                PlayFireSound();
                yield return new WaitForSeconds(0.3f);
            }
        }
        Invoke("Think", 2f);
    }

    void Break()
    {
        Invoke("Think", 3f);
    }

    void FireAround()
    {
        Vector3 bossPosition = transform.position;
        int bulletCount = 50;
        int repeatCount = 5;
        float rotationOffset = 120f;

        StartCoroutine(FireAroundRepeatedly(bossPosition, bulletCount, repeatCount, rotationOffset));
        Invoke("Think", 7f);
    }

    IEnumerator FireAroundRepeatedly(Vector3 bossPosition, int bulletCount, int repeatCount, float rotationOffset)
    {
        animator.SetTrigger("Spread");
        yield return new WaitForSeconds(3f);

        for (int r = 0; r < repeatCount; r++)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                if (isAlive)
                {
                    float angle = Mathf.PI * 2 * i / bulletCount + Mathf.Deg2Rad * rotationOffset * r;
                    Vector2 dirVec = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                    GameObject bullet = Instantiate(bulletPrefab, bossPosition, Quaternion.identity);
                    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                    bulletRb.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
        animator.SetTrigger("Idle");
    }

    void ShootLaser180Degrees()
    {
        if (!isShooting)
        {
            StartCoroutine(ShootLaserOverTime());
        }
    }

    private IEnumerator ShootLaserOverTime()
    {
        animator.SetTrigger("Lazer");
        PlayRazerSound();
        yield return new WaitForSeconds(5f);

        if (!isAlive) yield break;

        isShooting = true;
        lineRenderer.enabled = true;
        curPatternCount++;
        Vector3 playerPosition = gameManager.player.transform.position;
        Vector3 bossPosition = transform.position;

        bool shootDownward = playerPosition.y < bossPosition.y;

        float startAngle = shootDownward ? 180f : 180f;
        float endAngle = shootDownward ? 360f : 0f;
        int steps = 60;
        float delay = 0.05f;
        int layerMask = ~LayerMask.GetMask("Boss", "PlayerBullet", "Obstacle");

        for (int i = 0; i <= steps; i++)
        {
            float t = (float)i / steps;
            float angle = Mathf.Lerp(startAngle, endAngle, t);
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
            RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, direction, defDistanceRay, layerMask);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Player player = hit.collider.GetComponent<Player>();
                    if (player != null)
                    {
                        player.changeHealth(-10);
                    }
                }
                else
                {
                    Draw2DRay(laserFirePoint.position, hit.point);
                }
            }
            else
            {
                Draw2DRay(laserFirePoint.position, laserFirePoint.position + (Vector3)direction * defDistanceRay);
            }

            yield return new WaitForSeconds(delay);
        }
        lineRenderer.enabled = false;
        isShooting = false;
        animator.SetTrigger("Idle");
        Invoke("Think", 2f);
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    private void PlayFireSound()
    {
        if (audioSource != null && fireSound != null)
        {
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(fireSound);
        }
    }

    private void PlayRazerSound()
    {
        if (audioSource != null && razerSound != null)
        {
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(razerSound);
        }
    }
}