class Airplane
{
    private Wing wing;
    private Engine engine;
    private Chassis chassis;
    public string name;
    public string route = "маршрута нема";
    public Airplane(string name, Wing wing, Engine engine, Chassis chassis)
    {
        this.wing = wing;
        this.engine = engine;
        this.chassis = chassis;
        this.name = name;
    }
    public void Fly()
    {
        Console.WriteLine($"Лiтак {name} полетiв");
    }
    public void Route()
    {
        Console.WriteLine($"Маршрут: {route}");
    }
    public void SetRoute(string route)
    {
        this.route = route;
    }
    public override string ToString()
    {
        return $"\nНазва лiтаку: {name} \nКрила: {wing}\nДвигун: {engine}\nШасi: {chassis}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Airplane airplane = (Airplane)obj;

        return name == airplane.name &&
               route == airplane.route &&
               wing.Equals(airplane.wing) &&
               engine.Equals(airplane.engine) &&
               chassis.Equals(airplane.chassis);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, route, wing, engine, chassis);
    }
}
class Wing
{
    public double width;
    public double length;
    public Wing(double width, double length)
    {
        this.width = width;
        this.length = length;
    }
    public override string ToString()
    {
        return ($"Ширина крила - {width}м, довжина - {length}м");
    }
}
class Chassis
{
    public double radius;
    public double width;
    public Chassis(double radius, double width)
    {
        this.radius = radius;
        this.width = width;
    }
    public override string ToString()
    {
        return ($"Радiус колеса - {radius}м, ширина - {width}м");
    }
}
class Engine
{
    public int horsepower;
    public Engine(int horsepower)
    {
        this.horsepower = horsepower;
    }
    public override string ToString()
    {
        return ($"Потужнiсть двигуна - {horsepower} кс");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Wing wing = new Wing(5, 15);
        Chassis chassis = new Chassis(0.7, 0.26);
        Engine engine = new Engine(7800);
        Airplane airplane = new Airplane("Ан-158", wing, engine, chassis);
        airplane.SetRoute("Киiв - Стамбул");
        airplane.Fly();
        airplane.Route();
        Console.WriteLine(airplane);
        Console.WriteLine(airplane.GetHashCode());
    }
}