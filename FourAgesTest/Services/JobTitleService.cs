using FourAgesTest.Abstractions;
using FourAgesTest.Domain;
using FourAgesTest.Domain.Entities;
using FourAgesTest.HttpTypes;
using Microsoft.EntityFrameworkCore;

namespace FourAgesTest.Services;

public class JobTitleService : IJobTitleService
{
    private readonly PosgresqlDatabaseContext _context;

    public JobTitleService(PosgresqlDatabaseContext context)
    {
        _context = context;
    }

    public async Task<JobTitle?> GetById(Guid id)
    {
        return await _context.JobTitles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<JobTitle>> GetAll()
    {
        return await _context.JobTitles.AsNoTracking().ToListAsync();
    }

    public async Task<JobTitle> Create(CreateJobTitleRequest request)
    {
        var jobTitle = JobTitle.Create(request.Name);
        
        var entry = await _context.JobTitles.AddAsync(jobTitle);
        await _context.SaveChangesAsync();
        
        return entry.Entity;
    }

    public async Task<JobTitle> Update(UpdateJobTitleRequest request)
    {
        var jobTitle = await _context.JobTitles.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (jobTitle is null)
        {
            throw new ArgumentException($"Id {request.Id} not found in database", nameof(request));
        }

        jobTitle.SetName(request.NewName);
        var entry = _context.JobTitles.Update(jobTitle);
        await _context.SaveChangesAsync();
        
        return entry.Entity;
    }

    public async Task Delete(Guid id)
    {
        var jobTitle = await _context.JobTitles.FirstOrDefaultAsync(x => x.Id == id);

        if (jobTitle is null)
        {
            throw new ArgumentException($"Id {id} not found in database", nameof(id));
        }
        
        var entry = _context.JobTitles.Remove(jobTitle);
        await _context.SaveChangesAsync();

    }
}