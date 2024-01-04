using System;
using System.Collections.Generic;

namespace BlockAction.Repository.Dtos.DataModel;

public partial class Userfundetail
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AccountType { get; set; }

    public decimal BeforeBalance { get; set; }

    public decimal AfterBalance { get; set; }

    public DateOnly CreateTime { get; set; }

    public string? Summary { get; set; }

    public int? OperatorUserId { get; set; }

    public string? UserName { get; set; }
}
