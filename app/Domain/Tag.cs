using app.Data.Repositories.Base;
using app.Domain.Base;

namespace app.Domain;
public class Tag : Entity<Guid>
{
    public string Name { get; private set; }
    public Article[]? Articles { get; set; }

    private Tag(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static async Task<Tag> CreateAsync(string name, IRepository<Tag,Guid> repository)
    {
        var exist = await repository.ExistsAsync(t => t.Name == name);
        if(exist)
        {
            throw new Exception("Tag already exists");
        }

        return new Tag(Guid.NewGuid(), name);
    }
}
