using System;
using UnityEngine;

// Token: 0x0200027D RID: 637
public class DemonPortalScript : MonoBehaviour
{
	// Token: 0x06001381 RID: 4993 RVA: 0x000B3914 File Offset: 0x000B1B14
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

	// Token: 0x04001CC6 RID: 7366
	public YandereScript Yandere;

	// Token: 0x04001CC7 RID: 7367
	public JukeboxScript Jukebox;

	// Token: 0x04001CC8 RID: 7368
	public PromptScript Prompt;

	// Token: 0x04001CC9 RID: 7369
	public ClockScript Clock;

	// Token: 0x04001CCA RID: 7370
	public AudioSource DemonRealmAudio;

	// Token: 0x04001CCB RID: 7371
	public GameObject HeartbeatCamera;

	// Token: 0x04001CCC RID: 7372
	public GameObject DarkAura;

	// Token: 0x04001CCD RID: 7373
	public GameObject FPS;

	// Token: 0x04001CCE RID: 7374
	public GameObject HUD;

	// Token: 0x04001CCF RID: 7375
	public UISprite Darkness;

	// Token: 0x04001CD0 RID: 7376
	public float Timer;
}
