using System.ComponentModel.DataAnnotations;

namespace MVCMovieBase.Web.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Range(1930, 2023)]
        public int Year { get; set; }

        public string Country { get; set; }

        [Range(1, 10)]
        public int? ScoreAverage { get; set; }

        [Range(0, double.MaxValue)]
        public int? ScoreVotesCount { get; set; }
    }
}
