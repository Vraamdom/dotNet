
using Microsoft.EntityFrameworkCore;
using projectef.Models;
namespace projectef;

public class TareasContext:DbContext{
    //se importa la libreria using
    //Representan las tablas de la db
    public DbSet<Categoria> Categorias {get; set;} //en caso de error importa using projectef.Models;
    public DbSet<Tarea> Tareas{get; set;}
    
    //se crea el metodo constructor
    public TareasContext (DbContextOptions<TareasContext>options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Categoria>(categoria =>{
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p=>  p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion);
        });

        modelBuilder.Entity<Tarea>(tarea =>{
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p=>  p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaID);
            tarea.Property(p => p.Descripcion);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
        });
    }
}
