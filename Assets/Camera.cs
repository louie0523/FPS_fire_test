using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public float minYRotation = -60f; // �ּ� Y ȸ�� ����
    public float maxYRotation = 60f;  // �ִ� Y ȸ�� ����

    private float rotationX = 0f;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>(); // �θ� ��ü�� PlayerMovement ������Ʈ ��������
        Cursor.lockState = CursorLockMode.Locked; // Ŀ���� ȭ�� �߾ӿ� ����
    }

    void Update()
    {
        // ���콺 �̵����� ȸ��
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ���� ȸ�� ���� ����
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);

        // ī�޶� ȸ��
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // ĳ������ Y ȸ�� ������Ʈ
        playerMovement.SetRotationY(transform.parent.eulerAngles.y + mouseX);
    }
}
