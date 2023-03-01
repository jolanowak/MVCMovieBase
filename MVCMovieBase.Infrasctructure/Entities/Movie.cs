﻿namespace MVCMovieBase.Infrasctructure.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }
        public int? ScoreAverage { get; set; }
        public int? ScoreVotesCount { get; set; }
    }
}
