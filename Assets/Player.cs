using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    // �ִϸ����� �߰�
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void Update()
    {
        // ���� ��Ҵ��� Ȯ��
        isGrounded = controller.isGrounded;

        // �߷� �ʱ�ȭ
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        // WASD �Է����� �̵�
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // �̵� �ִϸ��̼� ó��
        if (move.magnitude > 0) // �̵� ��
        {
            if (Input.GetKey(KeyCode.LeftShift)) // �޸� ��
            {
                controller.Move(move * (moveSpeed * 1.5f) * Time.deltaTime);
                animator.SetBool("Run", true); // Run �ִϸ��̼� Ȱ��ȭ
                animator.SetBool("Walk", false); // Walk �ִϸ��̼� ��Ȱ��ȭ
            }
            else // ���� ��
            {
                controller.Move(move * moveSpeed * Time.deltaTime);
                animator.SetBool("Walk", true); // Walk �ִϸ��̼� Ȱ��ȭ
                animator.SetBool("Run", false); // Run �ִϸ��̼� ��Ȱ��ȭ
            }
        }
        else // ���� ����
        {
            animator.SetBool("Walk", false); // Walk �ִϸ��̼� ��Ȱ��ȭ
            animator.SetBool("Run", false); // Run �ִϸ��̼� ��Ȱ��ȭ
        }

        // ����
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // �߷� ����
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void SetRotationY(float yRotation)
    {
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
