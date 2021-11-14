using UnityEngine;

public class Globals : MonoBehaviour
{

    private static Globals instance;

    private void Awake() {
        if(instance != null) {
            gameObject.SetActive(false);
            Destroy(this);
        } else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
