using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor
{
    public static class SignCompositeFactory
    {
        public static EquationBase CreateEquation(EquationContainer equationParent, Position position, SignCompositeSymbol symbol)
        {
            EquationBase equation = null;
            switch (position)
            {
                case Position.None:
                    equation = new SignSimple(equationParent, symbol, false);
                    break;
                case Position.Bottom:
                    equation = new SignBottom(equationParent, symbol, false);
                    break;
                case Position.BottomTop:
                    equation = new SignBottomTop(equationParent, symbol, false);
                    break;
                case Position.Sub:
                    equation = new SignSub(equationParent, symbol, false);
                    break;
                case Position.SubSuper:
                    equation = new SignSubSuper(equationParent, symbol, false);
                    break;
            }
            return equation;
        }
    }
}
