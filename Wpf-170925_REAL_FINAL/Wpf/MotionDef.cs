using System;
using System.Runtime.InteropServices;

public enum SYNC_SET:uint
{
    SLAVE,
    MASTER
}

// CAMC-5M PORT_DATA 셋팅 - ADDRESS에 값을 쓰기 위한
public enum PORT_DATA_WRITE:uint
{
    Data1Write                                  = 0x00,
    Data2Write                                  = 0x01,
    Data3Write                                  = 0x02,
    Data4Write                                  = 0x03,
    CommandWrite                                = 0x04,
    Mode1Write                                  = 0x05,
    Mode2Write                                  = 0x06,
    UniversalSignalWrite                        = 0x07
}

// ADDRESS에 값 읽기
public enum PORT_DATA_READ
{
    Data1Read                                   = 0x00,
    Data2Read                                   = 0x01,
    Data3Read                                   = 0x02,
    Data4Read                                   = 0x03,
    DriveStatusRead                             = 0x04,
    EndStatusRead                               = 0x05,
    MechanicalSignalRead                        = 0x06,
    UniversalSignalRead                         = 0x07
}

// COMMAND LIST
public enum COMMAND:uint
{
    RangeDataWrite                              = 0x00,
    RangeDataRead                               = 0x01,
    StartStopSpeedDataWrite                     = 0x02,
    StartStopSpeedDataRead                      = 0x03,
    ObjectSpeedDataWrite                        = 0x04,
    ObjectSpeedDataRead                         = 0x05,
    Rate1DataWrite                              = 0x06,
    Rate1DataRead                               = 0x07,
    Rate2DataWrite                              = 0x08,
    Rate2DataRead                               = 0x09,
    Rate3DataWrite                              = 0x0a,
    Rate3DataRead                               = 0x0b,
    RateChangePoint12Write                      = 0x0c,
    RateChangePoint12Read                       = 0x0d,
    RateChangePoint23Write                      = 0x0e,
    RateChangePoint23Read                       = 0x0f,
    SlowDownRealPulseWrite                      = 0x10,
    SlowDownRealPulseRead                       = 0x11,
    CurrentSpeedDataRead                        = 0x12,
    DrivePulseCountRead                         = 0x13,
    PresetPulseDataOverride                     = 0x14,
    PresetPulseDataRead                         = 0x15,
    DeviationDataRead                           = 0x16,
    NoOperation                                 = 0x17,
    InpositionWaitModeSet                       = 0x18,
    InpositionWaitModeReset                     = 0x19,
    AlarmStopEnableModeSet                      = 0x1a,
    AlarmStopEnableModeReset                    = 0x1b,
    InterruptOutEnableModeSet                   = 0x1c,
    InterruptOutEnableModeReset                 = 0x1d,
    SlowDownStop                                = 0x1e,
    EmergencyStop                               = 0x1f,
    PresetPulseDriveP                           = 0x20,
    PresetPulseDriveN                           = 0x21,
    ContinuousDriveP                            = 0x22,
    ContinuousDriveN                            = 0x23,
    SignalSearch1DriveP                         = 0x24,
    SignalSearch1DriveN                         = 0x25,
    SignalSearch2DriveP                         = 0x26,
    SignalSearch2DriveN                         = 0x27,
    InternalCounterWrite                        = 0x28,
    InternalCounterRead                         = 0x29,
    InternalComparatorDataWrite                 = 0x2a,
    InternalComparatorDataRead                  = 0x2b,
    ExternalCounterWrite                        = 0x2c,
    ExternalCounterRead                         = 0x2d,
    ExternalComparatorDataWrite                 = 0x2e,
    ExternalComparatorDataRead                  = 0x2f
}

public enum VERSION:uint
{
    CAMC_5M_VERSION_10                          = 0x00,         // 5M Ver 1.0
    CAMC_5M_VERSION_30                          = 0x03,         // 5M Ver 3.0
}

public enum DIRECTION_SENSE:int
{
    POSITIVE_SENSE                              = 1,
    NEGATIVE_SENSE                              = -1
}

public enum UI_MODE:uint
{
    UI4                                         = 0,
    UI5                                         = 0,
    JOG                                         = 1,
    MARK                                        = 2
}

public enum SP_MODE:uint
{
    DRIVE1                                      = 1,
    DRIVE2                                      = 2,
    DRIVE3                                      = 3
}

public enum INPUT_METHOD:uint
{
    DIFF_INPUT,
    LEVEL_INPUT
}

// Main clock
public enum MAIN_CLOCK:uint
{
    F_33M_CLK                                   = 33000000,     // 33.000 MHz
    F_32_768M_CLK                               = 32768000,     // 32.768 MHz
    F_20M_CLK                                   = 20000000,     // 20.000 MHz
    F_16_384M_CLK                               = 16384000      // 16.384 MHz : Default
}

// 감속 개시 POINT 검출 방식
public enum DETECT_DOWN_START_POINT:uint
{
    AutoDetect,
    RestPulse
}

public enum PULSE_OUTPUT:uint
{
    OneHighLowHighm,                                            // 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
    OneHighHighLow,                                             // 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
    OneLowLowHigh,                                              // 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
    OneLowHighLow,                                              // 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
    TwoCcwCwHigh,                                               // 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High
    TwoCcwCwLow,                                                // 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low
    TwoCwCcwHigh,                                               // 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
    TwoCwCcwLow,                                                // 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
    TwoPhase                                                    // 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
}

public enum DETECT_DESTINATION_SIGNAL:uint
{
    PElmNegativeEdge,                                           // +Elm(End limit) 하강 edge
    NElmNegativeEdge,                                           // -Elm(End limit) 하강 edge
    PSlmNegativeEdge,                                           // +Slm(Slowdown limit) 하강 edge
    NSlmNegativeEdge,                                           // -Slm(Slowdown limit) 하강 edge
    In0DownEdge,                                                // IN0(ORG) 하강 edge
    In1DownEdge,                                                // IN1(Z상) 하강 edge
    In2DownEdge,                                                // IN2(범용) 하강 edge
    In3DownEdge,                                                // IN3(범용) 하강 edge
    PElmPositiveEdge,                                           // +Elm(End limit) 상승 edge
    NElmPositiveEdge,                                           // -Elm(End limit) 상승 edge
    PSlmPositiveEdge,                                           // +Slm(Slowdown limit) 상승 edge
    NSlmPositiveEdge,                                           // -Slm(Slowdown limit) 상승 edge
    In0UpEdge,                                                  // IN0(ORG) 상승 edge
    In1UpEdge,                                                  // IN1(Z상) 상승 edge
    In2UpEdge,                                                  // IN2(범용) 상승 edge
    In3UpEdge                                                   // IN3(범용) 상승 edge
}

public enum EXTERNAL_COUNTER_INPUT:uint
{
    UpDownMode,                                                 // Up/Down
    Sqr1Mode,                                                   // 1체배
    Sqr2Mode,                                                   // 2체배
    Sqr4Mode                                                    // 4체배
}

public enum INP_SIGNAL_ACTIVE_LEVEL:uint
{
    InpActiveLow,
    InpActiveHigh
}

public enum ALM_SIGNAL_ACTIVE_LEVEL:uint
{
    AlmActiveLow,
    AlmActiveHigh
}

public enum NSLM_SIGNAL_ACTIVE_LEVEL:uint
{
    NSlmActiveLow,
    NSlmActiveHigh
}

public enum PSLM_SIGNAL_ACTIVE_LEVEL:uint
{
    PSlmActiveLow,
    PSlmActiveHigh
}

public enum NELM_SIGNAL_ACTIVE_LEVEL:uint
{
    NElmActiveLow,
    NElmActiveHigh
}

public enum PELM_SIGNAL_ACTIVE_LEVEL:uint
{
    PElmActiveLow,
    PElmActiveHigh
}

// Universal Input/Output
public enum UNIVERSAL_SIGNAL:uint
{
    US_OUT0                                     = 0x01,
    US_OUT1                                     = 0x02,
    US_OUT2                                     = 0x04,
    US_OUT3                                     = 0x08,
    US_IN0                                      = 0x10,
    US_IN1                                      = 0x20,
    US_IN2                                      = 0x40,
    US_IN3                                      = 0x80
}

// BOARD SELECT
public enum BASE_ADDR:uint
{
    BOARD0_BASE_ADDR,
    BOARD1_BASE_ADDR,
    BOARD2_BASE_ADDR,
    BOARD3_BASE_ADDR,
    BOARD4_BASE_ADDR,
    BOARD5_BASE_ADDR,
    BOARD6_BASE_ADDR,
    BOARD7_BASE_ADDR
}

// CHIP SELECT
public enum CHIP_SELECT:uint
{
    CS_CAMC0,
    CS_CAMC1,
    CS_CAMC2,
    CS_CAMC3,
    CS_CAMC4,
    CS_CAMC5,
    CS_CAMC6,
    CS_CAMC7,
    CS_CAMC8,
    CS_CAMC9,
    CS_CAMC10,
    CS_CAMC11,
    CS_CAMC12,
    CS_CAMC13,
    CS_CAMC14,
    CS_CAMC15,
    CS_CAMC16,
    CS_CAMC17,
    CS_CAMC18,
    CS_CAMC19,
    CS_CAMC20,
    CS_CAMC21,
    CS_CAMC22,
    CS_CAMC23,
    CS_CAMC24,
    CS_CAMC25,
    CS_CAMC26,
    CS_CAMC27,
    CS_CAMC28,
    CS_CAMC29,
    CS_CAMC30,
    CS_CAMC31
}

// 이동방향
public enum MOVE_DIRECTION:int
{
    MoveLeft                                    = -1,
    MoveRight                                   = 1
}

public enum MPG_MODE:uint
{
    SLAVE_MODE                                  = 1,
    PRST_DRV_MODE                               = 2,
    CONT_DRV_MODE                               = 4
}



public enum FS_VERSION:uint
{
    CAMC_FS_VERSION_10                          = 0x00,         // FS Ver 1.0
    CAMC_FS_VERSION_20                          = 0x02,         // FS Ver 2.0
    CAMC_FS_VERSION_20_KDNS                     = 0x03,         // FS Ver 2.0 - for KDNS
    CAMC_FS_VERSION_21                          = 0x04,         // FS Ver 2.1
    CAMC_FS_VERSION_30                          = 0x05          // FS Ver 3.0
}

public enum IP_VERSION:uint
{
    CAMC_IP_VERSION_10                          = 0x11,         // IP Ver 1.0
    CAMC_IP_VERSION_20                          = 0x20,         // IP Ver 2.0
    CAMC_IP_VERSION_30                          = 0x30,         // IP Ver 3.0 // not exist yet(2003)
    CAMC_IP_VERSION_40                          = 0x40          // IP Ver 4.0 // not exist yet(2003)
}

// FS Write port
public enum FSPORT_DATA_WRITE:uint
{
    FsData1Write                                = 0x00,
    FsData2Write                                = 0x01,
    FsData3Write                                = 0x02,
    FsData4Write                                = 0x03,
    FsCommandWrite                              = 0x04
}

// IP Write port
public enum IPPORT_DATA_WRITE:uint
{
    IpData1Write                                = 0x00,
    IpData2Write                                = 0x01,
    IpData3Write                                = 0x02,
    IpData4Write                                = 0x03,
    IpCommandWrite                              = 0x04,
    IpCommonCommandWrite                        = 0x07
}

// FS Read port
public enum FSPORT_DATA_READ
{
    FsData1Read                                 = 0x00,
    FsData2Read                                 = 0x01,
    FsData3Read                                 = 0x02,
    FsData4Read                                 = 0x03,
    FsCommandRead                               = 0x04
}

// IP Read port
public enum IPPORT_DATA_READ
{
    IpData1Read                                 = 0x00,
    IpData2Read                                 = 0x01,
    IpData3Read                                 = 0x02,
    IpData4Read                                 = 0x03,
    IpCommandRead                               = 0x04,
    IpAxisStatusMSB                             = 0x05,
    IpAxisStatusLSB                             = 0x06,
    IpCommonAxisStatus                          = 0x07
}

// 5M End status : 0x0000이면 정상종료
public enum END_STATUS
{
    END_STATUS_SLM                              = 0x0001,       // Bit 0, limit 감속정지 신호 입력에 의한 종료
    END_STATUS_ELM                              = 0x0002,       // Bit 1, limit 급정지 신호 입력에 의한 종료
    END_STATUS_SSTOP_SIGNAL                     = 0x0004,       // Bit 2, 감속 정지 신호 입력에 의한 종료
    END_STATUS_ESTOP_SIGANL                     = 0x0008,       // Bit 3, 급정지 신호 입력에 의한 종료
    END_STATUS_SSTOP_COMMAND                    = 0x0010,       // Bit 4, 감속 정지 명령에 의한 종료
    END_STATUS_ESTOP_COMMAND                    = 0x0020,       // Bit 5, 급정지 정지 명령에 의한 종료
    END_STATUS_ALARM_SIGNAL                     = 0x0040,       // Bit 6, Alarm 신호 입력에 희한 종료
    END_STATUS_DATA_ERROR                       = 0x0080        // Bit 7, 데이터 설정 에러에 의한 종료
}

// FS End status : 0x0000이면 정상종료
public enum FS_END_STATUS
{
    FSEND_STATUS_SLM                            = 0x0001,       // Bit 0, limit 감속정지 신호 입력에 의한 종료
    FSEND_STATUS_ELM                            = 0x0002,       // Bit 1, limit 급정지 신호 입력에 의한 종료
    FSEND_STATUS_SSTOP_SIGNAL                   = 0x0004,       // Bit 2, 감속 정지 신호 입력에 의한 종료
    FSEND_STATUS_ESTOP_SIGANL                   = 0x0008,       // Bit 3, 급정지 신호 입력에 의한 종료
    FSEND_STATUS_SSTOP_COMMAND                  = 0x0010,       // Bit 4, 감속 정지 명령에 의한 종료
    FSEND_STATUS_ESTOP_COMMAND                  = 0x0020,       // Bit 5, 급정지 정지 명령에 의한 종료
    FSEND_STATUS_ALARM_SIGNAL                   = 0x0040,       // Bit 6, Alarm 신호 입력에 희한 종료
    FSEND_STATUS_DATA_ERROR                     = 0x0080,       // Bit 7, 데이터 설정 에러에 의한 종료

    //[V2.0이상]
    FSEND_STATUS_DEVIATION_ERROR                = 0x0100,       // Bit 8, 탈조 에러에 의한 종료
    FSEND_STATUS_ORIGIN_DETECT                  = 0x0200,       // Bit 9, 원점 검출에 의한 종료
    FSEND_STATUS_SIGNAL_DETECT                  = 0x0400,       // Bit 10, 신호 검출에 의한 종료(Signal search-1/2 drive 종료)
    FSEND_STATUS_PRESET_PULSE_DRIVE             = 0x0800,       // Bit 11, Preset pulse drive 종료
    FSEND_STATUS_SENSOR_PULSE_DRIVE             = 0x1000,       // Bit 12, Sensor pulse drive 종료
    FSEND_STATUS_LIMIT                          = 0x2000,       // Bit 13, Limit 완전정지에 의한 종료
    FSEND_STATUS_SOFTLIMIT                      = 0x4000        // Bit 14, Soft limit에 의한 종료
}

// IP End status : 0x0000이면 정상종료
public enum IP_END_STATUS:uint
{
    IPEND_STATUS_SLM                            = 0x0001,       // Bit 0, limit 감속정지 신호 입력에 의한 종료
    IPEND_STATUS_ELM                            = 0x0002,       // Bit 1, limit 급정지 신호 입력에 의한 종료
    IPEND_STATUS_SSTOP_SIGNAL                   = 0x0004,       // Bit 2, 감속 정지 신호 입력에 의한 종료
    IPEND_STATUS_ESTOP_SIGANL                   = 0x0008,       // Bit 3, 급정지 신호 입력에 의한 종료
    IPEND_STATUS_SSTOP_COMMAND                  = 0x0010,       // Bit 4, 감속 정지 명령에 의한 종료
    IPEND_STATUS_ESTOP_COMMAND                  = 0x0020,       // Bit 5, 급정지 정지 명령에 의한 종료
    IPEND_STATUS_ALARM_SIGNAL                   = 0x0040,       // Bit 6, Alarm 신호 입력에 희한 종료
    IPEND_STATUS_DATA_ERROR                     = 0x0080,       // Bit 7, 데이터 설정 에러에 의한 종료
    IPEND_STATUS_DEVIATION_ERROR                = 0x0100,       // Bit 8, 탈조 에러에 의한 종료
    IPEND_STATUS_ORIGIN_DETECT                  = 0x0200,       // Bit 9, 원점 검출에 의한 종료
    IPEND_STATUS_SIGNAL_DETECT                  = 0x0400,       // Bit 10, 신호 검출에 의한 종료(Signal search-1/2 drive 종료)
    IPEND_STATUS_PRESET_PULSE_DRIVE             = 0x0800,       // Bit 11, Preset pulse drive 종료
    IPEND_STATUS_SENSOR_PULSE_DRIVE             = 0x1000,       // Bit 12, Sensor pulse drive 종료
    IPEND_STATUS_LIMIT                          = 0x2000,       // Bit 13, Limit 완전정지에 의한 종료
    IPEND_STATUS_SOFTLIMIT                      = 0x4000,       // Bit 14, Soft limit에 의한 종료
    IPEND_STATUS_INTERPOLATION_DRIVE            = 0x8000        // Bit 15, Soft limit에 의한 종료
}

