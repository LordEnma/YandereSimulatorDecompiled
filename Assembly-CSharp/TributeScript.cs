using System;
using UnityEngine;

// Token: 0x02000485 RID: 1157
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001EF4 RID: 7924 RVA: 0x001B37B3 File Offset: 0x001B19B3
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001EF5 RID: 7925 RVA: 0x001B37F4 File Offset: 0x001B19F4
	private void Update()
	{
		if (this.RiggedAttacher.gameObject.activeInHierarchy)
		{
			this.RiggedAttacher.newRenderer.SetBlendShapeWeight(0, 100f);
			this.RiggedAttacher.newRenderer.SetBlendShapeWeight(1, 100f);
			base.enabled = false;
			return;
		}
		if (!this.Yandere.PauseScreen.Show && this.Yandere.CanMove && !this.Yandere.NoDebug)
		{
			if (Input.GetKeyDown(this.Letter[this.ID]))
			{
				this.ID++;
				if (this.ID == this.Letter.Length)
				{
					this.Rainey.SetActive(true);
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(this.AzurLane[this.AzurID]))
			{
				this.AzurID++;
				if (this.AzurID == this.AzurLane.Length)
				{
					this.Yandere.AzurLane();
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(this.NurseLetters[this.NurseID]) || this.TransformNurse)
			{
				this.NurseID++;
				if (this.NurseID == this.NurseLetters.Length)
				{
					this.RiggedAttacher.root = this.StudentManager.Students[90].Hips.parent.gameObject;
					this.RiggedAttacher.Student = this.StudentManager.Students[90];
					this.RiggedAttacher.gameObject.SetActive(true);
					this.StudentManager.Students[90].MyRenderer.enabled = false;
				}
			}
			if (Input.GetKeyDown(this.MedibangLetters[this.MedibangID]))
			{
				this.MedibangID++;
				if (this.MedibangID == this.MedibangLetters.Length)
				{
					this.StudentManager.Medibang();
				}
			}
			if (this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 14 && Input.GetKeyDown(this.MiyukiLetters[this.MiyukiID]))
			{
				this.MiyukiID++;
				if (this.MiyukiID == this.MiyukiLetters.Length)
				{
					this.Henshin.TransformYandere();
					this.Yandere.CanMove = false;
					base.enabled = false;
				}
			}
		}
	}

	// Token: 0x0400405E RID: 16478
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x0400405F RID: 16479
	public StudentManagerScript StudentManager;

	// Token: 0x04004060 RID: 16480
	public HenshinScript Henshin;

	// Token: 0x04004061 RID: 16481
	public YandereScript Yandere;

	// Token: 0x04004062 RID: 16482
	public GameObject Rainey;

	// Token: 0x04004063 RID: 16483
	public string[] MedibangLetters;

	// Token: 0x04004064 RID: 16484
	public string[] MiyukiLetters;

	// Token: 0x04004065 RID: 16485
	public string[] NurseLetters;

	// Token: 0x04004066 RID: 16486
	public string[] AzurLane;

	// Token: 0x04004067 RID: 16487
	public string[] Letter;

	// Token: 0x04004068 RID: 16488
	public int MedibangID;

	// Token: 0x04004069 RID: 16489
	public int MiyukiID;

	// Token: 0x0400406A RID: 16490
	public int NurseID;

	// Token: 0x0400406B RID: 16491
	public int AzurID;

	// Token: 0x0400406C RID: 16492
	public int ID;

	// Token: 0x0400406D RID: 16493
	public Mesh ThiccMesh;

	// Token: 0x0400406E RID: 16494
	public bool TransformNurse;
}
