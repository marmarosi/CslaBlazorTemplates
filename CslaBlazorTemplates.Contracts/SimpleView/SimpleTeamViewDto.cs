namespace CslaBlazorTemplates.Contracts.SimpleView
{
    /// <summary>
    /// Defines the data access object of the read-only team object.
    /// </summary>
    public class SimpleTeamViewDto
    {
        public long? TeamKey { get; set; }
        public string TeamCode { get; set; }
        public string TeamName { get; set; }
    }
}
