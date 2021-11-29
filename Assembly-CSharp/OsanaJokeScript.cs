using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A0F RID: 6671 RVA: 0x00112BF0 File Offset: 0x00110DF0
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

	// Token: 0x04002A5C RID: 10844
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002A5D RID: 10845
	public GameObject BloodSplatterEffect;

	// Token: 0x04002A5E RID: 10846
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002A5F RID: 10847
	public AudioClip VictoryMusic;

	// Token: 0x04002A60 RID: 10848
	public AudioSource Jukebox;

	// Token: 0x04002A61 RID: 10849
	public Transform Head;

	// Token: 0x04002A62 RID: 10850
	public UILabel Label;

	// Token: 0x04002A63 RID: 10851
	public bool Advance;

	// Token: 0x04002A64 RID: 10852
	public float Timer;

	// Token: 0x04002A65 RID: 10853
	public int ID;
}
