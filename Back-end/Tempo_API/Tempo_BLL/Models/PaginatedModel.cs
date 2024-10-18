namespace Tempo_BLL.Models;

public class PaginatedModel<Model> where Model : BaseModel
{
    public int? Total { get; set; }
    public int? Page { get; set; }
    public int? PageCount { get; set; }
    public int? PageSize { get; set; }
    public List<Model>? Items { get; set; }
}
