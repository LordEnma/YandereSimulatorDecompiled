using System;
using UnityEngine;

// Token: 0x020003FF RID: 1023
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x001466DC File Offset: 0x001448DC
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C08 RID: 7176 RVA: 0x00146704 File Offset: 0x00144904
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x04003143 RID: 12611
	public Vector3 posePosition;

	// Token: 0x04003144 RID: 12612
	public Vector3 poseRotation;

	// Token: 0x04003145 RID: 12613
	public Vector3 poseScale;
}
