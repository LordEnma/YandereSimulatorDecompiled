using System;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class GardenHoleScript : MonoBehaviour
{
	// Token: 0x060014C0 RID: 5312 RVA: 0x000CC340 File Offset: 0x000CA540
	private void Start()
	{
		if (SchoolGlobals.GetGardenGraveOccupied(this.ID))
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x060014C1 RID: 5313 RVA: 0x000CC370 File Offset: 0x000CA570
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

	// Token: 0x060014C2 RID: 5314 RVA: 0x000CC8A4 File Offset: 0x000CAAA4
	private void OnTriggerEnter(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     Bury";
			this.Corpse = other.transform.root.gameObject.GetComponent<RagdollScript>();
			this.Bury = true;
		}
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x000CC901 File Offset: 0x000CAB01
	private void OnTriggerExit(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     Fill";
			this.Corpse = null;
			this.Bury = false;
		}
	}

	// Token: 0x060014C4 RID: 5316 RVA: 0x000CC93F File Offset: 0x000CAB3F
	public void EndOfDayCheck()
	{
		if (this.VictimID > 0)
		{
			StudentGlobals.SetStudentMissing(this.VictimID, true);
			SchoolGlobals.SetGardenGraveOccupied(this.ID, true);
		}
	}

	// Token: 0x0400209B RID: 8347
	public YandereScript Yandere;

	// Token: 0x0400209C RID: 8348
	public RagdollScript Corpse;

	// Token: 0x0400209D RID: 8349
	public PromptScript Prompt;

	// Token: 0x0400209E RID: 8350
	public Collider MyCollider;

	// Token: 0x0400209F RID: 8351
	public MeshFilter MyMesh;

	// Token: 0x040020A0 RID: 8352
	public GameObject Carrots;

	// Token: 0x040020A1 RID: 8353
	public GameObject Pile;

	// Token: 0x040020A2 RID: 8354
	public Mesh MoundMesh;

	// Token: 0x040020A3 RID: 8355
	public Mesh HoleMesh;

	// Token: 0x040020A4 RID: 8356
	public bool Bury;

	// Token: 0x040020A5 RID: 8357
	public bool Dug;

	// Token: 0x040020A6 RID: 8358
	public int VictimID;

	// Token: 0x040020A7 RID: 8359
	public int ID;
}
