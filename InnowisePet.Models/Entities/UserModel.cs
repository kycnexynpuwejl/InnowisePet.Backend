﻿namespace InnowisePet.Models.Entities;

public class UserModel
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
}