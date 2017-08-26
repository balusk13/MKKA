using MKKA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKA
{
    class Kata
    {
        Kata(string id)
        {
            DBAccessor db = new DBAccessor();
            int size = db.GetKataSize(id);
        }
        public string Name { get; set; }
        List<KataMove> moves { get;}
        public int GetSize()
        {
            return moves.Count;
        }

    }
}
