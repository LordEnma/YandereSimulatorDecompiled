using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001F07 RID: 7943 RVA: 0x001B4EF3 File Offset: 0x001B30F3
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001F08 RID: 7944 RVA: 0x001B4F34 File Offset: 0x001B3134
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

	// Token: 0x0400408E RID: 16526
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x0400408F RID: 16527
	public StudentManagerScript StudentManager;

	// Token: 0x04004090 RID: 16528
	public HenshinScript Henshin;

	// Token: 0x04004091 RID: 16529
	public YandereScript Yandere;

	// Token: 0x04004092 RID: 16530
	public GameObject Rainey;

	// Token: 0x04004093 RID: 16531
	public string[] MedibangLetters;

	// Token: 0x04004094 RID: 16532
	public string[] MiyukiLetters;

	// Token: 0x04004095 RID: 16533
	public string[] NurseLetters;

	// Token: 0x04004096 RID: 16534
	public string[] AzurLane;

	// Token: 0x04004097 RID: 16535
	public string[] Letter;

	// Token: 0x04004098 RID: 16536
	public int MedibangID;

	// Token: 0x04004099 RID: 16537
	public int MiyukiID;

	// Token: 0x0400409A RID: 16538
	public int NurseID;

	// Token: 0x0400409B RID: 16539
	public int AzurID;

	// Token: 0x0400409C RID: 16540
	public int ID;

	// Token: 0x0400409D RID: 16541
	public Mesh ThiccMesh;

	// Token: 0x0400409E RID: 16542
	public bool TransformNurse;
}
