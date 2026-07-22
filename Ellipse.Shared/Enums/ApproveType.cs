using System.ComponentModel;

namespace Ellipse.Shared.Enums
{
    public enum ApproverType
    {
        [Description("Line Manager")]
        LineManager = 0,
        [Description("Training Center Representative")]
        TrainingCenterRepresentative = 1,
        [Description("HC Officer")]
        HCOfficer = 2,
        [Description("ICT Manager")]
        ICTManager = 3,
        [Description("Unknown Approver")]
        UnknownApprover = 4,
    }
}
