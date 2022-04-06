using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class WoodChipperScript : MonoBehaviour
{
	// Token: 0x0600200D RID: 8205 RVA: 0x001C6F1F File Offset: 0x001C511F
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600200E RID: 8206 RVA: 0x001C6F30 File Offset: 0x001C5130
	private void Update()
	{
		if (!this.Acid)
		{
			if (this.Yandere.PickUp != null)
			{
				if (this.Yandere.PickUp.Bucket != null)
				{
					if (!this.Yandere.PickUp.Bucket.Full)
					{
						if (this.Bucket == null)
						{
							this.BucketPrompt.HideButton[0] = false;
							if (this.BucketPrompt.Circle[0].fillAmount == 0f)
							{
								this.Bucket = this.Yandere.PickUp;
								this.Yandere.EmptyHands();
								this.Bucket.transform.eulerAngles = this.BucketPoint.eulerAngles;
								this.Bucket.transform.position = this.BucketPoint.position;
								this.Bucket.MyRigidbody.useGravity = false;
								this.Bucket.MyCollider.enabled = false;
							}
						}
						else
						{
							this.BucketPrompt.HideButton[0] = true;
						}
					}
					else
					{
						this.BucketPrompt.HideButton[0] = true;
					}
				}
				else
				{
					this.BucketPrompt.HideButton[0] = true;
				}
			}
			else
			{
				this.BucketPrompt.HideButton[0] = true;
			}
			if (!this.BloodSpray.isPlaying)
			{
				if (!this.Occupied)
				{
					if (this.Yandere.Ragdoll == null)
					{
						this.Prompt.HideButton[3] = true;
					}
					else
					{
						this.Prompt.HideButton[3] = false;
					}
				}
				else if (this.Bucket == null)
				{
					this.Prompt.HideButton[0] = true;
				}
				else if (this.Bucket.Bucket.Full)
				{
					this.Prompt.HideButton[0] = true;
				}
				else
				{
					this.Prompt.HideButton[0] = false;
				}
			}
		}
		else
		{
			if (this.Yandere.Ragdoll == null)
			{
				this.Prompt.HideButton[3] = true;
			}
			else
			{
				this.Prompt.HideButton[3] = false;
			}
			if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Evidence) || (this.Yandere.PickUp != null && this.Yandere.PickUp.Evidence) || (this.Yandere.PickUp != null && this.Yandere.PickUp.ConcealedBodyPart))
			{
				this.Prompt.HideButton[1] = false;
			}
			else
			{
				this.Prompt.HideButton[1] = true;
			}
		}
		if (!this.Open)
		{
			this.Rotation = Mathf.MoveTowards(this.Rotation, 0f, Time.deltaTime * 360f);
			if (this.Rotation > -36f)
			{
				if (this.Rotation < 0f)
				{
					this.MyAudio.clip = this.CloseAudio;
					this.MyAudio.Play();
				}
				this.Rotation = 0f;
			}
			this.Lid.transform.localEulerAngles = new Vector3(this.Rotation, this.Lid.transform.localEulerAngles.y, this.Lid.transform.localEulerAngles.z);
		}
		else
		{
			if (this.Lid.transform.localEulerAngles.x == 0f)
			{
				this.MyAudio.clip = this.OpenAudio;
				this.MyAudio.Play();
			}
			this.Rotation = Mathf.MoveTowards(this.Rotation, -90f, Time.deltaTime * 360f);
			this.Lid.transform.localEulerAngles = new Vector3(this.Rotation, this.Lid.transform.localEulerAngles.y, this.Lid.transform.localEulerAngles.z);
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			Debug.Log("As of now, Yandere-chan's ''Woodchipper'' is being set to: " + base.gameObject.name);
			this.Yandere.WoodChipper = this;
			Time.timeScale = 1f;
			if (this.Yandere.Ragdoll != null)
			{
				if (!this.Yandere.Carrying)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_dragIdle_00");
				}
				else
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_carryIdleA_00");
				}
				this.Yandere.YandereVision = false;
				this.Yandere.Chipping = true;
				this.Yandere.CanMove = false;
				this.Victims++;
				this.VictimList[this.Victims] = this.Yandere.Ragdoll.GetComponent<RagdollScript>().StudentID;
				this.Open = true;
				bool acid = this.Acid;
			}
		}
		if (this.Acid && this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			if (this.Yandere.Armed)
			{
				Component equippedWeapon = this.Yandere.EquippedWeapon;
				this.Yandere.EmptyHands();
				this.Yandere.Police.BloodyWeapons--;
				UnityEngine.Object.Destroy(equippedWeapon.gameObject);
			}
			else
			{
				PickUpScript pickUp = this.Yandere.PickUp;
				this.Yandere.EmptyHands();
				if (pickUp.Clothing)
				{
					this.Yandere.Police.BloodyClothing--;
				}
				if (pickUp.ConcealedBodyPart)
				{
					this.Yandere.Police.BodyParts--;
				}
				UnityEngine.Object.Destroy(pickUp.gameObject);
			}
			this.MyAudio.clip = this.ShredAudio;
			this.MyAudio.Play();
		}
		if ((this.Acid && this.Occupied && this.VictimID > 0) || this.Prompt.Circle[0].fillAmount == 0f)
		{
			Debug.Log(base.gameObject.name + " is now disposing of a corpse.");
			if (!this.Acid)
			{
				this.MyAudio.clip = this.ShredAudio;
				this.MyAudio.Play();
				this.Prompt.HideButton[3] = false;
				this.Prompt.HideButton[0] = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			this.Yandere.Police.HiddenCorpses -= this.HiddenCorpses;
			this.Yandere.Police.Corpses--;
			if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
			{
				this.Yandere.Police.MurderScene = false;
			}
			if (this.Yandere.Police.Corpses == 0)
			{
				this.Yandere.Police.MurderScene = false;
			}
			Debug.Log("The Student ID of the victim is: " + this.VictimID.ToString());
			if (this.Yandere.StudentManager == null)
			{
				Debug.Log("StudentManager is null?!");
			}
			if (this.Yandere.StudentManager.Students[this.VictimID] == null)
			{
				Debug.Log("Student #" + this.VictimID.ToString() + " is null?!");
			}
			if (this.Yandere.StudentManager.Students[this.VictimID].Drowned)
			{
				this.Yandere.Police.DrownVictims--;
			}
			if (!this.Acid)
			{
				this.Shredding = true;
			}
			else
			{
				this.Occupied = false;
			}
			this.Yandere.StudentManager.Students[this.VictimID].Ragdoll.Disposed = true;
			if (this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID] != null && this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID].Ragdoll.Disposed)
			{
				Debug.Log("Just shredded or dissolved the current rival's corpse.");
				this.Yandere.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
			}
			this.Yandere.StudentManager.UpdateStudents(0);
			this.HiddenCorpses = 0;
			this.VictimID = 0;
		}
		if (this.Shredding)
		{
			if (this.Bucket != null)
			{
				this.Bucket.Bucket.UpdateAppearance = true;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer >= 10f)
			{
				this.Prompt.enabled = true;
				this.Shredding = false;
				this.Occupied = false;
				this.Timer = 0f;
				return;
			}
			if (this.Timer >= 9f)
			{
				if (this.Bucket != null)
				{
					this.Bucket.MyCollider.enabled = true;
					this.Bucket.Bucket.FillSpeed = 1f;
					this.Bucket = null;
					this.BloodSpray.Stop();
					return;
				}
			}
			else if (this.Timer >= 0.33333f && this.Bucket != null && !this.Bucket.Bucket.Full)
			{
				this.BloodSpray.GetComponent<AudioSource>().Play();
				this.BloodSpray.Play();
				this.Bucket.Bucket.Bloodiness = 100f;
				this.Bucket.Bucket.FillSpeed = 0.066666f;
				this.Bucket.Bucket.Blood.material.color = new Color(1f, 1f, 1f, 1f);
				this.Bucket.Bucket.Blood.gameObject.SetActive(true);
				this.Bucket.Bucket.UpdateAppearance = true;
				this.Bucket.Bucket.Full = true;
			}
		}
	}

	// Token: 0x0600200F RID: 8207 RVA: 0x001C799C File Offset: 0x001C5B9C
	public void SetVictimsMissing()
	{
		int[] victimList = this.VictimList;
		for (int i = 0; i < victimList.Length; i++)
		{
			StudentGlobals.SetStudentMissing(victimList[i], true);
		}
	}

	// Token: 0x04004377 RID: 17271
	public ParticleSystem BloodSpray;

	// Token: 0x04004378 RID: 17272
	public PromptScript BucketPrompt;

	// Token: 0x04004379 RID: 17273
	public YandereScript Yandere;

	// Token: 0x0400437A RID: 17274
	public PickUpScript Bucket;

	// Token: 0x0400437B RID: 17275
	public PromptScript Prompt;

	// Token: 0x0400437C RID: 17276
	public AudioClip CloseAudio;

	// Token: 0x0400437D RID: 17277
	public AudioClip ShredAudio;

	// Token: 0x0400437E RID: 17278
	public AudioClip OpenAudio;

	// Token: 0x0400437F RID: 17279
	public Transform BucketPoint;

	// Token: 0x04004380 RID: 17280
	public Transform DumpPoint;

	// Token: 0x04004381 RID: 17281
	public Transform Lid;

	// Token: 0x04004382 RID: 17282
	public float Rotation;

	// Token: 0x04004383 RID: 17283
	public float Timer;

	// Token: 0x04004384 RID: 17284
	public bool Shredding;

	// Token: 0x04004385 RID: 17285
	public bool Occupied;

	// Token: 0x04004386 RID: 17286
	public bool Acid;

	// Token: 0x04004387 RID: 17287
	public bool Open;

	// Token: 0x04004388 RID: 17288
	public int HiddenCorpses;

	// Token: 0x04004389 RID: 17289
	public int VictimID;

	// Token: 0x0400438A RID: 17290
	public int Victims;

	// Token: 0x0400438B RID: 17291
	public int ID;

	// Token: 0x0400438C RID: 17292
	public int[] VictimList;

	// Token: 0x0400438D RID: 17293
	public AudioSource MyAudio;
}
