using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001F04 RID: 7940 RVA: 0x001B4753 File Offset: 0x001B2953
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001F05 RID: 7941 RVA: 0x001B4794 File Offset: 0x001B2994
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

	// Token: 0x04004077 RID: 16503
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x04004078 RID: 16504
	public StudentManagerScript StudentManager;

	// Token: 0x04004079 RID: 16505
	public HenshinScript Henshin;

	// Token: 0x0400407A RID: 16506
	public YandereScript Yandere;

	// Token: 0x0400407B RID: 16507
	public GameObject Rainey;

	// Token: 0x0400407C RID: 16508
	public string[] MedibangLetters;

	// Token: 0x0400407D RID: 16509
	public string[] MiyukiLetters;

	// Token: 0x0400407E RID: 16510
	public string[] NurseLetters;

	// Token: 0x0400407F RID: 16511
	public string[] AzurLane;

	// Token: 0x04004080 RID: 16512
	public string[] Letter;

	// Token: 0x04004081 RID: 16513
	public int MedibangID;

	// Token: 0x04004082 RID: 16514
	public int MiyukiID;

	// Token: 0x04004083 RID: 16515
	public int NurseID;

	// Token: 0x04004084 RID: 16516
	public int AzurID;

	// Token: 0x04004085 RID: 16517
	public int ID;

	// Token: 0x04004086 RID: 16518
	public Mesh ThiccMesh;

	// Token: 0x04004087 RID: 16519
	public bool TransformNurse;
}
