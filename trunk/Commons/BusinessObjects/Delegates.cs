using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons.BusinessObjects
{
    public delegate void EmptyEventHandler();
    public delegate void ActionEventHandler(object sender);
    public delegate void ActionEventHandler<T>(object sender, T parameter);
    public delegate void ActionEventHandler<T1, T2>(object sender, T1 parameter1, T2 parameter2);
    public delegate void ActionEventHandler<T1, T2, T3>(object sender, T1 parameter1, T2 parameter2, T3 parameter3);
}
