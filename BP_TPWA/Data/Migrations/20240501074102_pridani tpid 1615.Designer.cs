﻿// <auto-generated />
using System;
using BP_TPWA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BP_TPWA.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240501074102_pridani tpid 1615")]
    partial class pridanitpid1615
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BP_TPWA.Models.Cvik", b =>
                {
                    b.Property<int>("CvikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CvikId"));

                    b.Property<string>("Nazev")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Partie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PauzaMeziSériemiSerialized")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PauzaMeziSériemi");

                    b.Property<string>("PopisCviku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PočetOpakováníSerialized")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PočetOpakování");

                    b.Property<string>("PočetSériíSerialized")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PočetSérií");

                    b.Property<string>("TypTreninkuSerialized")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TypTreninku");

                    b.Property<string>("UzivatelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("cvikVytvorenUzivatelem")
                        .HasColumnType("bit");

                    b.HasKey("CvikId");

                    b.HasIndex("UzivatelId");

                    b.HasIndex("Nazev", "UzivatelId")
                        .IsUnique();

                    b.ToTable("Cvik");
                });

            modelBuilder.Entity("BP_TPWA.Models.DenTreninku", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CvikySerialized")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cviky");

                    b.Property<DateTime>("DatumTreninku")
                        .HasColumnType("datetime2");

                    b.Property<int>("TPId")
                        .HasColumnType("int");

                    b.Property<string>("TypTreninku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TPId");

                    b.ToTable("DenTreninku");
                });

            modelBuilder.Entity("BP_TPWA.Models.DenVTydnu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Den")
                        .HasColumnType("int");

                    b.Property<bool>("DenTréninku")
                        .HasColumnType("bit");

                    b.Property<int?>("TPId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TPId");

                    b.ToTable("DenVTydnu");
                });

            modelBuilder.Entity("BP_TPWA.Models.TP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AktualniVaha")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DatumPoslednihoUlozeniVahy")
                        .HasColumnType("datetime2");

                    b.Property<string>("DruhTP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Délka")
                        .HasColumnType("int");

                    b.Property<int>("PocetTreninkuZaTyden")
                        .HasColumnType("int");

                    b.Property<string>("StylTP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UlozenaDataDnu")
                        .HasColumnType("bit");

                    b.Property<string>("UzivatelID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ZkontrolovaneDny")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UzivatelID");

                    b.ToTable("TP");
                });

            modelBuilder.Entity("BP_TPWA.Models.TreninkoveData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CisloSerie")
                        .HasColumnType("int");

                    b.Property<int>("CvicenaVaha")
                        .HasColumnType("int");

                    b.Property<int>("CvikId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("PocetOpakovani")
                        .HasColumnType("int");

                    b.Property<int>("TpId")
                        .HasColumnType("int");

                    b.Property<string>("UzivatelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("VahaUzivatele")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CvikId");

                    b.ToTable("TreninkoveData");
                });

            modelBuilder.Entity("BP_TPWA.Models.Uzivatel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("JakCastoAktualizovatVahu")
                        .HasColumnType("int");

                    b.Property<string>("Jmeno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Pohlavi")
                        .HasColumnType("int");

                    b.Property<DateTime>("PomocneDatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PridaneData")
                        .HasColumnType("bit");

                    b.Property<string>("Prijmeni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TPId")
                        .HasColumnType("int");

                    b.Property<string>("TreninkovyPlanySerialized")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TreninkovyPlany");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Uroven")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<double>("Vaha")
                        .HasColumnType("float");

                    b.Property<int>("Vek")
                        .HasColumnType("int");

                    b.Property<int>("Vyska")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BP_TPWA.Models.Cvik", b =>
                {
                    b.HasOne("BP_TPWA.Models.Uzivatel", "Uzivatel")
                        .WithMany()
                        .HasForeignKey("UzivatelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uzivatel");
                });

            modelBuilder.Entity("BP_TPWA.Models.DenTreninku", b =>
                {
                    b.HasOne("BP_TPWA.Models.TP", "TP")
                        .WithMany()
                        .HasForeignKey("TPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TP");
                });

            modelBuilder.Entity("BP_TPWA.Models.DenVTydnu", b =>
                {
                    b.HasOne("BP_TPWA.Models.TP", null)
                        .WithMany("DnyVTydnu")
                        .HasForeignKey("TPId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BP_TPWA.Models.TP", b =>
                {
                    b.HasOne("BP_TPWA.Models.Uzivatel", "User")
                        .WithMany()
                        .HasForeignKey("UzivatelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BP_TPWA.Models.TreninkoveData", b =>
                {
                    b.HasOne("BP_TPWA.Models.Cvik", "Cvik")
                        .WithMany()
                        .HasForeignKey("CvikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cvik");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BP_TPWA.Models.Uzivatel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BP_TPWA.Models.Uzivatel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BP_TPWA.Models.Uzivatel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BP_TPWA.Models.Uzivatel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BP_TPWA.Models.TP", b =>
                {
                    b.Navigation("DnyVTydnu");
                });
#pragma warning restore 612, 618
        }
    }
}
