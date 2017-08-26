using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKA
{

    public class KataMove
    {
        public int ObjectID { get; set; }
        public string KataID { get; set; }
        public int OrderNumber { get; set; }
        public string SourceSide { get; set; }
        public string ActionType { get; set; }
        public string SourcePart { get; set; }
        public string TransitionText { get; set; }
        public string DestSide { get; set; }
        public string DestPart { get; set; }
        public int isSeries { get; set; }
        public int isContinued { get; set; }
        public string SpecialText { get; set; }
        public bool HiddenMove { get; set; }
        public override string ToString()
        {
            string ret = "";
            ret += isSeries > 0 ? "Series of " : "";
            ret += SourceSide.Trim().Length > 0 ? SourceSide.ToLower() + " " : "";
            ret += ActionType.Trim().Length > 0 ? ActionType.ToLower() + " " : "";
            ret += SourcePart.Trim().Length > 0 ? SourcePart.ToLower() + " " : "";
            ret += TransitionText.Trim().Length > 0 ? TransitionText.ToLower() + " " : "";
            ret += DestSide.Trim().Length > 0 ? DestSide.ToLower() + " " : "";
            ret += DestPart.Trim().Length > 0 ? DestPart.ToLower() + " " : "";
            ret += SpecialText.Trim().Length > 0 ? SpecialText.ToLower() + " " : "";
            return ret;
        }
    }
}
