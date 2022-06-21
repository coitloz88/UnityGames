using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //������ ź���� ���� ������
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ�

    private Transform target; //������ ��� ���� ������Ʈ�� Ʈ������ ������Ʈ
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�

    //�ð��� ���� ������ �ʱ�ȭ�ϰ�, ź�� �߻� ��ǥ ������ ���� ������Ʈ�� Ʈ������ ������Ʈ�� ������
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            //������ �ð��� ����
            timeAfterSpawn = 0f;

            //bulletPrefab�� ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //������ bullet ������Ʈ�� ���� ������ target�� ���ϵ��� ����
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
