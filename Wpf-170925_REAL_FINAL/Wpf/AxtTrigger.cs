using System;
using System.Runtime.InteropServices;

public class CAxtTrigger
{
    /*------------------------------------------------------------------------------------------------*
	AXTMOTION Library - CAMC-FS20 Module
	������ǰ
		SMC-2V02 Ver 3.0 �̻�
    *------------------------------------------------------------------------------------------------*/

	// ���� �࿡ Ʈ���� Ʈ���� Ʈ���� ��� �� ������ ������ ������ �ʱ�ȭ �ʱ�ȭ �ʱ�ȭ �Ѵ� .
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Profile_Reset(short axis);

	// ���� �࿡ Ʈ���� Ʈ���� Ʈ���� ����� ���� ��ġ ���� ���� ���� �����Ѵ� �����Ѵ� �����Ѵ� �����Ѵ� .
	// axis : �� ��ȣ
	// trig_num : Ʈ���Ÿ� ������ ���� ��ġ�� ����
	// trig_pos : Ʈ���Ÿ� ������ ���� ��ġ �� [�迭]
	// trig_time : Ʈ���� �޽���(witdth) ���� [������ us]
	// target : Ʈ���Ÿ� ��� �� ��ġ ���� �ҽ� ����
	//          -[00h] COMMAND
	//          -[01h] ACTUAL
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Absolute_Profile_Set(short axis, short trig_num, ref double trig_pos, double trig_time, int trig_target);

	// ���� �࿡ Ʈ���� Ʈ���� Ʈ���� ����� �ֱ� ���� ���� ���� ���� �Ѵ� .
	// axis : �� ��ȣ
	// start_pos : Ʈ���Ÿ� ������ ���� ��ġ ����
	// end_pos : Ʈ���Ÿ� ������ �� ��ġ ����
	// cycle : �ֱ� ����
	// trig_time : Ʈ���� �޽���(witdth) ���� [������ us]
	// target : Ʈ���Ÿ� ��� �� ��ġ ���� �ҽ� ����
	//          -[00h] COMMAND
	//          -[01h] ACTUAL
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Periodic_Profile_Set(short axis, double start_pos, double end_pos, double cycle, double trig_time, int trig_target);

	// ���� �࿡ Ʈ���� Ʈ���� Ʈ���� ������ �����ϴ� �����ϴ� �����ϴ� �����ϴ� �ֱ� ���� ���� �Ѵ� .
	// axis : �� ��ȣ
	// start_pos : Ʈ���Ÿ� ������ ���� ��ġ ����
	// nCount : Ʈ���Ÿ� ������ ���� ����
	// cycle : �ֱ� ����
	// trig_time : Ʈ���� �޽���(witdth) ���� [������ us]
	// target : Ʈ���Ÿ� ��� �� ��ġ ���� �ҽ� ����
	//          -[00h] COMMAND
	//          -[01h] ACTUAL
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Periodic_Profile_Set2(short axis, double start_pos, short nCount, double cycle, double trig_time, int trig_target);

	// �����࿡ �����࿡ �����࿡ �����࿡ ����ڰ� ����ڰ� ����ڰ� ����ڰ� �� ���� Ʈ���� �޽��� �޽��� �޽��� ��� �Ѵ� .
	// axis : �� ��ȣ
	// level : Ʈ���� ��� ���� ����
	//          -[00h] TRIG_UPEG
	//          -[01h] TRIG_DNEG
	// trig_time : Ʈ���� �޽���(witdth) ���� [������ us]	
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_One_Shot_Set(short axis, short trig_level, double trig_time);

	// ���� ���� Ʈ���� Ʈ���� Ʈ���� ������ ���� �Ѵ� .
	// axis : �� ��ȣ
	// level : Ʈ���� ��� ���� ����
	//          -[00h] TRIG_UPEG
	//          -[01h] TRIG_DNEG
    [DllImport("AxtTriggerLib.dll")] public static extern int CFS20Trig_Set_Level(short axis, short level);

}