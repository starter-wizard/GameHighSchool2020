using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    ////가장 간단한 싱글톤...;
    //public static GameManager instance;
    //void Awake()
    //{
    //    instance = this;
    //}

    public Text m_ScoreUI;
    public Text m_RestartUI;

    public PlayerController m_PlayerController;
    public List<GameObject> m_BulletSpawners;

    public bool m_IsPlaying;
    public float m_Score;

    private void Start()
    {
        //GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        //시간당 점수업
        if (m_IsPlaying)
        {
            m_Score = m_Score + Time.deltaTime;
            m_ScoreUI.text = string.Format("Score : {0}", m_Score);
        }
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        GameStart();
        //    }
        //}
    }

    public void GameStart()
    {
        m_IsPlaying = true;
        m_Score = 0f;
        m_RestartUI.gameObject.SetActive(false);
        m_PlayerController.gameObject.SetActive(true);

        for(int i=0; i<m_BulletSpawners.Count; i++)
        {
            m_BulletSpawners[i].gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        m_IsPlaying = false;
        m_RestartUI.gameObject.SetActive(true);
        m_PlayerController.gameObject.SetActive(false);

        for (int i = 0; i < m_BulletSpawners.Count; i++)
        {
            m_BulletSpawners[i].gameObject.SetActive(false);
        }

        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }
    }
}
