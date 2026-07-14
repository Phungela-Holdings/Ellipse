namespace Ellipse.Data.Entities
{
    public class Contractor
    {
        public int Id { get; set; }

        public string IdentificationNumber { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string CompanyName { get; set; }

        public string ResponsibleManager { get; set; }

        public string BusinessJustification { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DepartmentId { get; set; }

        public int BranchId { get; set; }

        public bool Active { get; set; }

        public List<Request> Requests { get; set; }
    }
}