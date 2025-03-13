using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        // Crear el primer trabajo
        Job job1 = new Job
        {
            JobTitle = "Software Engineer",
            Company = "Microsoft",
            StartYear = 2019,
            EndYear = 2022
        };

        // Crear el segundo trabajo
        Job job2 = new Job
        {
            JobTitle = "Manager",
            Company = "Apple",
            StartYear = 2022,
            EndYear = 2023
        };

        // Crear el currículum
        Resume myResume = new Resume
        {
            Name = "Allison Rose"
        };

        // Agregar trabajos a la lista
        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        // Mostrar el currículum completo
        myResume.Display();
    }
}
