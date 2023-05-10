using System.Text.Json.Serialization;

namespace Practica.Web.Dto
{
    public class ItemDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
