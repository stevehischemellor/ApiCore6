namespace BusinessCore6
{
    public interface ISectionService
    {
        public Task<Section> ReadAsync(int id);
    }

    public class SectionService : ISectionService
    {
        public Task<Section> ReadAsync(int id)
        {
            return Task.FromResult(new Section { Name = "One" });
        }
    }

    public class Section
    { 
        public string? Name { get; set; }
    }
}
