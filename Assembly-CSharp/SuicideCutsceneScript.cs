using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200045E RID: 1118
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E5B RID: 7771 RVA: 0x001A1D44 File Offset: 0x0019FF44
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

	// Token: 0x06001E5C RID: 7772 RVA: 0x001A1DCC File Offset: 0x0019FFCC
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

	// Token: 0x04003E27 RID: 15911
	public AudioSource MyAudio;

	// Token: 0x04003E28 RID: 15912
	public AudioClip EightiesMother;

	// Token: 0x04003E29 RID: 15913
	public Light DirectionalLight;

	// Token: 0x04003E2A RID: 15914
	public Light PointLight;

	// Token: 0x04003E2B RID: 15915
	public Transform Door;

	// Token: 0x04003E2C RID: 15916
	public Animation Mom;

	// Token: 0x04003E2D RID: 15917
	public float Timer;

	// Token: 0x04003E2E RID: 15918
	public float Rotation;

	// Token: 0x04003E2F RID: 15919
	public float Speed;

	// Token: 0x04003E30 RID: 15920
	public int ID;

	// Token: 0x04003E31 RID: 15921
	public GameObject[] RivalHair;

	// Token: 0x04003E32 RID: 15922
	public GameObject[] EightiesHair;
}
