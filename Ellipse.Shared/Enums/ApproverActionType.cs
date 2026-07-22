using System.ComponentModel;

namespace Ellipse.Shared.Enums
{
    public enum ApproverActionType
    {
        [Description("Line Manager Rejected")]
        LineManagerRejected = 0,
        [Description("Line Manager Approved")]
        LineManagerApproved = 1,
        [Description("ICT Manager")]
        LineManagerClosed = 2,
        [Description("ICT Manager Rejected")]
        ICTManagerRejected = 3,
        [Description("ICT Manager Approved")]
        ICTManagerApproved = 4,
        [Description("ICT Manager Closed")]
        ICTManagerClosed = 5,
        [Description("Training Verified")]
        TrainingVerified = 6,
        [Description("Training Unverified")]
        TrainingUnverified = 7,
        [Description("Hc Officer Implemented")]
        HcOfficerImplemented = 8,
        [Description("Hc Officer Rejected")]
        HcOfficerRejected = 9,
        [Description("Hc Officer Closed")]
        HcOfficerClosed = 10,
        [Description("Unknown Action")]
        UnknownAction = 11,
    }
}