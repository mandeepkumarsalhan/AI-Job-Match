using backend.Data;
using backend.DTOs;
using backend.Services;
using Microsoft.EntityFrameworkCore;

namespace backend.Tests;

public class JobServiceTests
{
    private AppDbContext CreateContext(string dbName) =>
        new(new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(dbName).Options);

    [Fact]
    public async Task CreateJobAsync_ShouldAddJob()
    {
        using var ctx = CreateContext(nameof(CreateJobAsync_ShouldAddJob));
        var service = new JobService(ctx);
        var dto = new CreateJobDto { Title = "Dev", Company = "Acme", Location = "Oslo", Description = "C# dev" };

        var job = await service.CreateJobAsync(dto);

        Assert.Equal("Dev", job.Title);
        Assert.Equal(1, await ctx.Jobs.CountAsync());
    }

    [Fact]
    public async Task GetAllJobsAsync_ShouldReturnAllJobs()
    {
        using var ctx = CreateContext(nameof(GetAllJobsAsync_ShouldReturnAllJobs));
        var service = new JobService(ctx);
        await service.CreateJobAsync(new CreateJobDto { Title = "A", Company = "C1", Location = "L1", Description = "D1" });
        await service.CreateJobAsync(new CreateJobDto { Title = "B", Company = "C2", Location = "L2", Description = "D2" });

        var jobs = await service.GetAllJobsAsync();

        Assert.Equal(2, jobs.Count);
    }

    [Fact]
    public async Task GetJobByIdAsync_ShouldReturnJob_WhenExists()
    {
        using var ctx = CreateContext(nameof(GetJobByIdAsync_ShouldReturnJob_WhenExists));
        var service = new JobService(ctx);
        var created = await service.CreateJobAsync(new CreateJobDto { Title = "Dev", Company = "Acme", Location = "Oslo", Description = "D" });

        var job = await service.GetJobByIdAsync(created.Id);

        Assert.NotNull(job);
        Assert.Equal(created.Id, job.Id);
    }

    [Fact]
    public async Task GetJobByIdAsync_ShouldReturnNull_WhenNotExists()
    {
        using var ctx = CreateContext(nameof(GetJobByIdAsync_ShouldReturnNull_WhenNotExists));
        var service = new JobService(ctx);

        var job = await service.GetJobByIdAsync(999);

        Assert.Null(job);
    }

    [Fact]
    public async Task UpdateJobAsync_ShouldUpdateJob_WhenExists()
    {
        using var ctx = CreateContext(nameof(UpdateJobAsync_ShouldUpdateJob_WhenExists));
        var service = new JobService(ctx);
        var created = await service.CreateJobAsync(new CreateJobDto { Title = "Old", Company = "OldCo", Location = "Bergen", Description = "Old" });

        var updated = await service.UpdateJobAsync(created.Id, new UpdateJobDto { Title = "New", Company = "NewCo", Location = "Oslo", Description = "New" });

        Assert.NotNull(updated);
        Assert.Equal("New", updated.Title);
        Assert.Equal("NewCo", updated.Company);
    }

    [Fact]
    public async Task UpdateJobAsync_ShouldReturnNull_WhenNotExists()
    {
        using var ctx = CreateContext(nameof(UpdateJobAsync_ShouldReturnNull_WhenNotExists));
        var service = new JobService(ctx);

        var result = await service.UpdateJobAsync(999, new UpdateJobDto { Title = "X", Company = "X", Location = "X", Description = "X" });

        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteJobAsync_ShouldReturnTrue_WhenExists()
    {
        using var ctx = CreateContext(nameof(DeleteJobAsync_ShouldReturnTrue_WhenExists));
        var service = new JobService(ctx);
        var created = await service.CreateJobAsync(new CreateJobDto { Title = "Dev", Company = "Acme", Location = "Oslo", Description = "D" });

        var result = await service.DeleteJobAsync(created.Id);

        Assert.True(result);
        Assert.Equal(0, await ctx.Jobs.CountAsync());
    }

    [Fact]
    public async Task DeleteJobAsync_ShouldReturnFalse_WhenNotExists()
    {
        using var ctx = CreateContext(nameof(DeleteJobAsync_ShouldReturnFalse_WhenNotExists));
        var service = new JobService(ctx);

        var result = await service.DeleteJobAsync(999);

        Assert.False(result);
    }
}
