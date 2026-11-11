using UnityEngine;
using TMPro;

// TMPro, TextMeshPro metin bileşenlerini kullanmayı sağlar.

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    // public, değişkene başka scriptlerden erişilmesini sağlar.
    // static, değişkene sınıf üzerinden erişilmesini sağlar.
    // Instance, ScoreManager'a diğer scriptlerden erişilmesini sağlar.
    // SerializeField, private değişkeni Inspector'da gösterir.
    // private, değişkene yalnızca bu sınıf içinden erişilmesini sağlar.
    // scoreText, ekrandaki skor metnini tutar.
    // int, tam sayıları tutar. score oyuncunun puanını saklar.
    // score başlangıçta sıfırdır.

    private void Awake()
    {
        Instance = this;
    }

    // Awake() nesne oluşturulurken çalışır.
    // Instance, bu ScoreManager nesnesine atanır.

    private void Start()
    {
        UpdateScoreUİ();
    }

    // Start() sahne başladığında çalışır.
    // Skor ilk kez ekranda güncellenir.

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUİ();
    }

    // AddScore() metodu, amount değerini skora ekler.
    // amount, eklenecek puan miktarını belirtir.
    // Ardından ekrandaki skor yazısını günceller.

    public void RemoveScore(int amount)
    {
        score -= amount;

        if (score < 0)
        {
            score = 0;
        }

        UpdateScoreUİ();
    }

    // RemoveScore() metodu, amount değerini skordan çıkarır.
    // amount, çıkarılacak puan miktarını belirtir.
    // Skor sıfırın altına düşerse sıfıra ayarlanır.
    // Son olarak ekrandaki skor yazısı güncellenir.

    public int GetScore()
    { 
        return score;
    }

    // GetScore() metodu, mevcut skoru geri döndürür.

    public void UpdateScoreUİ()
    {
        scoreText.text = "Score: " + score;
    }

    // UpdateScoreUİ() metodu, ekrandaki skor metnini günceller.
    // Sayısal skor, metne eklenerek ekranda gösterilir.
}
