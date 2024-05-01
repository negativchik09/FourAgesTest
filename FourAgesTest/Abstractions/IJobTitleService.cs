using FourAgesTest.Domain.Entities;
using FourAgesTest.HttpTypes;

namespace FourAgesTest.Abstractions;

public interface IJobTitleService
{
    public Task<JobTitle?> GetById(Guid id);
    public Task<List<JobTitle>> GetAll();
    public Task<JobTitle> Create(CreateJobTitleRequest request);
    public Task<JobTitle> Update(UpdateJobTitleRequest request);
    public Task Delete(Guid id);
}