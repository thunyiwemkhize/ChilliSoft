﻿namespace CleanArchitecture.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public User()
    {
        Email = string.Empty;
        Name = string.Empty;
        Surname = string.Empty;
    }
}