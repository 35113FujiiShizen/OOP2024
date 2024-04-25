using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Song {

        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Length { get; set; }

        public Song(string title, string artistName, int length) {
            this.Title = title;
            this.Length = length;
            this.ArtistName = artistName;
        }
    }
}
