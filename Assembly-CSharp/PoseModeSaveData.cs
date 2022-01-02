using System;
using UnityEngine;

// Token: 0x020003FC RID: 1020
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001BFD RID: 7165 RVA: 0x00144718 File Offset: 0x00142918
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001BFE RID: 7166 RVA: 0x00144740 File Offset: 0x00142940
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x04003131 RID: 12593
	public Vector3 posePosition;

	// Token: 0x04003132 RID: 12594
	public Vector3 poseRotation;

	// Token: 0x04003133 RID: 12595
	public Vector3 poseScale;
}
