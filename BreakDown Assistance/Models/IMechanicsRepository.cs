using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public interface IMechanicsRepository
    {
        Mechanics GetMechanics(int Id);
        IEnumerable<Mechanics> GetAllMechanics();
        Mechanics Add(Mechanics mechanic);
        Mechanics Update(Mechanics mechanicChanges);
        Mechanics Delete(int id);
    }
}
