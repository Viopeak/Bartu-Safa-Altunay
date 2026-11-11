using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

// SceneManager sahneleri yönetir. Uzun adı yerine UnitySceneManager kullanılır.

public class SceneController : MonoBehaviour
{
    public void NextScene()
    {
        int currentScene = UnitySceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene < UnitySceneManager.sceneCountInBuildSettings)
        {
            UnitySceneManager.LoadScene(nextScene);
        }
    }

    // NextScene() metodu, sıradaki sahneyi açar.
    // currentScene, açık sahnenin build index değerini tutar.
    // nextScene, mevcut sahnenin bir sonrasını belirtir.
    // if koşulu, sonraki sahnenin build ayarlarında olup olmadığını kontrol eder.
    // LoadScene() metodu, build index değeri verilen sahneyi yükler.

}
