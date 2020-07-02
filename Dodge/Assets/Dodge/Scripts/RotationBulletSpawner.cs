﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBulletSpawner : MonoBehaviour
{
    public GameObject m_Bullet;

    public float m_RotationSpeed = 60f;
    public float m_AttackInterval = 1f;
    private float m_AttackCooltime = 0f;

    // Update is called once per frame
    void Update()
    {
        //공격 선쿨타임 계산
        m_AttackCooltime += Time.deltaTime;
        if (m_AttackCooltime >= m_AttackInterval)
        {
            //총알 생성
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            //공격 선쿨타임 초기화
            m_AttackCooltime = 0;
        }

        //삭제
        //GameObject.Find("Player"); //게임오브젝트의 이름
        //GameObject player = GameObject.FindGameObjectWithTag("Player"); //Player
        //GameObject.FindObjectOfType<PlayerController>();

        //GameObject.FindGameObjectsWithTag("Player"); // 모든 Player
        //GameObject.FindObjectsOfType<PlayerController>(); // 모든 PlayerController 검색

        transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0);
        
        //삭제
        //if(player != null)
        //{
        //    Vector3 attacketPoint = player.transform.position;
        //    attacketPoint.y = transform.position.y;
        //    transform.LookAt(attacketPoint);
        //}
    }
}
