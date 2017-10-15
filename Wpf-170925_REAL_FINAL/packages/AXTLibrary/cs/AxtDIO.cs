using System;
using System.Runtime.InteropServices;

public class CAxtDIO
{
    /*------------------------------------------------------------------------------------------------*
        AXTDIO Library - Digital Input/Ouput module
        적용제품
            SIO-DI32  - 입력 32점
            SIO-DO32P - 출력 32점, 포토커플러 출력타입
            SIO-DO32T - 출력 32점, 파워TR 출력타입
            SIO-DB32P - 입력 16점 / 출력 32점, 포토커플러 출력타입
            SIO-DB32T - 입력 16점 / 출력 32점, 파워TR 출력타입
    *------------------------------------------------------------------------------------------------*/

    /// 초기화 함수군
    // DIO모듈을 초기화한다. 열려있는 모든베이스보드에서 DIO모듈을 검색하여 초기화한다
    [DllImport("AxtLib.dll")] public static extern int InitializeDIO();
    // DIO모듈을 사용할 수 있도록 라이브러리가 초기화되었는가 ?
    [DllImport("AxtLib.dll")] public static extern int DIOIsInitialized();
    //void DIOStopService();

    // 인터럽트 메세지 및 핸들러를 설정한다.
    [DllImport("AxtLib.dll")] public static extern void DIOSetWindowMessage(IntPtr hWnd, ushort wMsg, CAxdLibDef.AXT_DIO_INTERRUPT_PROC proc);    

    /// 인터럽트 관련 함수군
    // 지정한 모듈의 인터럽트를 허용한다.
    [DllImport("AxtLib.dll")] public static extern void DIOEnableInterrupt(short nModuleNo);
    // 지정한 모듈의 인터럽트를 금지한다.
    [DllImport("AxtLib.dll")] public static extern void DIODisableInterrupt(short nModuleNo);
    // 모듈이 인터럽트 허용상태인지를 확인한다.
    [DllImport("AxtLib.dll")] public static extern int DIOIsInterruptEnabled(short nModuleNo);

    /// 보드 및 모듈 정보 함수군
    // 지정한 베이스보드가 열려있는지(오픈되었는지)를 확인한다
    [DllImport("AxtLib.dll")] public static extern int DIOIsOpenBoard(short nBoardNo);
    // 지정한 DIO모듈이 열려있는지(오픈되었는지)를 확인한다
    [DllImport("AxtLib.dll")] public static extern int DIOIsOpenModule(short nModuleNo);
    // 유효한 모듈번호인지를 확인한다
    [DllImport("AxtLib.dll")] public static extern int DIOIsValidModuleNo(short nModuleNo);
    // DIO모듈이 장착된 베이스보드의 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_board_count();
    // DIO모듈의 갯수를 리턴한다.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_module_count();
    // 지정한 번지를 사용하는 베이스보드 번호를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short DIOget_boardno(uint address);
    /*
            address : 절대번지
            리턴값
                0..베이스보드-1
                -1    = 유효하지 않는 번지
    */

    // 지정한 모듈의 모델번호를 리턴한다
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_module_id(short nModuleNo);
    /*
            리턴값
                97h(AXT_SIO_DI32)    = SIO-DI32
                98h(AXT_SIO_DO32P)    = SIO-DO32P
                99h(AXT_SIO_DB32P)    = SIO-DB32P
                9Eh(AXT_SIO_DO32T)    = SIO-DO32T
                9Fh(AXT_SIO_DB32T)    = SIO-DB32T
                00h    = 유효하지 않는 모듈번호
        */
    // 지정한 모듈의 베이스보드내 모듈 위치를 리턴한다.
    [DllImport("AxtLib.dll")] public static extern short DIOget_module_pos(short nModuleNo);
    // 지정한 모듈의 출력점수를 리턴한다.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_output_number(short nModuleNo);
    // 지정한 모듈의 입력점수를 리턴한다.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_input_number(short nModuleNo);
    // 지정한 베이스보드의 모듈위치에 있는 DIO모듈의 모듈번호를 리턴한다.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_module_number(short nBoardNo, short nModulePos);
    // 지정한 모듈번호의 베이스보드번호와 모듈위치를 리턴한다
    [DllImport("AxtLib.dll")] public static extern int DIOget_module_info(short nModuleNo, ref short pBoardNo, ref short nModulePos);
    // 지정한 모델의 모듈의 갯수를 리턴한다.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_open_module_count(short ModuleID);
    /*
            ModuleID
                97h(AXT_SIO_DI32)    : SIO-DI32
                98h(AXT_SIO_DO32P)    : SIO-DO32P
                99h(AXT_SIO_DB32P)    : SIO-DB32P
                9Eh(AXT_SIO_DO32T)    : SIO-DO32T
                9Fh(AXT_SIO_DB32T)    : SIO-DB32T
                00h(DIO_MODULE_ALL)    : 모든 DIO모듈
            리턴값    : 모듈의 갯수를 리턴한다

        */

