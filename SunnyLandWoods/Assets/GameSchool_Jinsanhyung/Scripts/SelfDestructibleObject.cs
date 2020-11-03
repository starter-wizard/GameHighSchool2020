using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinsanhyoung
{
    public class SelfDestructibleObject : MonoBehaviour
    {
        public void SelfDestroy()
        {
            Destroy(gameObject);
        }
    }
}
