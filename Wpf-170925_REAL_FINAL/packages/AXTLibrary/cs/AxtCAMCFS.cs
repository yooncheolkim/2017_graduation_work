using System;
using System.Runtime.InteropServices;

public class CAxtCAMCFS
{
    /*------------------------------------------------------------------------------------------------*
        AXTCAMCFS Library - CAMC-FS 1.0 Motion module
        적용제품
            SMC-1V02 - CAMC-FS Ver1.0 1축
            SMC-2V02 - CAMC-FS Ver1.0 2축
    *------------------------------------------------------------------------------------------------*/

    // 보드 초기화 함수군        -======================================================================================
    // CAMC-FS가 장착된 모듈(SMC-1V02, SMC-2V02)을 검색하여 초기화한다. CAMC-FS 1.0만 검출한다
    [DllImport("AxtLib.dll")] public static extern int InitializeCAMCFS(int reset);
    // reset    : 1(TRUE) = 레지스터(카운터 등)를 초기화한다
    //  reset(TRUE)일때 초기 설정값.
    //  1) 인터럽트 사용하지 않음.
    //  2) 인포지션 기능 사용하지 않음.
    //  3) 알람정지 기능 사용하지 않음.
    //  4) 급정지 리미트 기능 사용 함.
    //  5) 감속정지 리미트 기능 사용 함.            
    //  6) 펄스 출력 모드 : OneLowHighLow(Pulse : Active LOW, Direction : CW{High};CCW{LOW}).
    //  7) 검색 신호 : +급정지 리미트 신호 하강 에지.
    //  8) 입력 인코더 설정 : 2상, 4 체배.
    //  9) 알람, 인포지션, +-감속 정지 리미트, +-급정지 리미트 Active level : HIGH
    // 10) 내부/외부 카운터 : 0.        
    // CAMC-FS 모듈의 사용이 가능한지를 확인한다
    [DllImport("AxtLib.dll")] public static extern int CFSIsInitialized();
    // 리턴값 :  1(TRUE) = CAMC-FS 모듈을 사용 가능하다
    // CAMC-FS가 장착된 모듈의 사용을 종료한다
    [DllImport("AxtLib.dll")] public static extern void CFSStopService();

    /// 보드 정보 관련 함수군        -===================================================================================
    // 지정한 주소에 장착된 베이스보드의 번호를 리턴한다. 없으면 -1을 리턴한다
    [DllImport("AxtLib.dll")] public static extern short CFSget_boardno(uint address);
    // 베이스보드의 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short CFSget_numof_boards();
    // 지정한 베이스보드에 장착된 축의 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short CFSget_numof_axes(short nBoardNo);
    // 축의 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short CFSget_total_numof_axis();
    // 지정한 베이스보드번호와 모듈번호에 해당하는 축번호를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short CFSget_axisno(short nBoardNo, short nModuleNo);
    // 지정한 축의 정보를 리턴한다
    // nBoardNo : 해당 축이 장착된 베이스보드의 번호.
    // nModuleNo: 해당 축이 장착된 모듈의 베이스 모드내 모듈 위치(0~3)
    // bModuleID: 해당 축이 장착된 모듈의 ID : SMC-2V02(0x02)
    // nAxisPos : 해당 축이 장착된 모듈의 첫번째인지 두번째 축인지 정보.(0 : 첫번째, 1 : 두번째)
    [DllImport("AxtLib.dll")] public static extern int CFSget_axis_info(short nAxisNo, ref short nBoardNo, ref short nModuleNo, ref byte bModuleID, ref short nAxisPos);

    // 파일 관련 함수군        -========================================================================================
    // 지정 축의 초기값을 지정한 파일에서 읽어서 설정한다
    // Loading parameters.
    //    1) 1Pulse당 이동거리(Move Unit / Pulse)
    //    2) 최대 이동 속도, 시작/정지 속도
    //    3) 엔코더 입력방식, 펄스 출력방식 
    //    4) +급정지 리미트레벨, -급정지 리미트레벨, 급정지 리미트 사용유무
    //  5) +감속정지 리미트레벨,-감속정지 리미트레벨, 감속정지 리미트 사용유무
    //  6) 알람레벨, 알람 사용유무
    //  7) 인포지션(위치결정완료 신호)레벨, 인포지션 사용유무
    //  8) 비상정지 사용유무
    //  9) 내부/외부 카운터 : 0.     
    [DllImport("AxtLib.dll")] public static extern int CFSload_parameter(short axis, ref byte nfilename);
    // 지정 축의 초기값을 지정한 파일에 저장한다.
    // Saving parameters.
    //    1) 1Pulse당 이동거리(Move Unit / Pulse)
    //    2) 최대 이동 속도, 시작/정지 속도
    //    3) 엔코더 입력방식, 펄스 출력방식 
    //    4) +급정지 리미트레벨, -급정지 리미트레벨, 급정지 리미트 사용유무
    //  5) +감속정지 리미트레벨,-감속정지 리미트레벨, 감속정지 리미트 사용유무
    //  6) 알람레벨, 알람 사용유무
    //  7) 인포지션(위치결정완료 신호)레벨, 인포지션 사용유무
    //  8) 비상정지 사용유무
    [DllImport("AxtLib.dll")] public static extern int CFSsave_parameter(short axis, ref byte nfilename); 
    // 모든 축의 초기값을 지정한 파일에서 읽어서 설정한다
    [DllImport("AxtLib.dll")] public static extern int CFSload_parameter_all(ref byte nfilename);
    // 모든 축의 초기값을 지정한 파일에 저장한다
    [DllImport("AxtLib.dll")] public static extern int CFSsave_parameter_all(ref byte nfilename); 