// 5M Drive status
public enum DRIVE_STATUS:uint
{
    DRIVE_STATUS_BUSY                           = 0x0001,       // Bit 0, BUSY(드라이브 구동 중)
    DRIVE_STATUS_DOWN                           = 0x0002,       // Bit 1, DOWN(감속 중)
    DRIVE_STATUS_CONST                          = 0x0004,       // Bit 2, CONST(등속 중)
    DRIVE_STATUS_UP                             = 0x0008,       // Bit 3, UP(가속 중)
    DRIVE_STATUS_ICL                            = 0x0010,       // Bit 4, ICL(내부 위치 카운터 < 내부 위치 카운터 비교값)
    DRIVE_STATUS_ICG                            = 0x0020,       // Bit 5, ICG(내부 위치 카운터 > 내부 위치 카운터 비교값)
    DRIVE_STATUS_ECL                            = 0x0040,       // Bit 6, ECL(외부 위치 카운터 < 외부 위치 카운터 비교값)
    DRIVE_STATUS_ECG                            = 0x0080        // Bit 7, ECG(외부 위치 카운터 > 외부 위치 카운터 비교값)
}

// FS Drive status
public enum FS_DRIVE_STATUS:uint
{
    FSDRIVE_STATUS_BUSY                         = 0x0001,       // Bit 0, BUSY(드라이브 구동 중)
    FSDRIVE_STATUS_DOWN                         = 0x0002,       // Bit 1, DOWN(감속 중)
    FSDRIVE_STATUS_CONST                        = 0x0004,       // Bit 2, CONST(등속 중)
    FSDRIVE_STATUS_UP                           = 0x0008,       // Bit 3, UP(가속 중)
    FSDRIVE_STATUS_ICL                          = 0x0010,       // Bit 4, ICL(내부 위치 카운터 < 내부 위치 카운터 비교값)
    FSDRIVE_STATUS_ICG                          = 0x0020,       // Bit 5, ICG(내부 위치 카운터 > 내부 위치 카운터 비교값)
    FSDRIVE_STATUS_ECL                          = 0x0040,       // Bit 6, ECL(외부 위치 카운터 < 외부 위치 카운터 비교값)
    FSDRIVE_STATUS_ECG                          = 0x0080,       // Bit 7, ECG(외부 위치 카운터 > 외부 위치 카운터 비교값)

    //[V2.0이상]
    FSDRIVE_STATUS_DEVIATION_ERROR              = 0x0100        // Bit 8, 드라이브 방향 신호(0=CW/1=CCW)
}

// IP Drive status
public enum IP_DRIVE_STATUS:uint
{
    IPDRIVE_STATUS_BUSY                         = 0x00001,      // Bit 0, BUSY(드라이브 구동 중)
    IPDRIVE_STATUS_DOWN                         = 0x00002,      // Bit 1, DOWN(감속 중)
    IPDRIVE_STATUS_CONST                        = 0x00004,      // Bit 2, CONST(등속 중)
    IPDRIVE_STATUS_UP                           = 0x00008,      // Bit 3, UP(가속 중)
    IPDRIVE_STATUS_ICL                          = 0x00010,      // Bit 4, ICL(내부 위치 카운터 < 내부 위치 카운터 비교값)
    IPDRIVE_STATUS_ICG                          = 0x00020,      // Bit 5, ICG(내부 위치 카운터 > 내부 위치 카운터 비교값)
    IPDRIVE_STATUS_ECL                          = 0x00040,      // Bit 6, ECL(외부 위치 카운터 < 외부 위치 카운터 비교값)
    IPDRIVE_STATUS_ECG                          = 0x00080,      // Bit 7, ECG(외부 위치 카운터 > 외부 위치 카운터 비교값)
    IPDRIVE_STATUS_DRIVE_DIRECTION              = 0x00100,      // Bit 8, 드라이브 방향 신호(0=CW/1=CCW)
    IPDRIVE_STATUS_COMMAND_BUSY                 = 0x00200,      // Bit 9, 명령어 수행중
    IPDRIVE_STATUS_PRESET_DRIVING               = 0x00400,      // Bit 10, Preset pulse drive 중
    IPDRIVE_STATUS_CONTINUOUS_DRIVING           = 0x00800,      // Bit 11, Continuouse speed drive 중
    IPDRIVE_STATUS_SIGNAL_SEARCH_DRIVING        = 0x01000,      // Bit 12, Signal search-1/2 drive 중
    IPDRIVE_STATUS_ORG_SEARCH_DRIVING           = 0x02000,      // Bit 13, 원점 검출 drive 중
    IPDRIVE_STATUS_MPG_DRIVING                  = 0x04000,      // Bit 14, MPG drive 중
    IPDRIVE_STATUS_SENSOR_DRIVING               = 0x08000,      // Bit 15, Sensor positioning drive 중
    IPDRIVE_STATUS_L_C_INTERPOLATION            = 0x10000,      // Bit 16, 직선/원호 보간 중
    IPDRIVE_STATUS_PATTERN_INTERPOLATION        = 0x20000,      // Bit 17, 비트 패턴 보간 중
    IPDRIVE_STATUS_INTERRUPT_BANK1              = 0x40000,      // Bit 18, 인터럽트 bank1에서 발생
    IPDRIVE_STATUS_INTERRUPT_BANK2              = 0x80000       // Bit 19, 인터럽트 bank2에서 발생
}

// 5M Mechanical signal
public enum MECHANICAL_SIGNAL:uint
{
    MECHANICAL_PELM_LEVEL                       = 0x0001,       // Bit 0, +Limit 급정지 신호 입력 Level
    MECHANICAL_NELM_LEVEL                       = 0x0002,       // Bit 1, -Limit 급정지 신호 입력 Level
    MECHANICAL_PSLM_LEVEL                       = 0x0004,       // Bit 2, +limit 감속정지 신호 입력 Level
    MECHANICAL_NSLM_LEVEL                       = 0x0008,       // Bit 3, -limit 감속정지 신호 입력 Level
    MECHANICAL_ALARM_LEVEL                      = 0x0010,       // Bit 4, Alarm 신호 입력 Level
    MECHANICAL_INP_LEVEL                        = 0x0020,       // Bit 5, Inposition 신호 입력 Level
    MECHANICAL_ENC_DOWN_LEVEL                   = 0x0040,       // Bit 6, 엔코더 DOWN(B상) 신호 입력 Level
    MECHANICAL_ENC_UP_LEVEL                     = 0x0080        // Bit 7, 엔코더 UP(A상) 신호 입력 Level
}

// FS Mechanical signal
public enum FS_MECHANICAL_SIGNAL:uint
{
    FSMECHANICAL_PELM_LEVEL                     = 0x0001,       // Bit 0, +Limit 급정지 신호 입력 Level
    FSMECHANICAL_NELM_LEVEL                     = 0x0002,       // Bit 1, -Limit 급정지 신호 입력 Level
    FSMECHANICAL_PSLM_LEVEL                     = 0x0004,       // Bit 2, +limit 감속정지 신호 입력 Level
    FSMECHANICAL_NSLM_LEVEL                     = 0x0008,       // Bit 3, -limit 감속정지 신호 입력 Level
    FSMECHANICAL_ALARM_LEVEL                    = 0x0010,       // Bit 4, Alarm 신호 입력 Level
    FSMECHANICAL_INP_LEVEL                      = 0x0020,       // Bit 5, Inposition 신호 입력 Level
    FSMECHANICAL_ENC_DOWN_LEVEL                 = 0x0040,       // Bit 6, 엔코더 DOWN(B상) 신호 입력 Level
    FSMECHANICAL_ENC_UP_LEVEL                   = 0x0080,       // Bit 7, 엔코더 UP(A상) 신호 입력 Level

    //[V2.0이상]
    FSMECHANICAL_EXMP_LEVEL                     = 0x0100,       // Bit 8, EXMP 신호 입력 Level
    FSMECHANICAL_EXPP_LEVEL                     = 0x0200,       // Bit 9, EXPP 신호 입력 Level
    FSMECHANICAL_MARK_LEVEL                     = 0x0400,       // Bit 10, MARK# 신호 입력 Level
    FSMECHANICAL_SSTOP_LEVEL                    = 0x0800,       // Bit 11, SSTOP 신호 입력 Level
    FSMECHANICAL_ESTOP_LEVEL                    = 0x1000,       // Bit 12, ESTOP 신호 입력 Level
}

// IP Mechanical signal
public enum IP_MECHANICAL_SIGNAL:uint
{
    IPMECHANICAL_PELM_LEVEL                     = 0x0001,       // Bit 0, +Limit 급정지 신호가 액티브 됨
    IPMECHANICAL_NELM_LEVEL                     = 0x0002,       // Bit 1, -Limit 급정지 신호 액티브 됨
    IPMECHANICAL_PSLM_LEVEL                     = 0x0004,       // Bit 2, +limit 감속정지 신호 액티브 됨
    IPMECHANICAL_NSLM_LEVEL                     = 0x0008,       // Bit 3, -limit 감속정지 신호 액티브 됨
    IPMECHANICAL_ALARM_LEVEL                    = 0x0010,       // Bit 4, Alarm 신호 액티브 됨
    IPMECHANICAL_INP_LEVEL                      = 0x0020,       // Bit 5, Inposition 신호 액티브 됨
    IPMECHANICAL_ENC_DOWN_LEVEL                 = 0x0040,       // Bit 6, 엔코더 DOWN(B상) 신호 입력 Level
    IPMECHANICAL_ENC_UP_LEVEL                   = 0x0080,       // Bit 7, 엔코더 UP(A상) 신호 입력 Level
    IPMECHANICAL_EXMP_LEVEL                     = 0x0100,       // Bit 8, EXMP 신호 입력 Level
    IPMECHANICAL_EXPP_LEVEL                     = 0x0200,       // Bit 9, EXPP 신호 입력 Level
    IPMECHANICAL_MARK_LEVEL                     = 0x0400,       // Bit 10, MARK# 신호 액티브 됨
    IPMECHANICAL_SSTOP_LEVEL                    = 0x0800,       // Bit 11, SSTOP 신호 액티브 됨
    IPMECHANICAL_ESTOP_LEVEL                    = 0x1000,       // Bit 12, ESTOP 신호 액티브 됨
    IPMECHANICAL_SYNC_LEVEL                     = 0x2000,       // Bit 13, SYNC 신호 입력 Level
    IPMECHANICAL_MODE8_16_LEVEL                 = 0x4000        // Bit 14, MODE8_16 신호 입력 Level
}

//  FS 드라이브 동작 설정
public enum FS_DRIVE_OPERATION:uint
{
    SYM_LINEAR                                  = 0x00,         // 대칭 사다리꼴
    ASYM_LINEAR                                 = 0x01,         // 비대칭 사다리꼴
    SYM_CURVE                                   = 0x02,         // 대칭 포물선(S-Curve)
    ASYM_CURVE                                  = 0x03          // 비대칭 포물선(S-Curve)
}

//  IP 드라이브 동작 설정
public enum IP_DRIVE_OPERATION:uint
{
    IPSYM_LINEAR                                = 0x00,         // 대칭 사다리꼴
    IPASYM_LINEAR                               = 0x01,         // 비대칭 사다리꼴
    IPSYM_CURVE                                 = 0x02,         // 대칭 포물선(S-Curve)
    IPASYM_CURVE                                = 0x03,         // 비대칭 포물선(S-Curve)
    IPSYM_LINEAR_FRAC                           = 0x08,         // 소수점 사용 대칭 사다리꼴
    IPASYM_LINEAR_FRAC                          = 0x09,         // 소수점 사용 비대칭 사다리꼴
    IPSYM_CURVE_FRAC                            = 0x0A,         // 소수점 사용 대칭 포물선(S-Curve)
    IPASYM_CURVE_FRAC                           = 0x0B          // 소수점 사용 비대칭 포물선(S-Curve)
}

// FS COMMAND LIST
public enum FSCOMMAND:uint
{
    // PGM-1 Group Register
    FsRangeDataRead                             = 0x00,         // PGM-1 RANGE READ, 16bit, 0xFFFF
    FsRangeDataWrite                            = 0x80,         // PGM-1 RANGE WRITE
    FsStartStopSpeedDataRead                    = 0x01,         // PGM-1 START/STOP SPEED DATA READ, 16bit, 
    FsStartStopSpeedDataWrite                   = 0x81,         // PGM-1 START/STOP SPEED DATA WRITE
    FsObjectSpeedDataRead                       = 0x02,         // PGM-1 OBJECT SPEED DATA READ, 16bit, 
    FsObjectSpeedDataWrite                      = 0x82,         // PGM-1 OBJECT SPEED DATA WRITE
    FsRate1DataRead                             = 0x03,         // PGM-1 RATE-1 DATA READ, 16bit, 0xFFFF
    FsRate1DataWrite                            = 0x83,         // PGM-1 RATE-1 DATA WRITE
    FsRate2DataRead                             = 0x04,         // PGM-1 RATE-2 DATA READ, 16bit, 0xFFFF
    FsRate2DataWrite                            = 0x84,         // PGM-1 RATE-2 DATA WRITE
    FsRate3DataRead                             = 0x05,         // PGM-1 RATE-3 DATA READ, 16bit, 0xFFFF
    FsRate3DataWrite                            = 0x85,         // PGM-1 RATE-3 DATA WRITE
    FsRateChangePoint12Read                     = 0x06,         // PGM-1 RATE CHANGE POINT 1-2 READ, 16bit, 0xFFFF
    FsRateChangePoint12Write                    = 0x86,         // PGM-1 RATE CHANGE POINT 1-2 WRITE
    FsRateChangePoint23Read                     = 0x07,         // PGM-1 RATE CHANGE POINT 2-3 READ, 16bit, 0xFFFF
    FsRateChangePoint23Write                    = 0x87,         // PGM-1 RATE CHANGE POINT 2-3 WRITE
    FsSw1DataRead                               = 0x08,         // PGM-1 SW-1 DATA READ, 15bit, 0x7FFF
    FsSw1DataWrite                              = 0x88,         // PGM-1 SW-1 DATA WRITE
    FsSw2DataRead                               = 0x09,         // PGM-1 SW-2 DATA READ, 15bit, 0x7FFF
    FsSw2DataWrite                              = 0x89,         // PGM-1 SW-2 DATA WRITE
    FsPwmOutDataRead                            = 0x0A,         // PGM-1 PWM 출력 설정 DATA READ(0~6), 3bit, 0x00
    FsPwmOutDataWrite                           = 0x8A,         // PGM-1 PWM 출력 설정 DATA WRITE
    FsSlowDownRearPulseRead                     = 0x0B,         // PGM-1 SLOW DOWN/REAR PULSE READ, 32bit, 0x00000000
    FsSlowDownRearPulseWrite                    = 0x8B,         // PGM-1 SLOW DOWN/REAR PULSE WRITE
    FsCurrentSpeedDataRead                      = 0x0C,         // PGM-1 현재 SPEED DATA READ, 16bit, 0x0000
    FsNoOperation_8C                            = 0x8C,         // No operation
    FsCurrentSpeedComparateDataRead             = 0x0D,         // PGM-1 현재 SPEED 비교 DATA READ, 16bit, 0x0000
    FsCurrentSpeedComparateDataWrite            = 0x8D,         // PGM-1 현재 SPEED 비교 DATA WRITE
    FsDrivePulseCountRead                       = 0x0E,         // PGM-1 DRIVE PULSE COUNTER READ, 32bit, 0x00000000
    FsNoOperation_8E                            = 0x8E,         // No operation
    FsPresetPulseDataRead                       = 0x0F,         // PGM-1 PRESET PULSE DATA READ, 32bit, 0x00000000
    FsNoOperation_8F                            = 0x8F,         // No operation

