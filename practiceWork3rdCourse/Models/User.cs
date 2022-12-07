﻿using Microsoft.AspNetCore.Identity;

namespace practiceWork3rdCourse.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}