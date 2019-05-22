using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using MoviesApp.Repository;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        MoviesRepository _moviesRepository = new MoviesRepository();


        [HttpGet("[action]")]
        public IEnumerable<MoviesModel> GetAllMovies()
        {
            return _moviesRepository.GetAllMovies();
        }

        [HttpGet("[action]")]
        public IEnumerable<ActorModel> GetAllActors()
        {
            return _moviesRepository.GetAllActors();
        }

        [HttpGet("[action]")]
        public IEnumerable<ProducersModel> GetAllProducers()
        {
            return _moviesRepository.GetAllProducers();
        }

        [HttpPost("[action]")]
        public StatusCodeResult AddNewProducer([FromBody]ProducersModel producer)
        {
            if (_moviesRepository.AddNewProducer(producer))
                return new StatusCodeResult(200);

            return new StatusCodeResult(400);
        }

        [HttpPost("[action]")]
        public StatusCodeResult AddNewActor([FromBody]ActorModel actor)
        {
            if (_moviesRepository.AddNewActor(actor))
                return new StatusCodeResult(200);

            return new StatusCodeResult(400);
        }

        [HttpPost("[action]")]
        public StatusCodeResult AddNewMovie([FromBody]MoviesModel movie)
        {          
            
            if (_moviesRepository.AddNewMovie(movie))
                return new StatusCodeResult(200);
            return new StatusCodeResult(400);
        }

        [HttpPost("[action]")]
        public StatusCodeResult UpdateMovie([FromBody]MoviesModel movie)
        {
            if (_moviesRepository.UpdateMovie(movie))
                return new StatusCodeResult(200);

            return new StatusCodeResult(400);
        }

        [HttpPost("[action]"), DisableRequestSizeLimit]
        public string UploadFile()
        {
            string fullPath = "";
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = "C:\\Users\\xsperiasamy\\source\\repos\\MoviesApp\\MoviesApp\\ClientApp\\src\\assets";
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return fullPath;
            }
            catch (System.Exception ex)
            {
                return "Upload Failed: ";
            }
        }
    }
}