using Gateway.Entities;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;

namespace Gateway.Aggregators
{
    public class ClientJobsAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var clientsResponse = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var jobsResponse = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var clients = JsonConvert.DeserializeObject<List<Client>>(clientsResponse);
            var jobs = JsonConvert.DeserializeObject<List<JobPosition>>(jobsResponse);

            //foreach (Client client in clients)
            //{
            //    var jobsCl = jobs.Where(jc => jc.ClientId == client.Id).ToList();
            //    client.Jobs.AddRange(jobsCl);
            //}

            var joinedData = from client in clients
                             join job in jobs on client.Id equals job.ClientId into clientJobs
                             select new Client
                             {
                                 Id = client.Id,
                                 Name = client.Name,
                                 Address = client.Address,
                                 Description = client.Description,
                                 Status = client.Status,
                                 Jobs = clientJobs.ToList() // client.Jobs.Concat(clientJobs).ToList()
                             };

            var dataSerialized = JsonConvert.SerializeObject(joinedData);
            var stringContent = new StringContent(dataSerialized);
            {

            }

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}
