namespace Application.Validations;

internal class Validations : IValidations
{
    public string message { get; set; } = string.Empty;
    public bool ValidatePath(string path)
    {
        if (!Directory.Exists(path))
        {
            message = "Putanja koju ste definisali ne postoji!";
            return false;
        }
        return true;
    }
    public bool ValidateTime(int maxDuration, int minDuration, int trueDuration)
    {
        if (trueDuration < minDuration)
        {
            message = "Vrijeme razmaka operacije je prekratko!";
            return false;
        }
        if (trueDuration > maxDuration)
        {
            message = "Vrijeme razmaka operacije je predugo!";
            return false;
        }
        return true;
    }
}
