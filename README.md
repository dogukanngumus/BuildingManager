![](https://raw.githubusercontent.com/dogukanngumus/BuildingManager/main/Images/Building%20Manager.gif?token=APZFDXGS5OK6LCRWZF4VZZTA4Z2C4)

<h1>Building Manager</h1>

**Patika.dev Apsiyon .NET Core Bootcamp** bitirme projesi olarak **Building Manager** isimli uygulamayı geliştirdim. **Building Manager** uygulamasını hazırlanırken **Apsiyon Apsis** projesinden esinlendim. **Building Manager** içerisinde apartman yöneticilerinin hayatlarını kolaylaştıracak birçok özelliği barındırmakta.

* :ear: **Duyurular** : Bu alan yönetici tarafından kullanıcıların tamamına duyuru göndermek için kullanılır. Yönetici bu duyuruları ekleyebilir, silebilir ve güncelleyebilir.

* :house: **Site** : Bu alan içerisinde iki farklı özellik vardır bunlardan ilki **Blok** alanıdır. Yönetici site içerisindeki blokları sisteme dahil edebilir silebilir ve güncelleyebilir. İkincisi ise **daire** alanıdır. Bloklar daireler ile ilişkilidir ve yönetici eğer bir daire eklemek istiyorsa onun hangi bloğa ait olduğunu belirtmek zorundadır.

* :love_letter: **Mesajlar**: Kullanıcılar birbirleri arasında mesajlaşmak isterse bu alanı kullanabilir.

* :euro: **Finans**: Finans alanı aslında projenin en aktif alanıdır. Öncelikle yönetici bir gider tipi belirlemelidir, daha sonra ise bu gider tipine daireye özel ya da toplu olarak gider tipi ekler. Eğer ki kullanıcı kendisine atanan borcu ödemek isterse **Building Manager** uygulamasının ödeme servisinden yararlanarak bu ödeme işlemini gerçekleştirebilir. 

 <h1 id="built-with">Geliştirildiği Teknolojiler</h1>

<img src="https://media.giphy.com/media/836HiJc7pgzy8iNXCn/giphy.gif">

<table>
  <tbody>
    <tr>
      <td><a href="#"><img alt="JavaScript" height="50px" src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/javascript/javascript.png"></a></td>
      <td><a href="#"><img alt="HTML5" title="HTML5" height="50px"                      src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/html/html.png" /></a></td>
       <td><a href="#"><img alt="CSS3" title="CSS3" height="50px"
                        src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/css/css.png" /></a>
            </td>
       <td><a href="#"><img alt="Bootstrap" title="Bootstrap" height="50px"
                        src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/bootstrap/bootstrap.png" /></a>
            </td>
    </tr>
    <tr>
      <td><a href="#"><img alt="ASP" title="ASP" height="50px"
                        src="https://www.vectorlogo.zone/logos/dotnet/dotnet-ar21.svg" /></a>
            </td>
      <td><a href="#"><img alt="C#" title="C#" height="50px"
                        src="https://img.icons8.com/color/48/000000/c-sharp-logo.png" /></a>
            </td>
       <td><a href="#"><img alt="C#" title="C#" height="50px"
                        src="https://www.vectorlogo.zone/logos/mongodb/mongodb-ar21.svg" /></a>
            </td>
      <td><a href="#"><img alt="Rider" title="Rider" height="50px"
                        src="https://resources.jetbrains.com/storage/products/rider/img/meta/rider_logo_300x300.png" /></a>
            </td>
    </tr>
    <tr>
       <td><a href="#"><img alt="Git" title="Git" height="50px"
                        src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/git/git.png" /></a>
            </td>
      <td><a href="#"><img alt="ASP" title="ASP" height="30px"
                        src="https://img.shields.io/badge/-ASP.NET-5C2D91?style=flat&logo=.net&logoColor=white" /></a>
            </td>
        <td><a href="#"><img alt="Ef" title="Ef" height="30px"
                        src="https://img.shields.io/badge/-EntityFramework-5C2D91?style=flat&logo=.net&logoColor=white" /></a>
            </td>
       <td><a href="#"><img alt="MsSql" title="MsSql" height="30px"
                        src="https://img.shields.io/badge/-Sql%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=ffffff" /></a>
            </td>
    </tr>
   <tr>
     </td>
        <td><a href="#"><img alt="AutoMapper" title="AutoMapper" height="30px"
                        src="https://img.shields.io/badge/-AutoMapper-5C2D91?style=flat&logo=.net&logoColor=white" /></a>
            </td>
       <td><a href="#"><img alt="FluentValidation" title="FluentValidation" height="30px"
                        src="https://img.shields.io/badge/-FluentValidation-CC2927?style=flat-square&logo=.net&logoColor=ffffff" /></a>
            </td>
    </tr>
  </tbody>
</table>

<h1 id="prerequisites" > Ön Gereklilikler Ve Kurulum</h1>

<p align="center">
<img align="right" width=200px height=200px alt="side_sticker" src="https://media.giphy.com/media/TEnXkcsHrP4YedChhA/giphy.gif" />
</p>

Aslında projeyi çalıştırmak oldukça basit.Uygulamayı başarılı bir şekilde çalıştırıp kullanmak için bilgisayarınızda en güncel dotnet sdk'sının kurulu olması gerekmektedir. Ardından ise veritabanı için **MongoDb** ve **Sql Server** veritabanlarına sahip olmanız gerekmektedir. Kurulumlarınızı eksiksiz tamamladıysanız yapmanız gereken ilk şey migration eklemek olacak bunu **BuildingManager.Data** katmanı içerisinde "**dotnet ef migrations add InitialCreate --context BuildingManagerDbContext --startup-project ../BuildingManager.Web**" komutu yardımıyla yapabilirsiniz. Daha sonra ise bu migration dosyası aracılığı ile veri tabanımızı kurmak için "**dotnet ef database update InitialCreate --context BuildingManagerDbContext --startup-project ../BuildingManager.Web**" komutunu kullanabilirsiniz.Uygulamayı çalıştırırken dikkat etmeniz gereken bir diğer husus ise ödeme servisi ve web uygulaması arasında bir port çakışması olmamasına dikkat etmeniz olacaktır. Uygulamayı çalıştırdığınızda size varsayılan olarak aşağıdaki credential'lar ile birlikte gelecektir.

* **Kullanıcı Adı** : admin@admin.com
* **Parola**: admin123admin

![](https://im.ge/i/1.OQE3T)
![](https://im.ge/i/2.OQCL0)
![](https://im.ge/i/3.OQtRr)
![](https://im.ge/i/4.OQAQW)
![](https://im.ge/i/5.OQP9m)
![](https://im.ge/i/6.OQxnc)
<h1 > İletişim</h1>

<p align="center">
</a>
<a href="https://www.linkedin.com/in/dogukanngumus/">
  <img alt="dogukanngumus's LinkdeIN" width="35px" src="https://image.flaticon.com/icons/png/512/174/174857.png" />
</a>
<a href="https://www.instagram.com/dogukngumus/">
  <img alt="dogukanngumus's Instagram" width="35px" src="https://image.flaticon.com/icons/svg/2111/2111421.svg" />
</a>
<a href="https://dogukanngumus.medium.com">
  <img alt="dogukanngumus's Medium" width="35px" src="https://image.flaticon.com/icons/png/512/725/725376.png" />
</a>
-
</p>

Merhaba ben Doğukan Muhittin Gümüş. **8 Mayıs - 27 Haziran** tarihleri arasında gerçekleşmiş, **Patika.dev Apsiyon .NET Core Bootcamp**'inden mezunum. Eğer **BuildingManager** projesi sizinde hoşunuza gittiyse, dilerseniz yukarıdaki kaynaklar aracılığı ile bana ulaşabilirsiniz.

<p align="center">
  <img align="center" alt="GIF" src="https://media1.tenor.com/images/1c6140897565e34a4e98f618e220dc0d/tenor.gif?itemid=9358372" />
</p>


