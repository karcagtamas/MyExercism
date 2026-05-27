using System.Text.Json;
using System.Text.Json.Serialization;

public class RestApi
{
    private static readonly JsonSerializerOptions JsonOptions =
        new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    private readonly List<User> users;
    public RestApi(string database)
    {
        users = JsonSerializer.Deserialize<List<User>>(database, JsonOptions) ?? [];
    }

    public string Get(string url, string? payload = null)
    {
        if (url != "/users") throw new ArgumentException();

        List<User> result = users;

        if (payload != null)
        {
            var request = JsonSerializer.Deserialize<UserReuqest>(payload, JsonOptions)!;

            result = [.. users
                .Where(u => request.Users.Contains(u.Name))
                .OrderBy(u => u.Name)];
        }

        return JsonSerializer.Serialize(result, JsonOptions);
    }

    public string Post(string url, string payload)
    {
        return url switch
        {
            "/add" => AddUser(payload),
            "/iou" => AddIou(payload),
            _ => throw new ArgumentException(),
        };
    }

    private string AddUser(string payload)
    {
        var request = JsonSerializer.Deserialize<AddUserRequest>(payload, JsonOptions)!;

        var user = new User
        {
            Name = request.User,
        };

        users.Add(user);

        return JsonSerializer.Serialize(user, JsonOptions);
    }

    private string AddIou(string payload)
    {
        var request = JsonSerializer.Deserialize<IouRequest>(payload, JsonOptions)!;

        var lender = users.Single(u => u.Name == request.Lender);
        var borrower = users.Single(u => u.Name == request.Borrower);
        var amount = request.Amount;

        if (lender.Owes.TryGetValue(borrower.Name, out decimal debt))
        {
            if (debt > amount)
            {
                lender.Owes[borrower.Name] -= amount;
                borrower.OwedBy[lender.Name] -= amount;
            }
            else if (debt == amount)
            {
                lender.Owes.Remove(borrower.Name);
                borrower.OwedBy.Remove(lender.Name);
            }
            else
            {
                lender.Owes.Remove(borrower.Name);
                borrower.OwedBy.Remove(lender.Name);

                amount -= debt;

                lender.OwedBy[borrower.Name] = amount;
                borrower.Owes[lender.Name] = amount;
            }
        }
        else
        {
            lender.OwedBy[lender.Name == borrower.Name ? "" : borrower.Name] =
                lender.OwedBy.GetValueOrDefault(borrower.Name) + amount;

            borrower.Owes[lender.Name] =
                borrower.Owes.GetValueOrDefault(lender.Name) + amount;
        }

        var result = new List<User> { lender, borrower }.OrderBy(x => x.Name);

        return JsonSerializer.Serialize(result, JsonOptions);
    }

    public class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("owes")]
        public SortedDictionary<string, decimal> Owes { get; set; } = [];

        [JsonPropertyName("owed_by")]
        public SortedDictionary<string, decimal> OwedBy { get; set; } = [];

        [JsonPropertyName("balance")]
        public decimal Balance => OwedBy.Values.Sum() - Owes.Values.Sum();
    }

    public class AddUserRequest
    {
        [JsonPropertyName("user")]
        public string User { get; set; } = string.Empty;
    }

    public class UserReuqest
    {
        [JsonPropertyName("users")]
        public List<string> Users { get; set; } = [];
    }

    public class IouRequest
    {
        [JsonPropertyName("lender")]
        public string Lender { get; set; } = string.Empty;

        [JsonPropertyName("borrower")]
        public string Borrower { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}
