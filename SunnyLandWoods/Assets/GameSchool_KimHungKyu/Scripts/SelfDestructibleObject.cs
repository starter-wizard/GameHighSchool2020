using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KimHungKyu
{
    public class SelfDestructibleObject : MonoBehaviour
    {
        public void SelfDestroy()
        {
            Destroy(gameObject);
        }

    }

}
