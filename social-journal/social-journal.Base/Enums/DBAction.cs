using System.ComponentModel;

namespace social_journal.Base.Enums
{
    public enum DBAction
    {
        [Description("updated")]
        Update,

        [Description("removed")]
        Delete,
        
        [Description("added")]
        Add,

        [Description("found")]
        Get,
    }
}
