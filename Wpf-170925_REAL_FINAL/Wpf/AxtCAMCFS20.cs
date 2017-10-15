using System;
using System.Runtime.InteropServices;

public class CAxtCAMCFS20
{
    /*------------------------------------------------------------------------------------------------*
        AXTCAMCFS Library - CAMC-FS 2.0�̻� Motion module
        ������ǰ
            SMC-1V02 - CAMC-FS Ver2.0 �̻� 1��
            SMC-2V02 - CAMC-FS Ver2.0 �̻� 2��
    *------------------------------------------------------------------------------------------------*/

    // ���� �ʱ�ȭ �Լ���        -======================================================================================
    // CAMC-FS�� ������ ���(SMC-1V02, SMC-2V02)�� �˻��Ͽ� �ʱ�ȭ�Ѵ�. CAMC-FS 2.0�̻� �����Ѵ�
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
    [DllImport("AxtLib.dll")] public static extern int InitializeCAMCFS20(int reset);
    // CAMC-FS20 ����� ����� ���������� Ȯ���Ѵ�
    // ���ϰ� :  1(TRUE) = CAMC-FS20 ����� ��� �����ϴ�
    [DllImport("AxtLib.dll")] public static extern int CFS20IsInitialized();
    // CAMC-FS20�� ������ ����� ����� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern void CFS20StopService();

    /// ���� ���� ���� �Լ���        -===================================================================================
    // ������ �ּҿ� ������ ���̽������� ��ȣ�� �����Ѵ�. ������ -1�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFS20get_boardno(uint address);
    // ���̽������� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFS20get_numof_boards();
    // ������ ���̽����忡 ������ ���� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFS20get_numof_axes(short nBoardNo);
    // ���� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFS20get_total_numof_axis();
    // ������ ���̽������ȣ�� ����ȣ�� �ش��ϴ� ���ȣ�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short CFS20get_axisno(short nBoardNo, short nModuleNo);
    // ������ ���� ������ �����Ѵ�
    // nBoardNo : �ش� ���� ������ ���̽������� ��ȣ.
    // nModuleNo: �ش� ���� ������ ����� ���̽� ��峻 ��� ��ġ(0~3)
    // bModuleID: �ش� ���� ������ ����� ID : SMC-2V02(0x02)
    // nAxisPos : �ش� ���� ������ ����� ù��°���� �ι�° ������ ����.(0 : ù��°, 1 : �ι�°)
    [DllImport("AxtLib.dll")] public static extern int CFS20get_axis_info(short nAxisNo, ref short nBoardNo, ref short nModuleNo, ref byte bModuleID, ref short nAxisPos);

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
    //  9) ���ڴ� �Է¹��2 ������
    // 10) ����/�ܺ� ī���� : 0.     
    [DllImport("AxtLib.dll")] public static extern int CFS20load_parameter(short axis, ref byte nfilename);
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
    //  9) ���ڴ� �Է¹��2 ������
    [DllImport("AxtLib.dll")] public static extern int CFS20save_parameter(short axis, ref byte nfilename); 
    // ��� ���� �ʱⰪ�� ������ ���Ͽ��� �о �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern int CFS20load_parameter_all(ref byte nfilename);
    // ��� ���� �ʱⰪ�� ������ ���Ͽ� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern int CFS20save_parameter_all(ref byte nfilename); 
    
    // ���ͷ�Ʈ �Լ���   -================================================================================================
    //(���ͷ�Ʈ�� ����ϱ� ���ؼ��� 
    //Window message & procedure
    //    hWnd    : ������ �ڵ�, ������ �޼����� ������ ���. ������� ������ NULL�� �Է�.
    //    wMsg    : ������ �ڵ��� �޼���, ������� �ʰų� ����Ʈ���� ����Ϸ��� 0�� �Է�.
    //    proc    : ���ͷ�Ʈ �߻��� ȣ��� �Լ��� ������, ������� ������ NULL�� �Է�.
    [DllImport("AxtLib.dll")] public static extern void CFS20SetWindowMessage(IntPtr hWnd, ushort wMsg, CAxdLibDef.AXT_CAMCFS_INTERRUPT_PROC proc);    
    //-===============================================================================
    // ReadInterruptFlag���� ������ ���� flag������ �о� ���� �Լ�(���ͷ�Ʈ service routine���� ���ͷ��� �߻� ������ �Ǻ��Ѵ�.)
    // ���ϰ�: ���ͷ�Ʈ�� �߻� �Ͽ����� �߻��ϴ� ���ͷ�Ʈ flag register(CAMC-FS20 �� INTFLAG ����.)
    [DllImport("AxtLib.dll")] public static extern uint CFS20read_interrupt_flag(short axis);