    // PGM-1 Update Group Register
    FsURangeDataRead                            = 0x10,         // PGM-1 UP-DATE RANGE READ, 16bit, 0xFFFF
    FsURangeDataWrite                           = 0x90,         // PGM-1 UP-DATE RANGE WRITE
    FsUStartStopSpeedDataRead                   = 0x11,         // PGM-1 UP-DATE START/STOP SPEED DATA READ, 16bit, 
    FsUStartStopSpeedDataWrite                  = 0x91,         // PGM-1 UP-DATE START/STOP SPEED DATA WRITE
    FsUObjectSpeedDataRead                      = 0x12,         // PGM-1 UP-DATE OBJECT SPEED DATA READ, 16bit, 
    FsUObjectSpeedDataWrite                     = 0x92,         // PGM-1 UP-DATE OBJECT SPEED DATA WRITE
    FsURate1DataRead                            = 0x13,         // PGM-1 UP-DATE RATE-1 DATA READ, 16bit, 0xFFFF
    FsURate1DataWrite                           = 0x93,         // PGM-1 UP-DATE RATE-1 DATA WRITE
    FsURate2DataRead                            = 0x14,         // PGM-1 UP-DATE RATE-2 DATA READ, 16bit, 0xFFFF
    FsURate2DataWrite                           = 0x94,         // PGM-1 UP-DATE RATE-2 DATA WRITE
    FsURate3DataRead                            = 0x15,         // PGM-1 UP-DATE RATE-3 DATA READ, 16bit, 0xFFFF
    FsURate3DataWrite                           = 0x95,         // PGM-1 UP-DATE RATE-3 DATA WRITE
    FsURateChange12DataRead                     = 0x16,         // PGM-1 UP-DATE RATE CHANGE POINT 1-2 READ, 16bit, 0xFFFF
    FsURateChange12DataWrite                    = 0x96,         // PGM-1 UP-DATE RATE CHANGE POINT 1-2 WRITE
    FsURateChange23DataRead                     = 0x17,         // PGM-1 UP-DATE RATE CHANGE POINT 2-3 READ, 16bit, 0xFFFF
    FsURateChange23DataWrite                    = 0x97,         // PGM-1 UP-DATE RATE CHANGE POINT 2-3 WRITE
    FsUSw1DataRead                              = 0x18,         // PGM-1 UP-DATE SW-1 DATA READ, 15bit, 0x7FFF
    FsUSw1DataWrite                             = 0x98,         // PGM-1 UP-DATE SW-1 DATA WRITE
    FsUSw2DataRead                              = 0x19,         // PGM-1 UP-DATE SW-2 DATA READ, 15bit, 0x7FFF
    FsUSw2DataWrite                             = 0x99,         // PGM-1 UP-DATE SW-2 DATA WRITE
    FsUCurrentSpeedChangeDataRead               = 0x1A,         // PGM-1 CURRENT SPEED CHANGE DATA READ
    FsUCurrentSpeedChangeDataWrote              = 0x9A,         // PGM-1 CURRENT SPEED CHANGE DATA WRITE
    FsUSlowDownRearPulseRead                    = 0x1B,         // PGM-1 UP-DATE SLOW DOWN/REAR PULSE READ, 32bit, 0x00000000
    FsUSlowDownRearPulseWrite                   = 0x9B,         // PGM-1 UP-DATE SLOW DOWN/REAR PULSE WRITE
    FsUCurrentSpeedDataRead                     = 0x1C,         // PGM-1 현재 SPEED DATA READ, 16bit, 0x0000
    FsNoOperation_9C                            = 0x9C,         // No operation
    FsUCurrentSpeedComparateDataRead            = 0x1D,         // PGM-1 UP-DATE 현재 SPEED 비교 DATA READ, 16bit, 0x0000
    FsUCurrentSpeedComparateDataWrite           = 0x9D,         // PGM-1 UP-DATE 현재 SPEED 비교 DATA WRITE
    FsUDrivePulseCounterDataRead                = 0x1E,         // PGM-1 DRIVE PULSE COUNTER READ, 32bit, 0x00000000
    FsNoOperation_9E                            = 0x9E,         // No operation
    FsUPresetPulseDataRead                      = 0x1F,         // PGM-1 UP-DATE PRESET PULSE DATA READ, 32bit, 0x00000000
    FsNoOperation_9F                            = 0x9F,         // No operation

    // PGM-2 Group Register
    FsNoOperation_20                            = 0x20,         // No operation
    FsPresetPulseDriveP                         = 0xA0,         // +PRESET PULSE DRIVE, 32
    FsNoOperation_21                            = 0x21,         // No operation
    FsContinuousDriveP                          = 0xA1,         // +CONTINUOUS DRIVE
    FsNoOperation_22                            = 0x22,         // No operation
    FsSignalSearch1DriveP                       = 0xA2,         // +SIGNAL SEARCH-1 DRIVE
    FsNoOperation_23                            = 0x23,         // No operation
    FsSignalSearch2DriveP                       = 0xA3,         // +SIGNAL SEARCH-2 DRIVE
    FsNoOperation_24                            = 0x24,         // No operation
    FsOriginSearchDriveP                        = 0xA4,         // +ORIGIN(원점) SEARCH DRIVE
    FsNoOperation_25                            = 0x25,         // No operation
    FsPresetPulseDriveN                         = 0xA5,         // -PRESET PULSE DRIVE, 32
    FsNoOperation_26                            = 0x26,         // No operation
    FsContinuousDriveN                          = 0xA6,         // -CONTINUOUS DRIVE
    FsNoOperation_27                            = 0x27,         // No operation
    FsSignalSearch1DriveN                       = 0xA7,         // -SIGNAL SEARCH-1 DRIVE
    FsNoOperation_28                            = 0x28,         // No operation
    FsSignalSearch2DriveN                       = 0xA8,         // -SIGNAL SEARCH-2 DRIVE
    FsNoOperation_29                            = 0x29,         // No operation
    FsOriginSearchDriveN                        = 0xA9,         // -ORIGIN(원점) SEARCH DRIVE
    FsNoOperation_2A                            = 0x2A,         // No operation
    FsPresetPulseDataOverride                   = 0xAA,         // PRESET PULSE DATA OVERRIDE(ON_BUSY)
    FsNoOperation_2B                            = 0x2B,         // No operation
    FsSlowDownStop                              = 0xAB,         // SLOW DOWN STOP
    FsNoOperation_2C                            = 0x2C,         // No operation
    FsEmergencyStop                             = 0xAC,         // EMERGENCY STOP
    FsDriveOperationSelectDataRead              = 0x2D,         // 드라이브 동작 설정 DATA READ
    FsDriveOperationSelectDataWrite             = 0xAD,         // 드라이브 동작 설정 DATA WRITE
    FsMpgOperationSettingDataRead               = 0x2E,         // MPG OPERATION SETTING DATA READ, 3bit, 0x00
    FsMpgOperationSettingDataWrite              = 0xAE,         // MPG OPERATION SETTING DATA WRITE
    FsMpgPresetPulseDataRead                    = 0x2F,         // MPG PRESET PULSE DATA READ, 32bit, 0x00000000
    FsMpgPresetPulseDataWrite                   = 0xAF,         // MPG PRESET PULSE DATA WRITE

    // Extension Group Register
    FsNoOperation_30                            = 0x30,         // No operation
    FsSensorPositioningDrive1P                  = 0xB0,         // +SENSOR POSITIONING DRIVE I
    FsNoOperation_31                            = 0x31,         // No operation
    FsSensorPositioningDrive1N                  = 0xB1,         // -SENSOR POSITIONING DRIVE I
    FsNoOperation_32                            = 0x32,         // No operation
    FsSensorPositioningDrive2P                  = 0xB2,         // +SENSOR POSITIONING DRIVE II
    FsNoOperation_33                            = 0x33,         // No operation
    FsSensorPositioningDrive2N                  = 0xB3,         // -SENSOR POSITIONING DRIVE II
    FsNoOperation_34                            = 0x34,         // No operation
    FsSensorPositioningDrive3P                  = 0xB4,         // +SENSOR POSITIONING DRIVE III
    FsNoOperation_35                            = 0x35,         // No operation
    FsSensorPositioningDrive3N                  = 0xB5,         // -SENSOR POSITIONING DRIVE III
    FsSoftlimitSettingDataRead                  = 0x36,         // SOFT LIMIT 설정 READ, 3bit, 0x00
    FsSoftlimitSettingDataWrite                 = 0xB6,         // SOFT LIMIT 설정 WRITE
    FsNegativeSoftlimitDataRead                 = 0x37,         // -SOFT LIMIT 비교 레지스터 설정 READ, 32bit, 0x80000000
    FsNegativeSoftlimitDataWrite                = 0xB7,         // -SOFT LIMIT 비교 레지스터 설정 WRITE
    FsPositiveSoftlimitDataRead                 = 0x38,         // +SOFT LIMIT 비교 레지스터 설정 READ, 32bit, 0x7FFFFFFF
    FsPositiveSoftlimitDataWrite                = 0xB8,         // +SOFT LIMIT 비교 레지스터 설정 WRITE
    FsTriggerModeSettingDataRead                = 0x39,         // TRIGGER MODE 설정 READ, 32bit, 0x00010000
    FsTriggerModeSettingDataWrite               = 0xB9,         // TRIGGER MODE 설정 WRITE
    FsTriggerComparatorDataRead                 = 0x3A,         // TRIGGER 비교 데이터 설정 READ, 32bit, 0x00000000
    FsTriggerComparatorDataWrite                = 0xBA,         // TRIGGER 비교 데이터 설정 WRITE
    FsInternalCounterMDataRead                  = 0x3B,         // INTERNAL M-DATA 설정 READ, 32bit, 0x80000000
    FsInternalCounterMDataWrite                 = 0xBB,         // INTERNAL M-DATA 설정 WRITE
    FsExternalCounterMDataRead                  = 0x3C,         // EXTERNAL M-DATA 설정 READ, 32bit, 0x80000000
    FsExternalCounterMDataWrite                 = 0xBC,         // EXTERNAL M-DATA 설정 WRITE
    FsNoOperation_BD                            = 0xBD,         // No operation
    FsNoOperation_3D                            = 0x3D,         // No operation
    FsNoOperation_3E                            = 0x3E,         // No operation
    FsNoOperation_BE                            = 0xBE,         // No operation
    FsNoOperation_3F                            = 0x3F,         // No operation
    FsNoOperation_BF                            = 0xBF,         // No operation
    
    // Scripter Group Register
    FsScriptOperSetReg1Read                     = 0x40,         // 스크립트 동작 설정 레지스터-1 READ, 32bit, 0x00000000
    FsScriptOperSetReg1Write                    = 0xC0,         // 스크립트 동작 설정 레지스터-1 WRITE
    FsScriptOperSetReg2Read                     = 0x41,         // 스크립트 동작 설정 레지스터-2 READ, 32bit, 0x00000000
    FsScriptOperSetReg2Write                    = 0xC1,         // 스크립트 동작 설정 레지스터-2 WRITE
    FsScriptOperSetReg3Read                     = 0x42,         // 스크립트 동작 설정 레지스터-3 READ, 32bit, 0x00000000 
    FsScriptOperSetReg3Write                    = 0xC2,         // 스크립트 동작 설정 레지스터-3 WRITE
    FsScriptOperSetRegQueueRead                 = 0x43,         // 스크립트 동작 설정 레지스터-Queue READ, 32bit, 0x00000000
    FsScriptOperSetRegQueueWrite                = 0xC3,         // 스크립트 동작 설정 레지스터-Queue WRITE
    FsScriptOperDataReg1Read                    = 0x44,         // 스크립트 동작 데이터 레지스터-1 READ, 32bit, 0x00000000 
    FsScriptOperDataReg1Write                   = 0xC4,         // 스크립트 동작 데이터 레지스터-1 WRITE
    FsScriptOperDataReg2Read                    = 0x45,         // 스크립트 동작 데이터 레지스터-2 READ, 32bit, 0x00000000 
    FsScriptOperDataReg2Write                   = 0xC5,         // 스크립트 동작 데이터 레지스터-2 WRITE
    FsScriptOperDataReg3Read                    = 0x46,         // 스크립트 동작 데이터 레지스터-3 READ, 32bit, 0x00000000 
    FsScriptOperDataReg3Write                   = 0xC6,         // 스크립트 동작 데이터 레지스터-3 WRITE
    FsScriptOperDataRegQueueRead                = 0x47,         // 스크립트 동작 데이터 레지스터-Queue READ, 32bit, 0x00000000 
    FsScriptOperDataRegQueueWrite               = 0xC7,         // 스크립트 동작 데이터 레지스터-Queue WRITE
    FsNoOperation_48                            = 0x48,         // No operation
    FsScriptOperQueueClear                      = 0xC8,         // 스크립트 Queue clear
    FsScriptOperSetQueueIndexRead               = 0x49,         // 스크립트 동작 설정 Queue 인덱스 READ, 4bit, 0x00
    FsNoOperation_C9                            = 0xC9,         // No operation
    FsScriptOperDataQueueIndexRead              = 0x4A,         // 스크립트 동작 데이터 Queue 인덱스 READ, 4bit, 0x00
    FsNoOperation_CA                            = 0xCA,         // No operation
    FsScriptOperQueueFlagRead                   = 0x4B,         // 스크립트 Queue Full/Empty Flag READ, 4bit, 0x05
    FsNoOperation_CB                            = 0xCB,         // No operation
    FsScriptOperQueueSizeSettingRead            = 0x4C,         // 스크립트 Queue size 설정(0~13) READ, 16bit, 0xD0D0
    FsScriptOperQueueSizeSettingWrite           = 0xCC,         // 스크립트 Queue size 설정(0~13) WRITE
    FsScriptOperQueueStatusRead                 = 0x4D,         // 스크립트 Queue status READ, 12bit, 0x005
    FsNoOperation_CD                            = 0xCD,         // No operation
    FsNoOperation_4E                            = 0x4E,         // No operation
    FsNoOperation_CE                            = 0xCE,         // No operation
    FsNoOperation_4F                            = 0x4F,         // No operation
    FsNoOperation_CF                            = 0xCF,         // No operation

    // Caption Group Register
    FsCaptionOperSetReg1Read                    = 0x50,         // 갈무리 동작 설정 레지스터-1 READ, 32bit, 0x00000000
    FsCaptionOperSetReg1Write                   = 0xD0,         // 갈무리 동작 설정 레지스터-1 WRITE
    FsCaptionOperSetReg2Read                    = 0x51,         // 갈무리 동작 설정 레지스터-2 READ, 32bit, 0x00000000
    FsCaptionOperSetReg2Write                   = 0xD1,         // 갈무리 동작 설정 레지스터-2 WRITE
    FsCaptionOperSetReg3Read                    = 0x52,         // 갈무리 동작 설정 레지스터-3 READ, 32bit, 0x00000000 
    FsCaptionOperSetReg3Write                   = 0xD2,         // 갈무리 동작 설정 레지스터-3 WRITE
    FsCaptionOperSetRegQueueRead                = 0x53,         // 갈무리 동작 설정 레지스터-Queue READ, 32bit, 0x00000000
    FsCaptionOperSetRegQueueWrite               = 0xD3,         // 갈무리 동작 설정 레지스터-Queue WRITE
    FsCaptionOperDataReg1Read                   = 0x54,         // 갈무리 동작 데이터 레지스터-1 READ, 32bit, 0x00000000 
    FsNoOperation_D4                            = 0xD4,         // No operation
    FsCaptionOperDataReg2Read                   = 0x55,         // 갈무리 동작 데이터 레지스터-2 READ, 32bit, 0x00000000 
    FsNoOperation_D5                            = 0xD5,         // No operation
    FsCaptionOperDataReg3Read                   = 0x56,         // 갈무리 동작 데이터 레지스터-3 READ, 32bit, 0x00000000 
    FsNoOperation_D6                            = 0xD6,         // No operation
    FsCaptionOperDataRegQueueRead               = 0x57,         // 갈무리 동작 데이터 레지스터-Queue READ, 32bit, 0x00000000 
    FsNoOperation_D7                            = 0xD7,         // No operation
    FsNoOperation_58                            = 0x58,         // No operation
    FsCaptionOperQueueClear                     = 0xD8,         // 갈무리 Queue clear
    FsCaptionOperSetQueueIndexRead              = 0x59,         // 갈무리 동작 설정 Queue 인덱스 READ, 4bit, 0x00
    FsNoOperation_D9                            = 0xD9,         // No operation
    FsCaptionOperDataQueueIndexRead             = 0x5A,         // 갈무리 동작 데이터 Queue 인덱스 READ, 4bit, 0x00
    FsNoOperation_DA                            = 0xDA,         // No operation
    FsCaptionOperQueueFlagRead                  = 0x5B,         // 갈무리 Queue Full/Empty Flag READ, 4bit, 0x05
    FsNoOperation_DB                            = 0xDB,         // No operation
    FsCaptionOperQueueSizeSettingRead           = 0x5C,         // 갈무리 Queue size 설정(0~13) READ, 16bit, 0xD0D0
    FsCaptionOperQueueSizeSettingWrite          = 0xDC,         // 갈무리 Queue size 설정(0~13) WRITE
    FsCaptionOperQueueStatusRead                = 0x5D,         // 갈무리 Queue status READ, 12bit, 0x005
    FsNoOperation_DD                            = 0xDD,         // No operation
    FsNoOperation_5E                            = 0x5E,         // No operation
    FsNoOperation_DE                            = 0xDE,         // No operation
    FsNoOperation_5F                            = 0x5F,         // No operation
    FsNoOperation_DF                            = 0xDF,         // No operation

