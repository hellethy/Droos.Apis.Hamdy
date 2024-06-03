using System;
using System.Collections.Generic;
using Droos.Model.UserIdentitiy;
using Droos.Models;
using Microsoft.EntityFrameworkCore;

namespace Droos.Model.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {


    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<AnswersTemplate> AnswersTemplates { get; set; }

    public virtual DbSet<ApplicationUser> Users { get; set; }
    public virtual DbSet<ApplicationRole> Roles { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<ChapterContent> ChapterContents { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<EducationSystem> EducationSystems { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamTemplate> ExamTemplates { get; set; }

    public virtual DbSet<Governorate> Governorates { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<PayableItem> PayableItems { get; set; }

    public virtual DbSet<QuestionTemplate> QuestionTemplates { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SectionChapter> SectionChapters { get; set; }

    public virtual DbSet<SectionContent> SectionContents { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectSection> SubjectSections { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public object Remove()
    {
        throw new NotImplementedException();
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Trusted_Connection=true;TrustServerCertificate=True;Persist Security Info=False;Initial Catalog=Droos;Data Source=.\\sqlexpress");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<ApplicationUser>(b =>
        {
            b.HasKey(u => u.Id);
            b.Property(u => u.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ApplicationRole>(b =>
        {
            b.HasKey(r => r.Id);
            b.Property(r => r.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.ToTable("Answer");

            entity.Property(e => e.AnswerId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Text).HasMaxLength(1000);

            entity.HasOne(d => d.Exam).WithMany(p => p.Answers)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK_Answer_Exam");

            entity.HasOne(d => d.QuestionTemplate).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Answer_QuestionTemplate");
        });

        modelBuilder.Entity<AnswersTemplate>(entity =>
        {
            entity.HasKey(e => e.AnswerTemplateId);

            entity.ToTable("AnswersTemplate");

            entity.Property(e => e.AnswerTemplateId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(1000);

            entity.HasOne(d => d.QuestionTemplate).WithMany(p => p.AnswersTemplates)
                .HasForeignKey(d => d.QuestionTemplateId)
                .HasConstraintName("FK_AnswersTemplate_QuestionTemplate");
        });



        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.ChapterId).HasName("PK_Chapter");

            entity.Property(e => e.ChapterId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ChapterContent>(entity =>
        {
            entity.HasKey(e => e.ChapterContentId).HasName("PK_ChapterContent");

            entity.Property(e => e.ChapterContentId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Chapter).WithMany(p => p.ChapterContents)
                .HasForeignKey(d => d.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChapterContent_Chapter");

            entity.HasOne(d => d.Content).WithMany(p => p.ChapterContents)
                .HasForeignKey(d => d.ContentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChapterContent_Content");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK_Content");

            entity.Property(e => e.ContentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HtmlText).HasMaxLength(4000);
            entity.Property(e => e.IsFree).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Url)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("URL");
        });

        modelBuilder.Entity<EducationSystem>(entity =>
        {
            entity.HasKey(e => e.EducationSystemId).HasName("PK_EducationSystem_1");

            entity.Property(e => e.EducationSystemId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.ToTable("Exam");

            entity.Property(e => e.ExamId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.ExamTemplate).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamTemplateId)
                .HasConstraintName("FK_Exam_ExamTemplate");
        });

        modelBuilder.Entity<ExamTemplate>(entity =>
        {
            entity.ToTable("ExamTemplate");

            entity.Property(e => e.ExamTemplateId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Governorate>(entity =>
        {
            entity.HasKey(e => e.GovernorateId).HasName("PK_Governorate");

            entity.Property(e => e.GovernorateId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.Property(e => e.GradeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.EducationSystem).WithMany(p => p.Grades)
                .HasForeignKey(d => d.EducationSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grade_EducationSystem");

            entity.HasOne(d => d.Governorate).WithMany(p => p.Grades)
                .HasForeignKey(d => d.GovernorateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grade_Governorate");
        });

        modelBuilder.Entity<PayableItem>(entity =>
        {
            entity.ToTable("PayableItem");

            entity.Property(e => e.PayableItemId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Chapter).WithMany(p => p.PayableItems)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK_PayableItem_Chapters");

            entity.HasOne(d => d.Content).WithMany(p => p.PayableItems)
                .HasForeignKey(d => d.ContentId)
                .HasConstraintName("FK_PayableItem_Contents");

            entity.HasOne(d => d.Section).WithMany(p => p.PayableItems)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_PayableItem_Sections");

            entity.HasOne(d => d.Subject).WithMany(p => p.PayableItems)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_PayableItem_Subjects");
        });

        modelBuilder.Entity<QuestionTemplate>(entity =>
        {
            entity.ToTable("QuestionTemplate");

            entity.Property(e => e.QuestionTemplateId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(1000);

            entity.HasOne(d => d.ExamTemplate).WithMany(p => p.QuestionTemplates)
                .HasForeignKey(d => d.ExamTemplateId)
                .HasConstraintName("FK_QuestionTemplate_ExamTemplate");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK_Riview");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Comment).HasMaxLength(200);
            entity.Property(e => e.ItemType)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Item).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_Review_Contents");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.Property(e => e.SectionId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<SectionChapter>(entity =>
        {
            entity.Property(e => e.SectionChapterId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Chapter).WithMany(p => p.SectionChapters)
                .HasForeignKey(d => d.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SectionChapters_Chapters");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionChapters)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SectionChapters_Sections");
        });

        modelBuilder.Entity<SectionContent>(entity =>
        {
            entity.HasKey(e => e.SectionContentId).HasName("PK_SectionContent");

            entity.Property(e => e.SectionContentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.Property(e => e.SubjectId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Grade).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_Subject_Grade");
        });

        modelBuilder.Entity<SubjectSection>(entity =>
        {
            entity.Property(e => e.SubjectSectionId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Section).WithMany(p => p.SubjectSections)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectSections_Sections");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectSections)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectSections_Subject");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.Property(e => e.SubscriptionId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.PayableItem).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.PayableItemId)
                .HasConstraintName("FK_Subscriptions_PayableItem");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
