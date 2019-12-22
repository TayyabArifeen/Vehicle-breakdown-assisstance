using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class SQLMechanicsRepository : IMechanicsRepository
    {
        private readonly AppDbContext context;

        

        public SQLMechanicsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Mechanics Add(Mechanics mechanic)
        {
            context.Mechanics.Add(mechanic);
            context.SaveChanges();
            return mechanic;
        }

        public Mechanics Delete(int id)
        {
            Mechanics mechanic = context.Mechanics.Find(id);
            if (mechanic != null)
            {
                context.Mechanics.Remove(mechanic);
                context.SaveChanges();
            }
            return mechanic;
        }

        public IEnumerable<Mechanics> GetAllMechanics()
        {
            return context.Mechanics;
        }

        public Mechanics GetMechanics(int Id)
        {
            return context.Mechanics.Find(Id);
        }

        public Mechanics Update(Mechanics mechanicChanges)
        {
            var mechanic = context.Mechanics.Attach(mechanicChanges);
            mechanic.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return mechanicChanges;
        }
    }
}
