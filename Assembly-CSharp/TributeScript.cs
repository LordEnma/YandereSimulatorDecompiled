using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001F2B RID: 7979 RVA: 0x001B8107 File Offset: 0x001B6307
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001F2C RID: 7980 RVA: 0x001B8148 File Offset: 0x001B6348
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

	// Token: 0x04004109 RID: 16649
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x0400410A RID: 16650
	public StudentManagerScript StudentManager;

	// Token: 0x0400410B RID: 16651
	public HenshinScript Henshin;

	// Token: 0x0400410C RID: 16652
	public YandereScript Yandere;

	// Token: 0x0400410D RID: 16653
	public GameObject Rainey;

	// Token: 0x0400410E RID: 16654
	public string[] MedibangLetters;

	// Token: 0x0400410F RID: 16655
	public string[] MiyukiLetters;

	// Token: 0x04004110 RID: 16656
	public string[] NurseLetters;

	// Token: 0x04004111 RID: 16657
	public string[] AzurLane;

	// Token: 0x04004112 RID: 16658
	public string[] Letter;

	// Token: 0x04004113 RID: 16659
	public int MedibangID;

	// Token: 0x04004114 RID: 16660
	public int MiyukiID;

	// Token: 0x04004115 RID: 16661
	public int NurseID;

	// Token: 0x04004116 RID: 16662
	public int AzurID;

	// Token: 0x04004117 RID: 16663
	public int ID;

	// Token: 0x04004118 RID: 16664
	public Mesh ThiccMesh;

	// Token: 0x04004119 RID: 16665
	public bool TransformNurse;
}
