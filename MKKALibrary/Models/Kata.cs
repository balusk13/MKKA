using MKKA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKA
{
    public class Kata
    {
        public Kata(string id)
        {
            Name = id;
            DBAccessor db = new DBAccessor();
            int size = db.GetKataSize(id);
            for(int i = 1; i <= size; ++i)
            {
                moves.Add(db.GetKataMove(Name, i));
            }
        }
        public string Name { get; set; }
        List<KataMove> moves { get;}
        public int GetSize()
        {
            return moves.Count;
        }

    }
}
