using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity;

public partial class OrchotDbContext : DbContext
{
    public OrchotDbContext()
    {
    }

    public OrchotDbContext(DbContextOptions<OrchotDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocReferance> DocReferances { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<TblAssist> TblAssists { get; set; }

    public virtual DbSet<TblAssistValue> TblAssistValues { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ViewLog> ViewLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ORCHOT_DBDB;TrustServerCertificate=true;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocReferance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DocRefer__3214EC27F04696EC");

            entity.ToTable("DocReferance");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DocId).HasColumnName("DocID");
            entity.Property(e => e.Ref).HasMaxLength(250);
            entity.Property(e => e.RefType).HasMaxLength(50);

            entity.HasOne(d => d.Doc).WithMany(p => p.DocReferances)
                .HasForeignKey(d => d.DocId)
                .HasConstraintName("FK__DocRefera__DocID__3C69FB99");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC2797EA6043");

            entity.ToTable("Document");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BusinessUnit).HasMaxLength(25);
            entity.Property(e => e.CreateBy).HasMaxLength(25);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(25);
            entity.Property(e => e.DocLink).HasMaxLength(200);
            entity.Property(e => e.DocType).HasMaxLength(25);
            entity.Property(e => e.DocumentName).HasMaxLength(250);
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.LastAlert).HasColumnType("datetime");
            entity.Property(e => e.MailAddress).HasMaxLength(50);
            entity.Property(e => e.Organization).HasMaxLength(25);
        });

        modelBuilder.Entity<TblAssist>(entity =>
        {
            entity.HasKey(e => e.TableCode);

            entity.ToTable("tbl_assist");

            entity.Property(e => e.TableCode).ValueGeneratedNever();
            entity.Property(e => e.TableDescription).HasMaxLength(150);
            entity.Property(e => e.TableName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblAssistValue>(entity =>
        {
            entity.HasKey(e => new { e.TableCode, e.Code });

            entity.ToTable("tbl_assist_value");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Value1).HasMaxLength(250);

            entity.HasOne(d => d.TableCodeNavigation).WithMany(p => p.TblAssistValues)
                .HasForeignKey(d => d.TableCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_assis__Table__25869641");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC272882D6EB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Department).HasMaxLength(25);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.MailAddress).HasMaxLength(25);
            entity.Property(e => e.Mobile).HasMaxLength(25);
            entity.Property(e => e.Password).HasMaxLength(25);
            entity.Property(e => e.UserName).HasMaxLength(25);
        });

        modelBuilder.Entity<ViewLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ViewLog__3214EC2777D5B25C");

            entity.ToTable("ViewLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DocumentName).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Ip)
                .HasMaxLength(25)
                .HasColumnName("IP");
            entity.Property(e => e.ViewDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