    /// Write port(Register) 함수군
    // 출력(Output) 포트로에 1비트의 데이터를 써넣는다. 점수 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport(ushort offset, int bValue);
    // 출력(Output) 포트로에 1비트의 데이터를 써넣는다. 지정한 모듈의 점수 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport_bit(short nModuleNo, ushort offset, int bValue);
    // 출력(Output) 포트로에 1바이트의 데이터를 써넣는다. 지정한 모듈의 바이트 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport_byte(short nModuleNo, ushort offset, byte byValue);
    // 출력(Output) 포트로에 2바이트의 데이터를 써넣는다. 지정한 모듈의 워드 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport_word(short nModuleNo, ushort offset, ushort wValue);
    // 출력(Output) 포트로에 4바이트의 데이터를 써넣는다. 지정한 모듈의 더블워드 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport_dword(short nModuleNo, ushort offset, uint lValue);
    // 출력(Output) 포트로부터 1비트의 데이터를 읽어들인다, 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_outport(ushort offset);
    // 출력(Output) 포트로부터 1비트의 데이터를 읽어들인다. 지정한 모듈의 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_outport_bit(short nModuleNo, ushort offset);
    // 출력(Output) 포트로부터 1바이트의 데이터를 읽어들인다, 지정한 모듈의 바이트 단위
    [DllImport("AxtLib.dll")] public static extern byte DIOread_outport_byte(short nModuleNo, ushort offset);
    // 출력(Output) 포트로부터 2바이트의 데이터를 읽어들인다, 지정한 모듈의 워드 단위
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_outport_word(short nModuleNo, ushort offset);
    // 출력(Output) 포트로부터 4바이트의 데이터를 읽어들인다, 지정한 모듈의 더블워드 단위
    [DllImport("AxtLib.dll")] public static extern uint DIOread_outport_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOwrite_outport(),       DIOread_outport()            : 0부터 총출력점수-1까지 사용 가능
                DIOwrite_outport_bit(),   DIOread_outport_bit()        : SIO-DI32:사용불가, SIO-DB32:0..15, SIO-DO32:0..31
                DIOwrite_outport_byte(),  DIOread_outport_byte()    : SIO-DI32:사용불가, SIO-DB32:0..1,  SIO-DO32:0..3
                DIOwrite_outport_word(),  DIOread_outport_word()    : SIO-DI32:사용불가, SIO-DB32:0,     SIO-DO32:0..1
                DIOwrite_outport_dword(), DIOread_outport_dword()    : SIO-DI32:사용불가, SIO-DB32:0,     SIO-DO32:0
            리턴값
                DIOread_outport()        : 0(OFF), 1(ON)
                DIOread_outport_bit()    : 0(OFF), 1(ON)
                DIOread_outport_byte()    : 00h .. FFh
                DIOread_outport_word()    : 0000h .. FFFFh
                DIOread_outport_dword()    : 00000000h .. FFFFFFFFh
        */

    /// Input port 함수군 - 읽기 전용 포트
    // 입력(Input) 포트로부터 1비트의 데이터를 읽어들인다. 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_inport(ushort offset);
    // 입력(Input) 포트로부터 1비트의 데이터를 읽어들인다. 지정한 모듈의 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_inport_bit(short nModuleNo, ushort offset);
    // 입력(Input) 포트로부터 1바이트의 데이터를 읽어들인다. 지정한 모듈의 바이트 단위
    [DllImport("AxtLib.dll")] public static extern byte DIOread_inport_byte(short nModuleNo, ushort offset);
    // 입력(Input) 포트로부터 2바이트의 데이터를 읽어들인다. 지정한 모듈의 워드 단위
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_inport_word(short nModuleNo, ushort offset);
    // 입력(Input) 포트로부터 4바이트의 데이터를 읽어들인다. 지정한 모듈의 더블워드 단위
    [DllImport("AxtLib.dll")] public static extern uint DIOread_inport_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOread_inport()        : 0부터 총입력점수-1까지 사용 가능
                DIOread_inport_bit()    : SIO-DI32:0..31, SIO-DB32:0..15, SIO-DO32:사용불가
                DIOread_inport_byte()    : SIO-DI32:0..3,  SIO-DB32:0..1,  SIO-DO32:사용불가
                DIOread_inport_word()    : SIO-DI32:0..1,  SIO-DB32:0,     SIO-DO32:사용불가
                DIOread_inport_dword()    : SIO-DI32:0,     SIO-DB32:0,     SIO-DO32:사용불가
            리턴값
                DIOread_inport()        : 0(OFF), 1(ON)
                DIOread_inport_bit()    : 0(OFF), 1(ON)
                DIOread_inport_byte()    : 00h .. FFh
                DIOread_inport_word()    : 0000h .. FFFFh
                DIOread_inport_dword()    : 00000000h .. FFFFFFFFh
        */