    // ���� ���� �ʱ�ȭ �Լ���        -==================================================================================
    // ����Ŭ�� ����( ��⿡ ������ Oscillator�� ����� ��쿡�� ����)
    [DllImport("AxtLib.dll")] public static extern void CFS20KeSetMainClk(int nMainClk);
    // Drive mode 1�� ����/Ȯ���Ѵ�.
    // decelstartpoint : �����Ÿ� ���� ��� ����� ���� ��ġ ���� ��� ����(0 : �ڵ� ������, 1 : ���� ������)
    // pulseoutmethod : ��� �޽� ��� ����(typedef : PULSE_OUTPUT)
    // detecsignal : ��ȣ �˻�-1/2 ���� ��� ����� �˻� �� ��ȣ ����(typedef : DETECT_DESTINATION_SIGNAL)
    [DllImport("AxtLib.dll")] public static extern void CFS20set_drive_mode1(short axis, 
                       byte decelstartpoint,
                       byte pulseoutmethod,
                       byte detectsignal);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_drive_mode1(short axis);
    // Drive mode 2�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_drive_mode2(short axis, 
                       byte encmethod,
                       byte inpactivelevel,
                       byte alarmactivelevel,
                       byte nslmactivelevel,
                       byte pslmactivelevel,
                       byte nelmactivelevel,
                       byte pelmactivelevel);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20get_drive_mode2(short axis);
    // Unit/Pulse ����/Ȯ���Ѵ�.
    // Unit/Pulse : 1 pulse�� ���� system�� �̵��Ÿ��� ���ϸ�, �̶� Unit�� ������ ����ڰ� ���Ƿ� ������ �� �ִ�.
    // Ex) Ball screw pitch : 10mm, ���� 1ȸ���� �޽��� : 10000 ==> Unit�� mm�� ������ ��� : Unit/Pulse = 10/10000.
    // ���� unitperpulse�� 0.001�� �Է��ϸ� ��� ��������� mm�� ������. 
    // Ex) Linear motor�� ���ش��� 1 pulse�� 2 uM. ==> Unit�� mm�� ������ ��� : Unit/Pulse = 0.002/1.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_moveunit_perpulse(short axis, double unitperpulse);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_moveunit_perpulse(short axis);
    // Unit/Pulse�� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_movepulse_perunit(short axis, double pulseperunit);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_movepulse_perunit(short axis);
    // ���� �ӵ� ����/Ȯ���Ѵ�.(Unit/Sec)
    [DllImport("AxtLib.dll")] public static extern void CFS20set_startstop_speed(short axis, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_startstop_speed(short axis);
    // �ְ� �ӵ� ���� Unit/Sec. ���� system�� �ְ� �ӵ��� �����Ѵ�.
    // Unit/Pulse ������ ���ۼӵ� ���� ���Ŀ� �����Ѵ�.
    // ������ �ְ� �ӵ� �̻����δ� ������ �Ҽ� �����Ƿ� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_max_speed(short axis, double max_velocity);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_max_speed(short axis);
    // SW�� ����� ���� ����/Ȯ���Ѵ�. �̰����� S-Curve ������ percentage�� ���� �����ϴ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_s_rate(short axis, double a_percent, double b_percent);
    [DllImport("AxtLib.dll")] public static extern void CFS20get_s_rate(short axis, ref double a_percent, ref double b_percent);
    // ���� ������ ��忡�� �ܷ� �޽��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_slowdown_rear_pulse(short axis, uint ulData);
    [DllImport("AxtLib.dll")] public static extern uint CFS20get_slowdown_rear_pulse(short axis);
    // ���� ���� ���� ���� ������ ���� ����� ����/Ȯ���Ѵ�.
    // 0x0 : �ڵ� ������.
    // 0x1 : ���� ������.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_decel_point(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_decel_point(short axis);

    // ���� ���� Ȯ�� �Լ���        -=====================================================================================
    // ���� ���� �޽� ����������� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20in_motion(short axis);
    // ���� ���� �޽� ����� ����ƴ��� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20motion_done(short axis);
    // ���� ���� �������� ���� ��µ� �޽� ī���� ���� Ȯ���Ѵ�. (Pulse)
    [DllImport("AxtLib.dll")] public static extern int CFS20get_drive_pulse_counts(short axis);
    // ���� ���� DriveStatus �������͸� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern ushort CFS20get_drive_status(short axis);
    // ���� ���� EndStatus �������͸� Ȯ���Ѵ�.
    // End Status Bit�� �ǹ�
    // 14bit : Limit(PELM, NELM, PSLM, NSLM, Soft)�� ���� ����
    // 13bit : Limit ���� ������ ���� ����
    // 12bit : Sensor positioning drive����
    // 11bit : Preset pulse drive�� ���� ����(������ ��ġ/�Ÿ���ŭ �����̴� �Լ���)
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
    [DllImport("AxtLib.dll")] public static extern ushort CFS20get_end_status(short axis);
    // ���� ���� Mechanical �������͸� Ȯ���Ѵ�.
    // Mechanical Signal Bit�� �ǹ�
    // 12bit : ESTOP ��ȣ �Է� Level
    // 11bit : SSTOP ��ȣ �Է� Level
    // 10bit : MARK ��ȣ �Է� Level
    // 9 bit : EXPP(MPG) ��ȣ �Է� Level
    // 8 bit : EXMP(MPG) ��ȣ �Է� Level
    // 7 bit : Encoder Up��ȣ �Է� Level(A�� ��ȣ)
    // 6 bit : Encoder Down��ȣ �Է� Level(B�� ��ȣ)
    // 5 bit : INPOSITION ��ȣ Active ����
    // 4 bit : ALARM ��ȣ Active ����
    // 3 bit : -Limit �������� ��ȣ Active ���� (Ver3.0���� ����������)
    // 2 bit : +Limit �������� ��ȣ Active ���� (Ver3.0���� ����������)
    // 1 bit : -Limit ������ ��ȣ Active ����
    // 0 bit : +Limit ������ ��ȣ Active ����
    [DllImport("AxtLib.dll")] public static extern ushort CFS20get_mechanical_signal(short axis);
    // ���� ����  ���� �ӵ��� �о� �´�.(Unit/Sec)
    [DllImport("AxtLib.dll")] public static extern double CFS20get_velocity(short axis);
    // ���� ���� Command position�� Actual position�� ���� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern double CFS20get_error(short axis);
    // ���� ���� ���� ����̺��� �̵� �Ÿ��� Ȯ�� �Ѵ�. (Unit)
    [DllImport("AxtLib.dll")] public static extern double CFS20get_drivedistance(short axis);

    // Encoder �Է� ��� ���� �Լ���        -=============================================================================
    // ���� ���� Encoder �Է� ����� ����/Ȯ���Ѵ�.
    // method : typedef(EXTERNAL_COUNTER_INPUT)
    // UpDownMode = 0x0    // Up/Down
    // Sqr1Mode   = 0x1    // 1ü��
    // Sqr2Mode   = 0x2    // 2ü��
    // Sqr4Mode   = 0x3    // 4ü��
    [DllImport("AxtLib.dll")] public static extern int CFS20set_enc_input_method(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_enc_input_method(short axis);
    // ���� ���� �ܺ� ��ġ counter clear�� ����� ����/Ȯ���Ѵ�.
    // method : CAMC-FS chip �޴��� EXTCNTCLR �������� ����.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_enc2_input_method(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte  CFS20get_enc2_input_method(short axis);
    // ���� ���� �ܺ� ��ġ counter�� count ����� ����/Ȯ���Ѵ�.
    // reverse :
    // TRUE  : �Է� ���ڴ��� �ݴ�Ǵ� �������� count�Ѵ�.
    // FALSE : �Է� ���ڴ��� ���� ���������� count�Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_enc_reverse(short axis, byte reverse);
    [DllImport("AxtLib.dll")] public static extern int CFS20get_enc_reverse(short axis);

    // �޽� ��� ��� �Լ���        -=====================================================================================
    // �޽� ��� ����� ����/Ȯ���Ѵ�.
    // method : ��� �޽� ��� ����(typedef : PULSE_OUTPUT)
    // OneHighLowHigh   = 0x0, 1�޽� ���, PULSE(Active High), ������(DIR=Low)  / ������(DIR=High)
    // OneHighHighLow   = 0x1, 1�޽� ���, PULSE(Active High), ������(DIR=High) / ������(DIR=Low)
    // OneLowLowHigh    = 0x2, 1�޽� ���, PULSE(Active Low),  ������(DIR=Low)  / ������(DIR=High)
    // OneLowHighLow    = 0x3, 1�޽� ���, PULSE(Active Low),  ������(DIR=High) / ������(DIR=Low)
    // TwoCcwCwHigh     = 0x4, 2�޽� ���, PULSE(CCW:������),  DIR(CW:������),  Active High 
    // TwoCcwCwLow      = 0x5, 2�޽� ���, PULSE(CCW:������),  DIR(CW:������),  Active Low 
    // TwoCwCcwHigh     = 0x6, 2�޽� ���, PULSE(CW:������),   DIR(CCW:������), Active High
    // TwoCwCcwLow      = 0x7, 2�޽� ���, PULSE(CW:������),   DIR(CCW:������), Active Low
    [DllImport("AxtLib.dll")] public static extern int CFS20set_pulse_out_method(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_pulse_out_method(short axis);

    // ��ġ Ȯ�� �� ��ġ �� ���� �Լ��� -===============================================================================
    // �ܺ� ��ġ ���� �����Ѵ�. ������ ���¿��� �ܺ� ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern void CFS20set_actual_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_actual_position(short axis);
    // ���� ��ġ ���� �����Ѵ�. ������ ���¿��� ���� ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern void CFS20set_command_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_command_position(short axis);

    // ���� ����̹� ��� ��ȣ ���� �Լ���-===============================================================================
    // ���� Enable��� ��ȣ�� Active Level�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_servo_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_servo_level(short axis);    
    // ���� Enable(On) / Disable(Off)�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_servo_enable(short axis, byte state);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_servo_enable(short axis);
    
    // ���� ����̹� �Է� ��ȣ ���� �Լ���-===============================================================================
    // ���� ��ġ�����Ϸ�(inposition)�Է� ��ȣ�� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_inposition_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_inposition_enable(short axis);
    // ���� ��ġ�����Ϸ�(inposition)�Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_inposition_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_inposition_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_inposition_switch(short axis);
    [DllImport("AxtLib.dll")] public static extern int CFS20in_position(short axis);
    // ���� �˶� �Է½�ȣ ����� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_alarm_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_alarm_enable(short axis);
    // ���� �˶� �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_alarm_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_alarm_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_alarm_switch(short axis);

    // ����Ʈ ��ȣ ���� �Լ���-===========================================================================================
    // ������ ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_end_limit_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_end_limit_enable(short axis);
    // -������ ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_nend_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_nend_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_nend_limit_switch(short axis);
    // +������ ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_pend_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_pend_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_pend_limit_switch(short axis);
    // �������� ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_slow_limit_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_slow_limit_enable(short axis);
    // -�������� ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_nslow_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_nslow_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_nslow_limit_switch(short axis);
    // +�������� ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_pslow_limit_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_pslow_limit_level(short axis);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_pslow_limit_switch(short axis);
    // -LIMIT ���� ������ ��/�������� ���θ� ����/Ȯ���Ѵ�. (Ver 3.0���� ����)
    // stop:
    // 0 : ������, 1 : ��������
    [DllImport("AxtLib.dll")] public static extern int CFS20set_nlimit_sel(short axis, byte stop);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_nlimit_sel(short axis);
    // +LIMIT ���� ������ ��/�������� ���θ� ����/Ȯ���Ѵ�. (Ver 3.0���� ����)    
    // stop:
    // 0 : ������, 1 : ��������
    [DllImport("AxtLib.dll")] public static extern int CFS20set_plimit_sel(short axis, byte stop);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_plimit_sel(short axis);

    // ����Ʈ���� ����Ʈ ���� �Լ���-=====================================================================================
    // ����Ʈ���� ����Ʈ ��������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_soft_limit_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte  CFS20get_soft_limit_enable(short axis);
    // ����Ʈ���� ����Ʈ ���� ������ġ������ ����/Ȯ���Ѵ�.
    // sel :
    // 0x0 : ������ġ�� ���Ͽ� ����Ʈ���� ����Ʈ ��� ����.
    // 0x1 : �ܺ���ġ�� ���Ͽ� ����Ʈ���� ����Ʈ ��� ����.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_soft_limit_sel(short axis, byte sel);
    [DllImport("AxtLib.dll")] public static extern byte  CFS20get_soft_limit_sel(short axis);
    // ����Ʈ���� ����Ʈ �߻��� ���� ��带 ����/Ȯ���Ѵ�.
    // mode :
    // 0x0 : ����Ʈ���� ����Ʈ ��ġ���� ������ �Ѵ�.
    // 0x1 : ����Ʈ���� ����Ʈ ��ġ���� �������� �Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_soft_limit_stopmode(short axis, byte mode);
    [DllImport("AxtLib.dll")] public static extern byte  CFS20get_soft_limit_stopmode(short axis);
    // ����Ʈ���� ����Ʈ -��ġ�� ����/Ȯ���Ѵ�.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern void CFS20set_soft_nlimit_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_soft_nlimit_position(short axis);
    // ����Ʈ���� ����Ʈ +��ġ�� ����/Ȯ�� �Ѵ�.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern void CFS20set_soft_plimit_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_soft_plimit_position(short axis);

    // ������� ��ȣ-=====================================================================================================
    // ESTOP, SSTOP ��ȣ ��������� ����/Ȯ���Ѵ�.(Emergency stop, Slow-Down stop)
    [DllImport("AxtLib.dll")] public static extern int CFS20set_emg_signal_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_emg_signal_enable(short axis);
    // ��������� ��/�������� ���θ� ����/Ȯ���Ѵ�.
    // stop:
    // 0 : ������, 1 : ��������
    [DllImport("AxtLib.dll")] public static extern int CFS20set_stop_sel(short axis, byte stop);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_stop_sel(short axis);

    // ���� ���� �Ÿ� ����-===============================================================================================
    // start_** : ���� �࿡�� ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�(Blocking).
    // *r*_*    : ���� �࿡�� �Էµ� �Ÿ���ŭ(�����ǥ)�� �̵��Ѵ�. "*r_*�� ������ �Էµ� ��ġ(������ǥ)�� �̵��Ѵ�.
    // *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    // *a*_*    : ������ �ӵ� �����ӵ��� ���Ī���� ����Ѵ�. ���ӷ� �Ǵ� ���� �ð���  ���ӷ� �Ǵ� ���� �ð��� ���� �Է¹޴´�.
    // *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.
    // �Է� ����: velocity(Unit/Sec), acceleration/deceleration(Unit/Sec^2), acceltime/deceltime(Sec), position(Unit)

    // ��Ī �����޽�(Pulse Drive), ��ٸ��� ���� �Լ�, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern ushort CFS20move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20r_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20r_move_ex(short axis, double distance, double velocity, double acceltime);
    // Non Blocking�Լ� (�������� ��� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_r_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_r_move_ex(short axis, double distance, double velocity, double acceltime);
    // ���Ī �����޽�(Pulse Drive), ��ٸ��� ���� �Լ�, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern ushort CFS20a_move(short axis, double position, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20a_move_ex(short axis, double position, double velocity, double acceltime, double deceltime);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20ra_move(short axis, double distance, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20ra_move_ex(short axis, double distance, double velocity, double acceltime, double deceltime);
    // Non Blocking�Լ� (�������� ��� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_a_move(short axis, double position, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_a_move_ex(short axis, double position, double velocity, double acceltime, double deceltime);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_ra_move(short axis, double distance, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_ra_move_ex(short axis, double distance, double velocity, double acceltime, double deceltime);
    // ��Ī �����޽�(Pulse Drive), S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern ushort CFS20s_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20s_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20rs_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20rs_move_ex(short axis, double distance, double velocity, double acceltime);
    // Non Blocking�Լ� (�������� ��� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_s_move(short axis, double position, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_s_move_ex(short axis, double position, double velocity, double acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_rs_move(short axis, double distance, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_rs_move_ex(short axis, double distance, double velocity, double acceltime);
    // ���Ī �����޽�(Pulse Drive), S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern ushort CFS20as_move(short axis, double position, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20as_move_ex(short axis, double position, double velocity, double acceltime, double deceltime);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20ras_move(short axis, double distance, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20ras_move_ex(short axis, double distance, double velocity, double acceltime, double deceltime);
    // Non Blocking�Լ� (�������� ��� ���õ�), jerk���(���� : �ۼ�Ʈ) ���������� S�� �̵�����.
    [DllImport("AxtLib.dll")] public static extern int CFS20start_as_move(short axis, double position, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_as_move2(short axis, double position, double velocity, double acceleration, double deceleration, double jerk);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_as_move_ex(short axis, double position, double velocity, double acceltime, double deceltime);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_ras_move(short axis, double distance, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_ras_move_ex(short axis, double distance, double velocity, double acceltime, double deceltime);

    // ��Ī ���� �޽�(Pulse Drive), S���� ����, �����ǥ, ������,
    // Non Blocking (�������� ��� ���õ�), ���� ��ġ�� �������� over_distance���� over_velocity�� �ӵ��� ���� �Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20start_rs_move_override(short axis, double distance, double velocity, double acceleration, double over_distance, double over_velocity, int Target);

    // ���� ���� ����-====================================================================================================
    // ���� �����ӵ� �� �ӵ��� ���� ������ �߻����� ������ ���������� �����Ѵ�.
    // *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    // *a*_*    : ������ �ӵ� �����ӵ��� ���Ī���� ����Ѵ�. ���ӷ� �Ǵ� ���� �ð���  ���ӷ� �Ǵ� ���� �ð��� ���� �Է¹޴´�.
    // *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.

    // ���ӵ� ��ٸ��� ���� �Լ���, ������/���ӽð�(_ex)(�ð�����:Sec) - �������� ��쿡�� �ӵ��������̵�
    // ��Ī ������ �����Լ�
    [DllImport("AxtLib.dll")] public static extern int CFS20v_move(short axis, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20v_move_ex(short axis, double velocity, double acceltime);
    // ���Ī ������ �����Լ�
    [DllImport("AxtLib.dll")] public static extern int CFS20v_a_move(short axis, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20v_a_move_ex(short axis, double velocity, double acceltime, double deceltime);
    // ���ӵ� S���� ���� �Լ���, ������/���ӽð�(_ex)(�ð�����:Sec) - �������� ��쿡�� �ӵ��������̵�
    // ��Ī ������ �����Լ�
    [DllImport("AxtLib.dll")] public static extern int CFS20v_s_move(short axis, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20v_s_move_ex(short axis, double velocity, double acceltime);
    // ���Ī ������ �����Լ�
    [DllImport("AxtLib.dll")] public static extern int CFS20v_as_move(short axis, double velocity, double acceleration, double deceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20v_as_move_ex(short axis, double velocity, double acceltime, double deceltime);

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
    [DllImport("AxtLib.dll")] public static extern int CFS20start_signal_search1(short axis, double velocity, double acceleration, byte detect_signal);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_signal_search1_ex(short axis, double velocity, double acceltime, byte detect_signal);
    // ��ȣ����1(Signal search 1) S���� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_s_signal_search1(short axis, double velocity, double acceleration, byte detect_signal);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_s_signal_search1_ex(short axis, double velocity, double acceltime, byte detect_signal);
    // ��ȣ����2(Signal search 2) ��ٸ��� ����, ������ ����
    [DllImport("AxtLib.dll")] public static extern int CFS20start_signal_search2(short axis, double velocity, byte detect_signal);

    // MPG(Manual Pulse Generation) ���� ����-===========================================================================
    // ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ��带 ����/Ȯ���Ѵ�.
    // mode
    // 0x1 : Slave �������, �ܺ� Differential ��ȣ�� ���� ���
    // 0x2 : ���� �޽� ����, �ܺ� �Է� ��ȣ�� ���� ���� �޽� ���� ����
    // 0x4 : ���� ���� ���, �ܺ� ���� �Է� ��ȣ�� Ư�� ���� ���� ����
    [DllImport("AxtLib.dll")] public static extern int CFS20set_mpg_drive_mode(short axis, byte mode);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_mpg_drive_mode(short axis);
    // ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ���� ������带 ����/Ȯ���Ѵ�.
    // mode
    // 0x0 : �ܺ� ��ȣ�� ���� ���� ����
    // 0x1 : ����ڿ� ���� ������ �������� ����
    [DllImport("AxtLib.dll")] public static extern int CFS20set_mpg_dir_mode(short axis, byte mode);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_mpg_dir_mode(short axis);
    // ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ���� ������尡 ����ڿ� ����
    // ������ �������� �����Ǿ��� �� �ʿ��� ������� ���� ���� ���� ���� ����/Ȯ���Ѵ�.
    // mode
    // 0x0 : ����� ���� ���� ������ +�� ����
    // 0x1 : ����� ���� ���� ������ -�� ����
    [DllImport("AxtLib.dll")] public static extern int CFS20set_mpg_user_dir(short axis, byte mode);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_mpg_user_dir(short axis);
    // ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���Ǵ� EXPP/EXMP �� �Է� ��带 �����Ѵ�.
    //  2 bit : '0' : level input(���� �Է� 4 = EXPP, ���� �Է� 5 = EXMP�� �Է� �޴´�.)
    //          '1' : Differential input(���� �Է����� EXPP, EXMP�� �Է� ����,)
    //  1~0bit: "00" : 1 phase
    //          "01" : 2 phase 1 times
    //          "10" : 2 phase 2 times
    //          "11" : 2 phase 4 times
    [DllImport("AxtLib.dll")] public static extern int CFS20set_mpg_input_method(short axis, byte method);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_mpg_input_method(short axis);
    // MPG��ġ ���� �����Ѵ�. ������ ���¿��� MPG ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
    [DllImport("AxtLib.dll")] public static extern int CFS20set_mpg_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_mpg_position(short axis);

    // MPG(Manual Pulse Generation) ���� -===============================================================================
    // ������ �ӵ��� ��ٸ��� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_mpg(short axis, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_mpg_ex(short axis, double velocity, double acceltime);
    // ������ �ӵ��� S���� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_s_mpg(short axis, double velocity, double acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_s_mpg_ex(short axis, double velocity, double acceltime);

    // �������̵�(������)-================================================================================================
    // ���� ���� �Ÿ� ������ ���� ���۽������� �Է��� ��ġ(������ġ)�� ������ �ٲ۴�.
    [DllImport("AxtLib.dll")] public static extern int CFS20position_override(short axis, double overrideposition);
    // ���� ���� �Ÿ� ������ ���� ���۽������� �Է��� �Ÿ�(�����ġ)�� ������ �ٲ۴�.    
    [DllImport("AxtLib.dll")] public static extern int CFS20position_r_override(short axis, double overridedistance);
    // ������ ���� �ʱ� ������ �ӵ��� �ٲ۴�.(set_max_speed > velocity > set_startstop_speed)
    [DllImport("AxtLib.dll")] public static extern int CFS20velocity_override(short axis, double velocity);
    // ���� ���� ������ ����Ǳ� �� �Էµ� overrideposition���� �ּ� ��� �޽�(dec_pulse) �̻��� ��� override ������ �Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20position_override2(short axis, double overrideposition, double dec_pulse);
    // ���� �࿡ ����/���� ���� ������ ������ ���������� �ӵ� override ������ �Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20velocity_override2(short axis, double velocity, double acceleration, double deceleration, double jerk);
 
    // ���� ���� Ȯ��-====================================================================================================
    // ���� ���� ������ ����� ������ ��ٸ� �� �Լ��� �����.
    [DllImport("AxtLib.dll")] public static extern ushort CFS20wait_for_done(short axis);

    // ���� ���� ����-====================================================================================================
    // ���� ���� �������Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_e_stop(short axis);
    // ���� ���� ������ �������� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_stop(short axis);
    // ���� ���� �Էµ� �������� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_stop_decel(short axis, double deceleration);
    // ���� ���� �Էµ� ���� �ð����� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_stop_deceltime(short axis, double deceltime);

    // ���� ���� �������� ����-==========================================================================================
    // Master/Slave link �Ǵ� ��ǥ�� link ���� �ϳ��� ����Ͽ��� �Ѵ�.
    // Master/Slave link ����. (�Ϲ� ���� ������ master �� ������ slave�൵ ���� �����ȴ�.)
    [DllImport("AxtLib.dll")] public static extern int CFS20link(short master, short slave, double ratio);
    // Master/Slave link ����
    [DllImport("AxtLib.dll")] public static extern int CFS20endlink(short slave);

    // ��ǥ�� link ����-================================================================================================
    // ���� ��ǥ�迡 �� �Ҵ� - n_axes������ŭ�� ����� ����/Ȯ���Ѵ�.(coordinate�� 1..8���� ��� ����)
    // n_axes ������ŭ�� ����� ����/Ȯ���Ѵ�. - (n_axes�� 1..4���� ��� ����)
    [DllImport("AxtLib.dll")] public static extern int CFS20map_axes(short coordinate, short n_axes, short[] map_array);
    [DllImport("AxtLib.dll")] public static extern int CFS20get_mapped_axes(short coordinate, short n_axes, ref short map_array);
    // ���� ��ǥ���� ���/���� ��� ����/Ȯ���Ѵ�.
    // mode:
    // 0: �����ǥ����, 1: ������ǥ ����
    [DllImport("AxtLib.dll")] public static extern void CFS20set_coordinate_mode(short coordinate, short mode);
    [DllImport("AxtLib.dll")] public static extern short CFS20get_coordinate_mode(short coordinate);
    // ���� ��ǥ���� �ӵ� �������� ����/Ȯ���Ѵ�.
    // mode:
    // 0: ��ٸ��� ����, 1: SĿ�� ����
    [DllImport("AxtLib.dll")] public static extern void CFS20set_move_profile(short coordinate, short mode);
    [DllImport("AxtLib.dll")] public static extern short CFS20get_move_profile(short coordinate);
    // ���� ��ǥ���� �ʱ� �ӵ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_move_startstop_velocity(short coordinate, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_move_startstop_velocity(short coordinate);
    // Ư�� ��ǥ���� �ӵ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_move_velocity(short coordinate, double velocity);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_move_velocity(short coordinate);
    // Ư�� ��ǥ���� �������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_move_acceleration(short coordinate, double acceleration);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_move_acceleration(short coordinate);
    // Ư�� ��ǥ���� ���� �ð�(Sec)�� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_move_acceltime(short coordinate, double acceltime);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_move_acceltime(short coordinate);
    // ���� ��������  ��ǥ���� ���� �����ӵ��� ��ȯ�Ѵ�.
    [DllImport("AxtLib.dll")] public static extern double CFS20co_get_velocity(short coordinate);

    // ����Ʈ���� ���� ����(���� ��ǥ�迡 ���Ͽ�)-========================================================================
    // Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    // 2, 3, 4���� �����̵��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20move_2(short coordinate, double x, double y);
    [DllImport("AxtLib.dll")] public static extern int CFS20move_3(short coordinate, double x, double y, double z);
    [DllImport("AxtLib.dll")] public static extern int CFS20move_4(short coordinate, double x, double y, double z, double w);
    // Non Blocking�Լ� (�������� ��� ���õ�)
    // 2, 3, 4���� ���� �̵��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20start_move_2(short coordinate, double x, double y);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_move_3(short coordinate, double x, double y, double z);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_move_4(short coordinate, double x, double y, double z, double w);
    // ���� ��ǥ���� ������� ��� �Ϸ� üũ    
    [DllImport("AxtLib.dll")] public static extern int CFS20co_motion_done(short coordinate);
    // ���� ��ǥ���� ������ �Ϸ�ɶ� ���� ��ٸ���.
    [DllImport("AxtLib.dll")] public static extern int CFS20co_wait_for_done(short coordinate);

    // ���� ����(���� ����) : Master/Slave�� link�Ǿ� ���� ��� ������ �߻� �� �� �ִ�.-==================================
    // ���� ����� ���� �Ÿ� �� �ӵ� ���ӵ� ������ ���� ���� �����Ѵ�. ���� ���ۿ� ���� ����ȭ�� ����Ѵ�. 
    // start_** : ���� �࿡�� ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�.
    // *r*_*    : ���� �࿡�� �Էµ� �Ÿ���ŭ(�����ǥ)�� �̵��Ѵ�. "*r_*�� ������ �Էµ� ��ġ(������ǥ)�� �̵��Ѵ�.
    // *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    // *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.

    // ���� �����޽�(Pulse Drive)����, ��ٸ��� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� ��� �������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern byte CFS20move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFS20move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern byte CFS20r_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFS20r_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // Non Blocking�Լ� (�������� ���� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_r_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_r_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // ���� �����޽�(Pulse Drive)����, S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    // Blocking�Լ� (������� ��� �������� �޽� ����� �Ϸ�� �� �Ѿ��)
    [DllImport("AxtLib.dll")] public static extern byte CFS20s_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFS20s_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern byte CFS20rs_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern byte CFS20rs_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    // Non Blocking�Լ� (�������� ���� ���õ�)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_s_move_all(short number, short[] axes, double[] positions, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_s_move_all_ex(short number, short[] axes, double[] positions, double[] velocities, double[] acceltimes);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_rs_move_all(short number, short[] axes, double[] distances, double[] velocities, double[] accelerations);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_rs_move_all_ex(short number, short[] axes, double[] distances, double[] velocities, double[] acceltimes);
    //���� ��鿡 ���Ͽ� S���� ������ ���� �����ӽ��� SĿ���� ������ ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_s_rate_all(short number, short[] axes, double[] a_percent, double[] b_percent);
    [DllImport("AxtLib.dll")] public static extern void CFS20get_s_rate_all(short number, ref short axes, ref double a_percent, ref double b_percent);

    // ���� ���� Ȯ��-====================================================================================================
    // �Է� �ش� ����� ���� ���¸� Ȯ���ϰ� ������ ���� �� ���� ��ٸ���.
    [DllImport("AxtLib.dll")] public static extern byte CFS20wait_for_all(short number, short[] axes);

    // ���� ���� ����-====================================================================================================
    // ���� ����� ���⸦ ������Ų��. - ��������� �������� ���������ʰ� �����.
    [DllImport("AxtLib.dll")] public static extern int CFS20reset_axis_sync(short nLen, short[] aAxis);
    // ���� ����� ���⸦ ������Ų��. - ��������� �������� ���������ʰ� �����.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_axis_sync(short nLen, ref short aAxis);
    // ������ ���� ���� ����/����/Ȯ���Ѵ�.
    // sync:
    // 0: Reset - ���� �������� ����.
    // 1: Set    - ���� ������.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_sync_axis(short axis, byte sync);
    [DllImport("AxtLib.dll")] public static extern byte  CFS20get_sync_axis(short axis);
    // ������ ����� ���� ���� ����/����/Ȯ���Ѵ�.
    // sync:
    // 0: Reset - ���� �������� ����.
    // 1: Set    - ���� ������.    
    [DllImport("AxtLib.dll")] public static extern int CFS20set_sync_module(short axis, byte sync);
    [DllImport("AxtLib.dll")] public static extern byte  CFS20get_sync_module(short axis);

    // ���� ���� ����-====================================================================================================
    // Ȩ ��ġ �����嵵 ����
    [DllImport("AxtLib.dll")] public static extern int CFS20emergency_stop();

    // -�����˻� =========================================================================================================
    // ���̺귯�� �󿡼� Thread�� ����Ͽ� �˻��Ѵ�. ���� : ������ Ĩ���� StartStop Speed�� ���� �� �ִ�.
    // �����˻��� �����Ѵ�.
    // bStop:
    // 0: ��������
    // 1: ������
    [DllImport("AxtLib.dll")] public static extern int CFS20abort_home_search(short axis, byte bStop);
    // �����˻��� �����Ѵ�. �����ϱ� ���� �����˻��� �ʿ��� ������ �ʿ��ϴ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20home_search(short axis);
    // �Է� ����� ���ÿ� �����˻��� �ǽ��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20home_search_all(short number, short[] axes);
    // �����˻� ���� �������� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20get_home_done(short axis);
    // ��ȯ��: 0: �����˻� ������, 1: �����˻� ����
    // �ش� ����� �����˻� ���� �������� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20get_home_done_all(short number, ref short axes);
    // ���� ���� ���� �˻� ������ ���� ���¸� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_home_end_status(short axis);
    // ��ȯ��: 0: �����˻� ����, 1: �����˻� ����
    // ���� ����� ���� �˻� ������ ���� ���¸� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20get_home_end_status_all(short number, ref short axes, ref byte endstatus);
    // ���� �˻��� �� ���ܸ��� method�� ����/Ȯ���Ѵ�.
    // Method�� ���� ���� 
    //    0 Bit ���� ��뿩�� ���� (0 : ������� ����, 1: �����
    //    1 Bit ������ ��� ���� (0 : ������, 1 : ���� �ð�)
    //    2 Bit ������� ���� (0 : ���� ����, 1 : �� ����)
    //    3 Bit �˻����� ���� (0 : cww(-), 1 : cw(+))
    // 7654 Bit detect signal ����(typedef : DETECT_DESTINATION_SIGNAL)
    [DllImport("AxtLib.dll")] public static extern int CFS20set_home_method(short axis, short nstep, byte[] method);
    [DllImport("AxtLib.dll")] public static extern int CFS20get_home_method(short axis, short nstep, ref byte method);
    // ���� �˻��� �� ���ܸ��� offset�� ����/Ȯ���Ѵ�.    
    [DllImport("AxtLib.dll")] public static extern int CFS20set_home_offset(short axis, short nstep, double[] offset);
    [DllImport("AxtLib.dll")] public static extern int CFS20get_home_offset(short axis, short nstep, ref double offset);
    // �� ���� ���� �˻� �ӵ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_home_velocity(short axis, short nstep, double[] velocity);
    [DllImport("AxtLib.dll")] public static extern int CFS20get_home_velocity(short axis, short nstep, ref double velocity);
    // ���� ���� ���� �˻� �� �� ���ܺ� �������� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_home_acceleration(short axis, short nstep, double[] acceleration);
    [DllImport("AxtLib.dll")] public static extern int CFS20get_home_acceleration(short axis, short nstep, ref double acceleration);
    // ���� ���� ���� �˻� �� �� ���ܺ� ���� �ð��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_home_acceltime(short axis, short nstep, double[] acceltime);
    [DllImport("AxtLib.dll")] public static extern int CFS20get_home_acceltime(short axis, short nstep, ref double acceltime);
    // ���� �࿡ ���� �˻����� ���ڴ� 'Z'�� ���� ��� �� ���� �Ѱ谪�� ����/Ȯ���Ѵ�.(Pulse) - ������ ����� �˻� ����
    [DllImport("AxtLib.dll")] public static extern int CFS20set_zphase_search_range(short axis, short pulses);
    [DllImport("AxtLib.dll")] public static extern short CFS20get_zphase_search_range(short axis);
    // ���� ��ġ�� ����(0 Position)���� �����Ѵ�. - �������̸� ���õ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20home_zero(short axis);
    // ������ ��� ���� ���� ��ġ�� ����(0 Position)���� �����Ѵ�. - �������� ���� ���õ�
    [DllImport("AxtLib.dll")] public static extern int CFS20home_zero_all(short number, short[] axes);

    // ���� �����-=======================================================================================================
    // ���� ���
    // 0 bit : ���� ��� 0(Servo-On)
    // 1 bit : ���� ��� 1(ALARM Clear)
    // 2 bit : ���� ��� 2
    // 3 bit : ���� ��� 3
    // 4 bit(PLD) : ���� ��� 4
    // 5 bit(PLD) : ���� ��� 5
    // ���� �Է�
    // 0 bit : ���� �Է� 0(ORiginal Sensor)
    // 1 bit : ���� �Է� 1(Z phase)
    // 2 bit : ���� �Է� 2
    // 3 bit : ���� �Է� 3
    // 4 bit(PLD) : ���� �Է� 5
    // 5 bit(PLD) : ���� �Է� 6
    // On ==> ���ڴ� N24V, 'Off' ==> ���ڴ� Open(float).    

    // ���� ���� ��°��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_output(short axis, byte value);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_output(short axis);
    // ���� �Է� ���� Ȯ���Ѵ�.
    // '1'('On') <== ���ڴ� N24V�� �����, '0'('Off') <== ���ڴ� P24V �Ǵ� Float.
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_input(short axis);
    // �ش� ���� �ش� bit�� ����� On/Off ��Ų��.
    // bitNo : 0 ~ 5.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_output_bit(short axis, byte bitNo);
    [DllImport("AxtLib.dll")] public static extern int CFS20reset_output_bit(short axis, byte bitNo);
    // �ش� ���� �ش� ���� ��� bit�� ��� ���¸� Ȯ���Ѵ�.
    // bitNo : 0 ~ 5.
    [DllImport("AxtLib.dll")] public static extern int CFS20output_bit_on(short axis, byte bitNo);
    // �ش� ���� �ش� ���� ��� bit�� ���¸� �Է� state�� �ٲ۴�.
    // bitNo : 0 ~ 5. 
    [DllImport("AxtLib.dll")] public static extern int CFS20change_output_bit(short axis, byte bitNo, byte state);
    // �ش� ���� �ش� ���� �Է� bit�� ���¸� Ȯ�� �Ѵ�.
    // bitNo : 0 ~ 5.
    [DllImport("AxtLib.dll")] public static extern int CFS20input_bit_on(short axis, byte bitNo);
    // ���� �Է�(Universal input) 4 ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_ui4_mode(short axis, byte state);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_ui4_mode(short axis);
    // ���� �Է�(Universal input) 5 ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_ui5_mode(short axis, byte state);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_ui5_mode(short axis);

    // �ܿ� �޽� clear-===================================================================================================
    // �ش� ���� ������ �ܿ� �޽� Clear ����� ��� ���θ� ����/Ȯ���Ѵ�.
    // CLR ��ȣ�� Default ��� ==> ���ڴ� Open�̴�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_crc_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_crc_mask(short axis);
    // �ش� ���� �ܿ� �޽� Clear ����� Active level�� ����/Ȯ���Ѵ�.
    // Default Active level ==> '1' ==> ���ڴ� N24V
    [DllImport("AxtLib.dll")] public static extern int CFS20set_crc_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_crc_level(short axis);
    // �ش� ���� -Emeregency End limit�� ���� Clear��� ��� ������ ����/Ȯ���Ѵ�.    
    [DllImport("AxtLib.dll")] public static extern int CFS20set_crc_nelm_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_crc_nelm_mask(short axis);
    // �ش� ���� -Emeregency End limit�� Active level�� ����/Ȯ���Ѵ�. set_nend_limit_level�� �����ϰ� �����Ѵ�.    
    [DllImport("AxtLib.dll")] public static extern int CFS20set_crc_nelm_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_crc_nelm_level(short axis);
    // �ش� ���� +Emeregency End limit�� ���� Clear��� ��� ������ ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_crc_pelm_mask(short axis, short mask);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_crc_pelm_mask(short axis);
    // �ش� ���� +Emeregency End limit�� Active level�� ����/Ȯ���Ѵ�. set_nend_limit_level�� �����ϰ� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_crc_pelm_level(short axis, short level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_crc_pelm_level(short axis);
    // �ش� ���� �ܿ� �޽� Clear ����� �Է� ������ ���� ���/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_programmed_crc(short axis, short data);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_programmed_crc(short axis);

    // Ʈ���� ��� ======================================================================================================
    // ����/�ܺ� ��ġ�� ���Ͽ� �ֱ�/���� ��ġ���� ������ Active level�� Trigger pulse�� �߻� ��Ų��.
    // Ʈ���� ��� �޽��� Active level�� ����/Ȯ���Ѵ�.
    // ('0' : 5V ���(0 V), 24V �͹̳� ���(Open); '1'(default) : 5V ���(5 V), 24V �͹̳� ���(N24V).
    [DllImport("AxtLib.dll")] public static extern int CFS20set_trigger_level(short axis, byte trigger_level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_trigger_level(short axis);
    // Ʈ���� ��ɿ� ����� ���� ��ġ�� �����Ѵ�.
    // 0x0 : �ܺ� ��ġ External(Actual)
    // 0x1 : ���� ��ġ Internal(Command)
    [DllImport("AxtLib.dll")] public static extern int CFS20set_trigger_sel(short axis, byte trigger_sel);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_trigger_sel(short axis);
    // time
    // 0x00 : 4 msec(Ĩ ��� Bypass)
    // 0x01 : 8msec
    // 0x02 : 16msec
    // 0x03    : 24msec
    // ~
    // 0x0A: 80msec
    // 0x0B: 88msec
    // ~
    // 0x0F: 120msec
    [DllImport("AxtLib.dll")] public static extern int CFS20set_trigger_time(short axis, byte time);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_trigger_time(short axis);
    // ���� �࿡ Ʈ���� �߻� ����� ����/Ȯ���Ѵ�.
    // 0x0 : Ʈ���� ���� ��ġ���� Ʈ���� �߻�, ���� ��ġ ���
    // 0x1 : Ʈ���� ��ġ���� ����� �ֱ� Ʈ���� ���
    [DllImport("AxtLib.dll")] public static extern int CFS20set_trigger_mode(short axis, byte mode_sel);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_trigger_mode(short axis);
    // ���� �࿡ Ʈ���� �ֱ� �Ǵ� ���� ��ġ ���� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_trigger_position(short axis, double trigger_position);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_trigger_position(short axis);
    // ���� ���� Ʈ���� ����� ��� ���θ� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_trigger_enable(short axis, byte ena_status);
    [DllImport("AxtLib.dll")] public static extern byte CFS20is_trigger_enabled(short axis);
    // ���� �࿡ Ʈ���� �߻��� ���ͷ�Ʈ�� �߻��ϵ��� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_trigger_interrupt_enable(short axis, byte ena_int);
    [DllImport("AxtLib.dll")] public static extern byte CFS20is_trigger_interrupt_enabled(short axis);

    // MARK ����̺� �����Լ� ===========================================================================================
    // MARK, �����޽�(Pulse Drive) ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_pr_move(short axis, double distance, double velocity, double acceleration, byte drive);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_pr_move_ex(short axis, double distance, double velocity, double acceltime, byte drive);
    // MARK, ���Ī �����޽�(Pulse Drive) ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_pra_move(short axis, double distance, double velocity, double acceleration, double deceleration, byte drive);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_pra_move_ex(short axis, double distance, double velocity, double acceltime, double deceltime, byte drive);
    // �����޽�(Pulse Drive) ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
    [DllImport("AxtLib.dll")] public static extern ushort CFS20pr_move(short axis, double distance, double velocity, double acceleration, byte drive);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20pr_move_ex(short axis, double distance, double velocity, double acceltime, byte drive);
    // MARK, ���Ī �����޽�(Pulse Drive) ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
    [DllImport("AxtLib.dll")] public static extern ushort CFS20pra_move(short axis, double distance, double velocity, double acceleration, double deceleration, byte drive);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20pra_move_ex(short axis, double distance, double velocity, double acceltime, double deceltime, byte drive);
    // MARK, �����޽�(Pulse Drive) S���� ����, �����ǥ, ������/���ӽð�(Sec)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_prs_move(short axis, double distance, double velocity, double acceleration, byte drive);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_prs_move_ex(short axis, double distance, double velocity, double acceltime, byte drive);
    // MARK, ���Ī �����޽�(Pulse Drive) S���� ����, �����ǥ, ������/���ӽð�(Sec)
    [DllImport("AxtLib.dll")] public static extern int CFS20start_pras_move(short axis, double distance, double velocity, double acceleration, double deceleration, byte drive);
    [DllImport("AxtLib.dll")] public static extern int CFS20start_pras_move_ex(short axis, double distance, double velocity, double acceltime, double deceltime, byte drive);
    // MARK, �����޽�(Pulse Drive) S���� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
    [DllImport("AxtLib.dll")] public static extern ushort CFS20prs_move(short axis, double distance, double velocity, double acceleration, byte drive);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20prs_move_ex(short axis, double distance, double velocity, double acceltime, byte drive);
    // MARK, ���Ī �����޽�(Pulse Drive) S���� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
    [DllImport("AxtLib.dll")] public static extern ushort CFS20pras_move(short axis, double distance, double velocity, double acceleration, double deceleration, byte drive);
    [DllImport("AxtLib.dll")] public static extern ushort CFS20pras_move_ex(short axis, double distance, double velocity, double acceltime, double deceltime, byte drive);
    // MARK Signal�� Active level�� ����/Ȯ��/����Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int CFS20set_mark_signal_level(short axis, byte level);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_mark_signal_level(short axis);    
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_mark_signal_switch(short axis);
    
    [DllImport("AxtLib.dll")] public static extern int CFS20set_mark_signal_enable(short axis, byte use);
    [DllImport("AxtLib.dll")] public static extern byte CFS20get_mark_signal_enable(short axis);

    // ��ġ �񱳱� ���� �Լ��� ==========================================================================================
    // Internal(Command) comparator���� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_internal_comparator_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_internal_comparator_position(short axis);
    // External(Encoder) comparator���� ����/Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void CFS20set_external_comparator_position(short axis, double position);
    [DllImport("AxtLib.dll")] public static extern double CFS20get_external_comparator_position(short axis);

    // �����ڵ� �б� �Լ��� =============================================================================================
    // ������ �����ڵ带 �д´�.
    [DllImport("AxtLib.dll")] public static extern short CFS20get_error_code();
    // �����ڵ��� ������ ���ڷ� ��ȯ�Ѵ�.
    [DllImport("AxtLib.dll")] public static extern string CFS20get_error_msg(short ErrorCode);
}