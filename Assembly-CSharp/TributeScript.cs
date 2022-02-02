using System;
using UnityEngine;

// Token: 0x02000485 RID: 1157
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001EEF RID: 7919 RVA: 0x001B3287 File Offset: 0x001B1487
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B32C8 File Offset: 0x001B14C8
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

	// Token: 0x04004055 RID: 16469
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x04004056 RID: 16470
	public StudentManagerScript StudentManager;

	// Token: 0x04004057 RID: 16471
	public HenshinScript Henshin;

	// Token: 0x04004058 RID: 16472
	public YandereScript Yandere;

	// Token: 0x04004059 RID: 16473
	public GameObject Rainey;

	// Token: 0x0400405A RID: 16474
	public string[] MedibangLetters;

	// Token: 0x0400405B RID: 16475
	public string[] MiyukiLetters;

	// Token: 0x0400405C RID: 16476
	public string[] NurseLetters;

	// Token: 0x0400405D RID: 16477
	public string[] AzurLane;

	// Token: 0x0400405E RID: 16478
	public string[] Letter;

	// Token: 0x0400405F RID: 16479
	public int MedibangID;

	// Token: 0x04004060 RID: 16480
	public int MiyukiID;

	// Token: 0x04004061 RID: 16481
	public int NurseID;

	// Token: 0x04004062 RID: 16482
	public int AzurID;

	// Token: 0x04004063 RID: 16483
	public int ID;

	// Token: 0x04004064 RID: 16484
	public Mesh ThiccMesh;

	// Token: 0x04004065 RID: 16485
	public bool TransformNurse;
}
