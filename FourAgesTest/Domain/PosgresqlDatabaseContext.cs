using FourAgesTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FourAgesTest.Domain;

public class PosgresqlDatabaseContext : DbContext
{
    public DbSet<JobTitle> JobTitles { get; set; }
    
    public PosgresqlDatabaseContext(DbContextOptions<PosgresqlDatabaseContext> options) : base(options){}
}