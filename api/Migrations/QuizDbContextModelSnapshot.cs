﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.DatabaseContext;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    partial class QuizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("api.Models.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("api.Models.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("QuizId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("api.Models.Entities.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<bool>("isOpen")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("api.Models.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfCompletion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PercentOfCorrectAnswers")
                        .HasColumnType("integer");

                    b.Property<int>("QuizId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("api.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClassQuiz", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("integer");

                    b.Property<int>("QuizzesId")
                        .HasColumnType("integer");

                    b.HasKey("ClassesId", "QuizzesId");

                    b.HasIndex("QuizzesId");

                    b.ToTable("ClassQuiz");
                });

            modelBuilder.Entity("ClassUser", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("ClassesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ClassUser");
                });

            modelBuilder.Entity("api.Models.Entities.Answer", b =>
                {
                    b.HasOne("api.Models.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("api.Models.Entities.Question", b =>
                {
                    b.HasOne("api.Models.Entities.Quiz", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("api.Models.Entities.Quiz", b =>
                {
                    b.HasOne("api.Models.Entities.User", "User")
                        .WithMany("Quizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Entities.Score", b =>
                {
                    b.HasOne("api.Models.Entities.Quiz", "Quiz")
                        .WithMany("Scores")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Entities.User", "User")
                        .WithMany("Scores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClassQuiz", b =>
                {
                    b.HasOne("api.Models.Entities.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Entities.Quiz", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassUser", b =>
                {
                    b.HasOne("api.Models.Entities.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("api.Models.Entities.Quiz", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("api.Models.Entities.User", b =>
                {
                    b.Navigation("Quizzes");

                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
