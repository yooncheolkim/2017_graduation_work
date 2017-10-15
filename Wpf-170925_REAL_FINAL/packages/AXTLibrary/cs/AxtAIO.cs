using System;
using System.Runtime.InteropServices;

public class CAxtAIO
{
    /*------------------------------------------------------------------------------------------------*
        AXTAIO Library - Analog Input/Ouput module
        ������ǰ
            SIO-AI4R  - AD 4Ch, 12bit, 1U size
            SIO-AO4R  - DA 4Ch, 12bit, 1U size
            SIO-AI16H - AD 16Ch, 16bit, 2U size
            SIO-AO8H  - DA 8Ch, 16bit, 2U size
     *------------------------------------------------------------------------------------------------*/

//========== Initilize/Close =========================================================================
    [DllImport("AxtLib.dll")] public static extern int InitializeAIO();
    [DllImport("AxtLib.dll")] public static extern int AIOIsInitialized();

    // Window message & procedure
    [DllImport("AxtLib.dll")] public static extern void AIOSetWindowMessage(IntPtr hWnd, ushort wMsg, CAxdLibDef.AXT_AIO_INTERRUPT_PROC proc);
    // ����Ʈ���� ����
    [DllImport("AxtLib.dll")] public static extern int AIOrun_software_reset(short nModuleNo);

    // EEPROM �а���
    [DllImport("AxtLib.dll")] public static extern void AIOeeprom_write_word(short nModuleNo, short eep_addr, ushort wValue);
    [DllImport("AxtLib.dll")] public static extern ushort AIOeeprom_read_word(short nModuleNo, short eep_addr);

    // ���� �� ��� ���� �˻�
    [DllImport("AxtLib.dll")] public static extern short AIOget_boardno(uint address);                                            // ���̽� ��巹���� ���̽� ���� ��ȣ ���ϱ�
    [DllImport("AxtLib.dll")] public static extern short AIOget_moduleno(short nBoardNo, short nModulePos);                       // ���̽����� ��ȣ�� �����ġ�� ����ȣ ���ϱ�
    [DllImport("AxtLib.dll")] public static extern int AIOis_open_board(short nBoardNo);                                          // ���µ� ���̽������ΰ� ?
    [DllImport("AxtLib.dll")] public static extern int AIOis_open_module(short nModuleNo);                                        // ���µ� ����ΰ� ?
    [DllImport("AxtLib.dll")] public static extern int AIOis_valid_moduleno(short nModuleNo);                                     // ��ȿ�� ����ȣ�ΰ� ?    
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_output_number(short nModuleNo);                                  // ����� ���ä�μ��� ��ȯ
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_input_number(short nModuleNo);                                   // ����� �Է�ä�μ��� ��ȯ
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_moduleid(short nModuleNo);                                       // ��� ID
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_board_count();                                                   // �˻��� ���̽������� ������ ��ȯ
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_module_count();                                                  // �˻��� �Ƴ��α� ��⺸���� ������ ��ȯ
    [DllImport("AxtLib.dll")] public static extern int AIOget_module_info(short nModuleNo, ref short pBoardNo, ref short pModulePos);// ���ѹ��� ��������� ���´�

