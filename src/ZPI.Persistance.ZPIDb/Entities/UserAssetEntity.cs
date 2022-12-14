namespace ZPI.Persistance.Entities;

public class UserAssetEntity
{
    public string UserId { get; set; }
    public string AssetIdentifier { get; set; }
    public double Value { get; set; }
    public string Description {get; set;}

    public virtual AssetEntity Asset { get; set; }
    public virtual UserPreferencesEntity User { get; set; }
}