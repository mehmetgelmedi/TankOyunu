# TankProje
### Yazılım Sınama dersi ikinci projesi

### Amaç
Mayın oyunu projesinde amaç; kullanıcının girdiği değerler ile oluşturulan alanda yine kullanıcı tarafından yapılan mayın ekleme çıkarma işlemleri sonucunda tarayıcının alandaki mayınları tarayıp temizlemesini sağlamaktır. Kullanıcı mayın ekleme çıkarmanın yanında tarayıcıya engel olacak duvarlar da yerleştirebilmektedir.

### Girdiler
Projede başlangıç için iki tane girdi alınmaktadır. Bu girdiler x ve y koordinatlarıdır. Bu koordinatlara göre X * Y ‘lik kenarları duvar halinde bir mayın alanı oluşturulur daha sonra kullanıcılar alan üzerinde istedikleri noktalara engel ekleyebilir.

### Çıktılar
Kullanıcıdan alınan X ve Y değerleri sonucunda 2 boyutlu, kenarları duvar ile kaplı bir alan elde ediliyor.

### Mantığı
Kullanıcının girdileri ile oluşturulan alan içerisindeki tarayıcının gezmediği alanların değeri 0, duvar koyulan alanlar ile kullanıcının duvar eklediği alanlarda  9999’dur. Buna bağlı olarak tarayıcımız her geçtiği alanı 1 artırarak bölgede ilk önceliği yukarı yön olmak üzere sırasıyla sol, sağ ve aşağı yönlere yönelir. Geçtiği alanlardan tekrar geçebilir.

### Ekran Çıktıları
> Değerleri Aldığımız Ekran
![test0](https://cloud.githubusercontent.com/assets/16701951/20274870/e2f36056-aa9e-11e6-9766-bb295913a89a.png)
> Panel üzerinde duvar ekleme / harita hali
![test1](https://cloud.githubusercontent.com/assets/16701951/20274886/faad7aba-aa9e-11e6-875d-f1fdcd0396cf.png)
> Başladıktan sonra tarama işlemi ekranı
![test2](https://cloud.githubusercontent.com/assets/16701951/20274899/09b12930-aa9f-11e6-8302-f1b45eddc976.png)

### Test Durumları

#### Başarılı Test Durumları
1. Kullanıcıdan istenen X ve Y boş geçilemez.
2. X ve Y değerlerinin eksi değer, harf ve özel karakter olarak girilemez.
3. İstenen değerler girilmediği sürece alan oluşturulmadan oyuna başlanamaz.
4. Girdiler belirli aralıkta olmalıdır.
5.	Değerler minimum 5 x 5 olmalıdır.
6.	Değerler en fazla 30 x 17 olmalıdır. (Bu kısıtlama ekran çözünürlüğünün 1366 x 768 olmasından kaynaklıdır.)
7.	Tarama işlemine başlandıktan sonra tekrar alan oluşturulamaz.
8.	Alan oluşturulmadan tarama işlemine başlanamaz.
9.	Tarayıcının etrafı kapatılamaz.
10.	Bir matının dört tarafı kapatılamaz.

#### Başarısız Test Durumları 
1.	Alanın ortasına engel koyma engellenemedi.
2.	Çözünürlükten kaynaklı sınırlama yapıldı.
