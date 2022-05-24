using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000468 RID: 1128
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001EAF RID: 7855 RVA: 0x001A9F5C File Offset: 0x001A815C
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

	// Token: 0x06001EB0 RID: 7856 RVA: 0x001A9FE4 File Offset: 0x001A81E4
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

	// Token: 0x04003F2B RID: 16171
	public AudioSource MyAudio;

	// Token: 0x04003F2C RID: 16172
	public AudioClip EightiesMother;

	// Token: 0x04003F2D RID: 16173
	public Light DirectionalLight;

	// Token: 0x04003F2E RID: 16174
	public Light PointLight;

	// Token: 0x04003F2F RID: 16175
	public Transform Door;

	// Token: 0x04003F30 RID: 16176
	public Animation Mom;

	// Token: 0x04003F31 RID: 16177
	public float Timer;

	// Token: 0x04003F32 RID: 16178
	public float Rotation;

	// Token: 0x04003F33 RID: 16179
	public float Speed;

	// Token: 0x04003F34 RID: 16180
	public int ID;

	// Token: 0x04003F35 RID: 16181
	public GameObject[] RivalHair;

	// Token: 0x04003F36 RID: 16182
	public GameObject[] EightiesHair;
}
