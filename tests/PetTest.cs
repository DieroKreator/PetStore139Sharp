using Newtonsoft.Json;
using RestSharp;

namespace Pet;

public class PetTest
{
    // API address
    private const string BASE_URL = "https://petstore.swagger.io/v2/";

    [Test, Order(1)]
    public void PostPetTest()
    {
        var client = new RestClient(BASE_URL);

        var request = new RestRequest("pet", Method.Post);

        // save pet.json in memory
        string jsonBody = File.ReadAllText("/Users/dierokreator/Programming/Interasys/PetStore139Sharp/fixtures/pet1.json");

        // add file content to the request
        request.AddBody(jsonBody);

        var response = client.Execute(request);

        var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);

        Console.WriteLine(responseBody);

        Assert.That((int)response.StatusCode, Is.EqualTo(200));

        String name = responseBody.name.ToString();
        Assert.That(name, Is.EqualTo("Athena"));

        // Assert.That(responseBody.name.ToString(), Is.EqualTo("Athena"));

        string status = responseBody.status;
        Assert.That(status, Is.EqualTo("available"));
    }

    [Test, Order(2)]
    public void GetPetTest()
    {
        int petId = 602740501;
        String petName = "Athena";
        String categoryName = "dog";
        String tagsName = "vacinado";

        var client = new RestClient(BASE_URL);
        var request = new RestRequest($"pet/{petId}", Method.Get);

        var response = client.Execute(request);

        var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);
        Console.WriteLine(responseBody);

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        Assert.That((int)responseBody.id, Is.EqualTo(petId));
        Assert.That((String)responseBody.name, Is.EqualTo(petName));
        Assert.That((String)responseBody.category.name, Is.EqualTo(categoryName));
        Assert.That((String)responseBody.tags[0].name, Is.EqualTo(tagsName));

    }
}