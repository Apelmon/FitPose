using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    void Start() {
//        GameAnalytics.Initialize();
        SceneManager.LoadScene("Game");
    }
}
