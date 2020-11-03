using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jinsanhyoung
{
    public class FollowBackground : MonoBehaviour
    {
        public float m_Grid = 20f;

        public GameObject[] m_Background;
        public Transform m_Target;

        public int m_Offset = 0;

        public void Update()
        {
            int mod = Mathf.RoundToInt(m_Target.position.x / m_Grid);

            if (m_Offset != mod)
            {
                foreach (var background in m_Background)
                {
                    var pos = background.transform.position;
                    pos.x += m_Grid * (mod - m_Offset);
                    background.transform.position = pos;
                }
            }

            foreach (var background in m_Background)
            {
                var pos = background.transform.position;
                pos.y = m_Target.position.y;
                background.transform.position = pos;
            }

            m_Offset = mod;
        }
    }
}
