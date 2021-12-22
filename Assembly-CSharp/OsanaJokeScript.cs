using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A17 RID: 6679 RVA: 0x00113420 File Offset: 0x00111620
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

	// Token: 0x04002A86 RID: 10886
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002A87 RID: 10887
	public GameObject BloodSplatterEffect;

	// Token: 0x04002A88 RID: 10888
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002A89 RID: 10889
	public AudioClip VictoryMusic;

	// Token: 0x04002A8A RID: 10890
	public AudioSource Jukebox;

	// Token: 0x04002A8B RID: 10891
	public Transform Head;

	// Token: 0x04002A8C RID: 10892
	public UILabel Label;

	// Token: 0x04002A8D RID: 10893
	public bool Advance;

	// Token: 0x04002A8E RID: 10894
	public float Timer;

	// Token: 0x04002A8F RID: 10895
	public int ID;
}
