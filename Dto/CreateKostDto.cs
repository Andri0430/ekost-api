namespace EKostApi.Dto
{
    public class CreateKostDto
    {
        public string KostName { get; set; } = string.Empty;
        public int KostPrice { get; set; }
        public int IdTypeKost { get; set; }
        public string Province { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int QtyRoom { get; set; }

    }
}
