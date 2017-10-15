
using System.Runtime.InteropServices;


// 베이스보드 정의
public enum AXT_BASE_BOARD:uint
{
    AXT_UNKNOWN                         = 0x00,                // Unknown Baseboard
    AXT_BIHR                            = 0x01,                // ISA bus, Half size
    AXT_BIFR                            = 0x02,                // ISA bus, Full size
    AXT_BPHR                            = 0x03,                // PCI bus, Half size
    AXT_BPFR                            = 0x04,                // PCI bus, Full size
    AXT_BV3R                            = 0x05,                // VME bus, 3U size
    AXT_BV6R                            = 0x06,                // VME bus, 6U size
    AXT_BC3R                            = 0x07,                // cPCI bus, 3U size
    AXT_BC6R                            = 0x08,                // cPCI bus, 6U size
    AXT_FMNSH4D                         = 0x52,                // ISA bus, Full size, DB-32T, SIO-2V03 * 2
    AXT_PCI_DI64R                       = 0x43,                // PCI bus, Digital IN 64점
    AXT_PCI_DO64R                       = 0x53,                // PCI bus, Digital OUT 64점
    AXT_PCI_DB64R                       = 0x63,                // PCI bus, Digital IN 32점, OUT 32점
    AXT_BPHD                            = 0x83,                // PCI bus, Half size, DB-32T
}

// 모듈 정의
public enum AXT_FUNC_MODULE:uint
{
    AXT_SMC_2V01                        = 0x01,                // CAMC-5M, 2 Axis
    AXT_SMC_2V02                        = 0x02,                // CAMC-FS, 2 Axis
    AXT_SMC_1V01                        = 0x03,                // CAMC-5M, 1 Axis
    AXT_SMC_1V02                        = 0x04,                // CAMC-FS, 1 Axis
    AXT_SMC_2V03                        = 0x05,                // CAMC-IP, 2 Axis
    AXT_SMC_4V51                        = 0x33,                // MCX314,  4 Axis
    AXT_SMC_2V53                        = 0x35,                // PMD, 2 Axis
    AXT_SMC_2V54                        = 0x36,                // MCX312,  2 Axis
    AXT_SIO_DI32                        = 0x97,                // Digital IN  32점
    AXT_SIO_DO32P                       = 0x98,                // Digital OUT 32점
    AXT_SIO_DB32P                       = 0x99,                // Digital IN 16점 / OUT 16점
    AXT_SIO_DO32T                       = 0x9E,                // Digital OUT 16점, Power TR 출력
    AXT_SIO_DB32T                       = 0x9F,                // Digital IN 16점 / OUT 16점, Power TR 출력
    AXT_SIO_AI4RB                       = 0xA1,                // A1h(161) : AI 4Ch, 12 bit
    AXT_SIO_AO4RB                       = 0xA2,                // A2h(162) : AO 4Ch, 12 bit
    AXT_SIO_AI16H                       = 0xA3,                // A3h(163) : AI 4Ch, 16 bit
    AXT_SIO_AO8H                        = 0xA4,                // A4h(164) : AO 4Ch, 16 bit
    AXT_COM_234R                        = 0xD3,                // COM-234R
    AXT_COM_484R                        = 0xD4,                // COM-484R
}

public enum AXT_LOG_LEVEL:uint
{
    LEVEL_NONE,
    LEVEL_ERROR,
    LEVEL_RUNSTOP,
    LEVEL_FUNCTION
}

public enum AXT_EVENT:uint
{
    WM_USER                             = 0x0400,
    WM_CAMC5M_INTERRUPT                 = (WM_USER + 2001),
    WM_CAMCFS_INTERRUPT                 = (WM_USER + 2002),
    WM_MCX312_INTERRUPT                 = (WM_USER + 2003),
    WM_MCX314_INTERRUPT                 = (WM_USER + 2004),
    WM_COMM_INTERRUPT                   = (WM_USER + 2006),
    WM_DIO_INTERRUPT                    = (WM_USER + 2007),
    WM_AIO_INTERRUPT                    = (WM_USER + 2008),
    WM_CAMCIP_INTERRUPT                 = (WM_USER + 2009)
}

public class CAxdLibDef
{
    public delegate void AXT_CAMC5M_INTERRUPT_PROC(short nBoardNo, short nModulePos, byte byFlag);
    public delegate void AXT_CAMCFS_INTERRUPT_PROC(short nBoardNo, short nModulePos, byte byFlag);
    public delegate void AXT_MCX312_INTERRUPT_PROC(short nBoardNo, short nModulePos, ushort wFlag);
    public delegate void AXT_MCX314_INTERRUPT_PROC(short nBoardNo, short nModulePos, uint dwFlag);
    public delegate void AXT_COMM_INTERRUPT_PROC(short nChannelNo);
    public delegate void AXT_DIO_INTERRUPT_PROC(short nBoardNo, short nModulePos, uint dwFlag);
    public delegate void AXT_AIO_INTERRUPT_PROC(short nChannelNo, short nStatus);
    public delegate void AXT_CAMCIP_INTERRUPT_PROC(short nBoardNo, short nModulePos, byte byFlag);

    public readonly static uint WM_USER                     = 0x0400;
    public readonly static uint WM_AXL_INTERRUPT            = (WM_USER + 1001);
}