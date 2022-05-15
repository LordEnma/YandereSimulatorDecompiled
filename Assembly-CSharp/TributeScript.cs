using System;
using UnityEngine;

// Token: 0x02000490 RID: 1168
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001F43 RID: 8003 RVA: 0x001BB0C3 File Offset: 0x001B92C3
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001F44 RID: 8004 RVA: 0x001BB104 File Offset: 0x001B9304
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

	// Token: 0x0400414D RID: 16717
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x0400414E RID: 16718
	public StudentManagerScript StudentManager;

	// Token: 0x0400414F RID: 16719
	public HenshinScript Henshin;

	// Token: 0x04004150 RID: 16720
	public YandereScript Yandere;

	// Token: 0x04004151 RID: 16721
	public GameObject Rainey;

	// Token: 0x04004152 RID: 16722
	public string[] MedibangLetters;

	// Token: 0x04004153 RID: 16723
	public string[] MiyukiLetters;

	// Token: 0x04004154 RID: 16724
	public string[] NurseLetters;

	// Token: 0x04004155 RID: 16725
	public string[] AzurLane;

	// Token: 0x04004156 RID: 16726
	public string[] Letter;

	// Token: 0x04004157 RID: 16727
	public int MedibangID;

	// Token: 0x04004158 RID: 16728
	public int MiyukiID;

	// Token: 0x04004159 RID: 16729
	public int NurseID;

	// Token: 0x0400415A RID: 16730
	public int AzurID;

	// Token: 0x0400415B RID: 16731
	public int ID;

	// Token: 0x0400415C RID: 16732
	public Mesh ThiccMesh;

	// Token: 0x0400415D RID: 16733
	public bool TransformNurse;
}
