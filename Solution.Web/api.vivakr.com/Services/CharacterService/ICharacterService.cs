namespace api.vivakr.com.Services.CharacterService;
public interface ICharacterService
{
    Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
    Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
    Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto data);
    Task<ServiceResponse<List<GetCharacterDto>>> UpdateCharacter(AddCharacterDto data);
}
