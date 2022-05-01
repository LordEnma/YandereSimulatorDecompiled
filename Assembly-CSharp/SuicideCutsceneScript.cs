using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000467 RID: 1127
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001EA5 RID: 7845 RVA: 0x001A88BC File Offset: 0x001A6ABC
	private void Start()
	{
		this.PointLight.color = new Color(0.1f, 0.1f, 0.1f, 1f);
		this.Door.eulerAngles = new Vector3(0f, 0f, 0f);
		if (GameGlobals.Eighties)
		{
			this.MyAudio.clip = this.EightiesMother;
			this.RivalHair[1].SetActive(false);
			this.EightiesHair[DateGlobals.Week].SetActive(true);
		}
	}

	// Token: 0x06001EA6 RID: 7846 RVA: 0x001A8944 File Offset: 0x001A6B44
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.ID == 0)
		{
			if (this.Timer > 1f)
			{
				this.MyAudio.Play();
				this.ID++;
				return;
			}
		}
		else if (this.ID == 1)
		{
			if (this.Timer > 6f)
			{
				this.Speed += Time.deltaTime * 0.66666f;
				this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * this.Speed);
				this.PointLight.color = new Color(0.1f + this.Rotation / -45f * 0.9f, 0.1f + this.Rotation / -45f * 0.9f, 0.1f + this.Rotation / -45f * 0.9f, 1f);
				this.Door.eulerAngles = new Vector3(0f, this.Rotation, 0f);
			}
			if (this.Timer > 8.5f)
			{
				this.Mom.CrossFade("f02_shock_00");
			}
			if (this.Timer > 9.5f)
			{
				this.DirectionalLight.color = new Color(0f, 0f, 0f);
				this.PointLight.color = new Color(0f, 0f, 0f);
			}
			if (this.Timer > 11f)
			{
				GameGlobals.SpecificEliminationID = 19;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Suicide", 1);
				}
				SchoolGlobals.SchoolAtmosphere -= 0.1f;
				GameGlobals.SenpaiMourning = true;
				SceneManager.LoadScene("HomeScene");
			}
		}
	}

	// Token: 0x04003F04 RID: 16132
	public AudioSource MyAudio;

	// Token: 0x04003F05 RID: 16133
	public AudioClip EightiesMother;

	// Token: 0x04003F06 RID: 16134
	public Light DirectionalLight;

	// Token: 0x04003F07 RID: 16135
	public Light PointLight;

	// Token: 0x04003F08 RID: 16136
	public Transform Door;

	// Token: 0x04003F09 RID: 16137
	public Animation Mom;

	// Token: 0x04003F0A RID: 16138
	public float Timer;

	// Token: 0x04003F0B RID: 16139
	public float Rotation;

	// Token: 0x04003F0C RID: 16140
	public float Speed;

	// Token: 0x04003F0D RID: 16141
	public int ID;

	// Token: 0x04003F0E RID: 16142
	public GameObject[] RivalHair;

	// Token: 0x04003F0F RID: 16143
	public GameObject[] EightiesHair;
}
