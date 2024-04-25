using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {
            var songs = new Song[] {
                new Song ("FAKELAND","FAKETYPE",196),
                new Song("Yummy Yummy Yummy","FAKETYPE",200)
            };
            PrintSongs(songs);
        }

        private static void PrintSongs(Song[] songs) {
            //ヒント
            foreach (var song in songs) {
                Console.WriteLine(@"{0}{1}{2:hh\:mm\:ss}", song.Title, song.ArtistName, TimeSpan.FromSeconds(songs.Length));
            }

        }
    }
}
