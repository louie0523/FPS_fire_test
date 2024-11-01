using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public float minYRotation = -60f; // 최소 Y 회전 각도
    public float maxYRotation = 60f;  // 최대 Y 회전 각도

    private float rotationX = 0f;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>(); // 부모 객체의 PlayerMovement 컴포넌트 가져오기
        Cursor.lockState = CursorLockMode.Locked; // 커서를 화면 중앙에 고정
    }

    void Update()
    {
        // 마우스 이동으로 회전
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 상하 회전 각도 제한
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);

        // 카메라 회전
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // 캐릭터의 Y 회전 업데이트
        playerMovement.SetRotationY(transform.parent.eulerAngles.y + mouseX);
    }
}
