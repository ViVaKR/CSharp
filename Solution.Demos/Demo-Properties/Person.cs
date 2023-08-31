
namespace Demo_Properties;
public class Customer
{
    private string? id;

    public string? Id
    {
        get => id;
        set => id = value;
    }

    private int password;

    public int Password
    {
        get => password;
        set
        {
            try
            {
                if (value < 1_000){
                    password = value;
                    return;
                }

                throw new Exception($"잘못된 `{value}` 비밀번호입니다.\n`1_000` 이하의 숫자를 넣어 주세요");
            }
            catch (Exception ex)
            {
                password = Password;
                Console.WriteLine(ex.Message + Environment.NewLine);
            }
        }
    }

    public override string ToString()
    {
        return $"고객님의 아이디는 ( {Id} ) 이고 비밀번호는 ( {Password} ) 입니다.";
    }
}
