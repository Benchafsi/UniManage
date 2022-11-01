namespace UniversityDatabaseManagementWebApp.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public override string ToString() =>
            $"{Id}, {Firstname}, {Lastname}";

    }
}
