using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Jurnal_Mod_10_103022400031.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> dataGame = new List<Game>
        {
             new Game {Nama = "Valorant" , Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform = ["PC"], Mode = ["Multiplayer"], IsOnline = true, Harga = 0},
             new Game {Nama = "GTA V" , Developer = "Rosckstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5, Platform = ["PC", "PS4", "PS5", "Xbox"], Mode = ["Singleplayer", "Multiplayer"], IsOnline = true, Harga = 300000},
             new Game {Nama = "The Witcher" , Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform = ["PC", "PS4", "PS5", "Xbox", "Switch"], Mode = ["Singleplayer"], IsOnline = false, Harga = 250000},
             new Game {Nama = "Pragmata" , Developer = "Capcom", TahunRilis = 2026, Genre = "RPG", Rating = 9.0, Platform = ["PC", "PS4", "PS5", "Xbox"], Mode = ["Singleplayer"], IsOnline = false, Harga = 700000},
             new Game {Nama = "Resident Evil 9" , Developer = "Capcom", TahunRilis = 2026, Genre = "RPG", Rating = 9.7, Platform = ["PC", "PS4", "PS5", "Xbox"], Mode = ["Singleplayer"], IsOnline = false, Harga = 900000},
        };

        [HttpGet]

        public IEnumerable<Game> Get()
        {
            return dataGame;
        }

        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            int index = id - 1;
            if (index < 0 || index >= dataGame.Count)
            {
                return NotFound("Game tidak ditemukan.");
            }
            return dataGame[index];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Game newGame)
        {
            dataGame.Add(newGame);
            return Ok("Game berhasil ditambahkan.");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int index = id - 1;
            if (index < 0 || index >= dataGame.Count)
            {
                return NotFound("Game tidak ditemukan.");
            }
            dataGame.RemoveAt(index);
            return Ok("Game berhasil dihapus.");
        }
    }
}
