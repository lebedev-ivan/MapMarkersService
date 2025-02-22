﻿using System.ComponentModel.DataAnnotations;

public class Marker
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
