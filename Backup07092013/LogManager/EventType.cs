using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogManager
{
    public enum EventTypeEnum
    {
        et_Administrative = 0x1,
        et_Internal = 0x1 << 1,
        et_Trades = 0x1 << 2,
        et_Orders = 0x1 << 3,
        et_Market_Data_Control = 0x1 << 4,
        et_Inside_Market = 0x1 << 5,
        et_Market_Depth = 0x1 << 6,
        et_Positions = 0x1 << 7,
        et_Accounts = 0x1 << 8,
        et_RSS_Feed = 0x1 << 9,
        et_RoboTrader = 0x1 << 10,
        et_RiskManager = 0x1 << 11,
        et_MarginCall = 0x1 << 12,
        et_AutoX = 0x1 << 13,
        et_Alert = 0x1 << 14,
        et_Performance = 0x1 << 15,
        et_RTDService = 0x1 << 16,
        et_Undefined = 0x1 << 31
    }
}
