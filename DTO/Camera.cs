namespace DTO
{
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public Model Model { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string StaticImageUrl => $"http://{IPAddress}{Model.StaticImageUrl}";
        public string OpenLensUrl => $"http://{IPAddress}{Model.OpenLensUrl}";
        public string CloseLensUrl => $"http://{IPAddress}{Model.CloseLensUrl}";
    }
}