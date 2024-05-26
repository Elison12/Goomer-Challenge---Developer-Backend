using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GoomerChallenger.API.Controller
{

    public class RestauranteController {
    

       public RestauranteController() { }

        [HttpPost]
        public Task<ActionResult> Create()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public Task<ActionResult> Get(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch ( Exception ex)
            {
                throw;
            }
        }

        public Task<ActionResult> GetAll()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<ActionResult> Delete(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<ActionResult> Update(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }


}