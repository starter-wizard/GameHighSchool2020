using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jinsanhyoung
{
    public class LevelScript_PlatformStage : MonoBehaviour
    {
        public void RestatLevel1()
        {
            var nowScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(nowScene.name);
        }

        public void LoadLevel1(string levelname)
        {
            SceneManager.LoadScene(levelname);
        }
    }
}
