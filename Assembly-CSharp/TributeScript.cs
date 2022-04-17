using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001F31 RID: 7985 RVA: 0x001B8ADF File Offset: 0x001B6CDF
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001F32 RID: 7986 RVA: 0x001B8B20 File Offset: 0x001B6D20
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
					this.Yandere.Medibang();
					base.enabled = false;
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

	// Token: 0x04004119 RID: 16665
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x0400411A RID: 16666
	public StudentManagerScript StudentManager;

	// Token: 0x0400411B RID: 16667
	public HenshinScript Henshin;

	// Token: 0x0400411C RID: 16668
	public YandereScript Yandere;

	// Token: 0x0400411D RID: 16669
	public GameObject Rainey;

	// Token: 0x0400411E RID: 16670
	public string[] MedibangLetters;

	// Token: 0x0400411F RID: 16671
	public string[] MiyukiLetters;

	// Token: 0x04004120 RID: 16672
	public string[] NurseLetters;

	// Token: 0x04004121 RID: 16673
	public string[] AzurLane;

	// Token: 0x04004122 RID: 16674
	public string[] Letter;

	// Token: 0x04004123 RID: 16675
	public int MedibangID;

	// Token: 0x04004124 RID: 16676
	public int MiyukiID;

	// Token: 0x04004125 RID: 16677
	public int NurseID;

	// Token: 0x04004126 RID: 16678
	public int AzurID;

	// Token: 0x04004127 RID: 16679
	public int ID;

	// Token: 0x04004128 RID: 16680
	public Mesh ThiccMesh;

	// Token: 0x04004129 RID: 16681
	public bool TransformNurse;
}
