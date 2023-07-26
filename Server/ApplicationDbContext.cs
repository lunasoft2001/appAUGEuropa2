using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using appAUGEuropa2.Shared;

namespace appAUGEuropa2.Server;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Script> Scripts { get; set; }

    public virtual DbSet<ScriptDetalle> ScriptDetalles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=tcp:auge.database.windows.net,1433;Initial Catalog=appScripts;Persist Security Info=False;User ID=Juanjo;Password=#MadridAccess23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Script>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__script__3213E83F436B6BC3");

            entity.ToTable("script");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Scripts)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__script__usuario___60A75C0F");
        });

        modelBuilder.Entity<ScriptDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__scriptDe__3213E83FA14EFE20");

            entity.ToTable("scriptDetalle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.ScriptId).HasColumnName("script_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Script).WithMany(p => p.ScriptDetalles)
                .HasForeignKey(d => d.ScriptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_scriptDetalle_script");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83F2C1BDA05");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164104D1355").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