    /// Interrupt Up-edge port(Register) 함수군
    // 상승에지(Upedge) 포트로에 1비트의 데이터를 써넣는다. 점수 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge(ushort offset, int bValue);
    // 상승에지(Upedge) 포트로에 1비트의 데이터를 써넣는다. 지정한 모듈의 점수 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge_bit(short nModuleNo, ushort offset, int bValue);
    // 상승에지(Upedge) 포트로에 1바이트의 데이터를 써넣는다. 지정한 모듈의 바이트 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge_byte(short nModuleNo, ushort offset, byte byValue);
    // 상승에지(Upedge) 포트로에 2바이트의 데이터를 써넣는다. 지정한 모듈의 워드 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge_word(short nModuleNo, ushort offset, ushort wValue);
    // 상승에지(Upedge) 포트로에 4바이트의 데이터를 써넣는다. 지정한 모듈의 더블워드 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge_dword(short nModuleNo, ushort offset, uint lValue);
    // 상승에지(Upedge) 포트로부터 1비트의 데이터를 읽어들인다, 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_upedge(ushort offset);
    // 상승에지(Upedge) 포트로부터 1비트의 데이터를 읽어들인다. 지정한 모듈의 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_upedge_bit(short nModuleNo, ushort offset);
    // 상승에지(Upedge) 포트로부터 1바이트의 데이터를 읽어들인다, 지정한 모듈의 바이트 단위
    [DllImport("AxtLib.dll")] public static extern byte DIOread_upedge_byte(short nModuleNo, ushort offset);
    // 상승에지(Upedge) 포트로부터 2바이트의 데이터를 읽어들인다, 지정한 모듈의 워드 단위
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_upedge_word(short nModuleNo, ushort offset);
    // 상승에지(Upedge) 포트로부터 4바이트의 데이터를 읽어들인다, 지정한 모듈의 더블워드 단위
    [DllImport("AxtLib.dll")] public static extern uint DIOread_upedge_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOwrite_upedge(),       DIOread_upedge()        : 0부터 총입력점수-1까지 사용 가능
                DIOwrite_upedge_bit(),   DIOread_upedge_bit()    : SIO-DI32:0..31, SIO-DB32:0..15, SIO-DO32:사용불가
                DIOwrite_upedge_byte(),  DIOread_upedge_byte()    : SIO-DI32:0..3,  SIO-DB32:0..1,  SIO-DO32:사용불가
                DIOwrite_upedge_word(),  DIOread_upedge_word()    : SIO-DI32:0..1,  SIO-DB32:0,     SIO-DO32:사용불가
                DIOwrite_upedge_dword(), DIOread_upedge_dword()    : SIO-DI32:0,     SIO-DB32:0,     SIO-DO32:사용불가
            리턴값
                DIOread_upedge()        : 0(OFF), 1(ON)
                DIOread_upedge_bit()    : 0(OFF), 1(ON)
                DIOread_upedge_byte()    : 00h .. FFh
                DIOread_upedge_word()    : 0000h .. FFFFh
                DIOread_upedge_dword()    : 00000000h .. FFFFFFFFh
        */

