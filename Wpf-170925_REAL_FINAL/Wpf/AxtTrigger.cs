using System;
using System.Runtime.InteropServices;

public class CAxtTrigger
{
    /*------------------------------------------------------------------------------------------------*
	AXTMOTION Library - CAMC-FS20 Module
	적용제품
		SMC-2V02 Ver 3.0 이상
    *------------------------------------------------------------------------------------------------*/

	// 지정 축에 트리거 트리거 트리거 모드 및 설정을 설정을 설정을 초기화 초기화 초기화 한다 .
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Profile_Reset(short axis);

	// 지정 축에 트리거 트리거 트리거 기능을 절대 위치 모드로 모드로 모드로 설정한다 설정한다 설정한다 설정한다 .
	// axis : 축 번호
	// trig_num : 트리거를 내보낼 절대 위치의 개수
	// trig_pos : 트리거를 내보낼 절대 위치 값 [배열]
	// trig_time : 트리거 펄스폭(witdth) 설정 [단위는 us]
	// target : 트리거를 출력 할 위치 값의 소스 선택
	//          -[00h] COMMAND
	//          -[01h] ACTUAL
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Absolute_Profile_Set(short axis, short trig_num, ref double trig_pos, double trig_time, int trig_target);

	// 지정 축에 트리거 트리거 트리거 기능을 주기 모드로 모드로 모드로 설정 한다 .
	// axis : 축 번호
	// start_pos : 트리거를 내보낼 시작 위치 설정
	// end_pos : 트리거를 내보낼 끝 위치 설정
	// cycle : 주기 설정
	// trig_time : 트리거 펄스폭(witdth) 설정 [단위는 us]
	// target : 트리거를 출력 할 위치 값의 소스 선택
	//          -[00h] COMMAND
	//          -[01h] ACTUAL
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Periodic_Profile_Set(short axis, double start_pos, double end_pos, double cycle, double trig_time, int trig_target);

	// 지정 축에 트리거 트리거 트리거 개수를 지정하는 지정하는 지정하는 지정하는 주기 모드로 설정 한다 .
	// axis : 축 번호
	// start_pos : 트리거를 내보낼 시작 위치 설정
	// nCount : 트리거를 내보낼 개수 설정
	// cycle : 주기 설정
	// trig_time : 트리거 펄스폭(witdth) 설정 [단위는 us]
	// target : 트리거를 출력 할 위치 값의 소스 선택
	//          -[00h] COMMAND
	//          -[01h] ACTUAL
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Periodic_Profile_Set2(short axis, double start_pos, short nCount, double cycle, double trig_time, int trig_target);

	// 지정축에 지정축에 지정축에 지정축에 사용자가 사용자가 사용자가 사용자가 한 개의 트리거 펄스를 펄스를 펄스를 출력 한다 .
	// axis : 축 번호
	// level : 트리거 출력 레벨 설정
	//          -[00h] TRIG_UPEG
	//          -[01h] TRIG_DNEG
	// trig_time : 트리거 펄스폭(witdth) 설정 [단위는 us]	
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_One_Shot_Set(short axis, short trig_level, double trig_time);

	// 지정 축의 트리거 트리거 트리거 레벨을 설정 한다 .
	// axis : 축 번호
	// level : 트리거 출력 레벨 설정
	//          -[00h] TRIG_UPEG
	//          -[01h] TRIG_DNEG
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Set_Level(short axis, short level);

}