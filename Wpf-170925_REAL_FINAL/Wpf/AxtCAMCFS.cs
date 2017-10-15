using System;
using System.Runtime.InteropServices;

public class CAxtCAMCFS
{
    /*------------------------------------------------------------------------------------------------*
        AXTCAMCFS Library - CAMC-FS 1.0 Motion module
        ������ǰ
            SMC-1V02 - CAMC-FS Ver1.0 1��
            SMC-2V02 - CAMC-FS Ver1.0 2��
    *------------------------------------------------------------------------------------------------*/

    // ���� �ʱ�ȭ �Լ���        -======================================================================================
    // CAMC-FS�� ������ ���(SMC-1V02, SMC-2V02)�� �˻��Ͽ� �ʱ�ȭ�Ѵ�. CAMC-FS 1.0�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern int InitializeCAMCFS(int reset);
    // reset    : 1(TRUE) = ��������(ī���� ��)�� �ʱ�ȭ�Ѵ�
    //  reset(TRUE)�϶� �ʱ� ������.
    //  1) ���ͷ�Ʈ ������� ����.
    //  2) �������� ��� ������� ����.
    //  3) �˶����� ��� ������� ����.
    //  4) ������ ����Ʈ ��� ��� ��.
    //  5) �������� ����Ʈ ��� ��� ��.            
    //  6) �޽� ��� ��� : OneLowHighLow(Pulse : Active LOW, Direction : CW{High};CCW{LOW}).
    //  7) �˻� ��ȣ : +������ ����Ʈ ��ȣ �ϰ� ����.
    //  8) �Է� ���ڴ� ���� : 2��, 4 ü��.
    //  9) �˶�, ��������, +-���� ���� ����Ʈ, +-������ ����Ʈ Active level : HIGH
    // 10) ����/�ܺ� ī���� : 0.        
    // CAMC-FS ����� ����� ���������� Ȯ���Ѵ�
    [DllImport("AxtLib.dll")] public static extern int CFSIsInitialized();
    // ���ϰ� :  1(TRUE) = CAMC-FS ����� ��� �����ϴ�
    // CAMC-FS�� ������ ����� ����� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern void CFSStopService();

    /// ���� ���� ���� �Լ���        -===================================================================================
    // ������ �ּҿ� ������ ���̽������� ��ȣ�� �����Ѵ�. ������ -1�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFSget_boardno(uint address);
    // ���̽������� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFSget_numof_boards();
    // ������ ���̽����忡 ������ ���� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFSget_numof_axes(short nBoardNo);
    // ���� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFSget_total_numof_axis();
    // ������ ���̽������ȣ�� ����ȣ�� �ش��ϴ� ���ȣ�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFSget_axisno(short nBoardNo, short nModuleNo);
    // ������ ���� ������ �����Ѵ�
    // nBoardNo : �ش� ���� ������ ���̽������� ��ȣ.
    // nModuleNo: �ش� ���� ������ ����� ���̽� ��峻 ��� ��ġ(0~3)
    // bModuleID: �ش� ���� ������ ����� ID : SMC-2V02(0x02)
    // nAxisPos : �ش� ���� ������ ����� ù��°���� �ι�° ������ ����.(0 : ù��°, 1 : �ι�°)
    [DllImport("AxtLib.dll")] public static extern int CFSget_axis_info(short nAxisNo, ref short nBoardNo, ref short nModuleNo, ref byte bModuleID, ref short nAxisPos);

    // ���� ���� �Լ���        -========================================================================================
    // ���� ���� �ʱⰪ�� ������ ���Ͽ��� �о �����Ѵ�
    // Loading parameters.
    //    1) 1Pulse�� �̵��Ÿ�(Move Unit / Pulse)
    //    2) �ִ� �̵� �ӵ�, ����/���� �ӵ�
    //    3) ���ڴ� �Է¹��, �޽� ��¹�� 
    //    4) +������ ����Ʈ����, -������ ����Ʈ����, ������ ����Ʈ �������
    //  5) +�������� ����Ʈ����,-�������� ����Ʈ����, �������� ����Ʈ �������
    //  6) �˶�����, �˶� �������
    //  7) ��������(��ġ�����Ϸ� ��ȣ)����, �������� �������
    //  8) ������� �������
    //  9) ����/�ܺ� ī���� : 0.     
    [DllImport("AxtLib.dll")] public static extern int CFSload_parameter(short axis, ref byte nfilename);
    // ���� ���� �ʱⰪ�� ������ ���Ͽ� �����Ѵ�.
    // Saving parameters.
    //    1) 1Pulse�� �̵��Ÿ�(Move Unit / Pulse)
    //    2) �ִ� �̵� �ӵ�, ����/���� �ӵ�
    //    3) ���ڴ� �Է¹��, �޽� ��¹�� 
    //    4) +������ ����Ʈ����, -������ ����Ʈ����, ������ ����Ʈ �������
    //  5) +�������� ����Ʈ����,-�������� ����Ʈ����, �������� ����Ʈ �������
    //  6) �˶�����, �˶� �������
    //  7) ��������(��ġ�����Ϸ� ��ȣ)����, �������� �������
    //  8) ������� �������
    [DllImport("AxtLib.dll")] public static extern int CFSsave_parameter(short axis, ref byte nfilename); 
    // ��� ���� �ʱⰪ�� ������ ���Ͽ��� �о �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern int CFSload_parameter_all(ref byte nfilename);
    // ��� ���� �ʱⰪ�� ������ ���Ͽ� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern int CFSsave_parameter_all(ref byte nfilename); 

