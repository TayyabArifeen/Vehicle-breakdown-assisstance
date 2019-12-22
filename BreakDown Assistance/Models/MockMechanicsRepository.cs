using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class MockMechanicsRepository : IMechanicsRepository
    {
        private List<Mechanics> _mechanicList;
        public MockMechanicsRepository()
        {
            _mechanicList = new List<Mechanics>()
            {
                new Mechanics(){id=1,name="Nawaz",contact_Number=0512323451,availability="Yes"},
                new Mechanics(){id=2,name="Sheraz",contact_Number=0512323452,availability="Yes"},
                new Mechanics(){id=3,name="Andrew",contact_Number=0512323453,availability="Nil"}
        };
        }

        public Mechanics Add(Mechanics mechanic)
        {
            mechanic.id = _mechanicList.Max(m => m.id) + 1;
            _mechanicList.Add(mechanic);
            return mechanic;
        }

        public Mechanics Delete(int id)
        {
            Mechanics mechanic = _mechanicList.FirstOrDefault(m => m.id == id);
            if (mechanic != null)
            {
                _mechanicList.Remove(mechanic);
            }
            return mechanic;
        }

        public IEnumerable<Mechanics> GetAllMechanics()
        {
            throw new NotImplementedException();
        }

        public Mechanics GetMechanics(int Id)
        {
            return _mechanicList.FirstOrDefault(m => m.id == Id);
        }

        public Mechanics Update(Mechanics mechanicChanges)
        {
            Mechanics mechanic = _mechanicList.FirstOrDefault(m => m.id == mechanicChanges.id);
            if (mechanic != null)
            {
                mechanic.name = mechanicChanges.name;
                mechanic.contact_Number = mechanicChanges.contact_Number;
                mechanic.availability = mechanicChanges.availability;
            }
            return mechanic;
        }
    }
}
