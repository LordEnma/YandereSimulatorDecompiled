using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FamilyVoiceScript : MonoBehaviour
{
	// Token: 0x0600147E RID: 5246 RVA: 0x000C7B16 File Offset: 0x000C5D16
	private void Start()
	{
		this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x0600147F RID: 5247 RVA: 0x000C7B3C File Offset: 0x000C5D3C
	private void Update()
	{
		if (!this.GameOver)
		{
			if (this.Investigating)
			{
				this.LookForYandere();
				base.transform.parent.position = Vector3.MoveTowards(base.transform.parent.position, this.Node[this.CurrentNode].position, Time.deltaTime);
				if (this.FixTimer == 0f || this.FixTimer == 5f)
				{
					Quaternion b = Quaternion.LookRotation(this.Node[this.CurrentNode].position - base.transform.parent.position);
					base.transform.parent.rotation = Quaternion.Slerp(base.transform.parent.rotation, b, Time.deltaTime * 10f);
				}
				if (Vector3.Distance(base.transform.parent.position, this.Node[this.CurrentNode].position) < 0.1f)
				{
					if (this.CurrentNode == this.Node.Length - 1)
					{
						this.Return = true;
					}
					if (!this.Return)
					{
						this.CurrentNode++;
						if (this.CurrentNode == 3)
						{
							AudioSource.PlayClipAtPoint(this.DoorOpen, this.Door.transform.position);
							this.OpenFrontDoor = true;
						}
					}
					else if (this.FixTimer == 5f)
					{
						this.BreakerDoor.Label.text = "Open";
						this.BreakerDoor.Open = false;
						this.MyAnimation.CrossFade("walkConfident_00");
						this.CurrentNode--;
						if (this.CurrentNode == 1)
						{
							AudioSource.PlayClipAtPoint(this.DoorOpen, this.Door.transform.position);
							this.OpenFrontDoor = false;
						}
						if (this.CurrentNode < 0)
						{
							this.MyAnimation.CrossFade("fatherFixing_00");
							this.BreakerDoor.ServedPurpose = false;
							this.Investigating = false;
							this.Return = false;
							this.CurrentNode = 1;
							this.FixTimer = 0f;
						}
					}
					else
					{
						this.FixTimer = Mathf.MoveTowards(this.FixTimer, 5f, Time.deltaTime);
						if (this.FixTimer >= 4f && !this.Lights.activeInHierarchy)
						{
							AudioSource.PlayClipAtPoint(this.PowerOn, Camera.main.transform.position);
							this.Lights.SetActive(true);
						}
						this.MyAnimation.CrossFade("rummage_00");
					}
				}
				if (this.OpenFrontDoor)
				{
					this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 3.6f);
				}
				else
				{
					this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 3.6f);
				}
				this.Door.transform.localEulerAngles = new Vector3(this.Door.transform.localEulerAngles.x, this.Rotation, this.Door.transform.localEulerAngles.z);
				return;
			}
			if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
			{
				this.Distance = Vector3.Distance(this.Yandere.transform.position, base.transform.position);
				if (this.Distance < this.MinimumDistance)
				{
					if (!this.Started)
					{
						this.Subtitle.text = this.SpeechText[0];
						this.MyAudio.Play();
						this.Started = true;
					}
					else
					{
						this.MyAudio.pitch = Time.timeScale;
						if (this.MultiClip)
						{
							if (this.MyAnimation["fatherFixing_00"].time > this.MyAnimation["fatherFixing_00"].length)
							{
								this.MyAnimation["fatherFixing_00"].time = this.MyAnimation["fatherFixing_00"].time - this.MyAnimation["fatherFixing_00"].length;
							}
							if (this.AnimPhase == 0)
							{
								if (this.MyAnimation["fatherFixing_00"].time > 18f && this.MyAnimation["fatherFixing_00"].time < 18.1f)
								{
									this.Subtitle.text = this.SpeechText[this.SpeechPhase];
									this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
									this.MyAudio.Play();
									this.SpeechPhase++;
									this.AnimPhase = 1;
								}
							}
							else if (this.MyAnimation["fatherFixing_00"].time < 1f)
							{
								this.Subtitle.text = this.SpeechText[this.SpeechPhase];
								this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
								this.MyAudio.Play();
								this.SpeechPhase++;
								this.AnimPhase = 0;
							}
						}
						else if (this.SpeechPhase < this.SpeechTime.Length && this.MyAudio.time > this.SpeechTime[this.SpeechPhase])
						{
							this.Subtitle.text = this.SpeechText[this.SpeechPhase];
							this.SpeechPhase++;
						}
						this.Scale = Mathf.Abs(1f - (this.Distance - 1f) / (this.MinimumDistance - 1f));
						if (this.Scale < 0f)
						{
							this.Scale = 0f;
						}
						if (this.Scale > 1f)
						{
							this.Scale = 1f;
						}
						this.Jukebox.volume = 1f - 0.9f * this.Scale;
						this.Subtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
						this.MyAudio.volume = this.Scale;
					}
					for (int i = 0; i < this.Boundary.Length; i++)
					{
						Transform transform = this.Boundary[i];
						if (transform != null && Vector3.Distance(this.Yandere.transform.position, transform.position) < 0.33333f)
						{
							Debug.Log("Got a ''proximity'' game over from " + base.gameObject.name);
							AudioSource.PlayClipAtPoint(this.CrunchSound, Camera.main.transform.position);
							this.TransitionToGameOver();
						}
					}
					this.LookForYandere();
				}
				else if (this.Distance < this.MinimumDistance + 1f)
				{
					this.Jukebox.volume = 1f;
					this.MyAudio.volume = 0f;
					this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
				}
			}
			if (this.Node.Length != 0)
			{
				Quaternion b2 = Quaternion.LookRotation(new Vector3(5.4f, 0f, -100f) - base.transform.parent.position);
				base.transform.parent.rotation = Quaternion.Slerp(base.transform.parent.rotation, b2, Time.deltaTime * 10f);
				return;
			}
		}
		else if (this.GameOverPhase == 0)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f && !this.MyAudio.isPlaying)
			{
				Debug.Log("Should be updating the subtitle with the Game Over text.");
				this.Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				this.Subtitle.text = (this.GameOverText ?? "");
				this.MyAudio.clip = this.GameOverLine;
				this.MyAudio.Play();
				this.GameOverPhase++;
				return;
			}
		}
		else if (!this.MyAudio.isPlaying || Input.GetButton("A"))
		{
			this.Heartbroken.SetActive(true);
			this.Subtitle.text = "";
			base.enabled = false;
			this.MyAudio.Stop();
		}
	}

	// Token: 0x06001480 RID: 5248 RVA: 0x000C8414 File Offset: 0x000C6614
	private bool YandereIsInFOV()
	{
		Vector3 to = this.Yandere.transform.position - this.Head.position;
		float num = 90f;
		return Vector3.Angle(this.Head.forward, to) <= num;
	}

	// Token: 0x06001481 RID: 5249 RVA: 0x000C8460 File Offset: 0x000C6660
	private bool YandereIsInLOS()
	{
		Debug.DrawLine(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), Color.red);
		RaycastHit raycastHit;
		return Physics.Linecast(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject.layer == 13;
	}

	// Token: 0x06001482 RID: 5250 RVA: 0x000C852C File Offset: 0x000C672C
	private void TransitionToGameOver()
	{
		this.Marker.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		this.Marker.Tex.color = new Color(1f, 0f, 0f, 0f);
		this.Darkness.material.color = new Color(0f, 0f, 0f, 1f);
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.CanMove = false;
		this.Subtitle.text = "";
		this.GameOver = true;
		this.Jukebox.Stop();
		this.MyAudio.Stop();
		this.Alpha = 0f;
	}

	// Token: 0x06001483 RID: 5251 RVA: 0x000C860C File Offset: 0x000C680C
	private void LookForYandere()
	{
		if (this.Yandere.Hidden && this.Yandere.Stance.Current == StanceType.Crouching)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * this.NoticeSpeed);
		}
		else
		{
			if (this.YandereIsInFOV())
			{
				if (this.YandereIsInLOS())
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * this.NoticeSpeed);
				}
				else
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * this.NoticeSpeed);
				}
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * this.NoticeSpeed);
			}
			if (this.Investigating && Vector3.Distance(this.Yandere.transform.position, base.transform.parent.position) < 1f)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * this.NoticeSpeed * 2f);
			}
		}
		if (this.Alpha == 1f)
		{
			Debug.Log("Got a ''witnessed'' game over from " + base.gameObject.name);
			AudioSource.PlayClipAtPoint(this.GameOverSound, Camera.main.transform.position);
			this.TransitionToGameOver();
		}
		this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
		this.Marker.Tex.color = new Color(1f, 0f, 0f, this.Alpha);
	}

	// Token: 0x04001FAF RID: 8111
	public StalkerPromptScript BreakerDoor;

	// Token: 0x04001FB0 RID: 8112
	public StalkerYandereScript Yandere;

	// Token: 0x04001FB1 RID: 8113
	public DetectionMarkerScript Marker;

	// Token: 0x04001FB2 RID: 8114
	public AudioClip GameOverSound;

	// Token: 0x04001FB3 RID: 8115
	public AudioClip GameOverLine;

	// Token: 0x04001FB4 RID: 8116
	public AudioClip CrunchSound;

	// Token: 0x04001FB5 RID: 8117
	public GameObject Heartbroken;

	// Token: 0x04001FB6 RID: 8118
	public GameObject Lights;

	// Token: 0x04001FB7 RID: 8119
	public Animation MyAnimation;

	// Token: 0x04001FB8 RID: 8120
	public Transform YandereHead;

	// Token: 0x04001FB9 RID: 8121
	public Transform Door;

	// Token: 0x04001FBA RID: 8122
	public Transform Head;

	// Token: 0x04001FBB RID: 8123
	public AudioSource Jukebox;

	// Token: 0x04001FBC RID: 8124
	public AudioSource MyAudio;

	// Token: 0x04001FBD RID: 8125
	public Renderer Darkness;

	// Token: 0x04001FBE RID: 8126
	public UILabel Subtitle;

	// Token: 0x04001FBF RID: 8127
	public AudioClip[] SpeechClip;

	// Token: 0x04001FC0 RID: 8128
	public AudioClip DoorOpen;

	// Token: 0x04001FC1 RID: 8129
	public AudioClip PowerOn;

	// Token: 0x04001FC2 RID: 8130
	public Transform[] Boundary;

	// Token: 0x04001FC3 RID: 8131
	public Transform[] Node;

	// Token: 0x04001FC4 RID: 8132
	public string[] SpeechText;

	// Token: 0x04001FC5 RID: 8133
	public float[] SpeechTime;

	// Token: 0x04001FC6 RID: 8134
	public string GameOverText;

	// Token: 0x04001FC7 RID: 8135
	public float MinimumDistance;

	// Token: 0x04001FC8 RID: 8136
	public float NoticeSpeed;

	// Token: 0x04001FC9 RID: 8137
	public float Distance;

	// Token: 0x04001FCA RID: 8138
	public float FixTimer;

	// Token: 0x04001FCB RID: 8139
	public float Alpha;

	// Token: 0x04001FCC RID: 8140
	public float Scale;

	// Token: 0x04001FCD RID: 8141
	public float Timer;

	// Token: 0x04001FCE RID: 8142
	public float TargetRotation;

	// Token: 0x04001FCF RID: 8143
	public float Rotation;

	// Token: 0x04001FD0 RID: 8144
	public int GameOverPhase;

	// Token: 0x04001FD1 RID: 8145
	public int CurrentNode;

	// Token: 0x04001FD2 RID: 8146
	public int SpeechPhase;

	// Token: 0x04001FD3 RID: 8147
	public int AnimPhase;

	// Token: 0x04001FD4 RID: 8148
	public bool Investigating;

	// Token: 0x04001FD5 RID: 8149
	public bool OpenFrontDoor;

	// Token: 0x04001FD6 RID: 8150
	public bool MultiClip;

	// Token: 0x04001FD7 RID: 8151
	public bool GameOver;

	// Token: 0x04001FD8 RID: 8152
	public bool Started;

	// Token: 0x04001FD9 RID: 8153
	public bool Return;
}