    // 인터럽트 함수군   -================================================================================================
    //(인터럽트를 사용하기 위해서는 
    //Window message & procedure
    //    hWnd    : 윈도우 핸들, 윈도우 메세지를 받을때 사용. 사용하지 않으면 NULL을 입력.
    //    wMsg    : 윈도우 핸들의 메세지, 사용하지 않거나 디폴트값을 사용하려면 0을 입력.
    //    proc    : 인터럽트 발생시 호출될 함수의 포인터, 사용하지 않으면 NULL을 입력.
    [DllImport("AxtLib.dll")] public static extern void CFSSetWindowMessage(IntPtr hWnd, ushort wMsg, CAxdLibDef.AXT_CAMCFS_INTERRUPT_PROC proc);    

    // 구동 설정 초기화 함수군        -==================================================================================
    // 메인클럭 설정( 모듈에 장착된 Oscillator가 변경될 경우에만 설정)
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetMainClk(int nMainClk);
    // Drive mode 1의 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void rmfCFSset_drive_mode1(short axis, 
                       byte decelstartpoint,
                       byte pulseoutmethod,
                       byte detectsignal);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_drive_mode1(short axis);
    // decelstartpoint : 지정거리 구동 기능 사용중 감속 위치 지정 방식 설정(0 : 자동 가감속, 1 : 수동 가감속)
    // pulseoutmethod : 출력 펄스 방식 설정(typedef : PULSE_OUTPUT)
    // detecsignal : 신호 검색-1/2 구동 기능 사용중 검색 할 신호 설정(typedef : DETECT_DESTINATION_SIGNAL)
    // Drive mode 2의 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_drive_mode2(short axis, 
                       byte encmethod,
                       byte inpactivelevel,
                       byte alarmactivelevel,
                       byte nslmactivelevel,
                       byte pslmactivelevel,
                       byte nelmactivelevel,
                       byte pelmactivelevel);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_drive_mode2(short axis);
    // Unit/Pulse 설정/확인한다.
    // 1펄스당 이동단위를 설정/검색한다. 이동량 및 속도에 영향을 준다
    [DllImport("AxtLib.dll")] public static extern void CFSset_moveunit_perpulse(short axis, double unitperpulse);
    [DllImport("AxtLib.dll")] public static extern double CFSget_moveunit_perpulse(short axis);
    // Unit/Pulse : 1 pulse에 대한 system의 이동거리를 말하며, 이때 Unit의 기준은 사용자가 임의로 생각할 수 있다.
    // Ex) Ball screw pitch : 10mm, 모터 1회전당 펄스수 : 10000 ==> Unit을 mm로 생각할 경우 : Unit/Pulse = 10/10000.
    // 따라서 unitperpulse에 0.001을 입력하면 모든 제어단위가 mm로 설정됨. 
    // Ex) Linear motor의 분해능이 1 pulse당 2 uM. ==> Unit을 mm로 생각할 경우 : Unit/Pulse = 0.002/1.
    // Unit/Pulse와 역수관계
    // pulse/Unit 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_movepulse_perunit(short axis, double pulseperunit);
    [DllImport("AxtLib.dll")] public static extern double CFSget_movepulse_perunit(short axis);
    // 시작 속도 설정/확인한다.(Unit/Sec)
    [DllImport("AxtLib.dll")] public static extern void CFSset_startstop_speed(short axis, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFSget_startstop_speed(short axis);
    // 최고 속도 설정 Unit/Sec. 제어 system의 최고 속도를 설정한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_max_speed(short axis, double max_velocity);
    [DllImport("AxtLib.dll")] public static extern double CFSget_max_speed(short axis);
    // Unit/Pulse 설정과 시작속도 설정 이후에 설정한다.
    // 설정된 최고 속도 이상으로는 구동을 할수 없으므로 주의한다.
    // SW에 관계된 값을 설정/확인한다. 이값으로 S-Curve 구간을 percentage로 설정 가능하다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_s_rate(short axis, double a_percent, double b_percent);
    [DllImport("AxtLib.dll")] public static extern void CFSget_s_rate(short axis, ref double a_percent, ref double b_percent);
    // 수동 가감속 모드에서 잔량 펄스를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_slowdown_rear_pulse(short axis, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFSget_slowdown_rear_pulse(short axis);
    // 지정 축의 감속 시작 포인터 검출 방식을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_decel_point(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_decel_point(short axis);
    // 0x0 : 자동 가감속.
    // 0x1 : 수동 가감속.

    // 구동 상태 확인 함수군        -=====================================================================================
    // 지정 축의 펄스 출력중인지를 확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSin_motion(short axis);
    // 지정 축의 펄스 출력이 종료됐는지 확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSmotion_done(short axis);
    // 지정 축의 구동시작 이후 출력된 펄스 카운터 값을 확인한다. (Pulse)
    [DllImport("AxtLib.dll")] public static extern int CFSget_drive_pulse_counts(short axis);
    // 지정 축의 DriveStatus 레지스터를 확인한다.
    [DllImport("AxtLib.dll")] public static extern byte CFSget_drive_status(short axis);
    // 지정 축의 EndStatus 레지스터를 확인한다.
    [DllImport("AxtLib.dll")] public static extern ushort CFSget_end_status(short axis);
    // End Status Bit별 의미
    // 10bit : 신호 검출에 의한 종료(Signal Search-1/2 drive종료)
    // 9 bit : 원점 검출에 의한 종료
    // 8 bit : 탈조 에러에 의한 종료
    // 7 bit : 데이타 설정 에러에 의한 종료
    // 6 bit : ALARM 신호 입력에 의한 종료
    // 5 bit : 급정지 명령에 의한 종료
    // 4 bit : 감속정지 명령에 의한 종료
    // 3 bit : 급정지 신호 입력에 의한 종료 (EMG Button)
    // 2 bit : 감속정지 신호 입력에 의한 종료
    // 1 bit : Limit(PELM, NELM, Soft) 급정지에 의한 종료
    // 0 bit : Limit(PSLM, NSLM, Soft) 감속정지에 의한 종료
    // 지정 축의 Mechanical 레지스터를 확인한다.
    [DllImport("AxtLib.dll")] public static extern byte CFSget_mechanical_signal(short axis);
    // Mechanical Signal Bit별 의미
    // 7 bit : Encoder Up신호 입력 Level(A상 신호)
    // 6 bit : Encoder Down신호 입력 Level(B상 신호)
    // 5 bit : INPOSITION 신호 Active 상태
    // 4 bit : ALARM 신호 Active 상태
    // 3 bit : -Limit 감속정지 신호 Active 상태
    // 2 bit : +Limit 감속정지 신호 Active 상태
    // 1 bit : -Limit 급정지 신호 Active 상태
    // 0 bit : +Limit 급정지 신호 Active 상태
    // 지정 축의  현재 속도를 읽어 온다.(Unit/Sec)
    [DllImport("AxtLib.dll")] public static extern double CFSget_velocity(short axis);
    // 지정 축의 Command position과 Actual position의 차를 확인한다.
    [DllImport("AxtLib.dll")] public static extern double CFSget_error(short axis);
    // 지정 축의 최후 드라이브의 이동 거리를 확인 한다. (Unit)
    [DllImport("AxtLib.dll")] public static extern double CFSget_drivedistance(short axis);

    // Encoder 입력 방식 설정 함수군        -=============================================================================
    // 지정 축의 Encoder 입력 방식을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_enc_input_method(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_enc_input_method(short axis);
    // method : typedef(EXTERNAL_COUNTER_INPUT)
    // UpDownMode = 0x0    // Up/Down
    // Sqr1Mode   = 0x1    // 1체배
    // Sqr2Mode   = 0x2    // 2체배
    // Sqr4Mode   = 0x3    // 4체배

    // 펄스 출력 방식 함수군        -=====================================================================================
    // 펄스 출력 방식을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_pulse_out_method(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pulse_out_method(short axis);
    // method : 출력 펄스 방식 설정(typedef : PULSE_OUTPUT)
    // OneHighLowHigh   = 0x0, 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
    // OneHighHighLow   = 0x1, 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
    // OneLowLowHigh    = 0x2, 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
    // OneLowHighLow    = 0x3, 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
    // TwoCcwCwHigh     = 0x4, 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High 
    // TwoCcwCwLow      = 0x5, 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low 
    // TwoCwCcwHigh     = 0x6, 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
    // TwoCwCcwLow      = 0x7, 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low

    // 위치 확인 및 위치 비교 설정 함수군 -===============================================================================
    // 외부 위치 값을 설정한다. 현재의 상태에서 외부 위치를 특정 값으로 설정/확인한다.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern void CFSset_actual_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFSget_actual_position(short axis);
    // 내부 위치 값을 설정한다. 현재의 상태에서 내부 위치를 특정 값으로 설정/확인한다.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern void CFSset_command_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFSget_command_position(short axis);

    // 서보 드라이버 출력 신호 설정 함수군-===============================================================================
    // 서보 Enable출력 신호의 Active Level을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_servo_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_servo_level(short axis);
    // 서보 Enable(On) / Disable(Off)을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_servo_enable(short axis, byte state);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_servo_enable(short axis);
    
    // 서보 드라이버 입력 신호 설정 함수군-===============================================================================
    // 서보 위치결정완료(inposition)입력 신호의 사용유무를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_inposition_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_inposition_enable(short axis);
    // 서보 위치결정완료(inposition)입력 신호의 Active Level을 설정/확인/상태확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_inposition_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_inposition_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_inposition_switch(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFSin_position(short axis);
    // 서보 알람 입력신호 기능의 사용유무를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_alarm_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_alarm_enable(short axis);
    // 서보 알람 입력 신호의 Active Level을 설정/확인/상태확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_alarm_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_alarm_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_alarm_switch(short axis);
    
    // 리미트 신호 설정 함수군-===========================================================================================
    // 급정지 리미트 기능 사용유무를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_end_limit_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_end_limit_enable(short axis);
    // -급정지 리미트 입력 신호의 Active Level을 설정/확인/상태확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_nend_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_nend_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_nend_limit_switch(short axis);
    // +급정지 리미트 입력 신호의 Active Level을 설정/확인/상태확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_pend_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pend_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pend_limit_switch(short axis);
    // 감속정지 리미트 기능 사용유무를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_slow_limit_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_slow_limit_enable(short axis);
    // -감속정지 리미트 입력 신호의 Active Level을 설정/확인/상태확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_nslow_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_nslow_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_nslow_limit_switch(short axis);    
    // +감속정지 리미트 입력 신호의 Active Level을 설정/확인/상태확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_pslow_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pslow_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pslow_limit_switch(short axis);
    
    // 비상정지 신호-=====================================================================================================
    // ESTOP, SSTOP 신호 사용유무를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_emg_signal_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_emg_signal_enable(short axis);
    
    // 단축 지정 거리 구동-===============================================================================================
    // start_** : 지정 축에서 구동 시작후 함수를 return한다. "start_*" 가 없으면 이동 완료후 return한다(Blocking).
    // *r*_*    : 지정 축에서 입력된 거리만큼(상대좌표)로 이동한다. "*r_*이 없으면 입력된 위치(절대좌표)로 이동한다.
    // *s*_*    : 구동중 속도 프로파일을 "S curve"를 이용한다. "*s_*"가 없다면 사다리꼴 가감속을 이용한다.
    // *a*_*    : 구동중 속도 가감속도를 비대칭으로 사용한다. 가속률 또는 가속 시간과  감속률 또는 감속 시간을 각각 입력받는다.
    // *_ex     : 구동중 가감속도를 가속 또는 감속 시간으로 입력 받는다. "*_ex"가 없다면 가감속률로 입력 받는다.
    // 입력 값들: velocity(Unit/Sec), acceleration/deceleration(Unit/Sec^2), acceltime/deceltime(Sec), position(Unit)

    // 대칭 지정펄스(Pulse Drive), 사다리꼴 구동 함수, 절대/상대좌표(r), 가속율/가속시간(_ex)(시간단위:Sec)
    // Blocking함수 (제어권이 펄스 출력이 완료된 후 넘어옴)
    [DllImport("AxtLib.dll")] public static extern ushort CFSmove(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSmove_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern ushort CFSr_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSr_move_ex(short axis, double distance, double velocity, double acceltime);
    // Non Blocking함수 (구동중일 경우 무시됨)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_r_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_r_move_ex(short axis, double distance, double velocity, double acceltime);
    // 대칭 지정펄스(Pulse Drive), S자형 구동, 절대/상대좌표(r), 가속율/가속시간(_ex)(시간단위:Sec)
    // Blocking함수 (제어권이 펄스 출력이 완료된 후 넘어옴)
    [DllImport("AxtLib.dll")] public static extern ushort CFSs_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSs_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern ushort CFSrs_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSrs_move_ex(short axis, double distance, double velocity, double acceltime);
    // Non Blocking함수 (구동중일 경우 무시됨)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_rs_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_rs_move_ex(short axis, double distance, double velocity, double acceltime);

    // 단축 연속 구동-====================================================================================================
    // 지정 가감속도 및 속도로 정지 조건이 발생하지 않으면 지속적으로 구동한다.
    // *s*_*    : 구동중 속도 프로파일을 "S curve"를 이용한다. "*s_*"가 없다면 사다리꼴 가감속을 이용한다.
    // *a*_*    : 구동중 속도 가감속도를 비대칭으로 사용한다. 가속률 또는 가속 시간과  감속률 또는 감속 시간을 각각 입력받는다.
    // *_ex     : 구동중 가감속도를 가속 또는 감속 시간으로 입력 받는다. "*_ex"가 없다면 가감속률로 입력 받는다.

    // 정속도 사다리꼴 구동 함수군, 가속율/가속시간(_ex)(시간단위:Sec) - 구동중일 경우에는 속도오버라이드
    [DllImport("AxtLib.dll")] public static extern int CFSv_move(short axis, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSv_move_ex(short axis, double velocity, double acceltime);
    // 정속도 S자형 구동 함수군, 가속율/가속시간(_ex)(시간단위:Sec) - 구동중일 경우에는 속도오버라이드 (단 감속중일때 제외)
    [DllImport("AxtLib.dll")] public static extern int CFSv_s_move(short axis, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSv_s_move_ex(short axis, double velocity, double acceltime);
 
    // 신호 검출 구동-====================================================================================================
    // 지정 신호의 상향/하향 에지를 검색하여 급정지 또는 감속정지를 할 수 있다.
    // detect_signal : 검색 신호 설정(typedef : DETECT_DESTINATION_SIGNAL)
    // PElmNegativeEdge    = 0x0,        // +Elm(End limit) 하강 edge
    // NElmNegativeEdge    = 0x1,        // -Elm(End limit) 하강 edge
    // PSlmNegativeEdge    = 0x2,        // +Slm(Slowdown limit) 하강 edge
    // NSlmNegativeEdge    = 0x3,        // -Slm(Slowdown limit) 하강 edge
    // In0DownEdge         = 0x4,        // IN0(ORG) 하강 edge
    // In1DownEdge         = 0x5,        // IN1(Z상) 하강 edge
    // In2DownEdge         = 0x6,        // IN2(범용) 하강 edge
    // In3DownEdge         = 0x7,        // IN3(범용) 하강 edge
    // PElmPositiveEdge    = 0x8,        // +Elm(End limit) 상승 edge
    // NElmPositiveEdge    = 0x9,        // -Elm(End limit) 상승 edge
    // PSlmPositiveEdge    = 0xa,        // +Slm(Slowdown limit) 상승 edge
    // NSlmPositiveEdge    = 0xb,        // -Slm(Slowdown limit) 상승 edge
    // In0UpEdge           = 0xc,        // IN0(ORG) 상승 edge
    // In1UpEdge           = 0xd,        // IN1(Z상) 상승 edge
    // In2UpEdge           = 0xe,        // IN2(범용) 상승 edge
    // In3UpEdge           = 0xf         // IN3(범용) 상승 edge
    // Signal Search1 : 구동 시작후 입력 속도까지 가속하여, 신호 검출후 감속 정지.
    // Signal Search2 : 구동 시작후 가속없이 입력 속도가 되고, 신호 검출후 급정지. 
    // 주의 : Signal Search2는 가감속이 없으므로 속도가 높을경우 탈조및 기구부의 무리가 갈수 있으므로 주의한다.
    // *s*_*    : 구동중 속도 프로파일을 "S curve"를 이용한다. "*s_*"가 없다면 사다리꼴 가감속을 이용한다.
    // *_ex     : 구동중 가감속도를 가속 또는 감속 시간으로 입력 받는다. "*_ex"가 없다면 가감속률로 입력 받는다.
    
    // 신호검출1(Signal search 1) 사다리꼴 구동, 가속율/가속시간(_ex)(시간단위:Sec)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_signal_search1(short axis, double velocity, double acceleration, byte detect_signal);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_signal_search1_ex(short axis, double velocity, double acceltime, byte detect_signal);
    // 신호검출1(Signal search 1) S자형 구동, 가속율/가속시간(_ex)(시간단위:Sec)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_signal_search1(short axis, double velocity, double acceleration, byte detect_signal);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_signal_search1_ex(short axis, double velocity, double acceltime, byte detect_signal);
    // 신호검출2(Signal search 2) 사다리꼴 구동, 가감속 없음
    [DllImport("AxtLib.dll")] public static extern int CFSstart_signal_search2(short axis, double velocity, byte detect_signal);

    // 오버라이드(구동중)-================================================================================================
    // 단축 지정 거리 구동시 구동 시작시점에서 입력한 위치(절대위치)를 구동중 바꾼다.
    [DllImport("AxtLib.dll")] public static extern int CFSposition_override(short axis, double overrideposition);
    // 단축 지정 거리 구동시 구동 시작시점에서 입력한 거리(상대위치)를 구동중 바꾼다.    
    [DllImport("AxtLib.dll")] public static extern int CFSposition_r_override(short axis, double overridedistance);
    // 구동중 구동 초기 설정한 속도를 바꾼다.(set_max_speed > velocity > set_startstop_speed)
    [DllImport("AxtLib.dll")] public static extern int CFSvelocity_override(short axis, double velocity);

    // 단축 구동 확인-====================================================================================================
    // 지정 축의 구동이 종료될 때까지 기다린 후 함수를 벗어난다.
    [DllImport("AxtLib.dll")] public static extern ushort CFSwait_for_done(short axis);

    // 단축 구동 정지-====================================================================================================
    // 지정 축을 급정지한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_e_stop(short axis);
    // 지정 축을 구동시 감속율로 정지한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_stop(short axis);
    // 지정 축을 입력된 감속율로 정지한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_stop_decel(short axis, double deceleration);
    // 지정 축을 입력된 감속 시간으로 정지한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_stop_deceltime(short axis, double deceltime);

    // 다축 동기 구동관련 설정-==========================================================================================
    // Master/Slave link 또는 좌표계 link 둘중 하나를 사용하여야 한다.
    // Master/Slave link 설정. (일반 단축 구동시 master 축 구동시 slave축도 같이 구동된다.)
    [DllImport("AxtLib.dll")] public static extern int CFSlink(short master, short slave, double ratio);
    // Master/Slave link 해제
    [DllImport("AxtLib.dll")] public static extern int CFSendlink(short slave);

    // 좌표계 link 설정-================================================================================================
    // 지정 좌표계에 축 할당 - n_axes갯수만큼의 축수를 설정/확인한다.(coordinate는 1..8까지 사용 가능)
    // n_axes 갯수만큼의 축수를 설정/확인한다. - (n_axes는 1..4까지 사용 가능)
    [DllImport("AxtLib.dll")] public static extern int CFSmap_axes(short coordinate, short n_axes, short[] map_array);
    [DllImport("AxtLib.dll")] public static extern int CFSget_mapped_axes(short coordinate, short n_axes, ref short map_array);
    // 지정 좌표계의 상대/절대 모드 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_coordinate_mode(short coordinate, short mode);
    [DllImport("AxtLib.dll")] public static extern short CFSget_coordinate_mode(short coordinate);
    // mode:
    // 0: 상대좌표구동, 1: 절대좌표 구동
    // 지정 좌표계의 속도 프로파일 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_profile(short coordinate, short mode);
    [DllImport("AxtLib.dll")] public static extern short CFSget_move_profile(short coordinate);
    // mode:
    // 0: 사다리꼴 구동, 1: S커브 구동
    // 지정 좌표계의 초기 속도를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_startstop_velocity(short coordinate, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFSget_move_startstop_velocity(short coordinate);
    // 특정 좌표계의 속도를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_velocity(short coordinate, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFSget_move_velocity(short coordinate);
    // 특정 좌표계의 가속율을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_acceleration(short coordinate, double acceleration);
    [DllImport("AxtLib.dll")] public static extern double CFSget_move_acceleration(short coordinate);
    // 특정 좌표계의 가속 시간(Sec)을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_acceltime(short coordinate, double acceltime);
    [DllImport("AxtLib.dll")] public static extern double CFSget_move_acceltime(short coordinate);
    // 보간 구동중인  좌표계의 현재 구동속도를 반환한다.
    [DllImport("AxtLib.dll")] public static extern double CFSco_get_velocity(short coordinate);

    // 소프트웨어 보간 구동(지정 좌표계에 대하여)-========================================================================
    // Blocking함수 (제어권이 펄스 출력이 완료된 후 넘어옴)
    // 2, 3, 4축이 동시이동한다.
    [DllImport("AxtLib.dll")] public static extern int CFSmove_2(short coordinate, double x, double y);
    [DllImport("AxtLib.dll")] public static extern int CFSmove_3(short coordinate, double x, double y, double z);
    [DllImport("AxtLib.dll")] public static extern int CFSmove_4(short coordinate, double x, double y, double z, double w);
    // Non Blocking함수 (구동중일 경우 무시됨)
    // 2, 3, 4축이 동시 이동한다.
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_2(short coordinate, double x, double y);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_3(short coordinate, double x, double y, double z);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_4(short coordinate, double x, double y, double z, double w);
    // 지정 좌표계의 모든축의 모션 완료 체크    
    [DllImport("AxtLib.dll")] public static extern int CFSco_motion_done(short coordinate);
    // 지정 좌표계의 구동이 완료될때 까지 기다린다.
    [DllImport("AxtLib.dll")] public static extern int CFSco_wait_for_done(short coordinate);

    // 다축 구동(동기 구동) : Master/Slave로 link되어 있을 경우 오류가 발생 할 수 있다.-==================================
    // 지정 축들을 지정 거리 및 속도 가속도 정보로 동기 시작 구동한다. 구동 시작에 대한 동기화시 사용한다. 
    // start_** : 지정 축에서 구동 시작후 함수를 return한다. "start_*" 가 없으면 이동 완료후 return한다.
    // *r*_*    : 지정 축에서 입력된 거리만큼(상대좌표)로 이동한다. "*r_*이 없으면 입력된 위치(절대좌표)로 이동한다.
    // *s*_*    : 구동중 속도 프로파일을 "S curve"를 이용한다. "*s_*"가 없다면 사다리꼴 가감속을 이용한다.
    // *_ex     : 구동중 가감속도를 가속 또는 감속 시간으로 입력 받는다. "*_ex"가 없다면 가감속률로 입력 받는다.

    // 다축 지정펄스(Pulse Drive)구동, 사다리꼴 구동, 절대/상대좌표(r), 가속율/가속시간(_ex)(시간단위:Sec)
    // Blocking함수 (제어권이 모든 구동축의 펄스 출력이 완료된 후 넘어옴)
    [DllImport("AxtLib.dll")] public static extern byte CFSmove_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFSmove_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern byte CFSr_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFSr_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // Non Blocking함수 (구동중인 축은 무시됨)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_r_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_r_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // 다축 지정펄스(Pulse Drive)구동, S자형 구동, 절대/상대좌표(r), 가속율/가속시간(_ex)(시간단위:Sec)
    // Blocking함수 (제어권이 모든 구동축의 펄스 출력이 완료된 후 넘어옴)
    [DllImport("AxtLib.dll")] public static extern byte CFSs_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFSs_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern byte CFSrs_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFSrs_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // Non Blocking함수 (구동중인 축은 무시됨)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_rs_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_rs_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    //지정 축들에 대하여 S자형 구동을 위한 가감속시의 S커브의 비율을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_s_rate_all(short number, short[] axes, double[] a_percent, double[] b_percent);
    [DllImport("AxtLib.dll")] public static extern void CFSget_s_rate_all(short number, ref short axes, ref double a_percent, ref double b_percent);
    
    // 다축 구동 확인-====================================================================================================
    // 입력 해당 축들의 구동 상태를 확인하고 구동이 끝날 때 까지 기다린다.
    [DllImport("AxtLib.dll")] public static extern byte CFSwait_for_all(short number, short[] axes);

    // 다축 동기 설정-====================================================================================================
    // 지정 축들의 동기를 해제시킨다. - 구동명령이 내려져도 구동되지않고 대기함.
    [DllImport("AxtLib.dll")] public static extern int CFSreset_axis_sync(short nLen, short[] aAxis);
    // 지정 축들의 동기를 해제시킨다. - 구동명령이 내려져도 구동되지않고 대기함.
    [DllImport("AxtLib.dll")] public static extern int CFSset_axis_sync(short nLen, ref short aAxis);

    // 다축 구동 정지-====================================================================================================
    // 홈 서치 쓰레드도 정지
    [DllImport("AxtLib.dll")] public static extern int CFSemergency_stop();

    // -원점검색 =========================================================================================================
    // 라이브러리 상에서 Thread를 사용하여 검색한다. 주의 : 구동후 칩내의 StartStop Speed가 변할 수 있다.
    // 원점검색을 종료한다.
    [DllImport("AxtLib.dll")] public static extern int CFSabort_home_search(short axis, byte bStop);
    // bStop:
    // 0: 감속정지
    // 1: 급정지
    // 원점검색을 시작한다. 시작하기 전에 원점검색에 필요한 설정이 필요하다.
    [DllImport("AxtLib.dll")] public static extern int CFShome_search(short axis);
    // 입력 축들을 동시에 원점검색을 실시한다.
    [DllImport("AxtLib.dll")] public static extern int CFShome_search_all(short number, short[] axes);
    // 반환값: 0: 원점검색 진행중, 1: 원점검색 종료
    // 원점검색 진행 중인지를 확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_done(short axis);
    // 해당 축들의 원점검색 진행 중인지를 확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_done_all(short number, ref short axes);
    // 지정 축의 원점 검색 실행후 종료 상태를 확인한다.
    [DllImport("AxtLib.dll")] public static extern byte CFSget_home_end_status(short axis);
    // 반환값: 0: 원점검색 실패, 1: 원점검색 성공
    // 지정 축들의 원점 검색 실행후 종료 상태를 확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_end_status_all(short number, ref short axes, ref byte endstatus);
    // 원점 검색시 각 스텝마다 method를 설정/확인한다.
    // Method에 대한 설명 
    //    0 Bit 스텝 사용여부 설정 (0 : 사용하지 않음, 1: 사용함
    //    1 Bit 가감속 방법 설정 (0 : 가속율, 1 : 가속 시간)
    //    2 Bit 정지방법 설정 (0 : 감속 정지, 1 : 급 정지)
    //    3 Bit 검색방향 설정 (0 : cww(-), 1 : cw(+))
    // 7654 Bit detect signal 설정(typedef : DETECT_DESTINATION_SIGNAL)
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_method(short axis, short nstep, byte[] method);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_method(short axis, short nstep, ref byte method);
    // 원점 검색시 각 스텝마다 offset을 설정/확인한다.    
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_offset(short axis, short nstep, double[] offset);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_offset(short axis, short nstep, ref double offset);
    // 각 축의 원점 검색 속도를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_velocity(short axis, short nstep, double[] velocity);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_velocity(short axis, short nstep, ref double velocity);
    // 지정 축의 원점 검색 시 각 스텝별 가속율을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_acceleration(short axis, short nstep, double[] acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_acceleration(short axis, short nstep, ref double acceleration);
    // 지정 축의 원점 검색 시 각 스텝별 가속 시간을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_acceltime(short axis, short nstep, double[] acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_acceltime(short axis, short nstep, ref double acceltime);
    // 지정 축에 원점 검색에서 엔코더 'Z'상 검출 사용 시 구동 한계값를 설정/확인한다.(Pulse) - 범위를 벗어나면 검색 실패
    [DllImport("AxtLib.dll")] public static extern int CFSset_zphase_search_range(short axis, short pulses);
    [DllImport("AxtLib.dll")] public static extern short CFSget_zphase_search_range(short axis);
    // 현재 위치를 원점(0 Position)으로 설정한다. - 구동중이면 무시됨.
    [DllImport("AxtLib.dll")] public static extern int CFShome_zero(short axis);
    // 설정한 모든 축의 현재 위치를 원점(0 Position)으로 설정한다. - 구동중인 축은 무시됨
    [DllImport("AxtLib.dll")] public static extern int CFShome_zero_all(short number, short[] axes);

    // 범용 입출력-=======================================================================================================
    // 범용 출력
    // 0 bit : 범용 출력 0(Servo-On)
    // 1 bit : 범용 출력 1(ALARM Clear)
    // 2 bit : 범용 출력 2
    // 3 bit : 범용 출력 3
    // 범용 입력
    // 0 bit : 범용 입력 0(ORiginal Sensor)
    // 1 bit : 범용 입력 1(Z phase)
    // 2 bit : 범용 입력 2
    // 3 bit : 범용 입력 3
    // On ==> 단자대 N24V, 'Off' ==> 단자대 Open(float).

    // 현재 범용 출력값을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_output(short axis, byte value);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_output(short axis);
    // 범용 입력 값을 확인한다.
    // '1'('On') <== 단자대 N24V와 연결됨, '0'('Off') <== 단자대 P24V 또는 Float.
    [DllImport("AxtLib.dll")] public static extern byte CFSget_input(short axis);
    // 해당 축의 해당 bit의 출력을 On/Off 시킨다.
    // bitNo : 0 ~ 3.
    [DllImport("AxtLib.dll")] public static extern int CFSset_output_bit(short axis, byte bitNo);
    [DllImport("AxtLib.dll")] public static extern int CFSreset_output_bit(short axis, byte bitNo);
    // 해당 축의 해당 범용 출력 bit의 출력 상태를 확인한다.
    // bitNo : 0 ~ 3.
    [DllImport("AxtLib.dll")] public static extern int CFSoutput_bit_on(short axis, byte bitNo);
    // 해당 축의 해당 범용 출력 bit의 상태를 입력 state로 바꾼다.
    // bitNo : 0 ~ 3. 
    [DllImport("AxtLib.dll")] public static extern int CFSchange_output_bit(short axis, byte bitNo, byte state);
    // 해당 축의 해당 범용 입력 bit의 상태를 확인 한다.
    // bitNo : 0 ~ 3.
    [DllImport("AxtLib.dll")] public static extern int CFSinput_bit_on(short axis, byte bitNo);

    // 잔여 펄스 clear-===================================================================================================
    // 해당 축의 서보팩 잔여 펄스 Clear 출력의 사용 여부를 설정/확인한다.
    // CLR 신호의 Default 출력 ==> 단자대 Open이다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_mask(short axis);
    // 해당 축의 잔여 펄스 Clear 출력의 Active level을 설정/확인한다.
    // Default Active level ==> '1' ==> 단자대 N24V
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_level(short axis);
    // 해당 축의 -Emeregency End limit에 대한 Clear출력 사용 유무를 설정/확인한다.    
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_nelm_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_nelm_mask(short axis);
    // 해당 축의 -Emeregency End limit의 Active level을 설정/확인한다. set_nend_limit_level과 동일하게 설정한다.    
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_nelm_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_nelm_level(short axis);
    // 해당 축의 +Emeregency End limit에 대한 Clear출력 사용 유무를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_pelm_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_pelm_mask(short axis);
    // 해당 축의 +Emeregency End limit의 Active level을 설정/확인한다. set_nend_limit_level과 동일하게 설정한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_pelm_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_pelm_level(short axis);
    // 해당 축의 잔여 펄스 Clear 출력을 입력 값으로 강제 출력/확인한다.    
    [DllImport("AxtLib.dll")] public static extern int CFSset_programmed_crc(short axis, short data);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_programmed_crc(short axis);

    // 트리거 기능 ======================================================================================================
    // 내부/외부 위치에 대하여 주기/절대 위치에서 설정된 Active level의 Trigger pulse를 발생 시킨다.
    // 트리거 출력 펄스의 Active level을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_level(short axis, byte trigger_level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_trigger_level(short axis);
    // 트리거 기능에 사용할 기준 위치를 선택한다.
    // 0x0 : 외부 위치 External(Actual)
    // 0x1 : 내부 위치 Internal(Command)
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_sel(short axis, byte trigger_sel);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_trigger_sel(short axis);
    // 트리거 펄스폭을 설정/확인한다.
    // 0Fh : 64 msec
    // 0Eh : 32 msec
    // 0Dh : 16 mSec
    // ..
    // 04h : 0.062msec
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_time(short axis, byte time);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_trigger_time(short axis);
    // 지정 축의 트리거 기능의 사용 여부를 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_enable(short axis, byte ena_status);
    [DllImport("AxtLib.dll")] public static extern byte CFSis_trigger_enabled(short axis);
    // 지정 축에 트리거 발생시 인터럽트를 발생하도록 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_interrupt_enable(short axis, byte ena_int);
    [DllImport("AxtLib.dll")] public static extern byte CFSis_trigger_interrupt_enabled(short axis);

    // 위치 비교기 관련 함수군 ==========================================================================================
    // Internal(Command) comparator값을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_internal_comparator_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFSget_internal_comparator_position(short axis);
    // External(Encoder) comparator값을 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern void CFSset_external_comparator_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFSget_external_comparator_position(short axis);

    // 구동완료 인터럽트 사용관련 함수군 ==========================================================================================
    // 구동 완료시 인터럽트 출력의 사용유무 설정/확인한다.
    [DllImport("AxtLib.dll")] public static extern int CFSset_motiondone_interrupt_enable(short axis, byte ena_int);
    [DllImport("AxtLib.dll")] public static extern byte CFSis_motiondone_interrupt_enabled(short axis);

    // 에러코드 읽기 함수군 =============================================================================================
    // 마지막 에러코드를 읽는다.
    [DllImport("AxtLib.dll")] public static extern short CFSget_error_code();
    // 에러코드의 원인을 문자로 반환한다.
    [DllImport("AxtLib.dll")] public static extern string CFSget_error_msg(short ErrorCode);
}