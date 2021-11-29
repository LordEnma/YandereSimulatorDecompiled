﻿using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
public class ManholeScript : MonoBehaviour
{
	// Token: 0x06001965 RID: 6501 RVA: 0x001015A8 File Offset: 0x000FF7A8
	private void Update()
	{
		if (!this.Open)
		{
			if (this.Prompt.Yandere.EquippedWeapon != null)
			{
				if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 19 || this.Prompt.Yandere.EquippedWeapon.WeaponID == 29)
				{
					if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 19)
					{
						this.Prompt.Text[0] = "Use Crowbar";
					}
					else
					{
						this.Prompt.Text[0] = "Use Tool";
					}
					if (this.Prompt.Circle[0].fillAmount == 0f)
					{
						this.Prompt.Text[0] = "Dump Body";
						AudioSource.PlayClipAtPoint(this.MoveCover, base.transform.position);
						this.AnimateTimer = 1f;
						this.Open = true;
					}
				}
				else
				{
					this.Prompt.Text[0] = "Need Crowbar or Manhole Tool";
				}
			}
			else
			{
				this.Prompt.Text[0] = "Need Crowbar or Manhole Tool";
			}
			this.Prompt.Label[0].text = "     " + this.Prompt.Text[0];
			return;
		}
		if (this.AnimateTimer > 0f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(34.1f, 0f, 24.1f), Time.deltaTime);
			this.AnimateTimer -= Time.deltaTime;
		}
		if (this.SewerTimer > 0f)
		{
			if (this.Corpse.Student.Hips.transform.position.y < -5f)
			{
				if (this.Corpse.Student.Hips.transform.position.y > -5f)
				{
					this.Corpse.Student.Hips.transform.position = new Vector3(this.Corpse.Student.Hips.transform.position.x, -5f, this.Corpse.Student.Hips.transform.position.z);
				}
				if (this.Corpse.AllRigidbodies[0].useGravity)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BigSewerWaterSplash, this.Corpse.Student.Hips.transform.position, Quaternion.identity).transform.eulerAngles = new Vector3(-90f, 0f, 0f);
					for (int i = 0; i < this.Corpse.AllRigidbodies.Length; i++)
					{
						this.Corpse.AllRigidbodies[i].useGravity = false;
					}
				}
				this.Corpse.AllRigidbodies[0].AddForce(new Vector3(-100f, -50f, 0f));
			}
			this.SewerTimer -= Time.deltaTime;
			if (this.SewerTimer <= 0f)
			{
				this.Prompt.Yandere.Police.Corpses--;
				this.Corpse.gameObject.SetActive(false);
				this.Corpse.Disposed = true;
				if (this.Corpse.StudentID == this.Prompt.Yandere.StudentManager.RivalID)
				{
					Debug.Log("Just dumped Osana's corpse into the sewer.");
					this.Prompt.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
				}
				this.SewerCamera.SetActive(false);
				this.Prompt.Yandere.StudentManager.UpdateStudents(0);
			}
		}
		if (this.Prompt.Yandere.Ragdoll != null)
		{
			this.Prompt.Label[0].text = "     Dump Body";
			this.Prompt.HideButton[0] = false;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Corpse = this.Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>();
				this.Prompt.Yandere.EmptyHands();
				this.Corpse.Student.Hips.transform.position = base.transform.position + new Vector3(0f, -1f, 0f);
				this.Corpse.BloodPoolSpawner.enabled = false;
				Physics.SyncTransforms();
				this.SewerCamera.SetActive(true);
				this.SewerTimer = 5f;
				return;
			}
		}
		else if ((this.Prompt.Yandere.Armed && this.Prompt.Yandere.EquippedWeapon.Evidence) || (this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.Evidence) || (this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.ConcealedBodyPart))
		{
			this.Prompt.Label[0].text = "     Dump Evidence";
			this.Prompt.HideButton[0] = false;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				if (this.Prompt.Yandere.Armed)
				{
					Component equippedWeapon = this.Prompt.Yandere.EquippedWeapon;
					this.Prompt.Yandere.EmptyHands();
					this.Prompt.Yandere.Police.BloodyWeapons--;
					UnityEngine.Object.Destroy(equippedWeapon.gameObject);
					return;
				}
				PickUpScript pickUp = this.Prompt.Yandere.PickUp;
				this.Prompt.Yandere.EmptyHands();
				if (pickUp.Clothing)
				{
					this.Prompt.Yandere.Police.BloodyClothing--;
				}
				if (pickUp.ConcealedBodyPart)
				{
					this.Prompt.Yandere.Police.BodyParts--;
				}
				UnityEngine.Object.Destroy(pickUp.gameObject);
				return;
			}
		}
		else
		{
			this.Prompt.HideButton[0] = true;
		}
	}

	// Token: 0x0400285F RID: 10335
	public GameObject BigSewerWaterSplash;

	// Token: 0x04002860 RID: 10336
	public GameObject SewerCamera;

	// Token: 0x04002861 RID: 10337
	public RagdollScript Corpse;

	// Token: 0x04002862 RID: 10338
	public PromptScript Prompt;

	// Token: 0x04002863 RID: 10339
	public AudioClip MoveCover;

	// Token: 0x04002864 RID: 10340
	public float AnimateTimer;

	// Token: 0x04002865 RID: 10341
	public float SewerTimer;

	// Token: 0x04002866 RID: 10342
	public bool Open;
}