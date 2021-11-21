using UnityEngine;
using UnityEngine.SceneManagement;

namespace Triggers
{
    public class ResetLevelAction : MonoBehaviour
    {
        private IActionReceiver actionReceiver;

        private void Start()
        {
            GetComponent<IActionReceiver>()?.SetAction(ResetLevel);
        }

        private void ResetLevel() {
            //print("Level would reset now.");
            FindObjectOfType<SceneLoader>().LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    
    }
}
