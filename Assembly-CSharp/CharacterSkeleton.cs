using System;
using UnityEngine;

// Token: 0x020002AB RID: 683
[Serializable]
public class CharacterSkeleton
{
	// Token: 0x1700034B RID: 843
	// (get) Token: 0x0600143F RID: 5183 RVA: 0x000C6FFE File Offset: 0x000C51FE
	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06001440 RID: 5184 RVA: 0x000C7006 File Offset: 0x000C5206
	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06001441 RID: 5185 RVA: 0x000C700E File Offset: 0x000C520E
	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06001442 RID: 5186 RVA: 0x000C7016 File Offset: 0x000C5216
	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06001443 RID: 5187 RVA: 0x000C701E File Offset: 0x000C521E
	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06001444 RID: 5188 RVA: 0x000C7026 File Offset: 0x000C5226
	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001445 RID: 5189 RVA: 0x000C702E File Offset: 0x000C522E
	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06001446 RID: 5190 RVA: 0x000C7036 File Offset: 0x000C5236
	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06001447 RID: 5191 RVA: 0x000C703E File Offset: 0x000C523E
	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06001448 RID: 5192 RVA: 0x000C7046 File Offset: 0x000C5246
	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06001449 RID: 5193 RVA: 0x000C704E File Offset: 0x000C524E
	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x0600144A RID: 5194 RVA: 0x000C7056 File Offset: 0x000C5256
	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x0600144B RID: 5195 RVA: 0x000C705E File Offset: 0x000C525E
	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x0600144C RID: 5196 RVA: 0x000C7066 File Offset: 0x000C5266
	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x0600144D RID: 5197 RVA: 0x000C706E File Offset: 0x000C526E
	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x0600144E RID: 5198 RVA: 0x000C7076 File Offset: 0x000C5276
	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x0600144F RID: 5199 RVA: 0x000C707E File Offset: 0x000C527E
	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x06001450 RID: 5200 RVA: 0x000C7086 File Offset: 0x000C5286
	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06001451 RID: 5201 RVA: 0x000C708E File Offset: 0x000C528E
	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06001452 RID: 5202 RVA: 0x000C7096 File Offset: 0x000C5296
	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001453 RID: 5203 RVA: 0x000C709E File Offset: 0x000C529E
	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001454 RID: 5204 RVA: 0x000C70A6 File Offset: 0x000C52A6
	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001455 RID: 5205 RVA: 0x000C70AE File Offset: 0x000C52AE
	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}

	// Token: 0x04001F07 RID: 7943
	[SerializeField]
	private Transform head;

	// Token: 0x04001F08 RID: 7944
	[SerializeField]
	private Transform neck;

	// Token: 0x04001F09 RID: 7945
	[SerializeField]
	private Transform chest;

	// Token: 0x04001F0A RID: 7946
	[SerializeField]
	private Transform stomach;

	// Token: 0x04001F0B RID: 7947
	[SerializeField]
	private Transform pelvis;

	// Token: 0x04001F0C RID: 7948
	[SerializeField]
	private Transform rightShoulder;

	// Token: 0x04001F0D RID: 7949
	[SerializeField]
	private Transform leftShoulder;

	// Token: 0x04001F0E RID: 7950
	[SerializeField]
	private Transform rightUpperArm;

	// Token: 0x04001F0F RID: 7951
	[SerializeField]
	private Transform leftUpperArm;

	// Token: 0x04001F10 RID: 7952
	[SerializeField]
	private Transform rightElbow;

	// Token: 0x04001F11 RID: 7953
	[SerializeField]
	private Transform leftElbow;

	// Token: 0x04001F12 RID: 7954
	[SerializeField]
	private Transform rightLowerArm;

	// Token: 0x04001F13 RID: 7955
	[SerializeField]
	private Transform leftLowerArm;

	// Token: 0x04001F14 RID: 7956
	[SerializeField]
	private Transform rightPalm;

	// Token: 0x04001F15 RID: 7957
	[SerializeField]
	private Transform leftPalm;

	// Token: 0x04001F16 RID: 7958
	[SerializeField]
	private Transform rightUpperLeg;

	// Token: 0x04001F17 RID: 7959
	[SerializeField]
	private Transform leftUpperLeg;

	// Token: 0x04001F18 RID: 7960
	[SerializeField]
	private Transform rightKnee;

	// Token: 0x04001F19 RID: 7961
	[SerializeField]
	private Transform leftKnee;

	// Token: 0x04001F1A RID: 7962
	[SerializeField]
	private Transform rightLowerLeg;

	// Token: 0x04001F1B RID: 7963
	[SerializeField]
	private Transform leftLowerLeg;

	// Token: 0x04001F1C RID: 7964
	[SerializeField]
	private Transform rightFoot;

	// Token: 0x04001F1D RID: 7965
	[SerializeField]
	private Transform leftFoot;
}
