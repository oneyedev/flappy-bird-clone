using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneEyed.Extensions
{
    [CreateAssetMenu(fileName = "SceneManagerExtension", menuName = "Oneyed/SceneManagerExtension", order = 1)]
    public class SceneManagerExtension : ScriptableObject
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
