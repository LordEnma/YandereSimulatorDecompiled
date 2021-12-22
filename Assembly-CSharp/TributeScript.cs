using System;
using UnityEngine;

// Token: 0x02000482 RID: 1154
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001EDD RID: 7901 RVA: 0x001B127F File Offset: 0x001AF47F
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001EDE RID: 7902 RVA: 0x001B12C0 File Offset: 0x001AF4C0
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

	// Token: 0x0400402B RID: 16427
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x0400402C RID: 16428
	public StudentManagerScript StudentManager;

	// Token: 0x0400402D RID: 16429
	public HenshinScript Henshin;

	// Token: 0x0400402E RID: 16430
	public YandereScript Yandere;

	// Token: 0x0400402F RID: 16431
	public GameObject Rainey;

	// Token: 0x04004030 RID: 16432
	public string[] MedibangLetters;

	// Token: 0x04004031 RID: 16433
	public string[] MiyukiLetters;

	// Token: 0x04004032 RID: 16434
	public string[] NurseLetters;

	// Token: 0x04004033 RID: 16435
	public string[] AzurLane;

	// Token: 0x04004034 RID: 16436
	public string[] Letter;

	// Token: 0x04004035 RID: 16437
	public int MedibangID;

	// Token: 0x04004036 RID: 16438
	public int MiyukiID;

	// Token: 0x04004037 RID: 16439
	public int NurseID;

	// Token: 0x04004038 RID: 16440
	public int AzurID;

	// Token: 0x04004039 RID: 16441
	public int ID;

	// Token: 0x0400403A RID: 16442
	public Mesh ThiccMesh;

	// Token: 0x0400403B RID: 16443
	public bool TransformNurse;
}
