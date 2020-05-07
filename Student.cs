namespace Dom
{
    public class Student
    {
        int _id;
        string _firstName;
        string _lastName;
        int _semester;
        string _mayor;

        public Student(int id, string firstname, string lastName, int semester, string mayor)
        {
            _id = id;
            _firstName = firstname;
            _lastName = lastName;
            _semester = semester;
            _mayor = mayor;
        }

        public override string ToString()
        {
            return $"{_id,15} {_firstName,10} {_lastName,10} {_semester,5} {new string(' ',3)}semester of {_mayor,15}";
        }
    }
}