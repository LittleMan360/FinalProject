public class TeamMember
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime Birthdate { get; set; }
    public string CollegeProgram { get; set; }
    public string YearInProgram { get; set; }
}

public class Hobby
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DifficultyLevel { get; set; }
    public string RequiredEquipment { get; set; }
}

public class FavoriteBreakfast
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public int Calories { get; set; }
    public bool IsVegetarian { get; set; }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Genre { get; set; }
}
