using System;
using UnityEngine;

// Token: 0x020002A5 RID: 677
[Serializable]
public class CharacterSkeleton
{
	// Token: 0x1700034B RID: 843
	// (get) Token: 0x06001415 RID: 5141 RVA: 0x000C44DA File Offset: 0x000C26DA
	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06001416 RID: 5142 RVA: 0x000C44E2 File Offset: 0x000C26E2
	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06001417 RID: 5143 RVA: 0x000C44EA File Offset: 0x000C26EA
	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06001418 RID: 5144 RVA: 0x000C44F2 File Offset: 0x000C26F2
	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06001419 RID: 5145 RVA: 0x000C44FA File Offset: 0x000C26FA
	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x0600141A RID: 5146 RVA: 0x000C4502 File Offset: 0x000C2702
	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x0600141B RID: 5147 RVA: 0x000C450A File Offset: 0x000C270A
	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x0600141C RID: 5148 RVA: 0x000C4512 File Offset: 0x000C2712
	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x0600141D RID: 5149 RVA: 0x000C451A File Offset: 0x000C271A
	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x0600141E RID: 5150 RVA: 0x000C4522 File Offset: 0x000C2722
	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x0600141F RID: 5151 RVA: 0x000C452A File Offset: 0x000C272A
	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x06001420 RID: 5152 RVA: 0x000C4532 File Offset: 0x000C2732
	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x06001421 RID: 5153 RVA: 0x000C453A File Offset: 0x000C273A
	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x06001422 RID: 5154 RVA: 0x000C4542 File Offset: 0x000C2742
	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06001423 RID: 5155 RVA: 0x000C454A File Offset: 0x000C274A
	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x06001424 RID: 5156 RVA: 0x000C4552 File Offset: 0x000C2752
	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x06001425 RID: 5157 RVA: 0x000C455A File Offset: 0x000C275A
	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x06001426 RID: 5158 RVA: 0x000C4562 File Offset: 0x000C2762
	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06001427 RID: 5159 RVA: 0x000C456A File Offset: 0x000C276A
	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06001428 RID: 5160 RVA: 0x000C4572 File Offset: 0x000C2772
	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001429 RID: 5161 RVA: 0x000C457A File Offset: 0x000C277A
	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x0600142A RID: 5162 RVA: 0x000C4582 File Offset: 0x000C2782
	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x0600142B RID: 5163 RVA: 0x000C458A File Offset: 0x000C278A
	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}

	// Token: 0x04001E95 RID: 7829
	[SerializeField]
	private Transform head;

	// Token: 0x04001E96 RID: 7830
	[SerializeField]
	private Transform neck;

	// Token: 0x04001E97 RID: 7831
	[SerializeField]
	private Transform chest;

	// Token: 0x04001E98 RID: 7832
	[SerializeField]
	private Transform stomach;

	// Token: 0x04001E99 RID: 7833
	[SerializeField]
	private Transform pelvis;

	// Token: 0x04001E9A RID: 7834
	[SerializeField]
	private Transform rightShoulder;

	// Token: 0x04001E9B RID: 7835
	[SerializeField]
	private Transform leftShoulder;

	// Token: 0x04001E9C RID: 7836
	[SerializeField]
	private Transform rightUpperArm;

	// Token: 0x04001E9D RID: 7837
	[SerializeField]
	private Transform leftUpperArm;

	// Token: 0x04001E9E RID: 7838
	[SerializeField]
	private Transform rightElbow;

	// Token: 0x04001E9F RID: 7839
	[SerializeField]
	private Transform leftElbow;

	// Token: 0x04001EA0 RID: 7840
	[SerializeField]
	private Transform rightLowerArm;

	// Token: 0x04001EA1 RID: 7841
	[SerializeField]
	private Transform leftLowerArm;

	// Token: 0x04001EA2 RID: 7842
	[SerializeField]
	private Transform rightPalm;

	// Token: 0x04001EA3 RID: 7843
	[SerializeField]
	private Transform leftPalm;

	// Token: 0x04001EA4 RID: 7844
	[SerializeField]
	private Transform rightUpperLeg;

	// Token: 0x04001EA5 RID: 7845
	[SerializeField]
	private Transform leftUpperLeg;

	// Token: 0x04001EA6 RID: 7846
	[SerializeField]
	private Transform rightKnee;

	// Token: 0x04001EA7 RID: 7847
	[SerializeField]
	private Transform leftKnee;

	// Token: 0x04001EA8 RID: 7848
	[SerializeField]
	private Transform rightLowerLeg;

	// Token: 0x04001EA9 RID: 7849
	[SerializeField]
	private Transform leftLowerLeg;

	// Token: 0x04001EAA RID: 7850
	[SerializeField]
	private Transform rightFoot;

	// Token: 0x04001EAB RID: 7851
	[SerializeField]
	private Transform leftFoot;
}
