using System;
using System.Collections.Generic;
using System.Text;

namespace Radio_Blue_Point.Models
{
    class Song
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public int Has_Lyrics { get; set; }
        public string Image { get; set; }
    }
}
