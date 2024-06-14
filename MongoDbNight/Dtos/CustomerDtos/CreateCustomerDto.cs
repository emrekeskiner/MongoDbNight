namespace MongoDbNight.Dtos.CustomerDtos
{
    public class CreateCustomerDto
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
    }
}