    // ���ͷ�Ʈ �Լ���   -================================================================================================
    //(���ͷ�Ʈ�� ����ϱ� ���ؼ��� 
    //Window message & procedure
    //    hWnd    : ������ �ڵ�, ������ �޼����� ������ ���. ������� ������ NULL�� �Է�.
    //    wMsg    : ������ �ڵ��� �޼���, ������� �ʰų� ����Ʈ���� ����Ϸ��� 0�� �Է�.
    //    proc    : ���ͷ�Ʈ �߻��� ȣ��� �Լ��� ������, ������� ������ NULL�� �Է�.
    [DllImport("AxtLib.dll")] public static extern void CFSSetWindowMessage(IntPtr hWnd, ushort wMsg, CAxdLibDef.AXT_CAMCFS_INTERRUPT_PROC proc);    

    // ���� ���� �ʱ�ȭ �Լ���        -==================================================================================
    // ����Ŭ�� ����( ��⿡ ������ Oscillator�� ����� ��쿡�� ����)
    [DllImport("AxtLib.dll")] public static extern void CFSKeSetMainClk(int nMainClk);
    // Drive mode 1�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void rmfCFSset_drive_mode1(short axis, 
                       byte decelstartpoint,
                       byte pulseoutmethod,
                       byte detectsignal);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_drive_mode1(short axis);
    // decelstartpoint : �����Ÿ� ���� ��� ����� ���� ��ġ ���� ��� ����(0 : �ڵ� ������, 1 : ���� ������)
    // pulseoutmethod : ��� �޽� ��� ����(typedef : PULSE_OUTPUT)
    // detecsignal : ��ȣ �˻�-1/2 ���� ��� ����� �˻� �� ��ȣ ����(typedef : DETECT_DESTINATION_SIGNAL)
    // Drive mode 2�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_drive_mode2(short axis, 
                       byte encmethod,
                       byte inpactivelevel,
                       byte alarmactivelevel,
                       byte nslmactivelevel,
                       byte pslmactivelevel,
                       byte nelmactivelevel,
                       byte pelmactivelevel);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_drive_mode2(short axis);
    // Unit/Pulse ����/Ȯ���Ѵ�.
    // 1�޽��� �̵������� ����/�˻��Ѵ�. �̵��� �� �ӵ��� ������ �ش�
    [DllImport("AxtLib.dll")] public static extern void CFSset_moveunit_perpulse(short axis, double unitperpulse);
    [DllImport("AxtLib.dll")] public static extern double CFSget_moveunit_perpulse(short axis);
    // Unit/Pulse : 1 pulse�� ���� system�� �̵��Ÿ��� ���ϸ�, �̶� Unit�� ������ ����ڰ� ���Ƿ� ������ �� �ִ�.
    // Ex) Ball screw pitch : 10mm, ���� 1ȸ���� �޽��� : 10000 ==> Unit�� mm�� ������ ��� : Unit/Pulse = 10/10000.
    // ���� unitperpulse�� 0.001�� �Է��ϸ� ��� ��������� mm�� ������. 
    // Ex) Linear motor�� ���ش��� 1 pulse�� 2 uM. ==> Unit�� mm�� ������ ��� : Unit/Pulse = 0.002/1.
    // Unit/Pulse�� ��������
    // pulse/Unit ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_movepulse_perunit(short axis, double pulseperunit);
    [DllImport("AxtLib.dll")] public static extern double CFSget_movepulse_perunit(short axis);
    // ���� �ӵ� ����/Ȯ���Ѵ�.(Unit/Sec)
    [DllImport("AxtLib.dll")] public static extern void CFSset_startstop_speed(short axis, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFSget_startstop_speed(short axis);
    // �ְ� �ӵ� ���� Unit/Sec. ���� system�� �ְ� �ӵ��� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_max_speed(short axis, double max_velocity);
    [DllImport("AxtLib.dll")] public static extern double CFSget_max_speed(short axis);
    // Unit/Pulse ������ ���ۼӵ� ���� ���Ŀ� �����Ѵ�.
    // ������ �ְ� �ӵ� �̻����δ� ������ �Ҽ� �����Ƿ� �����Ѵ�.
    // SW�� ����� ���� ����/Ȯ���Ѵ�. �̰����� S-Curve ������ percentage�� ���� �����ϴ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_s_rate(short axis, double a_percent, double b_percent);
    [DllImport("AxtLib.dll")] public static extern void CFSget_s_rate(short axis, ref double a_percent, ref double b_percent);
    // ���� ������ ��忡�� �ܷ� �޽��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_slowdown_rear_pulse(short axis, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFSget_slowdown_rear_pulse(short axis);
    // ���� ���� ���� ���� ������ ���� ����� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_decel_point(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_decel_point(short axis);
    // 0x0 : �ڵ� ������.
    // 0x1 : ���� ������.

    // ���� ���� Ȯ�� �Լ���        -=====================================================================================
    // ���� ���� �޽� ����������� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSin_motion(short axis);
    // ���� ���� �޽� ����� ����ƴ��� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSmotion_done(short axis);
    // ���� ���� �������� ���� ��µ� �޽� ī���� ���� Ȯ���Ѵ�. (Pulse)
    [DllImport("AxtLib.dll")] public static extern int CFSget_drive_pulse_counts(short axis);
    // ���� ���� DriveStatus �������͸� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern byte CFSget_drive_status(short axis);
    // ���� ���� EndStatus �������͸� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern ushort CFSget_end_status(short axis);
    // End Status Bit�� �ǹ�
    // 10bit : ��ȣ ���⿡ ���� ����(Signal Search-1/2 drive����)
    // 9 bit : ���� ���⿡ ���� ����
    // 8 bit : Ż�� ������ ���� ����
    // 7 bit : ����Ÿ ���� ������ ���� ����
    // 6 bit : ALARM ��ȣ �Է¿� ���� ����
    // 5 bit : ������ ��ɿ� ���� ����
    // 4 bit : �������� ��ɿ� ���� ����
    // 3 bit : ������ ��ȣ �Է¿� ���� ���� (EMG Button)
    // 2 bit : �������� ��ȣ �Է¿� ���� ����
    // 1 bit : Limit(PELM, NELM, Soft) �������� ���� ����
    // 0 bit : Limit(PSLM, NSLM, Soft) ���������� ���� ����
    // ���� ���� Mechanical �������͸� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern byte CFSget_mechanical_signal(short axis);
    // Mechanical Signal Bit�� �ǹ�
    // 7 bit : Encoder Up��ȣ �Է� Level(A�� ��ȣ)
    // 6 bit : Encoder Down��ȣ �Է� Level(B�� ��ȣ)
    // 5 bit : INPOSITION ��ȣ Active ����
    // 4 bit : ALARM ��ȣ Active ����
    // 3 bit : -Limit �������� ��ȣ Active ����
    // 2 bit : +Limit �������� ��ȣ Active ����
    // 1 bit : -Limit ������ ��ȣ Active ����
    // 0 bit : +Limit ������ ��ȣ Active ����
    // ���� ����  ���� �ӵ��� �о� �´�.(Unit/Sec)
    [DllImport("AxtLib.dll")] public static extern double CFSget_velocity(short axis);
    // ���� ���� Command position�� Actual position�� ���� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern double CFSget_error(short axis);
    // ���� ���� ���� ����̺��� �̵� �Ÿ��� Ȯ�� �Ѵ�. (Unit)
    [DllImport("AxtLib.dll")] public static extern double CFSget_drivedistance(short axis);

    // Encoder �Է� ��� ���� �Լ���        -=============================================================================
    // ���� ���� Encoder �Է� ����� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_enc_input_method(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_enc_input_method(short axis);
    // method : typedef(EXTERNAL_COUNTER_INPUT)
    // UpDownMode = 0x0    // Up/Down
    // Sqr1Mode   = 0x1    // 1ü��
    // Sqr2Mode   = 0x2    // 2ü��
    // Sqr4Mode   = 0x3    // 4ü��

    // �޽� ��� ��� �Լ���        -=====================================================================================
    // �޽� ��� ����� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_pulse_out_method(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pulse_out_method(short axis);
    // method : ��� �޽� ��� ����(typedef : PULSE_OUTPUT)
    // OneHighLowHigh   = 0x0, 1�޽� ���, PULSE(Active High), ������(DIR=Low)  / ������(DIR=High)
    // OneHighHighLow   = 0x1, 1�޽� ���, PULSE(Active High), ������(DIR=High) / ������(DIR=Low)
    // OneLowLowHigh    = 0x2, 1�޽� ���, PULSE(Active Low),  ������(DIR=Low)  / ������(DIR=High)
    // OneLowHighLow    = 0x3, 1�޽� ���, PULSE(Active Low),  ������(DIR=High) / ������(DIR=Low)
    // TwoCcwCwHigh     = 0x4, 2�޽� ���, PULSE(CCW:������),  DIR(CW:������),  Active High 
    // TwoCcwCwLow      = 0x5, 2�޽� ���, PULSE(CCW:������),  DIR(CW:������),  Active Low 
    // TwoCwCcwHigh     = 0x6, 2�޽� ���, PULSE(CW:������),   DIR(CCW:������), Active High
    // TwoCwCcwLow      = 0x7, 2�޽� ���, PULSE(CW:������),   DIR(CCW:������), Active Low

    // ��ġ Ȯ�� �� ��ġ �� ���� �Լ��� -===============================================================================
    // �ܺ� ��ġ ���� �����Ѵ�. ������ ���¿��� �ܺ� ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern void CFSset_actual_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFSget_actual_position(short axis);
    // ���� ��ġ ���� �����Ѵ�. ������ ���¿��� ���� ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern void CFSset_command_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFSget_command_position(short axis);

    // ���� ����̹� ��� ��ȣ ���� �Լ���-===============================================================================
    // ���� Enable��� ��ȣ�� Active Level�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_servo_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_servo_level(short axis);
    // ���� Enable(On) / Disable(Off)�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_servo_enable(short axis, byte state);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_servo_enable(short axis);
    
    // ���� ����̹� �Է� ��ȣ ���� �Լ���-===============================================================================
    // ���� ��ġ�����Ϸ�(inposition)�Է� ��ȣ�� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_inposition_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_inposition_enable(short axis);
    // ���� ��ġ�����Ϸ�(inposition)�Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_inposition_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_inposition_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_inposition_switch(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFSin_position(short axis);
    // ���� �˶� �Է½�ȣ ����� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_alarm_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_alarm_enable(short axis);
    // ���� �˶� �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_alarm_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_alarm_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_alarm_switch(short axis);
    
    // ����Ʈ ��ȣ ���� �Լ���-===========================================================================================
    // ������ ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_end_limit_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_end_limit_enable(short axis);
    // -������ ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_nend_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_nend_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_nend_limit_switch(short axis);
    // +������ ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_pend_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pend_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pend_limit_switch(short axis);
    // �������� ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_slow_limit_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_slow_limit_enable(short axis);
    // -�������� ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_nslow_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_nslow_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_nslow_limit_switch(short axis);    
    // +�������� ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_pslow_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pslow_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_pslow_limit_switch(short axis);
    
    // ������� ��ȣ-=====================================================================================================
    // ESTOP, SSTOP ��ȣ ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_emg_signal_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_emg_signal_enable(short axis);
    
    // ���� ���� �Ÿ� ����-===============================================================================================
    // start_** : ���� �࿡�� ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�(Blocking).
    // *r*_*    : ���� �࿡�� �Էµ� �Ÿ���ŭ(�����ǥ)�� �̵��Ѵ�. "*r_*�� ������ �Էµ� ��ġ(������ǥ)�� �̵��Ѵ�.
    // *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    // *a*_*    : ������ �ӵ� �����ӵ��� ���Ī���� ����Ѵ�. ���ӷ� �Ǵ� ���� �ð���  ���ӷ� �Ǵ� ���� �ð��� ���� �Է¹޴´�.
    // *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.
    // �Է� ����: velocity(Unit/Sec), acceleration/deceleration(Unit/Sec^2), acceltime/deceltime(Sec), position(Unit)

    // ��Ī �����޽�(Pulse Drive), ��ٸ��� ���� �Լ�, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern ushort CFSmove(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSmove_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern ushort CFSr_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSr_move_ex(short axis, double distance, double velocity, double acceltime);
    // Non Blocking�Լ� (�������� ��� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_r_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_r_move_ex(short axis, double distance, double velocity, double acceltime);
    // ��Ī �����޽�(Pulse Drive), S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern ushort CFSs_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSs_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern ushort CFSrs_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFSrs_move_ex(short axis, double distance, double velocity, double acceltime);
    // Non Blocking�Լ� (�������� ��� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_rs_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_rs_move_ex(short axis, double distance, double velocity, double acceltime);

    // ���� ���� ����-====================================================================================================
    // ���� �����ӵ� �� �ӵ��� ���� ������ �߻����� ������ ���������� �����Ѵ�.
    // *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    // *a*_*    : ������ �ӵ� �����ӵ��� ���Ī���� ����Ѵ�. ���ӷ� �Ǵ� ���� �ð���  ���ӷ� �Ǵ� ���� �ð��� ���� �Է¹޴´�.
    // *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.

    // ���ӵ� ��ٸ��� ���� �Լ���, ������/���ӽð�(_ex)(�ð�����:Sec) - �������� ��쿡�� �ӵ��������̵�
    [DllImport("AxtLib.dll")] public static extern int CFSv_move(short axis, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSv_move_ex(short axis, double velocity, double acceltime);
    // ���ӵ� S���� ���� �Լ���, ������/���ӽð�(_ex)(�ð�����:Sec) - �������� ��쿡�� �ӵ��������̵� (�� �������϶� ����)
    [DllImport("AxtLib.dll")] public static extern int CFSv_s_move(short axis, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSv_s_move_ex(short axis, double velocity, double acceltime);
 
    // ��ȣ ���� ����-====================================================================================================
    // ���� ��ȣ�� ����/���� ������ �˻��Ͽ� ������ �Ǵ� ���������� �� �� �ִ�.
    // detect_signal : �˻� ��ȣ ����(typedef : DETECT_DESTINATION_SIGNAL)
    // PElmNegativeEdge    = 0x0,        // +Elm(End limit) �ϰ� edge
    // NElmNegativeEdge    = 0x1,        // -Elm(End limit) �ϰ� edge
    // PSlmNegativeEdge    = 0x2,        // +Slm(Slowdown limit) �ϰ� edge
    // NSlmNegativeEdge    = 0x3,        // -Slm(Slowdown limit) �ϰ� edge
    // In0DownEdge         = 0x4,        // IN0(ORG) �ϰ� edge
    // In1DownEdge         = 0x5,        // IN1(Z��) �ϰ� edge
    // In2DownEdge         = 0x6,        // IN2(����) �ϰ� edge
    // In3DownEdge         = 0x7,        // IN3(����) �ϰ� edge
    // PElmPositiveEdge    = 0x8,        // +Elm(End limit) ��� edge
    // NElmPositiveEdge    = 0x9,        // -Elm(End limit) ��� edge
    // PSlmPositiveEdge    = 0xa,        // +Slm(Slowdown limit) ��� edge
    // NSlmPositiveEdge    = 0xb,        // -Slm(Slowdown limit) ��� edge
    // In0UpEdge           = 0xc,        // IN0(ORG) ��� edge
    // In1UpEdge           = 0xd,        // IN1(Z��) ��� edge
    // In2UpEdge           = 0xe,        // IN2(����) ��� edge
    // In3UpEdge           = 0xf         // IN3(����) ��� edge
    // Signal Search1 : ���� ������ �Է� �ӵ����� �����Ͽ�, ��ȣ ������ ���� ����.
    // Signal Search2 : ���� ������ ���Ӿ��� �Է� �ӵ��� �ǰ�, ��ȣ ������ ������. 
    // ���� : Signal Search2�� �������� �����Ƿ� �ӵ��� ������� Ż���� �ⱸ���� ������ ���� �����Ƿ� �����Ѵ�.
    // *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    // *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.
    
    // ��ȣ����1(Signal search 1) ��ٸ��� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_signal_search1(short axis, double velocity, double acceleration, byte detect_signal);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_signal_search1_ex(short axis, double velocity, double acceltime, byte detect_signal);
    // ��ȣ����1(Signal search 1) S���� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_signal_search1(short axis, double velocity, double acceleration, byte detect_signal);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_signal_search1_ex(short axis, double velocity, double acceltime, byte detect_signal);
    // ��ȣ����2(Signal search 2) ��ٸ��� ����, ������ ����
    [DllImport("AxtLib.dll")] public static extern int CFSstart_signal_search2(short axis, double velocity, byte detect_signal);

    // �������̵�(������)-================================================================================================
    // ���� ���� �Ÿ� ������ ���� ���۽������� �Է��� ��ġ(������ġ)�� ������ �ٲ۴�.
    [DllImport("AxtLib.dll")] public static extern int CFSposition_override(short axis, double overrideposition);
    // ���� ���� �Ÿ� ������ ���� ���۽������� �Է��� �Ÿ�(�����ġ)�� ������ �ٲ۴�.    
    [DllImport("AxtLib.dll")] public static extern int CFSposition_r_override(short axis, double overridedistance);
    // ������ ���� �ʱ� ������ �ӵ��� �ٲ۴�.(set_max_speed > velocity > set_startstop_speed)
    [DllImport("AxtLib.dll")] public static extern int CFSvelocity_override(short axis, double velocity);

    // ���� ���� Ȯ��-====================================================================================================
    // ���� ���� ������ ����� ������ ��ٸ� �� �Լ��� �����.
    [DllImport("AxtLib.dll")] public static extern ushort CFSwait_for_done(short axis);

    // ���� ���� ����-====================================================================================================
    // ���� ���� �������Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_e_stop(short axis);
    // ���� ���� ������ �������� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_stop(short axis);
    // ���� ���� �Էµ� �������� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_stop_decel(short axis, double deceleration);
    // ���� ���� �Էµ� ���� �ð����� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_stop_deceltime(short axis, double deceltime);

    // ���� ���� �������� ����-==========================================================================================
    // Master/Slave link �Ǵ� ��ǥ�� link ���� �ϳ��� ����Ͽ��� �Ѵ�.
    // Master/Slave link ����. (�Ϲ� ���� ������ master �� ������ slave�൵ ���� �����ȴ�.)
    [DllImport("AxtLib.dll")] public static extern int CFSlink(short master, short slave, double ratio);
    // Master/Slave link ����
    [DllImport("AxtLib.dll")] public static extern int CFSendlink(short slave);

    // ��ǥ�� link ����-================================================================================================
    // ���� ��ǥ�迡 �� �Ҵ� - n_axes������ŭ�� ����� ����/Ȯ���Ѵ�.(coordinate�� 1..8���� ��� ����)
    // n_axes ������ŭ�� ����� ����/Ȯ���Ѵ�. - (n_axes�� 1..4���� ��� ����)
    [DllImport("AxtLib.dll")] public static extern int CFSmap_axes(short coordinate, short n_axes, short[] map_array);
    [DllImport("AxtLib.dll")] public static extern int CFSget_mapped_axes(short coordinate, short n_axes, ref short map_array);
    // ���� ��ǥ���� ���/���� ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_coordinate_mode(short coordinate, short mode);
    [DllImport("AxtLib.dll")] public static extern short CFSget_coordinate_mode(short coordinate);
    // mode:
    // 0: �����ǥ����, 1: ������ǥ ����
    // ���� ��ǥ���� �ӵ� �������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_profile(short coordinate, short mode);
    [DllImport("AxtLib.dll")] public static extern short CFSget_move_profile(short coordinate);
    // mode:
    // 0: ��ٸ��� ����, 1: SĿ�� ����
    // ���� ��ǥ���� �ʱ� �ӵ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_startstop_velocity(short coordinate, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFSget_move_startstop_velocity(short coordinate);
    // Ư�� ��ǥ���� �ӵ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_velocity(short coordinate, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFSget_move_velocity(short coordinate);
    // Ư�� ��ǥ���� �������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_acceleration(short coordinate, double acceleration);
    [DllImport("AxtLib.dll")] public static extern double CFSget_move_acceleration(short coordinate);
    // Ư�� ��ǥ���� ���� �ð�(Sec)�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_move_acceltime(short coordinate, double acceltime);
    [DllImport("AxtLib.dll")] public static extern double CFSget_move_acceltime(short coordinate);
    // ���� ��������  ��ǥ���� ���� �����ӵ��� ��ȯ�Ѵ�.
    [DllImport("AxtLib.dll")] public static extern double CFSco_get_velocity(short coordinate);

    // ����Ʈ���� ���� ����(���� ��ǥ�迡 ���Ͽ�)-========================================================================
    // Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    // 2, 3, 4���� �����̵��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSmove_2(short coordinate, double x, double y);
    [DllImport("AxtLib.dll")] public static extern int CFSmove_3(short coordinate, double x, double y, double z);
    [DllImport("AxtLib.dll")] public static extern int CFSmove_4(short coordinate, double x, double y, double z, double w);
    // Non Blocking�Լ� (�������� ��� ���õ�)
    // 2, 3, 4���� ���� �̵��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_2(short coordinate, double x, double y);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_3(short coordinate, double x, double y, double z);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_4(short coordinate, double x, double y, double z, double w);
    // ���� ��ǥ���� ������� ��� �Ϸ� üũ    
    [DllImport("AxtLib.dll")] public static extern int CFSco_motion_done(short coordinate);
    // ���� ��ǥ���� ������ �Ϸ�ɶ� ���� ��ٸ���.
    [DllImport("AxtLib.dll")] public static extern int CFSco_wait_for_done(short coordinate);

    // ���� ����(���� ����) : Master/Slave�� link�Ǿ� ���� ��� ������ �߻� �� �� �ִ�.-==================================
    // ���� ����� ���� �Ÿ� �� �ӵ� ���ӵ� ������ ���� ���� �����Ѵ�. ���� ���ۿ� ���� ����ȭ�� ����Ѵ�. 
    // start_** : ���� �࿡�� ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�.
    // *r*_*    : ���� �࿡�� �Էµ� �Ÿ���ŭ(�����ǥ)�� �̵��Ѵ�. "*r_*�� ������ �Էµ� ��ġ(������ǥ)�� �̵��Ѵ�.
    // *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    // *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.

    // ���� �����޽�(Pulse Drive)����, ��ٸ��� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� ��� �������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern byte CFSmove_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFSmove_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern byte CFSr_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFSr_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // Non Blocking�Լ� (�������� ���� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_r_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_r_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // ���� �����޽�(Pulse Drive)����, S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� ��� �������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern byte CFSs_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFSs_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern byte CFSrs_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFSrs_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // Non Blocking�Լ� (�������� ���� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_s_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_rs_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFSstart_rs_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    //���� ��鿡 ���Ͽ� S���� ������ ���� �����ӽ��� SĿ���� ������ ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_s_rate_all(short number, short[] axes, double[] a_percent, double[] b_percent);
    [DllImport("AxtLib.dll")] public static extern void CFSget_s_rate_all(short number, ref short axes, ref double a_percent, ref double b_percent);
    
    // ���� ���� Ȯ��-====================================================================================================
    // �Է� �ش� ����� ���� ���¸� Ȯ���ϰ� ������ ���� �� ���� ��ٸ���.
    [DllImport("AxtLib.dll")] public static extern byte CFSwait_for_all(short number, short[] axes);

    // ���� ���� ����-====================================================================================================
    // ���� ����� ���⸦ ������Ų��. - ��������� �������� ���������ʰ� �����.
    [DllImport("AxtLib.dll")] public static extern int CFSreset_axis_sync(short nLen, short[] aAxis);
    // ���� ����� ���⸦ ������Ų��. - ��������� �������� ���������ʰ� �����.
    [DllImport("AxtLib.dll")] public static extern int CFSset_axis_sync(short nLen, ref short aAxis);

    // ���� ���� ����-====================================================================================================
    // Ȩ ��ġ �����嵵 ����
    [DllImport("AxtLib.dll")] public static extern int CFSemergency_stop();

    // -�����˻� =========================================================================================================
    // ���̺귯�� �󿡼� Thread�� ����Ͽ� �˻��Ѵ�. ���� : ������ Ĩ���� StartStop Speed�� ���� �� �ִ�.
    // �����˻��� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSabort_home_search(short axis, byte bStop);
    // bStop:
    // 0: ��������
    // 1: ������
    // �����˻��� �����Ѵ�. �����ϱ� ���� �����˻��� �ʿ��� ������ �ʿ��ϴ�.
    [DllImport("AxtLib.dll")] public static extern int CFShome_search(short axis);
    // �Է� ����� ���ÿ� �����˻��� �ǽ��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFShome_search_all(short number, short[] axes);
    // ��ȯ��: 0: �����˻� ������, 1: �����˻� ����
    // �����˻� ���� �������� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_done(short axis);
    // �ش� ����� �����˻� ���� �������� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_done_all(short number, ref short axes);
    // ���� ���� ���� �˻� ������ ���� ���¸� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern byte CFSget_home_end_status(short axis);
    // ��ȯ��: 0: �����˻� ����, 1: �����˻� ����
    // ���� ����� ���� �˻� ������ ���� ���¸� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_end_status_all(short number, ref short axes, ref byte endstatus);
    // ���� �˻��� �� ���ܸ��� method�� ����/Ȯ���Ѵ�.
    // Method�� ���� ���� 
    //    0 Bit ���� ��뿩�� ���� (0 : ������� ����, 1: �����
    //    1 Bit ������ ��� ���� (0 : ������, 1 : ���� �ð�)
    //    2 Bit ������� ���� (0 : ���� ����, 1 : �� ����)
    //    3 Bit �˻����� ���� (0 : cww(-), 1 : cw(+))
    // 7654 Bit detect signal ����(typedef : DETECT_DESTINATION_SIGNAL)
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_method(short axis, short nstep, byte[] method);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_method(short axis, short nstep, ref byte method);
    // ���� �˻��� �� ���ܸ��� offset�� ����/Ȯ���Ѵ�.    
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_offset(short axis, short nstep, double[] offset);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_offset(short axis, short nstep, ref double offset);
    // �� ���� ���� �˻� �ӵ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_velocity(short axis, short nstep, double[] velocity);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_velocity(short axis, short nstep, ref double velocity);
    // ���� ���� ���� �˻� �� �� ���ܺ� �������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_acceleration(short axis, short nstep, double[] acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_acceleration(short axis, short nstep, ref double acceleration);
    // ���� ���� ���� �˻� �� �� ���ܺ� ���� �ð��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_home_acceltime(short axis, short nstep, double[] acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFSget_home_acceltime(short axis, short nstep, ref double acceltime);
    // ���� �࿡ ���� �˻����� ���ڴ� 'Z'�� ���� ��� �� ���� �Ѱ谪�� ����/Ȯ���Ѵ�.(Pulse) - ������ ����� �˻� ����
    [DllImport("AxtLib.dll")] public static extern int CFSset_zphase_search_range(short axis, short pulses);
    [DllImport("AxtLib.dll")] public static extern short CFSget_zphase_search_range(short axis);
    // ���� ��ġ�� ����(0 Position)���� �����Ѵ�. - �������̸� ���õ�.
    [DllImport("AxtLib.dll")] public static extern int CFShome_zero(short axis);
    // ������ ��� ���� ���� ��ġ�� ����(0 Position)���� �����Ѵ�. - �������� ���� ���õ�
    [DllImport("AxtLib.dll")] public static extern int CFShome_zero_all(short number, short[] axes);

    // ���� �����-=======================================================================================================
    // ���� ���
    // 0 bit : ���� ��� 0(Servo-On)
    // 1 bit : ���� ��� 1(ALARM Clear)
    // 2 bit : ���� ��� 2
    // 3 bit : ���� ��� 3
    // ���� �Է�
    // 0 bit : ���� �Է� 0(ORiginal Sensor)
    // 1 bit : ���� �Է� 1(Z phase)
    // 2 bit : ���� �Է� 2
    // 3 bit : ���� �Է� 3
    // On ==> ���ڴ� N24V, 'Off' ==> ���ڴ� Open(float).

    // ���� ���� ��°��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_output(short axis, byte value);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_output(short axis);
    // ���� �Է� ���� Ȯ���Ѵ�.
    // '1'('On') <== ���ڴ� N24V�� �����, '0'('Off') <== ���ڴ� P24V �Ǵ� Float.
    [DllImport("AxtLib.dll")] public static extern byte CFSget_input(short axis);
    // �ش� ���� �ش� bit�� ����� On/Off ��Ų��.
    // bitNo : 0 ~ 3.
    [DllImport("AxtLib.dll")] public static extern int CFSset_output_bit(short axis, byte bitNo);
    [DllImport("AxtLib.dll")] public static extern int CFSreset_output_bit(short axis, byte bitNo);
    // �ش� ���� �ش� ���� ��� bit�� ��� ���¸� Ȯ���Ѵ�.
    // bitNo : 0 ~ 3.
    [DllImport("AxtLib.dll")] public static extern int CFSoutput_bit_on(short axis, byte bitNo);
    // �ش� ���� �ش� ���� ��� bit�� ���¸� �Է� state�� �ٲ۴�.
    // bitNo : 0 ~ 3. 
    [DllImport("AxtLib.dll")] public static extern int CFSchange_output_bit(short axis, byte bitNo, byte state);
    // �ش� ���� �ش� ���� �Է� bit�� ���¸� Ȯ�� �Ѵ�.
    // bitNo : 0 ~ 3.
    [DllImport("AxtLib.dll")] public static extern int CFSinput_bit_on(short axis, byte bitNo);

    // �ܿ� �޽� clear-===================================================================================================
    // �ش� ���� ������ �ܿ� �޽� Clear ����� ��� ���θ� ����/Ȯ���Ѵ�.
    // CLR ��ȣ�� Default ��� ==> ���ڴ� Open�̴�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_mask(short axis);
    // �ش� ���� �ܿ� �޽� Clear ����� Active level�� ����/Ȯ���Ѵ�.
    // Default Active level ==> '1' ==> ���ڴ� N24V
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_level(short axis);
    // �ش� ���� -Emeregency End limit�� ���� Clear��� ��� ������ ����/Ȯ���Ѵ�.    
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_nelm_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_nelm_mask(short axis);
    // �ش� ���� -Emeregency End limit�� Active level�� ����/Ȯ���Ѵ�. set_nend_limit_level�� �����ϰ� �����Ѵ�.    
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_nelm_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_nelm_level(short axis);
    // �ش� ���� +Emeregency End limit�� ���� Clear��� ��� ������ ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_pelm_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_pelm_mask(short axis);
    // �ش� ���� +Emeregency End limit�� Active level�� ����/Ȯ���Ѵ�. set_nend_limit_level�� �����ϰ� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_crc_pelm_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_crc_pelm_level(short axis);
    // �ش� ���� �ܿ� �޽� Clear ����� �Է� ������ ���� ���/Ȯ���Ѵ�.    
    [DllImport("AxtLib.dll")] public static extern int CFSset_programmed_crc(short axis, short data);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_programmed_crc(short axis);

    // Ʈ���� ��� ======================================================================================================
    // ����/�ܺ� ��ġ�� ���Ͽ� �ֱ�/���� ��ġ���� ������ Active level�� Trigger pulse�� �߻� ��Ų��.
    // Ʈ���� ��� �޽��� Active level�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_level(short axis, byte trigger_level);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_trigger_level(short axis);
    // Ʈ���� ��ɿ� ����� ���� ��ġ�� �����Ѵ�.
    // 0x0 : �ܺ� ��ġ External(Actual)
    // 0x1 : ���� ��ġ Internal(Command)
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_sel(short axis, byte trigger_sel);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_trigger_sel(short axis);
    // Ʈ���� �޽����� ����/Ȯ���Ѵ�.
    // 0Fh : 64 msec
    // 0Eh : 32 msec
    // 0Dh : 16 mSec
    // ..
    // 04h : 0.062msec
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_time(short axis, byte time);
    [DllImport("AxtLib.dll")] public static extern byte CFSget_trigger_time(short axis);
    // ���� ���� Ʈ���� ����� ��� ���θ� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_enable(short axis, byte ena_status);
    [DllImport("AxtLib.dll")] public static extern byte CFSis_trigger_enabled(short axis);
    // ���� �࿡ Ʈ���� �߻��� ���ͷ�Ʈ�� �߻��ϵ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_trigger_interrupt_enable(short axis, byte ena_int);
    [DllImport("AxtLib.dll")] public static extern byte CFSis_trigger_interrupt_enabled(short axis);

    // ��ġ �񱳱� ���� �Լ��� ==========================================================================================
    // Internal(Command) comparator���� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_internal_comparator_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFSget_internal_comparator_position(short axis);
    // External(Encoder) comparator���� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFSset_external_comparator_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFSget_external_comparator_position(short axis);

    // �����Ϸ� ���ͷ�Ʈ ������ �Լ��� ==========================================================================================
    // ���� �Ϸ�� ���ͷ�Ʈ ����� ������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFSset_motiondone_interrupt_enable(short axis, byte ena_int);
    [DllImport("AxtLib.dll")] public static extern byte CFSis_motiondone_interrupt_enabled(short axis);

    // �����ڵ� �б� �Լ��� =============================================================================================
    // ������ �����ڵ带 �д´�.
    [DllImport("AxtLib.dll")] public static extern short CFSget_error_code();
    // �����ڵ��� ������ ���ڷ� ��ȯ�Ѵ�.
    [DllImport("AxtLib.dll")] public static extern string CFSget_error_msg(short ErrorCode);
}