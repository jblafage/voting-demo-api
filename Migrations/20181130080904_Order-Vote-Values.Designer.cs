﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api_voting_demo.Models;

namespace api_voting_demo.Migrations
{
    [DbContext(typeof(VotingDbContext))]
    [Migration("20181130080904_Order-Vote-Values")]
    partial class OrderVoteValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("api_voting_demo.Models.VoteResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("VoteDate");

                    b.Property<long>("VoteValueId");

                    b.HasKey("Id");

                    b.HasIndex("VoteValueId");

                    b.ToTable("VoteResults");
                });

            modelBuilder.Entity("api_voting_demo.Models.VoteValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("VoteValues");

                    b.HasData(
                        new { Id = 1L, Name = "Cats", Order = 0 },
                        new { Id = 2L, Name = "Dogs", Order = 0 }
                    );
                });

            modelBuilder.Entity("api_voting_demo.Models.VoteResult", b =>
                {
                    b.HasOne("api_voting_demo.Models.VoteValue")
                        .WithMany("VoteResults")
                        .HasForeignKey("VoteValueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
