using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

// SceneManager sahneleri yönetir. Uzun adı yerine UnitySceneManager kullanılır.

public class DeadBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            int currentScene = UnitySceneManager.GetActiveScene().buildIndex;
            UnitySceneManager.LoadScene(currentScene);
        }
    }

    // OnTriggerEnter() metodu, bir nesne tetikleyici alana girdiğinde çağrılır.
    // other, alana giren nesnenin Collider bileşenidir.
    // GetComponent<PlayerController>(), nesnede PlayerController olup olmadığını bulur.
    // player değişkeni bulunan PlayerController bileşenini tutar.
    // player null değilse alana giren nesne oyuncudur.
    // currentScene, açık sahnenin build index değerini alır.
    // LoadScene() aynı sahneyi yeniden yükler.
}
