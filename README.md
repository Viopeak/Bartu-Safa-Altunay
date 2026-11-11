# Oyun Adı

**Öğrenci:** Bartu Safa Altunay  
**Öğrenci No:** 2602020027

## Oyunun Kısa Açıklaması
Oyuncu, üç seviye boyunca haritadaki nesneleri toplayarak bir sonraki seviyeye geçer.

## Kullanılan C# Scriptleri
- **PlayerController.cs:** Oyuncunun hareketini ve zıplamasını yönetir.
- **ScoreManager.cs:** Oyuncunun skorunu tutar, artırır/azaltır ve ekrandaki skor yazısını günceller.
- **AudioManager.cs:** Arka plan müziğini çalar ve zıplama ile coin seslerini oynatır.
- **SceneController.cs:** Sonraki sahneyi yükler.
- **LevelExit.cs:** Oyuncu çıkışa gelince yeterli puanı varsa sonraki sahneye geçirir.
- **DeadBox:** Oyuncu bu alana girince mevcut sahneyi baştan yükler.

## Teknik Açıklama (Nesne Toplama / Sahne Geçişi Algoritması)
Toplanabilir nesnelerin Collider bileşeni "Is Trigger" olarak ayarlanmıştır.
Oyuncu nesneye değdiğinde `PlayerController` içindeki `OnTriggerEnter` çalışır
ve nesnenin etiketi kontrol edilir, `PositiveCoin` etiketli nesnelerde `ScoreManager`
üzerindeki skor 10 artırılır, `NegativeCoin` etkiteli nesnelerde skor 5 azaltılır
(skor 0'ın altına düşmez). Her iki durumda da ilgili ses efekti çalınır ve nesne
`Destroy` ile yok edilir

## Karşılaşılan Hata ve Çözümü
**Hata:** Oyun içi ses gelmedi  
**Neden:** PlayerController.sc ye AudioManager komutlarını girmeyi unuttum  
**Çözüm:** PlayerController.sc deki zıplama +puan ve -puan sesleri için AudioManager
komutlarını koydum

## Nasıl Çalıştırılır?
1. `Assets/Scenes/Level1` sahnesini aç ve **Play** tuşuna bas.
2. Kontroller: WASD / Ok tuşları ile hareket, Space ile zıplama.

## Oynanış Videosu
[Videoyu izle](https://youtu.be/-Nhq6vQlmzE)