    // ## �Ƴ��α� ��°��� ##
    // ��¸�� �����Լ�
    [DllImport("AxtLib.dll")] public static extern double AIOread_dac(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOwrite_dac(short nChannelNo, double dVolt);                              // D/A ���
    [DllImport("AxtLib.dll")] public static extern int AIOset_range_dac(short nChannelNo, double dVmin, double dVmax);            // D/A ��� ���й��� ����
    [DllImport("AxtLib.dll")] public static extern int AIOget_range_dac(short nChannelNo, ref double dVmin, ref double dVmax);    // D/A ��� ���й��� ������ �б�

    // ��¸�� Calibration�Լ�
    [DllImport("AxtLib.dll")] public static extern double AIOmanual_calibration_dac(short nDAChannelNo, short nADChannelNo, double dVolt, short nOffset);
    [DllImport("AxtLib.dll")] public static extern int AIOsave_calibration_data_dac(short nDAChannelNo, double dVolt, short nOffset);
    [DllImport("AxtLib.dll")] public static extern int AIOone_channel_calibration_dac(short nDAChannelNo, short nADChannelNo);
    [DllImport("AxtLib.dll")] public static extern short AIOget_calibration_data_dac(short nChannelNo, double dVolt);
    [DllImport("AxtLib.dll")] public static extern ushort AIOauto_calibration_dac(short nDAModuleNo, short nADModuleNo);

    // ��¸�� �����˻��Լ�
    [DllImport("AxtLib.dll")] public static extern short AIOmoduleno_2_channelno_dac(short nModuleNo);
    [DllImport("AxtLib.dll")] public static extern short AIOchannelno_2_moduleno_dac(short nChannelNo);    // AO
    [DllImport("AxtLib.dll")] public static extern short AIOchannelno_2_boardno_dac(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern short AIOget_module_number_dac();
    [DllImport("AxtLib.dll")] public static extern short AIOget_channel_number_dac();

    // ## �Ƴ��α� �Է� ���� ##    
    // �Ƴ��α� �Է� �����Լ�
    [DllImport("AxtLib.dll")] public static extern int AIOset_range_adc(short nChannelNo, double dVmin, double dVmax);            // ������� ������ ����
    [DllImport("AxtLib.dll")] public static extern int AIOset_overflower_mode_adc(short nChannelNo, int bMode);
    [DllImport("AxtLib.dll")] public static extern int AIOset_limit_adc(short nChannelNo, ushort wLower, ushort wUpper);
    [DllImport("AxtLib.dll")] public static extern int AIOset_trigger_mode_adc(short nModuleNo, short nTriggerMode);                // Ʈ���� ��� ����
    [DllImport("AxtLib.dll")] public static extern int AIOset_sample_freq_adc(short nModuleNo, double dValue);                    // Ÿ�̸� ���ļ� ������ ����[10 - 50000]
    [DllImport("AxtLib.dll")] public static extern int AIOset_timer_const_adc(short nModuleNo, double dValue);                    // Ÿ�̸� �ð� ������ ����[20 - 100000]

    // �Ƴ��α� �Է� ä�� ���� �����Լ�
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_set_range_adc(short nCHNum, short[] pnCHList, double dVmin, double dVmax);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_set_overflower_mode_adc(short nCHNum, short[] pnCHList, int bMode);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_set_limit_adc(short nCHNum, short[] pnCHList, ushort wLower, ushort wUpper);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_set_interrupt_mask_adc(short nCHNum, short[] pnCHList, byte byIntMask);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_enable_interrupt_adc(short nCHNum, short[] pnCHList);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_disable_interrupt_adc(short nCHNum, short[] pnCHList);

    // �Է¸�� ������ �б��Լ�
    [DllImport("AxtLib.dll")] public static extern int AIOget_range_adc(short nChannelNo, ref double dVmin, ref double dVmax);            // ������� ���� ������ �б�
    [DllImport("AxtLib.dll")] public static extern int AIOget_overflower_mode_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOget_limit_adc(short nChannelNo, ref ushort wLower, ref ushort wUpper);
    [DllImport("AxtLib.dll")] public static extern short AIOget_trigger_mode_adc(short nModuleNo);                                    // Ʈ���� ��� �˻�
    [DllImport("AxtLib.dll")] public static extern uint AIOget_sample_freq_adc(short nModuleNo);                                    // Ÿ�̸� ������ ���ļ� ������ �˻�
    [DllImport("AxtLib.dll")] public static extern double AIOget_timer_const_adc(short nModuleNo);                                    // Ÿ�̸� ������ �ð� ������ �˻�    

    // �Է¸�� ���ͷ�Ʈ ���� �Լ�
    [DllImport("AxtLib.dll")] public static extern int AIOenable_interrupt_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOis_enable_interrupt_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOdisable_interrupt_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOset_interrupt_mask_adc(short nChannelNo, byte byIntMask);
    [DllImport("AxtLib.dll")] public static extern byte AIOget_interrupt_mask_adc(short nChannelNo);        // �Ⱥ��� ���� 2003.06.13.
    
    // A/D ��ȯ �Լ�
    // A/D Conversion �� ��ȯ���� Digit�� ��ȯ
    [DllImport("AxtLib.dll")] public static extern double AIOread_one_volt_adc(short nChannelNo);                                    // A/D Conversion �� ��ȯ���� �������·� ��ȯ
    [DllImport("AxtLib.dll")] public static extern int AIOread_one_digit_adc(short nChannelNo, ref ushort wDigit);        
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_read_one_volt_adc(short nCHNum, short[] pnCHList, short nDataNum, ref double[] pdVolt);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_read_one_digit_adc(short nCHNum, short[] pnCHList, short nDataNum, ref ushort[] pwDigit);    
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_start_channel_adc(short nCHNum, short[] pnCHList, ushort uBufSize);    // H/W Ÿ�̸Ӹ� �̿��� A/D Conversion ����
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_start_filter_adc(short nCHNum, short[] pnCHList, ushort uFilterNum, ushort uBufSize);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_stop_channel_adc();                                                // H/W Ÿ�̸Ӹ� �̿��� A/D Conversion ����
    [DllImport("AxtLib.dll")] public static extern int AIOset_immediate_access_adc(short nCHNum, short[] pnCHList, ushort[] pwSize, ushort[] pwRetLength);
    [DllImport("AxtLib.dll")] public static extern int AIOstart_immediate_access_adc(double[,] pdBuffer);
    [DllImport("AxtLib.dll")] public static extern double AIOread_channel_volt_adc(short nChannelNo);                                // H/W Ÿ�̸Ӹ� �̿��� A/D Conversion�� ����Ÿ ���а����� �б�
    [DllImport("AxtLib.dll")] public static extern int AIOread_channel_digit_adc(short nChannelNo, ref ushort wDigit);                // H/W Ÿ�̸Ӹ� �̿��� A/D Conversion�� ����Ÿ Digit�� �б�    
    
    // ���� ���� Check �Լ�
    [DllImport("AxtLib.dll")] public static extern int AIOis_buffer_empty_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOis_buffer_upper_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOis_buffer_lower_adc(short nChannelNo);    
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_data_length_adc(short nChannelNo);                                    // ��ȯ�ȵ������� ����

    // �Է¸�� ���� �˻��Լ�
    [DllImport("AxtLib.dll")] public static extern short AIOchannelno_2_boardno_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern short AIOchannelno_2_moduleno_adc(short nChannelNo);    // AI
    [DllImport("AxtLib.dll")] public static extern short AIOmoduleno_2_channelno_adc(short nModuleNo);
    [DllImport("AxtLib.dll")] public static extern short AIOget_module_number_adc();
    [DllImport("AxtLib.dll")] public static extern short AIOget_channel_number_adc();

    [DllImport("AxtLib.dll")] public static extern short AIOget_error_code();
    [DllImport("AxtLib.dll")] public static extern string AIOget_error_msg(short ErrorCode);
}