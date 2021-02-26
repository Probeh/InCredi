using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Context;
using Shared.Models;

namespace WebAPI.Extensions {
  public static partial class Extensions {
    public static IApplicationBuilder ScaffoldProfile(this IApplicationBuilder builder) {
      var manager = builder
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<UserManager<User>>();
      var context = builder
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<ApplicationContext>();
      SetAccounts(manager);
      SetProfiles(context);
      return builder;
    }
    private static async void SetAccounts(UserManager<User> manager) {
      if (await manager.Users.AnyAsync())
        return;
      await manager.CreateAsync(new User { UserName = "admin" }, password: "password");
    }
    private static async void SetProfiles(ApplicationContext context) {
      if (!(await context.Profiles.AnyAsync())) {
        new List<Profile> {
          new Profile(831, "jeryL", 28, "jery", DateTime.Parse("2018-05-23 00:00:00.000"), "Suplier", "cash", 1450.00d),
          new Profile(281, "natanX", 28, "natan", DateTime.Parse("2019-09-21 00:00:00.000"), "Suplier", "other", 1470.00d),
          new Profile(282, "natanF", 28, "natan", DateTime.Parse("2019-10-16 00:00:00.000"), "Suplier", "other", -1520.00d),
          new Profile(283, "natanY", 28, "natan", DateTime.Parse("2019-11-10 00:00:00.000"), "Suplier", "cash", 1570.00d),
          new Profile(284, "natanZ", 28, "natan", DateTime.Parse("2019-12-05 00:00:00.000"), "Costumer", "other", 2500.00d),
          new Profile(282, "natanF", 28, "natan", DateTime.Parse("2019-12-30 00:00:00.000"), "Suplier", "other", -2810.00d),
          new Profile(282, "natanF", 28, "natan", DateTime.Parse("2020-01-04 00:00:00.000"), "Suplier", "other", -3240.00d),
          new Profile(282, "natanF", 28, "natan", DateTime.Parse("2020-01-14 00:00:00.000"), "Suplier", "cash", 2810.00d),
          new Profile(283, "natanY", 28, "natan", DateTime.Parse("2020-01-19 00:00:00.000"), "Suplier", "cash", 220.00d),
          new Profile(283, "natanY", 28, "natan", DateTime.Parse("2020-01-24 00:00:00.000"), "Suplier", "other", -80.00d),
          new Profile(284, "natanZ", 28, "natan", DateTime.Parse("2020-01-24 00:00:00.000"), "Costumer", "other", 560.00d),
          new Profile(282, "natanF", 28, "natan", DateTime.Parse("2020-01-29 00:00:00.000"), "Suplier", "other", 2380.00d),
          new Profile(283, "natanY", 28, "natan", DateTime.Parse("2020-01-29 00:00:00.000"), "Suplier", "other", -320.00d),
          new Profile(282, "natanF", 28, "natan", DateTime.Parse("2020-02-03 00:00:00.000"), "Suplier", "cash", 820.00d),
          new Profile(282, "natanF", 28, "natan", DateTime.Parse("2020-02-08 00:00:00.000"), "Suplier", "cash", 520.00d),
          new Profile(282, "natanF", 28, "natan", DateTime.Parse("2020-02-23 00:00:00.000"), "Suplier", "cash", 1950.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-08-22 00:00:00.000"), "Costumer", "other", 400.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-08-27 00:00:00.000"), "Costumer", "cash", -152.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-09-16 00:00:00.000"), "Costumer", "other", 500.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-09-21 00:00:00.000"), "Costumer", "other", 600.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-09-26 00:00:00.000"), "Costumer", "other", 700.00d),
          new Profile(342, "karinG", 34, "karin", DateTime.Parse("2019-10-01 00:00:00.000"), "Costumer", "other", 870.00d),
          new Profile(343, "karinS", 34, "karin", DateTime.Parse("2019-10-11 00:00:00.000"), "Costumer", "other", 1000.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-10-16 00:00:00.000"), "Costumer", "cash", -152.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-10-21 00:00:00.000"), "Costumer", "cash", -157.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-11-10 00:00:00.000"), "Costumer", "other", 1800.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2019-11-15 00:00:00.000"), "Costumer", "other", 2000.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2020-01-09 00:00:00.000"), "Costumer", "cash", -320.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2020-01-29 00:00:00.000"), "Costumer", "other", 2500.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2020-02-18 00:00:00.000"), "Costumer", "cash", -160.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2020-05-08 00:00:00.000"), "Costumer", "cash", -400.00d),
          new Profile(341, "karinD", 34, "karin", DateTime.Parse("2020-07-27 00:00:00.000"), "Costumer", "other", 3400.00d),
          new Profile(503, "jamesK", 50, "james", DateTime.Parse("2020-08-11 00:00:00.000"), "Suplier", "other", -840.00d),
          new Profile(503, "jamesK", 50, "james", DateTime.Parse("2020-08-21 00:00:00.000"), "Suplier", "other", -1340.00d),
          new Profile(503, "jamesK", 50, "james", DateTime.Parse("2020-10-30 00:00:00.000"), "Suplier", "other", -940.00d),
          new Profile(503, "jamesK", 50, "james", DateTime.Parse("2021-01-08 00:00:00.000"), "Suplier", "other", -1290.00d),
          new Profile(503, "jamesK", 50, "james", DateTime.Parse("2021-03-19 00:00:00.000"), "Suplier", "other", -1050.00d),
          new Profile(501, "jamesS", 50, "james", DateTime.Parse("2021-03-29 00:00:00.000"), "Costumer", "cash", 2000.00d),
          new Profile(502, "jamesJ", 50, "james", DateTime.Parse("2021-06-07 00:00:00.000"), "Suplier", "cash", 1240.00d),
          new Profile(503, "jamesK", 50, "james", DateTime.Parse("2021-08-16 00:00:00.000"), "Suplier", "cash", 1580.00d),
          new Profile(621, "dotanS", 62, "dotan", DateTime.Parse("2021-10-25 00:00:00.000"), "Suplier", "other", -1500.00d),
          new Profile(621, "dotanS", 62, "dotan", DateTime.Parse("2022-01-03 00:00:00.000"), "Suplier", "other", -1940.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2022-01-08 00:00:00.000"), "Suplier", "other", -2500.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2022-01-13 00:00:00.000"), "Suplier", "cash", 3500.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2022-01-18 00:00:00.000"), "Suplier", "other", -2500.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2022-01-23 00:00:00.000"), "Suplier", "cash", 2160.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2022-04-03 00:00:00.000"), "Suplier", "cash", 1820.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2022-06-12 00:00:00.000"), "Suplier", "other", -1480.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2022-08-21 00:00:00.000"), "Suplier", "cash", 1140.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2022-10-30 00:00:00.000"), "Suplier", "other", -800.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2023-01-08 00:00:00.000"), "Suplier", "other", -460.00d),
          new Profile(691, "felixH", 69, "felix", DateTime.Parse("2023-01-18 00:00:00.000"), "Suplier", "cash", -2140.00d),
          new Profile(761, "rachelQ", 76, "rachel", DateTime.Parse("2023-03-29 00:00:00.000"), "Costumer", "other", 1400.00d),
          new Profile(831, "jeryL", 83, "jery", DateTime.Parse("2019-10-05 00:00:00.000"), "Suplier", "other", -1420.00d),
          new Profile(831, "jeryL", 83, "jery", DateTime.Parse("2019-10-05 00:00:00.000"), "Suplier", "other", -1120.00d),
          new Profile(762, "rachelU", 83, "rachel", DateTime.Parse("2019-12-14 00:00:00.000"), "Costumer", "cash", 4000.00d),
          new Profile(831, "jeryL", 83, "jery", DateTime.Parse("2020-02-22 00:00:00.000"), "Suplier", "cash", 1170.00d),
          new Profile(831, "jeryL", 83, "jery", DateTime.Parse("2020-05-02 00:00:00.000"), "Suplier", "other", -830.00d),
          new Profile(831, "jeryL", 83, "jery", DateTime.Parse("2020-07-11 00:00:00.000"), "Suplier", "cash", 490.00d),
          new Profile(831, "jeryL", 83, "jery", DateTime.Parse("2020-08-25 00:00:00.000"), "Suplier", "cash", -530.00d),
          new Profile(831, "jeryL", 83, "jery", DateTime.Parse("2020-09-19 00:00:00.000"), "Suplier", "cash", 150.00d),
          new Profile(831, "jeryL", 83, "jery", DateTime.Parse("2020-11-03 00:00:00.000"), "Suplier", "other", -190.00d),
          new Profile(901, "davidE", 90, "david", DateTime.Parse("2020-11-23 00:00:00.000"), "Costumer", "other", 820.00d),
          new Profile(763, "rachelK", 90, "rachel", DateTime.Parse("2021-02-01 00:00:00.000"), "Costumer", "other", 1200.00d),
          new Profile(902, "davidW", 97, "david", DateTime.Parse("2021-04-12 00:00:00.000"), "Costumer", "other", 1000.00d),
          new Profile(971, "mayaY", 97, "maya", DateTime.Parse("2021-06-21 00:00:00.000"), "Costumer", "cash", -200.00d),
          new Profile(902, "davidW", 97, "david", DateTime.Parse("2021-07-31 00:00:00.000"), "Costumer", "other", 520.00d),
          new Profile(902, "davidW", 97, "david", DateTime.Parse("2021-08-20 00:00:00.000"), "Costumer", "other", 820.00d),
          new Profile(902, "davidW", 97, "david", DateTime.Parse("2021-08-25 00:00:00.000"), "Costumer", "other", 4500.00d),
          new Profile(902, "davidW", 97, "david", DateTime.Parse("2021-08-30 00:00:00.000"), "Costumer", "other", 5800.00d),
          new Profile(902, "davidW", 97, "david", DateTime.Parse("2021-09-04 00:00:00.000"), "Costumer", "other", 7000.00d),
          new Profile(973, "mayaO", 104, "maya", DateTime.Parse("2019-08-26 00:00:00.000"), "Suplier", "other", -870.00d),
          new Profile(1041, "veliH", 104, "veli", DateTime.Parse("2019-09-20 00:00:00.000"), "Suplier", "cash", 1210.00d),
          new Profile(972, "mayaU", 104, "maya", DateTime.Parse("2019-10-15 00:00:00.000"), "Suplier", "cash", 400.00d),
          new Profile(973, "mayaO", 104, "maya", DateTime.Parse("2020-08-10 00:00:00.000"), "Suplier", "other", 160.00d),
          new Profile(1041, "veliH", 104, "veli", DateTime.Parse("2021-06-06 00:00:00.000"), "Suplier", "cash", -80.00d),
          new Profile(972, "mayaU", 104, "maya", DateTime.Parse("2021-11-13 00:00:00.000"), "Suplier", "other", -2240.00d),
          new Profile(973, "mayaO", 104, "maya", DateTime.Parse("2022-01-22 00:00:00.000"), "Suplier", "cash", 1240.00d),
          new Profile(1041, "veliH", 104, "veli", DateTime.Parse("2022-04-02 00:00:00.000"), "Suplier", "other", -2240.00d),
          new Profile(1042, "veliX", 111, "veli", DateTime.Parse("2017-07-27 00:00:00.000"), "Costumer", "other", 1300.00d),
          new Profile(1042, "veliX", 111, "veli", DateTime.Parse("2017-08-21 00:00:00.000"), "Costumer", "other", 1100.00d),
          new Profile(1042, "veliX", 111, "veli", DateTime.Parse("2017-09-15 00:00:00.000"), "Costumer", "other", 3000.00d),
          new Profile(1042, "veliX", 111, "veli", DateTime.Parse("2017-10-10 00:00:00.000"), "Costumer", "other", 4000.00d),
          new Profile(1042, "veliX", 111, "veli", DateTime.Parse("2017-11-04 00:00:00.000"), "Costumer", "other", 320.00d),
          new Profile(1111, "tamarK", 111, "tamar", DateTime.Parse("2017-11-14 00:00:00.000"), "Suplier", "cash", -560.00d),
          new Profile(1111, "tamarK", 111, "tamar", DateTime.Parse("2018-09-10 00:00:00.000"), "Suplier", "cash", -800.00d),
          new Profile(1111, "tamarK", 111, "tamar", DateTime.Parse("2019-07-07 00:00:00.000"), "Suplier", "other", -1040.00d),
          new Profile(1181, "idoR", 118, "ido", DateTime.Parse("2016-09-30 00:00:00.000"), "Suplier", "cash", 1280.00d),
          new Profile(1182, "idoO", 125, "ido", DateTime.Parse("2016-08-31 00:00:00.000"), "Suplier", "other", -1520.00d),
          new Profile(1251, "lotemL", 125, "lotem", DateTime.Parse("2016-09-20 00:00:00.000"), "Costumer", "cash", -176.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2015-09-26 00:00:00.000"), "Costumer", "other", -2000.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2015-12-05 00:00:00.000"), "Costumer", "other", 1280.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2016-02-13 00:00:00.000"), "Costumer", "cash", -152.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2016-04-23 00:00:00.000"), "Costumer", "other", 760.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2016-07-02 00:00:00.000"), "Costumer", "cash", -2000.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2016-07-22 00:00:00.000"), "Costumer", "cash", -176.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2016-08-21 00:00:00.000"), "Costumer", "cash", -15.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2016-09-10 00:00:00.000"), "Costumer", "cash", -224.00d),
          new Profile(1252, "lotemP", 132, "lotem", DateTime.Parse("2016-11-19 00:00:00.000"), "Costumer", "cash", 2000.00d)
        }.ForEach(async x => await context.AddAsync(x));
        await context.SaveChangesAsync();
      }
      return;
    }
  }
}