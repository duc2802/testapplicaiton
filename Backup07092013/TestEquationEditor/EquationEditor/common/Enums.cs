
namespace Editor
{
    public enum CommandType
    {
        None,
        Text, 
        ShowBox, HideBox, 
        SquareRoot, nRoot, 
        DivRegular, DivSlanted, DivHorizontal, 
        LeftBracket, RightBracket, LeftRightBracket,
        Sub, Super, SubAndSuper, SignComposite,
    }

    public enum DecorationType
    {
        Tilde, Hat, Parenthesis, Tortoise, RightArrow, LeftArrow, DoubleArrow, RightHarpoonUpBarb, LeftHarpoonUpBarb,
        RightHarpoonDownBarb, LeftHarpoonDownBarb, Bar, DoubleBar, StrikeThrough, Cross, RightCross, LeftCross,
    }

    public enum Position { None, Middle, Top, Bottom, Left, Right, Sub, Super, SubSuper, BottomTop, }

    public enum SignCompositeSymbol
    {
        Sum, Product, CoProduct, Intersection, Union, Integral, DoubleIntegral, TripleIntegral,
        ContourIntegral, SurfaceIntegral, VolumeIntegral, ClockContourIntegral, AntiClockContourIntegral
    }
  
    public enum IntegralType
    {
        Integral, DoubleIntegral, TripleIntegral, 
        ContourIntegral, 
        SurfaceIntegral,
        VolumeIntegral,
        ClockContourIntegral, 
        AntiClockContourIntegral,
    }

    public enum BracketSignType
    {
        LeftRound, RightRound, LeftCurly, RightCurly, LeftSquare, RightSquare, LeftAngle, RightAngle,
        LeftBar, RightBar, LeftSquareBar, RightSquareBar, LeftDoubleBar, RightDoubleBar, LeftCeiling, RightCeiling,
        LeftFloor, RightFloor,
    }

    public enum HorizontalBracketSignType
    {
       TopCurly, BottomCurly, ToSquare, BottomSquare,
    }
    
    //public enum SubSuperType { Sub = 0, Super = 1 }   

    public enum FontType
    {
        SystemDefault, STIXGeneral, STIXIntegralsD, STIXIntegralsSm, STIXNonUnicode, STIXSizeThreeSym, STIXSizeTwoSym, STIXVariants,
        STIXSizeFourSym, STIXIntegralsUpSm, STIXSizeOneSym, STIXIntegralsUpD, STIXIntegralsUp, STIXSizeFiveSym,
        Segoe, Arial
    }
}