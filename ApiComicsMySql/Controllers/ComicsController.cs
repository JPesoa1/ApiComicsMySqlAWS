using ApiComicsMySql.Models;
using ApiComicsMySql.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiComicsMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private RepositoryComics repo;

        public ComicsController(RepositoryComics repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("action")]
        public async Task<ActionResult<List<Comic>>> GetComicList()
        {
            return await this.repo.GetComicsAsync();
        }

        [HttpGet("{id}")]
        [Route("action")]
        public async Task<ActionResult<Comic>> Find(int id)
        {
            return await this.repo.FindComicAsync(id);
        }

        [HttpPost]
        [Route("action")]
        public async Task<ActionResult> Create (Comic comic)
        {
            await this.repo.CreateComicAsync(comic.Nombre, comic.Imagen);
            return Ok();
        }

        [HttpPut]
        [Route("action")]
        public async Task<ActionResult> Update(Comic comic)
        {
            await this.repo.UpdateComicAsync(comic.IdComic,comic.Nombre, comic.Imagen);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("action")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.repo.DeleteComicAsync(id);
            return Ok();
        }


    }
}
