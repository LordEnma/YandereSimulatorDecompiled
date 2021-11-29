﻿using System;
using UnityEngine;

// Token: 0x0200027B RID: 635
public class DemonPortalScript : MonoBehaviour
{
	// Token: 0x0600136D RID: 4973 RVA: 0x000B21B8 File Offset: 0x000B03B8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			UnityEngine.Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			this.Timer += Time.deltaTime;
		}
		this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, (this.Yandere.transform.position.y > 1000f) ? 0.5f : 0f, Time.deltaTime * 0.1f);
		if (this.Timer > 0f)
		{
			if (this.Yandere.transform.position.y > 1000f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 4f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
					if (this.Darkness.color.a == 1f)
					{
						this.Yandere.transform.position = new Vector3(12f, 0f, 28f);
						this.Yandere.Character.SetActive(true);
						this.Yandere.SetAnimationLayers();
						this.HeartbeatCamera.SetActive(true);
						this.FPS.SetActive(true);
						this.HUD.SetActive(true);
						return;
					}
				}
				else if (this.Timer > 1f)
				{
					this.Yandere.Character.SetActive(false);
					return;
				}
			}
			else
			{
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.5f, Time.deltaTime * 0.5f);
				if (this.Jukebox.Volume == 0.5f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Darkness.color.a == 0f)
					{
						base.transform.parent.gameObject.SetActive(false);
						this.Darkness.enabled = false;
						this.Yandere.CanMove = true;
						this.Clock.StopTime = false;
						this.Timer = 0f;
					}
				}
			}
		}
	}

	// Token: 0x04001C74 RID: 7284
	public YandereScript Yandere;

	// Token: 0x04001C75 RID: 7285
	public JukeboxScript Jukebox;

	// Token: 0x04001C76 RID: 7286
	public PromptScript Prompt;

	// Token: 0x04001C77 RID: 7287
	public ClockScript Clock;

	// Token: 0x04001C78 RID: 7288
	public AudioSource DemonRealmAudio;

	// Token: 0x04001C79 RID: 7289
	public GameObject HeartbeatCamera;

	// Token: 0x04001C7A RID: 7290
	public GameObject DarkAura;

	// Token: 0x04001C7B RID: 7291
	public GameObject FPS;

	// Token: 0x04001C7C RID: 7292
	public GameObject HUD;

	// Token: 0x04001C7D RID: 7293
	public UISprite Darkness;

	// Token: 0x04001C7E RID: 7294
	public float Timer;
}