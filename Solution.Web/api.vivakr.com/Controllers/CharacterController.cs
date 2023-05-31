
using Microsoft.AspNetCore.Mvc;
using api.vivakr.com.Models;
namespace api.vivakr.com.Controllers;

/// <summary>
///* ~/api/character
/// </summary>
[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private static readonly List<Character> character = new()
    {
        new Character(),
        new Character {
            Id = 1,
            Name = "BravoBJ",
            HitPoints = 100,
            Strength = 10,
            Defense = 10,
            Intelligence =10,
            Class = RPGClass.Mage
        },
        new Character {
            Id = 2,
            Name = "HelloWorld"
        }
    };

    [HttpGet("GetAll")]
    // [Route("GetAll")]
    public ActionResult<List<Character>> Get()
    {
        return Ok(character);
        //! Ok :  200
        //! BadRequest : 400
        //! NotFound : 404
    }

    [HttpGet("{id}")]
    public ActionResult GetSingle(int id)
    {
        if(!character.Any(x=>x.Id == id)) return BadRequest();
        return Ok(character.Find(x=> x.Id == id));
    }
}

/*
    readonly : 생성자를 통하여서 반복적으로 값을 재 할당할 수 있음
*/
