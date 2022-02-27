namespace ApiGatewayService.Models
{
    public class PetPhoto
    {
        public int PetID { get; set; }
        public string MetaData { get; set; }
        public Byte[] File { get; set; }
    }
}
