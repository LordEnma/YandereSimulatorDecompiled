using System;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001F3A RID: 7994 RVA: 0x001B9E4F File Offset: 0x001B804F
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001F3B RID: 7995 RVA: 0x001B9E90 File Offset: 0x001B8090
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

	// Token: 0x0400412F RID: 16687
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x04004130 RID: 16688
	public StudentManagerScript StudentManager;

	// Token: 0x04004131 RID: 16689
	public HenshinScript Henshin;

	// Token: 0x04004132 RID: 16690
	public YandereScript Yandere;

	// Token: 0x04004133 RID: 16691
	public GameObject Rainey;

	// Token: 0x04004134 RID: 16692
	public string[] MedibangLetters;

	// Token: 0x04004135 RID: 16693
	public string[] MiyukiLetters;

	// Token: 0x04004136 RID: 16694
	public string[] NurseLetters;

	// Token: 0x04004137 RID: 16695
	public string[] AzurLane;

	// Token: 0x04004138 RID: 16696
	public string[] Letter;

	// Token: 0x04004139 RID: 16697
	public int MedibangID;

	// Token: 0x0400413A RID: 16698
	public int MiyukiID;

	// Token: 0x0400413B RID: 16699
	public int NurseID;

	// Token: 0x0400413C RID: 16700
	public int AzurID;

	// Token: 0x0400413D RID: 16701
	public int ID;

	// Token: 0x0400413E RID: 16702
	public Mesh ThiccMesh;

	// Token: 0x0400413F RID: 16703
	public bool TransformNurse;
}
