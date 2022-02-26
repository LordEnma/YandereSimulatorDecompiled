using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MovingEventScript : MonoBehaviour
{
	// Token: 0x060019C7 RID: 6599 RVA: 0x00107B7A File Offset: 0x00105D7A
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == this.EventDay)
		{
			this.EventCheck = true;
		}
	}

	// Token: 0x060019C8 RID: 6600 RVA: 0x00107BA8 File Offset: 0x00105DA8
	private void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck && this.Clock.HourTime > 13f)
		{
			this.EventStudent = this.StudentManager.Students[30];
			if (this.EventStudent != null)
			{
				this.EventStudent.Character.GetComponent<Animation>()[this.EventStudent.BentoAnim].weight = 1f;
				this.EventStudent.CurrentDestination = this.EventLocation[0];
				this.EventStudent.Pathfinding.target = this.EventLocation[0];
				this.EventStudent.SmartPhone.SetActive(false);
				this.EventStudent.Scrubber.SetActive(false);
				this.EventStudent.Bento.SetActive(true);
				this.EventStudent.Pen.SetActive(false);
				this.EventStudent.MovingEvent = this;
				this.EventStudent.InEvent = true;
				this.EventStudent.Private = true;
				this.EventCheck = false;
				this.EventActive = true;
			}
		}
		if (this.EventActive)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Poisoned = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if ((this.Clock.HourTime > 13.375f && !this.Poisoned) || this.EventStudent.Dying || this.EventStudent.Splashed || this.EventStudent.Dodging)
			{
				this.EndEvent();
				return;
			}
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
			if (!this.EventStudent.Alarmed && this.EventStudent.DistanceToDestination < this.EventStudent.TargetDistance && !this.EventStudent.Pathfinding.canMove)
			{
				if (this.EventPhase == 0)
				{
					this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.IdleAnim);
					if (this.Clock.HourTime > 13.05f)
					{
						this.EventStudent.CurrentDestination = this.EventLocation[1];
						this.EventStudent.Pathfinding.target = this.EventLocation[1];
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 1)
				{
					if (!this.StudentManager.Students[1].WitnessedCorpse)
					{
						if (this.Timer == 0f)
						{
							AudioClipPlayer.Play(this.EventClip[1], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
							this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.IdleAnim);
							if (this.Distance < 10f)
							{
								this.EventSubtitle.text = this.EventSpeech[1];
							}
							this.EventStudent.Prompt.Hide();
							this.EventStudent.Prompt.enabled = false;
						}
						this.Timer += Time.deltaTime;
						if (this.Timer > 2f)
						{
							this.EventStudent.CurrentDestination = this.EventLocation[2];
							this.EventStudent.Pathfinding.target = this.EventLocation[2];
							if (this.Distance < 10f)
							{
								this.EventSubtitle.text = string.Empty;
							}
							this.EventPhase++;
							this.Timer = 0f;
						}
					}
					else
					{
						this.EventPhase = 7;
						this.Timer = 3f;
					}
				}
				else if (this.EventPhase == 2)
				{
					Animation component = this.EventStudent.Character.GetComponent<Animation>();
					component[this.EventStudent.BentoAnim].weight -= Time.deltaTime;
					if (this.Timer == 0f)
					{
						component.CrossFade("f02_bentoPlace_00");
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f && this.EventStudent.Bento.transform.parent != null)
					{
						this.EventStudent.Bento.transform.parent = null;
						this.EventStudent.Bento.transform.position = new Vector3(8f, 0.5f, -2.2965f);
						this.EventStudent.Bento.transform.eulerAngles = new Vector3(0f, 0f, 0f);
						this.EventStudent.Bento.transform.localScale = new Vector3(1.4f, 1.5f, 1.4f);
					}
					if (this.Timer > 2f)
					{
						if (this.Yandere.Inventory.ChemicalPoison || this.Yandere.Inventory.LethalPoison)
						{
							this.Prompt.HideButton[0] = false;
						}
						this.EventStudent.CurrentDestination = this.EventLocation[3];
						this.EventStudent.Pathfinding.target = this.EventLocation[3];
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 3)
				{
					AudioClipPlayer.Play(this.EventClip[2], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
					this.EventStudent.Character.GetComponent<Animation>().CrossFade("f02_cornerPeek_00");
					if (this.Distance < 10f)
					{
						this.EventSubtitle.text = this.EventSpeech[2];
					}
					this.EventPhase++;
				}
				else if (this.EventPhase == 4)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 5.5f)
					{
						AudioClipPlayer.Play(this.EventClip[3], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
						if (this.Distance < 10f)
						{
							this.EventSubtitle.text = this.EventSpeech[3];
						}
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 5)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 5.5f)
					{
						AudioClipPlayer.Play(this.EventClip[4], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
						if (this.Distance < 10f)
						{
							this.EventSubtitle.text = this.EventSpeech[4];
						}
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 6)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 3f)
					{
						this.EventStudent.CurrentDestination = this.EventLocation[2];
						this.EventStudent.Pathfinding.target = this.EventLocation[2];
						if (this.Distance < 10f)
						{
							this.EventSubtitle.text = string.Empty;
						}
						this.EventPhase++;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 7)
				{
					if (this.Timer == 0f)
					{
						Animation component2 = this.EventStudent.Character.GetComponent<Animation>();
						component2["f02_bentoPlace_00"].time = component2["f02_bentoPlace_00"].length;
						component2["f02_bentoPlace_00"].speed = -1f;
						component2.CrossFade("f02_bentoPlace_00");
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f && this.EventStudent.Bento.transform.parent == null)
					{
						this.EventStudent.Bento.transform.parent = this.EventStudent.LeftHand;
						this.EventStudent.Bento.transform.localPosition = new Vector3(0f, -0.0906f, -0.032f);
						this.EventStudent.Bento.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
						this.EventStudent.Bento.transform.localScale = new Vector3(1.4f, 1.5f, 1.4f);
					}
					if (this.Timer > 2f)
					{
						this.EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
						this.EventStudent.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
						this.EventStudent.CurrentDestination = this.EventLocation[4];
						this.EventStudent.Pathfinding.target = this.EventLocation[4];
						this.EventStudent.Prompt.Hide();
						this.EventStudent.Prompt.enabled = false;
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 8)
				{
					Animation component3 = this.EventStudent.Character.GetComponent<Animation>();
					if (!this.Poisoned)
					{
						component3[this.EventStudent.BentoAnim].weight = 0f;
						component3.CrossFade(this.EventStudent.EatAnim);
						if (!this.EventStudent.Chopsticks[0].activeInHierarchy)
						{
							this.EventStudent.Chopsticks[0].SetActive(true);
							this.EventStudent.Chopsticks[1].SetActive(true);
						}
					}
					else
					{
						component3.CrossFade("f02_poisonDeath_00");
						this.Timer += Time.deltaTime;
						if (this.Timer < 13.55f)
						{
							if (!this.EventStudent.Chopsticks[0].activeInHierarchy)
							{
								AudioClipPlayer.Play(this.EventClip[5], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip);
								this.EventStudent.Chopsticks[0].SetActive(true);
								this.EventStudent.Chopsticks[1].SetActive(true);
								this.EventStudent.Distracted = true;
							}
						}
						else if (this.Timer < 16.33333f)
						{
							if (this.EventStudent.Chopsticks[0].transform.parent != this.EventStudent.Bento.transform)
							{
								this.EventStudent.Chopsticks[0].transform.parent = this.EventStudent.Bento.transform;
								this.EventStudent.Chopsticks[1].transform.parent = this.EventStudent.Bento.transform;
							}
							this.EventStudent.EyeShrink += Time.deltaTime;
							if (this.EventStudent.EyeShrink > 0.9f)
							{
								this.EventStudent.EyeShrink = 0.9f;
							}
						}
						else if (this.EventStudent.Bento.transform.parent != null)
						{
							this.EventStudent.Bento.transform.parent = null;
							this.EventStudent.Bento.GetComponent<Collider>().isTrigger = false;
							this.EventStudent.Bento.AddComponent<Rigidbody>();
							Rigidbody component4 = this.EventStudent.Bento.GetComponent<Rigidbody>();
							component4.AddRelativeForce(Vector3.up * 100f);
							component4.AddRelativeForce(Vector3.left * 100f);
							component4.AddRelativeForce(Vector3.forward * -100f);
						}
						if (component3["f02_poisonDeath_00"].time > component3["f02_poisonDeath_00"].length)
						{
							this.EventStudent.Ragdoll.Poisoned = true;
							this.EventStudent.BecomeRagdoll();
							this.Yandere.Police.PoisonScene = true;
							this.EventOver = true;
							this.EndEvent();
						}
					}
				}
				if (this.Distance < 11f)
				{
					if (this.Distance < 10f)
					{
						float num = Mathf.Abs((this.Distance - 10f) * 0.2f);
						if (num < 0f)
						{
							num = 0f;
						}
						if (num > 1f)
						{
							num = 1f;
						}
						this.EventSubtitle.transform.localScale = new Vector3(num, num, num);
						return;
					}
					this.EventSubtitle.transform.localScale = Vector3.zero;
				}
			}
		}
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x001089B8 File Offset: 0x00106BB8
	private void EndEvent()
	{
		if (!this.EventOver)
		{
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Character.GetComponent<Animation>()[this.EventStudent.BentoAnim].weight = 0f;
			this.EventStudent.Chopsticks[0].SetActive(false);
			this.EventStudent.Chopsticks[1].SetActive(false);
			this.EventStudent.Bento.SetActive(false);
			this.EventStudent.Prompt.enabled = true;
			this.EventStudent.MovingEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents(0);
		}
		this.EventActive = false;
		this.EventCheck = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x04002946 RID: 10566
	public StudentManagerScript StudentManager;

	// Token: 0x04002947 RID: 10567
	public UILabel EventSubtitle;

	// Token: 0x04002948 RID: 10568
	public YandereScript Yandere;

	// Token: 0x04002949 RID: 10569
	public PortalScript Portal;

	// Token: 0x0400294A RID: 10570
	public PromptScript Prompt;

	// Token: 0x0400294B RID: 10571
	public ClockScript Clock;

	// Token: 0x0400294C RID: 10572
	public StudentScript EventStudent;

	// Token: 0x0400294D RID: 10573
	public Transform[] EventLocation;

	// Token: 0x0400294E RID: 10574
	public AudioClip[] EventClip;

	// Token: 0x0400294F RID: 10575
	public string[] EventSpeech;

	// Token: 0x04002950 RID: 10576
	public string[] EventAnim;

	// Token: 0x04002951 RID: 10577
	public Collider BenchCollider;

	// Token: 0x04002952 RID: 10578
	public GameObject VoiceClip;

	// Token: 0x04002953 RID: 10579
	public bool EventActive;

	// Token: 0x04002954 RID: 10580
	public bool EventCheck;

	// Token: 0x04002955 RID: 10581
	public bool EventOver;

	// Token: 0x04002956 RID: 10582
	public bool Poisoned;

	// Token: 0x04002957 RID: 10583
	public int EventPhase = 1;

	// Token: 0x04002958 RID: 10584
	public DayOfWeek EventDay = DayOfWeek.Wednesday;

	// Token: 0x04002959 RID: 10585
	public float Distance;

	// Token: 0x0400295A RID: 10586
	public float Timer;
}
