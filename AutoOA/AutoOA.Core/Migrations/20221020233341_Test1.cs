using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoOA.Core.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    BodyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.BodyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DriveTypes",
                columns: table => new
                {
                    DriveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTypes", x => x.DriveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    FuelTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.FuelTypeId);
                });

            migrationBuilder.CreateTable(
                name: "GearBoxes",
                columns: table => new
                {
                    GearBoxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GearBoxName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBoxes", x => x.GearBoxId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    VehicleBrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleBrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.VehicleBrandId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.VehicleModelId);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "VehicleBrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GearBoxId = table.Column<int>(type: "int", nullable: false),
                    DriveTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    MileageIconPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    VehicleIconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "BodyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_DriveTypes_DriveTypeId",
                        column: x => x.DriveTypeId,
                        principalTable: "DriveTypes",
                        principalColumn: "DriveTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "FuelTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_GearBoxes_GearBoxId",
                        column: x => x.GearBoxId,
                        principalTable: "GearBoxes",
                        principalColumn: "GearBoxId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d8ac350-0590-4973-b3da-eb0daab1b6ca", "4e421d61-094a-49ba-a880-976648fcdf93", "Admin", "ADMIN" },
                    { "737d13d4-54b3-47d9-bcc2-f2fc1df0c9d7", "15522d6d-2e7e-4938-a3f0-1ac355a5c94d", "Moderator", "MODERATOR" },
                    { "fdb16792-5366-4650-8af9-acc9b615f3d6", "0538504f-54b7-4301-8c11-c5913a31f342", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "54440f44-252c-4531-8d56-a2a1e6d6e50a", 0, "f1d4da5f-227a-4719-ab22-83fbdc3fb2cf", "user@autooa.com", true, null, null, false, null, "USER@AUTOOA.COM", "USER@AUTOOA.COM", "AQAAAAEAACcQAAAAEOCUN3pApsyORIt023hguk1uzcorLkdcKKPylu2EXe5UBHAUOSwEfI5FTPQi/AOwfA==", null, false, "7847fb4c-1a25-4113-ad47-8b122d1dec38", false, "user@autooa.com" },
                    { "8974e59e-38e3-4d85-82e0-33cbb5217a3d", 0, "b7ca9d83-7aa7-4d68-a4d9-f1e99854996b", "admin@autooa.com", true, null, null, false, null, "ADMIN@AUTOOA.COM", "ADMIN@AUTOOA.COM", "AQAAAAEAACcQAAAAEF6vQ/l3Mg6QYf6iMJ572bkbuhDvSBJqALkabKwZ0ntvdJDSpRTM2Aw3rgMFT5w/yw==", null, false, "9dba61af-6ed5-4a6c-9177-47d1d273121a", false, "admin@autooa.com" },
                    { "c4676a5f-b7c6-420e-aa0d-f1a77426157a", 0, "50145372-1329-401c-a601-d0be4615f5d1", "moder@autooa.com", true, null, null, false, null, "MODER@AUTOOA.COM", "MODER@AUTOOA.COM", "AQAAAAEAACcQAAAAEAWNk8l6GYN4EXlXapsRmOMQXmeaeP6vwNOX34RwodQo1XntOpWYXqfTnARj/iKcOw==", null, false, "0852bc1c-ad57-44ed-b1b8-b749a2e30671", false, "moder@autooa.com" }
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "BodyTypeId", "BodyTypeName", "IconPath" },
                values: new object[,]
                {
                    { 1, "Седан", "Images\\BodyTypeIcon.png" },
                    { 2, "Універсал", "Images\\BodyTypeIcon.png" },
                    { 3, "Хетчбек", "Images\\BodyTypeIcon.png" },
                    { 4, "Купе", "Images\\BodyTypeIcon.png" },
                    { 5, "Кабріолет", "Images\\BodyTypeIcon.png" },
                    { 6, "Позашляховик / Кросовер", "Images\\BodyTypeIcon.png" },
                    { 7, "Мінівен", "Images\\BodyTypeIcon.png" },
                    { 8, "Ліфтбек", "Images\\BodyTypeIcon.png" },
                    { 9, "Мікровен", "Images\\BodyTypeIcon.png" },
                    { 10, "Пікап", "Images\\BodyTypeIcon.png" },
                    { 11, "Родстер", "Images\\BodyTypeIcon.png" },
                    { 12, "Лімузин", "Images\\BodyTypeIcon.png" },
                    { 13, "Фастбек", "Images\\BodyTypeIcon.png" }
                });

            migrationBuilder.InsertData(
                table: "DriveTypes",
                columns: new[] { "DriveTypeId", "DriveTypeName" },
                values: new object[,]
                {
                    { 1, "Повний" },
                    { 2, "Передній" },
                    { 3, "Задній" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "FuelTypeId", "FuelName", "IconPath" },
                values: new object[,]
                {
                    { 1, "Дизель", "Images\\fuelTypeIcon.png" },
                    { 2, "Бензин", "Images\\fuelTypeIcon.png" },
                    { 3, "Газ", "Images\\fuelTypeIcon.png" },
                    { 4, "Газ / Бензин", "Images\\fuelTypeIcon.png" },
                    { 5, "Гібрид", "Images\\fuelTypeIcon.png" },
                    { 6, "Електро", "Images\\fuelTypeIcon.png" },
                    { 7, "Інше", "Images\\fuelTypeIcon.png" },
                    { 8, "Газ метан", "Images\\fuelTypeIcon.png" },
                    { 9, "Газ пропан-бутан", "Images\\fuelTypeIcon.png" }
                });

            migrationBuilder.InsertData(
                table: "GearBoxes",
                columns: new[] { "GearBoxId", "GearBoxName", "IconPath" },
                values: new object[,]
                {
                    { 1, "Ручна / Механіка", "Images\\gearBoxIcon.png" },
                    { 2, "Автомат", "Images\\gearBoxIcon.png" },
                    { 3, "Типтронік", "Images\\gearBoxIcon.png" },
                    { 4, "Робот", "Images\\gearBoxIcon.png" },
                    { 5, "Варіатор", "Images\\gearBoxIcon.png" }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "VehicleBrandId", "VehicleBrandName" },
                values: new object[,]
                {
                    { 1, "Mercedes" },
                    { 2, "BMW" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fdb16792-5366-4650-8af9-acc9b615f3d6", "54440f44-252c-4531-8d56-a2a1e6d6e50a" },
                    { "1d8ac350-0590-4973-b3da-eb0daab1b6ca", "8974e59e-38e3-4d85-82e0-33cbb5217a3d" },
                    { "737d13d4-54b3-47d9-bcc2-f2fc1df0c9d7", "8974e59e-38e3-4d85-82e0-33cbb5217a3d" },
                    { "fdb16792-5366-4650-8af9-acc9b615f3d6", "8974e59e-38e3-4d85-82e0-33cbb5217a3d" },
                    { "737d13d4-54b3-47d9-bcc2-f2fc1df0c9d7", "c4676a5f-b7c6-420e-aa0d-f1a77426157a" },
                    { "fdb16792-5366-4650-8af9-acc9b615f3d6", "c4676a5f-b7c6-420e-aa0d-f1a77426157a" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "VehicleModelId", "VehicleBrandId", "VehicleModelName" },
                values: new object[,]
                {
                    { 1, 1, "E 220" },
                    { 2, 2, "320" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "BodyTypeId", "Color", "Description", "DriveTypeId", "FuelTypeId", "GearBoxId", "Mileage", "MileageIconPath", "Price", "ProductionDate", "VehicleIconPath", "VehicleModelId", "isNew" },
                values: new object[] { 1, 1, "Black", "Авто в дуже хорошому стані. Повністтю обслужене. Капіталовкладень не потребує.", 1, 1, 1, 90000, "Images\\MileageIcon.png", 15000m, new DateTime(2006, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "\\Images\\w220cidan.png", 1, true });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "BodyTypeId", "Color", "Description", "DriveTypeId", "FuelTypeId", "GearBoxId", "Mileage", "MileageIconPath", "Price", "ProductionDate", "VehicleIconPath", "VehicleModelId", "isNew" },
                values: new object[] { 2, 2, "Gray", "Продаю свій автомобіль у хорошому стані. Зроблено всі планові роботи, все працює добре. Є невеликі подряпини, пов'язані з експлуатацією.", 3, 2, 2, 320000, "Images\\MileageIcon.png", 9000m, new DateTime(2000, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "\\Images\\320Universal.png", 2, false });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleBrandId",
                table: "VehicleModels",
                column: "VehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BodyTypeId",
                table: "Vehicles",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriveTypeId",
                table: "Vehicles",
                column: "DriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FuelTypeId",
                table: "Vehicles",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_GearBoxId",
                table: "Vehicles",
                column: "GearBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "DriveTypes");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "GearBoxes");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleBrands");
        }
    }
}
