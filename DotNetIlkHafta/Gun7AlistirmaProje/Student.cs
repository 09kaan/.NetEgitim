public class Student
{
    public string Name { get; }
    public int Grade { get; private set; }

    public Student(string name, int grade)
    {
        // name boş veya yalnızca boşluklardan oluşuyorsa
        // ArgumentException fırlat.
        if (string.IsNullOrWhiteSpace(name) )
        {
            throw new ArgumentException(
                "Öğrenci adı boş olamaz."
            );
        }

        // grade 0'dan küçük veya 100'den büyükse
        // ArgumentException fırlat.
        if (grade < 0 || grade > 100)
        {
            throw new ArgumentException(
                "Not 0–100 aralığında olmalıdır."
            );
        }

        Name = name;
        Grade = grade;
    }
}

