using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using request_show_and_tell.Db;
using request_show_and_tell.Models;

namespace request_show_and_tell.Controllers
{
    [ApiController]
    [Route("thing")]
    public class ThingController : ControllerBase
    {

        private readonly ILogger<ThingController> _logger;
        private readonly ThingRepo repo;
        private readonly RequestRepo requestRepo;
        public ThingController(ILogger<ThingController> logger)
        {
            _logger = logger;
            repo = new ThingRepo();
            requestRepo = new RequestRepo();
        }

        [HttpGet]
        public async Task<IEnumerable<Thing>> Get()
        {
            return await this.repo.FindAll();
        }

        [HttpPost]
        [Route("/thing/bulk")]
        public async Task<ActionResult<bool>> BulkCreateRandom(int count)
        {
            for(int i = 0; i < count; i++)
            {
                var newThing = new Thing();
                await repo.Insert(newThing);
            }
            return true;
        }

        [HttpPost]
        [Route("/thing/bulkDeactivate")]
        public async Task<ActionResult<Thing[]>> BulkDeactivate()
        {
            var things = await this.repo.FindAll();
            foreach (var thing in things)
            {
                await Task.Delay(1000);
                thing.Active = false;
                await repo.Update(thing);
            }
            return things.ToArray();
        }

        [HttpPost]
        [Route("/thing/requestBulk")]
        public async Task<ActionResult<Request>> RequestBulkCreate()
        {
             var request = new Request();
             request.Tasks = (await this.repo.FindAll()).Select(t => t.Id).ToList();
             await this.requestRepo.Insert(request);
             await Task.Delay(1000);
             return request;   
        }
    }
}
