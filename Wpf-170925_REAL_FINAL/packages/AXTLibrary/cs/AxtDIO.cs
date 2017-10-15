using System;
using System.Runtime.InteropServices;

public class CAxtDIO
{
    /*------------------------------------------------------------------------------------------------*
        AXTDIO Library - Digital Input/Ouput module
        ������ǰ
            SIO-DI32  - �Է� 32��
            SIO-DO32P - ��� 32��, ����Ŀ�÷� ���Ÿ��
            SIO-DO32T - ��� 32��, �Ŀ�TR ���Ÿ��
            SIO-DB32P - �Է� 16�� / ��� 32��, ����Ŀ�÷� ���Ÿ��
            SIO-DB32T - �Է� 16�� / ��� 32��, �Ŀ�TR ���Ÿ��
    *------------------------------------------------------------------------------------------------*/

    /// �ʱ�ȭ �Լ���
    // DIO����� �ʱ�ȭ�Ѵ�. �����ִ� ��纣�̽����忡�� DIO����� �˻��Ͽ� �ʱ�ȭ�Ѵ�
    [DllImport("AxtLib.dll")] public static extern int InitializeDIO();
    // DIO����� ����� �� �ֵ��� ���̺귯���� �ʱ�ȭ�Ǿ��°� ?
    [DllImport("AxtLib.dll")] public static extern int DIOIsInitialized();
    //void DIOStopService();

    // ���ͷ�Ʈ �޼��� �� �ڵ鷯�� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void DIOSetWindowMessage(IntPtr hWnd, ushort wMsg, CAxdLibDef.AXT_DIO_INTERRUPT_PROC proc);    

    /// ���ͷ�Ʈ ���� �Լ���
    // ������ ����� ���ͷ�Ʈ�� ����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void DIOEnableInterrupt(short nModuleNo);
    // ������ ����� ���ͷ�Ʈ�� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void DIODisableInterrupt(short nModuleNo);
    // ����� ���ͷ�Ʈ ������������ Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern int DIOIsInterruptEnabled(short nModuleNo);

    /// ���� �� ��� ���� �Լ���
    // ������ ���̽����尡 �����ִ���(���µǾ�����)�� Ȯ���Ѵ�
    [DllImport("AxtLib.dll")] public static extern int DIOIsOpenBoard(short nBoardNo);
    // ������ DIO����� �����ִ���(���µǾ�����)�� Ȯ���Ѵ�
    [DllImport("AxtLib.dll")] public static extern int DIOIsOpenModule(short nModuleNo);
    // ��ȿ�� ����ȣ������ Ȯ���Ѵ�
    [DllImport("AxtLib.dll")] public static extern int DIOIsValidModuleNo(short nModuleNo);
    // DIO����� ������ ���̽������� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_board_count();
    // DIO����� ������ �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_module_count();
    // ������ ������ ����ϴ� ���̽����� ��ȣ�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short DIOget_boardno(uint address);
    /*
            address : �������
            ���ϰ�
                0..���̽�����-1
                -1    = ��ȿ���� �ʴ� ����
    */

    // ������ ����� �𵨹�ȣ�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_module_id(short nModuleNo);
    /*
            ���ϰ�
                97h(AXT_SIO_DI32)    = SIO-DI32
                98h(AXT_SIO_DO32P)    = SIO-DO32P
                99h(AXT_SIO_DB32P)    = SIO-DB32P
                9Eh(AXT_SIO_DO32T)    = SIO-DO32T
                9Fh(AXT_SIO_DB32T)    = SIO-DB32T
                00h    = ��ȿ���� �ʴ� ����ȣ
        */
    // ������ ����� ���̽����峻 ��� ��ġ�� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern short DIOget_module_pos(short nModuleNo);
    // ������ ����� ��������� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_output_number(short nModuleNo);
    // ������ ����� �Է������� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_input_number(short nModuleNo);
    // ������ ���̽������� �����ġ�� �ִ� DIO����� ����ȣ�� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_module_number(short nBoardNo, short nModulePos);
    // ������ ����ȣ�� ���̽������ȣ�� �����ġ�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern int DIOget_module_info(short nModuleNo, ref short pBoardNo, ref short nModulePos);
    // ������ ���� ����� ������ �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern ushort DIOget_open_module_count(short ModuleID);
    /*
            ModuleID
                97h(AXT_SIO_DI32)    : SIO-DI32
                98h(AXT_SIO_DO32P)    : SIO-DO32P
                99h(AXT_SIO_DB32P)    : SIO-DB32P
                9Eh(AXT_SIO_DO32T)    : SIO-DO32T
                9Fh(AXT_SIO_DB32T)    : SIO-DB32T
                00h(DIO_MODULE_ALL)    : ��� DIO���
            ���ϰ�    : ����� ������ �����Ѵ�

        */

