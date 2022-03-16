using System;
using UnityEngine;

// Token: 0x0200037C RID: 892
public class NoteLockerScript : MonoBehaviour
{
	// Token: 0x06001A16 RID: 6678 RVA: 0x00111B04 File Offset: 0x0010FD04
	private void Update()
	{
		if (this.Student != null)
		{
			Vector3 b = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
			if (this.Prompt.enabled)
			{
				if (Vector3.Distance(this.Student.transform.position, b) < 1f || this.Yandere.Armed)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.CanLeaveNote && Vector3.Distance(this.Student.transform.position, b) > 1f && !this.Yandere.Armed)
			{
				this.Prompt.enabled = true;
			}
		}
		else
		{
			this.Student = this.StudentManager.Students[this.LockerOwner];
		}
		if (this.Prompt != null && this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.NoteWindow.NoteLocker = this;
			this.Yandere.Blur.enabled = true;
			this.NoteWindow.gameObject.SetActive(true);
			this.Yandere.CanMove = false;
			this.NoteWindow.Show = true;
			this.Yandere.HUD.alpha = 0f;
			this.PromptBar.Show = true;
			Time.timeScale = 0.0001f;
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.Label[1].text = "Cancel";
			this.PromptBar.Label[4].text = "Select";
			this.PromptBar.UpdateButtons();
		}
		if (this.NoteLeft)
		{
			if (this.Student != null)
			{
				if ((this.Student.Routine && this.Student.Phase < 3) || (this.Student.Routine && this.Student.Phase == 8) || this.Student.SentToLocker)
				{
					if (Vector3.Distance(base.transform.position, this.Student.transform.position) < 1.5f && !this.Student.InEvent)
					{
						this.Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						if (!this.Success)
						{
							this.Student.CharacterAnimation.CrossFade(this.Student.TossNoteAnim);
						}
						else
						{
							this.Student.CharacterAnimation.CrossFade(this.Student.KeepNoteAnim);
						}
						this.Student.Pathfinding.canSearch = false;
						this.Student.Pathfinding.canMove = false;
						this.Student.CheckingNote = true;
						this.Student.Routine = false;
						this.Student.InEvent = true;
						this.CheckingNote = true;
					}
				}
				else if (!this.Student.CheckingNote && this.Student.InEvent && !this.Informed)
				{
					Debug.Log("The locker owner's ''InEvent'' boolean is true...");
					if (this.Student.Rival && Vector3.Distance(base.transform.position, this.Student.transform.position) < 1.5f)
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "Tell her about the note when she's not busy.";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						this.Prompt.Yandere.NotificationManager.CustomText = "Something else is on her mind right now.";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						this.Prompt.Yandere.NotificationManager.CustomText = "She didn't notice the note in her locker.";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						this.Informed = true;
					}
				}
			}
			if (this.CheckingNote)
			{
				if (this.Timer == 0f)
				{
					this.Student.Follower != null;
					this.Phase = 1;
				}
				this.Timer += Time.deltaTime;
				this.Student.MoveTowardsTarget(this.Student.MyLocker.position);
				this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, this.Student.MyLocker.rotation, 10f * Time.deltaTime);
				if (this.Student != null)
				{
					if (this.Student.CharacterAnimation[this.Student.TossNoteAnim].time >= this.Student.CharacterAnimation[this.Student.TossNoteAnim].length)
					{
						this.Finish();
					}
					if (this.Student.CharacterAnimation[this.Student.KeepNoteAnim].time >= this.Student.CharacterAnimation[this.Student.KeepNoteAnim].length)
					{
						this.DetermineSchedule();
						this.Finish();
					}
				}
				if (this.Timer > 3.5f && !this.SpawnedNote)
				{
					this.NewNote = UnityEngine.Object.Instantiate<GameObject>(this.Note, base.transform.position, Quaternion.identity);
					this.NewNote.transform.parent = this.Student.LeftHand;
					if (this.Student.Male)
					{
						this.NewNote.transform.localPosition = new Vector3(-0.133333f, -0.03f, 0.0133333f);
					}
					else
					{
						this.NewNote.transform.localPosition = new Vector3(-0.06f, -0.01f, 0f);
					}
					this.NewNote.transform.localEulerAngles = new Vector3(-75f, -90f, 180f);
					this.NewNote.transform.localScale = new Vector3(0.1f, 0.2f, 1f);
					this.SpawnedNote = true;
				}
				if (!this.Success)
				{
					if (this.Timer > 10f && this.NewNote != null)
					{
						if (this.NewNote.transform.localScale.z > 0.1f)
						{
							this.NewNote.transform.localScale = Vector3.MoveTowards(this.NewNote.transform.localScale, Vector3.zero, Time.deltaTime * 2f);
						}
						else
						{
							UnityEngine.Object.Destroy(this.NewNote);
						}
					}
					if (this.Timer > 12.25f && this.NewBall == null)
					{
						this.NewBall = UnityEngine.Object.Instantiate<GameObject>(this.Ball, this.Student.LeftHand.position, Quaternion.identity);
						Rigidbody component = this.NewBall.GetComponent<Rigidbody>();
						component.AddRelativeForce(this.Student.transform.forward * -100f);
						component.AddRelativeForce(Vector3.up * 100f);
						this.Phase++;
					}
				}
				else if (this.Timer > 12.5f && this.NewNote != null)
				{
					if (this.NewNote.transform.localScale.z > 0.1f)
					{
						this.NewNote.transform.localScale = Vector3.MoveTowards(this.NewNote.transform.localScale, Vector3.zero, Time.deltaTime * 2f);
					}
					else
					{
						UnityEngine.Object.Destroy(this.NewNote);
					}
				}
				if (this.Phase == 1)
				{
					if (this.Timer > 2.3333333f)
					{
						if (!this.Student.Male)
						{
							this.Yandere.Subtitle.Speaker = this.Student;
							this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 1, 3f);
						}
						else
						{
							this.Yandere.Subtitle.Speaker = this.Student;
							this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 1, 3f);
						}
						this.Phase++;
						return;
					}
				}
				else if (this.Phase == 2)
				{
					if (!this.Success)
					{
						if (this.Timer > 9.666667f)
						{
							if (!this.Student.Male)
							{
								this.Yandere.Subtitle.Speaker = this.Student;
								this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 2, 3f);
							}
							else
							{
								this.Yandere.Subtitle.Speaker = this.Student;
								this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 2, 3f);
							}
							this.Phase++;
							return;
						}
					}
					else if (this.Timer > 10.166667f)
					{
						if (!this.Student.Male)
						{
							this.Yandere.Subtitle.Speaker = this.Student;
							this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 3, 3f);
						}
						else
						{
							this.Yandere.Subtitle.Speaker = this.Student;
							this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 3, 3f);
						}
						this.Phase++;
					}
				}
			}
		}
	}

	// Token: 0x06001A17 RID: 6679 RVA: 0x001124E8 File Offset: 0x001106E8
	private void Finish()
	{
		if (this.Success)
		{
			if (this.Student.Clock.HourTime > this.Student.MeetTime)
			{
				this.Student.CurrentDestination = this.Student.MeetSpot;
				this.Student.Pathfinding.target = this.Student.MeetSpot;
				this.Student.Meeting = true;
				this.Student.MeetTime = 0f;
			}
			else
			{
				this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
				this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
			}
			this.Student.Pathfinding.canSearch = true;
			this.Student.Pathfinding.canMove = true;
			this.Student.Pathfinding.speed = 1f;
		}
		else
		{
			Debug.Log(this.Student.Name + " has rejected the note, and is being told to travel to the destination of their current phase.");
			this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
			this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
			this.FindStudentLocker.Prompt.Label[0].text = "     Find Student Locker";
			this.FindStudentLocker.TargetedStudent = null;
			this.FindStudentLocker.Prompt.enabled = true;
			this.FindStudentLocker.Phase = 1;
			this.Student.CanTalk = true;
		}
		Animation component = this.Student.Character.GetComponent<Animation>();
		component.cullingType = AnimationCullingType.BasedOnRenderers;
		component.CrossFade(this.Student.IdleAnim);
		this.Student.DistanceToDestination = 100f;
		this.Student.CheckingNote = false;
		this.Student.SentToLocker = false;
		this.Student.InEvent = false;
		this.Student.Routine = true;
		this.CheckingNote = false;
		this.NoteLeft = false;
		this.Phase++;
		this.NewBall = null;
		this.Timer = 0f;
		this.Student.Follower != null;
	}

	// Token: 0x06001A18 RID: 6680 RVA: 0x0011274C File Offset: 0x0011094C
	private void DetermineSchedule()
	{
		this.Student.MeetSpot = this.MeetSpots.List[this.MeetID];
		this.Student.MeetTime = this.MeetTime;
	}

	// Token: 0x04002A63 RID: 10851
	public FindStudentLockerScript FindStudentLocker;

	// Token: 0x04002A64 RID: 10852
	public StudentManagerScript StudentManager;

	// Token: 0x04002A65 RID: 10853
	public NoteWindowScript NoteWindow;

	// Token: 0x04002A66 RID: 10854
	public PromptBarScript PromptBar;

	// Token: 0x04002A67 RID: 10855
	public StudentScript Student;

	// Token: 0x04002A68 RID: 10856
	public YandereScript Yandere;

	// Token: 0x04002A69 RID: 10857
	public ListScript MeetSpots;

	// Token: 0x04002A6A RID: 10858
	public PromptScript Prompt;

	// Token: 0x04002A6B RID: 10859
	public GameObject NewBall;

	// Token: 0x04002A6C RID: 10860
	public GameObject NewNote;

	// Token: 0x04002A6D RID: 10861
	public GameObject Locker;

	// Token: 0x04002A6E RID: 10862
	public GameObject Ball;

	// Token: 0x04002A6F RID: 10863
	public GameObject Note;

	// Token: 0x04002A70 RID: 10864
	public AudioClip NoteSuccess;

	// Token: 0x04002A71 RID: 10865
	public AudioClip NoteFail;

	// Token: 0x04002A72 RID: 10866
	public AudioClip NoteFind;

	// Token: 0x04002A73 RID: 10867
	public bool CheckingNote;

	// Token: 0x04002A74 RID: 10868
	public bool CanLeaveNote = true;

	// Token: 0x04002A75 RID: 10869
	public bool SpawnedNote;

	// Token: 0x04002A76 RID: 10870
	public bool Informed;

	// Token: 0x04002A77 RID: 10871
	public bool NoteLeft;

	// Token: 0x04002A78 RID: 10872
	public bool Success;

	// Token: 0x04002A79 RID: 10873
	public float MeetTime;

	// Token: 0x04002A7A RID: 10874
	public float Timer;

	// Token: 0x04002A7B RID: 10875
	public int LockerOwner;

	// Token: 0x04002A7C RID: 10876
	public int MeetID;

	// Token: 0x04002A7D RID: 10877
	public int Phase = 1;
}
