using Academia.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academia.Model
{
    public class Student : User
    {
        public string Dni { get; set; }
        public string Name { get; set; }

        public List<double> Notas { get; set; }

        public static Dictionary<string, Student> StudentsByDni { get; set; } = new Dictionary<string, Student>();
        
        
        public static bool ValidateDni(string dni)
        {
            return !string.IsNullOrEmpty(dni);
        }

      

        public static bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }

       public bool Save()
        {
            var validation = ValidateDni(this.Dni);
            if (!validation)
                return false;

            validation = ValidateName(this.Name);
            if (!validation)
                return false;

            if (this.Id == Guid.Empty)
            {
                DbContext.AddStudent(this);
            }
            else
            {
                DbContext.UpdateStudent(this);
            }

            return true;
            
        }
    
    }

}
