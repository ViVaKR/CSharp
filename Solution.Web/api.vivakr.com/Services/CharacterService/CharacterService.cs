

namespace api.vivakr.com.Services.CharacterService;
public class CharacterService : ICharacterService
{
    private static readonly List<Character> characters = new()
    {
        new Character(),
        new Character { Id = 1, Name = "BravoBJ"},
        new Character {Id = 2,Name = "Jang"}
    };
    public IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto data)
    {
        var character = _mapper.Map<Character>(data);
        character.Id = characters.Max(x => x.Id) + 1;
        characters.Add(character);

        return new ServiceResponse<List<GetCharacterDto>>
        {
            Data = characters.ConvertAll(_mapper.Map<GetCharacterDto>)
        };
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        return new ServiceResponse<List<GetCharacterDto>>
        {
            Data = characters.ConvertAll(_mapper.Map<GetCharacterDto>)
        };
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        if (characters.Any(x => x.Id == id))
        {
            return new ServiceResponse<GetCharacterDto>
            {
                Data = _mapper.Map<GetCharacterDto>(characters.Single(x => x.Id == id))
            };
        }
        throw new Exception("Character not found");
    }
}
