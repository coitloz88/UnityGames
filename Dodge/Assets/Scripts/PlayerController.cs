using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� ��� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӵ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3�� �ӵ��� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidBody.velocity = newVelocity;
    }

    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
