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
        string jsonBody = File.ReadAllText("/Users/dierokreator/Programming/Interasys/PetStore139Sharp/fixtures/pet1.json")

        // add file content to the request
        request.AddBody(jsonBody);

        var response = client.Execute(request);

        var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);
    }
}