using System;
using UnityEngine;

// Token: 0x02000386 RID: 902
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A31 RID: 6705 RVA: 0x001152C8 File Offset: 0x001134C8
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

	// Token: 0x04002AC9 RID: 10953
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002ACA RID: 10954
	public GameObject BloodSplatterEffect;

	// Token: 0x04002ACB RID: 10955
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002ACC RID: 10956
	public AudioClip VictoryMusic;

	// Token: 0x04002ACD RID: 10957
	public AudioSource Jukebox;

	// Token: 0x04002ACE RID: 10958
	public Transform Head;

	// Token: 0x04002ACF RID: 10959
	public UILabel Label;

	// Token: 0x04002AD0 RID: 10960
	public bool Advance;

	// Token: 0x04002AD1 RID: 10961
	public float Timer;

	// Token: 0x04002AD2 RID: 10962
	public int ID;
}
