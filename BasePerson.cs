using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_8_Tasks_2_3
{
    public interface BasePerson
    {
        string Name { get; set; }   
        string Surname {  get; set; }
        int Age {  get; set; }
        char? Gender { get; set; }
    }
}
