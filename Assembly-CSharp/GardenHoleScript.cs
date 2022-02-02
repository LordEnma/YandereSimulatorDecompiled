using System;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class GardenHoleScript : MonoBehaviour
{
	// Token: 0x060014BB RID: 5307 RVA: 0x000CC108 File Offset: 0x000CA308
	private void Start()
	{
		if (SchoolGlobals.GetGardenGraveOccupied(this.ID))
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x060014BC RID: 5308 RVA: 0x000CC138 File Offset: 0x000CA338
	private void Update()
	{
		if (this.Yandere.transform.position.z < base.transform.position.z - 0.5f)
		{
			if (this.Yandere.Equipped > 0)
			{
				if (this.Yandere.EquippedWeapon.WeaponID == 10)
				{
					this.Prompt.enabled = true;
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				foreach (string name in this.Yandere.ArmedAnims)
				{
					this.Yandere.CharacterAnimation[name].weight = 0f;
				}
				this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z) - this.Yandere.transform.position);
				this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DigSpot.eulerAngles;
				this.Yandere.RPGCamera.transform.position = this.Yandere.DigSpot.position;
				this.Yandere.EquippedWeapon.gameObject.SetActive(false);
				this.Yandere.CharacterAnimation["f02_shovelBury_00"].time = 0f;
				this.Yandere.CharacterAnimation["f02_shovelDig_00"].time = 0f;
				this.Yandere.FloatingShovel.SetActive(true);
				this.Yandere.RPGCamera.enabled = false;
				this.Yandere.CanMove = false;
				this.Yandere.DigPhase = 1;
				this.Carrots.SetActive(false);
				this.Prompt.Circle[0].fillAmount = 1f;
				if (!this.Dug)
				{
					this.Yandere.FloatingShovel.GetComponent<Animation>()["Dig"].time = 0f;
					this.Yandere.FloatingShovel.GetComponent<Animation>().Play("Dig");
					this.Yandere.Character.GetComponent<Animation>().Play("f02_shovelDig_00");
					this.Yandere.Digging = true;
					this.Prompt.Label[0].text = "     Fill";
					this.MyCollider.isTrigger = true;
					this.MyMesh.mesh = this.HoleMesh;
					this.Pile.SetActive(true);
					this.Dug = true;
				}
				else
				{
					this.Yandere.FloatingShovel.GetComponent<Animation>()["Bury"].time = 0f;
					this.Yandere.FloatingShovel.GetComponent<Animation>().Play("Bury");
					this.Yandere.CharacterAnimation.Play("f02_shovelBury_00");
					this.Yandere.Burying = true;
					this.Prompt.Label[0].text = "     Dig";
					this.MyCollider.isTrigger = false;
					this.MyMesh.mesh = this.MoundMesh;
					this.Pile.SetActive(false);
					this.Dug = false;
				}
				if (this.Bury)
				{
					this.Yandere.Police.Corpses--;
					if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
					{
						this.Yandere.Police.MurderScene = false;
					}
					if (this.Yandere.Police.Corpses == 0)
					{
						this.Yandere.Police.MurderScene = false;
					}
					this.VictimID = this.Corpse.StudentID;
					this.Corpse.Remove();
					if (this.Corpse.StudentID == this.Yandere.StudentManager.RivalID)
					{
						Debug.Log("Just buried Osana's corpse.");
						this.Yandere.Police.EndOfDay.RivalBuried = true;
					}
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					base.enabled = false;
					this.Prompt.Yandere.StudentManager.UpdateStudents(0);
				}
			}
		}
	}

	// Token: 0x060014BD RID: 5309 RVA: 0x000CC66C File Offset: 0x000CA86C
	private void OnTriggerEnter(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     Bury";
			this.Corpse = other.transform.root.gameObject.GetComponent<RagdollScript>();
			this.Bury = true;
		}
	}

	// Token: 0x060014BE RID: 5310 RVA: 0x000CC6C9 File Offset: 0x000CA8C9
	private void OnTriggerExit(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     Fill";
			this.Corpse = null;
			this.Bury = false;
		}
	}

	// Token: 0x060014BF RID: 5311 RVA: 0x000CC707 File Offset: 0x000CA907
	public void EndOfDayCheck()
	{
		if (this.VictimID > 0)
		{
			StudentGlobals.SetStudentMissing(this.VictimID, true);
			SchoolGlobals.SetGardenGraveOccupied(this.ID, true);
		}
	}

	// Token: 0x04002093 RID: 8339
	public YandereScript Yandere;

	// Token: 0x04002094 RID: 8340
	public RagdollScript Corpse;

	// Token: 0x04002095 RID: 8341
	public PromptScript Prompt;

	// Token: 0x04002096 RID: 8342
	public Collider MyCollider;

	// Token: 0x04002097 RID: 8343
	public MeshFilter MyMesh;

	// Token: 0x04002098 RID: 8344
	public GameObject Carrots;

	// Token: 0x04002099 RID: 8345
	public GameObject Pile;

	// Token: 0x0400209A RID: 8346
	public Mesh MoundMesh;

	// Token: 0x0400209B RID: 8347
	public Mesh HoleMesh;

	// Token: 0x0400209C RID: 8348
	public bool Bury;

	// Token: 0x0400209D RID: 8349
	public bool Dug;

	// Token: 0x0400209E RID: 8350
	public int VictimID;

	// Token: 0x0400209F RID: 8351
	public int ID;
}
