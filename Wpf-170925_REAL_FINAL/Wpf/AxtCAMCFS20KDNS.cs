using System;
using System.Runtime.InteropServices;

public class CAxtCAMCFS20KDNS
{
    /*------------------------------------------------------------------------------------------------*
        AXTCAMCFS Library - CAMC-FS 2.0이상 Motion module => KDNS전용 PLD에 적용됨
        적용제품
            SMC-1V02 - CAMC-FS Ver2.0 이상 1축
            SMC-2V02 - CAMC-FS Ver2.0 이상 2축
    *------------------------------------------------------------------------------------------------*/

    //<+> 2002/12/10 gun5, 외부 limit 처리(PLD) CAMCFS 2.0에서 +,-각각의 limit를 enable/disable 할수 없어 PLD에서 처리한다.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_ext_nelm_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_ext_nelm_level(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFS20set_ext_nelm_enable(short axis, short enable);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_ext_nelm_enable(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFS20set_ext_pelm_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_ext_pelm_level(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFS20set_ext_pelm_enable(short axis, short enable);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_ext_pelm_enable(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_ext_pelm_switch(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_ext_nelm_switch(short axis);
}