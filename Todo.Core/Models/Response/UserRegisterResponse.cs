namespace Todo.Core.Models.Response
{
    public class UserRegisterResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
    }
}
