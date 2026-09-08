List<Student> students = new()
{
    new Student("Kaan", 75),
    new Student("Ayşe", 45),
    new Student("Deniz", 90),
    new Student("Ege", 60)
};

List<Student> successfulStudents = students
    .Where(student => student.Grade >= 50)
    .OrderByDescending(student => student.Grade)
    .ToList();

Console.WriteLine("\n--- Başarılı Öğrenciler ---");

foreach (Student student in successfulStudents)
{
    Console.WriteLine(
        $"{student.Name} — Not: {student.Grade}"
    );
}
// Bütün öğrencilerin not ortalamasını hesapla.
double averageGrade = students.Average(
    student => student.Grade
);

// Öğrencileri notlarına göre yüksekten düşüğe sırala
// ve ilk öğrenciyi seç.
Student topStudent = students
    .OrderByDescending(student => student.Grade)
    .First();

Console.WriteLine(
    $"\nSınıf ortalaması: {averageGrade}"
);

Console.WriteLine(
    $"En yüksek not: {topStudent.Name} — " +
    $"{topStudent.Grade}"
);