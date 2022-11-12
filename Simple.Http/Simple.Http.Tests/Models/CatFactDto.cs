using System.Text.Json.Serialization;

namespace Simple.Http.Tests.Models;

public class CatFactDto
{
    [JsonPropertyName("fact")]
    public string Fact { get; set; }
    
    [JsonPropertyName("length")]
    public int Length { get; set; }
}