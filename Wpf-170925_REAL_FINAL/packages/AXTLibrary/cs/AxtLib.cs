using System;
using System.Runtime.InteropServices;

public class CAxtLib
{
    /*------------------------------------------------------------------------------------------------*
        AXTLIB Library - ���ն��̺귯�� �� ���̽����� ����
        ������ǰ
            BIHR - ISA Half size, 2 module
            BIFR - ISA Full size, 4 module
            BPHR - PCI Half size, 2 module
            BPFR - PCI Full size, 4 module
            BV3R - VME 3U size, 2 module
            BV6R - VME 6U size, 4 module
            BC3R - CompactPCI 3U size, 2 module
            BC6R - CompactPCI 6U size, 4 module
     *------------------------------------------------------------------------------------------------*/

    /// <<���ն��̺귯�� �ʱ�ȭ �� ����>>
    // ���� ���̺귯���� �ʱ�ȭ �Ѵ�..
    [DllImport("AxtLib.dll")] public static extern int AxtInitialize(IntPtr hWnd, short nIrqNo);
    // ���� ���̺귯���� ��� �������� (�ʱ�ȭ�� �Ǿ�����)�� Ȯ���Ѵ�
    [DllImport("AxtLib.dll")] public static extern int AxtIsInitialized();
    // ���� ���̺귯���� ����� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void AxtClose();

    /// <<���̽����� ���� �� �ݱ�>>
    // ������ ����(ISA, PCI, VME, CompactPCI)�� �ʱ�ȭ �Ǿ������� Ȯ���Ѵ�
    [DllImport("AxtLib.dll")] public static extern short AxtIsInitializedBus(short BusType);
    // ���ο� ���̽����带 ���ն��̺귯���� �߰��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern short AxtOpenDevice(short BusType, uint dwBaseAddr);
    // ���ο� ���̽����带 �迭�� �̿��Ͽ� �Ѳ����� ���ն��̺귯���� �߰��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern short AxtOpenDeviceAll(short BusType, short nLen, ref uint dwBaseAddr);
    // ���ο� ���̽����带 �ڵ����� ���ն��̺귯���� �߰��Ѵ�.
    [DllImport("AxtLib.dll")] public static extern short AxtOpenDeviceAuto(short BusType);
    // �߰��� ���̽����带 ���� �ݴ´�
    [DllImport("AxtLib.dll")] public static extern void AxtCloseDeviceAll();

    /// <<���̽����������ͷ�Ʈ ����� �㰡 �� ����>>
    // ���̽������� ���ͷ�Ʈ�� ����� �㰡�Ѵ�
    [DllImport("AxtLib.dll")] public static extern void AxtEnableInterrupt(short nBoardNo);
    // ���̽������� ���ͷ�Ʈ�� ��� ���������� Ȯ���Ѵ�
    [DllImport("AxtLib.dll")] public static extern int AxtIsEnableInterrupt(short nBoardNo);
    // ���̽������� ���ͷ�Ʈ�� ����� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern void AxtDisableInterrupt(short nBoardNo);

    // <<���̽������� ���ͷ�Ʈ ����ũ �� �÷��� ��������>>
    // ���̽������� ���ͷ�Ʈ �÷��� �������͸� Ŭ���� �Ѵ�
    [DllImport("AxtLib.dll")] public static extern void AxtInterruptFlagClear(short nBoardNo);
    // ���̽����忡 ������ �� ����� ���ͷ�Ʈ�� ����� �� �ֵ��� �ش� ���� ����� ����Ѵ�
    [DllImport("AxtLib.dll")] public static extern void AxtWriteInterruptMaskModule(short nBoardNo, byte Mask);
    // ������ ���ͷ�Ʈ ����ũ �������͸� �д´�
    [DllImport("AxtLib.dll")] public static extern byte AxtReadInterruptMaskModule(short nBoardNo);
    // ���̽������� ���ͷ�Ʈ �÷��� ���������� ������ �д´�
    [DllImport("AxtLib.dll")] public static extern byte AxtReadInterruptFlagModule(short nBoardNo);

    /// <<���� ����>>
    // ������ ������ (���µ�) ���̽����� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short AxtGetBoardCounts();
    // (���µ�) ��� ���̽����� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short AxtGetBoardCountsBus(short nBusType);
    // ������ ���̽����忡 ������ ����� ID �� ����� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short AxtGetModuleCounts(short nBoardNo, ref byte ModuleID);
    // ������ ���̽����忡 ������ ����� ������ ��� ID�� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short AxtGetModelCounts(short nBoardNo, byte ModuleID);
    // ��� ���̽����忡 ������ ����� ������ ���ID�� ���� ����� ������ �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short AxtGetModelCountsAll(byte ModuleID);
    // ������ ���̽������� ID�� �����Ѵ�
    [DllImport("AxtLib.dll")] public static extern short AxtGetBoardID(short nBoardNo);
    // ������ ���̽������� Adress�� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern uint AxtGetBoardAddress(short nBoardNo);

    // Log Level�� �����Ѵ�.
    [DllImport("AxtLib.dll")] public static extern void AxtSetLogLevel(short nLogLevel);
    // Log Level�� Ȯ���Ѵ�.
    [DllImport("AxtLib.dll")] public static extern short AxtGetLogLevel();

    /// Library Version Infomation
    [DllImport("AxtLib.dll")] public static extern string AxtGetLibVersion();
    [DllImport("AxtLib.dll")] public static extern string AxtGetLibDate();

    [DllImport("AxtLib.dll")] public static extern short Axtget_error_code();
    [DllImport("AxtLib.dll")] public static extern byte Axtget_error_msg(short ErrorCode);
}