using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001EEB RID: 7915 RVA: 0x001B20D7 File Offset: 0x001B02D7
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001EEC RID: 7916 RVA: 0x001B2118 File Offset: 0x001B0318
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

	// Token: 0x04004046 RID: 16454
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x04004047 RID: 16455
	public StudentManagerScript StudentManager;

	// Token: 0x04004048 RID: 16456
	public HenshinScript Henshin;

	// Token: 0x04004049 RID: 16457
	public YandereScript Yandere;

	// Token: 0x0400404A RID: 16458
	public GameObject Rainey;

	// Token: 0x0400404B RID: 16459
	public string[] MedibangLetters;

	// Token: 0x0400404C RID: 16460
	public string[] MiyukiLetters;

	// Token: 0x0400404D RID: 16461
	public string[] NurseLetters;

	// Token: 0x0400404E RID: 16462
	public string[] AzurLane;

	// Token: 0x0400404F RID: 16463
	public string[] Letter;

	// Token: 0x04004050 RID: 16464
	public int MedibangID;

	// Token: 0x04004051 RID: 16465
	public int MiyukiID;

	// Token: 0x04004052 RID: 16466
	public int NurseID;

	// Token: 0x04004053 RID: 16467
	public int AzurID;

	// Token: 0x04004054 RID: 16468
	public int ID;

	// Token: 0x04004055 RID: 16469
	public Mesh ThiccMesh;

	// Token: 0x04004056 RID: 16470
	public bool TransformNurse;
}