    // BUS - 1 Group Register
    FsInternalCounterRead                       = 0x60,         // INTERNAL COUNTER DATA READ(Signed), 32bit, 0x00000000
    FsInternalCounterWrite                      = 0xE0,         // INTERNAL COUNTER DATA WRITE(Signed)
    FsInternalCounterComparatorDataRead         = 0x61,         // INTERNAL COUNTER COMPARATE DATA READ(Signed), 32bit, 0x00000000
    FsInternalCounterComparatorDataWrite        = 0xE1,         // INTERNAL COUNTER COMPARATE DATA WRITE(Signed)
    FsInternalCounterPreScaleDataRead           = 0x62,         // INTERNAL COUNTER PRE-SCALE DATA READ, 8bit, 0x00
    FsInternalCounterPreScaleDataWrite          = 0xE2,         // INTERNAL COUNTER PRE-SCALE DATA WRITE
    FsInternalCounterNCountDataRead             = 0x63,         // INTERNAL COUNTER P-DATA READ, 32bit, 0x7FFFFFFF
    FsInternalCounterNCountDataWrite            = 0xE3,         // INTERNAL COUNTER P-DATA WRITE
    FsExternalCounterRead                       = 0x64,         // EXTERNAL COUNTER DATA READ READ(Signed), 32bit, 0x00000000
    FsExternalCounterWrite                      = 0xE4,         // EXTERNAL COUNTER DATA READ WRITE(Signed)
    FsExternalCounterComparatorDataRead         = 0x65,         // EXTERNAL COUNTER COMPARATE DATA READ(Signed), 32bit, 0x00000000
    FsExternalCounterComparatorDataWrite        = 0xE5,         // EXTERNAL COUNTER COMPARATE DATA WRITE(Signed)
    FsExternalCounterPreScaleDataRead           = 0x66,         // EXTERNAL COUNTER PRE-SCALE DATA READ, 8bit, 0x00
    FsExternalCounterPreScaleDataWrite          = 0xE6,         // EXTERNAL COUNTER PRE-SCALE DATA WRITE
    FsExternalCounterNCountDataRead             = 0x67,         // EXTERNAL COUNTER P-DATA READ, 32bit, 0x7FFFFFFF
    FsExternalCounterNCountDataWrite            = 0xE7,         // EXTERNAL COUNTER P-DATA WRITE
    FsExternalSpeedDataRead                     = 0x68,         // EXTERNAL SPEED DATA READ, 32bit, 0x00000000
    FsExternalSpeedDataWrite                    = 0xE8,         // EXTERNAL SPEED DATA WRITE
    FsExternalSpeedComparateDataRead            = 0x69,         // EXTERNAL SPEED COMPARATE DATA READ, 32bit, 0x00000000
    FsExternalSpeedComparateDataWrite           = 0xE9,         // EXTERNAL SPEED COMPARATE DATA WRITE
    FsExternalSensorFilterBandWidthDataRead     = 0x6A,         // 외부 센서 필터 대역폭 설정 DATA READ, 8bit, 0x05
    FsExternalSensorFilterBandWidthDataWrite    = 0xEA,         // 외부 센서 필터 대역폭 설정 DATA WRITE
    FsOffRangeDataRead                          = 0x6B,         // OFF-RANGE DATA READ, 8bit, 0x00
    FsOffRangeDataWrite                         = 0xEB,         // OFF-RANGE DATA WRITE
    FsDeviationDataRead                         = 0x6C,         // DEVIATION DATA READ, 16bit, 0x0000
    FsNoOperation_EC                            = 0xEC,         // No operation
    FsPgmRegChangeDataRead                      = 0x6D,         // PGM REGISTER CHANGE DATA READ
    FsPgmRegChangeDataWrite                     = 0xED,         // PGM REGISTER CHANGE DATA WRITE
    FsNoOperation_6E                            = 0x6E,         // No operation
    FsCompareRegisterInputChangeDataWrite       = 0xEE,         // COMPARE REGISTER INPUT CHANGE
    FsNoOperation_6F                            = 0x6F,         // No operation
    FsNoOperation_EF                            = 0xEF,         // No operation
    // FsCompareRegisterInputChangeDataRead    = 0x6E,

    // BUS - 2 Group Register
    FsChipFunctionSetDataRead                   = 0x70,         // 칩 기능 설정 DATA READ, 13bit, 0x0C3E
    FsChipFunctionSetDataWrite                  = 0xF0,         // 칩 기능 설정 DATA WRITE
    FsMode1Read                                 = 0x71,         // MODE1 DATA READ, 8bit, 0x00
    FsMode1Write                                = 0xF1,         // MODE1 DATA WRITE
    FsMode2Read                                 = 0x72,         // MODE2 DATA READ, 11bit, 0x200
    FsMode2Write                                = 0xF2,         // MODE2 DATA WRITE
    FsUniversalSignalRead                       = 0x73,         // UNIVERSAL IN READ, 11bit, 0x0000
    FsUniversalSignalWrite                      = 0xF3,         // UNIVERSAL OUT WRITE
    FsEndStatusRead                             = 0x74,         // END STATUS DATA READ, 15bit, 0x0000
    FsNoOperation_F4                            = 0xF4,         // No operation
    FsMechanicalSignalRead                      = 0x75,         // MECHANICAL SIGNAL DATA READ, 13bit
    FsNoOperation_F5                            = 0xF5,         // No operation
    FsDriveStatusRead                           = 0x76,         // DRIVE STATE DATA READ, 9bit
    FsNoOperation_F6                            = 0xF6,         // No operation
    FsExternalCounterSetDataRead                = 0x77,         // EXTERNAL COUNTER 설정 DATA READ, 9bit, 0x00
    FsExternalCounterSetDataWrite               = 0xF7,         // EXTERNAL COUNTER 설정 DATA WRITE
    FsNoOperation_78                            = 0x78,         // No operation
    FsRegisterClear                             = 0xF8,         // REGISTER CLEAR(INITIALIZATION)
    FsInterruptFlagRead                         = 0x79,         // Interrupt Flag READ, 32bit, 0x00000000
    FsInterruptOutCommand                       = 0xF9,         // Interrupt 발생 Command
    FsInterruptMaskRead                         = 0x7A,         // Interrupt Mask READ, 32bit, 0x00000001
    FsInterruptMaskWrite                        = 0xFA,         // Interrupt Mask WRITE
    FsEMode1DataRead                            = 0x7B,         // EMODE1 DATA READ, 8bit, 0x00
    FsEMode1DataWrite                           = 0xFB,         // EMODE1 DATA WRITE
    FsEUniversalOutRead                         = 0x7C,         // Extension UNIVERSAL OUT READ, 8bit, 0x00
    FsEUniversalOutWrite                        = 0xFC,         // Extension UNIVERSAL OUT WRITE
    FsNoOperation_7D                            = 0x7D,         // No operation
    FsLimitStopDisableWrite                     = 0xFD,         // LIMIT 완전정지 해제
    FsUserInterruptSourceSelectRegRead          = 0x7E,         // USER Interrupt source selection register READ, 32bit, 0x00000000
    FsUserInterruptSourceSelectRegWrite         = 0xFE,         // USER Interrupt source selection register WRITE
    FsNoOperation_7F                            = 0x7F,         // No operation
    FsNoOperation_FF                            = 0xFF,         // No operation
}

// IP COMMAND LIST
public enum IPCOMMAND:uint
{
    // PGM-1 Group Register
    IPxyRANGERead                               = 0x00,         // PGM-1 RANGE READ, 16bit, 0xFFFF
    IPxyRANGEWrite                              = 0x80,         // PGM-1 RANGE WRITE
    IPxySTDRead                                 = 0x01,         // PGM-1 START/STOP SPEED DATA READ, 16bit, 
    IPxySTDWrite                                = 0x81,         // PGM-1 START/STOP SPEED DATA WRITE
    IPxyOBJRead                                 = 0x02,         // PGM-1 OBJECT SPEED DATA READ, 16bit, 
    IPxyOBJWrite                                = 0x82,         // PGM-1 OBJECT SPEED DATA WRITE
    IPxyRATE1Read                               = 0x03,         // PGM-1 RATE-1 DATA READ, 16bit, 0xFFFF
    IPxyRATE1Write                              = 0x83,         // PGM-1 RATE-1 DATA WRITE
    IPxyRATE2Read                               = 0x04,         // PGM-1 RATE-2 DATA READ, 16bit, 0xFFFF
    IPxyRATE2Write                              = 0x84,         // PGM-1 RATE-2 DATA WRITE
    IPxyRATE3Read                               = 0x05,         // PGM-1 RATE-3 DATA READ, 16bit, 0xFFFF
    IPxyRATE3Write                              = 0x85,         // PGM-1 RATE-3 DATA WRITE
    IPxyRCP12Read                               = 0x06,         // PGM-1 RATE CHANGE POINT 1-2 READ, 16bit, 0xFFFF
    IPxyRCP12Write                              = 0x86,         // PGM-1 RATE CHANGE POINT 1-2 WRITE
    IPxyRCP23Read                               = 0x07,         // PGM-1 RATE CHANGE POINT 2-3 READ, 16bit, 0xFFFF
    IPxyRCP23Write                              = 0x87,         // PGM-1 RATE CHANGE POINT 2-3 WRITE
    IPxySW1Read                                 = 0x08,         // PGM-1 SW-1 DATA READ, 15bit, 0x7FFF
    IPxySW1Write                                = 0x88,         // PGM-1 SW-1 DATA WRITE
    IPxySW2Read                                 = 0x09,         // PGM-1 SW-2 DATA READ, 15bit, 0x7FFF
    IPxySW2Write                                = 0x89,         // PGM-1 SW-2 DATA WRITE
    IPxyPWMRead                                 = 0x0A,         // PGM-1 PWM 출력 설정 DATA READ(0~6), 3bit, 0x00
    IPxyPWMWrite                                = 0x8A,         // PGM-1 PWM 출력 설정 DATA WRITE
    IPxyREARRead                                = 0x0B,         // PGM-1 SLOW DOWN/REAR PULSE READ, 32bit, 0x00000000
    IPxyREARWrite                               = 0x8B,         // PGM-1 SLOW DOWN/REAR PULSE WRITE
    IPxySPDRead                                 = 0x0C,         // PGM-1 현재 SPEED DATA READ, 16bit, 0x0000
    IPxyNoOperation_8C                          = 0x8C,         // No operation
    IPxySPDCMPRead                              = 0x0D,         // PGM-1 현재 SPEED 비교 DATA READ, 16bit, 0x0000
    IPxySPDCMPWrite                             = 0x8D,         // PGM-1 현재 SPEED 비교 DATA WRITE
    IPxyDRVPULSERead                            = 0x0E,         // PGM-1 DRIVE PULSE COUNTER READ, 32bit, 0x00000000
    IPxyNoOperation_8E                          = 0x8E,         // No operation
    IPxyPRESETPULSERead                         = 0x0F,         // PGM-1 PRESET PULSE DATA READ, 32bit, 0x00000000
    IPxyNoOperation_8F                          = 0x8F,         // No operation

    // PGM-1 Update Group Register
    IPxyURANGERead                              = 0x10,         // PGM-1 UP-DATE RANGE READ, 16bit, 0xFFFF
    IPxyURANGEWrite                             = 0x90,         // PGM-1 UP-DATE RANGE WRITE
    IPxyUSTDRead                                = 0x11,         // PGM-1 UP-DATE START/STOP SPEED DATA READ, 16bit, 
    IPxyUSTDWrite                               = 0x91,         // PGM-1 UP-DATE START/STOP SPEED DATA WRITE
    IPxyUOBJRead                                = 0x12,         // PGM-1 UP-DATE OBJECT SPEED DATA READ, 16bit, 
    IPxyUOBJWrite                               = 0x92,         // PGM-1 UP-DATE OBJECT SPEED DATA WRITE
    IPxyURATE1Read                              = 0x13,         // PGM-1 UP-DATE RATE-1 DATA READ, 16bit, 0xFFFF
    IPxyURATE1Write                             = 0x93,         // PGM-1 UP-DATE RATE-1 DATA WRITE
    IPxyURATE2Read                              = 0x14,         // PGM-1 UP-DATE RATE-2 DATA READ, 16bit, 0xFFFF
    IPxyURATE2Write                             = 0x94,         // PGM-1 UP-DATE RATE-2 DATA WRITE
    IPxyURATE3Read                              = 0x15,         // PGM-1 UP-DATE RATE-3 DATA READ, 16bit, 0xFFFF
    IPxyURATE3Write                             = 0x95,         // PGM-1 UP-DATE RATE-3 DATA WRITE
    IPxyURCP12Read                              = 0x16,         // PGM-1 UP-DATE RATE CHANGE POINT 1-2 READ, 16bit, 0xFFFF
    IPxyURCP12Write                             = 0x96,         // PGM-1 UP-DATE RATE CHANGE POINT 1-2 WRITE
    IPxyURCP23Read                              = 0x17,         // PGM-1 UP-DATE RATE CHANGE POINT 2-3 READ, 16bit, 0xFFFF
    IPxyURCP23Write                             = 0x97,         // PGM-1 UP-DATE RATE CHANGE POINT 2-3 WRITE
    IPxyUSW1Read                                = 0x18,         // PGM-1 UP-DATE SW-1 DATA READ, 15bit, 0x7FFF
    IPxyUSW1Write                               = 0x98,         // PGM-1 UP-DATE SW-1 DATA WRITE
    IPxyUSW2Read                                = 0x19,         // PGM-1 UP-DATE SW-2 DATA READ, 15bit, 0x7FFF
    IPxyUSW2Write                               = 0x99,         // PGM-1 UP-DATE SW-2 DATA WRITE
    IPxyNoOperation_1A                          = 0x1A,         // No operation
    IPxyNoOperation_9A                          = 0x9A,         // No operation
    IPxyUREARRead                               = 0x1B,         // PGM-1 UP-DATE SLOW DOWN/REAR PULSE READ, 32bit, 0x00000000
    IPxyUREARWrite                              = 0x9B,         // PGM-1 UP-DATE SLOW DOWN/REAR PULSE WRITE
    IPxySPDRead_1C                              = 0x1C,         // PGM-1 UP-DATA CURRENT SPEED READ(Same with 0x0C)
    IPxyNoOperation_9C                          = 0x9C,         // No operation
    IPxySPDCMPRead_1D                           = 0x1D,         // PGM-1 현재 SPEED 비교 DATA READ(Same with 0x0D) 
    IPxySPDCMPWrite_9D                          = 0x9D,         // PGM-1 현재 SPEED 비교 DATA WRITE(Same with 0x8D) 
    IPxyACCPULSERead                            = 0x1E,         // PGM-1 가속 PULSE COUNTER READ, 32bit, 0x00000000
    IPxyNoOperation_9E                          = 0x9E,         // No operation
    IPxyPRESETPULSERead_1F                      = 0x1F,         // PGM-1 PRESET PULSE DATA READ(Same with 0x0F)
    IPxyNoOperation_9F                          = 0x9F,         // No operation

