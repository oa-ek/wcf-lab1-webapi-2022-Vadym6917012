using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Core
{
    public static class AutoOADbContextExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string MODER_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = MODER_ROLE_ID,
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER"
                });

            string ADMIN_ID = Guid.NewGuid().ToString();
            string MODER_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@autooa.com",
                Email = "admin@autooa.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@autooa.com".ToUpper(),
                NormalizedUserName = "admin@autooa.com".ToUpper()
            };

            var moder = new User
            {
                Id = MODER_ID,
                UserName = "moder@autooa.com",
                Email = "moder@autooa.com",
                EmailConfirmed = true,
                NormalizedEmail = "moder@autooa.com".ToUpper(),
                NormalizedUserName = "moder@autooa.com".ToUpper()
            };

            var user = new User
            {
                Id = USER_ID,
                UserName = "user@autooa.com",
                Email = "user@autooa.com",
                EmailConfirmed = true,
                NormalizedEmail = "user@autooa.com".ToUpper(),
                NormalizedUserName = "user@autooa.com".ToUpper()
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin$pass1");
            moder.PasswordHash = hasher.HashPassword(moder, "Moder$pass1");
            user.PasswordHash = hasher.HashPassword(user, "User$pass1");

            builder.Entity<User>().HasData(admin, moder, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODER_ROLE_ID,
                    UserId = MODER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = MODER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });

            builder.Entity<FuelType>().HasData(
                new FuelType
                {
                    FuelTypeId = 1,
                    FuelName = "Дизель",
                    VehicleId = 1
                },
                new FuelType
                {
                    FuelTypeId = 2,
                    FuelName = "Бензин",
                    VehicleId = 2
                });
            builder.Entity<BodyType>().HasData(
                new BodyType
                {
                    BodyTypeId = 1,
                    BodyTypeName = "Седан",
                    VehicleId = 1
                },
                new BodyType
                {
                    BodyTypeId = 2,
                    BodyTypeName = "Універсал",
                    VehicleId = 2
                });
            builder.Entity<GearBox>().HasData(
                new GearBox
                {
                    GearBoxId = 1,
                    GearBoxName = "Механіка",
                    VehicleId = 1
                },
                new GearBox
                {
                    GearBoxId = 2,
                    GearBoxName = "Автомат",
                    VehicleId = 2
                });
            builder.Entity<VehicleBrand>().HasData(
                new VehicleBrand
                {
                    VehicleBrandId = 1,
                    VehicleBrandName = "Mercedes",
                },
                new VehicleBrand
                {
                    VehicleBrandId = 2,
                    VehicleBrandName = "BMW",
                });
            builder.Entity<VehicleModel>().HasData(
                new VehicleModel
                {
                    VehicleModelId = 1,
                    VehicleModelName = "E 220",
                    ProductionDate = DateTime.Now,
                    VehicleBrandId = 1,
                },
                new VehicleModel
                {
                    VehicleModelId = 2,
                    VehicleModelName = "320",
                    ProductionDate = DateTime.Now,
                    VehicleBrandId = 2,
                });
            builder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    VehicleId = 1,
                    BodyTypeId = 1,
                    VehicleModelId = 1,
                    GearBoxId = 1,
                    Price = 15000,
                    isNew = true,
                    Mileage = 90000,
                    IconPath = @"Images\w220cidan - Copy.png",
                    FuelTypeId = 1,
                    Color = "Black"
                },
                new Vehicle
                {
                    VehicleId = 2,
                    BodyTypeId = 2,
                    VehicleModelId = 2,
                    GearBoxId = 2,
                    Price = 9000,
                    isNew = false,
                    Mileage = 320000,
                    IconPath = @"Images\320Universal.png",
                    FuelTypeId = 2,
                    Color = "Gray"
                });
        }
    }
}
