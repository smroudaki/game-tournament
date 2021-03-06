// <auto-generated />
using System;
using GameTournament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameTournament.Infrastructure.Migrations
{
    [DbContext(typeof(GameTournamentTournamentContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameTournament.Domain.Entities.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ActivityGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("ActivityId");

                    b.ToTable("Activity");

                    b.HasData(
                        new
                        {
                            ActivityId = 1,
                            ActivityGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Name = "Pes"
                        },
                        new
                        {
                            ActivityId = 2,
                            ActivityGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Name = "Fifa"
                        },
                        new
                        {
                            ActivityId = 3,
                            ActivityGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Name = "Counter Strike"
                        },
                        new
                        {
                            ActivityId = 4,
                            ActivityGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Name = "Call Of Duty"
                        },
                        new
                        {
                            ActivityId = 5,
                            ActivityGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Name = "Dota 2"
                        },
                        new
                        {
                            ActivityId = 6,
                            ActivityGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Name = "Rainbow Six"
                        });
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CategoryGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Title = "وبلاگ"
                        });
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("DocumentGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("DocumentId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<long>("Discount")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsSuccessful")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<Guid>("PaymentGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("TrackingToken")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoverDocumentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<bool>("IsShow")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PostGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("CoverDocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.PostCategory", b =>
                {
                    b.Property<int>("PostCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("PostCategoryGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("PostCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId");

                    b.ToTable("PostCategory");
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.Province", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("ProvinceGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("ProvinceId");

                    b.ToTable("Province");

                    b.HasData(
                        new
                        {
                            ProvinceId = 1,
                            Name = "يزد",
                            ProvinceGuid = new Guid("bb2e6e93-d619-447e-8853-03d25854df98")
                        },
                        new
                        {
                            ProvinceId = 2,
                            Name = "چهار محال و بختياري",
                            ProvinceGuid = new Guid("e81f56d8-773b-4f34-b8d6-386ef8dc32e7")
                        },
                        new
                        {
                            ProvinceId = 3,
                            Name = "خراسان شمالي",
                            ProvinceGuid = new Guid("c1a30d7d-3e43-48cc-861a-377bc3bc6ba9")
                        },
                        new
                        {
                            ProvinceId = 4,
                            Name = "البرز",
                            ProvinceGuid = new Guid("05781c60-c4bd-426a-a50b-f00e62eb28e1")
                        },
                        new
                        {
                            ProvinceId = 5,
                            Name = "قم",
                            ProvinceGuid = new Guid("c26ecfd5-df04-474e-89a1-b284ef479679")
                        },
                        new
                        {
                            ProvinceId = 6,
                            Name = "کردستان",
                            ProvinceGuid = new Guid("8f22cd96-081d-4885-bf55-257d5d276dd5")
                        },
                        new
                        {
                            ProvinceId = 7,
                            Name = "آذربايجان غربي",
                            ProvinceGuid = new Guid("d0ebd30a-9bac-4496-95ba-db526bdcd1f3")
                        },
                        new
                        {
                            ProvinceId = 8,
                            Name = "خراسان رضوي",
                            ProvinceGuid = new Guid("a8267440-adc6-4f93-832a-b505c2bd928d")
                        },
                        new
                        {
                            ProvinceId = 9,
                            Name = "سيستان و بلوچستان",
                            ProvinceGuid = new Guid("74700a5f-f70c-422f-a391-ef92846dba33")
                        },
                        new
                        {
                            ProvinceId = 10,
                            Name = "خراسان جنوبي",
                            ProvinceGuid = new Guid("e51d01ab-0bfd-4f91-8fa3-d2c453aa5478")
                        },
                        new
                        {
                            ProvinceId = 11,
                            Name = "خوزستان",
                            ProvinceGuid = new Guid("a2817df5-047a-4481-aba2-5a45d06feb42")
                        },
                        new
                        {
                            ProvinceId = 12,
                            Name = "بوشهر",
                            ProvinceGuid = new Guid("818c4b2f-3aec-44b6-9e88-4c613fafb476")
                        },
                        new
                        {
                            ProvinceId = 13,
                            Name = "زنجان",
                            ProvinceGuid = new Guid("8ecc5a52-10f2-42fb-8911-df472f25b428")
                        },
                        new
                        {
                            ProvinceId = 14,
                            Name = "گلستان",
                            ProvinceGuid = new Guid("0c1117f6-d79b-4048-9c48-499a6173e7bc")
                        },
                        new
                        {
                            ProvinceId = 15,
                            Name = "مازندران",
                            ProvinceGuid = new Guid("05c6e72e-cc2b-48f9-a253-ad8fdd045d4e")
                        },
                        new
                        {
                            ProvinceId = 16,
                            Name = "قزوين",
                            ProvinceGuid = new Guid("057f789e-6445-48be-9368-e307d676de34")
                        },
                        new
                        {
                            ProvinceId = 17,
                            Name = "لرستان",
                            ProvinceGuid = new Guid("994357a1-aac4-4cd8-a527-a60df8028bde")
                        },
                        new
                        {
                            ProvinceId = 18,
                            Name = "اردبيل",
                            ProvinceGuid = new Guid("0bd70aed-03c0-4c49-80f0-e7e65d5a790b")
                        },
                        new
                        {
                            ProvinceId = 19,
                            Name = "اصفهان",
                            ProvinceGuid = new Guid("f210d98d-2590-4084-96c8-fbfbec74059c")
                        },
                        new
                        {
                            ProvinceId = 20,
                            Name = "ايلام",
                            ProvinceGuid = new Guid("935e3dde-5bf8-493e-8ac1-003f9831bfa9")
                        },
                        new
                        {
                            ProvinceId = 21,
                            Name = "تهران",
                            ProvinceGuid = new Guid("483d5ab7-8b74-4171-8b04-1ac679948e91")
                        },
                        new
                        {
                            ProvinceId = 22,
                            Name = "آذربايجان شرقي",
                            ProvinceGuid = new Guid("d274f9e8-e71a-4b8c-832d-b433d54c7013")
                        },
                        new
                        {
                            ProvinceId = 23,
                            Name = "فارس",
                            ProvinceGuid = new Guid("bf78b6bb-6242-43db-a2c4-2e5fe2e41586")
                        },
                        new
                        {
                            ProvinceId = 24,
                            Name = "کرمانشاه",
                            ProvinceGuid = new Guid("764634fc-03d7-4c4e-9fa9-9baa260faf02")
                        },
                        new
                        {
                            ProvinceId = 25,
                            Name = "هرمزگان",
                            ProvinceGuid = new Guid("e51e57c6-c908-4434-bb1f-d0ea0fdbbff1")
                        },
                        new
                        {
                            ProvinceId = 26,
                            Name = "مرکزي",
                            ProvinceGuid = new Guid("3b030e1a-4f81-41cb-8e1f-76b77dc7dd5f")
                        },
                        new
                        {
                            ProvinceId = 27,
                            Name = "گيلان",
                            ProvinceGuid = new Guid("3bbdae0a-aea0-4b46-a67d-3db95536af18")
                        },
                        new
                        {
                            ProvinceId = 28,
                            Name = "همدان",
                            ProvinceGuid = new Guid("9238a7d4-48e9-411d-bf6b-bd5a274a25c6")
                        },
                        new
                        {
                            ProvinceId = 29,
                            Name = "کرمان",
                            ProvinceGuid = new Guid("ea3deed6-76c2-4601-ae8f-3613e2e50420")
                        },
                        new
                        {
                            ProvinceId = 30,
                            Name = "سمنان",
                            ProvinceGuid = new Guid("dda847fd-8ea0-4883-ba87-84c281edb60e")
                        },
                        new
                        {
                            ProvinceId = 31,
                            Name = "کهگيلويه و بويراحمد",
                            ProvinceGuid = new Guid("dc8fee19-7b28-4ca1-a97b-58533bd7da78")
                        });
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountState")
                        .HasColumnType("int");

                    b.Property<string>("ActivitiesIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActivitiesStartYear")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("LatinFirstName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("LatinLastName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("ProfileDocumentId")
                        .HasColumnType("int");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("RawInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("UserGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int?>("UserIntroducedId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("ProfileDocumentId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("UserIntroducedId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            AccountState = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "سیدمهدی",
                            Identifier = "gamer-152482",
                            IsActive = false,
                            IsAdmin = true,
                            IsDelete = false,
                            LastName = "رودکی",
                            PhoneNumber = "09126842446",
                            PhoneNumberConfirmed = true,
                            UserGuid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            UserId = 2,
                            AccountState = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "دکتر",
                            Identifier = "gamer-561318",
                            IsActive = false,
                            IsAdmin = true,
                            IsDelete = false,
                            LastName = "آخشته",
                            PhoneNumber = "09192180663",
                            PhoneNumberConfirmed = true,
                            UserGuid = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.UserToken", b =>
                {
                    b.Property<int>("UserTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserTokenGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("UserTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.Category", b =>
                {
                    b.HasOne("GameTournament.Domain.Entities.Category", "ParentCategory")
                        .WithMany("InverseParentCategory")
                        .HasForeignKey("ParentCategoryId")
                        .HasConstraintName("FK_Category_ParentCategory");
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.Payment", b =>
                {
                    b.HasOne("GameTournament.Domain.Entities.User", "User")
                        .WithMany("Payment")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Payment_User")
                        .IsRequired();
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.Post", b =>
                {
                    b.HasOne("GameTournament.Domain.Entities.Document", "CoverDocument")
                        .WithMany("Post")
                        .HasForeignKey("CoverDocumentId")
                        .HasConstraintName("FK_Post_CoverDocument")
                        .IsRequired();

                    b.HasOne("GameTournament.Domain.Entities.User", "User")
                        .WithMany("Post")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Post_User")
                        .IsRequired();
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.PostCategory", b =>
                {
                    b.HasOne("GameTournament.Domain.Entities.Category", "Category")
                        .WithMany("PostCategory")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_PostCategory_Category")
                        .IsRequired();

                    b.HasOne("GameTournament.Domain.Entities.Post", "Post")
                        .WithMany("PostCategory")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostCategory_Post")
                        .IsRequired();
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.User", b =>
                {
                    b.HasOne("GameTournament.Domain.Entities.Document", "ProfileDocument")
                        .WithMany("User")
                        .HasForeignKey("ProfileDocumentId")
                        .HasConstraintName("FK_User_ImageDocument");

                    b.HasOne("GameTournament.Domain.Entities.Province", "Province")
                        .WithMany("User")
                        .HasForeignKey("ProvinceId")
                        .HasConstraintName("FK_User_Province");

                    b.HasOne("GameTournament.Domain.Entities.User", "UserIntroduced")
                        .WithMany("InverseUserIntroduced")
                        .HasForeignKey("UserIntroducedId")
                        .HasConstraintName("FK_User_UserIntroduced");
                });

            modelBuilder.Entity("GameTournament.Domain.Entities.UserToken", b =>
                {
                    b.HasOne("GameTournament.Domain.Entities.User", "User")
                        .WithMany("UserToken")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserToken_User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