    // PGM-2 Group Register
    IPxyNoOperation_20                          = 0x20,         // No operation
    IPxyPPRESETDRV                              = 0xA0,         // +PRESET PULSE DRIVE, 32
    IPxyNoOperation_21                          = 0x21,         // No operation
    IPxyPCONTDRV                                = 0xA1,         // +CONTINUOUS DRIVE
    IPxyNoOperation_22                          = 0x22,         // No operation
    IPxyPSCH1DRV                                = 0xA2,         // +SIGNAL SEARCH-1 DRIVE
    IPxyNoOperation_23                          = 0x23,         // No operation
    IPxyPSCH2DRV                                = 0xA3,         // +SIGNAL SEARCH-2 DRIVE
    IPxyNoOperation_24                          = 0x24,         // No operation
    IPxyPORGDRV                                 = 0xA4,         // +ORIGIN(원점) SEARCH DRIVE
    IPxyNoOperation_25                          = 0x25,         // No operation
    IPxyMPRESETDRV                              = 0xA5,         // -PRESET PULSE DRIVE, 32
    IPxyNoOperation_26                          = 0x26,         // No operation
    IPxyMCONTDRV                                = 0xA6,         // -CONTINUOUS DRIVE
    IPxyNoOperation_27                          = 0x27,         // No operation
    IPxyMSCH1DRV                                = 0xA7,         // -SIGNAL SEARCH-1 DRIVE
    IPxyNoOperation_28                          = 0x28,         // No operation
    IPxyMSCH2DRV                                = 0xA8,         // -SIGNAL SEARCH-2 DRIVE
    IPxyNoOperation_29                          = 0x29,         // No operation
    IPxyMORGDRV                                 = 0xA9,         // -ORIGIN(원점) SEARCH DRIVE
    IPxyPULSEOVERRead                           = 0x2A,         // Preset/MPG drive override pulse data read
    IPxyPULSEOVERWrite                          = 0xAA,         // PRESET PULSE DATA OVERRIDE(ON_BUSY)
    IPxyNoOperation_2B                          = 0x2B,         // No operation
    IPxySSTOPCMD                                = 0xAB,         // SLOW DOWN STOP
    IPxyNoOperation_2C                          = 0x2C,         // No operation
    IPxyESTOPCMD                                = 0xAC,         // EMERGENCY STOP
    IPxyDRIVEMODERead                           = 0x2D,         // 드라이브 동작 설정 DATA READ
    IPxyDRIVEMODEWrite                          = 0xAD,         // 드라이브 동작 설정 DATA WRITE
    IPxyMPGCONRead                              = 0x2E,         // MPG OPERATION SETTING DATA READ, 3bit, 0x00    
    IPxyMPGCONWrite                             = 0xAE,         // MPG OPERATION SETTING DATA WRITE                
    IPxyPULSEMPGRead                            = 0x2F,         // MPG PRESET PULSE DATA READ, 32bit, 0x00000000
    IPxyPULSEMPGWrite                           = 0xAF,         // MPG PRESET PULSE DATA WRITE                    

    // Extension Group Register
    IPxyNoOperation_30                          = 0x30,         // No operation
    IPxyPSPO1DRV                                = 0xB0,         // +SENSOR POSITIONING DRIVE I
    IPxyNoOperation_31                          = 0x31,         // No operation
    IPxyMSPO1DRV                                = 0xB1,         // -SENSOR POSITIONING DRIVE I
    IPxyNoOperation_32                          = 0x32,         // No operation
    IPxyPSPO2DRV                                = 0xB2,         // +SENSOR POSITIONING DRIVE II
    IPxyNoOperation_33                          = 0x33,         // No operation
    IPxyMSPO2DRV                                = 0xB3,         // -SENSOR POSITIONING DRIVE II
    IPxyNoOperation_34                          = 0x34,         // No operation
    IPxyPSPO3DRV                                = 0xB4,         // +SENSOR POSITIONING DRIVE III
    IPxyNoOperation_35                          = 0x35,         // No operation
    IPxyMSPO3DRV                                = 0xB5,         // -SENSOR POSITIONING DRIVE III
    IPxySWLMTCONRead                            = 0x36,         // SOFT LIMIT 설정 READ, 3bit, 0x00
    IPxySWLMTCONWrite                           = 0xB6,         // SOFT LIMIT 설정 WRITE
    IPxyMSWLMTCOMPRead                          = 0x37,         // -SOFT LIMIT 비교 레지스터 설정 READ, 32bit, 0x80000000
    IPxyMSWLMTCOMPWrite                         = 0xB7,         // -SOFT LIMIT 비교 레지스터 설정 WRITE
    IPxyPSWLMTCOMPRead                          = 0x38,         // +SOFT LIMIT 비교 레지스터 설정 READ, 32bit, 0x7FFFFFFF
    IPxyPSWLMTCOMPWrite                         = 0xB8,         // +SOFT LIMIT 비교 레지스터 설정 WRITE
    IPxyTRGCONRead                              = 0x39,         // TRIGGER MODE 설정 READ, 32bit, 0x00010000
    IPxyTRGCONWrite                             = 0xB9,         // TRIGGER MODE 설정 WRITE
    IPxyTRGCOMPRead                             = 0x3A,         // TRIGGER 비교 데이터 설정 READ, 32bit, 0x00000000
    IPxyTRGCOMPWrite                            = 0xBA,         // TRIGGER 비교 데이터 설정 WRITE
    IPxyICMRead                                 = 0x3B,         // INTERNAL M-DATA 설정 READ, 32bit, 0x80000000
    IPxyICMWrite                                = 0xBB,         // INTERNAL M-DATA 설정 WRITE
    IPxyECMRead                                 = 0x3C,         // EXTERNAL M-DATA 설정 READ, 32bit, 0x80000000
    IPxyECMWrite                                = 0xBC,         // EXTERNAL M-DATA 설정 WRITE
    IPxySTOPPWRead                              = 0x3D,         // Stop pulse width Read
    IPxySTOPPWWrite                             = 0xBD,         // Stop pulse width Write
    IPxyNoOperation_3E                          = 0x3E,         // No operation
    IPxyNoOperation_BE                          = 0xBE,         // No operation
    IPxyNoOperation_3F                          = 0x3F,         // No operation
    IPxyTRGCMD                                  = 0xBF,         // TRIG output signal generation command

    // Interpolation Group Registers
    IPxCIRXCRead                                = 0x40,         // Circular interpolation X axis center point read
    IPxCIRXCWrite                               = 0xC0,         // Circular interpolation X axis center point write 
    IPxCIRYCRead                                = 0x41,         // Circular interpolation Y axis center point read 
    IPxCIRYCWrite                               = 0xC1,         // Circular interpolation Y axis center point write  
    IPxENDXRead                                 = 0x42,         // Interpolation X axis end point read 
    IPxENDXWrite                                = 0xC2,         // Interpolation X axis end point write  
    IPxENDYRead                                 = 0x43,         // Interpolation Y axis end point read  
    IPxENDYWrite                                = 0xC3,         // Interpolation Y axis end point write  
    IPxPTXENDRead                               = 0x44,         // Pattern interpolation X Queue data read
    IPxPTXENDWrite                              = 0xC4,         // Pattern interpolation X Queue data with queue push 
    IPxPTYENDRead                               = 0x45,         // Pattern interpolation Y Queue data read 
    IPxPTYENDWrite                              = 0xC5,         // Pattern interpolation Y Queue data write
    IPxPTQUEUERead                              = 0x46,         // Pattern interpolation Queue index read
    IPxNoOperation_C6                           = 0xC6,         // No operation
    IPxNoOperation_47                           = 0x47,         // No operation
    IPxNoOperation_C7                           = 0xC7,         // No operation
    IPxNoOperation_48                           = 0x48,         // No operation
    IPxNoOperation_C8                           = 0xC8,         // No operation
    IPxNoOperation_49                           = 0x49,         // No operation
    IPxNoOperation_C9                           = 0xC9,         // No operation
    IPxINPSTATUSRead                            = 0x4A,         // Interpolation Status register read
    IPxNoOperation_CA                           = 0xCA,         // No operation
    IPxINPMODE_4B                               = 0x4B,         // Interpolation mode in Queue TOP contets
    IPxLINPDRV                                  = 0xCB,         // Linear interpolation with Queue push
    IPxINPMODE_4C                               = 0x4C,         // Interpolation mode in Queue TOP contets
    IPxCINPDRV                                  = 0xCC,         // Circular interpolation with Queue push 
    IPxBPINPMODE                                = 0x4D,         // Bit Pattern Interpolation mode in Queue TOP contets
    IPxBPINPDRV                                 = 0xCD,         // Bit pattern Drive
    IPxNoOperation_4E                           = 0x4E,         // No Operation
    IPxNoOperation_CE                           = 0xCE,         // No Operation 
    IPxNoOperation_4F                           = 0x4F,         // No Operation 
    IPxNoOperation_CF                           = 0xCF,         // No Operation 

    // Arithemetic Group Register
    IPxNoOperation_50                           = 0x50,         // No Operation
    IPxINPCLR                                   = 0xD0,         // Initialize all interpolation control block
    IPxINPMPOINTRead                            = 0x51,         // Interpolation deceleration manual point(unsigned) read
    IPxINPMPOINTWrite                           = 0xD1,         // Interpolation deceleration manual point(unsigned) write
    IPxNoOperation_52                           = 0x52,         // No Operation
    IPxINPCLRSWrite                             = 0xD2,         // Initialize interpolation control block with target selection
    IPxNoOperation_53                           = 0x53,         // No Operation
    IPxINPDRVWrite                              = 0xD3,         // linear/circular drive start with queue data(Hold on mode), Restart on pause
    IPxNoOperation_54                           = 0x54,         // No operation
    IPxNoOperation_D4                           = 0xD4,         // No operation
    IPxNoOperation_55                           = 0x55,         // No operation
    IPxARTSHOT                                  = 0xD5,         // Arithmetic block One time execution
    IPxARTSHOPERRead                            = 0x56,         // Arithmetic block shift and operation selection Read
    IPxARTSHOPERWrite                           = 0xD6,         // Arithmetic block shift and operation selection Write
    IPxARTSHRead                                = 0x57,         // Arithmetic block shift amount data Read
    IPxARTSHWrite                               = 0xD7,         // Arithmetic block shift amount data Write
    IPxARTSOURCERead                            = 0x58,         // Arithmetic block operand configure data Read
    IPxARTSOURCEWrite                           = 0xD8,         // Arithmetic block operand configure data Write
    IPxARTCRESULT1Read                          = 0x59,         // Arithmetic first compare result data Read
    IPxNoOperation_D9                           = 0xD9,         // No Operation
    IPxARTCRESULT2Read                          = 0x5A,         // Arithmetic second compare result data Read
    IPxNoOperation_DA                           = 0xDA,         // No Operation
    IPxARTARESULT1Read                          = 0x5B,         // Arithmetic first algebraic result data Read
    IPxNoOperation_DB                           = 0xDB,         // No Operation
    IPxARTARESULT2Read                          = 0x5C,         // Arithmetic second algebraic result data Read
    IPxNoOperation_DC                           = 0xDC,         // No operation
    IPxARTUSERARead                             = 0x5D,         // Arithmetic block User operand A Read
    IPxARTUSERAWrite                            = 0xDD,         // Arithmetic block User operand A Write
    IPxARTUSERBRead                             = 0x5E,         // Arithmetic block User operand B Read
    IPxARTUSERBWrite                            = 0xDE,         // Arithmetic block User operand B Write
    IPxARTUSERCRead                             = 0x5F,         // Arithmetic block User operand C Read
    IPxARTUSERCWrite                            = 0xDF,         // Arithmetic block User operand C Write

    // Scripter Group Register
    IPySCRCON1Read                              = 0x40,         // 스크립트 동작 설정 레지스터-1 READ, 32bit, 0x00000000
    IPySCRCON1Write                             = 0xC0,         // 스크립트 동작 설정 레지스터-1 WRITE
    IPySCRCON2Read                              = 0x41,         // 스크립트 동작 설정 레지스터-2 READ, 32bit, 0x00000000
    IPySCRCON2Write                             = 0xC1,         // 스크립트 동작 설정 레지스터-2 WRITE
    IPySCRCON3Read                              = 0x42,         // 스크립트 동작 설정 레지스터-3 READ, 32bit, 0x00000000 
    IPySCRCON3Write                             = 0xC2,         // 스크립트 동작 설정 레지스터-3 WRITE
    IPySCRCONQRead                              = 0x43,         // 스크립트 동작 설정 레지스터-Queue READ, 32bit, 0x00000000
    IPySCRCONQWrite                             = 0xC3,         // 스크립트 동작 설정 레지스터-Queue WRITE
    IPySCRDATA1Read                             = 0x44,         // 스크립트 동작 데이터 레지스터-1 READ, 32bit, 0x00000000 
    IPySCRDATA1Write                            = 0xC4,         // 스크립트 동작 데이터 레지스터-1 WRITE
    IPySCRDATA2Read                             = 0x45,         // 스크립트 동작 데이터 레지스터-2 READ, 32bit, 0x00000000 
    IPySCRDATA2Write                            = 0xC5,         // 스크립트 동작 데이터 레지스터-2 WRITE
    IPySCRDATA3Read                             = 0x46,         // 스크립트 동작 데이터 레지스터-3 READ, 32bit, 0x00000000 
    IPySCRDATA3Write                            = 0xC6,         // 스크립트 동작 데이터 레지스터-3 WRITE
    IPySCRDATAQRead                             = 0x47,         // 스크립트 동작 데이터 레지스터-Queue READ, 32bit, 0x00000000 
    IPySCRDATAQWrite                            = 0xC7,         // 스크립트 동작 데이터 레지스터-Queue WRITE
    IPyNoOperation_48                           = 0x48,         // No operation
    IPySCRQCLR                                  = 0xC8,         // 스크립트 Queue clear
    IPySCRCQSIZERead                            = 0x49,         // 스크립트 동작 설정 Queue 인덱스 READ, 4bit, 0x00
    IPyNoOperation_C9                           = 0xC9,         // No operation
    IPySCRDQSIZERead                            = 0x4A,         // 스크립트 동작 데이터 Queue 인덱스 READ, 4bit, 0x00
    IPyNoOperation_CA                           = 0xCA,         // No operation
    IPySCRQFLAGRead                             = 0x4B,         // 스크립트 Queue Full/Empty Flag READ, 4bit, 0x05
    IPyNoOperation_CB                           = 0xCB,         // No operation
    IPySCRQSIZECONRead                          = 0x4C,         // 스크립트 Queue size 설정(0~13) READ, 16bit, 0xD0D0
    IPySCRQSIZECONWrite                         = 0xCC,         // 스크립트 Queue size 설정(0~13) WRITE
    IPySCRQSTATUSRead                           = 0x4D,         // 스크립트 Queue status READ, 12bit, 0x005
    IPyNoOperation_CD                           = 0xCD,         // No operation
    IPyNoOperation_4E                           = 0x4E,         // No operation
    IPyNoOperation_CE                           = 0xCE,         // No operation
    IPyNoOperation_4F                           = 0x4F,         // No operation
    IPyNoOperation_CF                           = 0xCF,         // No operation

