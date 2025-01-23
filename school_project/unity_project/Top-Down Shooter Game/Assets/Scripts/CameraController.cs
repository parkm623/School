using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform player;  // �÷��̾��� Transform
    public float offsetDistance = 4f;  // ī�޶� �̵��� �ִ� �Ÿ�
    public float smoothSpeed = 0.01f;  // ī�޶� �̵� �ε巯��

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // ���콺 Ŭ�� ���� Ȯ��
        if (Input.GetMouseButton(0)) // ���� ���콺 ��ư
        {
            // �÷��̾�� ���콺�� ȭ��� ��ġ ���
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2D ȯ�濡���� Z���� 0���� ����

            // �÷��̾�� ���콺���� ���� ���
            Vector3 direction = (mousePosition - player.position).normalized;

            // �÷��̾ �߽����� ���⿡ ���� ī�޶� ��ǥ ��ġ ����
            Vector3 targetPosition = player.position + direction * offsetDistance;

            // ī�޶� �÷��̾ ����� �ʵ��� ����
            float clampedX = Mathf.Clamp(targetPosition.x, player.position.x - offsetDistance, player.position.x + offsetDistance);
            float clampedY = Mathf.Clamp(targetPosition.y, player.position.y - offsetDistance, player.position.y + offsetDistance);
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);

            // ī�޶� �ε巴�� �̵�
            transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
        }
        else
        {
            // ���콺 Ŭ���� ������ ī�޶� �÷��̾� ��ġ�� ����
            Vector3 playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
        }
    }
}
