using System;
using System.Collections.Generic;

namespace BlockAction.Repository.Dtos.DataModel;

public partial class Userdatainfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Money { get; set; }

    public string? Tag { get; set; }

    public int Age { get; set; }
}
