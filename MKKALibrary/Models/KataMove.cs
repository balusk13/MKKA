using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKALibrary.Models
{

    enum SideEnum { noSide, leftSide, rightSide};
    enum OtherSideEnum { noOtherSide}
    enum AttackEnum { knuckle, frontkick}
    enum PartEnum { throat, shin, groin, stomach, }
    class KataMove
    {
        SideEnum SourceSide;
        AttackEnum SourcePart;
        ActionEnum Action;
        SideEnum DestSide;
        PartEnum DestPart;
        public string special;
        bool PartOfNextMove; 

    }
}
