using Employment.API.DTOs;
using Employment.API.Entities;
using Employment.API.Extensions;
using Parser.Common.Repositories;

namespace Employment.API.EndPoints
{
    public static class JobPositionEndPoint
    {
        public static void MapJobPositionEndPoint(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("api/JobPosition");
            group.MapGet("/", async (IRepository<JobPosition> _jobsRepository) =>
            {
                var jobPositions = (await _jobsRepository.GetAllAsync())
                .Select(jp => jp.AsDTO());
                return Results.Ok(jobPositions);
            })
            .WithName("GetAllPositions");

            group.MapGet("/{id}", async (Guid id, IRepository<JobPosition> _jobsRepository) =>
            {
                var jobPositions = (await _jobsRepository.GetByIdAsync(id));
                return (jobPositions != null)
                ? Results.Ok(jobPositions.AsDTO())
                : Results.NotFound();
            })
            .WithName("GetPositionById");
            group.MapPost("/", async (JobPositionDTO clientJob, IRepository<JobPosition> _jobsRepository) =>
            {
                await _jobsRepository.CreateAsync(clientJob.FomDTO());
            })
                .WithName("CreateJobPosition");
            group.MapPut("/", async (Guid id, JobPositionDTO clientJob, IRepository<JobPosition> _jobsRepository) =>
            {
                await _jobsRepository.UpdateAsync( id,clientJob.FomDTO());
            })
            .WithName("UpdateJobPosition");
            group.MapDelete("/", async (Guid guid, IRepository<JobPosition> _jobsRepository) =>
            {
                await _jobsRepository.DeleteAsync(guid);
            })
           .WithName("DeleteJobPosition");

        }
    }
}
