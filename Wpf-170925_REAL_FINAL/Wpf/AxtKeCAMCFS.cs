using System;
using System.Runtime.InteropServices;

public class CAxtKeCAMCFS
{
    /*------------------------------------------------------------------------------------------------*
        AXTCAMCFS Library - CAMC-FS 1.0 Motion module, 1�� �Լ���
        ������ǰ
            SMC-1V02 - CAMC-FS Ver2.0 �̻� 1��
            SMC-2V02 - CAMC-FS Ver2.0 �̻� 2��
    *------------------------------------------------------------------------------------------------*/

    // ��� ������ ���ȣ������ Ȯ���Ѵ�
    [DllImport("AxtLib.dll")] public static extern int CFSKeIsEnableAxis(short axis);
    
    // Port Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetPortData(short axis, FSPORT_DATA_WRITE pdwItem, byte wValue);
    [DllImport("AxtLib.dll")] public static extern byte CFSKeGetPortData(short axis, FSPORT_DATA_READ pdrItem);

    // Command write
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetCommand(short axis, FSCOMMAND ccCommand);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetCommandData(short axis, FSCOMMAND ccCommand, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFSKeGetCommandData(short axis, FSCOMMAND ccCommand);

    // Data1/2/3/4 Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetData1(short axis, byte byData);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetData2(short axis, byte byData);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetData3(short axis, byte byData);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetData4(short axis, byte byData);
    [DllImport("AxtLib.dll")] public static extern byte CFSKeGetData1(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSKeGetData2(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSKeGetData3(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSKeGetData4(short axis);

    // Preset pulse drive : ���� �޽��� ����
    [DllImport("AxtLib.dll")] public static extern void CFSKePresetPulseDrive(short axis, 
                      ushort ulRange, ushort ulSTSPSpeedData, ushort ulObjectSpeedData,
                      ushort ulRate1Data, ushort ulRate2Data, ushort ulRate3Data,
                      ushort ulRCPoint12, ushort ulRCPoint23, int nTotalPulses);
    // Continous drive : ���� ���� ����
    [DllImport("AxtLib.dll")] public static extern void CFSKeContinuousDrive(short axis, 
                      ushort ulRange, ushort ulSTSPSpeedData, ushort ulObjectSpeedData,
                      ushort ulRate1Data, ushort ulRate2Data, ushort ulRate3Data,
                      ushort ulRCPoint12, ushort ulRCPoint23, MOVE_DIRECTION nDirection);
    // Signal search 1 drive : ��ȣ ����-1 ���� 
    [DllImport("AxtLib.dll")] public static extern void CFSKeSignalSearch1Drive(short axis, 
                      ushort ulRange, ushort ulSTSPSpeedData, ushort ulObjectSpeedData,
                      ushort ulRate1Data, ushort ulRate2Data, ushort ulRate3Data,
                      ushort ulRCPoint12, ushort ulRCPoint23, MOVE_DIRECTION nDirection);
    // Signal search 2 drive : ��ȣ ����-2 ���� 
    [DllImport("AxtLib.dll")] public static extern void CFSKeSignalSearch2Drive(short axis, 
                      ushort ulRange, ushort ulSTSPSpeedData, MOVE_DIRECTION nDirection);

    // ���� �ӵ��� ?
    //uint->double
    [DllImport("AxtLib.dll")] public static extern double CFSKeGetCurrentSpeed(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSKeGetUniversalSignal(short axis);

    // ���� ����
    [DllImport("AxtLib.dll")] public static extern int CFSKeInMotion(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFSKeMotionDone(short axis);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeWaitForDone(short axis);
    
    [DllImport("AxtLib.dll")] public static extern int CFSKeStartMove(short axis, double dDistance, double dVelocity, double dAcceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeMove(short axis, double dDistance, double dVelocity, double dAcceleration);
    
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetDetectSignal(short axis, byte signal);
    [DllImport("AxtLib.dll")] public static extern byte CFSKeGetDetectSignal(short axis);    //<+> 2002/12/06 JNS
    
    [DllImport("AxtLib.dll")] public static extern int CFSKeMoveToCW(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFSKeMoveToCCW(short axis);
    
    [DllImport("AxtLib.dll")] public static extern int CFSKeSetSStop(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFSKeSetEStop(short axis);
    
    // Rage data Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetRangeData(short axis, ushort ulData);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetRangeData(short axis);

    // Start/stop speed data Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetStartStopSpeedData(short axis, ushort ulData);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetStartStopSpeedData(short axis);
    
    // Object speed data Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetObjectSpeedData(short axis, ushort ulData);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetObjectSpeedData(short axis);

    // Rate 1/2/3 Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetRate1Data(short axis, ushort ulData);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetRate1Data(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetRate2Data(short axis, ushort ulData);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetRate2Data(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetRate3Data(short axis, ushort ulData);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetRate3Data(short axis);

    // Rate change point 12/23 Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetRateChangePoint12(short axis, ushort ulData);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetRateChangePoint12(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetRateChangePoint23(short axis, ushort ulData);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetRateChangePoint23(short axis);

    [DllImport("AxtLib.dll")] public static extern void CFSKeSetSlowDownRearPulse(short axis, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFSKeGetSlowDownRearPulse(short axis);
    [DllImport("AxtLib.dll")] public static extern ushort CFSKeGetCurrentSpeedData(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetPresetPulseDataOverride(short axis, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFSKeGetPresetPulseData(short axis);
    [DllImport("AxtLib.dll")] public static extern short CFSKeGetDeviationData(short axis);    //<+> 2002/12/06 JNS

    // Inposition signal Enable/Disable
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetInpositionWaitMode(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeResetInpositionWaitMode(short axis);
    
    // Alarm signal Enable/Disable
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetAlarmStopEnableMode(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeResetAlarmStopEnableMode(short axis);
    
    // Interrupt out Enable/Disable
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetInterruptOutEnableMode(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeResetInterruptOutEnableMode(short axis);
    
    [DllImport("AxtLib.dll")] public static extern void CFSKeSlowDownStop(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeEmergencyStop(short axis);

    [DllImport("AxtLib.dll")] public static extern void CFSKeSetInternalCounter(short axis, int ulData);
    [DllImport("AxtLib.dll")] public static extern int CFSKeGetInternalCounter(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetInternalComparatorData(short axis, int ulData);
    [DllImport("AxtLib.dll")] public static extern int CFSKeGetInternalComparatorData(short axis);
    
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetExternalCounter(short axis, int ulData);
    [DllImport("AxtLib.dll")] public static extern int CFSKeGetExternalCounter(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetExternalComparatorData(short axis, int ulData);
    [DllImport("AxtLib.dll")] public static extern int CFSKeGetExternalComparatorData(short axis);

    //<+> 2002/12/06 JNS
    // ������ ��带 �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern int CFSKeSetChipOperationSelect(short axis, byte bSelect);
    /* -----------------------------------------------------------------
                axis    : ���ȣ
                bSelect : ������ ���
                    0(SYM_LINEAR)    = ��Ī ��ٸ���
                    1(ASYM_LINEAR)    = ���Ī ��ٸ���
                    2(SYM_CURVE)    = ��Ī ������(S-Curve)
                    3(ASYM_CURVE)    = ���Ī ������(S-Curve)
                ���ϰ�    : ���������� ������ �Ǹ� 1(TRUE)
                * CFSKePresetPulseDrive(), CFSKeContinuousDrive(), CFSKeSignalSearch1Drive()
                  �Լ��� �����ϱ� ���� ������ ��带 �����ؾ� �Ѵ�
            ----------------------------------------------------------------- */

    //<+> 2003/2/07 LSJ, ��Ī
    // ��Ī, ������
    [DllImport("AxtLib.dll")] public static extern int CFSKeGetOptimizeDriveData(short axis, double dStartStop, double  dVelocity, double  dAcceleration, 
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRate1, ref ushort pRateChange12);
    // ��Ī, ���ӽð�
    [DllImport("AxtLib.dll")] public static extern int CFSKeGetOptimizeDriveDataEx(short axis, double dStartStop, double dVelocity, double dAccelTime,
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRate1, ref ushort pRateChange12);
    // �ӵ��������̵�(mode=1), ��Ī, ������
    [DllImport("AxtLib.dll")] public static extern int CFSKeGetOptimizeSpeedData(byte mode, short axis, double dStartStopSpeed, double dVelocity, double dAcceleration,
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRate1, ref ushort pRateChange12);
    // �ӵ��������̵�(mode=1), ��Ī, ���ӽð�
    [DllImport("AxtLib.dll")] public static extern int CFSKeGetOptimizeSpeedDataEx(byte mode, short axis, double dStartStopSpeed, double dVelocity, double dAccelTime,
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRate1, ref ushort pRateChange12);
}