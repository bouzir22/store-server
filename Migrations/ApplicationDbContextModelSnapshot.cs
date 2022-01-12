﻿// <auto-generated />
using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("API.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PanierId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClientId");

                    b.HasIndex("PanierId");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("API.Entities.Commande", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("ClientId");

                    b.ToTable("commandes");
                });

            modelBuilder.Entity("API.Entities.LigneComamnde", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCommande")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProduitID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("commandeid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("ProduitID");

                    b.HasIndex("commandeid");

                    b.ToTable("ligneComamndes");
                });

            modelBuilder.Entity("API.Entities.Magasin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("magasins");
                });

            modelBuilder.Entity("API.Entities.Panier", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("paniers");
                });

            modelBuilder.Entity("API.Entities.PanierProduit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProduitID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("panierid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantite")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("ProduitID");

                    b.HasIndex("panierid");

                    b.ToTable("panierProduits");
                });

            modelBuilder.Entity("API.Entities.Produit", b =>
                {
                    b.Property<int>("ProduitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Magasinid")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Prix")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantite")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProduitID");

                    b.HasIndex("Magasinid");

                    b.ToTable("produits");
                });

            modelBuilder.Entity("API.Entities.Vendeur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("magasinid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("magasinid");

                    b.ToTable("vendeurs");
                });

            modelBuilder.Entity("API.Entities.Client", b =>
                {
                    b.HasOne("API.Entities.Panier", "panier")
                        .WithMany()
                        .HasForeignKey("PanierId");

                    b.Navigation("panier");
                });

            modelBuilder.Entity("API.Entities.Commande", b =>
                {
                    b.HasOne("API.Entities.Client", null)
                        .WithMany("commandes")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("API.Entities.LigneComamnde", b =>
                {
                    b.HasOne("API.Entities.Produit", "produit")
                        .WithMany("commandes")
                        .HasForeignKey("ProduitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Commande", "commande")
                        .WithMany("listProduits")
                        .HasForeignKey("commandeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("commande");

                    b.Navigation("produit");
                });

            modelBuilder.Entity("API.Entities.PanierProduit", b =>
                {
                    b.HasOne("API.Entities.Produit", "produit")
                        .WithMany("paniers")
                        .HasForeignKey("ProduitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Panier", "panier")
                        .WithMany("produits")
                        .HasForeignKey("panierid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("panier");

                    b.Navigation("produit");
                });

            modelBuilder.Entity("API.Entities.Produit", b =>
                {
                    b.HasOne("API.Entities.Magasin", null)
                        .WithMany("produits")
                        .HasForeignKey("Magasinid");
                });

            modelBuilder.Entity("API.Entities.Vendeur", b =>
                {
                    b.HasOne("API.Entities.Magasin", "magasin")
                        .WithMany()
                        .HasForeignKey("magasinid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("magasin");
                });

            modelBuilder.Entity("API.Entities.Client", b =>
                {
                    b.Navigation("commandes");
                });

            modelBuilder.Entity("API.Entities.Commande", b =>
                {
                    b.Navigation("listProduits");
                });

            modelBuilder.Entity("API.Entities.Magasin", b =>
                {
                    b.Navigation("produits");
                });

            modelBuilder.Entity("API.Entities.Panier", b =>
                {
                    b.Navigation("produits");
                });

            modelBuilder.Entity("API.Entities.Produit", b =>
                {
                    b.Navigation("commandes");

                    b.Navigation("paniers");
                });
#pragma warning restore 612, 618
        }
    }
}
