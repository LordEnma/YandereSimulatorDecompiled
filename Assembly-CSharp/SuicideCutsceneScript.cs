using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200045F RID: 1119
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E68 RID: 7784 RVA: 0x001A2B24 File Offset: 0x001A0D24
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

	// Token: 0x06001E69 RID: 7785 RVA: 0x001A2BAC File Offset: 0x001A0DAC
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

	// Token: 0x04003E40 RID: 15936
	public AudioSource MyAudio;

	// Token: 0x04003E41 RID: 15937
	public AudioClip EightiesMother;

	// Token: 0x04003E42 RID: 15938
	public Light DirectionalLight;

	// Token: 0x04003E43 RID: 15939
	public Light PointLight;

	// Token: 0x04003E44 RID: 15940
	public Transform Door;

	// Token: 0x04003E45 RID: 15941
	public Animation Mom;

	// Token: 0x04003E46 RID: 15942
	public float Timer;

	// Token: 0x04003E47 RID: 15943
	public float Rotation;

	// Token: 0x04003E48 RID: 15944
	public float Speed;

	// Token: 0x04003E49 RID: 15945
	public int ID;

	// Token: 0x04003E4A RID: 15946
	public GameObject[] RivalHair;

	// Token: 0x04003E4B RID: 15947
	public GameObject[] EightiesHair;
}