    /* Caption Group Register */
    IPyCAPCON1Read                              = 0x50,         // 갈무리 동작 설정 레지스터-1 READ, 32bit, 0x00000000
    IPyCAPCON1Write                             = 0xD0,         // 갈무리 동작 설정 레지스터-1 WRITE
    IPyCAPCON2Read                              = 0x51,         // 갈무리 동작 설정 레지스터-2 READ, 32bit, 0x00000000
    IPyCAPCON2Write                             = 0xD1,         // 갈무리 동작 설정 레지스터-2 WRITE
    IPyCAPCON3Read                              = 0x52,         // 갈무리 동작 설정 레지스터-3 READ, 32bit, 0x00000000 
    IPyCAPCON3Write                             = 0xD2,         // 갈무리 동작 설정 레지스터-3 WRITE
    IPyCAPCONQRead                              = 0x53,         // 갈무리 동작 설정 레지스터-Queue READ, 32bit, 0x00000000
    IPyCAPCONQWrite                             = 0xD3,         // 갈무리 동작 설정 레지스터-Queue WRITE
    IPyCAPDATA1Read                             = 0x54,         // 갈무리 동작 데이터 레지스터-1 READ, 32bit, 0x00000000 
    IPyNoOperation_D4                           = 0xD4,         // No operation
    IPyCAPDATA2Read                             = 0x55,         // 갈무리 동작 데이터 레지스터-2 READ, 32bit, 0x00000000 
    IPyNoOperation_D5                           = 0xD5,         // No operation
    IPyCAPDATA3Read                             = 0x56,         // 갈무리 동작 데이터 레지스터-3 READ, 32bit, 0x00000000 
    IPyNoOperation_D6                           = 0xD6,         // No operation
    IPyCAPDATAQRead                             = 0x57,         // 갈무리 동작 데이터 레지스터-Queue READ, 32bit, 0x00000000 
    IPyNoOperation_D7                           = 0xD7,         // No operation
    IPyNoOperation_58                           = 0x58,         // No operation
    IPyCAPQCLR                                  = 0xD8,         // 갈무리 Queue clear
    IPyCAPCQSIZERead                            = 0x59,         // 갈무리 동작 설정 Queue 인덱스 READ, 4bit, 0x00
    IPyNoOperation_D9                           = 0xD9,         // No operation
    IPyCAPDQSIZERead                            = 0x5A,         // 갈무리 동작 데이터 Queue 인덱스 READ, 4bit, 0x00
    IPyNoOperation_DA                           = 0xDA,         // No operation
    IPyCAPQFLAGRead                             = 0x5B,         // 갈무리 Queue Full/Empty Flag READ, 4bit, 0x05
    IPyNoOperation_DB                           = 0xDB,         // No operation
    IPyCAPQSIZECONRead                          = 0x5C,         // 갈무리 Queue size 설정(0~13) READ, 16bit, 0xD0D0
    IPyCAPQSIZECONWrite                         = 0xDC,         // 갈무리 Queue size 설정(0~13) WRITE
    IPyCAPQSTATUSRead                           = 0x5D,         // 갈무리 Queue status READ, 12bit, 0x005
    IPyNoOperation_DD                           = 0xDD,         // No operation
    IPyNoOperation_5E                           = 0x5E,         // No operation
    IPyNoOperation_DE                           = 0xDE,         // No operation
    IPyNoOperation_5F                           = 0x5F,         // No operation
    IPyNoOperation_DF                           = 0xDF,         // No operation

    // BUS - 1 Group Register
    IPxyINCNTRead                               = 0x60,         // INTERNAL COUNTER DATA READ(Signed), 32bit, 0x00000000
    IPxyINCNTWrite                              = 0xE0,         // INTERNAL COUNTER DATA WRITE(Signed)
    IPxyINCNTCMPRead                            = 0x61,         // INTERNAL COUNTER COMPARATE DATA READ(Signed), 32bit, 0x00000000
    IPxyINCNTCMPWrite                           = 0xE1,         // INTERNAL COUNTER COMPARATE DATA WRITE(Signed)
    IPxyINCNTSCALERead                          = 0x62,         // INTERNAL COUNTER PRE-SCALE DATA READ, 8bit, 0x00
    IPxyINCNTSCALEWrite                         = 0xE2,         // INTERNAL COUNTER PRE-SCALE DATA WRITE
    IPxyICPRead                                 = 0x63,         // INTERNAL COUNTER P-DATA READ, 32bit, 0x7FFFFFFF
    IPxyICPWrite                                = 0xE3,         // INTERNAL COUNTER P-DATA WRITE
    IPxyEXCNTRead                               = 0x64,         // EXTERNAL COUNTER DATA READ READ(Signed), 32bit, 0x00000000
    IPxyEXCNTWrite                              = 0xE4,         // EXTERNAL COUNTER DATA READ WRITE(Signed)
    IPxyEXCNTCMPRead                            = 0x65,         // EXTERNAL COUNTER COMPARATE DATA READ(Signed), 32bit, 0x00000000
    IPxyEXCNTCMPWrite                           = 0xE5,         // EXTERNAL COUNTER COMPARATE DATA WRITE(Signed)
    IPxyEXCNTSCALERead                          = 0x66,         // EXTERNAL COUNTER PRE-SCALE DATA READ, 8bit, 0x00
    IPxyEXCNTSCALEWrite                         = 0xE6,         // EXTERNAL COUNTER PRE-SCALE DATA WRITE
    IPxyEXPRead                                 = 0x67,         // EXTERNAL COUNTER P-DATA READ, 32bit, 0x7FFFFFFF
    IPxyEXPWrite                                = 0xE7,         // EXTERNAL COUNTER P-DATA WRITE
    IPxyEXSPDRead                               = 0x68,         // EXTERNAL SPEED DATA READ, 32bit, 0x00000000
    IPxyNoOperation_E8                          = 0xE8,         // No operation
    IPxyEXSPDCMPRead                            = 0x69,         // EXTERNAL SPEED COMPARATE DATA READ, 32bit, 0x00000000
    IPxyEXSPDCMPWrite                           = 0xE9,         // EXTERNAL SPEED COMPARATE DATA WRITE
    IPxyEXFILTERDRead                           = 0x6A,         // 외부 센서 필터 대역폭 설정 DATA READ, 32bit, 0x00050005
    IPxyEXFILTERDWrite                          = 0xEA,         // 외부 센서 필터 대역폭 설정 DATA WRITE
    IPxyOFFREGIONRead                           = 0x6B,         // OFF-RANGE DATA READ, 8bit, 0x00
    IPxyOFFREGIONWrite                          = 0xEB,         // OFF-RANGE DATA WRITE
    IPxyDEVIATIONRead                           = 0x6C,         // DEVIATION DATA READ, 16bit, 0x0000
    IPxyNoOperation_EC                          = 0xEC,         // No operation
    IPxyPGMCHRead                               = 0x6D,         // PGM REGISTER CHANGE DATA READ
    IPxyPGMCHWrite                              = 0xED,         // PGM REGISTER CHANGE DATA WRITE
    IPxyCOMPCONRead                             = 0x6E,         // COMPARE REGISTER INPUT CHANGE DATA READ
    IPxyCOMPCONWrite                            = 0xEE,         // COMPARE REGISTER INPUT CHANGE DATA WRITE
    IPxyNoOperation_6F                          = 0x6F,         // No operation
    IPxyNoOperation_EF                          = 0xEF,         // No operation

    // BUS - 2 Group Register
    IPxyFUNCONRead                              = 0x70,         // 칩 기능 설정 DATA READ,
    IPxyFUNCONWrite                             = 0xF0,         // 칩 기능 설정 DATA WRITE
    IPxyMODE1Read                               = 0x71,         // MODE1 DATA READ,
    IPxyMODE1Write                              = 0xF1,         // MODE1 DATA WRITE
    IPxyMODE2Read                               = 0x72,         // MODE2 DATA READ,
    IPxyMODE2Write                              = 0xF2,         // MODE2 DATA WRITE
    IPxyUIODATARead                             = 0x73,         // UNIVERSAL IN READ,
    IPxyUIODATAWrite                            = 0xF3,         // UNIVERSAL OUT WRITE
    IPxyENDSTATUSRead                           = 0x74,         // END STATUS DATA READ,
    IPxyCLIMCLR                                 = 0xF4,         // Complete limit stop clear command
    IPxyMECHRead                                = 0x75,         // MECHANICAL SIGNAL DATA READ, 13bit
    IPxyNoOperation_F5                          = 0xF5,         // No operation
    IPxyDRVSTATUSRead                           = 0x76,         // DRIVE STATE DATA READ, 9bit
    IPxyNoOperation_F6                          = 0xF6,         // No operation
    IPxyEXCNTCLRRead                            = 0x77,         // EXTERNAL COUNTER 설정 DATA READ, 9bit, 0x00
    IPxyEXCNTCLRWrite                           = 0xF7,         // EXTERNAL COUNTER 설정 DATA WRITE
    IPxyNoOperation_78                          = 0x78,         // No operation
    IPxySWRESET                                 = 0xF8,         // REGISTER CLEAR(INITIALIZATION), Software reset
    IPxyINTFLAG1Read                            = 0x79,         // Interrupt Flag1 READ, 32bit, 0x00000000
    IPxyINTFLAG1CLR                             = 0xF9,         // Interrupt Flag1 Clear data write command.
    IPxyINTMASK1Read                            = 0x7A,         // Interrupt Mask1 READ, 32bit, 0x00000001
    IPxyINTMASK1Write                           = 0xFA,         // Interrupt Mask1 WRITE
    IPxyUIOMODERead                             = 0x7B,         // UIO MODE DATA READ, 12bit, 0x01F
    IPxyUIOMODEWrite                            = 0xFB,         // UIO MODE DATA WRITE
    IPxyINTFLAG2Read                            = 0x7C,         // Interrupt Flag2 READ, 32bit, 0x00000000
    IPxyINTFLAG2CLRWrite                        = 0xFC,         // Interrupt Flag2 Clear data write command.
    IPxyINTMASK2Read                            = 0x7D,         // Interrupt Mask2 READ, 32bit, 0x00000001
    IPxyINTMASK2Write                           = 0xFD,         // Interrupt Mask2 WRITE
    IPxyINTUSERCONRead                          = 0x7E,         // User interrupt selection control.
    IPxyINTUSERCONWrite                         = 0xFE,         // User interrupt selection control. 
    IPxyNoOperation_7F                          = 0x7F,         // No operation
    IPxyINTGENCMD                               = 0xFF          // Interrupt generation command.
}

// FS EVENT LIST
public enum FSEVENT:uint
{
    EVENT_NONE                                  = 0x00,         // 검출사항 없음
    EVENT_DRIVE_END                             = 0x01,         // 드라이브 종료
    EVENT_PRESETDRIVE_START                     = 0x02,         // 지정펄스 수 드라이브 시작
    EVENT_PRESETDRIVE_END                       = 0x03,         // 지정펄스 수 드라이브 종료
    EVENT_CONTINOUSDRIVE_START                  = 0x04,         // 연속 드라이브 시작
    EVENT_CONTINOUSDRIVE_END                    = 0x05,         // 연속 드라이브 종료
    EVENT_SIGNAL_SEARCH_1_START                 = 0x06,         // 신호 검출-1 드라이브 시작
    EVENT_SIGNAL_SEARCH_1_END                   = 0x07,         // 신호 검출-1 드라이브 종료
    EVENT_SIGNAL_SEARCH_2_START                 = 0x08,         // 신호 검출-2 드라이브 시작
    EVENT_SIGNAL_SEARCH_2_END                   = 0x09,         // 신호 검출-2 드라이브 종료
    EVENT_ORIGIN_DETECT_START                   = 0x0A,         // 원점검출 드라이브 시작
    EVENT_ORIGIN_DETECT_END                     = 0x0B,         // 원점검출 드라이브 종료
    EVENT_SPEED_UP                              = 0x0C,         // 가속
    EVENT_SPEED_CONST                           = 0x0D,         // 등속
    EVENT_SPEED_DOWN                            = 0x0E,         // 감속
    EVENT_ICG                                   = 0x0F,         // 내부위치카운터 > 내부위치비교값
    EVENT_ICE                                   = 0x10,         // 내부위치카운터 = 내부위치비교값
    EVENT_ICL                                   = 0x11,         // 내부위치카운터 < 내부위치비교값
    EVENT_ECG                                   = 0x12,         // 외부위치카운터 > 외부위치비교값
    EVENT_ECE                                   = 0x13,         // 외부위치카운터 = 외부위치비교값
    EVENT_ECL                                   = 0x14,         // 외부위치카운터 < 외부위치비교값
    EVENT_EPCG                                  = 0x15,         // 외부펄스카운터 > 외부펄스카운터비교값
    EVENT_EPCE                                  = 0x16,         // 외부펄스카운터 = 외부펄스카운터비교값
    EVENT_EPCL                                  = 0x17,         // 외부펄스카운터 < 외부펄스카운터비교값
    EVENT_SPG                                   = 0x18,         // 현재속도데이터 > 현재속도비교데이터
    EVENT_SPE                                   = 0x19,         // 현재속도데이터 = 현재속도비교데이터
    EVENT_SPL                                   = 0x1A,         // 현재속도데이터 < 현재속도비교데이터
    EVENT_SP12G                                 = 0x1B,         // 현재속도데이터 > Rate Change Point 1-2
    EVENT_SP12E                                 = 0x1C,         // 현재속도데이터 = Rate Change Point 1-2
    EVENT_SP12L                                 = 0x1D,         // 현재속도데이터 < Rate Change Point 1-2
    EVENT_SP23G                                 = 0x1E,         // 현재속도데이터 > Rate Change Point 2-3
    EVENT_SP23E                                 = 0x1F,         // 현재속도데이터 = Rate Change Point 2-3
    EVENT_SP23L                                 = 0x20,         // 현재속도데이터 < Rate Change Point 2-3
    EVENT_OBJECT_SPEED                          = 0x21,         // 현재속도데이터 = 목표속도데이터
    EVENT_SS_SPEED                              = 0x22,         // 현재속도데이터 = 시작속도데이터
    EVENT_ESTOP                                 = 0x23,         // 급속정지
    EVENT_SSTOP                                 = 0x24,         // 감속정지
    EVENT_PELM                                  = 0x25,         // +Emergency Limit 신호 입력
    EVENT_NELM                                  = 0x26,         // -Emergency Limit 신호 입력
    EVENT_PSLM                                  = 0x27,         // +Slow Down Limit 신호 입력
    EVENT_NSLM                                  = 0x28,         // -Slow Down Limit 신호 입력
    EVENT_DEVIATION_ERROR                       = 0x29,         // 탈조 에러 발생
    EVENT_DATA_ERROR                            = 0x2A,         // 데이터 설정 에러 발생
    EVENT_ALARM_ERROR                           = 0x2B,         // Alarm 신호 입력
    EVENT_ESTOP_COMMAND                         = 0x2C,         // 급속 정지 명령 실행
    EVENT_SSTOP_COMMAND                         = 0x2D,         // 감속 정지 명령 실행
    EVENT_ESTOP_SIGNAL                          = 0x2E,         // 급속 정지 신호 입력
    EVENT_SSTOP_SIGNAL                          = 0x2F,         // 감속 정지 신호 입력
    EVENT_ELM                                   = 0x30,         // Emergency Limit 신호 입력
    EVENT_SLM                                   = 0x31,         // Slow Down Limit 신호 입력
    EVENT_INPOSITION                            = 0x32,         // Inposition 신호 입력
    EVENT_IN0_HIGH                              = 0x33,         // IN0 High 신호 입력
    EVENT_IN0_LOW                               = 0x34,         // IN0 Low  신호 입력
    EVENT_IN1_HIGH                              = 0x35,         // IN1 High 신호 입력
    EVENT_IN1_LOW                               = 0x36,         // IN1 Low  신호 입력
    EVENT_IN2_HIGH                              = 0x37,         // IN2 High 신호 입력
    EVENT_IN2_LOW                               = 0x38,         // IN2 Low  신호 입력
    EVENT_IN3_HIGH                              = 0x39,         // IN3 High 신호 입력
    EVENT_IN3_LOW                               = 0x3A,         // IN3 Low  신호 입력
    EVENT_OUT0_HIGH                             = 0x3B,         // OUT0 High 신호 입력
    EVENT_OUT0_LOW                              = 0x3C,         // OUT0 Low  신호 입력
    EVENT_OUT1_HIGH                             = 0x3D,         // OUT1 High 신호 입력
    EVENT_OUT1_LOW                              = 0x3E,         // OUT1 Low  신호 입력
    EVENT_OUT2_HIGH                             = 0x3F,         // OUT2 High 신호 입력
    EVENT_OUT2_LOW                              = 0x40,         // OUT2 Low  신호 입력
    EVENT_OUT3_HIGH                             = 0x41,         // OUT3 High 신호 입력
    EVENT_OUT3_LOW                              = 0x42,         // OUT3 Low  신호 입력
    EVENT_SENSOR_DRIVE1_START                   = 0x43,         // Sensor Positioning drive I 시작
    EVENT_SENSOR_DRIVE1_END                     = 0x44,         // Sensor Positioning drive I 종료
    EVENT_SENSOR_DRIVE2_START                   = 0x45,         // Sensor Positioning drive II 시작
    EVENT_SENSOR_DRIVE2_END                     = 0x46,         // Sensor Positioning drive II 종료
    EVENT_SENSOR_DRIVE3_START                   = 0x47,         // Sensor Positioning drive III 시작
    EVENT_SENSOR_DRIVE3_END                     = 0x48,         // Sensor Positioning drive III 종료
    EVENT_1STCOUNTER_NDATA_CLEAR                = 0x49,         // 1'st counter N-data count clear
    EVENT_2NDCOUNTER_NDATA_CLEAR                = 0x4A,         // 2'nd counter N-data count clear
    EVENT_MARK_SIGNAL_HIGH                      = 0x4B,         // Mark# signal high
    EVENT_MARK_SIGNAL_LOW                       = 0x4C,         // Mark# signal low
    EVENT_EUIO0_HIGH                            = 0x4D,         // EUIO0 High 신호 입력
    EVENT_EUIO0_LOW                             = 0x4E,         // EUIO0 Low  신호 입력
    EVENT_EUIO1_HIGH                            = 0x4F,         // EUIO1 High 신호 입력
    EVENT_EUIO1_LOW                             = 0x50,         // EUIO1 Low  신호 입력
    EVENT_EUIO2_HIGH                            = 0x51,         // EUIO2 High 신호 입력
    EVENT_EUIO2_LOW                             = 0x52,         // EUIO2 Low  신호 입력
    EVENT_EUIO3_HIGH                            = 0x53,         // EUIO3 High 신호 입력
    EVENT_EUIO3_LOW                             = 0x54,         // EUIO3 Low  신호 입력
    EVENT_EUIO4_HIGH                            = 0x55,         // EUIO4 High 신호 입력
    EVENT_EUIO4_LOW                             = 0x56,         // EUIO4 Low  신호 입력
    EVENT_SOFTWARE_PLIMIT                       = 0x57,         // +Software Limit
    EVENT_SOFTWARE_NLIMIT                       = 0x58,         // -Software Limit
    EVENT_SOFTWARE_LIMIT                        = 0x59,         // Software Limit
    EVENT_TRIGGER_ENABLE                        = 0x5A,         // Trigger enable
    EVENT_INT_GEN_SOURCE                        = 0x5B,         // Interrupt Generated by any source
    EVENT_INT_GEN_CMDF9                         = 0x5C,         // Interrupt Generated by Command "F9"
    EVENT_PRESETDRIVE_TRI_START                 = 0x5D,         // Preset 삼각구동 시작
    EVENT_BUSY_HIGH                             = 0x5E,         // 드라이브 busy High
    EVENT_BUSY_LOW                              = 0x5F,         // 드라이브 busy Low
    EVENT_UNCONDITIONAL_RUN                     = 0xFF,         // 무조건 수행(Queue command 한정)
}

