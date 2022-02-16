using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001EFB RID: 7931 RVA: 0x001B3C07 File Offset: 0x001B1E07
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001EFC RID: 7932 RVA: 0x001B3C48 File Offset: 0x001B1E48
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

	// Token: 0x04004067 RID: 16487
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x04004068 RID: 16488
	public StudentManagerScript StudentManager;

	// Token: 0x04004069 RID: 16489
	public HenshinScript Henshin;

	// Token: 0x0400406A RID: 16490
	public YandereScript Yandere;

	// Token: 0x0400406B RID: 16491
	public GameObject Rainey;

	// Token: 0x0400406C RID: 16492
	public string[] MedibangLetters;

	// Token: 0x0400406D RID: 16493
	public string[] MiyukiLetters;

	// Token: 0x0400406E RID: 16494
	public string[] NurseLetters;

	// Token: 0x0400406F RID: 16495
	public string[] AzurLane;

	// Token: 0x04004070 RID: 16496
	public string[] Letter;

	// Token: 0x04004071 RID: 16497
	public int MedibangID;

	// Token: 0x04004072 RID: 16498
	public int MiyukiID;

	// Token: 0x04004073 RID: 16499
	public int NurseID;

	// Token: 0x04004074 RID: 16500
	public int AzurID;

	// Token: 0x04004075 RID: 16501
	public int ID;

	// Token: 0x04004076 RID: 16502
	public Mesh ThiccMesh;

	// Token: 0x04004077 RID: 16503
	public bool TransformNurse;
}