    /// Write port(Register) �Լ���
    // ���(Output) ��Ʈ�ο� 1��Ʈ�� �����͸� ��ִ´�. ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport(ushort offset, int bValue);
    // ���(Output) ��Ʈ�ο� 1��Ʈ�� �����͸� ��ִ´�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport_bit(short nModuleNo, ushort offset, int bValue);
    // ���(Output) ��Ʈ�ο� 1����Ʈ�� �����͸� ��ִ´�. ������ ����� ����Ʈ ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport_byte(short nModuleNo, ushort offset, byte byValue);
    // ���(Output) ��Ʈ�ο� 2����Ʈ�� �����͸� ��ִ´�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport_word(short nModuleNo, ushort offset, ushort wValue);
    // ���(Output) ��Ʈ�ο� 4����Ʈ�� �����͸� ��ִ´�. ������ ����� ������� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_outport_dword(short nModuleNo, ushort offset, uint lValue);
    // ���(Output) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�, ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_outport(ushort offset);
    // ���(Output) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_outport_bit(short nModuleNo, ushort offset);
    // ���(Output) ��Ʈ�κ��� 1����Ʈ�� �����͸� �о���δ�, ������ ����� ����Ʈ ����
    [DllImport("AxtLib.dll")] public static extern byte DIOread_outport_byte(short nModuleNo, ushort offset);
    // ���(Output) ��Ʈ�κ��� 2����Ʈ�� �����͸� �о���δ�, ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_outport_word(short nModuleNo, ushort offset);
    // ���(Output) ��Ʈ�κ��� 4����Ʈ�� �����͸� �о���δ�, ������ ����� ������� ����
    [DllImport("AxtLib.dll")] public static extern uint DIOread_outport_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOwrite_outport(),       DIOread_outport()            : 0���� ���������-1���� ��� ����
                DIOwrite_outport_bit(),   DIOread_outport_bit()        : SIO-DI32:���Ұ�, SIO-DB32:0..15, SIO-DO32:0..31
                DIOwrite_outport_byte(),  DIOread_outport_byte()    : SIO-DI32:���Ұ�, SIO-DB32:0..1,  SIO-DO32:0..3
                DIOwrite_outport_word(),  DIOread_outport_word()    : SIO-DI32:���Ұ�, SIO-DB32:0,     SIO-DO32:0..1
                DIOwrite_outport_dword(), DIOread_outport_dword()    : SIO-DI32:���Ұ�, SIO-DB32:0,     SIO-DO32:0
            ���ϰ�
                DIOread_outport()        : 0(OFF), 1(ON)
                DIOread_outport_bit()    : 0(OFF), 1(ON)
                DIOread_outport_byte()    : 00h .. FFh
                DIOread_outport_word()    : 0000h .. FFFFh
                DIOread_outport_dword()    : 00000000h .. FFFFFFFFh
        */

    /// Input port �Լ��� - �б� ���� ��Ʈ
    // �Է�(Input) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�. ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_inport(ushort offset);
    // �Է�(Input) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_inport_bit(short nModuleNo, ushort offset);
    // �Է�(Input) ��Ʈ�κ��� 1����Ʈ�� �����͸� �о���δ�. ������ ����� ����Ʈ ����
    [DllImport("AxtLib.dll")] public static extern byte DIOread_inport_byte(short nModuleNo, ushort offset);
    // �Է�(Input) ��Ʈ�κ��� 2����Ʈ�� �����͸� �о���δ�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_inport_word(short nModuleNo, ushort offset);
    // �Է�(Input) ��Ʈ�κ��� 4����Ʈ�� �����͸� �о���δ�. ������ ����� ������� ����
    [DllImport("AxtLib.dll")] public static extern uint DIOread_inport_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOread_inport()        : 0���� ���Է�����-1���� ��� ����
                DIOread_inport_bit()    : SIO-DI32:0..31, SIO-DB32:0..15, SIO-DO32:���Ұ�
                DIOread_inport_byte()    : SIO-DI32:0..3,  SIO-DB32:0..1,  SIO-DO32:���Ұ�
                DIOread_inport_word()    : SIO-DI32:0..1,  SIO-DB32:0,     SIO-DO32:���Ұ�
                DIOread_inport_dword()    : SIO-DI32:0,     SIO-DB32:0,     SIO-DO32:���Ұ�
            ���ϰ�
                DIOread_inport()        : 0(OFF), 1(ON)
                DIOread_inport_bit()    : 0(OFF), 1(ON)
                DIOread_inport_byte()    : 00h .. FFh
                DIOread_inport_word()    : 0000h .. FFFFh
                DIOread_inport_dword()    : 00000000h .. FFFFFFFFh
        */

