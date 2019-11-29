namespace CourseProject
{
    class Checker
    {

        public Checker() { }

        public bool IsCorrectMark(string input)
        {
            input = input.ToLower();
            if (input.Equals("н"))
            {
                return true;
            }
            for (int i = 1; i <= 10; i++)
            {
                if (input == i.ToString())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
