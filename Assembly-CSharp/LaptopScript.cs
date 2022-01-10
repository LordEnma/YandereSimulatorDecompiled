using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class LaptopScript : MonoBehaviour
{
	// Token: 0x06001940 RID: 6464 RVA: 0x000FC9E4 File Offset: 0x000FABE4
	private void Start()
	{
		if (SchoolGlobals.SCP || GameGlobals.AlphabetMode)
		{
			this.LaptopScreen.localScale = Vector3.zero;
			this.LaptopCamera.enabled = false;
			this.SCP.SetActive(false);
			base.enabled = false;
			return;
		}
		this.SCPRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		Animation component = this.SCP.GetComponent<Animation>();
		component["f02_scp_00"].speed = 0f;
		component["f02_scp_00"].time = 0f;
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06001941 RID: 6465 RVA: 0x000FCA88 File Offset: 0x000FAC88
	private void Update()
	{
		if (this.FirstFrame == 2)
		{
			this.LaptopCamera.enabled = false;
		}
		this.FirstFrame++;
		if (!this.Off)
		{
			Animation component = this.SCP.GetComponent<Animation>();
			if (!this.React)
			{
				if (this.Yandere.transform.position.x > base.transform.position.x + 1f && Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) < 2f && this.Yandere.Followers == 0)
				{
					this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					component["f02_scp_00"].time = 0f;
					this.LaptopCamera.enabled = true;
					component.Play();
					this.Hair.enabled = true;
					this.Jukebox.Dip = 0.5f;
					this.MyAudio.Play();
					this.React = true;
				}
			}
			else
			{
				this.MyAudio.pitch = Time.timeScale;
				this.MyAudio.volume = 1f;
				if (this.Yandere.transform.position.y > base.transform.position.y + 3f || this.Yandere.transform.position.y < base.transform.position.y - 3f)
				{
					this.MyAudio.volume = 0f;
				}
				for (int i = 0; i < this.Cues.Length; i++)
				{
					if (this.MyAudio.time > this.Cues[i])
					{
						this.EventSubtitle.text = this.Subs[i];
					}
				}
				if (this.MyAudio.time >= this.MyAudio.clip.length - 1f || this.MyAudio.time == 0f)
				{
					component["f02_scp_00"].speed = 1f;
					this.Timer += Time.deltaTime;
				}
				else
				{
					component["f02_scp_00"].time = this.MyAudio.time;
				}
				if (this.Timer > 1f || Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) > 5f)
				{
					this.TurnOff();
				}
			}
			if (this.Yandere.StudentManager.Clock.HourTime > 16f || this.Yandere.Police.FadeOut)
			{
				this.TurnOff();
				return;
			}
		}
		else
		{
			if (this.LaptopScreen.localScale.x > 0.1f)
			{
				this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, Vector3.zero, Time.deltaTime * 10f);
				return;
			}
			if (base.enabled)
			{
				this.LaptopScreen.localScale = Vector3.zero;
				this.Hair.enabled = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x06001942 RID: 6466 RVA: 0x000FCE1C File Offset: 0x000FB01C
	private void TurnOff()
	{
		this.MyAudio.clip = this.ShutDown;
		this.MyAudio.Play();
		this.EventSubtitle.text = string.Empty;
		SchoolGlobals.SCP = true;
		this.LaptopCamera.enabled = false;
		this.Jukebox.Dip = 1f;
		this.React = false;
		this.Off = true;
	}

	// Token: 0x040027C3 RID: 10179
	public SkinnedMeshRenderer SCPRenderer;

	// Token: 0x040027C4 RID: 10180
	public Camera LaptopCamera;

	// Token: 0x040027C5 RID: 10181
	public JukeboxScript Jukebox;

	// Token: 0x040027C6 RID: 10182
	public YandereScript Yandere;

	// Token: 0x040027C7 RID: 10183
	public AudioSource MyAudio;

	// Token: 0x040027C8 RID: 10184
	public DynamicBone Hair;

	// Token: 0x040027C9 RID: 10185
	public Transform LaptopScreen;

	// Token: 0x040027CA RID: 10186
	public AudioClip ShutDown;

	// Token: 0x040027CB RID: 10187
	public GameObject SCP;

	// Token: 0x040027CC RID: 10188
	public bool React;

	// Token: 0x040027CD RID: 10189
	public bool Off;

	// Token: 0x040027CE RID: 10190
	public float[] Cues;

	// Token: 0x040027CF RID: 10191
	public string[] Subs;

	// Token: 0x040027D0 RID: 10192
	public Mesh[] Uniforms;

	// Token: 0x040027D1 RID: 10193
	public int FirstFrame;

	// Token: 0x040027D2 RID: 10194
	public float Timer;

	// Token: 0x040027D3 RID: 10195
	public UILabel EventSubtitle;
}
