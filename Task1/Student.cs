namespace Practice.Labs;

public class Student:
    IEquatable<Student>
{
    private string? _name; // И
    private string? _lastName;// Ф
    private string? _middleName; // О

    private string? _group; // М[номер института]О-[номер группы][Б,М,А]-[год поступления]

    private string? _practiceCourse;

    public Student(
        string name,
        string lastName,
        string middleName,
        string group,
        string practiceCourse)
    {
        Name = name;
        LastName = lastName;
        MiddleName = middleName;
        Group = group;
        PracticeCourse = practiceCourse;
    }

    //конструктор
    public string Name
    {
        get { return _name; }

        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            else _name = value;
        }
    }


    // свойства
    public string LastName
    {
        get { return _lastName; }

        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            else _lastName = value;
        }
    }

    public string MiddleName
    {
        get { return _middleName; }

        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            else _middleName = value;
        }
    }

    public string Group
    {
        get { return _group; }

        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            else _group = value;
        }
    }

    //
    public string Course
    {
        get
        {
            return _group.Substring(4, 1);
        }
    }

    public string PracticeCourse
    {
        get { return _practiceCourse; }

        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            else _practiceCourse = value;
        }
    }



    //ПЕРЕОРПЕДЕЛЕНИЕ МЕТОДОВ

    //переопределение то стринг
    public override string ToString()
    {
        
        return $"[{_name} {_lastName} {_middleName}  " +
            $"Group: {_group}, " +
            $"Practice course: {_practiceCourse}. ]";
    }

    //переопределение гет хэш код
    public override int GetHashCode()
    {
        return (((_name.GetHashCode() * 11 + _lastName.GetHashCode() ) * 31
            + _middleName.GetHashCode() ) * 7 + _group.GetHashCode() ) * 3
            + _practiceCourse.GetHashCode();
    }



    //переопределение глубокого сравнения
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        if (obj is Student std) return Equals(std);

        return false;
    }

    //определение для глубокого сравнения
    public bool Equals(
        Student std)
    {
        if (std == null) return false;

        return _name.Equals(std._name)
            && _lastName.Equals(std._lastName)
            && _middleName.Equals(std._middleName)
            && _group.Equals(std._group)
            && _practiceCourse.Equals(std._practiceCourse);

    }


}