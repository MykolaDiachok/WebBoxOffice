using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBoxOffice.Domain;

namespace WebBoxOffice.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class AddNewDbRecords
    {
        private readonly WebBoxOfficeDbContext _boxOfficeDbContext;
        

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="boxOfficeDbContext"></param>
        public AddNewDbRecords(WebBoxOfficeDbContext boxOfficeDbContext)
        {
            _boxOfficeDbContext = boxOfficeDbContext;
        }
        /// <summary>
        /// AddNewRecords
        /// </summary>
        public void AddNewRecords()
        {
            var officeGuid = Guid.NewGuid();
            var office = new DataBoxOffice
            {
                Id = officeGuid,
                Name = "National Palace of Arts \"Ukraina\"",
                Description =
                    @$"The National Palace of Arts ""Ukraine"" in Kiev is located in the center of the capital on the street. Big Vasilkovskaya, 103.
                The scale of this concert hall is impressive: capacity - more than 3700 people, about 1500 people can be on stage at the same time! Original architecture, advanced technical equipment, an unprecedented level of comfort and capabilities -all this makes Kiev Palace “Ukraine” the first and main concert hall of the country.For more chamber events, a cozy Small Hall is provided.And for the audience and visitors to spend time here in comfort, the palace provides for several buffet areas and wardrobes.
                <b>For about 50 years, the Ukraine Palace in Kiev has been the main venue for national and international events.Advanced technical equipment, original architecture and the ability to accommodate a huge number of visitors are decisive advantages over other concert halls in Ukraine.</b>
                The main stage of the country - it is such a well - deserved status that the National Palace of Arts ""Ukraine"" in Kiev retains.The concert repertoire of the institution is quite versatile, there are:
                live show;
                rock operas;
                theatrical productions and performances;
                premieres of new albums;
                concerts of the best domestic artists and world stars;
                presentation of top music awards to the best pop artists and groups;
                Creative and anniversary evenings.
                The most explosive and vibrant events are presented on the poster of the Palace ""Ukraine"" in Kiev.Each visitor will be able to find a suitable event according to their interests in order to feel the incredible atmosphere and involvement in a musical holiday.At Concert.ua you can buy tickets online or order a courier delivery.


                Kyiv, Kiev, B.Vasilkovskaya, 103, m. ""The Palace of Ukraine"".",

            };
             _boxOfficeDbContext.Add(office);
            
            var greateHallId = Guid.NewGuid();
            var smallHallId = Guid.NewGuid();
            var hall = new List<Hall>
            {
                new Hall
                {
                    Id = greateHallId,
                    Name = "Great hall",
                    DataBoxOfficeId = officeGuid,
                    Description = "Great hall of the theater",
                    FreePlaces = 3714
                },
                new Hall
                {
                    Id = smallHallId,
                    Name = "Small hall",
                    DataBoxOfficeId = officeGuid,
                    Description = "Great hall of the theater",
                    FreePlaces = 211
                }
            };
            _boxOfficeDbContext.AddRange(hall);
            
            var salidaId = Guid.NewGuid();
            var DangerWomenId = Guid.NewGuid();
            var spectacles = new List<Spectacle>
            {
                new Spectacle
                {
                    Id = salidaId,
                    Name = "SALIDA CRUZADA - 8 шагов-танго",
                    ShortDescription = @"",
                    Description = @"Заказать и купить билеты на SALIDA CRUZADA - 8 шагов-танго можно онлайн через интернет. Оплата наличными возможна при покупке в кассе или курьеру (при заказе билета с доставкой).
Спектакль SALIDA CRUZADA - 8 шагов-танго в Киеве состоится 22 сентября 2020 г, 19:00, Национальный дворец искусств Украина .
8 шагов танго - соответствуют этапам отношений между мужчинами и женщинами - встреча, узнавание, близость ...
""Мы входим в любовь, как в танец, а танец - это схема, которая работает безотказно "" - утверждает герой пьесы - учитель танго. Но люди, которые пришли танцевать - не ищут схему - они ищут любовь.",
                    Duration = 60
                },
                new Spectacle
                {
                    Id = DangerWomenId,
                    Name = "Осторожно, женщины!",
                    ShortDescription = @"Киевский театр «Тысячелетие»
                    Комедия «Осторожно, женщины!»
                    Режиссер-постановщик Ирина Малыгина
                    Хореограф Алекс Телешко
                    Длительность спектакля: 120 мин.с антрактом.",
                    Description = @"Приди Жаклин на десять минут раньше: о, что могло бы случиться!
Да, это как будто прогулка по минному полю. Всё время на волоске. Причём совершенное неспециально. Совершенно! И как так получается - сам не знаю.
Совершенно искренне пытаешься вести праведную, нормальную, честную жизнь: встречаешь девушку, красивую, замечательную, влюбляешься в неё: Живёшь. Живёшь, живёшь, живешь: А затем вдруг встречаешь ещё одну девушку, тоже красивую, тоже замечательную, и ты тоже пытаешься вести праведную, нормальную, честную жизнь, но уже и с ней. Затем ещё кого-нибудь встречаешь: И в итоге у тебя три правильные, нормальные, честные жизни, а ты сам при этом типичный, аморальный и бесчестный лицемер.
Парадокс какой-то: Тайна природы.
(отрывок из пьесы ""Осторожно - женщины!"")
                    Роли исполняют:
                    Серж - Геннадий Свитич / Вячеслав Станишевский
                    Жаклин - Татьяна Лещенко / Ирина Малыгина
                    Марисабель - Евгения Белова
                    Лулу - Маргарита Савкун",
                    Duration = 120
                }
            };
            _boxOfficeDbContext.AddRange(spectacles);
            

            var links = new List<SpectaclesLinks>
            {
                new SpectaclesLinks
                {
                    Id = Guid.NewGuid(),
                    SpectacleId = salidaId,
                    Url = "https://kiev.karabas.com/salida-cruzada-8-shagov-tango-83",
                    ContentUrl = "https://image.karabas.com/w/350/h/496/f/files/import/1547256497_ImageBig636815092419712679.jpeg"
                },
                new SpectaclesLinks
                {
                    Id = Guid.NewGuid(),
                    SpectacleId = DangerWomenId,
                    Url = "https://kiev.karabas.com/ostorozhno-zhenshiny-kievskij-teatr-tysyacheletie-40",
                    ContentUrl = "https://image.karabas.com/w/350/h/496/f/files/import/1339512055_ImageBig637275714514858896.jpeg"
                },
                new SpectaclesLinks
                {
                    Id = Guid.NewGuid(),
                    SpectacleId = DangerWomenId,
                    ContentUrl = "https://image.karabas.com/magican/cropResize/w/320/h/240/f/files/activities/26026015_2064233903856706_8176267217991442112_o.jpg"
                },
                new SpectaclesLinks
                {
                    Id = Guid.NewGuid(),
                    SpectacleId = DangerWomenId,
                    ContentUrl = "https://img.youtube.com/vi/4kc4_KUK99c/0.jpg"
                },
                new SpectaclesLinks
                {
                    Id = Guid.NewGuid(),
                    SpectacleId = DangerWomenId,
                    ContentUrl = "https://image.karabas.com/magican/cropResize/w/320/h/240/f/files/activities/26026098_2064236687189761_7967015420148366208_o.jpg"
                },
                new SpectaclesLinks
                {
                    Id = Guid.NewGuid(),
                    SpectacleId = DangerWomenId,
                    ContentUrl = "https://image.karabas.com/magican/cropResize/w/320/h/240/f/files/activities/26116281_2064238017189628_5635524866839700894_o.jpg"
                },
                new SpectaclesLinks
                {
                    Id = Guid.NewGuid(),
                    SpectacleId = DangerWomenId,
                    ContentUrl = "https://image.karabas.com/magican/cropResize/w/320/h/240/f/files/activities/26166066_2064234217190008_6356108737480690182_n.jpg"
                },
                new SpectaclesLinks
                {
                    Id = Guid.NewGuid(),
                    SpectacleId = DangerWomenId,
                    ContentUrl = "https://image.karabas.com/magican/cropResize/w/320/h/240/f/files/activities/26171781_2064240587189371_4811556720779617481_o.jpg"
                }

            };
            _boxOfficeDbContext.AddRange(links);
            
            var scDangerWomenId = Guid.NewGuid();
            var scSalidaId = Guid.NewGuid();
            var schedules = new List<Schedule>
            {
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "SALIDA CRUZADA - 8 шагов-танго",
                    HallId = smallHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,09,22,19,00,00),
                    EndTime = new DateTime(2020,09,22,20,00,00),
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "SALIDA CRUZADA - 8 шагов-танго",
                    HallId = smallHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,10,01,19,00,00),
                    EndTime = new DateTime(2020,10,01,20,00,00),
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "SALIDA CRUZADA - 8 шагов-танго",
                    HallId = smallHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,10,16,19,00,00),
                    EndTime = new DateTime(2020,10,16,20,00,00),
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "SALIDA CRUZADA - 8 шагов-танго",
                    HallId = smallHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,10,17,19,00,00),
                    EndTime = new DateTime(2020,10,17,20,00,00),
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "SALIDA CRUZADA - 8 шагов-танго",
                    HallId = smallHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,10,29,19,00,00),
                    EndTime = new DateTime(2020,10,29,20,00,00),
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "SALIDA CRUZADA - 8 шагов-танго",
                    HallId = smallHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,10,30,19,00,00),
                    EndTime = new DateTime(2020,10,30,20,00,00),
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "Осторожно, женщины!",
                    HallId = greateHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,09,27,19,00,00),
                    EndTime = new DateTime(2020,09,27,21,00,00),
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "Осторожно, женщины!",
                    HallId = greateHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,10,7,19,00,00),
                    EndTime = new DateTime(2020,10,7,21,00,00),
                },
                new Schedule
                {
                    Id = Guid.NewGuid(),
                    Name = "Осторожно, женщины!",
                    HallId = greateHallId,
                    Enabled = true,
                    SpectacleId = salidaId,
                    StartTime = new DateTime(2020,10,14,19,00,00),
                    EndTime = new DateTime(2020,10,14,21,00,00),
                },
            };
             _boxOfficeDbContext.AddRange(schedules);
             _boxOfficeDbContext.SaveChanges();


        }
    }
}