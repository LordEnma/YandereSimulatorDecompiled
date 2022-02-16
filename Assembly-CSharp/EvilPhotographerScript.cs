using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
public class EvilPhotographerScript : MonoBehaviour
{
	// Token: 0x06001472 RID: 5234 RVA: 0x000C6CFB File Offset: 0x000C4EFB
	private void Start()
	{
		this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001473 RID: 5235 RVA: 0x000C6D24 File Offset: 0x000C4F24
	private void Update()
	{
		if (!this.GameOver)
		{
			if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
			{
				if (this.Distracted)
				{
					Quaternion b = Quaternion.LookRotation(new Vector3(this.DistractionPoint.x, base.transform.position.y, this.DistractionPoint.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
					this.DistractionTimer -= Time.deltaTime;
					if (this.DistractionTimer < 0f)
					{
						this.Distracted = false;
					}
				}
				else
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
							if (this.SpeechPhase < this.SpeechTime.Length)
							{
								this.SpeechTimer += Time.deltaTime;
								if (this.SpeechTimer > this.SpeechTime[this.SpeechPhase])
								{
									this.Subtitle.text = this.SpeechText[this.SpeechPhase];
									this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
									this.MyAudio.Play();
									this.SpeechPhase++;
									if (this.Shocked && this.SpeechPhase > 3)
									{
										this.WaitAnim = "guardCorpse_00";
										this.Node = this.PanicNode;
										this.Searching = true;
										this.Shocked = false;
									}
								}
							}
							this.Scale = Mathf.Abs(1f - (this.Distance - 5f) / this.MinimumDistance);
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
						if (this.Distance < 0.5f)
						{
							Debug.Log("Got a ''proximity'' game over from " + base.gameObject.name);
							AudioSource.PlayClipAtPoint(this.SpottedSound, Camera.main.transform.position);
							this.TransitionToGameOver();
						}
					}
					else if (this.Distance < this.MinimumDistance + 1f)
					{
						this.Jukebox.volume = 1f;
						this.MyAudio.volume = 0f;
						this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
						this.Subtitle.text = "";
					}
				}
				this.LookForYandere();
			}
			else if (this.Alpha > 0f)
			{
				this.Alpha -= Time.deltaTime;
				this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
				this.Marker.Tex.color = new Color(1f, 0f, 0f, this.Alpha);
			}
			if (this.Distracted)
			{
				this.MyAnimation.CrossFade(this.WaitAnim);
				return;
			}
			if (Vector3.Distance(base.transform.position, this.Node[this.CurrentNode].position) >= 0.1f)
			{
				if (this.ShockTimer == 0f)
				{
					if (this.Fire != null && this.Fire.activeInHierarchy)
					{
						base.transform.position = Vector3.MoveTowards(base.transform.position, this.Node[this.CurrentNode].position, Time.deltaTime * 4f);
						this.MyAnimation.CrossFade(this.RunAnim);
					}
					else
					{
						base.transform.position = Vector3.MoveTowards(base.transform.position, this.Node[this.CurrentNode].position, Time.deltaTime);
						this.MyAnimation.CrossFade(this.WalkAnim);
					}
				}
				else
				{
					this.MyAnimation.CrossFade(this.WaitAnim);
					this.ShockTimer = Mathf.MoveTowards(this.ShockTimer, 0f, Time.deltaTime);
				}
				Quaternion b2 = Quaternion.LookRotation(this.Node[this.CurrentNode].position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, Time.deltaTime * 10f);
				return;
			}
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Node[this.CurrentNode].rotation, Time.deltaTime * 10f);
			this.MyAnimation.CrossFade(this.WaitAnim);
			this.WaitTimer += Time.deltaTime;
			if (this.WaitTimer > 10f && !this.Shocked)
			{
				this.WaitTimer = 0f;
				this.CurrentNode++;
				if (this.CurrentNode >= this.Node.Length)
				{
					this.CurrentNode = 1;
				}
				if (!this.Searching && this.Fire != null && this.Fire.activeInHierarchy)
				{
					this.SpeechClip = this.ShockClip;
					this.SpeechText = this.ShockText;
					this.SpeechTime = this.ShockTime;
					this.SpeechPhase = 0;
					this.SpeechTimer = 0f;
					this.Subtitle.text = this.SpeechText[0];
					this.MyAudio.clip = this.SpeechClip[0];
					this.MyAudio.Play();
					this.WaitAnim = "scaredIdle_01";
					this.CurrentNode = 1;
					this.ShockTimer = 1f;
					this.Shocked = true;
					return;
				}
			}
		}
		else if (this.GameOverPhase == 0)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f && !this.MyAudio.isPlaying)
			{
				Debug.Log("Should be updating the subtitle with the Game Over text.");
				this.Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				if (this.Shocked)
				{
					this.Subtitle.text = this.ShockedGameOverText;
					this.MyAudio.clip = this.ShockedGameOverLine;
				}
				else
				{
					this.Subtitle.text = this.GameOverText;
					this.MyAudio.clip = this.GameOverLine;
				}
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

	// Token: 0x06001474 RID: 5236 RVA: 0x000C7540 File Offset: 0x000C5740
	private bool YandereIsInFOV()
	{
		Vector3 to = this.Yandere.transform.position - this.Head.position;
		float num = 90f;
		return Vector3.Angle(this.Head.forward, to) <= num;
	}

	// Token: 0x06001475 RID: 5237 RVA: 0x000C758C File Offset: 0x000C578C
	private bool YandereIsInLOS()
	{
		Debug.DrawLine(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), Color.red);
		RaycastHit raycastHit;
		return Physics.Linecast(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject.layer == 13;
	}

	// Token: 0x06001476 RID: 5238 RVA: 0x000C7658 File Offset: 0x000C5858
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

	// Token: 0x06001477 RID: 5239 RVA: 0x000C7738 File Offset: 0x000C5938
	private void LookForYandere()
	{
		if (!this.Yandere.Invisible)
		{
			this.NoticeSpeed = (this.MinimumDistance - this.Distance) * this.Awareness;
			if (this.YandereIsInFOV())
			{
				if (this.YandereIsInLOS())
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * this.NoticeSpeed);
				}
				else
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
				}
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
			}
			if (this.Alpha == 1f)
			{
				Debug.Log("Got a ''witnessed'' game over from " + base.gameObject.name);
				AudioSource.PlayClipAtPoint(this.GameOverSound, Camera.main.transform.position);
				this.TransitionToGameOver();
			}
			if (this.Alpha < 0f)
			{
				this.Alpha = 0f;
			}
			this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
			this.Marker.Tex.color = new Color(1f, 0f, 0f, this.Alpha);
		}
	}

	// Token: 0x04001F69 RID: 8041
	public StalkerYandereScript Yandere;

	// Token: 0x04001F6A RID: 8042
	public DetectionMarkerScript Marker;

	// Token: 0x04001F6B RID: 8043
	public AudioClip ShockedGameOverLine;

	// Token: 0x04001F6C RID: 8044
	public AudioClip GameOverSound;

	// Token: 0x04001F6D RID: 8045
	public AudioClip GameOverLine;

	// Token: 0x04001F6E RID: 8046
	public AudioClip SpottedSound;

	// Token: 0x04001F6F RID: 8047
	public GameObject Heartbroken;

	// Token: 0x04001F70 RID: 8048
	public GameObject Fire;

	// Token: 0x04001F71 RID: 8049
	public Animation MyAnimation;

	// Token: 0x04001F72 RID: 8050
	public Transform YandereHead;

	// Token: 0x04001F73 RID: 8051
	public Transform Head;

	// Token: 0x04001F74 RID: 8052
	public AudioSource Jukebox;

	// Token: 0x04001F75 RID: 8053
	public AudioSource MyAudio;

	// Token: 0x04001F76 RID: 8054
	public Renderer Darkness;

	// Token: 0x04001F77 RID: 8055
	public UILabel Subtitle;

	// Token: 0x04001F78 RID: 8056
	public Transform[] PanicNode;

	// Token: 0x04001F79 RID: 8057
	public Transform[] Node;

	// Token: 0x04001F7A RID: 8058
	public AudioClip[] SpeechClip;

	// Token: 0x04001F7B RID: 8059
	public string[] SpeechText;

	// Token: 0x04001F7C RID: 8060
	public float[] SpeechTime;

	// Token: 0x04001F7D RID: 8061
	public AudioClip[] ShockClip;

	// Token: 0x04001F7E RID: 8062
	public string[] ShockText;

	// Token: 0x04001F7F RID: 8063
	public float[] ShockTime;

	// Token: 0x04001F80 RID: 8064
	public string ShockedGameOverText;

	// Token: 0x04001F81 RID: 8065
	public string GameOverText;

	// Token: 0x04001F82 RID: 8066
	public string WaitAnim;

	// Token: 0x04001F83 RID: 8067
	public string WalkAnim;

	// Token: 0x04001F84 RID: 8068
	public string RunAnim;

	// Token: 0x04001F85 RID: 8069
	public float MinimumDistance;

	// Token: 0x04001F86 RID: 8070
	public float SpeechTimer;

	// Token: 0x04001F87 RID: 8071
	public float NoticeSpeed;

	// Token: 0x04001F88 RID: 8072
	public float ShockTimer;

	// Token: 0x04001F89 RID: 8073
	public float Awareness;

	// Token: 0x04001F8A RID: 8074
	public float WaitTimer;

	// Token: 0x04001F8B RID: 8075
	public float Distance;

	// Token: 0x04001F8C RID: 8076
	public float Alpha;

	// Token: 0x04001F8D RID: 8077
	public float Scale;

	// Token: 0x04001F8E RID: 8078
	public float Timer;

	// Token: 0x04001F8F RID: 8079
	public float TargetRotation;

	// Token: 0x04001F90 RID: 8080
	public float Rotation;

	// Token: 0x04001F91 RID: 8081
	public int GameOverPhase;

	// Token: 0x04001F92 RID: 8082
	public int CurrentNode;

	// Token: 0x04001F93 RID: 8083
	public int SpeechPhase;

	// Token: 0x04001F94 RID: 8084
	public bool Searching;

	// Token: 0x04001F95 RID: 8085
	public bool GameOver;

	// Token: 0x04001F96 RID: 8086
	public bool Started;

	// Token: 0x04001F97 RID: 8087
	public bool Shocked;

	// Token: 0x04001F98 RID: 8088
	public Vector3 DistractionPoint;

	// Token: 0x04001F99 RID: 8089
	public float DistractionTimer;

	// Token: 0x04001F9A RID: 8090
	public bool Distracted;
}
