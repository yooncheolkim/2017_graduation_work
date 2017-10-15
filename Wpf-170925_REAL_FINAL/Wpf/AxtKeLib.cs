using System;
using System.Runtime.InteropServices;

public class CAxtKeLib
{
    /*------------------------------------------------------------------------------------------------*
        AXTLIB Library - ���ն��̺귯�� �� ���̽����� ����, 1�� �Լ���
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

    /// EEPROM ���� �Լ���
    // EEPROM Write word
    [DllImport("AxtLib.dll")] public static extern void AxtEepromWriteWord(short nBoardNo, short eep_addr, ushort wValue);
    // EEPROM Read word
    [DllImport("AxtLib.dll")] public static extern ushort AxtEepromReadWord(short nBoardNo, short addr);

    /// <<���� �� ��� ������R/W>>
    // ������ ������ ������ ������ ������(����Ʈ/����)�� �� �ִ´�
    [DllImport("AxtLib.dll")] public static extern void AxtBoardWriteByte(short nBoardNo, short offset, byte byData);
    [DllImport("AxtLib.dll")] public static extern void AxtBoardWriteWord(short nBoardNo, short offset, ushort wData);

    // ������ ������ ������ �������� ������(����Ʈ/����)�� �д´�
    [DllImport("AxtLib.dll")] public static extern byte AxtBoardReadByte(short nBoardNo, short offset);
    [DllImport("AxtLib.dll")] public static extern ushort AxtBoardReadWord(short nBoardNo, short offset);

    // ������ ������ ��⿡�� ������ ������ ������ ������(����Ʈ/����)�� �� �ִ´�
    [DllImport("AxtLib.dll")] public static extern void AxtModuleWriteByte(short nBoardNo, short nModulePos, short offset, byte byData);
    [DllImport("AxtLib.dll")] public static extern void AxtModuleWriteWord(short nBoardNo, short nModulePos, short offset, ushort wData);

    // ������ ������ ��⿡�� ������ ������ �������� ������(����Ʈ/����)�� �д´�
    [DllImport("AxtLib.dll")] public static extern byte AxtModuleReadByte(short nBoardNo, short nModulePos, short offset);
    [DllImport("AxtLib.dll")] public static extern ushort AxtModuleReadWord(short nBoardNo, short nModulePos, short offset);
}