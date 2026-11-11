using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private int requiredScore = 50;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SceneController sceneController;

    // SerializeField, private değişkenleri Inspector'da gösterir.
    // requiredScore, çıkış için gereken en düşük puanı tutar.
    // scoreManager, oyuncunun puanını öğrenmek için kullanılır.
    // sceneController, sonraki sahneyi açmak için kullanılır.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (scoreManager.GetScore() >= requiredScore)
            {
                Debug.Log("Yeterli puan! Sonraki level açılıyor.");

                sceneController.NextScene();
            }
            else
            {
                Debug.Log("Yeterli puan yok!");
            }
        }
    }

    // OnTriggerEnter() metodu, bir nesne çıkış alanına girdiğinde çağrılır.
    // other, alana giren nesnenin Collider bileşenidir.
    // CompareTag("Player"), giren nesnenin Player etiketini kontrol eder.
    // GetScore(), oyuncunun mevcut puanını verir.
    // Puan gereken değere eşit veya fazlaysa ilk koşul çalışır.
    // Debug.Log() başarı mesajını konsola yazar.
    // NextScene(), sonraki sahneyi açar.
    // Puan yetersizse else bölümü çalışır.
    // Debug.Log() yetersiz puan mesajını konsola yazar.
}
