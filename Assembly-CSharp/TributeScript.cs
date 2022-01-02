using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001EE0 RID: 7904 RVA: 0x001B1757 File Offset: 0x001AF957
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001EE1 RID: 7905 RVA: 0x001B1798 File Offset: 0x001AF998
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

	// Token: 0x04004032 RID: 16434
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x04004033 RID: 16435
	public StudentManagerScript StudentManager;

	// Token: 0x04004034 RID: 16436
	public HenshinScript Henshin;

	// Token: 0x04004035 RID: 16437
	public YandereScript Yandere;

	// Token: 0x04004036 RID: 16438
	public GameObject Rainey;

	// Token: 0x04004037 RID: 16439
	public string[] MedibangLetters;

	// Token: 0x04004038 RID: 16440
	public string[] MiyukiLetters;

	// Token: 0x04004039 RID: 16441
	public string[] NurseLetters;

	// Token: 0x0400403A RID: 16442
	public string[] AzurLane;

	// Token: 0x0400403B RID: 16443
	public string[] Letter;

	// Token: 0x0400403C RID: 16444
	public int MedibangID;

	// Token: 0x0400403D RID: 16445
	public int MiyukiID;

	// Token: 0x0400403E RID: 16446
	public int NurseID;

	// Token: 0x0400403F RID: 16447
	public int AzurID;

	// Token: 0x04004040 RID: 16448
	public int ID;

	// Token: 0x04004041 RID: 16449
	public Mesh ThiccMesh;

	// Token: 0x04004042 RID: 16450
	public bool TransformNurse;
}
