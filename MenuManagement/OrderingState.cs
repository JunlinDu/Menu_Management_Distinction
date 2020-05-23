using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuManagement
{
    //<summary>
    // An enum stores all the states indicating the ordering state.
    // </summary>
    public enum OrderingState
    {
        ViewingMenu,
        ExitToPreviousLevel,
        OrderFinalized,
        UnidentifiedInput
    }
}
