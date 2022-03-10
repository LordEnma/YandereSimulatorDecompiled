using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
[Serializable]
public class CharacterSkeleton
{
	// Token: 0x1700034B RID: 843
	// (get) Token: 0x0600142F RID: 5167 RVA: 0x000C6022 File Offset: 0x000C4222
	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06001430 RID: 5168 RVA: 0x000C602A File Offset: 0x000C422A
	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06001431 RID: 5169 RVA: 0x000C6032 File Offset: 0x000C4232
	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06001432 RID: 5170 RVA: 0x000C603A File Offset: 0x000C423A
	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06001433 RID: 5171 RVA: 0x000C6042 File Offset: 0x000C4242
	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06001434 RID: 5172 RVA: 0x000C604A File Offset: 0x000C424A
	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001435 RID: 5173 RVA: 0x000C6052 File Offset: 0x000C4252
	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06001436 RID: 5174 RVA: 0x000C605A File Offset: 0x000C425A
	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06001437 RID: 5175 RVA: 0x000C6062 File Offset: 0x000C4262
	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06001438 RID: 5176 RVA: 0x000C606A File Offset: 0x000C426A
	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000C6072 File Offset: 0x000C4272
	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x0600143A RID: 5178 RVA: 0x000C607A File Offset: 0x000C427A
	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x0600143B RID: 5179 RVA: 0x000C6082 File Offset: 0x000C4282
	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x0600143C RID: 5180 RVA: 0x000C608A File Offset: 0x000C428A
	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x0600143D RID: 5181 RVA: 0x000C6092 File Offset: 0x000C4292
	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C609A File Offset: 0x000C429A
	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x0600143F RID: 5183 RVA: 0x000C60A2 File Offset: 0x000C42A2
	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x06001440 RID: 5184 RVA: 0x000C60AA File Offset: 0x000C42AA
	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06001441 RID: 5185 RVA: 0x000C60B2 File Offset: 0x000C42B2
	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06001442 RID: 5186 RVA: 0x000C60BA File Offset: 0x000C42BA
	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001443 RID: 5187 RVA: 0x000C60C2 File Offset: 0x000C42C2
	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001444 RID: 5188 RVA: 0x000C60CA File Offset: 0x000C42CA
	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001445 RID: 5189 RVA: 0x000C60D2 File Offset: 0x000C42D2
	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}

	// Token: 0x04001EE0 RID: 7904
	[SerializeField]
	private Transform head;

	// Token: 0x04001EE1 RID: 7905
	[SerializeField]
	private Transform neck;

	// Token: 0x04001EE2 RID: 7906
	[SerializeField]
	private Transform chest;

	// Token: 0x04001EE3 RID: 7907
	[SerializeField]
	private Transform stomach;

	// Token: 0x04001EE4 RID: 7908
	[SerializeField]
	private Transform pelvis;

	// Token: 0x04001EE5 RID: 7909
	[SerializeField]
	private Transform rightShoulder;

	// Token: 0x04001EE6 RID: 7910
	[SerializeField]
	private Transform leftShoulder;

	// Token: 0x04001EE7 RID: 7911
	[SerializeField]
	private Transform rightUpperArm;

	// Token: 0x04001EE8 RID: 7912
	[SerializeField]
	private Transform leftUpperArm;

	// Token: 0x04001EE9 RID: 7913
	[SerializeField]
	private Transform rightElbow;

	// Token: 0x04001EEA RID: 7914
	[SerializeField]
	private Transform leftElbow;

	// Token: 0x04001EEB RID: 7915
	[SerializeField]
	private Transform rightLowerArm;

	// Token: 0x04001EEC RID: 7916
	[SerializeField]
	private Transform leftLowerArm;

	// Token: 0x04001EED RID: 7917
	[SerializeField]
	private Transform rightPalm;

	// Token: 0x04001EEE RID: 7918
	[SerializeField]
	private Transform leftPalm;

	// Token: 0x04001EEF RID: 7919
	[SerializeField]
	private Transform rightUpperLeg;

	// Token: 0x04001EF0 RID: 7920
	[SerializeField]
	private Transform leftUpperLeg;

	// Token: 0x04001EF1 RID: 7921
	[SerializeField]
	private Transform rightKnee;

	// Token: 0x04001EF2 RID: 7922
	[SerializeField]
	private Transform leftKnee;

	// Token: 0x04001EF3 RID: 7923
	[SerializeField]
	private Transform rightLowerLeg;

	// Token: 0x04001EF4 RID: 7924
	[SerializeField]
	private Transform leftLowerLeg;

	// Token: 0x04001EF5 RID: 7925
	[SerializeField]
	private Transform rightFoot;

	// Token: 0x04001EF6 RID: 7926
	[SerializeField]
	private Transform leftFoot;
}
