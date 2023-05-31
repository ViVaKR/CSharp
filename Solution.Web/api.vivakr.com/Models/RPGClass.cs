using System.Text.Json.Serialization;

namespace api.vivakr.com.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RPGClass
{
    Knight = 1, // 기사 
    Mage = 2, // 마술사 (메이지)
    Cleric = 3 // 성직자 (클래릭)
}
