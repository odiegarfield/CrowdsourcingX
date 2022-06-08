namespace CrowdsourcingX.Infra.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PaymentMethod { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Ethnicity { get; set; }
        public string CountryOfOrigin { get; set; }
        public string CountryOfResidence { get; set; }
        public string Signature { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}