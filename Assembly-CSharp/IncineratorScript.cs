using System;
using UnityEngine;

// Token: 0x02000335 RID: 821
public class IncineratorScript : MonoBehaviour
{
	// Token: 0x060018F3 RID: 6387 RVA: 0x000F621C File Offset: 0x000F441C
	private void Start()
	{
		this.Panel.SetActive(false);
		this.Prompt.enabled = true;
		if (!GameGlobals.Eighties && DateGlobals.Week == 2)
		{
			this.OutOfOrderSign.SetActive(true);
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			base.enabled = false;
		}
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x060018F4 RID: 6388 RVA: 0x000F6288 File Offset: 0x000F4488
	private void Update()
	{
		if (this.Animate)
		{
			if (this.Open)
			{
				if (this.RightDoor.transform.localEulerAngles.y == 0f)
				{
					this.MyAudio.clip = this.IncineratorOpen;
					this.MyAudio.Play();
				}
				this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 5f), this.RightDoor.transform.localEulerAngles.z);
				this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 5f), this.LeftDoor.transform.localEulerAngles.z);
				if (this.RightDoor.transform.localEulerAngles.y > 134f)
				{
					this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, 135f, this.RightDoor.transform.localEulerAngles.z);
				}
			}
			else
			{
				this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, Mathf.MoveTowards(this.RightDoor.transform.localEulerAngles.y, 0f, Time.deltaTime * 360f), this.RightDoor.transform.localEulerAngles.z);
				this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, Mathf.MoveTowards(this.LeftDoor.transform.localEulerAngles.y, 0f, Time.deltaTime * 360f), this.LeftDoor.transform.localEulerAngles.z);
				if (this.RightDoor.transform.localEulerAngles.y < 1f)
				{
					this.MyAudio.clip = this.IncineratorClose;
					this.MyAudio.Play();
					this.Animate = false;
					this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, 0f, this.RightDoor.transform.localEulerAngles.z);
					this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, 0f, this.LeftDoor.transform.localEulerAngles.z);
				}
			}
		}
		if (this.OpenTimer > 0f)
		{
			this.OpenTimer -= Time.deltaTime;
			if (this.OpenTimer <= 1f)
			{
				this.Open = false;
			}
			if (this.OpenTimer <= 0f)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (!this.Smoke.isPlaying)
		{
			this.YandereHoldingEvidence = (this.Yandere.Ragdoll != null);
			if (!this.YandereHoldingEvidence)
			{
				if (this.Yandere.PickUp != null)
				{
					this.YandereHoldingEvidence = (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Garbage);
				}
				else
				{
					this.YandereHoldingEvidence = false;
				}
			}
			if (!this.YandereHoldingEvidence)
			{
				if (this.Yandere.EquippedWeapon != null)
				{
					this.YandereHoldingEvidence = this.Yandere.EquippedWeapon.MurderWeapon;
				}
				else
				{
					this.YandereHoldingEvidence = false;
				}
			}
			if (!this.YandereHoldingEvidence)
			{
				if (!this.Prompt.HideButton[3])
				{
					this.Prompt.HideButton[3] = true;
				}
			}
			else if (this.Prompt.HideButton[3])
			{
				this.Prompt.HideButton[3] = false;
			}
			if ((this.Yandere.Chased || this.Yandere.Chasers > 0 || !this.YandereHoldingEvidence) && !this.Prompt.HideButton[3])
			{
				this.Prompt.HideButton[3] = true;
			}
			if (this.Ready)
			{
				if (!this.Smoke.isPlaying)
				{
					if (this.CannotIncinerate)
					{
						this.Prompt.HideButton[0] = true;
					}
					if (!this.CannotIncinerate && this.Prompt.HideButton[0])
					{
						this.Prompt.HideButton[0] = false;
					}
				}
				else if (!this.Prompt.HideButton[0])
				{
					this.Prompt.HideButton[0] = true;
				}
			}
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			Time.timeScale = 1f;
			if (this.Yandere.Ragdoll != null)
			{
				if (this.Yandere.Dragging)
				{
					this.Yandere.NotificationManager.CustomText = "Must be carrying, not dragging.";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					RagdollScript component = this.Yandere.Ragdoll.GetComponent<RagdollScript>();
					this.Yandere.CharacterAnimation.CrossFade(this.Yandere.Carrying ? "f02_carryIdleA_00" : "f02_dragIdle_00");
					this.Yandere.Incinerator = this;
					this.Yandere.YandereVision = false;
					this.Yandere.CanMove = false;
					this.Yandere.Dumping = true;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Victims++;
					this.VictimList[this.Victims] = component.StudentID;
					this.Open = true;
				}
			}
			if (this.Yandere.PickUp != null)
			{
				Debug.Log("The " + this.Yandere.PickUp.gameObject.name + " that Yandere-chan was carrying is now being dumped into the incinerator.");
				if (this.Yandere.PickUp.BodyPart != null)
				{
					this.Limbs++;
					this.LimbList[this.Limbs] = this.Yandere.PickUp.GetComponent<BodyPartScript>().StudentID;
				}
				this.Yandere.PickUp.Incinerator = this;
				this.Yandere.PickUp.Dumped = true;
				this.Yandere.PickUp.Drop();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.OpenTimer = 2f;
				this.Ready = true;
				this.Open = true;
			}
			WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
			if (equippedWeapon != null)
			{
				this.DestroyedEvidence++;
				this.EvidenceList[this.DestroyedEvidence] = equippedWeapon.WeaponID;
				equippedWeapon.Incinerator = this;
				equippedWeapon.Dumped = true;
				equippedWeapon.Drop();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.OpenTimer = 2f;
				this.Ready = true;
				this.Open = true;
			}
			this.Animate = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			int num = 0;
			this.ID = 1;
			while (this.ID < this.Limbs + 1)
			{
				if (this.LimbList[this.ID] == this.Yandere.StudentManager.RivalID)
				{
					num++;
					if (num == 6)
					{
						this.Yandere.StudentManager.Police.EndOfDay.RivalDismemberedAndIncinerated = true;
						Debug.Log("The player dismembered and incinerated Osana.");
					}
				}
				this.ID++;
			}
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Panel.SetActive(true);
			this.Timer = 60f;
			this.MyAudio.clip = this.IncineratorActivate;
			this.MyAudio.Play();
			this.Flames.Play();
			this.Smoke.Play();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			Debug.Log("Incinerating " + this.BloodyClothing.ToString() + " bloody clothing.");
			this.Yandere.Police.IncineratedWeapons += this.MurderWeapons;
			this.Yandere.Police.BloodyClothing -= this.BloodyClothing;
			this.Yandere.Police.MurderWeapons -= this.MurderWeapons;
			this.Yandere.Police.BloodyWeapons -= this.BloodyWeapons;
			this.Yandere.Police.HiddenCorpses -= this.HiddenCorpses;
			this.Yandere.Police.BodyParts -= this.BodyParts;
			this.Yandere.Police.Corpses -= this.Corpses;
			this.Yandere.Police.RedPaintClothing -= this.ClothingWithRedPaint;
			if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
			{
				this.Yandere.Police.MurderScene = false;
			}
			if (this.Yandere.Police.Corpses == 0)
			{
				this.Yandere.Police.MurderScene = false;
			}
			this.BloodyClothing = 0;
			this.HiddenCorpses = 0;
			this.MurderWeapons = 0;
			this.BodyParts = 0;
			this.Corpses = 0;
			this.ID = 0;
			while (this.ID < 101)
			{
				if (this.Yandere.StudentManager.Students[this.CorpseList[this.ID]] != null)
				{
					this.Yandere.StudentManager.Students[this.CorpseList[this.ID]].Ragdoll.Disposed = true;
					this.ConfirmedDead[this.ID] = this.CorpseList[this.ID];
					if (this.Yandere.StudentManager.Students[this.CorpseList[this.ID]].Ragdoll.Drowned)
					{
						this.Yandere.Police.DrownVictims--;
					}
				}
				this.ID++;
			}
			if (this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID] != null && this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID].Ragdoll.Disposed)
			{
				Debug.Log("Just incinerated Osana's corpse.");
				this.Yandere.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
			}
			this.Yandere.StudentManager.UpdateStudents(0);
		}
		if (this.Smoke.isPlaying)
		{
			this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
			this.FlameSound.volume += Time.deltaTime;
			this.Circle.fillAmount = 1f - this.Timer / 60f;
			if (this.Timer <= 0f)
			{
				this.Prompt.HideButton[0] = true;
				this.Prompt.enabled = true;
				this.Panel.SetActive(false);
				this.Ready = false;
				this.Flames.Stop();
				this.Smoke.Stop();
			}
		}
		else
		{
			this.FlameSound.volume -= Time.deltaTime;
		}
		if (this.Panel.activeInHierarchy)
		{
			float num2 = (float)Mathf.CeilToInt(this.Timer * 60f);
			float num3 = Mathf.Floor(num2 / 60f);
			float num4 = (float)Mathf.RoundToInt(num2 % 60f);
			this.TimeLabel.text = string.Format("{0:00}:{1:00}", num3, num4);
		}
	}

	// Token: 0x060018F5 RID: 6389 RVA: 0x000F6F6C File Offset: 0x000F516C
	public void SetVictimsMissing()
	{
		foreach (int num in this.ConfirmedDead)
		{
			if (num > 0)
			{
				Debug.Log("Student #" + num.ToString() + " was incinerated and is now considered ''missing'.");
				StudentGlobals.SetStudentMissing(num, true);
			}
		}
	}

	// Token: 0x060018F6 RID: 6390 RVA: 0x000F6FB8 File Offset: 0x000F51B8
	public void DumpGarbageBag(PickUpScript PickUp)
	{
		Debug.Log("A garbage bag was dumped into the incinerator!");
		this.Limbs++;
		this.LimbList[this.Limbs] = PickUp.GetComponent<BodyPartScript>().StudentID;
		PickUp.Incinerator = this;
		PickUp.Dumped = true;
		PickUp.Drop();
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.OpenTimer = 2f;
		this.Animate = true;
		this.Ready = true;
		this.Open = true;
	}

	// Token: 0x0400263D RID: 9789
	public YandereScript Yandere;

	// Token: 0x0400263E RID: 9790
	public PromptScript Prompt;

	// Token: 0x0400263F RID: 9791
	public ClockScript Clock;

	// Token: 0x04002640 RID: 9792
	public AudioClip IncineratorActivate;

	// Token: 0x04002641 RID: 9793
	public AudioClip IncineratorClose;

	// Token: 0x04002642 RID: 9794
	public AudioClip IncineratorOpen;

	// Token: 0x04002643 RID: 9795
	public AudioSource FlameSound;

	// Token: 0x04002644 RID: 9796
	public AudioSource MyAudio;

	// Token: 0x04002645 RID: 9797
	public ParticleSystem Flames;

	// Token: 0x04002646 RID: 9798
	public ParticleSystem Smoke;

	// Token: 0x04002647 RID: 9799
	public Transform DumpPoint;

	// Token: 0x04002648 RID: 9800
	public Transform RightDoor;

	// Token: 0x04002649 RID: 9801
	public Transform LeftDoor;

	// Token: 0x0400264A RID: 9802
	public GameObject OutOfOrderSign;

	// Token: 0x0400264B RID: 9803
	public GameObject Panel;

	// Token: 0x0400264C RID: 9804
	public UILabel TimeLabel;

	// Token: 0x0400264D RID: 9805
	public UISprite Circle;

	// Token: 0x0400264E RID: 9806
	public bool YandereHoldingEvidence;

	// Token: 0x0400264F RID: 9807
	public bool ActivateAfterClosing;

	// Token: 0x04002650 RID: 9808
	public bool CannotIncinerate;

	// Token: 0x04002651 RID: 9809
	public bool Animate;

	// Token: 0x04002652 RID: 9810
	public bool Ready;

	// Token: 0x04002653 RID: 9811
	public bool Open;

	// Token: 0x04002654 RID: 9812
	public int ClothingWithRedPaint;

	// Token: 0x04002655 RID: 9813
	public int DestroyedEvidence;

	// Token: 0x04002656 RID: 9814
	public int BloodyClothing;

	// Token: 0x04002657 RID: 9815
	public int BloodyWeapons;

	// Token: 0x04002658 RID: 9816
	public int HiddenCorpses;

	// Token: 0x04002659 RID: 9817
	public int MurderWeapons;

	// Token: 0x0400265A RID: 9818
	public int BodyParts;

	// Token: 0x0400265B RID: 9819
	public int Corpses;

	// Token: 0x0400265C RID: 9820
	public int Victims;

	// Token: 0x0400265D RID: 9821
	public int Limbs;

	// Token: 0x0400265E RID: 9822
	public int ID;

	// Token: 0x0400265F RID: 9823
	public float OpenTimer;

	// Token: 0x04002660 RID: 9824
	public float Timer;

	// Token: 0x04002661 RID: 9825
	public int[] EvidenceList;

	// Token: 0x04002662 RID: 9826
	public int[] CorpseList;

	// Token: 0x04002663 RID: 9827
	public int[] VictimList;

	// Token: 0x04002664 RID: 9828
	public int[] LimbList;

	// Token: 0x04002665 RID: 9829
	public int[] ConfirmedDead;
}
