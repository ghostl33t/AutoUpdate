namespace Application.Validations;

internal interface IValidations
{
    public string message { get; set; }
    public bool ValidatePath(string path);
    public bool ValidateTime(int maxDuration, int minDuration, int trueDuration);
}
