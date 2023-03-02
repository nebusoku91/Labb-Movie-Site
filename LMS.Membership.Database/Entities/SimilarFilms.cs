using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Membership.Database.Entities
{
    public class SimilarFilms : IReferenceEntity
    {
        public int FilmId { get; set; }
        public int SimilarFilmId { get; set; }

        public virtual Film Film { get; set; }
        [ForeignKey("SimilarFilmId")]
        public virtual Film Similar { get; set; }
    }
}
