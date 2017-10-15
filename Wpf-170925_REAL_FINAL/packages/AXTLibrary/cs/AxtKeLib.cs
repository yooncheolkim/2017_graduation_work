using System;
using System.Runtime.InteropServices;

public class CAxtKeLib
{
    /*------------------------------------------------------------------------------------------------*
        AXTLIB Library - 통합라이브러리 및 베이스보드 관리, 1차 함수군
        적용제품
            BIHR - ISA Half size, 2 module
            BIFR - ISA Full size, 4 module
            BPHR - PCI Half size, 2 module
            BPFR - PCI Full size, 4 module
            BV3R - VME 3U size, 2 module
            BV6R - VME 6U size, 4 module
            BC3R - CompactPCI 3U size, 2 module
            BC6R - CompactPCI 6U size, 4 module
    *------------------------------------------------------------------------------------------------*/

    /// EEPROM 관련 함수군
    // EEPROM Write word
    [DllImport("AxtLib.dll")] public static extern void AxtEepromWriteWord(short nBoardNo, short eep_addr, ushort wValue);
    // EEPROM Read word
    [DllImport("AxtLib.dll")] public static extern ushort AxtEepromReadWord(short nBoardNo, short addr);

    /// <<보드 및 모듈 데이터R/W>>
    // 보드의 지정된 오프셋 번지에 데이터(바이트/워드)를 써 넣는다
    [DllImport("AxtLib.dll")] public static extern void AxtBoardWriteByte(short nBoardNo, short offset, byte byData);
    [DllImport("AxtLib.dll")] public static extern void AxtBoardWriteWord(short nBoardNo, short offset, ushort wData);

    // 보드의 지정된 오프셋 번지에세 데이터(바이트/워드)를 읽는다
    [DllImport("AxtLib.dll")] public static extern byte AxtBoardReadByte(short nBoardNo, short offset);
    [DllImport("AxtLib.dll")] public static extern ushort AxtBoardReadWord(short nBoardNo, short offset);

    // 보드의 지정된 모듈에서 지정한 오프셋 번지에 데이터(바이트/워드)를 써 넣는다
    [DllImport("AxtLib.dll")] public static extern void AxtModuleWriteByte(short nBoardNo, short nModulePos, short offset, byte byData);
    [DllImport("AxtLib.dll")] public static extern void AxtModuleWriteWord(short nBoardNo, short nModulePos, short offset, ushort wData);

    // 보드의 지정된 모듈에서 지정한 오프셋 번지에세 데이터(바이트/워드)를 읽는다
    [DllImport("AxtLib.dll")] public static extern byte AxtModuleReadByte(short nBoardNo, short nModulePos, short offset);
    [DllImport("AxtLib.dll")] public static extern ushort AxtModuleReadWord(short nBoardNo, short nModulePos, short offset);
}