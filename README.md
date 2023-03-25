# PaymentWebServiceApp
Bir ödeme sistemi ve bir Erp sistemine entegre web service uygulamasıdır.

Kayıtlı bir kullanıcının login olduktan sonra ürün ve müşteri bilgilerini alarak, temassız ödeme yapması amaçlanan rest api.

Clean architecture ve CQRS desing pattern MediatR ile birlikte kullanılmıştır.

Database olarak MSSQL kullanılıyor. Kullanıcıların login, logout traceleri ve şirketlerin uygulama içi lisanslarının MongoDb'de tutulmasını öngörüyorum. Henüz geliştirme aşamasında.

Caching için inmemory caching yeterli düzeyde. Gerekli görüldüğünde redis inject edilebilir.

Birden çok şirket yapısıyla çalışabileceği ve farklı şirketlerin farklı erp uygulamaları ile çalışabileceği göz önünde bulundurularak, Login olan kullanıcının bağlı bulunduğu şirketin kullandığı erp uygulaması db'den alınarak bir factory method aracılığı ile ayağa kaldırılmıştır.

Sms, mail, register validation vb queue işleri için RabbitMQ kullanmayı planladım
