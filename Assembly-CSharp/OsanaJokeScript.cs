using System;
using UnityEngine;

// Token: 0x02000388 RID: 904
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A47 RID: 6727 RVA: 0x0011659C File Offset: 0x0011479C
	private void Update()
	{
		if (this.Advance)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 14f)
			{
				Application.Quit();
				return;
			}
			if (this.Timer > 3f)
			{
				this.Label.text = "Congratulations! You have beaten Yandere Simulator!";
				if (!this.Jukebox.isPlaying)
				{
					this.Jukebox.clip = this.VictoryMusic;
					this.Jukebox.Play();
					return;
				}
			}
		}
		else if (Input.GetKeyDown("f"))
		{
			this.Rotation[0].enabled = false;
			this.Rotation[1].enabled = false;
			this.Rotation[2].enabled = false;
			this.Rotation[3].enabled = false;
			this.Rotation[4].enabled = false;
			this.Rotation[5].enabled = false;
			this.Rotation[6].enabled = false;
			this.Rotation[7].enabled = false;
			UnityEngine.Object.Instantiate<GameObject>(this.BloodSplatterEffect, this.Head.position, Quaternion.identity);
			this.Head.localScale = new Vector3(0f, 0f, 0f);
			this.Jukebox.clip = this.BloodSplatterSFX;
			this.Jukebox.Play();
			this.Label.text = "";
			this.Advance = true;
		}
	}

	// Token: 0x04002B08 RID: 11016
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002B09 RID: 11017
	public GameObject BloodSplatterEffect;

	// Token: 0x04002B0A RID: 11018
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002B0B RID: 11019
	public AudioClip VictoryMusic;

	// Token: 0x04002B0C RID: 11020
	public AudioSource Jukebox;

	// Token: 0x04002B0D RID: 11021
	public Transform Head;

	// Token: 0x04002B0E RID: 11022
	public UILabel Label;

	// Token: 0x04002B0F RID: 11023
	public bool Advance;

	// Token: 0x04002B10 RID: 11024
	public float Timer;

	// Token: 0x04002B11 RID: 11025
	public int ID;
}
