using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioClip positivecoinSound;
    [SerializeField] private AudioClip negativecoinSound;
    [SerializeField] private AudioClip JumpSound;

    [SerializeField] private AudioClip backgroundMusic;

    // public, değişkene başka scriptlerden erişilmesini sağlar.
    // static, değişkeni sınıf üzerinden erişilebilir yapar.
    // instance, bu AudioManager nesnesine diğer scriptlerden erişilmesini sağlar.
    // SerializeField, private değişkenleri Inspector'da gösterir.
    // sfxSource, ses efektlerini çalmak için kullanılır.
    // musicSource, arka plan müziğini çalmak için kullanılır.
    // AudioClip, çalınacak ses dosyasını tutar.
    // positivecoinSound, pozitif coin sesini tutar.
    // negativecoinSound, negatif coin sesini tutar.
    // JumpSound, zıplama sesini tutar.
    // backgroundMusic, arka plan müziğini tutar.

    private void Awake()
    {
        instance = this;
    }

    //this: AudioManager'ı temsil ediyor.
    // Awake() nesne oluşturulurken çalışır.
    // instance, bu nesneye atanarak diğer scriptlerden erişim sağlar.

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Start() metodu, sahne başladığında çalışır.
    // clip özelliğine arka plan müziği atanır.
    // loop true olduğunda müzik bitince yeniden başlar.
    // Play() metodu müziği çalar.

    public void PlayPositiveCoinSound()
    {
        sfxSource.PlayOneShot(positivecoinSound);
    }

    // Bu metot pozitif coin sesini bir kez çalar.
    // PlayOneShot(), çalan başka sesleri durdurmadan ses efekti oynatır.

        public void PlayNegativeCoinSound()
    {
        sfxSource.PlayOneShot(negativecoinSound);
    }

    // Bu metot negatif coin sesini bir kez çalar.
    // PlayOneShot(), çalan başka sesleri durdurmadan ses efekti oynatır.

        public void PlayJumpSound()
    {
        sfxSource.PlayOneShot(JumpSound);
    }

    // Bu metot zıplama sesini bir kez çalar.
    // PlayOneShot(), çalan başka sesleri durdurmadan ses efekti oynatır.

} 