    /// Interrupt Up-edge port(Register) �Լ���
    // ��¿���(Upedge) ��Ʈ�ο� 1��Ʈ�� �����͸� ��ִ´�. ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge(ushort offset, int bValue);
    // ��¿���(Upedge) ��Ʈ�ο� 1��Ʈ�� �����͸� ��ִ´�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge_bit(short nModuleNo, ushort offset, int bValue);
    // ��¿���(Upedge) ��Ʈ�ο� 1����Ʈ�� �����͸� ��ִ´�. ������ ����� ����Ʈ ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge_byte(short nModuleNo, ushort offset, byte byValue);
    // ��¿���(Upedge) ��Ʈ�ο� 2����Ʈ�� �����͸� ��ִ´�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge_word(short nModuleNo, ushort offset, ushort wValue);
    // ��¿���(Upedge) ��Ʈ�ο� 4����Ʈ�� �����͸� ��ִ´�. ������ ����� ������� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_upedge_dword(short nModuleNo, ushort offset, uint lValue);
    // ��¿���(Upedge) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�, ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_upedge(ushort offset);
    // ��¿���(Upedge) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_upedge_bit(short nModuleNo, ushort offset);
    // ��¿���(Upedge) ��Ʈ�κ��� 1����Ʈ�� �����͸� �о���δ�, ������ ����� ����Ʈ ����
    [DllImport("AxtLib.dll")] public static extern byte DIOread_upedge_byte(short nModuleNo, ushort offset);
    // ��¿���(Upedge) ��Ʈ�κ��� 2����Ʈ�� �����͸� �о���δ�, ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_upedge_word(short nModuleNo, ushort offset);
    // ��¿���(Upedge) ��Ʈ�κ��� 4����Ʈ�� �����͸� �о���δ�, ������ ����� ������� ����
    [DllImport("AxtLib.dll")] public static extern uint DIOread_upedge_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOwrite_upedge(),       DIOread_upedge()        : 0���� ���Է�����-1���� ��� ����
                DIOwrite_upedge_bit(),   DIOread_upedge_bit()    : SIO-DI32:0..31, SIO-DB32:0..15, SIO-DO32:���Ұ�
                DIOwrite_upedge_byte(),  DIOread_upedge_byte()    : SIO-DI32:0..3,  SIO-DB32:0..1,  SIO-DO32:���Ұ�
                DIOwrite_upedge_word(),  DIOread_upedge_word()    : SIO-DI32:0..1,  SIO-DB32:0,     SIO-DO32:���Ұ�
                DIOwrite_upedge_dword(), DIOread_upedge_dword()    : SIO-DI32:0,     SIO-DB32:0,     SIO-DO32:���Ұ�
            ���ϰ�
                DIOread_upedge()        : 0(OFF), 1(ON)
                DIOread_upedge_bit()    : 0(OFF), 1(ON)
                DIOread_upedge_byte()    : 00h .. FFh
                DIOread_upedge_word()    : 0000h .. FFFFh
                DIOread_upedge_dword()    : 00000000h .. FFFFFFFFh
        */

