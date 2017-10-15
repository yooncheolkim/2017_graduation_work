using System;
using System.Runtime.InteropServices;

public class CAxtKeCAMCFS20
{
    /*------------------------------------------------------------------------------------------------*
        AXTCAMCFS Library - CAMC-FS 2.0이상 Motion module, 1차 함수군
        적용제품
            SMC-1V02 - CAMC-FS Ver2.0 이상 1축
            SMC-2V02 - CAMC-FS Ver2.0 이상 2축
    *------------------------------------------------------------------------------------------------*/

    // 사용 가능한 축번호인지를 확인한다
    [DllImport("AxtLib.dll")] public static extern int CFS20KeIsEnableAxis(short axis);

    // Port Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetPortData(short axis, FSPORT_DATA_WRITE pdwItem, byte wValue);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetPortData(short axis, FSPORT_DATA_READ pdrItem);

    // Command write
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetCommand(short axis, FSCOMMAND ccCommand);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetCommandData(short axis, FSCOMMAND ccCommand, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCommandData(short axis, FSCOMMAND ccCommand);
    
    // Data1/2/3/4 Write/Read
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetData1(short axis, byte byData);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetData2(short axis, byte byData);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetData3(short axis, byte byData);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetData4(short axis, byte byData);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetData1(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetData2(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetData3(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetData4(short axis);

    /// Range data
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetRangeData(short axis, ushort ulData);                // C:80
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetRangeData(short axis);                            // C:00

    /// Start/Stop Speed data
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetStartStopSpeedData(short axis, ushort wData);        // C:81
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetStartStopSpeedData(short axis);                    // C:01

    /// Object Speed data
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetObjectSpeedData(short axis, ushort wData);        // C:82
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetObjectSpeedData(short axis);                    // C:02

    /// Rate data 1/2/3
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetRate1Data(short axis, ushort ulData);                // C:83
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetRate1Data(short axis);                            // C:03
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetRate2Data(short axis, ushort ulData);                // C:84
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetRate2Data(short axis);                            // C:04
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetRate3Data(short axis, ushort ulData);                // C:85
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetRate3Data(short axis);                            // C:05

    /// RCP(Rate Change Point) 12/23
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetRateChangePoint12(short axis, ushort ulData);        // C:86
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetRateChangePoint12(short axis);                    // C:06
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetRateChangePoint23(short axis, ushort ulData);        // C:87
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetRateChangePoint23(short axis);                    // C:07

    /*
        //! 08 / 88
        [DllImport("AxtLib.dll")] public static extern int CFS20KeSetSW1Data(short axis, ushort wSW1);                // C:88
        [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetSW1Data(short axis);                        // C:08
        //! 09 / 89
        [DllImport("AxtLib.dll")] public static extern int CFS20KeSetSW2Data(short axis, ushort wSW2);                // C:89
        [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetSW2Data(short axis);                        // C:09
    */

    // Preset pulse drive
    [DllImport("AxtLib.dll")] public static extern void CFS20KePresetPulseDrive(short axis, 
                      ushort ulRange, ushort ulSTSPSpeedData, ushort ulObjectSpeedData,
                      ushort ulRate1Data, ushort ulRate2Data, ushort ulRate3Data,
                      ushort ulRCPoint12, ushort ulRCPoint23, int nTotalPulses);
    // Continous drive
    [DllImport("AxtLib.dll")] public static extern void CFS20KeContinuousDrive(short axis, 
                      ushort ulRange, ushort ulSTSPSpeedData, ushort ulObjectSpeedData,
                      ushort ulRate1Data, ushort ulRate2Data, ushort ulRate3Data,
                      ushort ulRCPoint12, ushort ulRCPoint23, MOVE_DIRECTION nDirection);
    // Signal search 1 drive
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSignalSearch1Drive(short axis, 
                      ushort ulRange, ushort ulSTSPSpeedData, ushort ulObjectSpeedData,
                      ushort ulRate1Data, ushort ulRate2Data, ushort ulRate3Data,
                      ushort ulRCPoint12, ushort ulRCPoint23, MOVE_DIRECTION nDirection);
    // Signal search 2 drive
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSignalSearch2Drive(short axis,
                      ushort ulRange, ushort ulSTSPSpeedData, MOVE_DIRECTION nDirection);

    // 2004.03.31 안병건 추가
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSensorPositioningDrive(short axis, 
                      ushort ulRange, ushort ulSTSPSpeedData, ushort ulObjectSpeedData,
                      ushort ulRate1Data, ushort ulRate2Data, ushort ulRate3Data,
                      ushort ulRCPoint12, ushort ulRCPoint23, int nTotalPulses, byte drive);
    
    //uint->double
    [DllImport("AxtLib.dll")] public static extern double CFS20KeGetCurrentSpeed(short axis);

    /// Universal Input/Output
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetUniversalSignal(short axis, ushort wState);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetUniversalSignal(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetUniversalSignalBit(short axis, FSUNIVERSAL_SIGNAL usBit, byte byState);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetUniversalSignalBit(short axis, FSUNIVERSAL_SIGNAL usBit);

    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetUniversalSignal2(short axis, ushort wState);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetUniversalSignal2(short axis);

    /// Motion status
    [DllImport("AxtLib.dll")] public static extern int CFS20KeInMotion(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFS20KeMotionDone(short axis);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeWaitForDone(short axis);

    /// Motion move
    [DllImport("AxtLib.dll")] public static extern int CFS20KeStartMove(short axis, double dDistance, double dVelocity, double dAcceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeMove(short axis, double dDistance, double dVelocity, double dAcceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20KeMoveToCW(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFS20KeMoveToCCW(short axis);
    
    /// Detect signal : Signal search 1/2
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetDetectSignal(short axis, byte signal);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetDetectSignal(short axis);                            //<+> 2002/12/06 JNS
    
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetSlowDownRearPulse(short axis, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetSlowDownRearPulse(short axis);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetCurrentSpeedData(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetPresetPulseDataOverride(short axis, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetPresetPulseData(short axis);
    [DllImport("AxtLib.dll")] public static extern short CFS20KeGetDeviationData(short axis);    //<*> 2002/12/06 JNS

    /// Inposition Enable/Disable
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetInpositionWaitMode(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeResetInpositionWaitMode(short axis);
    
    /// Alarm Enable/Disable
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetAlarmStopEnableMode(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeResetAlarmStopEnableMode(short axis);
    
    /// Interrupt out Enable/Disable
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetInterruptOutEnableMode(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeResetInterruptOutEnableMode(short axis);

    /// Motion stop
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSlowDownStop(short axis);                            // C:AB
    [DllImport("AxtLib.dll")] public static extern void CFS20KeEmergencyStop(short axis);                            // C:AC
    [DllImport("AxtLib.dll")] public static extern int CFS20KeSetSStop(short axis);        //$$ CFS20KeSlowDownStop()와 동일기능
    [DllImport("AxtLib.dll")] public static extern int CFS20KeSetEStop(short axis);        //$$ CFS20KeEmergencyStop()와 동일기능

    //<+> 2002/12/06 JNS
    // 가감속 모드를 설정한다
    [DllImport("AxtLib.dll")] public static extern int CFS20KeSetChipOperationSelect(short axis, byte bSelect);        // C:AD
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetChipOperationSelect(short axis);                    // C:2D    //<+>

    /// Internal counter
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetInternalCounter(short axis, int ulData);            // C:E0
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetInternalCounter(short axis);                        // C:60
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetInternalComparatorData(short axis, int ulData);    // C:E1
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetInternalComparatorData(short axis);                // C:61
    
    /// External counter
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetExternalCounter(short axis, int ulData);            // C:E4
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetExternalCounter(short axis);                        // C:64
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetExternalComparatorData(short axis, int ulData);    // C:E5
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetExternalComparatorData(short axis);                // C:65

    //<+> 2002/12/06 JNS
    /// Script
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScript1Event(short axis, uint data);                // C:C0
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetScript1Event(short axis);                            // C:40
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScript2Event(short axis, uint data);                // C:C1
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetScript2Event(short axis);                            // C:41
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScript3Event(short axis, uint data);                // C:C2
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetScript3Event(short axis);                            // C:42
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScriptQueueEvent(short axis, uint data);            // C:C3
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetScriptQueueEvent(short axis);                        // C:43
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScript1Data(short axis, uint data);                // C:C4
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetScript1Data(short axis);                            // C:44
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScript2Data(short axis, uint data);                // C:C5
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetScript2Data(short axis);                            // C:45
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScript3Data(short axis, uint data);                // C:C6
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetScript3Data(short axis);                            // C:46
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScriptQueueData(short axis, uint data);            // C:C7
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetScriptQueueData(short axis);                        // C:47
    [DllImport("AxtLib.dll")] public static extern void CFS20KeScriptQueueClear(short axis);                        // C:C8
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetScriptQueueEventIndex(short axis);                // C:49
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetScriptQueueDataIndex(short axis);                    // C:4A
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetScriptQueueFlag(short axis);                        // C:4B
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetScriptQueueSize(short axis, ushort data);            // C:CC
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetScriptQueueSize(short axis);                    // C:4C
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetScriptQueueStatus(short axis);                    // C:4D
    /// Caption
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetCaption1Event(short axis, uint data);                // C:D0
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCaption1Event(short axis);                        // C:50
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetCaption2Event(short axis, uint data);                // C:D1
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCaption2Event(short axis);                        // C:51
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetCaption3Event(short axis, uint data);                // C:D2
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCaption3Event(short axis);                        // C:52
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetCaptionQueueEvent(short axis, uint data);            // C:D3
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCaptionQueueEvent(short axis);                    // C:53
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCaption1Data(short axis);                            // C:54
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCaption2Data(short axis);                            // C:55
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCaption3Data(short axis);                            // C:56
    [DllImport("AxtLib.dll")] public static extern uint CFS20KeGetCaptionQueueData(short axis);                        // C:57
    [DllImport("AxtLib.dll")] public static extern void CFS20KeCaptionQueueClear(short axis);                        // C:D8
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetCaptionQueueEventIndex(short axis);                // C:59
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetCaptionQueueDataIndex(short axis);                // C:5A
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetCaptionQueueFlag(short axis);                        // C:5B
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetCaptionQueueSize(short axis);                    // C:5C
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetCaptionQueueSize(short axis, ushort data);        // C:DC
    [DllImport("AxtLib.dll")] public static extern ushort CFS20KeGetCaptionQueueStatus(short axis);                    // C:5D

    //<+> 2002/12/06 JNS
    /// Script&Caption
    [DllImport("AxtLib.dll")] public static extern int CFS20KeSetScriptCaption(short axis, short sc, uint evnet, uint data);
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetScriptCaption(short axis, short sc, ref uint evnet, ref uint data);

    //<+> 2002/12/06 JNS, Soft limit
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetSoftLimitMode(short axis, byte mode);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetSoftLimitMode(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetSoftNLimitPosition(short axis, int lData);
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetSoftNLimitPosition(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetSoftPLimitPosition(short axis, int lData);
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetSoftPLimitPosition(short axis);

    //<+> 2002/12/06 JNS, MPG(Manual Pulse Generation)
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetMpgOperation(short axis, byte mode);
    [DllImport("AxtLib.dll")] public static extern byte CFS20KeGetMpgOperation(short axis);
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetMpgPresetPulseData(short axis, int lData);
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetMpgPresetPulseData(short axis);

    //<+> 2002/12/06 JNS, 대칭
    // 대칭, 가속율
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetOptimizeDriveData(short axis, double dStartStop, double  dVelocity, double  dAcceleration, 
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRate1, ref ushort pRateChange12);
    // 대칭, 가속시간
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetOptimizeDriveDataEx(short axis, double dStartStop, double dVelocity, double dAccelTime,
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRate1, ref ushort pRateChange12);
    // 속도오버라이드(mode=1), 대칭, 가속율
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetOptimizeSpeedData(byte mode, short axis, double dStartStopSpeed, double dVelocity, double dAcceleration,
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRate1, ref ushort pRateChange12);
    // 속도오버라이드(mode=1), 대칭, 가속시간
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetOptimizeSpeedDataEx(byte mode, short axis, double dStartStopSpeed, double dVelocity, double dAccelTime,
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRate1, ref ushort pRateChange12);

    //<+> 2002/12/06 JNS, 비대칭
    // 비대칭, 가속율
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetOptimizeDriveDataA(short axis, double dStartStop, double dVelocity, double dAcceleration, double dDeceleration, 
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRateAccel, ref ushort pRateDecel, ref ushort pRateChange12);
    // 비대칭, 가속시간
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetOptimizeDriveDataAEx(short axis, double dStartStop, double dVelocity, double dAccelTime, double dDecelTime,
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRateAccel, ref ushort pRateDecel, ref ushort pRateChange12);
    // 속도오버라이드(mode=1), 비대칭, 가속율
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetOptimizeSpeedDataA(byte mode, short axis, double dStartStopSpeed, double dVelocity, double dAcceleration, double dDeceleration, 
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRateAccel, ref ushort pRateDecel, ref ushort pRateChange12);
    // 속도오버라이드(mode=1), 비대칭, 가속시간
    [DllImport("AxtLib.dll")] public static extern int CFS20KeGetOptimizeSpeedDataAEx(byte mode, short axis, double dStartStopSpeed, double dVelocity, double dAccelTime, double dDecelTime, 
                      ref ushort pRangeData, ref ushort pStartStopSpeedData, ref ushort pObjectSpeedData, ref ushort pRateAccel, ref ushort pRateDecel, ref ushort pRateChange12);

    //<+> gun5, 축 기준으로 레지스터를 읽는 함수
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_board_reg_byte(short axis, uint offset);

}