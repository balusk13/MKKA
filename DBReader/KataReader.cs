using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBReader
{
    [PrimaryKey, AutoIncrement]
    class KataMoveReader
    {
        public string KataID { get; set; }
        public int OrderNumber { get; set; }
        public string SourceSide { get; set; }
        public string SourcePart { get; set; }
        public string Action { get; set; }
        public string DestSide { get; set; }
        public string DestPart { get; set; }
        public string special { get; set; }
        public bool PartOfNextMove { get; set; }
        public override string ToString()
        {
            return string.Format("[KataMove: KataID={0}, OrderNumber={1}, SourceSide={2}]", KataID, OrderNumber, SourceSide);
        }
    }
}