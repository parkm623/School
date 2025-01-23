using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform player;  // 플레이어의 Transform
    public float offsetDistance = 4f;  // 카메라가 이동할 최대 거리
    public float smoothSpeed = 0.01f;  // 카메라 이동 부드러움

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // 마우스 클릭 상태 확인
        if (Input.GetMouseButton(0)) // 왼쪽 마우스 버튼
        {
            // 플레이어와 마우스의 화면상 위치 계산
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2D 환경에서는 Z값을 0으로 고정

            // 플레이어에서 마우스로의 방향 계산
            Vector3 direction = (mousePosition - player.position).normalized;

            // 플레이어를 중심으로 방향에 따른 카메라 목표 위치 설정
            Vector3 targetPosition = player.position + direction * offsetDistance;

            // 카메라가 플레이어를 벗어나지 않도록 제한
            float clampedX = Mathf.Clamp(targetPosition.x, player.position.x - offsetDistance, player.position.x + offsetDistance);
            float clampedY = Mathf.Clamp(targetPosition.y, player.position.y - offsetDistance, player.position.y + offsetDistance);
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);

            // 카메라를 부드럽게 이동
            transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
        }
        else
        {
            // 마우스 클릭이 없으면 카메라를 플레이어 위치로 복귀
            Vector3 playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
        }
    }
}
