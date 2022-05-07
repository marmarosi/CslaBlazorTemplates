namespace CslaBlazorTemplates.Contracts.SimpleView
{
    /// <summary>
    /// Defines the data access functions of the read-only team object.
    /// </summary>
    public interface ISimpleTeamViewDal
    {
        SimpleTeamViewDto Fetch(SimpleTeamViewCriteria criteria);
    }
}
