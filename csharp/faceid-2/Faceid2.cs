public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? obj) =>
        obj is FacialFeatures other
            && EyeColor == other.EyeColor
            && PhiltrumWidth == other.PhiltrumWidth;

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object? obj) =>
        obj is Identity other
            && Email == other.Email
            && Equals(FacialFeatures, other.FacialFeatures);

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private readonly HashSet<Identity> registered = [];
    private static readonly Identity Admin = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(Admin);

    public bool Register(Identity identity) => registered.Add(identity);

    public bool IsRegistered(Identity identity) => registered.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}
