using System;
using UnityEngine;

// Token: 0x0200026D RID: 621
public class DanceMinigamePromptScript : MonoBehaviour
{
	// Token: 0x06001329 RID: 4905 RVA: 0x000AAD10 File Offset: 0x000A8F10
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

	// Token: 0x04001B61 RID: 7009
	public StudentManagerScript StudentManager;

	// Token: 0x04001B62 RID: 7010
	public Renderer OriginalRenderer;

	// Token: 0x04001B63 RID: 7011
	public DDRManager DanceManager;

	// Token: 0x04001B64 RID: 7012
	public PromptScript Prompt;

	// Token: 0x04001B65 RID: 7013
	public ClockScript Clock;

	// Token: 0x04001B66 RID: 7014
	public GameObject DanceMinigame;

	// Token: 0x04001B67 RID: 7015
	public Transform PlayerLocation;
}
