using Microsoft.EntityFrameworkCore;
using GameTournament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using GameTournament.Domain.Enums;

namespace GameTournament.Infrastructure.Persistence
{
    public static class GameContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
			#region Province

			modelBuilder.Entity<Province>().HasData(
				new Province
				{
					ProvinceId = 1,
					ProvinceGuid = Guid.NewGuid(),
					Name = "يزد"
				},
				new Province
				{
					ProvinceId = 2,
					ProvinceGuid = Guid.NewGuid(),
					Name = "چهار محال و بختياري"
				},
				new Province
				{
					ProvinceId = 3,
					ProvinceGuid = Guid.NewGuid(),
					Name = "خراسان شمالي"
				},
				new Province
				{
					ProvinceId = 4,
					ProvinceGuid = Guid.NewGuid(),
					Name = "البرز"
				},
				new Province
				{
					ProvinceId = 5,
					ProvinceGuid = Guid.NewGuid(),
					Name = "قم"
				},
				new Province
				{
					ProvinceId = 6,
					ProvinceGuid = Guid.NewGuid(),
					Name = "کردستان"
				},
				new Province
				{
					ProvinceId = 7,
					ProvinceGuid = Guid.NewGuid(),
					Name = "آذربايجان غربي"
				},
				new Province
				{
					ProvinceId = 8,
					ProvinceGuid = Guid.NewGuid(),
					Name = "خراسان رضوي"
				},
				new Province
				{
					ProvinceId = 9,
					ProvinceGuid = Guid.NewGuid(),
					Name = "سيستان و بلوچستان"
				},
				new Province
				{
					ProvinceId = 10,
					ProvinceGuid = Guid.NewGuid(),
					Name = "خراسان جنوبي"
				},
				new Province
				{
					ProvinceId = 11,
					ProvinceGuid = Guid.NewGuid(),
					Name = "خوزستان"
				},
				new Province
				{
					ProvinceId = 12,
					ProvinceGuid = Guid.NewGuid(),
					Name = "بوشهر"
				},
				new Province
				{
					ProvinceId = 13,
					ProvinceGuid = Guid.NewGuid(),
					Name = "زنجان"
				},
				new Province
				{
					ProvinceId = 14,
					ProvinceGuid = Guid.NewGuid(),
					Name = "گلستان"
				},
				new Province
				{
					ProvinceId = 15,
					ProvinceGuid = Guid.NewGuid(),
					Name = "مازندران"
				},
				new Province
				{
					ProvinceId = 16,
					ProvinceGuid = Guid.NewGuid(),
					Name = "قزوين"
				},
				new Province
				{
					ProvinceId = 17,
					ProvinceGuid = Guid.NewGuid(),
					Name = "لرستان"
				},
				new Province
				{
					ProvinceId = 18,
					ProvinceGuid = Guid.NewGuid(),
					Name = "اردبيل"
				},
				new Province
				{
					ProvinceId = 19,
					ProvinceGuid = Guid.NewGuid(),
					Name = "اصفهان"
				},
				new Province
				{
					ProvinceId = 20,
					ProvinceGuid = Guid.NewGuid(),
					Name = "ايلام"
				},
				new Province
				{
					ProvinceId = 21,
					ProvinceGuid = Guid.NewGuid(),
					Name = "تهران"
				},
				new Province
				{
					ProvinceId = 22,
					ProvinceGuid = Guid.NewGuid(),
					Name = "آذربايجان شرقي"
				},
				new Province
				{
					ProvinceId = 23,
					ProvinceGuid = Guid.NewGuid(),
					Name = "فارس"
				},
				new Province
				{
					ProvinceId = 24,
					ProvinceGuid = Guid.NewGuid(),
					Name = "کرمانشاه"
				},
				new Province
				{
					ProvinceId = 25,
					ProvinceGuid = Guid.NewGuid(),
					Name = "هرمزگان"
				},
				new Province
				{
					ProvinceId = 26,
					ProvinceGuid = Guid.NewGuid(),
					Name = "مرکزي"
				},
				new Province
				{
					ProvinceId = 27,
					ProvinceGuid = Guid.NewGuid(),
					Name = "گيلان"
				},
				new Province
				{
					ProvinceId = 28,
					ProvinceGuid = Guid.NewGuid(),
					Name = "همدان"
				},
				new Province
				{
					ProvinceId = 29,
					ProvinceGuid = Guid.NewGuid(),
					Name = "کرمان"
				},
				new Province
				{
					ProvinceId = 30,
					ProvinceGuid = Guid.NewGuid(),
					Name = "سمنان"
				},
				new Province
				{
					ProvinceId = 31,
					ProvinceGuid = Guid.NewGuid(),
					Name = "کهگيلويه و بويراحمد"
				}
			);

            #endregion

            #region User

            modelBuilder.Entity<User>().HasData(
				new User
				{
					UserId = 1,
					Identifier = "gamer-152482",
					FirstName = "سیدمهدی",
					LastName = "رودکی",
					PhoneNumber = "09126842446",
					PhoneNumberConfirmed = true,
					AccountState = AccountState.Confirmed,
					IsAdmin = true
				},
				new User
				{
					UserId = 2,
					Identifier = "gamer-561318",
					FirstName = "دکتر",
					LastName = "آخشته",
					PhoneNumber = "09192180663",
					PhoneNumberConfirmed = true,
					AccountState = AccountState.Confirmed,
					IsAdmin = true
				}
			);

            #endregion

            #region Category

            modelBuilder.Entity<Category>().HasData(
				new Category
				{
					CategoryId = 1,
					ParentCategoryId = null,
					Title = "وبلاگ"
				}
			);

			#endregion

			#region Activity

			modelBuilder.Entity<Activity>().HasData(
				new Activity
				{
					ActivityId = 1,
					Name = "Pes"
				},
				new Activity
				{
					ActivityId = 2,
					Name = "Fifa"
				},
				new Activity
				{
					ActivityId = 3,
					Name = "Counter Strike"
				},
				new Activity
				{
					ActivityId = 4,
					Name = "Call Of Duty"
				},
				new Activity
				{
					ActivityId = 5,
					Name = "Dota 2"
				},
				new Activity
				{
					ActivityId = 6,
					Name = "Rainbow Six"
				}
			);

			#endregion
		}
	}
}