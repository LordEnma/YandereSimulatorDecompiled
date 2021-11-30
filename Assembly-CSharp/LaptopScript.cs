using System;
using UnityEngine;

// Token: 0x02000349 RID: 841
public class LaptopScript : MonoBehaviour
{
	// Token: 0x06001933 RID: 6451 RVA: 0x000FBBB4 File Offset: 0x000F9DB4
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

	// Token: 0x06001934 RID: 6452 RVA: 0x000FBC58 File Offset: 0x000F9E58
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

	// Token: 0x06001935 RID: 6453 RVA: 0x000FBFEC File Offset: 0x000FA1EC
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

	// Token: 0x04002796 RID: 10134
	public SkinnedMeshRenderer SCPRenderer;

	// Token: 0x04002797 RID: 10135
	public Camera LaptopCamera;

	// Token: 0x04002798 RID: 10136
	public JukeboxScript Jukebox;

	// Token: 0x04002799 RID: 10137
	public YandereScript Yandere;

	// Token: 0x0400279A RID: 10138
	public AudioSource MyAudio;

	// Token: 0x0400279B RID: 10139
	public DynamicBone Hair;

	// Token: 0x0400279C RID: 10140
	public Transform LaptopScreen;

	// Token: 0x0400279D RID: 10141
	public AudioClip ShutDown;

	// Token: 0x0400279E RID: 10142
	public GameObject SCP;

	// Token: 0x0400279F RID: 10143
	public bool React;

	// Token: 0x040027A0 RID: 10144
	public bool Off;

	// Token: 0x040027A1 RID: 10145
	public float[] Cues;

	// Token: 0x040027A2 RID: 10146
	public string[] Subs;

	// Token: 0x040027A3 RID: 10147
	public Mesh[] Uniforms;

	// Token: 0x040027A4 RID: 10148
	public int FirstFrame;

	// Token: 0x040027A5 RID: 10149
	public float Timer;

	// Token: 0x040027A6 RID: 10150
	public UILabel EventSubtitle;
}
