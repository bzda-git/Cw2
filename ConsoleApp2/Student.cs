namespace ConsoleApp2
{
    public class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string index { get; set; }
        public string studies { get; set; }
        public string tryb { get; set; }
        public string dataUrodzienia { get; set; }
        public string mail { get; set; }
        public string momName { get; set; }
        public string dadName { get; set; }

        public override string ToString()
        {
            return " Index=[" + index +
                "] fName=[" + firstName +
                "] lName=[" + lastName +
                "] studies=[" + studies +
                "] tryb=[" + tryb +
                "] dataUrodzenia=[" + dataUrodzienia +
                "] mail=[" + mail +
                "] FName=[" + momName +
                "] LName=[" + dadName + "]";
        }

        
    }
}