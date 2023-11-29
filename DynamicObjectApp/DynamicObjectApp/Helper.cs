namespace DynamicObjectApp
{
    public class Helper
    {
        public static Student AddStudent(Student student)
        {
            student.Name = student.Name + " Kaushru";
            student.Id = student.Id + 1;
            return student;
        }
    }
}
