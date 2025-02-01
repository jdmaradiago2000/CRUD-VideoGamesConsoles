namespace CRUD_VideoGamesConsoles.DTOs
{
    public class GameConsoleDto
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public int BrandID { get; set; }
        public decimal Teraflops { get; set; }
    }
}
