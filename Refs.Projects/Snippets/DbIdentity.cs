[Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int Id { get; set; }

modelBuilder.HasSequence("CyclicalCountByThree")
  .StartsAt(6)
  .IncrementsBy(3)
  .HasMin(0)
  .HasMax(27)
  .IsCyclic();
---------------------




















