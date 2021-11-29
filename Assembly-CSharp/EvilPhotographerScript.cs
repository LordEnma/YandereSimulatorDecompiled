using System;
using UnityEngine;

// Token: 0x020002BB RID: 699
public class EvilPhotographerScript : MonoBehaviour
{
	// Token: 0x06001461 RID: 5217 RVA: 0x000C5BE3 File Offset: 0x000C3DE3
	private void Start()
	{
		this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001462 RID: 5218 RVA: 0x000C5C0C File Offset: 0x000C3E0C
	private void Update()
	{
		if (!this.GameOver)
		{
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
				this.LookForYandere();
			}
			else if (this.Alpha > 0f)
			{
				this.Alpha -= Time.deltaTime;
				this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
				this.Marker.Tex.color = new Color(1f, 0f, 0f, this.Alpha);
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
				Quaternion b = Quaternion.LookRotation(this.Node[this.CurrentNode].position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
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

	// Token: 0x06001463 RID: 5219 RVA: 0x000C636C File Offset: 0x000C456C
	private bool YandereIsInFOV()
	{
		Vector3 to = this.Yandere.transform.position - this.Head.position;
		float num = 90f;
		return Vector3.Angle(this.Head.forward, to) <= num;
	}

	// Token: 0x06001464 RID: 5220 RVA: 0x000C63B8 File Offset: 0x000C45B8
	private bool YandereIsInLOS()
	{
		Debug.DrawLine(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), Color.red);
		RaycastHit raycastHit;
		return Physics.Linecast(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.YandereHead.position.y, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject.layer == 13;
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000C6484 File Offset: 0x000C4684
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

	// Token: 0x06001466 RID: 5222 RVA: 0x000C6564 File Offset: 0x000C4764
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

	// Token: 0x04001F36 RID: 7990
	public StalkerYandereScript Yandere;

	// Token: 0x04001F37 RID: 7991
	public DetectionMarkerScript Marker;

	// Token: 0x04001F38 RID: 7992
	public AudioClip ShockedGameOverLine;

	// Token: 0x04001F39 RID: 7993
	public AudioClip GameOverSound;

	// Token: 0x04001F3A RID: 7994
	public AudioClip GameOverLine;

	// Token: 0x04001F3B RID: 7995
	public AudioClip SpottedSound;

	// Token: 0x04001F3C RID: 7996
	public GameObject Heartbroken;

	// Token: 0x04001F3D RID: 7997
	public GameObject Fire;

	// Token: 0x04001F3E RID: 7998
	public Animation MyAnimation;

	// Token: 0x04001F3F RID: 7999
	public Transform YandereHead;

	// Token: 0x04001F40 RID: 8000
	public Transform Head;

	// Token: 0x04001F41 RID: 8001
	public AudioSource Jukebox;

	// Token: 0x04001F42 RID: 8002
	public AudioSource MyAudio;

	// Token: 0x04001F43 RID: 8003
	public Renderer Darkness;

	// Token: 0x04001F44 RID: 8004
	public UILabel Subtitle;

	// Token: 0x04001F45 RID: 8005
	public Transform[] PanicNode;

	// Token: 0x04001F46 RID: 8006
	public Transform[] Node;

	// Token: 0x04001F47 RID: 8007
	public AudioClip[] SpeechClip;

	// Token: 0x04001F48 RID: 8008
	public string[] SpeechText;

	// Token: 0x04001F49 RID: 8009
	public float[] SpeechTime;

	// Token: 0x04001F4A RID: 8010
	public AudioClip[] ShockClip;

	// Token: 0x04001F4B RID: 8011
	public string[] ShockText;

	// Token: 0x04001F4C RID: 8012
	public float[] ShockTime;

	// Token: 0x04001F4D RID: 8013
	public string ShockedGameOverText;

	// Token: 0x04001F4E RID: 8014
	public string GameOverText;

	// Token: 0x04001F4F RID: 8015
	public string WaitAnim;

	// Token: 0x04001F50 RID: 8016
	public string WalkAnim;

	// Token: 0x04001F51 RID: 8017
	public string RunAnim;

	// Token: 0x04001F52 RID: 8018
	public float MinimumDistance;

	// Token: 0x04001F53 RID: 8019
	public float SpeechTimer;

	// Token: 0x04001F54 RID: 8020
	public float NoticeSpeed;

	// Token: 0x04001F55 RID: 8021
	public float ShockTimer;

	// Token: 0x04001F56 RID: 8022
	public float Awareness;

	// Token: 0x04001F57 RID: 8023
	public float WaitTimer;

	// Token: 0x04001F58 RID: 8024
	public float Distance;

	// Token: 0x04001F59 RID: 8025
	public float Alpha;

	// Token: 0x04001F5A RID: 8026
	public float Scale;

	// Token: 0x04001F5B RID: 8027
	public float Timer;

	// Token: 0x04001F5C RID: 8028
	public float TargetRotation;

	// Token: 0x04001F5D RID: 8029
	public float Rotation;

	// Token: 0x04001F5E RID: 8030
	public int GameOverPhase;

	// Token: 0x04001F5F RID: 8031
	public int CurrentNode;

	// Token: 0x04001F60 RID: 8032
	public int SpeechPhase;

	// Token: 0x04001F61 RID: 8033
	public bool Searching;

	// Token: 0x04001F62 RID: 8034
	public bool GameOver;

	// Token: 0x04001F63 RID: 8035
	public bool Started;

	// Token: 0x04001F64 RID: 8036
	public bool Shocked;
}
