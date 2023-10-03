﻿namespace CleanArchitecture.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }

    public User()
    {
        Email = string.Empty;
    }
}