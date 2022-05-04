using System;
using UnityEngine;

// Token: 0x020003AC RID: 940
public class PickpocketScript : MonoBehaviour
{
	// Token: 0x06001AD8 RID: 6872 RVA: 0x00123C6C File Offset: 0x00121E6C
	private void Start()
	{
		if (this.Student.StudentID != 71)
		{
			this.Prompt.transform.parent.gameObject.SetActive(false);
			base.enabled = false;
			return;
		}
		this.PickpocketMinigame = this.Student.StudentManager.PickpocketMinigame;
		if (this.Student.StudentID == this.Student.StudentManager.NurseID)
		{
			this.ID = 2;
			return;
		}
		if (ClubGlobals.GetClubClosed(this.Student.OriginalClub))
		{
			this.Prompt.transform.parent.gameObject.SetActive(false);
			base.enabled = false;
			return;
		}
		this.Prompt.Label[3].text = "     Steal Shed Key";
		this.NotNurse = true;
	}

	// Token: 0x06001AD9 RID: 6873 RVA: 0x00123D3C File Offset: 0x00121F3C
	private void Update()
	{
		if (this.Prompt.transform.parent != null)
		{
			if (this.Student.Routine)
			{
				if (this.Student.DistanceToDestination > 0.5f)
				{
					if (this.Prompt.enabled)
					{
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.PickpocketPanel.enabled = false;
					}
					if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
					{
						this.Prompt.Yandere.Caught = true;
						this.PickpocketMinigame.End();
						this.Punish();
					}
				}
				else
				{
					this.PickpocketPanel.enabled = true;
					if (this.Student.Yandere.PickUp == null && this.Student.Yandere.Pursuer == null)
					{
						this.Prompt.enabled = true;
					}
					else
					{
						this.Prompt.enabled = false;
						this.Prompt.Hide();
					}
					if (this.TimeBar != null)
					{
						this.Timer += Time.deltaTime * this.Student.CharacterAnimation[this.Student.PatrolAnim].speed;
						this.TimeBar.fillAmount = 1f - this.Timer / this.Student.CharacterAnimation[this.Student.PatrolAnim].length;
						if (this.Timer > this.Student.CharacterAnimation[this.Student.PatrolAnim].length)
						{
							if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
							{
								this.Prompt.Yandere.Caught = true;
								this.PickpocketMinigame.End();
								this.Punish();
							}
							this.Timer = 0f;
						}
					}
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.PickpocketPanel.enabled = false;
				if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
				{
					this.Prompt.Yandere.Caught = true;
					this.PickpocketMinigame.End();
					this.Punish();
				}
			}
			if (this.Prompt.Circle[3].fillAmount == 0f)
			{
				this.Prompt.Circle[3].fillAmount = 1f;
				if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0)
				{
					this.PickpocketMinigame.StartingAlerts = this.Prompt.Yandere.Alerts;
					this.PickpocketMinigame.PickpocketSpot = this.PickpocketSpot;
					this.PickpocketMinigame.NotNurse = this.NotNurse;
					this.PickpocketMinigame.Show = true;
					this.PickpocketMinigame.ID = this.ID;
					this.Student.Yandere.CharacterAnimation.CrossFade("f02_pickpocketing_00");
					this.Student.Yandere.Pickpocketing = true;
					this.Student.Yandere.EmptyHands();
					this.Student.Yandere.CanMove = false;
				}
			}
			if (this.PickpocketMinigame != null && this.PickpocketMinigame.ID == this.ID)
			{
				if (this.PickpocketMinigame.Success)
				{
					this.PickpocketMinigame.Success = false;
					this.PickpocketMinigame.ID = 0;
					this.Succeed();
					this.PickpocketPanel.enabled = false;
					this.Prompt.enabled = false;
					this.Prompt.Hide();
					this.Key.SetActive(false);
					base.enabled = false;
				}
				if (this.PickpocketMinigame.Failure)
				{
					this.PickpocketMinigame.Failure = false;
					this.PickpocketMinigame.ID = 0;
					this.Punish();
				}
			}
			if (!this.Student.Alive)
			{
				base.transform.position = new Vector3(this.Student.transform.position.x, this.Student.transform.position.y + 1f, this.Student.transform.position.z);
				this.Prompt.gameObject.GetComponent<BoxCollider>().isTrigger = false;
				this.Prompt.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				this.Prompt.gameObject.GetComponent<Rigidbody>().useGravity = true;
				this.Prompt.enabled = true;
				base.transform.parent = null;
				return;
			}
		}
		else if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Succeed();
			this.Prompt.Hide();
			this.PickpocketPanel.enabled = false;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.Key.SetActive(false);
			base.enabled = false;
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001ADA RID: 6874 RVA: 0x001242C0 File Offset: 0x001224C0
	private void Punish()
	{
		Debug.Log("Punishing Yandere-chan for pickpocketing.");
		UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Student.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
		if (!this.NotNurse && !this.Prompt.Yandere.Egg)
		{
			Debug.Log("A faculty member saw pickpocketing.");
			this.Student.Witnessed = StudentWitnessType.Theft;
			this.Student.SenpaiNoticed();
			this.Student.CameraEffects.MurderWitnessed();
			this.Student.Concern = 5;
		}
		else
		{
			this.Student.Witnessed = StudentWitnessType.Pickpocketing;
			this.Student.CameraEffects.Alarm();
			this.Student.Alarm += 200f;
		}
		this.Timer = 0f;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.PickpocketPanel.enabled = false;
		this.Student.CharacterAnimation[this.Student.PatrolAnim].time = 0f;
		this.Student.PatrolTimer = 0f;
	}

	// Token: 0x06001ADB RID: 6875 RVA: 0x00124404 File Offset: 0x00122604
	private void Succeed()
	{
		if (this.ID == 1)
		{
			this.Student.StudentManager.ShedDoor.Prompt.Label[0].text = "     Open";
			this.Student.StudentManager.ShedDoor.Locked = false;
			this.Student.ClubManager.Padlock.SetActive(false);
			this.Student.Yandere.Inventory.ShedKey = true;
		}
		else
		{
			this.Student.StudentManager.CabinetDoor.Prompt.Label[0].text = "     Open";
			this.Student.StudentManager.CabinetDoor.Locked = false;
			this.Student.Yandere.Inventory.CabinetKey = true;
		}
		this.Student.Yandere.NotificationManager.CustomText = "Got the key!";
		this.Student.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
	}

	// Token: 0x04002CED RID: 11501
	public PickpocketMinigameScript PickpocketMinigame;

	// Token: 0x04002CEE RID: 11502
	public StudentScript Student;

	// Token: 0x04002CEF RID: 11503
	public PromptScript Prompt;

	// Token: 0x04002CF0 RID: 11504
	public UIPanel PickpocketPanel;

	// Token: 0x04002CF1 RID: 11505
	public UISprite TimeBar;

	// Token: 0x04002CF2 RID: 11506
	public Transform PickpocketSpot;

	// Token: 0x04002CF3 RID: 11507
	public GameObject AlarmDisc;

	// Token: 0x04002CF4 RID: 11508
	public GameObject Key;

	// Token: 0x04002CF5 RID: 11509
	public float Timer;

	// Token: 0x04002CF6 RID: 11510
	public int ID = 1;

	// Token: 0x04002CF7 RID: 11511
	public bool NotNurse;

	// Token: 0x04002CF8 RID: 11512
	public bool Test;
}