    /// Interrupt Down-edge port(Register) 함수군
    // 하강에지(Downedge) 포트로에 1비트의 데이터를 써넣는다. 점수 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge(ushort offset, int bValue);
    // 하강에지(Downedge) 포트로에 1비트의 데이터를 써넣는다. 지정한 모듈의 점수 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge_bit(short nModuleNo, ushort offset, int bValue);
    // 하강에지(Downedge) 포트로에 1바이트의 데이터를 써넣는다. 지정한 모듈의 바이트 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge_byte(short nModuleNo, ushort offset, byte byValue);
    // 하강에지(Downedge) 포트로에 2바이트의 데이터를 써넣는다. 지정한 모듈의 워드 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge_word(short nModuleNo, ushort offset, ushort wValue);
    // 하강에지(Downedge) 포트로에 4바이트의 데이터를 써넣는다. 지정한 모듈의 더블워드 단위
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge_dword(short nModuleNo, ushort offset, uint lValue);
    // 하강에지(Downedge) 포트로부터 1비트의 데이터를 읽어들인다, 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_downedge(ushort offset);
    // 하강에지(Downedge) 포트로부터 1비트의 데이터를 읽어들인다. 지정한 모듈의 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_downedge_bit(short nModuleNo, ushort offset);
    // 하강에지(Downedge) 포트로부터 1바이트의 데이터를 읽어들인다, 지정한 모듈의 바이트 단위
    [DllImport("AxtLib.dll")] public static extern byte DIOread_downedge_byte(short nModuleNo, ushort offset);
    // 하강에지(Downedge) 포트로부터 2바이트의 데이터를 읽어들인다, 지정한 모듈의 워드 단위
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_downedge_word(short nModuleNo, ushort offset);
    // 하강에지(Downedge) 포트로부터 4바이트의 데이터를 읽어들인다, 지정한 모듈의 더블워드 단위
    [DllImport("AxtLib.dll")] public static extern uint DIOread_downedge_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOwrite_downedge(),       DIOread_downedge()        : 0부터 총입력점수-1까지 사용 가능
                DIOwrite_downedge_bit(),   DIOread_downedge_bit()    : SIO-DI32:0..31, SIO-DB32:0..15, SIO-DO32:사용불가
                DIOwrite_downedge_byte(),  DIOread_downedge_byte()    : SIO-DI32:0..3,  SIO-DB32:0..1,  SIO-DO32:사용불가
                DIOwrite_downedge_word(),  DIOread_downedge_word()    : SIO-DI32:0..1,  SIO-DB32:0,     SIO-DO32:사용불가
                DIOwrite_downedge_dword(), DIOread_downedge_dword()    : SIO-DI32:0,     SIO-DB32:0,     SIO-DO32:사용불가
            리턴값
                DIOread_downedge()        : 0(OFF), 1(ON)
                DIOread_downedge_bit()    : 0(OFF), 1(ON)
                DIOread_downedge_byte()    : 00h .. FFh
                DIOread_downedge_word()    : 0000h .. FFFFh
                DIOread_downedge_dword(): 00000000h .. FFFFFFFFh
        */
    
    /// Interrupt flag port(Register) 함수군
    // 인터럽트플래그(Flag) 포트로부터 1비트의 데이터를 읽어들인다, 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_flag(ushort offset);
    // 인터럽트플래그(Flag) 포트로부터 1비트의 데이터를 읽어들인다. 지정한 모듈의 점수 단위
    [DllImport("AxtLib.dll")] public static extern int DIOread_flag_bit(short nModuleNo, ushort offset);
    // 인터럽트플래그(Flag) 포트로부터 1바이트의 데이터를 읽어들인다, 지정한 모듈의 바이트 단위
    [DllImport("AxtLib.dll")] public static extern byte DIOread_flag_byte(short nModuleNo, ushort offset);
    // 인터럽트플래그(Flag) 포트로부터 2바이트의 데이터를 읽어들인다, 지정한 모듈의 워드 단위
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_flag_word(short nModuleNo, ushort offset);
    // 인터럽트플래그(Flag) 포트로부터 4바이트의 데이터를 읽어들인다, 지정한 모듈의 더블워드 단위
    [DllImport("AxtLib.dll")] public static extern uint DIOread_flag_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOread_flag()        : 0부터 총입력점수-1까지 사용 가능
                DIOread_flag_bit()    : SIO-DI32:0..31, SIO-DB32:0..15, SIO-DO32:사용불가
                DIOread_flag_byte()    : SIO-DI32:0..3,  SIO-DB32:0..1,  SIO-DO32:사용불가
                DIOread_flag_word()    : SIO-DI32:0..1,  SIO-DB32:0,     SIO-DO32:사용불가
                DIOread_flag_dword(): SIO-DI32:0,     SIO-DB32:0,     SIO-DO32:사용불가
            리턴값
                DIOread_flag()        : 0(OFF), 1(ON)
                DIOread_flag_bit()    : 0(OFF), 1(ON)
                DIOread_flag_byte()    : 00h .. FFh
                DIOread_flag_word()    : 0000h .. FFFFh
                DIOread_flag_dword(): 00000000h .. FFFFFFFFh
        */

    /*----------------------- 공통적으로 사용하는 인자(Parameter) ------------------------------------*
        nBoardNo    : 베이스보드번호, 검출된 순서대로 0부터 할당된다
        nModuleNo    : DIO모듈 번호, DIO모듈의 종류에 관계없이 검출된 순서대로 0부터 할당된다
     *------------------------------------------------------------------------------------------------*/

    [DllImport("AxtLib.dll")] public static extern short DIOget_error_code();
    [DllImport("AxtLib.dll")] public static extern string DIOget_error_msg(short ErrorCode);

}