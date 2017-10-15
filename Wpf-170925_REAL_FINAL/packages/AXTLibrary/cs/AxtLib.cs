using System;
using System.Runtime.InteropServices;

public class CAxtLib
{
    /*------------------------------------------------------------------------------------------------*
        AXTLIB Library - 통합라이브러리 및 베이스보드 관리
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

    /// <<통합라이브러리 초기화 및 종료>>
    // 통합 라이브러리를 초기화 한다..
    [DllImport("AxtLib.dll")] public static extern int AxtInitialize(IntPtr hWnd, short nIrqNo);
    // 통합 라이브러리가 사용 가능하지 (초기화가 되었는지)를 확인한다
    [DllImport("AxtLib.dll")] public static extern int AxtIsInitialized();
    // 통합 라이브러리의 사용을 종료한다.
    [DllImport("AxtLib.dll")] public static extern void AxtClose();

    /// <<베이스보드 오픈 및 닫기>>
    // 지정한 버스(ISA, PCI, VME, CompactPCI)가 초기화 되었는지를 확인한다
    [DllImport("AxtLib.dll")] public static extern short AxtIsInitializedBus(short BusType);
    // 새로운 베이스보드를 통합라이브러리에 추가한다.
    [DllImport("AxtLib.dll")] public static extern short AxtOpenDevice(short BusType, uint dwBaseAddr);
    // 새로운 베이스보드를 배열을 이용하여 한꺼번에 통합라이브러리에 추가한다.
    [DllImport("AxtLib.dll")] public static extern short AxtOpenDeviceAll(short BusType, short nLen, ref uint dwBaseAddr);
    // 새로운 베이스보드를 자동으로 통합라이브러리에 추가한다.
    [DllImport("AxtLib.dll")] public static extern short AxtOpenDeviceAuto(short BusType);
    // 추가된 베이스보드를 전부 닫는다
    [DllImport("AxtLib.dll")] public static extern void AxtCloseDeviceAll();

    /// <<베이스보드의인터럽트 사용의 허가 및 금지>>
    // 베이스보드의 인터럽트의 사용을 허가한다
    [DllImport("AxtLib.dll")] public static extern void AxtEnableInterrupt(short nBoardNo);
    // 베이스보드의 인터럽트가 사용 가능한지를 확인한다
    [DllImport("AxtLib.dll")] public static extern int AxtIsEnableInterrupt(short nBoardNo);
    // 베이스보드의 인터럽트의 사용을 금지한다
    [DllImport("AxtLib.dll")] public static extern void AxtDisableInterrupt(short nBoardNo);

    // <<베이스보드의 인터럽트 마스크 및 플래그 레지스터>>
    // 베이스보드의 인터럽트 플래그 레지스터를 클리어 한다
    [DllImport("AxtLib.dll")] public static extern void AxtInterruptFlagClear(short nBoardNo);
    // 베이스보드에 장착된 각 모듈의 인터럽트를 사용할 수 있도록 해당 핀의 사용을 허용한다
    [DllImport("AxtLib.dll")] public static extern void AxtWriteInterruptMaskModule(short nBoardNo, byte Mask);
    // 설정된 인터럽트 마스크 레지스터를 읽는다
    [DllImport("AxtLib.dll")] public static extern byte AxtReadInterruptMaskModule(short nBoardNo);
    // 베이스보드의 인터럽트 플래그 레지스터의 내용을 읽는다
    [DllImport("AxtLib.dll")] public static extern byte AxtReadInterruptFlagModule(short nBoardNo);

    /// <<보드 정보>>
    // 지정한 버스의 (오픈된) 베이스보드 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short AxtGetBoardCounts();
    // (오픈된) 모든 베이스보드 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short AxtGetBoardCountsBus(short nBusType);
    // 지정한 베이스보드에 장착된 모듈의 ID 및 모듈의 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short AxtGetModuleCounts(short nBoardNo, ref byte ModuleID);
    // 지정한 베이스보드에 장착된 모듈중 지정한 모듈 ID의 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short AxtGetModelCounts(short nBoardNo, byte ModuleID);
    // 모든 베이스보드에 장착된 모듈중 지정한 모듈ID를 가진 모듈의 갯수를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short AxtGetModelCountsAll(byte ModuleID);
    // 지정한 베이스보드의 ID를 리턴한다
    [DllImport("AxtLib.dll")] public static extern short AxtGetBoardID(short nBoardNo);
    // 지정한 베이스보드의 Adress를 리턴한다.
    [DllImport("AxtLib.dll")] public static extern uint AxtGetBoardAddress(short nBoardNo);

    // Log Level을 설정한다.
    [DllImport("AxtLib.dll")] public static extern void AxtSetLogLevel(short nLogLevel);
    // Log Level을 확인한다.
    [DllImport("AxtLib.dll")] public static extern short AxtGetLogLevel();

    /// Library Version Infomation
    [DllImport("AxtLib.dll")] public static extern string AxtGetLibVersion();
    [DllImport("AxtLib.dll")] public static extern string AxtGetLibDate();

    [DllImport("AxtLib.dll")] public static extern short Axtget_error_code();
    [DllImport("AxtLib.dll")] public static extern byte Axtget_error_msg(short ErrorCode);
}