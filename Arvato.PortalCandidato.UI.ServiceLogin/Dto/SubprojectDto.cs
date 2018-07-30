namespace ServiceLogin.Dto
{
    public class SubprojectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdRH { get; set; }
        public int ClientId { get; set; }

        public int SiteId { get; set; }

        public bool Active { get; set; }

        public ClientDto Client { get; set; }
        public SiteDto Site { get; set; }
    }
}
