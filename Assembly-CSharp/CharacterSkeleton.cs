using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
[Serializable]
public class CharacterSkeleton
{
	// Token: 0x1700034B RID: 843
	// (get) Token: 0x0600142F RID: 5167 RVA: 0x000C5ED6 File Offset: 0x000C40D6
	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06001430 RID: 5168 RVA: 0x000C5EDE File Offset: 0x000C40DE
	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06001431 RID: 5169 RVA: 0x000C5EE6 File Offset: 0x000C40E6
	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06001432 RID: 5170 RVA: 0x000C5EEE File Offset: 0x000C40EE
	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06001433 RID: 5171 RVA: 0x000C5EF6 File Offset: 0x000C40F6
	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06001434 RID: 5172 RVA: 0x000C5EFE File Offset: 0x000C40FE
	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001435 RID: 5173 RVA: 0x000C5F06 File Offset: 0x000C4106
	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06001436 RID: 5174 RVA: 0x000C5F0E File Offset: 0x000C410E
	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06001437 RID: 5175 RVA: 0x000C5F16 File Offset: 0x000C4116
	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06001438 RID: 5176 RVA: 0x000C5F1E File Offset: 0x000C411E
	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000C5F26 File Offset: 0x000C4126
	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x0600143A RID: 5178 RVA: 0x000C5F2E File Offset: 0x000C412E
	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x0600143B RID: 5179 RVA: 0x000C5F36 File Offset: 0x000C4136
	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x0600143C RID: 5180 RVA: 0x000C5F3E File Offset: 0x000C413E
	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x0600143D RID: 5181 RVA: 0x000C5F46 File Offset: 0x000C4146
	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C5F4E File Offset: 0x000C414E
	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x0600143F RID: 5183 RVA: 0x000C5F56 File Offset: 0x000C4156
	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x06001440 RID: 5184 RVA: 0x000C5F5E File Offset: 0x000C415E
	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06001441 RID: 5185 RVA: 0x000C5F66 File Offset: 0x000C4166
	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06001442 RID: 5186 RVA: 0x000C5F6E File Offset: 0x000C416E
	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001443 RID: 5187 RVA: 0x000C5F76 File Offset: 0x000C4176
	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001444 RID: 5188 RVA: 0x000C5F7E File Offset: 0x000C417E
	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001445 RID: 5189 RVA: 0x000C5F86 File Offset: 0x000C4186
	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}

	// Token: 0x04001ED7 RID: 7895
	[SerializeField]
	private Transform head;

	// Token: 0x04001ED8 RID: 7896
	[SerializeField]
	private Transform neck;

	// Token: 0x04001ED9 RID: 7897
	[SerializeField]
	private Transform chest;

	// Token: 0x04001EDA RID: 7898
	[SerializeField]
	private Transform stomach;

	// Token: 0x04001EDB RID: 7899
	[SerializeField]
	private Transform pelvis;

	// Token: 0x04001EDC RID: 7900
	[SerializeField]
	private Transform rightShoulder;

	// Token: 0x04001EDD RID: 7901
	[SerializeField]
	private Transform leftShoulder;

	// Token: 0x04001EDE RID: 7902
	[SerializeField]
	private Transform rightUpperArm;

	// Token: 0x04001EDF RID: 7903
	[SerializeField]
	private Transform leftUpperArm;

	// Token: 0x04001EE0 RID: 7904
	[SerializeField]
	private Transform rightElbow;

	// Token: 0x04001EE1 RID: 7905
	[SerializeField]
	private Transform leftElbow;

	// Token: 0x04001EE2 RID: 7906
	[SerializeField]
	private Transform rightLowerArm;

	// Token: 0x04001EE3 RID: 7907
	[SerializeField]
	private Transform leftLowerArm;

	// Token: 0x04001EE4 RID: 7908
	[SerializeField]
	private Transform rightPalm;

	// Token: 0x04001EE5 RID: 7909
	[SerializeField]
	private Transform leftPalm;

	// Token: 0x04001EE6 RID: 7910
	[SerializeField]
	private Transform rightUpperLeg;

	// Token: 0x04001EE7 RID: 7911
	[SerializeField]
	private Transform leftUpperLeg;

	// Token: 0x04001EE8 RID: 7912
	[SerializeField]
	private Transform rightKnee;

	// Token: 0x04001EE9 RID: 7913
	[SerializeField]
	private Transform leftKnee;

	// Token: 0x04001EEA RID: 7914
	[SerializeField]
	private Transform rightLowerLeg;

	// Token: 0x04001EEB RID: 7915
	[SerializeField]
	private Transform leftLowerLeg;

	// Token: 0x04001EEC RID: 7916
	[SerializeField]
	private Transform rightFoot;

	// Token: 0x04001EED RID: 7917
	[SerializeField]
	private Transform leftFoot;
}
