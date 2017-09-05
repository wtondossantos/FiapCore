using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiapCore.Services
{
    public class SerieService : ISerieService
    {
        private Context.Context _context;

        public SerieService(Context.Context context) {
            _context = context;
        }

        public List<Serie> GetAll()
        {
            //var retorno = new List<Serie>();
            //for (int i = 0; i < 3; i++)
            //{
            //    retorno.Add(new Serie() { Id = i + 1, Titulo = $"Narcos {i + 1}" });
            //}
            return _context.Series.ToList();
        }
    }
    public class Serie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Título da série é obrigatório.")]
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
    }
}
