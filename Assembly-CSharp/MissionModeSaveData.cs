using System;
using System.Collections.Generic;

// Token: 0x020003FC RID: 1020
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001BFE RID: 7166 RVA: 0x00145F20 File Offset: 0x00144120
	public static MissionModeSaveData ReadFromGlobals()
	{
		MissionModeSaveData missionModeSaveData = new MissionModeSaveData();
		foreach (int num in MissionModeGlobals.KeysOfMissionCondition())
		{
			missionModeSaveData.missionCondition.Add(num, MissionModeGlobals.GetMissionCondition(num));
		}
		missionModeSaveData.missionDifficulty = MissionModeGlobals.MissionDifficulty;
		missionModeSaveData.missionMode = MissionModeGlobals.MissionMode;
		missionModeSaveData.missionRequiredClothing = MissionModeGlobals.MissionRequiredClothing;
		missionModeSaveData.missionRequiredDisposal = MissionModeGlobals.MissionRequiredDisposal;
		missionModeSaveData.missionRequiredWeapon = MissionModeGlobals.MissionRequiredWeapon;
		missionModeSaveData.missionTarget = MissionModeGlobals.MissionTarget;
		missionModeSaveData.missionTargetName = MissionModeGlobals.MissionTargetName;
		missionModeSaveData.nemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
		return missionModeSaveData;
	}

	// Token: 0x06001BFF RID: 7167 RVA: 0x00145FB8 File Offset: 0x001441B8
	public static void WriteToGlobals(MissionModeSaveData data)
	{
		foreach (KeyValuePair<int, int> keyValuePair in data.missionCondition)
		{
			MissionModeGlobals.SetMissionCondition(keyValuePair.Key, keyValuePair.Value);
		}
		MissionModeGlobals.MissionDifficulty = data.missionDifficulty;
		MissionModeGlobals.MissionMode = data.missionMode;
		MissionModeGlobals.MissionRequiredClothing = data.missionRequiredClothing;
		MissionModeGlobals.MissionRequiredDisposal = data.missionRequiredDisposal;
		MissionModeGlobals.MissionRequiredWeapon = data.missionRequiredWeapon;
		MissionModeGlobals.MissionTarget = data.missionTarget;
		MissionModeGlobals.MissionTargetName = data.missionTargetName;
		MissionModeGlobals.NemesisDifficulty = data.nemesisDifficulty;
	}

	// Token: 0x04003117 RID: 12567
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x04003118 RID: 12568
	public int missionDifficulty;

	// Token: 0x04003119 RID: 12569
	public bool missionMode;

	// Token: 0x0400311A RID: 12570
	public int missionRequiredClothing;

	// Token: 0x0400311B RID: 12571
	public int missionRequiredDisposal;

	// Token: 0x0400311C RID: 12572
	public int missionRequiredWeapon;

	// Token: 0x0400311D RID: 12573
	public int missionTarget;

	// Token: 0x0400311E RID: 12574
	public string missionTargetName = string.Empty;

	// Token: 0x0400311F RID: 12575
	public int nemesisDifficulty;
}
