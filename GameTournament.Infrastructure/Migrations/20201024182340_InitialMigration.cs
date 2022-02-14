using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameTournament.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ParentCategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_ParentCategory",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Path = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(maxLength: 128, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Size = table.Column<long>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ProfileDocumentId = table.Column<int>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    UserIntroducedId = table.Column<int>(nullable: true),
                    Identifier = table.Column<string>(maxLength: 128, nullable: false),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    LatinFirstName = table.Column<string>(maxLength: 128, nullable: true),
                    LatinLastName = table.Column<string>(maxLength: 128, nullable: true),
                    NickName = table.Column<string>(maxLength: 128, nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Telephone = table.Column<string>(maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    Address = table.Column<string>(nullable: true),
                    ActivitiesIds = table.Column<string>(nullable: true),
                    ActivitiesStartYear = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RawInfo = table.Column<string>(nullable: true),
                    AccountState = table.Column<int>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_ImageDocument",
                        column: x => x.ProfileDocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Province",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserIntroduced",
                        column: x => x.UserIntroducedId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<int>(nullable: false),
                    Cost = table.Column<long>(nullable: false),
                    Discount = table.Column<long>(nullable: false),
                    TrackingToken = table.Column<string>(maxLength: 128, nullable: true),
                    IsSuccessful = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<int>(nullable: false),
                    CoverDocumentId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Abstract = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_CoverDocument",
                        column: x => x.CoverDocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTokenGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 128, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.UserTokenId);
                    table.ForeignKey(
                        name: "FK_UserToken_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    PostCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCategoryGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PostId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => x.PostCategoryId);
                    table.ForeignKey(
                        name: "FK_PostCategory_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategory_Post",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "ActivityId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, "Pes" },
                    { 2, null, "Fifa" },
                    { 3, null, "Counter Strike" },
                    { 4, null, "Call Of Duty" },
                    { 5, null, "Dota 2" },
                    { 6, null, "Rainbow Six" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "ModifiedDate", "ParentCategoryId", "Title" },
                values: new object[] { 1, null, null, "وبلاگ" });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceId", "Name", "ProvinceGuid" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("f210d98d-2590-4084-96c8-fbfbec74059c") },
                    { 20, "ايلام", new Guid("935e3dde-5bf8-493e-8ac1-003f9831bfa9") },
                    { 21, "تهران", new Guid("483d5ab7-8b74-4171-8b04-1ac679948e91") },
                    { 22, "آذربايجان شرقي", new Guid("d274f9e8-e71a-4b8c-832d-b433d54c7013") },
                    { 23, "فارس", new Guid("bf78b6bb-6242-43db-a2c4-2e5fe2e41586") },
                    { 24, "کرمانشاه", new Guid("764634fc-03d7-4c4e-9fa9-9baa260faf02") },
                    { 28, "همدان", new Guid("9238a7d4-48e9-411d-bf6b-bd5a274a25c6") },
                    { 26, "مرکزي", new Guid("3b030e1a-4f81-41cb-8e1f-76b77dc7dd5f") },
                    { 27, "گيلان", new Guid("3bbdae0a-aea0-4b46-a67d-3db95536af18") },
                    { 18, "اردبيل", new Guid("0bd70aed-03c0-4c49-80f0-e7e65d5a790b") },
                    { 29, "کرمان", new Guid("ea3deed6-76c2-4601-ae8f-3613e2e50420") },
                    { 30, "سمنان", new Guid("dda847fd-8ea0-4883-ba87-84c281edb60e") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("dc8fee19-7b28-4ca1-a97b-58533bd7da78") },
                    { 25, "هرمزگان", new Guid("e51e57c6-c908-4434-bb1f-d0ea0fdbbff1") },
                    { 17, "لرستان", new Guid("994357a1-aac4-4cd8-a527-a60df8028bde") },
                    { 13, "زنجان", new Guid("8ecc5a52-10f2-42fb-8911-df472f25b428") },
                    { 15, "مازندران", new Guid("05c6e72e-cc2b-48f9-a253-ad8fdd045d4e") },
                    { 1, "يزد", new Guid("bb2e6e93-d619-447e-8853-03d25854df98") },
                    { 2, "چهار محال و بختياري", new Guid("e81f56d8-773b-4f34-b8d6-386ef8dc32e7") },
                    { 3, "خراسان شمالي", new Guid("c1a30d7d-3e43-48cc-861a-377bc3bc6ba9") },
                    { 4, "البرز", new Guid("05781c60-c4bd-426a-a50b-f00e62eb28e1") },
                    { 5, "قم", new Guid("c26ecfd5-df04-474e-89a1-b284ef479679") },
                    { 6, "کردستان", new Guid("8f22cd96-081d-4885-bf55-257d5d276dd5") },
                    { 16, "قزوين", new Guid("057f789e-6445-48be-9368-e307d676de34") },
                    { 7, "آذربايجان غربي", new Guid("d0ebd30a-9bac-4496-95ba-db526bdcd1f3") },
                    { 9, "سيستان و بلوچستان", new Guid("74700a5f-f70c-422f-a391-ef92846dba33") },
                    { 10, "خراسان جنوبي", new Guid("e51d01ab-0bfd-4f91-8fa3-d2c453aa5478") },
                    { 11, "خوزستان", new Guid("a2817df5-047a-4481-aba2-5a45d06feb42") },
                    { 12, "بوشهر", new Guid("818c4b2f-3aec-44b6-9e88-4c613fafb476") },
                    { 14, "گلستان", new Guid("0c1117f6-d79b-4048-9c48-499a6173e7bc") },
                    { 8, "خراسان رضوي", new Guid("a8267440-adc6-4f93-832a-b505c2bd928d") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "AccountState", "ActivitiesIds", "ActivitiesStartYear", "Address", "Birthday", "Description", "Email", "FirstName", "Gender", "Identifier", "IsAdmin", "LastName", "LatinFirstName", "LatinLastName", "ModifiedDate", "NickName", "PhoneNumber", "PhoneNumberConfirmed", "ProfileDocumentId", "ProvinceId", "RawInfo", "Telephone", "UserIntroducedId" },
                values: new object[,]
                {
                    { 1, 3, null, null, null, null, null, null, "سیدمهدی", null, "gamer-152482", true, "رودکی", null, null, null, null, "09126842446", true, null, null, null, null, null },
                    { 2, 3, null, null, null, null, null, null, "دکتر", null, "gamer-561318", true, "آخشته", null, null, null, null, "09192180663", true, null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserId",
                table: "Payment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CoverDocumentId",
                table: "Post",
                column: "CoverDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_CategoryId",
                table: "PostCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_PostId",
                table: "PostCategory",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileDocumentId",
                table: "User",
                column: "ProfileDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProvinceId",
                table: "User",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserIntroducedId",
                table: "User",
                column: "UserIntroducedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
