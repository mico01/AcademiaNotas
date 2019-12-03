using System;
using System.Collections.Generic;
using System.Text;

namespace Academia.Model
{
    public class Examen : Entity
    {
        public DateTime DateStamp { get; set; }

        public Materia Subject { get; set; }

        public Student Student { get; set; }
    }
}
