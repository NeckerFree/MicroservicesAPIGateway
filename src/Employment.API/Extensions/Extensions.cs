using Employment.API.DTOs;
using Employment.API.Entities;
using System.Linq.Expressions;

namespace Employment.API.Extensions
{
    public static class Extensions
    {
        public static JobPositionDTO AsDTO(this JobPosition jobPosition)
        {
            return new JobPositionDTO(jobPosition.Id,  jobPosition.ClientId, jobPosition.Title, jobPosition.Description, jobPosition.Requisites);
        }
        public static JobPosition FomDTO(this JobPositionDTO clientJob)
        {
            return new JobPosition()
            {
                ClientId = clientJob.ClientId,
                Title = clientJob.Title,
                Description = clientJob.Description,
                Id = clientJob.Id,
                Requisites = clientJob.Requisites,
            };
        }
    }
}
