using System;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class TributeScript : MonoBehaviour
{
	// Token: 0x06001F19 RID: 7961 RVA: 0x001B6673 File Offset: 0x001B4873
	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		bool eighties = GameGlobals.Eighties;
		this.Rainey.SetActive(false);
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B66B4 File Offset: 0x001B48B4
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

	// Token: 0x040040D9 RID: 16601
	public RiggedAccessoryAttacher RiggedAttacher;

	// Token: 0x040040DA RID: 16602
	public StudentManagerScript StudentManager;

	// Token: 0x040040DB RID: 16603
	public HenshinScript Henshin;

	// Token: 0x040040DC RID: 16604
	public YandereScript Yandere;

	// Token: 0x040040DD RID: 16605
	public GameObject Rainey;

	// Token: 0x040040DE RID: 16606
	public string[] MedibangLetters;

	// Token: 0x040040DF RID: 16607
	public string[] MiyukiLetters;

	// Token: 0x040040E0 RID: 16608
	public string[] NurseLetters;

	// Token: 0x040040E1 RID: 16609
	public string[] AzurLane;

	// Token: 0x040040E2 RID: 16610
	public string[] Letter;

	// Token: 0x040040E3 RID: 16611
	public int MedibangID;

	// Token: 0x040040E4 RID: 16612
	public int MiyukiID;

	// Token: 0x040040E5 RID: 16613
	public int NurseID;

	// Token: 0x040040E6 RID: 16614
	public int AzurID;

	// Token: 0x040040E7 RID: 16615
	public int ID;

	// Token: 0x040040E8 RID: 16616
	public Mesh ThiccMesh;

	// Token: 0x040040E9 RID: 16617
	public bool TransformNurse;
}
