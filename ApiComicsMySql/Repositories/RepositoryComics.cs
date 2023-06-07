using ApiComicsMySql.Data;
using ApiComicsMySql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComicsMySql.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        public async Task<List<Comic>> GetComicsAsync()
            => await this.context.Comics.ToListAsync();
        public async Task<Comic> FindComicAsync(int id)
        {
            return await this.context.Comics.FirstOrDefaultAsync(x => x.IdComic == id);
        }
        private int GetMaxId()
        {
            return this.context.Comics.Max(x => x.IdComic) + 1;
        }
        public async Task CreateComicAsync(string nombre, string imagen)
        {
            Comic comic = new Comic();
            comic.IdComic = this.GetMaxId();
            comic.Nombre = nombre;
            comic.Imagen = imagen;

            await this.context.Comics.AddAsync(comic);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateComicAsync(int id,string nombre, string imagen)
        {
            Comic comic = await this.FindComicAsync(id);
            comic.Nombre = nombre;
            comic.Imagen = imagen;
            await this.context.SaveChangesAsync();
        }
        public async Task DeleteComicAsync(int id)
        {
            Comic comic = await this.FindComicAsync(id);

            this.context.Comics.Remove(comic);
            await this.context.SaveChangesAsync();
        }

    }
}
