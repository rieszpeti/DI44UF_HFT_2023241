﻿using System;
using Microsoft.EntityFrameworkCore;
using DI44UF_HFT_2023241.Models;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Repository
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public OrderDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                 .HasOne(c => c.Address)
                 .WithMany(a => a.Customers)
                 .HasForeignKey(c => c.AddressId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerId);

            //modelBuilder.Entity<Product>()
            //    .HasMany(x => x.Orders)
            //    .WithMany(x => x.Products)
            //    .UsingEntity<OrderItem>(
            //        x => x.HasOne(x => x.Order)
            //            .WithMany().HasForeignKey(x => x.OrderId),
            //        x => x.HasOne(x => x.Product)
            //            .WithMany().HasForeignKey(x => x.ProductId));

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Products)
                .WithMany(x => x.Orders)
                .UsingEntity<OrderDetail>(
                    x => x.HasOne(x => x.Product)
                        .WithMany().HasForeignKey(x => x.ProductId),
                    x => x.HasOne(x => x.Order)
                    .WithMany().HasForeignKey(x => x.OrderId));

            modelBuilder.Entity<Customer>().HasData(new Customer[]
            { 
                new Customer 
                { 
                    CustomerId = 1,
                    AddressId = 1,
                    Name = "Foo",
                }
            });

            modelBuilder.Entity<Address>().HasData(new Address[]
            {
                new Address
                {
                    AddressId = 1,
                    PostalCode = "2023",
                    Country = "HU",
                    City = "Bp",
                    Region = "Bp"
                }
            });

            List<Product> products = new List<Product>()
            {
                 new Product
                {
                    OrderItemId = 1,
                    Description = "Test",
                    Id = 1,
                    Name = "Test",
                    Size = "Test"
                }
            };

            modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order
                {
                    CustomerId = 1,
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                }
            });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail[]
            {
                new OrderDetail
                {
                    OrderItemId = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 1
                }
            });


            modelBuilder.Entity<Movie>(movie => movie
                .HasOne(movie => movie.Director)
                .WithMany(director => director.Movies)
                .HasForeignKey(movie => movie.DirectorId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Actor>()
                .HasMany(x => x.Movies)
                .WithMany(x => x.Actors)
                .UsingEntity<Role>(
                    x => x.HasOne(x => x.Movie)
                        .WithMany().HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.Actor)
                        .WithMany().HasForeignKey(x => x.ActorId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Actor)
                .WithMany(actor => actor.Roles)
                .HasForeignKey(r => r.ActorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Movie)
                .WithMany(movie => movie.Roles)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Movie>().HasData(new Movie[]
            {
                new Movie("1#Iron Man#585,8#1#2008*05*02#7,9"),
                new Movie("2#The Incredible Hulk#264,8#2#2008*06*13#6,6"),
                new Movie("3#Iron Man 2#623,9#1#2010*05*07#6,9"),
                new Movie("4#Thor#449,3#3#2011*05*06#7"),
                new Movie("5#Captain America: The First Avenger#370,6#4#2011*07*22#6,9"),
                new Movie("6#The Avengers#1519#5#2012*05*04#8"),
                new Movie("7#Iron Man 3#1214#6#2013*05*03#7,1"),
                new Movie("8#Thor: The Dark World#644,8#7#2013*11*08#6,8"),
                new Movie("9#Captain America: The Winter Soldier#714,4#8#2014*04*04#6,9"),
                new Movie("10#Guardians of the Galaxy#772,8#9#2014*08*01#8"),
                new Movie("11#Avengers: Age of Ultron#1403#5#2015*05*01#7,3"),
                new Movie("12#Ant-Man#519,3#10#2015*07*17#7,3"),
                new Movie("13#Captain America: Civil War#1153#8#2016*05*06#7,8"),
                new Movie("14#Doctor Strange#677,7#11#2016*11*04#7,5"),
                new Movie("15#Guardians of the Galaxy Vol. 2#863,8#9#2017*05*05#7,6"),
                new Movie("16#Spider-Man: Homecoming#880,2#12#2017*07*07#7,4"),
                new Movie("17#Thor: Ragnarok#854#13#2017*11*03#7,9"),
                new Movie("18#Black Panther#1348#14#2018*02*16#7,3"),
                new Movie("19#Avengers: Infinity War#2048#8#2018*04*27#8,4"),
                new Movie("20#Ant-Man and the Wasp#622,7#10#2018*07*06#7"),
                new Movie("21#Captain Marvel#1128#15#2019*03*08#6,8"),
                new Movie("22#Avengers: Endgame#2798#8#2019*04*26#8,4"),
                new Movie("23#Spider-Man: Far From Home#1132#12#2019*07*02#7,4"),
                new Movie("24#Black Widow#379,6#16#2021*07*09#6,7"),
                new Movie("25#Shang-Chi and the Legend of the Ten Rings#432,2#17#2021*09*03#7,5"),
                new Movie("26#Eternals#402,1#18#2021*11*05#6,4"),
                new Movie("27#Spider-Man: No Way Home#1804#12#2021*12*17#8,7"),
            });

            modelBuilder.Entity<Director>().HasData(new Director[]
            {
                   new Director("1#Jon Favreau"),
                new Director("2#Louis Leterrier"),
                new Director("3#Kenneth Branagh"),
                new Director("4#Joe Johnston"),
                new Director("5#Joss Whedon"),
                new Director("6#Shane Black"),
                new Director("7#Alan Taylor"),
                new Director("8#Anthony and Joe Russo"),
                new Director("9#James Gunn"),
                new Director("10#Peyton Reed"),
                new Director("11#Scott Derrickson"),
                new Director("12#Jon Watts"),
                new Director("13#Taika Waititi"),
                new Director("14#Ryan Coogler"),
                new Director("15#Anna Boden and Ryan Fleck"),
                new Director("16#Cate Shortland"),
                new Director("17#Destin Daniel Cretton"),
                new Director("18#ChloĂŠ Zhao"),
            });

            modelBuilder.Entity<Actor>().HasData(new Actor[]
            {
                new Actor("1#Aaron Schwartz"),
                new Actor("2#Aaron Taylor-Johnson"),
                new Actor("3#Abby Ryder Fortson"),
                new Actor("4#Abraham Attah"),
                new Actor("5#Adewale Akinnuoye-Agbaje"),
                new Actor("6#Adriana Barraza"),
                new Actor("7#Alaa Safi"),
                new Actor("8#Alan Scott"),
                new Actor("9#Alfred Molina"),
                new Actor("10#Algenis Perez Soto"),
                new Actor("11#Alice Krige"),
                new Actor("12#Amali Golden"),
                new Actor("13#Amy Landecker"),
                new Actor("14#Andrew Garfield"),
                new Actor("15#Andy Le"),
                new Actor("16#Andy Serkis"),
                new Actor("17#Angela Bassett"),
                new Actor("18#Angelina Jolie"),
                new Actor("19#Angourie Rice"),
                new Actor("20#Annette Bening"),
                new Actor("21#Anthony Hopkins"),
                new Actor("22#Anthony Mackie"),
                new Actor("23#Arian Moayed"),
                new Actor("24#Arnold Sun"),
                new Actor("25#Awkwafina"),
                new Actor("26#Barry Keoghan"),
                new Actor("27#Ben Kingsley"),
                new Actor("28#Ben Mendelsohn"),
                new Actor("29#Benedict Cumberbatch"),
                new Actor("30#Benedict Wong"),
                new Actor("31#Benicio Del Toro"),
                new Actor("32#Benjamin Bratt"),
                new Actor("33#Bill Skarsgård"),
                new Actor("34#Bill Smitrovich"),
                new Actor("35#Bobby Cannavale"),
                new Actor("36#Bokeem Woodbine"),
                new Actor("37#Bradley Cooper"),
                new Actor("38#Brian Tyree Henry"),
                new Actor("39#Brie Larson"),
                new Actor("40#Bruno Ricci"),
                new Actor("41#Cate Blanchett"),
                new Actor("42#Chadwick Boseman"),
                new Actor("43#Charlie Cox"),
                new Actor("44#Chiwetel Ejiofor"),
                new Actor("45#Chris Evans"),
                new Actor("46#Chris Hemsworth"),
                new Actor("47#Chris Pratt"),
                new Actor("48#Chris Sullivan"),
                new Actor("49#Christina Cabot"),
                new Actor("50#Christopher Eccleston"),
                new Actor("51#Christopher Fairbank"),
                new Actor("52#Clancy Brown"),
                new Actor("53#Clark Gregg"),
                new Actor("54#Clive Russell"),
                new Actor("55#Cobie Smulders"),
                new Actor("56#Colm Feore"),
                new Actor("57#Connie Chiume"),
                new Actor("58#Corey Stoll"),
                new Actor("59#Danai Gurira"),
                new Actor("60#Daniel Brühl"),
                new Actor("61#Daniel Kaluuya"),
                new Actor("62#Dave Bautista"),
                new Actor("63#David Dastmalchian"),
                new Actor("64#David Harbour"),
                new Actor("65#David S. Lee"),
                new Actor("66#Débora Nascimento"),
                new Actor("67#Derek Luke"),
                new Actor("68#Divian Ladwa"),
                new Actor("69#Djimon Hounsou"),
                new Actor("70#Dominic Cooper"),
                new Actor("71#Don Cheadle"),
                new Actor("72#Donald Glover"),
                new Actor("73#Edward Norton"),
                new Actor("74#Elizabeth Debicki"),
                new Actor("75#Elizabeth Olsen"),
                new Actor("76#Elodie Fong"),
                new Actor("77#Emily VanCamp"),
                new Actor("78#Esai Daniel Cross"),
                new Actor("79#Evangeline Lilly"),
                new Actor("80#Ever Anderson"),
                new Actor("81#Fala Chen"),
                new Actor("82#Faran Tahir"),
                new Actor("83#Florence Kasumba"),
                new Actor("84#Florence Pugh"),
                new Actor("85#Florian Munteanu"),
                new Actor("86#Forest Whitaker"),
                new Actor("87#Frank Grillo"),
                new Actor("88#Garrett Morris"),
                new Actor("89#Garry Shandling"),
                new Actor("90#Gemma Chan"),
                new Actor("91#Georgia Blizzard"),
                new Actor("92#Glenn Close"),
                new Actor("93#Goran Kostic"),
                new Actor("94#Gregg Turkington"),
                new Actor("95#Guy Pearce"),
                new Actor("96#Gwyneth Paltrow"),
                new Actor("97#Haaz Sleiman"),
                new Actor("98#Hannah Dodd"),
                new Actor("99#Hannah Harlow"),
                new Actor("100#Hannah John-Kamen"),
                new Actor("101#Hannibal Buress"),
                new Actor("102#Harish Patel"),
                new Actor("103#Haroon Khan"),
                new Actor("104#Harry Styles"),
                new Actor("105#Hayley Atwell"),
                new Actor("106#Hugo Weaving"),
                new Actor("107#Idris Elba"),
                new Actor("108#Isaach De Bankolé"),
                new Actor("109#J.B. Smoove"),
                new Actor("110#J.K. Simmons"),
                new Actor("111#Jacob Batalon"),
                new Actor("112#Jaimie Alexander"),
                new Actor("113#Jake Gyllenhaal"),
                new Actor("114#James Badge Dale"),
                new Actor("115#James Spader"),
                new Actor("116#Jamie Foxx"),
                new Actor("117#Jayden Zhang"),
                new Actor("118#Jeff Bridges"),
                new Actor("119#Jeff Goldblum"),
                new Actor("120#Jeremy Renner"),
                new Actor("121#JJ Feild"),
                new Actor("122#Jodi Long"),
                new Actor("123#John C. Reilly"),
                new Actor("124#John Kani"),
                new Actor("125#John Slattery"),
                new Actor("126#Jon Favreau"),
                new Actor("127#Jonathan Howard"),
                new Actor("128#Jorge Lendeborg Jr."),
                new Actor("129#Josh Dallas"),
                new Actor("130#Jude Law"),
                new Actor("131#Judy Greer"),
                new Actor("132#Karen Gillan"),
                new Actor("133#Karl Urban"),
                new Actor("134#Kat Dennings"),
                new Actor("135#Kathleen Cardoso"),
                new Actor("136#Katrina Durden"),
                new Actor("137#Kenneth Choi"),
                new Actor("138#Khalili Dastan"),
                new Actor("139#Kit Harington"),
                new Actor("140#Krystian Godlewski"),
                new Actor("141#Kumail Nanjiani"),
                new Actor("142#Kunal Dudheker"),
                new Actor("143#Kurt Russell"),
                new Actor("144#Lashana Lynch"),
                new Actor("145#Laura Haddock"),
                new Actor("146#Laura Harrier"),
                new Actor("147#Lauren Ridloff"),
                new Actor("148#Laurence Fishburne"),
                new Actor("149#Lee Pace"),
                new Actor("150#Leslie Bibb"),
                new Actor("151#Letitia Wright"),
                new Actor("152#Lewis Young"),
                new Actor("153#Lex Shrapnel"),
                new Actor("154#Lia McHugh"),
                new Actor("155#Liani Samuel"),
                new Actor("156#Linda Cardellini"),
                new Actor("157#Linda Louise Duan"),
                new Actor("158#Liv Tyler"),
                new Actor("159#Lou Ferrigno"),
                new Actor("160#Lupita Nyong'o"),
                new Actor("161#Ma Dong-seok"),
                new Actor("162#Mads Mikkelsen"),
                new Actor("163#Marco Khan"),
                new Actor("164#Marisa Tomei"),
                new Actor("165#Mark Anthony Brighton"),
                new Actor("166#Mark Ruffalo"),
                new Actor("167#Martin Donovan"),
                new Actor("168#Martin Freeman"),
                new Actor("169#Martin Starr"),
                new Actor("170#Mary Rivera"),
                new Actor("171#Maximiliano Hernández"),
                new Actor("172#Meera Syal"),
                new Actor("173#Meng'er Zhang"),
                new Actor("174#Michael B. Jordan"),
                new Actor("175#Michael Douglas"),
                new Actor("176#Michael Keaton"),
                new Actor("177#Michael Peña"),
                new Actor("178#Michael Rooker"),
                new Actor("179#Michael Stuhlbarg"),
                new Actor("180#Michelle Lee"),
                new Actor("181#Michelle Pfeiffer"),
                new Actor("182#Michelle Yeoh"),
                new Actor("183#Mickey Rourke"),
                new Actor("184#Nabiyah Be"),
                new Actor("185#Natalie Portman"),
                new Actor("186#Neal McDonough"),
                new Actor("187#Numan Acar"),
                new Actor("188#Olga Kurylenko"),
                new Actor("189#O-T Fagbenle"),
                new Actor("190#Paul Bettany"),
                new Actor("191#Paul Rudd"),
                new Actor("192#Paul Soles"),
                new Actor("193#Paul W. He"),
                new Actor("194#Paula Newsome"),
                new Actor("195#Peter Billingsley"),
                new Actor("196#Peter Mensah"),
                new Actor("197#Peter Serafinowicz"),
                new Actor("198#Pom Klementieff"),
                new Actor("199#Rachel House"),
                new Actor("200#Rachel McAdams"),
                new Actor("201#Rachel Weisz"),
                new Actor("202#Ramone Morgan"),
                new Actor("203#Randall Park"),
                new Actor("204#Ray Stevenson"),
                new Actor("205#Ray Winstone"),
                new Actor("206#Rebecca Hall"),
                new Actor("207#Remy Hii"),
                new Actor("208#Rene Russo"),
                new Actor("209#Rhys Ifans"),
                new Actor("210#Richard Armitage"),
                new Actor("211#Richard Madden"),
                new Actor("212#Robert Downey Jr."),
                new Actor("213#Robert Redford"),
                new Actor("214#Rod Hallett"),
                new Actor("215#Rune Temte"),
                new Actor("216#Ryan Kiera Armstrong"),
                new Actor("217#Salma Hayek"),
                new Actor("218#Sam Rockwell"),
                new Actor("219#Samuel L. Jackson"),
                new Actor("220#Sayed Badreya"),
                new Actor("221#Scarlett Johansson"),
                new Actor("222#Scott Adkins"),
                new Actor("223#Sean Gunn"),
                new Actor("224#Sebastian Stan"),
                new Actor("225#Selenis Leyva"),
                new Actor("226#Shaun Toub"),
                new Actor("227#Simu Liu"),
                new Actor("228#Stanley Tucci"),
                new Actor("229#Stellan Skarsgård"),
                new Actor("230#Stephanie Hsu"),
                new Actor("231#Stephanie Szostak"),
                new Actor("232#Sterling K. Brown"),
                new Actor("233#Sylvester Stallone"),
                new Actor("234#T.I."),
                new Actor("235#Tadanobu Asano"),
                new Actor("236#Taika Waititi"),
                new Actor("237#Terrence Howard"),
                new Actor("238#Tessa Thompson"),
                new Actor("239#Thomas Haden Church"),
                new Actor("240#Tilda Swinton"),
                new Actor("241#Tim Blake Nelson"),
                new Actor("242#Tim Guinee"),
                new Actor("243#Tim Roth"),
                new Actor("244#Tobey Maguire"),
                new Actor("245#Toby Jones"),
                new Actor("246#Tom Hiddleston"),
                new Actor("247#Tom Holland"),
                new Actor("248#Tom Morello"),
                new Actor("249#Tommy Flanagan"),
                new Actor("250#Tommy Lee Jones"),
                new Actor("251#Tony Chiu-Wai Leung"),
                new Actor("252#Tony Revolori"),
                new Actor("253#Topo Wresniwiro"),
                new Actor("254#Tsai Chin"),
                new Actor("255#Ty Burrell"),
                new Actor("256#Tyne Daly"),
                new Actor("257#Umit Ulgen"),
                new Actor("258#Vin Diesel"),
                new Actor("259#Violet McGraw"),
                new Actor("260#Wah Yuen"),
                new Actor("261#Walton Goggins"),
                new Actor("262#Will Lyman"),
                new Actor("263#Willem Dafoe"),
                new Actor("264#William Hurt"),
                new Actor("265#Winston Duke"),
                new Actor("266#Wood Harris"),
                new Actor("267#Wyatt Oleff"),
                new Actor("268#Yasmin Mwanza"),
                new Actor("269#Zach Barack"),
                new Actor("270#Zachary Levi"),
                new Actor("271#Zara Phythian"),
                new Actor("272#Zendaya"),
                new Actor("273#Zoe Saldana"),
                new Actor("274#Zoha Rahman"),

            });

            modelBuilder.Entity<Role>().HasData(new Role[]
            {
                new Role("1#1#212#1#Tony Stark"),
                new Role("2#1#96#2#Pepper Potts"),
                new Role("3#1#237#3#Rhodey"),
                new Role("4#1#118#4#Obadiah Stane"),
                new Role("5#1#150#5#Christine Everhart"),
                new Role("6#1#226#6#Yinsen"),
                new Role("7#1#82#7#Raza"),
                new Role("8#1#53#8#Agent Coulson"),
                new Role("9#1#34#9#General Gabriel"),
                new Role("10#1#220#10#Abu Bakaar"),
                new Role("11#1#190#11#JARVIS"),
                new Role("12#1#126#12#Hogan"),
                new Role("13#1#195#13#William Ginter Riva"),
                new Role("14#1#242#14#Major Allen"),
                new Role("15#1#262#15#Award Ceremony Narrator"),
                new Role("16#1#248#16#Guard"),
                new Role("17#1#163#17#Guard"),
                new Role("18#1#138#18#Guard"),
                new Role("19#2#73#1#Bruce Banner"),
                new Role("20#2#158#2#Betty Ross"),
                new Role("21#2#243#3#Emil Blonsky"),
                new Role("22#2#264#4#General 'Thunderbolt' Ross"),
                new Role("23#2#241#5#Samuel Sterns"),
                new Role("24#2#255#6#Leonard"),
                new Role("25#2#49#7#Major Kathleen Sparr"),
                new Role("26#2#196#8#General Joe Greller"),
                new Role("27#2#159#9#Voice of The Incredible Hulk"),
                new Role("28#2#192#10#Stanley"),
                new Role("29#2#66#11#Martina"),
                new Role("30#3#212#1#Tony Stark"),
                new Role("31#3#183#2#Ivan Vanko"),
                new Role("32#3#96#3#Pepper Potts"),
                new Role("33#3#71#4#Lt. Col. James 'Rhodey' Rhodes"),
                new Role("34#3#221#5#Natalie Rushman"),
                new Role("35#3#218#6#Justin Hammer"),
                new Role("36#3#219#7#Nick Fury"),
                new Role("37#3#53#8#Agent Coulson"),
                new Role("38#3#125#9#Howard Stark"),
                new Role("39#3#89#10#Senator Stern"),
                new Role("40#3#190#11#JARVIS"),
                new Role("41#4#46#1#Thor"),
                new Role("42#4#21#2#Odin"),
                new Role("43#4#185#3#Jane Foster"),
                new Role("44#4#246#4#Loki"),
                new Role("45#4#229#5#Erik Selvig"),
                new Role("46#4#134#6#Darcy Lewis"),
                new Role("47#4#53#7#Agent Coulson"),
                new Role("48#4#56#8#King Laufey"),
                new Role("49#4#107#9#Heimdall"),
                new Role("50#4#204#10#Volstagg"),
                new Role("51#4#235#11#Hogun"),
                new Role("52#4#129#12#Fandral"),
                new Role("53#4#112#13#Sif"),
                new Role("54#4#208#14#Frigga"),
                new Role("55#4#6#15#Isabela Alvarez"),
                new Role("56#4#171#16#Agent Sitwell"),
                new Role("57#5#45#1#Captain America"),
                new Role("58#5#106#2#Johann Schmidt"),
                new Role("59#5#219#3#Nick Fury"),
                new Role("60#5#105#4#Peggy Carter"),
                new Role("61#5#224#5#James Buchanan 'Bucky' Barnes"),
                new Role("62#5#250#6#Colonel Chester Phillips"),
                new Role("63#5#70#7#Howard Stark"),
                new Role("64#5#210#8#Heinz Kruger"),
                new Role("65#5#228#9#Dr. Abraham Erskine"),
                new Role("66#5#245#10#Dr. Arnim Zola"),
                new Role("67#5#186#11#Timothy 'Dum Dum' Dugan"),
                new Role("68#5#67#12#Gabe Jones"),
                new Role("69#5#137#13#Jim Morita"),
                new Role("70#5#121#14#James Montgomery Falsworth"),
                new Role("71#5#40#15#Jacques Dernier"),
                new Role("72#5#153#16#Gilmore Hodge"),
                new Role("73#6#212#1#Tony Stark"),
                new Role("74#6#45#2#Steve Rogers"),
                new Role("75#6#221#3#Natasha Romanoff"),
                new Role("76#6#120#4#Clint Barton"),
                new Role("77#6#166#5#Bruce Banner"),
                new Role("78#6#46#6#Thor"),
                new Role("79#6#246#7#Loki"),
                new Role("80#6#53#8#Agent Phil Coulson"),
                new Role("81#6#55#9#Agent Maria Hill"),
                new Role("82#6#229#10#Selvig"),
                new Role("83#6#219#11#Nick Fury"),
                new Role("84#6#96#12#Pepper Potts"),
                new Role("85#6#190#13#Jarvis"),
                new Role("86#7#212#1#Tony Stark"),
                new Role("87#7#95#2#Aldrich Killian"),
                new Role("88#7#96#3#Pepper Potts"),
                new Role("89#7#71#4#Colonel James Rhodes"),
                new Role("90#7#206#5#Maya Hansen"),
                new Role("91#7#126#6#Happy Hogan"),
                new Role("92#7#27#7#Trevor Slattery"),
                new Role("93#7#114#8#Savin"),
                new Role("94#7#231#9#Brandt"),
                new Role("95#7#190#10#JARVIS"),
                new Role("96#8#46#1#Thor"),
                new Role("97#8#185#2#Jane Foster"),
                new Role("98#8#246#3#Loki"),
                new Role("99#8#229#4#Erik Selvig"),
                new Role("100#8#21#5#Odin"),
                new Role("101#8#50#6#Malekith"),
                new Role("102#8#112#7#Sif"),
                new Role("103#8#270#8#Fandral"),
                new Role("104#8#204#9#Volstagg"),
                new Role("105#8#235#10#Hogun"),
                new Role("106#8#107#11#Heimdall"),
                new Role("107#8#208#12#Frigga"),
                new Role("108#8#5#13#Algrim"),
                new Role("109#8#134#14#Darcy Lewis"),
                new Role("110#8#11#15#Eir"),
                new Role("111#8#54#16#Tyr"),
                new Role("112#8#127#17#Ian Boothby"),
                new Role("113#8#202#18#John"),
                new Role("114#9#45#1#Steve Rogers"),
                new Role("115#9#219#2#Nick Fury"),
                new Role("116#9#221#3#Natasha Romanoff"),
                new Role("117#9#213#4#Alexander Pierce"),
                new Role("118#9#224#5#Bucky Barnes"),
                new Role("119#9#22#6#Sam Wilson"),
                new Role("120#9#55#7#Maria Hill"),
                new Role("121#9#87#8#Brock Rumlow"),
                new Role("122#9#171#9#Jasper Sitwell"),
                new Role("123#10#47#1#Peter Quill"),
                new Role("124#10#258#2#Groot"),
                new Role("125#10#37#3#Rocket"),
                new Role("126#10#273#4#Gamora"),
                new Role("127#10#62#5#Drax"),
                new Role("128#10#149#6#Ronan"),
                new Role("129#10#178#7#Yondu Udonta"),
                new Role("130#10#132#8#Nebula"),
                new Role("131#10#69#9#Korath"),
                new Role("132#10#123#10#Corpsman Dey"),
                new Role("133#10#92#11#Nova Prime"),
                new Role("134#10#31#12#The Collector"),
                new Role("135#10#145#13#Meredith Quill"),
                new Role("136#10#223#14#Kraglin…"),
                new Role("137#10#197#15#Denarian Saal"),
                new Role("138#10#51#16#The Broker"),
                new Role("139#10#140#17#On Set Groot"),
                new Role("140#10#267#18#Young Quill"),
                new Role("141#11#212#1#Tony Stark"),
                new Role("142#11#45#2#Steve Rogers"),
                new Role("143#11#166#3#Bruce Banner"),
                new Role("144#11#46#4#Thor"),
                new Role("145#11#221#5#Natasha Romanoff"),
                new Role("146#11#120#6#Clint Barton"),
                new Role("147#11#115#7#Ultron"),
                new Role("148#11#219#8#Nick Fury"),
                new Role("149#11#71#9#James Rhodes"),
                new Role("150#11#2#10#Pietro Maximoff"),
                new Role("151#11#75#11#Wanda Maximoff"),
                new Role("152#11#190#12#Jarvis"),
                new Role("153#11#55#13#Maria Hill"),
                new Role("154#11#22#14#Sam Wilson"),
                new Role("155#11#105#15#Peggy Carter"),
                new Role("156#11#107#16#Heimdall"),
                new Role("157#11#156#17#Laura Barton"),
                new Role("158#11#229#18#Erik Selvig"),
                new Role("159#12#191#1#Scott Lang"),
                new Role("160#12#175#2#Dr. Hank Pym"),
                new Role("161#12#58#3#Darren Cross"),
                new Role("162#12#79#4#Hope Van Dyne"),
                new Role("163#12#35#5#Paxton"),
                new Role("164#12#22#6#Sam Wilson"),
                new Role("165#12#131#7#Maggie Lang"),
                new Role("166#12#3#8#Cassie Lang"),
                new Role("167#12#177#9#Luis"),
                new Role("168#12#63#10#Kurt"),
                new Role("169#12#234#11#Dave"),
                new Role("170#12#266#12#Gale"),
                new Role("171#12#105#13#Peggy Carter"),
                new Role("172#12#125#14#Howard Stark"),
                new Role("173#12#167#15#Mitchell Carson"),
                new Role("174#12#88#16#Cab Driver"),
                new Role("175#12#94#17#Dale"),
                new Role("176#12#214#18#Hydra Buyer"),
                new Role("177#13#45#1#Steve Rogers"),
                new Role("178#13#212#2#Tony Stark"),
                new Role("179#13#221#3#Natasha Romanoff"),
                new Role("180#13#224#4#Bucky Barnes"),
                new Role("181#13#22#5#Sam Wilson"),
                new Role("182#13#71#6#Lieutenant James Rhodes"),
                new Role("183#13#120#7#Clint Barton"),
                new Role("184#13#42#8#T'Challa"),
                new Role("185#13#190#9#Vision"),
                new Role("186#13#75#10#Wanda Maximoff"),
                new Role("187#13#191#11#Scott Lang"),
                new Role("188#13#77#12#Sharon Carter"),
                new Role("189#13#247#13#Peter Parker"),
                new Role("190#13#60#14#Zemo"),
                new Role("191#13#87#15#Brock Rumlow"),
                new Role("192#13#264#16#Secretary of State Thaddeus Ross"),
                new Role("193#13#168#17#Everett K. Ross"),
                new Role("194#13#164#18#May Parker"),
                new Role("195#14#29#1#Dr. Stephen Strange"),
                new Role("196#14#44#2#Mordo"),
                new Role("197#14#200#3#Dr. Christine Palmer"),
                new Role("198#14#30#4#Wong"),
                new Role("199#14#162#5#Kaecilius"),
                new Role("200#14#240#6#The Ancient One"),
                new Role("201#14#179#7#Dr. Nicodemus West"),
                new Role("202#14#32#8#Jonathan Pangborn"),
                new Role("203#14#222#9#Lucian…"),
                new Role("204#14#271#10#Brunette Zealot"),
                new Role("205#14#7#11#Tall Zealot"),
                new Role("206#14#136#12#Blonde Zealot"),
                new Role("207#14#253#13#Hamir"),
                new Role("208#14#257#14#Sol Rama"),
                new Role("209#14#157#15#Tina Minoru"),
                new Role("210#14#165#16#Daniel Drumm"),
                new Role("211#14#172#17#Dr. Patel"),
                new Role("212#14#13#18#Dr. Bruner"),
                new Role("213#15#47#1#Peter Quill"),
                new Role("214#15#273#2#Gamora"),
                new Role("215#15#62#3#Drax"),
                new Role("216#15#258#4#Baby Groot"),
                new Role("217#15#37#5#Rocket"),
                new Role("218#15#178#6#Yondu"),
                new Role("219#15#132#7#Nebula"),
                new Role("220#15#198#8#Mantis"),
                new Role("221#15#233#9#Stakar Ogord"),
                new Role("222#15#143#10#Ego"),
                new Role("223#15#74#11#Ayesha"),
                new Role("224#15#48#12#Taserface"),
                new Role("225#15#223#13#Kraglin"),
                new Role("226#15#249#14#Tullk"),
                new Role("227#15#145#15#Meredith Quill"),
                new Role("228#15#1#16#Young Ego Facial Reference"),
                new Role("229#15#99#17#Sovereign Chambermaid"),
                new Role("230#16#247#1#Peter Parker"),
                new Role("231#16#176#2#Adrian Toomes"),
                new Role("232#16#212#3#Tony Stark"),
                new Role("233#16#164#4#May Parker"),
                new Role("234#16#126#5#Happy Hogan"),
                new Role("235#16#96#6#Pepper Potts"),
                new Role("236#16#272#7#Michelle"),
                new Role("237#16#72#8#Aaron Davis"),
                new Role("238#16#111#9#Ned"),
                new Role("239#16#146#10#Liz"),
                new Role("240#16#252#11#Flash"),
                new Role("241#16#36#12#Herman Schultz"),
                new Role("242#16#256#13#Anne Marie Hoag"),
                new Role("243#16#4#14#Abe"),
                new Role("244#16#101#15#Coach Wilson"),
                new Role("245#16#137#16#Principal Morita"),
                new Role("246#16#225#17#Ms. Warren"),
                new Role("247#16#19#18#Betty"),
                new Role("248#17#46#1#Thor"),
                new Role("249#17#246#2#Loki"),
                new Role("250#17#41#3#Hela"),
                new Role("251#17#166#4#Bruce Banner"),
                new Role("252#17#107#5#Heimdall"),
                new Role("253#17#119#6#Grandmaster"),
                new Role("254#17#238#7#Valkyrie"),
                new Role("255#17#133#8#Skurge"),
                new Role("256#17#21#9#Odin"),
                new Role("257#17#29#10#Doctor Strange"),
                new Role("258#17#236#11#Korg"),
                new Role("259#17#199#12#Topaz"),
                new Role("260#17#52#13#Surtur"),
                new Role("261#17#235#14#Hogun"),
                new Role("262#17#204#15#Volstagg"),
                new Role("263#17#270#16#Fandral"),
                new Role("264#17#91#17#Asgardian Date #1"),
                new Role("265#17#12#18#Asgardian Date #2"),
                new Role("266#18#42#1#T'Challa"),
                new Role("267#18#174#2#Erik Killmonger"),
                new Role("268#18#160#3#Nakia"),
                new Role("269#18#59#4#Okoye"),
                new Role("270#18#168#5#Everett K. Ross"),
                new Role("271#18#61#6#W'Kabi"),
                new Role("272#18#151#7#Shuri"),
                new Role("273#18#265#8#M'Baku"),
                new Role("274#18#232#9#N'Jobu"),

            });
        }




    }
}
