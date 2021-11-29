using System;
using UnityEngine;

// Token: 0x020004BA RID: 1210
public class WoodChipperScript : MonoBehaviour
{
	// Token: 0x06001FA4 RID: 8100 RVA: 0x001BDE1F File Offset: 0x001BC01F
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06001FA5 RID: 8101 RVA: 0x001BDE30 File Offset: 0x001BC030
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

	// Token: 0x06001FA6 RID: 8102 RVA: 0x001BE878 File Offset: 0x001BCA78
	public void SetVictimsMissing()
	{
		int[] victimList = this.VictimList;
		for (int i = 0; i < victimList.Length; i++)
		{
			StudentGlobals.SetStudentMissing(victimList[i], true);
		}
	}

	// Token: 0x0400423E RID: 16958
	public ParticleSystem BloodSpray;

	// Token: 0x0400423F RID: 16959
	public PromptScript BucketPrompt;

	// Token: 0x04004240 RID: 16960
	public YandereScript Yandere;

	// Token: 0x04004241 RID: 16961
	public PickUpScript Bucket;

	// Token: 0x04004242 RID: 16962
	public PromptScript Prompt;

	// Token: 0x04004243 RID: 16963
	public AudioClip CloseAudio;

	// Token: 0x04004244 RID: 16964
	public AudioClip ShredAudio;

	// Token: 0x04004245 RID: 16965
	public AudioClip OpenAudio;

	// Token: 0x04004246 RID: 16966
	public Transform BucketPoint;

	// Token: 0x04004247 RID: 16967
	public Transform DumpPoint;

	// Token: 0x04004248 RID: 16968
	public Transform Lid;

	// Token: 0x04004249 RID: 16969
	public float Rotation;

	// Token: 0x0400424A RID: 16970
	public float Timer;

	// Token: 0x0400424B RID: 16971
	public bool Shredding;

	// Token: 0x0400424C RID: 16972
	public bool Occupied;

	// Token: 0x0400424D RID: 16973
	public bool Acid;

	// Token: 0x0400424E RID: 16974
	public bool Open;

	// Token: 0x0400424F RID: 16975
	public int VictimID;

	// Token: 0x04004250 RID: 16976
	public int Victims;

	// Token: 0x04004251 RID: 16977
	public int ID;

	// Token: 0x04004252 RID: 16978
	public int[] VictimList;

	// Token: 0x04004253 RID: 16979
	public AudioSource MyAudio;
}
