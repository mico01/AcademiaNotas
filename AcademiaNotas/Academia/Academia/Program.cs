using Academia.Context;
using Academia.Model;
using System;
using System.Collections.Generic;

namespace Academia
{
    class Program
    {
        static string CurrentOption { get; set; }

      

        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Bienvenidos a mi Academia");
            Console.WriteLine("-------------------------");
            ShowMainMenu();

            while (true)
            {
                var option = Console.ReadKey().KeyChar;

                if (option == '*')
                {
                    LimpiaLinea();
                    if (CurrentOption != "m")
                    {
                        Console.WriteLine();
                        ShowMainMenu();
                    }
                }
                else if (option == 'a')
                {
                    LimpiaLinea();
                    if (CurrentOption != "a")
                    {
                        Console.WriteLine();
                        MenuGestionAlumno();
                    }
                }
                else if (option == 'n')
                {
                    LimpiaLinea();
                    if (CurrentOption != "n")
                    {
                        Console.WriteLine();
                        ShowAddNotesMenu();
                    }
                }
                else if (option == 'c')
                {
                    LimpiaLinea();
                    if (CurrentOption != "c")
                    {
                        Console.WriteLine();
                        ShowStatisticsMenu();
                    }
                }
            }
        }

        public static void LimpiaLinea()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void ShowMainMenu()
        {
            CurrentOption = "m";
            Console.WriteLine("Menu de opciones principal");

            Console.WriteLine("Opciones: m - para volver a este menu");
            Console.WriteLine("Opciones: a - menu gestion alumno");
            Console.WriteLine("Opciones: c - Estadísticas");
        }

        

        static void ShowAddNotesMenu()
        {
            CurrentOption = "n";
            Console.WriteLine("Menu de añadir notas. Añada notas [dni+nombre+nota] y presione al enter");
            Console.WriteLine("Presione m para acabar y volver al menú principal");

            while (true)
            {
                var notaText = Console.ReadLine();

                if (notaText == "m")
                {
                    break;
                }
                else
                {
                    char[] c1 = { '+' };
                    var spaso = notaText.Split(c1);

                    var dni = spaso[0];
                    var name = spaso[1];
                    var nota = spaso[2].Replace(".", ",");
                    Console.WriteLine(dni + name + nota);
                    #region Dni
                    #endregion


                    #region Nota
                    //double nota;
                    //if (double.TryParse(markText, out nota))
                    //{
                    //    if (!Marks.ContainsKey(dni))
                    //        Marks.Add(dni, new List<double>());

                    //    Marks[dni].Add(nota);
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"valor introducidio [{notaText}] no válido");
                    //}
                    #endregion

                    #region Name

                    //if (!Students.ContainsKey(dni))
                    //    Students.Add(dni, name);
                    //else if(!string.IsNullOrEmpty(name))
                    ////else if (name != "" && name != null)
                    //    Students[dni] = name;

                    #endregion



                }
            }

            LimpiaLinea();
            Console.WriteLine();
            ShowMainMenu();
        }

        static void ShowStatisticsMenu()
        {
            CurrentOption = "c";

            Console.WriteLine("Opción de Estadísticas");
            Console.WriteLine("Presione m para acabar y volver al menú principal");
            Console.WriteLine("Opciones: avg - obtener la media de las notas de los alumnos");
            Console.WriteLine("Opciones: max - obtener la máxima nota de los alumnos");
            Console.WriteLine("Opciones: max - obtener la mínima nota de los alumnos");

            while (true)
            {
                var optionText = Console.ReadLine();

                if (optionText == "m")
                {
                    break;
                }
                else if (optionText == "avg")
                {
                    //ShowAverage();
                }
            }

            LimpiaLinea();
            Console.WriteLine();
            ShowMainMenu();
        }

        static void MenuGestionAlumno()
        {
            CurrentOption = "a";
            Console.WriteLine("Menu de gestionar alumnos.");
            Console.WriteLine("Opciones: 1 - para añadir un nuevo almuno");
            Console.WriteLine("Opciones: 2 - para editar un alumno existente");
            Console.WriteLine("Opciones: 3 - ver información del alumno");
            Console.WriteLine("Opciones: 4 - ver exámenes de alumno");
            Console.WriteLine("Opciones: 5 - ver estadisticas de alumno");
            Console.WriteLine("Presione m para acabar y volver al menú principal");

            while (true)
            {
                var option = Console.ReadLine();

                if (option == "m")
                {
                    break;
                }
                else if (option == "1")
                {
                    Console.WriteLine("Para volver sin guardar alumno escriba  *.");
                    Console.WriteLine("escriba el dni:");

                    #region read dni
                    var dni = Console.ReadLine();

                    if (dni == "*")
                        break;

                    while (!Student.ValidateDni(dni))
                    {
                        Console.WriteLine("el dni está en formato incorrecto, vuelva a escribirlo");
                        dni = Console.ReadLine();
                    }
                    
                    while (DbContext.StudentsByDni.ContainsKey(dni))
                    {
                        Console.WriteLine("ya existe un alumno con ese dni");
                        dni = Console.ReadLine();

                        if (dni == "*")
                            break;
                    }
                    

                    if (dni == "*")
                        break;

                    #endregion

                    #region read name
                    Console.WriteLine("escriba el nombre y apellidos:");
                    var name = Console.ReadLine();

                    if (name == "*")
                        break;

                    while (!Student.ValidateName(name))
                    {
                        Console.WriteLine("el nombre está en formato incorrecto, vuelva a escribirlo");
                        name = Console.ReadLine();
                    }

                    #endregion

                    var student = new Student
                    {
                        Dni = dni,
                        Name = name
                    };

                    if (student.Save())
                    {
                        Console.WriteLine($"alumno guardado correctamente");
                        Console.WriteLine("---"+student.Id + student.Dni + " " + student.Name);
                    }
                    else
                    {
                        Console.WriteLine($"uno o más errores han ocurrido y el almuno no se guardado correctamente");
                    }
                    
                }


                if (option == "m")
                {
                    break;
                }
                else if (option == "2")
                {
                    Console.WriteLine("---Menu editar estudiante---");
                    Console.WriteLine("Escribir nombre estudiante: ");
                }

                if (option == "m")
                {
                    break;
                }
                else if (option == "3")
                {
                    Console.WriteLine("---Menu info estudiante---");
                    Console.WriteLine("Escribir nombre estudiante: ");
                }

                if (option == "m")
                {
                    break;
                }
                else if (option == "4")
                {
                    Console.WriteLine("---Menu notas estudiante---");
                    Console.WriteLine("Escribir nombre estudiante: ");
                }

                if (option == "m")
                {
                    break;
                }
                else if (option == "5")
                {
                    Console.WriteLine("---Menu estadistica estudiante---");
                    Console.WriteLine("Escribir nombre estudiante: ");
                }
            }

            LimpiaLinea();
            Console.WriteLine();
            ShowMainMenu();
        }


    }
}