    /// Interrupt Down-edge port(Register) �Լ���
    // �ϰ�����(Downedge) ��Ʈ�ο� 1��Ʈ�� �����͸� ��ִ´�. ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge(ushort offset, int bValue);
    // �ϰ�����(Downedge) ��Ʈ�ο� 1��Ʈ�� �����͸� ��ִ´�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge_bit(short nModuleNo, ushort offset, int bValue);
    // �ϰ�����(Downedge) ��Ʈ�ο� 1����Ʈ�� �����͸� ��ִ´�. ������ ����� ����Ʈ ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge_byte(short nModuleNo, ushort offset, byte byValue);
    // �ϰ�����(Downedge) ��Ʈ�ο� 2����Ʈ�� �����͸� ��ִ´�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge_word(short nModuleNo, ushort offset, ushort wValue);
    // �ϰ�����(Downedge) ��Ʈ�ο� 4����Ʈ�� �����͸� ��ִ´�. ������ ����� ������� ����
    [DllImport("AxtLib.dll")] public static extern void DIOwrite_downedge_dword(short nModuleNo, ushort offset, uint lValue);
    // �ϰ�����(Downedge) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�, ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_downedge(ushort offset);
    // �ϰ�����(Downedge) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_downedge_bit(short nModuleNo, ushort offset);
    // �ϰ�����(Downedge) ��Ʈ�κ��� 1����Ʈ�� �����͸� �о���δ�, ������ ����� ����Ʈ ����
    [DllImport("AxtLib.dll")] public static extern byte DIOread_downedge_byte(short nModuleNo, ushort offset);
    // �ϰ�����(Downedge) ��Ʈ�κ��� 2����Ʈ�� �����͸� �о���δ�, ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_downedge_word(short nModuleNo, ushort offset);
    // �ϰ�����(Downedge) ��Ʈ�κ��� 4����Ʈ�� �����͸� �о���δ�, ������ ����� ������� ����
    [DllImport("AxtLib.dll")] public static extern uint DIOread_downedge_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOwrite_downedge(),       DIOread_downedge()        : 0���� ���Է�����-1���� ��� ����
                DIOwrite_downedge_bit(),   DIOread_downedge_bit()    : SIO-DI32:0..31, SIO-DB32:0..15, SIO-DO32:���Ұ�
                DIOwrite_downedge_byte(),  DIOread_downedge_byte()    : SIO-DI32:0..3,  SIO-DB32:0..1,  SIO-DO32:���Ұ�
                DIOwrite_downedge_word(),  DIOread_downedge_word()    : SIO-DI32:0..1,  SIO-DB32:0,     SIO-DO32:���Ұ�
                DIOwrite_downedge_dword(), DIOread_downedge_dword()    : SIO-DI32:0,     SIO-DB32:0,     SIO-DO32:���Ұ�
            ���ϰ�
                DIOread_downedge()        : 0(OFF), 1(ON)
                DIOread_downedge_bit()    : 0(OFF), 1(ON)
                DIOread_downedge_byte()    : 00h .. FFh
                DIOread_downedge_word()    : 0000h .. FFFFh
                DIOread_downedge_dword(): 00000000h .. FFFFFFFFh
        */
    
    /// Interrupt flag port(Register) �Լ���
    // ���ͷ�Ʈ�÷���(Flag) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�, ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_flag(ushort offset);
    // ���ͷ�Ʈ�÷���(Flag) ��Ʈ�κ��� 1��Ʈ�� �����͸� �о���δ�. ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern int DIOread_flag_bit(short nModuleNo, ushort offset);
    // ���ͷ�Ʈ�÷���(Flag) ��Ʈ�κ��� 1����Ʈ�� �����͸� �о���δ�, ������ ����� ����Ʈ ����
    [DllImport("AxtLib.dll")] public static extern byte DIOread_flag_byte(short nModuleNo, ushort offset);
    // ���ͷ�Ʈ�÷���(Flag) ��Ʈ�κ��� 2����Ʈ�� �����͸� �о���δ�, ������ ����� ���� ����
    [DllImport("AxtLib.dll")] public static extern ushort DIOread_flag_word(short nModuleNo, ushort offset);
    // ���ͷ�Ʈ�÷���(Flag) ��Ʈ�κ��� 4����Ʈ�� �����͸� �о���δ�, ������ ����� ������� ����
    [DllImport("AxtLib.dll")] public static extern uint DIOread_flag_dword(short nModuleNo, ushort offset);
    /*
            offset
                DIOread_flag()        : 0���� ���Է�����-1���� ��� ����
                DIOread_flag_bit()    : SIO-DI32:0..31, SIO-DB32:0..15, SIO-DO32:���Ұ�
                DIOread_flag_byte()    : SIO-DI32:0..3,  SIO-DB32:0..1,  SIO-DO32:���Ұ�
                DIOread_flag_word()    : SIO-DI32:0..1,  SIO-DB32:0,     SIO-DO32:���Ұ�
                DIOread_flag_dword(): SIO-DI32:0,     SIO-DB32:0,     SIO-DO32:���Ұ�
            ���ϰ�
                DIOread_flag()        : 0(OFF), 1(ON)
                DIOread_flag_bit()    : 0(OFF), 1(ON)
                DIOread_flag_byte()    : 00h .. FFh
                DIOread_flag_word()    : 0000h .. FFFFh
                DIOread_flag_dword(): 00000000h .. FFFFFFFFh
        */

    /*----------------------- ���������� ����ϴ� ����(Parameter) ------------------------------------*
        nBoardNo    : ���̽������ȣ, ����� ������� 0���� �Ҵ�ȴ�
        nModuleNo    : DIO��� ��ȣ, DIO����� ������ ������� ����� ������� 0���� �Ҵ�ȴ�
     *------------------------------------------------------------------------------------------------*/

    [DllImport("AxtLib.dll")] public static extern short DIOget_error_code();
    [DllImport("AxtLib.dll")] public static extern string DIOget_error_msg(short ErrorCode);

}