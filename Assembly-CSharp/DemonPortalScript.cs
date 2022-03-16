using System;
using UnityEngine;

// Token: 0x0200027D RID: 637
public class DemonPortalScript : MonoBehaviour
{
	// Token: 0x0600137C RID: 4988 RVA: 0x000B3278 File Offset: 0x000B1478
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

	// Token: 0x04001CBA RID: 7354
	public YandereScript Yandere;

	// Token: 0x04001CBB RID: 7355
	public JukeboxScript Jukebox;

	// Token: 0x04001CBC RID: 7356
	public PromptScript Prompt;

	// Token: 0x04001CBD RID: 7357
	public ClockScript Clock;

	// Token: 0x04001CBE RID: 7358
	public AudioSource DemonRealmAudio;

	// Token: 0x04001CBF RID: 7359
	public GameObject HeartbeatCamera;

	// Token: 0x04001CC0 RID: 7360
	public GameObject DarkAura;

	// Token: 0x04001CC1 RID: 7361
	public GameObject FPS;

	// Token: 0x04001CC2 RID: 7362
	public GameObject HUD;

	// Token: 0x04001CC3 RID: 7363
	public UISprite Darkness;

	// Token: 0x04001CC4 RID: 7364
	public float Timer;
}
