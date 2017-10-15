using System;
using System.Runtime.InteropServices;

public class CAxtAIO
{
    /*------------------------------------------------------------------------------------------------*
        AXTAIO Library - Analog Input/Ouput module
        적용제품
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
    // 소프트웨어 리셋
    [DllImport("AxtLib.dll")] public static extern int AIOrun_software_reset(short nModuleNo);

    // EEPROM 읽고쓰기
    [DllImport("AxtLib.dll")] public static extern void AIOeeprom_write_word(short nModuleNo, short eep_addr, ushort wValue);
    [DllImport("AxtLib.dll")] public static extern ushort AIOeeprom_read_word(short nModuleNo, short eep_addr);

    // 보드 및 모듈 정보 검색
    [DllImport("AxtLib.dll")] public static extern short AIOget_boardno(uint address);                                            // 베이스 어드레스로 베이스 보드 번호 구하기
    [DllImport("AxtLib.dll")] public static extern short AIOget_moduleno(short nBoardNo, short nModulePos);                       // 베이스보드 번호와 모듈위치로 모듈번호 구하기
    [DllImport("AxtLib.dll")] public static extern int AIOis_open_board(short nBoardNo);                                          // 오픈된 베이스보드인가 ?
    [DllImport("AxtLib.dll")] public static extern int AIOis_open_module(short nModuleNo);                                        // 오픈된 모듈인가 ?
    [DllImport("AxtLib.dll")] public static extern int AIOis_valid_moduleno(short nModuleNo);                                     // 유효한 모듈번호인가 ?    
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_output_number(short nModuleNo);                                  // 모듈의 출력채널수를 반환
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_input_number(short nModuleNo);                                   // 모듈의 입력채널수를 반환
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_moduleid(short nModuleNo);                                       // 모듈 ID
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_board_count();                                                   // 검색된 베이스보드의 갯수를 반환
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_module_count();                                                  // 검색된 아날로그 모듈보드의 갯수를 반환
    [DllImport("AxtLib.dll")] public static extern int AIOget_module_info(short nModuleNo, ref short pBoardNo, ref short pModulePos);// 모듈넘버로 모듈정보를 얻어온다

    // ## 아날로그 출력관련 ##
    // 출력모듈 설정함수
    [DllImport("AxtLib.dll")] public static extern double AIOread_dac(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOwrite_dac(short nChannelNo, double dVolt);                              // D/A 출력
    [DllImport("AxtLib.dll")] public static extern int AIOset_range_dac(short nChannelNo, double dVmin, double dVmax);            // D/A 출력 전압범위 설정
    [DllImport("AxtLib.dll")] public static extern int AIOget_range_dac(short nChannelNo, ref double dVmin, ref double dVmax);    // D/A 출력 전압범위 설정값 읽기

    // 출력모듈 Calibration함수
    [DllImport("AxtLib.dll")] public static extern double AIOmanual_calibration_dac(short nDAChannelNo, short nADChannelNo, double dVolt, short nOffset);
    [DllImport("AxtLib.dll")] public static extern int AIOsave_calibration_data_dac(short nDAChannelNo, double dVolt, short nOffset);
    [DllImport("AxtLib.dll")] public static extern int AIOone_channel_calibration_dac(short nDAChannelNo, short nADChannelNo);
    [DllImport("AxtLib.dll")] public static extern short AIOget_calibration_data_dac(short nChannelNo, double dVolt);
    [DllImport("AxtLib.dll")] public static extern ushort AIOauto_calibration_dac(short nDAModuleNo, short nADModuleNo);

    // 출력모듈 정보검색함수
    [DllImport("AxtLib.dll")] public static extern short AIOmoduleno_2_channelno_dac(short nModuleNo);
    [DllImport("AxtLib.dll")] public static extern short AIOchannelno_2_moduleno_dac(short nChannelNo);    // AO
    [DllImport("AxtLib.dll")] public static extern short AIOchannelno_2_boardno_dac(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern short AIOget_module_number_dac();
    [DllImport("AxtLib.dll")] public static extern short AIOget_channel_number_dac();

    // ## 아날로그 입력 관련 ##    
    // 아날로그 입력 설정함수
    [DllImport("AxtLib.dll")] public static extern int AIOset_range_adc(short nChannelNo, double dVmin, double dVmax);            // 출력전압 범위를 설정
    [DllImport("AxtLib.dll")] public static extern int AIOset_overflower_mode_adc(short nChannelNo, int bMode);
    [DllImport("AxtLib.dll")] public static extern int AIOset_limit_adc(short nChannelNo, ushort wLower, ushort wUpper);
    [DllImport("AxtLib.dll")] public static extern int AIOset_trigger_mode_adc(short nModuleNo, short nTriggerMode);                // 트리거 모드 설정
    [DllImport("AxtLib.dll")] public static extern int AIOset_sample_freq_adc(short nModuleNo, double dValue);                    // 타이머 주파수 단위로 설정[10 - 50000]
    [DllImport("AxtLib.dll")] public static extern int AIOset_timer_const_adc(short nModuleNo, double dValue);                    // 타이머 시간 단위로 설정[20 - 100000]

    // 아날로그 입력 채널 다중 설정함수
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_set_range_adc(short nCHNum, short[] pnCHList, double dVmin, double dVmax);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_set_overflower_mode_adc(short nCHNum, short[] pnCHList, int bMode);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_set_limit_adc(short nCHNum, short[] pnCHList, ushort wLower, ushort wUpper);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_set_interrupt_mask_adc(short nCHNum, short[] pnCHList, byte byIntMask);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_enable_interrupt_adc(short nCHNum, short[] pnCHList);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_disable_interrupt_adc(short nCHNum, short[] pnCHList);

    // 입력모듈 설정값 읽기함수
    [DllImport("AxtLib.dll")] public static extern int AIOget_range_adc(short nChannelNo, ref double dVmin, ref double dVmax);            // 출력전압 범위 설정값 읽기
    [DllImport("AxtLib.dll")] public static extern int AIOget_overflower_mode_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOget_limit_adc(short nChannelNo, ref ushort wLower, ref ushort wUpper);
    [DllImport("AxtLib.dll")] public static extern short AIOget_trigger_mode_adc(short nModuleNo);                                    // 트리거 모드 검색
    [DllImport("AxtLib.dll")] public static extern uint AIOget_sample_freq_adc(short nModuleNo);                                    // 타이머 설정값 주파수 단위로 검색
    [DllImport("AxtLib.dll")] public static extern double AIOget_timer_const_adc(short nModuleNo);                                    // 타이머 설정값 시간 단위로 검색    

    // 입력모듈 인터럽트 설정 함수
    [DllImport("AxtLib.dll")] public static extern int AIOenable_interrupt_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOis_enable_interrupt_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOdisable_interrupt_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOset_interrupt_mask_adc(short nChannelNo, byte byIntMask);
    [DllImport("AxtLib.dll")] public static extern byte AIOget_interrupt_mask_adc(short nChannelNo);        // 안병건 수정 2003.06.13.
    
    // A/D 변환 함수
    // A/D Conversion 후 변환값을 Digit로 반환
    [DllImport("AxtLib.dll")] public static extern double AIOread_one_volt_adc(short nChannelNo);                                    // A/D Conversion 후 변환값을 전압형태로 반환
    [DllImport("AxtLib.dll")] public static extern int AIOread_one_digit_adc(short nChannelNo, ref ushort wDigit);        
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_read_one_volt_adc(short nCHNum, short[] pnCHList, short nDataNum, ref double[] pdVolt);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_read_one_digit_adc(short nCHNum, short[] pnCHList, short nDataNum, ref ushort[] pwDigit);    
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_start_channel_adc(short nCHNum, short[] pnCHList, ushort uBufSize);    // H/W 타이머를 이용한 A/D Conversion 시작
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_start_filter_adc(short nCHNum, short[] pnCHList, ushort uFilterNum, ushort uBufSize);
    [DllImport("AxtLib.dll")] public static extern int AIOmulti_stop_channel_adc();                                                // H/W 타이머를 이용한 A/D Conversion 정지
    [DllImport("AxtLib.dll")] public static extern int AIOset_immediate_access_adc(short nCHNum, short[] pnCHList, ushort[] pwSize, ushort[] pwRetLength);
    [DllImport("AxtLib.dll")] public static extern int AIOstart_immediate_access_adc(double[,] pdBuffer);
    [DllImport("AxtLib.dll")] public static extern double AIOread_channel_volt_adc(short nChannelNo);                                // H/W 타이머를 이용한 A/D Conversion한 데이타 전압값으로 읽기
    [DllImport("AxtLib.dll")] public static extern int AIOread_channel_digit_adc(short nChannelNo, ref ushort wDigit);                // H/W 타이머를 이용한 A/D Conversion한 데이타 Digit로 읽기    
    
    // 버퍼 상태 Check 함수
    [DllImport("AxtLib.dll")] public static extern int AIOis_buffer_empty_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOis_buffer_upper_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern int AIOis_buffer_lower_adc(short nChannelNo);    
    [DllImport("AxtLib.dll")] public static extern ushort AIOget_data_length_adc(short nChannelNo);                                    // 변환된데이터의 갯수

    // 입력모듈 정보 검색함수
    [DllImport("AxtLib.dll")] public static extern short AIOchannelno_2_boardno_adc(short nChannelNo);
    [DllImport("AxtLib.dll")] public static extern short AIOchannelno_2_moduleno_adc(short nChannelNo);    // AI
    [DllImport("AxtLib.dll")] public static extern short AIOmoduleno_2_channelno_adc(short nModuleNo);
    [DllImport("AxtLib.dll")] public static extern short AIOget_module_number_adc();
    [DllImport("AxtLib.dll")] public static extern short AIOget_channel_number_adc();

    [DllImport("AxtLib.dll")] public static extern short AIOget_error_code();
    [DllImport("AxtLib.dll")] public static extern string AIOget_error_msg(short ErrorCode);
}