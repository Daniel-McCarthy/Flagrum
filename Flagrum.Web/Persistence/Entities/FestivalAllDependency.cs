﻿using System.ComponentModel.DataAnnotations;

namespace Flagrum.Web.Persistence.Entities;

public class FestivalAllDependency
{
    [Key] public int Id { get; set; }

    public string Uri { get; set; }
}