namespace FourAgesTest.HttpTypes;

public class UpdateJobTitleRequest
{
    public Guid Id { get; set; }
    public string NewName { get; set; }
}