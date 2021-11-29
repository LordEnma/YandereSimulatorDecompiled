using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001ED3 RID: 7891 RVA: 0x001B04B0 File Offset: 0x001AE6B0
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		if (GameGlobals.Eighties)
		{
			this.TransformNurse = true;
		}
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001ED4 RID: 7892 RVA: 0x001B0504 File Offset: 0x001AE704
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

	// Token: 0x04003FFB RID: 16379
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x04003FFC RID: 16380
	public StudentManagerScript StudentManager;

	// Token: 0x04003FFD RID: 16381
	public HenshinScript Henshin;

	// Token: 0x04003FFE RID: 16382
	public YandereScript Yandere;

	// Token: 0x04003FFF RID: 16383
	public GameObject Rainey;

	// Token: 0x04004000 RID: 16384
	public string[] MedibangLetters;

	// Token: 0x04004001 RID: 16385
	public string[] MiyukiLetters;

	// Token: 0x04004002 RID: 16386
	public string[] NurseLetters;

	// Token: 0x04004003 RID: 16387
	public string[] AzurLane;

	// Token: 0x04004004 RID: 16388
	public string[] Letter;

	// Token: 0x04004005 RID: 16389
	public int MedibangID;

	// Token: 0x04004006 RID: 16390
	public int MiyukiID;

	// Token: 0x04004007 RID: 16391
	public int NurseID;

	// Token: 0x04004008 RID: 16392
	public int AzurID;

	// Token: 0x04004009 RID: 16393
	public int ID;

	// Token: 0x0400400A RID: 16394
	public Mesh ThiccMesh;

	// Token: 0x0400400B RID: 16395
	public bool TransformNurse;
}
