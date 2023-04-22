﻿using System.ComponentModel.DataAnnotations;

namespace BlogSN.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IList<Post> Posts { get; set; }

}