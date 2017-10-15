using System;
using System.Runtime.InteropServices;

public class CAxtCAMCFS20KDNS
{
    /*------------------------------------------------------------------------------------------------*
        AXTCAMCFS Library - CAMC-FS 2.0�̻� Motion module => KDNS���� PLD�� �����
        ������ǰ
            SMC-1V02 - CAMC-FS Ver2.0 �̻� 1��
            SMC-2V02 - CAMC-FS Ver2.0 �̻� 2��
    *------------------------------------------------------------------------------------------------*/

    //<+> 2002/12/10 gun5, �ܺ� limit ó��(PLD) CAMCFS 2.0���� +,-������ limit�� enable/disable �Ҽ� ���� PLD���� ó���Ѵ�.
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