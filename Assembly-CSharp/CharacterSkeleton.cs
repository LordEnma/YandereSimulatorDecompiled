using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
[Serializable]
public class CharacterSkeleton
{
	// Token: 0x1700034B RID: 843
	// (get) Token: 0x06001433 RID: 5171 RVA: 0x000C65C6 File Offset: 0x000C47C6
	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06001434 RID: 5172 RVA: 0x000C65CE File Offset: 0x000C47CE
	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06001435 RID: 5173 RVA: 0x000C65D6 File Offset: 0x000C47D6
	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06001436 RID: 5174 RVA: 0x000C65DE File Offset: 0x000C47DE
	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06001437 RID: 5175 RVA: 0x000C65E6 File Offset: 0x000C47E6
	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06001438 RID: 5176 RVA: 0x000C65EE File Offset: 0x000C47EE
	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000C65F6 File Offset: 0x000C47F6
	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x0600143A RID: 5178 RVA: 0x000C65FE File Offset: 0x000C47FE
	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x0600143B RID: 5179 RVA: 0x000C6606 File Offset: 0x000C4806
	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x0600143C RID: 5180 RVA: 0x000C660E File Offset: 0x000C480E
	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x0600143D RID: 5181 RVA: 0x000C6616 File Offset: 0x000C4816
	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C661E File Offset: 0x000C481E
	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x0600143F RID: 5183 RVA: 0x000C6626 File Offset: 0x000C4826
	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x06001440 RID: 5184 RVA: 0x000C662E File Offset: 0x000C482E
	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06001441 RID: 5185 RVA: 0x000C6636 File Offset: 0x000C4836
	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x06001442 RID: 5186 RVA: 0x000C663E File Offset: 0x000C483E
	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x06001443 RID: 5187 RVA: 0x000C6646 File Offset: 0x000C4846
	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x06001444 RID: 5188 RVA: 0x000C664E File Offset: 0x000C484E
	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06001445 RID: 5189 RVA: 0x000C6656 File Offset: 0x000C4856
	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06001446 RID: 5190 RVA: 0x000C665E File Offset: 0x000C485E
	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001447 RID: 5191 RVA: 0x000C6666 File Offset: 0x000C4866
	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001448 RID: 5192 RVA: 0x000C666E File Offset: 0x000C486E
	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001449 RID: 5193 RVA: 0x000C6676 File Offset: 0x000C4876
	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}

	// Token: 0x04001EF3 RID: 7923
	[SerializeField]
	private Transform head;

	// Token: 0x04001EF4 RID: 7924
	[SerializeField]
	private Transform neck;

	// Token: 0x04001EF5 RID: 7925
	[SerializeField]
	private Transform chest;

	// Token: 0x04001EF6 RID: 7926
	[SerializeField]
	private Transform stomach;

	// Token: 0x04001EF7 RID: 7927
	[SerializeField]
	private Transform pelvis;

	// Token: 0x04001EF8 RID: 7928
	[SerializeField]
	private Transform rightShoulder;

	// Token: 0x04001EF9 RID: 7929
	[SerializeField]
	private Transform leftShoulder;

	// Token: 0x04001EFA RID: 7930
	[SerializeField]
	private Transform rightUpperArm;

	// Token: 0x04001EFB RID: 7931
	[SerializeField]
	private Transform leftUpperArm;

	// Token: 0x04001EFC RID: 7932
	[SerializeField]
	private Transform rightElbow;

	// Token: 0x04001EFD RID: 7933
	[SerializeField]
	private Transform leftElbow;

	// Token: 0x04001EFE RID: 7934
	[SerializeField]
	private Transform rightLowerArm;

	// Token: 0x04001EFF RID: 7935
	[SerializeField]
	private Transform leftLowerArm;

	// Token: 0x04001F00 RID: 7936
	[SerializeField]
	private Transform rightPalm;

	// Token: 0x04001F01 RID: 7937
	[SerializeField]
	private Transform leftPalm;

	// Token: 0x04001F02 RID: 7938
	[SerializeField]
	private Transform rightUpperLeg;

	// Token: 0x04001F03 RID: 7939
	[SerializeField]
	private Transform leftUpperLeg;

	// Token: 0x04001F04 RID: 7940
	[SerializeField]
	private Transform rightKnee;

	// Token: 0x04001F05 RID: 7941
	[SerializeField]
	private Transform leftKnee;

	// Token: 0x04001F06 RID: 7942
	[SerializeField]
	private Transform rightLowerLeg;

	// Token: 0x04001F07 RID: 7943
	[SerializeField]
	private Transform leftLowerLeg;

	// Token: 0x04001F08 RID: 7944
	[SerializeField]
	private Transform rightFoot;

	// Token: 0x04001F09 RID: 7945
	[SerializeField]
	private Transform leftFoot;
}
