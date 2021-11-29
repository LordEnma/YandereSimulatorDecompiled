using System;
using UnityEngine;

// Token: 0x0200026C RID: 620
public class DanceMinigamePromptScript : MonoBehaviour
{
	// Token: 0x06001321 RID: 4897 RVA: 0x000AA4BC File Offset: 0x000A86BC
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.PlayerLocation.position;
			this.Prompt.Yandere.transform.rotation = this.PlayerLocation.rotation;
			this.Prompt.Yandere.CharacterAnimation.Play("f02_danceMachineIdle_00");
			this.Prompt.Yandere.StudentManager.Clock.StopTime = true;
			this.Prompt.Yandere.MyController.enabled = false;
			this.Prompt.Yandere.HeartCamera.enabled = false;
			this.Prompt.Yandere.HUD.enabled = false;
			this.Prompt.Yandere.CanMove = false;
			this.Prompt.Yandere.enabled = false;
			this.Prompt.Yandere.Jukebox.LastVolume = this.Prompt.Yandere.Jukebox.Volume;
			this.Prompt.Yandere.Jukebox.Volume = 0f;
			this.Prompt.Yandere.HUD.transform.parent.gameObject.SetActive(false);
			this.Prompt.Yandere.MainCamera.gameObject.SetActive(false);
			this.OriginalRenderer.enabled = false;
			Physics.SyncTransforms();
			this.DanceMinigame.SetActive(true);
			this.DanceManager.BeginMinigame();
			this.StudentManager.DisableEveryone();
		}
	}

	// Token: 0x04001B41 RID: 6977
	public StudentManagerScript StudentManager;

	// Token: 0x04001B42 RID: 6978
	public Renderer OriginalRenderer;

	// Token: 0x04001B43 RID: 6979
	public DDRManager DanceManager;

	// Token: 0x04001B44 RID: 6980
	public PromptScript Prompt;

	// Token: 0x04001B45 RID: 6981
	public ClockScript Clock;

	// Token: 0x04001B46 RID: 6982
	public GameObject DanceMinigame;

	// Token: 0x04001B47 RID: 6983
	public Transform PlayerLocation;
}