// IP EVENT LIST
public enum IPEVENT:uint
{
    EVENT_IPNONE                                = 0x00,         // 검출사항 없음
    EVENT_IPDRIVE_END                           = 0x01,         // 드라이브 종료
    EVENT_IPPRESETDRIVE_START                   = 0x02,         // 지정펄스 수 드라이브 시작
    EVENT_IPPRESETDRIVE_END                     = 0x03,         // 지정펄스 수 드라이브 종료
    EVENT_IPCONTINOUSDRIVE_START                = 0x04,         // 연속 드라이브 시작
    EVENT_IPCONTINOUSDRIVE_END                  = 0x05,         // 연속 드라이브 종료
    EVENT_IPSIGNAL_SEARCH_1_START               = 0x06,         // 신호 검출-1 드라이브 시작
    EVENT_IPSIGNAL_SEARCH_1_END                 = 0x07,         // 신호 검출-1 드라이브 종료
    EVENT_IPSIGNAL_SEARCH_2_START               = 0x08,         // 신호 검출-2 드라이브 시작
    EVENT_IPSIGNAL_SEARCH_2_END                 = 0x09,         // 신호 검출-2 드라이브 종료
    EVENT_IPORIGIN_DETECT_START                 = 0x0A,         // 원점검출 드라이브 시작
    EVENT_IPORIGIN_DETECT_END                   = 0x0B,         // 원점검출 드라이브 종료
    EVENT_IPSPEED_UP                            = 0x0C,         // 가속
    EVENT_IPSPEED_CONST                         = 0x0D,         // 등속
    EVENT_IPSPEED_DOWN                          = 0x0E,         // 감속
    EVENT_IPICL                                 = 0x0F,         // 내부위치카운터 < 내부위치비교값
    EVENT_IPICE                                 = 0x10,         // 내부위치카운터 = 내부위치비교값
    EVENT_IPICG                                 = 0x11,         // 내부위치카운터 > 내부위치비교값
    EVENT_IPECL                                 = 0x12,         // 외부위치카운터 < 외부위치비교값
    EVENT_IPECE                                 = 0x13,         // 외부위치카운터 = 외부위치비교값
    EVENT_IPECG                                 = 0x14,         // 외부위치카운터 > 외부위치비교값
    EVENT_IPEPCE                                = 0x15,         // 외부펄스카운터 = 외부펄스카운터비교값
    EVENT_IPEPCL                                = 0x16,         // 외부펄스카운터 < 외부펄스카운터비교값
    EVENT_IPEPCG                                = 0x17,         // 외부펄스카운터 > 외부펄스카운터비교값
    EVENT_IPSPL                                 = 0x18,         // 현재속도데이터 < 현재속도비교데이터
    EVENT_IPSPE                                 = 0x19,         // 현재속도데이터 = 현재속도비교데이터
    EVENT_IPSPG                                 = 0x1A,         // 현재속도데이터 > 현재속도비교데이터
    EVENT_IPSP12L                               = 0x1B,         // 현재속도데이터 < Rate Change Point 1-2
    EVENT_IPSP12E                               = 0x1C,         // 현재속도데이터 = Rate Change Point 1-2
    EVENT_IPSP12G                               = 0x1D,         // 현재속도데이터 > Rate Change Point 1-2
    EVENT_IPSP23L                               = 0x1E,         // 현재속도데이터 < Rate Change Point 2-3
    EVENT_IPSP23E                               = 0x1F,         // 현재속도데이터 = Rate Change Point 2-3
    EVENT_IPSP23G                               = 0x20,         // 현재속도데이터 > Rate Change Point 2-3
    EVENT_IPOBJECT_SPEED                        = 0x21,         // 현재속도데이터 = 목표속도데이터
    EVENT_IPSS_SPEED                            = 0x22,         // 현재속도데이터 = 시작속도데이터
    EVENT_IPESTOP                               = 0x23,         // 급속정지
    EVENT_IPSSTOP                               = 0x24,         // 감속정지
    EVENT_IPPELM                                = 0x25,         // +Emergency Limit 신호 입력
    EVENT_IPNELM                                = 0x26,         // -Emergency Limit 신호 입력
    EVENT_IPPSLM                                = 0x27,         // +Slow Down Limit 신호 입력
    EVENT_IPNSLM                                = 0x28,         // -Slow Down Limit 신호 입력
    EVENT_IPDEVIATION_ERROR                     = 0x29,         // 탈조 에러 발생
    EVENT_IPDATA_ERROR                          = 0x2A,         // 데이터 설정 에러 발생
    EVENT_IPALARM_ERROR                         = 0x2B,         // Alarm 신호 입력
    EVENT_IPESTOP_COMMAND                       = 0x2C,         // 급속 정지 명령 실행
    EVENT_IPSSTOP_COMMAND                       = 0x2D,         // 감속 정지 명령 실행
    EVENT_IPESTOP_SIGNAL                        = 0x2E,         // 급속 정지 신호 입력
    EVENT_IPSSTOP_SIGNAL                        = 0x2F,         // 감속 정지 신호 입력
    EVENT_IPELM                                 = 0x30,         // Emergency Limit 신호 입력
    EVENT_IPSLM                                 = 0x31,         // Slow Down Limit 신호 입력
    EVENT_IPINPOSITION                          = 0x32,         // Inposition 신호 입력
    EVENT_IPINOUT0_HIGH                         = 0x33,         // IN/OUT0 High 신호 입력
    EVENT_IPINOUT0_LOW                          = 0x34,         // IN/OUT0 Low  신호 입력
    EVENT_IPINOUT1_HIGH                         = 0x35,         // IN/OUT1 High 신호 입력
    EVENT_IPINOUT1_LOW                          = 0x36,         // IN/OUT1 Low  신호 입력
    EVENT_IPINOUT2_HIGH                         = 0x37,         // IN/OUT2 High 신호 입력
    EVENT_IPINOUT2_LOW                          = 0x38,         // IN/OUT2 Low  신호 입력
    EVENT_IPINOUT3_HIGH                         = 0x39,         // IN/OUT3 High 신호 입력
    EVENT_IPINOUT3_LOW                          = 0x3A,         // IN/OUT3 Low  신호 입력
    EVENT_IPINOUT4_HIGH                         = 0x3B,         // IN/OUT4 High 신호 입력
    EVENT_IPINOUT4_LOW                          = 0x3C,         // IN/OUT4 Low  신호 입력
    EVENT_IPINOUT5_HIGH                         = 0x3D,         // IN/OUT5 High 신호 입력
    EVENT_IPINOUT5_LOW                          = 0x3E,         // IN/OUT5 Low  신호 입력
    EVENT_IPINOUT6_HIGH                         = 0x3F,         // IN/OUT6 High 신호 입력
    EVENT_IPINOUT6_LOW                          = 0x40,         // IN/OUT6 Low  신호 입력
    EVENT_IPINOUT7_HIGH                         = 0x41,         // IN/OUT7 High 신호 입력
    EVENT_IPINOUT7_LOW                          = 0x42,         // IN/OUT7 Low  신호 
    EVENT_IPINOUT8_HIGH                         = 0x43,         // IN/OUT8 High 신호 입력
    EVENT_IPINOUT8_LOW                          = 0x44,         // IN/OUT8 Low  신호 입력
    EVENT_IPINOUT9_HIGH                         = 0x45,         // IN/OUT9 High 신호 입력
    EVENT_IPINOUT9_LOW                          = 0x46,         // IN/OUT9 Low  신호 입력
    EVENT_IPINOUT10_HIGH                        = 0x47,         // IN/OUT10 High 신호 입력
    EVENT_IPINOUT10_LOW                         = 0x48,         // IN/OUT10 Low  신호 입력
    EVENT_IPINOUT11_HIGH                        = 0x49,         // IN/OUT11 High 신호 입력
    EVENT_IPINOUT11_LOW                         = 0x4A,         // IN/OUT11 Low  신호     
    EVENT_IPSENSOR_DRIVE1_START                 = 0x4B,         // Sensor Positioning drive I 시작
    EVENT_IPSENSOR_DRIVE1_END                   = 0x4C,         // Sensor Positioning drive I 종료
    EVENT_IPSENSOR_DRIVE2_START                 = 0x4D,         // Sensor Positioning drive II 시작
    EVENT_IPSENSOR_DRIVE2_END                   = 0x4E,         // Sensor Positioning drive II 종료
    EVENT_IPSENSOR_DRIVE3_START                 = 0x4F,         // Sensor Positioning drive III 시작
    EVENT_IPSENSOR_DRIVE3_END                   = 0x50,         // Sensor Positioning drive III 종료
    EVENT_IP1STCOUNTER_NDATA_CLEAR              = 0x51,         // 1'st counter N-data count clear
    EVENT_IP2NDCOUNTER_NDATA_CLEAR              = 0x52,         // 2'nd counter N-data count clear
    EVENT_IPMARK_SIGNAL_HIGH                    = 0x53,         // Mark# signal high
    EVENT_IPMARK_SIGNAL_LOW                     = 0x54,         // Mark# signal low
    EVENT_IPSOFTWARE_PLIMIT                     = 0x55,         // +Software Limit
    EVENT_IPSOFTWARE_NLIMIT                     = 0x56,         // -Software Limit
    EVENT_IPSOFTWARE_LIMIT                      = 0x57,         // Software Limit
    EVENT_IPTRIGGER_ENABLE                      = 0x58,         // Trigger enable
    EVENT_IPINT_GEN_SOURCE                      = 0x59,         // Interrupt Generated by any source
    EVENT_IPINT_GEN_CMDF9                       = 0x5A,         // Interrupt Generated by Command "FF"
    EVENT_IPPRESETDRIVE_TRI_START               = 0x5B,         // Preset 삼각구동 시작
    EVENT_IPBUSY_HIGH                           = 0x5C,         // 드라이브 busy High
    EVENT_IPBUSY_LOW                            = 0x5D,         // 드라이브 busy Low

    EVENT_IPLINP_START                          = 0x5E,         // 단위 직선 보간 시작
    EVENT_IPLINP_END                            = 0x5F,         // 단위 직선 보간 종료

    EVENT_IPCINP_START                          = 0x60,         // 단위 원호 보간 시작
    EVENT_IPCINP_END                            = 0x61,         // 단위 원호 보간 종료
    EVENT_IPPINP_START                          = 0x62,         // 패턴 보간 시작
    EVENT_IPPINP_END                            = 0x63,         // 패턴 보간 종료
    EVENT_IPPDATA_Q_EMPTY                       = 0x64,         // 패턴 보간 데이타 큐 비었음
    EVENT_IPS_C_INTERNAL_COMMAND_Q_EMPTY        = 0x65,         // 스크립트/캡션 내부 명령어 큐 비었음
    EVENT_IPS_C_INTERNAL_COMMAND_Q_FULL         = 0x66,         // 스크립트/캡션 내부 명령어 큐 가득참
    EVENT_IPxSYNC_ACTIVATED                     = 0x67,         // xSYNC 신호 입력 High
    EVENT_IPySYNC_ACTIVATED                     = 0x68,         // ySYNC 신호 입력 High
    EVENT_IPINTERRUPT_GENERATED                 = 0x69,         // X 축 또는 Y 축에서 인터럽트 발생
    EVENT_IPINP_START                           = 0x6A,         // 보간 시작(원호, 직선, 패턴)
    EVENT_IPINP_END                             = 0x6B,         // 보간 종료(원호, 직선, 패턴)
    EVENT_IPALGEBRIC_RESULT_BIT0                = 0x6C,         // 연산 기능 블럭 연산 출력 결과 0 bit High
    EVENT_IPALGEBRIC_RESULT_BIT1                = 0x6D,         // 연산 기능 블럭 연산 출력 결과 1 bit High
    EVENT_IPALGEBRIC_RESULT_BIT2                = 0x6E,         // 연산 기능 블럭 연산 출력 결과 2 bit High
    EVENT_IPALGEBRIC_RESULT_BIT3                = 0x6F,         // 연산 기능 블럭 연산 출력 결과 3 bit High
    EVENT_IPALGEBRIC_RESULT_BIT4                = 0x70,         // 연산 기능 블럭 연산 출력 결과 4 bit High
    EVENT_IPALGEBRIC_RESULT_BIT5                = 0x71,         // 연산 기능 블럭 연산 출력 결과 5 bit High
    EVENT_IPALGEBRIC_RESULT_BIT6                = 0x72,         // 연산 기능 블럭 연산 출력 결과 6 bit High
    EVENT_IPALGEBRIC_RESULT_BIT7                = 0x73,         // 연산 기능 블럭 연산 출력 결과 7 bit High
    EVENT_IPALGEBRIC_RESULT_BIT8                = 0x74,         // 연산 기능 블럭 연산 출력 결과 8 bit High
    EVENT_IPALGEBRIC_RESULT_BIT9                = 0x75,         // 연산 기능 블럭 연산 출력 결과 9 bit High
    EVENT_IPALGEBRIC_RESULT_BIT10               = 0x76,         // 연산 기능 블럭 연산 출력 결과 10 bit High
    EVENT_IPALGEBRIC_RESULT_BIT11               = 0x77,         // 연산 기능 블럭 연산 출력 결과 11 bit High
    EVENT_IPALGEBRIC_RESULT_BIT12               = 0x78,         // 연산 기능 블럭 연산 출력 결과 12 bit High
    EVENT_IPALGEBRIC_RESULT_BIT13               = 0x79,         // 연산 기능 블럭 연산 출력 결과 13 bit High
    EVENT_IPALGEBRIC_RESULT_BIT14               = 0x7A,         // 연산 기능 블럭 연산 출력 결과 14 bit High
    EVENT_IPALGEBRIC_RESULT_BIT15               = 0x7B,         // 연산 기능 블럭 연산 출력 결과 15 bit High
    EVENT_IPALGEBRIC_RESULT_BIT16               = 0x7C,         // 연산 기능 블럭 연산 출력 결과 16 bit High
    EVENT_IPALGEBRIC_RESULT_BIT17               = 0x7D,         // 연산 기능 블럭 연산 출력 결과 17 bit High
    EVENT_IPALGEBRIC_RESULT_BIT18               = 0x7E,         // 연산 기능 블럭 연산 출력 결과 18 bit High
    EVENT_IPALGEBRIC_RESULT_BIT19               = 0x7F,         // 연산 기능 블럭 연산 출력 결과 19 bit High

