using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CharacterSheetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterSheetController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CharacterSheetController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get()
        {
            return Ok(await _dataContext.Characters.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> Get(int id)
        {
            var ch = await _dataContext.Characters.FindAsync(id);
            if(ch == null)
                return BadRequest("Not Found!");
            else
                return Ok(ch);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character c)
        {
            _dataContext.Characters.Add(c);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Characters.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Character>>> UpdateCharacter(Character chr)
        {
            var ch = _dataContext.Characters.Find(chr.Id);
            if (ch == null)
                return BadRequest("Not Found!");
            
            ch.Character_Name = chr.Character_Name;
            ch.Player_Name = chr.Player_Name;
            ch.Level = chr.Level;
            ch.Character_Race = chr.Character_Race;
            ch.Character_Background = chr.Character_Background;
            ch.Character_Class = chr.Character_Class;
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Characters.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Character>>> DeleteCharacter(int id)
        {
            var ch = _dataContext.Characters.Find(id);
            if (ch == null)
                return BadRequest("Not Found!");

            _dataContext.Characters.Remove(ch);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Characters.ToListAsync());
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class CharacterListController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CharacterListController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Get(Character c)
        {
            return Ok(await _dataContext.Characters.Where(aranan => 
            aranan.Character_Name.IndexOf(c.Character_Name)>=0 &&
            aranan.Player_Name.IndexOf(c.Player_Name) >= 0 &&
            (c.Level == 0 || aranan.Level == c.Level) &&
            aranan.Character_Class.IndexOf(c.Character_Class) >= 0 &&
            aranan.Character_Background.IndexOf(c.Character_Background) >= 0 &&
            aranan.Character_Race.IndexOf(c.Character_Race) >= 0
            ).ToListAsync());
        }
    }
}
