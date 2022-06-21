using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3f; //최대 생성 주기

    private Transform target; //조준할 대상 게임 오브젝트의 트랜스폼 컴포넌트
    private float spawnRate; //생성 주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간

    //시간에 관한 변수를 초기화하고, 탄알 발사 목표 지점인 게임 오브젝트의 트랜스폼 컴포넌트를 가져옴
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            //누적된 시간을 리셋
            timeAfterSpawn = 0f;

            //bulletPrefab의 복제본 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //생성된 bullet 오브젝트의 정면 방향이 target을 향하도록 설정
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
