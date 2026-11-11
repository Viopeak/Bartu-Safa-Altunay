
using UnityEngine;
using TMPro;

//TMPro kütüphanesi, Unity'de metinleri daha etkili ve özelleştirilebilir bir şekilde yönetmek için kullanılan TextMeshPro bileşenini sağlar. Bu kütüphane, metinlerin daha net ve yüksek kaliteli görünmesini sağlar.

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;

    // [SerializeField] ise bu değişkenin Unity Inspector üzerinden düzenlenmesini sağlar.
    // private, değişkene yalnızca sınıf içerisinden erişilebileceğini ifade eder.
    // moveSpeed oyuncunun hareket hızını belirler. float veri türü ondalıklı sayıları saklamak için kullanılır. 10f değeri, oyuncunun hareket hızını temsil eder
    // jumpForce değişkeni zıplama kuvvetini belirler. 5f değeri, oyuncunun zıplama kuvvetini temsl eder.

    private Rigidbody rb; 

    //rb: Oyuncunun Rigidbody bileşenine erişmek için kullanılır.

    private bool isGrounded;

    // isGrounded değişkeni, oyuncunun yerde olup olmadığını kontrol etmek için kullanılır. Bu, zıplama işleminin yalnızca oyuncu yerdeyken gerçekleşmesini sağlar.
    // bool, yalnızca true ve false değerlerini alabilen bir veri türüdür.true: Oyuncu yerde, false: Oyuncu havada.

    private float horizontal;
    private float vertical;
    public int Score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    // vertical değişkeni, oyuncunun dikey eksende hareketini kontrol etmek için kullanılır.
    // horizontal değişkeni, oyuncunun yatay eksende hareketini kontrol etmek için kullanılır.
    // int, tam sayıları saklamak için kullanılan bir veri türüdür. Score değişkeni, oyuncunun skorunu temsil eder.
    // Bu değişken, Canvas üzerindeki metin nesnesini kod içerisinde kullanabilmemizi sağlar.

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    //Awake()GameObject'in başlangıç yaşam döngüsünde çağrılır.
    // GetComponent<Rigidbody>() script'in bağlı olduğu GameObject üzerindeki Rigidbody bileşenini bulur.

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    //Bu metot oyuncunun WASD tuşlarıyla hareket etmesini sağlar.
    //Input.GetAxisRaw() klavye üzerinden yön bilgisi alır.
    //Örneğin oyuncu D tuşuna bastığında horizontal değeri 1 olur. A tuşuna bastığında ise -1 olur.

    private void FixedUpdate() 
    {
        Movement();
    }

    // movement() metodu, oyuncunun hareketini sağlar. Bu metot, FixedUpdate() içerisinde çağrılır çünkü fizik tabanlı hareketler için daha doğru sonuçlar verir.

    private void Movement()
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = direction.normalized;
        rb.AddForce(direction * moveSpeed);
    }

    // Vector3, 3 boyutlu bir vektörü temsil eder. direction değişkeni, oyuncunun hareket yönünü belirler.
    // direction.normalized, vektörün uzunluğunu 1 birim olacak şekilde normalize eder. Bu, oyuncunun hareket hızının sabit kalmasını sağlar.
    // rb.AddForce() metodu, Rigidbody bileşenine kuvvet uygular ve oyuncunun hareket etmesini sağlar. direction * moveSpeed ifadesi, hareket yönünü ve hızını belirler.

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        isGrounded = false;
        print("Zıpladın!");
        AudioManager.instance.PlayJumpSound();

    }
    
    // Jump() metodu, oyuncunun zıplamasını sağlar. Bu metot, Update() içerisinde çağrılır.
    // rb.AddForce() metodu, Rigidbody bileşenine yukarı yönünde kuvvet uygular ve oyuncunun zıplamasını sağlar. ForceMode.Impulse, kuvvetin anlık olarak uygulanmasını sağlar.
    // isGrounded = false; ifadesi, oyuncunun havada olduğunu belirtir ve zıplama işleminin tekrar gerçekleşmesini engeller.
    // print() metodu, konsola mesaj yazdırmak için kullanılır. Bu, oyuncunun zıpladığını belirtir.
    // AudioManager.instance.PlayJumpSound(); ifadesi, zıplama sesi çalmak için AudioManager sınıfındaki PlayJumpSound() metodunu çağırır.

    private void UpdateScoreUi()
    { 
        scoreText.text = "Score : " + Score.ToString();
    }

    // UpdateScoreUi() metodu, oyuncunun skorunu ekranda günceller. Bu metot, skor değiştiğinde çağrılır.
    // scoreText.text, Canvas üzerindeki metin nesnesinin içeriğini günceller. "Score : " + Score.ToString() ifadesi, skor değerini metin olarak ekrana yazdırır.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Yerdesin!");
        }
    }

    // OnCollisionEnter() metodu, oyuncu bir nesneyle çarpıştığında çağrılır. Bu metot, oyuncunun yere temas ettiğini kontrol eder.
    // collision.gameObject.CompareTag("Ground") ifadesi, çarpışılan nesnenin "Ground" tag'ine sahip olup olmadığını kontrol eder. Eğer sahipse, isGrounded değişkeni true olarak ayarlanır ve oyuncunun yere temas ettiği belirtilir.
    // Debug.Log() metodu, konsola mesaj yazdırmak için kullanılır. Bu, oyuncunun yere temas ettiğini belirtir.
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PositiveCoin"))
        {
            ScoreManager.Instance.AddScore(10);
            AudioManager.instance.PlayPositiveCoinSound();
            Debug.Log("PositiveCoin! +10 Puan");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("NegativeCoin")) 
        { 
            ScoreManager.Instance.RemoveScore(5);
            AudioManager.instance.PlayNegativeCoinSound();
            Debug.Log("NegativeCoin! -5 Puan");
            Destroy(other.gameObject);
        }
    }

    // OnTriggerEnter() metodu, oyuncu bir tetikleyici nesneye temas ettiğinde çağrılır. Bu metot, oyuncunun skorunu artırmak veya azaltmak için kullanılır.
    // other.CompareTag("PositiveCoin") ifadesi, çarpışılan nesnenin "PositiveCoin" tag'ine sahip olup olmadığını kontrol eder. Eğer sahipse, skor 10 puan artırılır ve pozitif ses efekti çalınır.
    // other.CompareTag("NegativeCoin") ifadesi, çarpışılan nesnenin "NegativeCoin" tag'ine sahip olup olmadığını kontrol eder. Eğer sahipse, skor 5 puan azaltılır ve negatif ses efekti çalınır.
    // Destroy(other.gameObject) ifadesi, çarpışılan nesneyi sahneden kaldırır. Bu, oyuncunun aynı nesneyle tekrar çarpışmasını engeller.

    // AudioManager scriptini yazdığımda
    //
    // AudioManager.instance.PlayNegativeCoinSound();
    // AudioManager.instance.PlayJumpSound();
    // AudioManager.instance.PlayPositiveCoinSound();
    //
    // ifadelerini kullanmayı unutmuştum ve uzun bir süre hatamı anlayamadığım için sesi de duymamaıştım :D.
}