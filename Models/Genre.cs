﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Genre
    {
        public Genre()
        {
            TitleGenres = new HashSet<TitleGenre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TitleGenre> TitleGenres { get; set; }
    }
}
