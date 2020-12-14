using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api.Models;

namespace api.Context
{
    public partial class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficios> Beneficios { get; set; }
        public virtual DbSet<CategoriasDocumentos> CategoriasDocumentos { get; set; }
        public virtual DbSet<DocumentosBeneficios> DocumentosBeneficios { get; set; }
        public virtual DbSet<LocaisTramitacao> LocaisTramitacao { get; set; }
        public virtual DbSet<Servidores> Servidores { get; set; }
        public virtual DbSet<Tramitacao> Tramitacao { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //         optionsBuilder.UseSqlServer("Data Source=den1.mssql7.gear.host; Initial Catalog=dbseplag;User ID=dbseplag;Password=Zl4HXrr~!oCE;");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beneficios>(entity =>
            {
                entity.HasKey(e => e.IdBeneficio);

                entity.ToTable("BENEFICIOS");

                entity.Property(e => e.DescricaoBeneficio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.Beneficios)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BENEFICIOS");
            });

            modelBuilder.Entity<CategoriasDocumentos>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaDocumento);

                entity.ToTable("CategoriasDocumentos");

                entity.Property(e => e.AbreviacaoCategoria)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoCategoria)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentosBeneficios>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoBeneficio);

                entity.ToTable("DocumentosBeneficios");

                entity.Property(e => e.DocumentoPdf)
                    .HasColumnName("DocumentoPDF")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBeneficioNavigation)
                    .WithMany(p => p.DocumentosBeneficios)
                    .HasForeignKey(d => d.IdBeneficio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentosBeneficios01");

                entity.HasOne(d => d.IdCategoriaDocumentoNavigation)
                    .WithMany(p => p.DocumentosBeneficios)
                    .HasForeignKey(d => d.IdCategoriaDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentosBeneficios02");
            });

            modelBuilder.Entity<LocaisTramitacao>(entity =>
            {
                entity.HasKey(e => e.IdLocalTramitacao);

                entity.ToTable("LocaisTramitacao");

                entity.Property(e => e.DescricaoLocalTramitacao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servidores>(entity =>
            {
                entity.HasKey(e => e.Matricula);

                entity.ToTable("SERVIDORES");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Orgao)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tramitacao>(entity =>
            {
                entity.HasKey(e => e.IdTramitacao);

                entity.ToTable("TRAMITACAO");

                entity.Property(e => e.DtTramitacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdBeneficioNavigation)
                    .WithMany(p => p.Tramitacao)
                    .HasForeignKey(d => d.IdBeneficio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRAMITACAO01");

                entity.HasOne(d => d.IdLocalTramitacaoDestinoNavigation)
                    .WithMany(p => p.TramitacaoIdLocalTramitacaoDestinoNavigation)
                    .HasForeignKey(d => d.IdLocalTramitacaoDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRAMITACAO03");

                entity.HasOne(d => d.IdLocalTramitacaoOrigemNavigation)
                    .WithMany(p => p.TramitacaoIdLocalTramitacaoOrigemNavigation)
                    .HasForeignKey(d => d.IdLocalTramitacaoOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRAMITACAO02");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIOS");

                entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd();

                entity.Property(e => e.NomeUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
