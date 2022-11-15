using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository;
using DataAccess;
using GolestanTestProject.Models;
using DataAccess.ActivityModels;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolestanTestProject.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GolestanActivityController : ControllerBase
    {
        private Activity _activity;
        private IGolestanTestRepos<RetailStore> _retailStore;
        private WebApiResponse _webApiResponse;

        public GolestanActivityController(Activity activity, IGolestanTestRepos<RetailStore> retailStore, WebApiResponse webApiResponse)
        {
            _activity = activity;
            _retailStore = retailStore;
            _webApiResponse = webApiResponse;
        }










        // GET: api/<GolestanActivityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GolestanActivityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("GetRetailStore")]
        public IActionResult GetRetailStore(GetRetailStoreModel model)
        {

           var res =  _retailStore.GetById(model.Id);
            _webApiResponse.Data = res;
            return Ok(_webApiResponse);
        }

        [HttpPost("AddRetailStore")]
        public IActionResult AddRetailStore(AddRetailStoreModel model)
        {

            var res = _activity.PROC_AddRetailStore(model);

            return Ok(res);
        }


        [HttpPost("UpdateRetailStore")]
        public IActionResult UpdateRetailStore(UpdateRetailModel model)
        {
            var res = _activity.PROC_UpdateRetailStore(model);
            return Ok(res);
        }

        [HttpPost("DeleteRetailStore")]
        public IActionResult DeleteRetailStore(PROC_DeleteRetailStoreModel model)
        {
            var res = _activity.PROC_DeleteRetailStore(model);

            return Ok(res);
        }


        [HttpPost("AddWorkSation")]
        public IActionResult AddWorkSation(PROC_AddWorkStationsModel model)
        {
            var res = _activity.PROC_AddWorkStations(model);
            return Ok(res);
        }



        [HttpPost("UpdateWorkStation")]
        public IActionResult UpdateWorkStation(PROC_UpdateWorkStationsModel model)
        {
            var res = _activity.PROC_UpdateWorkStations(model);

            return Ok(res);
        }

        [HttpPost("DeleteWorkStaion")]
        public IActionResult DeleteWorkStaion(PROC_DeleteWorkStationModel model)
        {
            var res = _activity.PROC_DeleteWorkStation(model);
            return Ok(res);
        }


        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            var res = _retailStore.GetAll().Include(pp=> pp.Children).ToList();
            _webApiResponse.Data = res;
            return Ok(_webApiResponse);
        }



        // POST api/<GolestanActivityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GolestanActivityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GolestanActivityController>/5

    }
}
