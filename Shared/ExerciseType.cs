﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Exercisediary.Shared;

/// <summary>
/// Exercise types, like swimming, jogging, etc.
/// </summary>
public partial class ExerciseType
{
    /// <summary>
    /// Auto generated UUID
    /// </summary>
    public Guid ExerciseTypeId { get; set; }

    public string ExerciseName { get; set; }
    [JsonIgnore]
    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}