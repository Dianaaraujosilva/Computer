namespace LabManager.Models;

class Lab
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public char Block { get; set; }

    public Lab() { }

    public Lab(int id, int number, string name, char block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }  
}
