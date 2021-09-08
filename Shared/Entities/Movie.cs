using System;

namespace Clear.CodeSample.Shared.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }


        public DateTime Release { get; set; }

        public short Runtime { get; set; }

        
        public byte CategoryId { get; set; }
        public Category Category { get; set; }


        public int DirectorId { get; set; }

        public Director Director { get; set; }
    }
}