    EVENT_IPALGEBRIC_RESULT_BIT20               = 0x80,         // 연산 기능 블럭 연산 출력 결과 20 bit High
    EVENT_IPALGEBRIC_RESULT_BIT21               = 0x81,         // 연산 기능 블럭 연산 출력 결과 21 bit High
    EVENT_IPALGEBRIC_RESULT_BIT22               = 0x82,         // 연산 기능 블럭 연산 출력 결과 22 bit High
    EVENT_IPALGEBRIC_RESULT_BIT23               = 0x83,         // 연산 기능 블럭 연산 출력 결과 23 bit High
    EVENT_IPALGEBRIC_RESULT_BIT24               = 0x84,         // 연산 기능 블럭 연산 출력 결과 24 it High
    EVENT_IPALGEBRIC_RESULT_BIT25               = 0x85,         // 연산 기능 블럭 연산 출력 결과 25 bit High
    EVENT_IPALGEBRIC_RESULT_BIT26               = 0x86,         // 연산 기능 블럭 연산 출력 결과 26 bit High
    EVENT_IPALGEBRIC_RESULT_BIT27               = 0x87,         // 연산 기능 블럭 연산 출력 결과 27 bit High
    EVENT_IPALGEBRIC_RESULT_BIT28               = 0x88,         // 연산 기능 블럭 연산 출력 결과 28 bit High
    EVENT_IPALGEBRIC_RESULT_BIT29               = 0x89,         // 연산 기능 블럭 연산 출력 결과 29 bit High
    EVENT_IPALGEBRIC_RESULT_BIT30               = 0x8A,         // 연산 기능 블럭 연산 출력 결과 30 bit High
    EVENT_IPALGEBRIC_RESULT_BIT31               = 0x8B,         // 연산 기능 블럭 연산 출력 결과 31 bit High
    EVENT_IPCOMPARE_RESULT_BIT0                 = 0x8C,         // 연산 기능 블럭 비교 출력 결과 0 bit High
    EVENT_IPCOMPARE_RESULT_BIT1                 = 0x8D,         // 연산 기능 블럭 비교 출력 결과 1 bit High
    EVENT_IPCOMPARE_RESULT_BIT2                 = 0x8E,         // 연산 기능 블럭 비교 출력 결과 2 bit High
    EVENT_IPCOMPARE_RESULT_BIT3                 = 0x8F,         // 연산 기능 블럭 비교 출력 결과 3 bit High
    EVENT_IPCOMPARE_RESULT_BIT4                 = 0x90,         // 연산 기능 블럭 비교 출력 결과 4 bit High
    EVENT_IPON_INTERPOLATION                    = 0x91,         // 보간 드라이버 중
    EVENT_IPON_LINEAR_INTERPOLATION             = 0x92,         // 직선 보간 드라이버 중
    EVENT_IPON_CIRCULAR_INTERPOLATION           = 0x93,         // 원호 보간 드라이버 중
    EVENT_IPON_PATTERN_INTERPOLATION            = 0x94,         // 패턴 보간 드라이버 중
    EVENT_IPNONE_95                             = 0x95,         // 검출 사항 없음
    EVENT_IPL_C_INP_Q_EMPTY                     = 0x96,         // 직선/원호보간 큐가 비었음
    EVENT_IPL_C_INP_Q_LESS_4                    = 0x97,         // 직선/원호보간 큐가 4 미만임
    EVENT_IPP_INP_Q_EMPTY                       = 0x98,         // 패턴 보간 큐가 비었음
    EVENT_IPP_INP_Q_LESS_4                      = 0x99,         // 패턴 보간 큐가 4 미만임
    EVENT_IPINTERPOLATION_PAUSED                = 0x9A,         // 보간 드라이버가 Pause 됨
    EVENT_IPP_INP_END_BY_END_PATTERN            = 0x9B,         // 패턴 보간 드라이버중 종료 패턴을 만남
    EVENT_IPARITHMETIC_DATA_SEL                 = 0xEE,         // 스크립트 1-3번 두번째 이벤트로 사용
    // 스크립트 입력 데이타로 연산블럭 출력값을 사용
    // 이벤트 연산 "00" 일때 유효
    EVENT_IPEXECUTION_ALWAYS                    = 0xFF          // 무조건 수행(스크립트/캡션 4번(큐)에 한정)
}

// FS Universal Input/Output
public enum FSUNIVERSAL_SIGNAL:uint
{
    FSUS_OUT0                                   = 0x0001,       // Bit 0
    FSUS_SVON                                   = 0x0001,       // Bit 0, Servo ON
    FSUS_OUT1                                   = 0x0002,       // Bit 1
    FSUS_ALMC                                   = 0x0002,       // Bit 1, Alarm Clear
    FSUS_OUT2                                   = 0x0004,       // Bit 2
    FSUS_OUT3                                   = 0x0008,       // Bit 3
    FSUS_IN0                                    = 0x0010,       // Bit 4
    FSUS_ORG                                    = 0x0010,       // Bit 4, Origin
    FSUS_IN1                                    = 0x0020,       // Bit 5
    FSUS_PZ                                     = 0x0020,       // Bit 5, Encoder Z상
    FSUS_IN2                                    = 0x0040,       // Bit 6
    FSUS_IN3                                    = 0x0080,       // Bit 7

    // [V2.0이상]
    FSUS_OPCODE0                                = 0x0100,       // Bit 8
    FSUS_OPCODE1                                = 0x0200,       // Bit 9
    FSUS_OPCODE2                                = 0x0400,       // Bit 10
    FSUS_OPDATA0                                = 0x0800,       // Bit 11
    FSUS_OPDATA1                                = 0x1000,       // Bit 12
    FSUS_OPDATA2                                = 0x2000,       // Bit 13
    FSUS_OPDATA3                                = 0x4000        // Bit 14
}

// IP Universal Input/Output
public enum IPUNIVERSAL_SIGNAL:uint
{
    IPUS_OUT0                                   = 0x0001,       // Bit 0
    IPUS_SVON                                   = 0x0001,       // Bit 0, Servo ON
    IPUS_OUT1                                   = 0x0002,       // Bit 1
    IPUS_ALMC                                   = 0x0002,       // Bit 1, Alarm Clear
    IPUS_OUT2                                   = 0x0004,       // Bit 2
    IPUS_OUT3                                   = 0x0008,       // Bit 3
    IPUS_OUT4                                   = 0x0010,       // Bit 4
    IPUS_CLR                                    = 0x0010,       // Bit 4
    IPUS_IN0                                    = 0x0020,       // Bit 5
    IPUS_ORG                                    = 0x0020,       // Bit 5, Origin
    IPUS_IN1                                    = 0x0040,       // Bit 6
    IPUS_PZ                                     = 0x0040,       // Bit 6, Encoder Z상
    IPUS_IN2                                    = 0x0080,       // Bit 7
    IPUS_IN3                                    = 0x0100,       // Bit 8
    IPUS_IN4                                    = 0x0200,       // Bit 9, PSLM 연결
    IPUS_IN5                                    = 0x0400,       // Bit 10. NSLM 연결
    IPUS_IN6                                    = 0x0800,       // Bit 11. SSTOP 연결

    IPUS_OPCODE0                                = 0x1000,       // Bit 12
    IPUS_OPCODE1                                = 0x2000,       // Bit 13
    IPUS_OPCODE2                                = 0x4000        // Bit 14
}

public enum IPINTERRUPT_BANK1:uint
{
    IPINTBANK1_DONTUSE                          = 0x00000000,   // INTERRUT DISABLED.
    IPINTBANK1_DRIVE_END                        = 0x00000001,   // Bit 0, Drive end(default value : 1).
    IPINTBANK1_ICG                              = 0x00000002,   // Bit 1, INCNT is greater than INCNTCMP.
    IPINTBANK1_ICE                              = 0x00000004,   // Bit 2, INCNT is equal with INCNTCMP.
    IPINTBANK1_ICL                              = 0x00000008,   // Bit 3, INCNT is less than INCNTCMP.
    IPINTBANK1_ECG                              = 0x00000010,   // Bit 4, EXCNT is greater than EXCNTCMP.
    IPINTBANK1_ECE                              = 0x00000020,   // Bit 5, EXCNT is equal with EXCNTCMP.
    IPINTBANK1_ECL                              = 0x00000040,   // Bit 6, EXCNT is less than EXCNTCMP.
    IPINTBANK1_SCRQEMPTY                        = 0x00000080,   // Bit 7, Script control queue is empty.
    IPINTBANK1_CAPRQEMPTY                       = 0x00000100,   // Bit 8, Caption result data queue is empty.
    IPINTBANK1_SCRREG1EXE                       = 0x00000200,   // Bit 9, Script control register-1 command is executed.
    IPINTBANK1_SCRREG2EXE                       = 0x00000400,   // Bit 10, Script control register-2 command is executed.
    IPINTBANK1_SCRREG3EXE                       = 0x00000800,   // Bit 11, Script control register-3 command is executed.
    IPINTBANK1_CAPREG1EXE                       = 0x00001000,   // Bit 12, Caption control register-1 command is executed.
    IPINTBANK1_CAPREG2EXE                       = 0x00002000,   // Bit 13, Caption control register-2 command is executed.
    IPINTBANK1_CAPREG3EXE                       = 0x00004000,   // Bit 14, Caption control register-3 command is executed.
    IPINTBANK1_INTGGENCMD                       = 0x00008000,   // Bit 15, Interrupt generation command is executed(0xFF)
    IPINTBANK1_DOWN                             = 0x00010000,   // Bit 16, At starting point for deceleration drive.
    IPINTBANK1_CONT                             = 0x00020000,   // Bit 17, At starting point for constant speed drive.
    IPINTBANK1_UP                               = 0x00040000,   // Bit 18, At starting point for acceleration drive.
    IPINTBANK1_SIGNALDETECTED                   = 0x00080000,   // Bit 19, Signal assigned in MODE1 is detected.
    IPINTBANK1_SP23E                            = 0x00100000,   // Bit 20, Current speed is equal with rate change point RCP23.
    IPINTBANK1_SP12E                            = 0x00200000,   // Bit 21, Current speed is equal with rate change point RCP12.
    IPINTBANK1_SPE                              = 0x00400000,   // Bit 22, Current speed is equal with speed comparison data(SPDCMP).
    IPINTBANK1_INCEICM                          = 0x00800000,   // Bit 23, INTCNT(1'st counter) is equal with ICM(1'st count minus limit data)
    IPINTBANK1_SCRQEXE                          = 0x01000000,   // Bit 24, Script queue command is executed When SCRCONQ's 30 bit is '1'.
    IPINTBANK1_CAPQEXE                          = 0x02000000,   // Bit 25, Caption queue command is executed When CAPCONQ's 30 bit is '1'.
    IPINTBANK1_SLM                              = 0x04000000,   // Bit 26, NSLM/PSLM input signal is activated.
    IPINTBANK1_ELM                              = 0x08000000,   // Bit 27, NELM/PELM input signal is activated.
    IPINTBANK1_USERDEFINE1                      = 0x10000000,   // Bit 28, Selectable interrupt source 0(refer "0xFE" command).
    IPINTBANK1_USERDEFINE2                      = 0x20000000,   // Bit 29, Selectable interrupt source 1(refer "0xFE" command).
    IPINTBANK1_USERDEFINE3                      = 0x40000000,   // Bit 30, Selectable interrupt source 2(refer "0xFE" command).
    IPINTBANK1_USERDEFINE4                      = 0x80000000    // Bit 31, Selectable interrupt source 3(refer "0xFE" command).
}

public enum AXT_MOTION_IP_INTERRUPT_BANK2:uint
{
    IPINTBANK2_DONTUSE                          = 0x00000000,   // INTERRUT DISABLED.
    IPINTBANK2_L_C_INP_Q_EMPTY                  = 0x00000001,   // Bit 0, Linear/Circular interpolation parameter queue is empty.
    IPINTBANK2_P_INP_Q_EMPTY                    = 0x00000002,   // Bit 1, Bit pattern interpolation queue is empty.
    IPINTBANK2_ALARM_ERROR                      = 0x00000004,   // Bit 2, Alarm input signal is activated.
    IPINTBANK2_INPOSITION                       = 0x00000008,   // Bit 3, Inposition input signal is activated.
    IPINTBANK2_MARK_SIGNAL_HIGH                 = 0x00000010,   // Bit 4, Mark input signal is activated.
    IPINTBANK2_SSTOP_SIGNAL                     = 0x00000020,   // Bit 5, SSTOP input signal is activated.
    IPINTBANK2_ESTOP_SIGNAL                     = 0x00000040,   // Bit 6, ESTOP input signal is activated.
    IPINTBANK2_SYNC_ACTIVATED                   = 0x00000080,   // Bit 7, SYNC input signal is activated.
    IPINTBANK2_TRIGGER_ENABLE                   = 0x00000100,   // Bit 8, Trigger output is activated.
    IPINTBANK2_EXCNTCLR                         = 0x00000200,   // Bit 9, External(2'nd) counter is cleard by EXCNTCLR setting.
    IPINTBANK2_FSTCOMPARE_RESULT_BIT0           = 0x00000400,   // Bit 10, ALU1's compare result bit 0 is activated.
    IPINTBANK2_FSTCOMPARE_RESULT_BIT1           = 0x00000800,   // Bit 11, ALU1's compare result bit 1 is activated.
    IPINTBANK2_FSTCOMPARE_RESULT_BIT2           = 0x00001000,   // Bit 12, ALU1's compare result bit 2 is activated.
    IPINTBANK2_FSTCOMPARE_RESULT_BIT3           = 0x00002000,   // Bit 13, ALU1's compare result bit 3 is activated.
    IPINTBANK2_FSTCOMPARE_RESULT_BIT4           = 0x00004000,   // Bit 14, ALU1's compare result bit 4 is activated.
    IPINTBANK2_SNDCOMPARE_RESULT_BIT0           = 0x00008000,   // Bit 15, ALU2's compare result bit 0 is activated.
    IPINTBANK2_SNDCOMPARE_RESULT_BIT1           = 0x00010000,   // Bit 16, ALU2's compare result bit 1 is activated.
    IPINTBANK2_SNDCOMPARE_RESULT_BIT2           = 0x00020000,   // Bit 17, ALU2's compare result bit 2 is activated.
    IPINTBANK2_SNDCOMPARE_RESULT_BIT3           = 0x00040000,   // Bit 18, ALU2's compare result bit 3 is activated.
    IPINTBANK2_SNDCOMPARE_RESULT_BIT4           = 0x00080000,   // Bit 19, ALU2's compare result bit 4 is activated.
    IPINTBANK2_L_C_INP_Q_LESS_4                 = 0x00100000,   // Bit 20, Linear/Circular interpolation parameter queue is less than 4.
    IPINTBANK2_P_INP_Q_LESS_4                   = 0x00200000,   // Bit 21, Pattern interpolation parameter queue is less than 4.
    IPINTBANK2_XSYNC_ACTIVATED                  = 0x00400000,   // Bit 22, X axis sync input signal is activated.
    IPINTBANK2_YSYNC_ACTIVATED                  = 0x00800000,   // Bit 23, Y axis sync input siangl is activated.
    IPINTBANK2_P_INP_END_BY_END_PATTERN         = 0x01000000    // Bit 24, Bit pattern interpolation is terminated by end pattern.
    //    IPINTBANK2_                           = 0x02000000,   // Bit 25, Don't care.
    //    IPINTBANK2_                           = 0x04000000,   // Bit 26, Don't care.
    //    IPINTBANK2_                           = 0x08000000,   // Bit 27, Don't care.
    //    IPINTBANK2_                           = 0x10000000,   // Bit 28, Don't care.
    //    IPINTBANK2_                           = 0x20000000,   // Bit 29, Don't care.
    //    IPINTBANK2_                           = 0x40000000,   // Bit 30, Don't care.
    //    IPINTBANK2_                           = 0x80000000    // Bit 31, Don't care.
}

public class CCAMCIPdef
{
}