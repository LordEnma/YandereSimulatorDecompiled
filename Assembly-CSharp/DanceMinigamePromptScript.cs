using System;
using UnityEngine;

// Token: 0x0200026D RID: 621
public class DanceMinigamePromptScript : MonoBehaviour
{
	// Token: 0x06001328 RID: 4904 RVA: 0x000AA960 File Offset: 0x000A8B60
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

	// Token: 0x04001B5A RID: 7002
	public StudentManagerScript StudentManager;

	// Token: 0x04001B5B RID: 7003
	public Renderer OriginalRenderer;

	// Token: 0x04001B5C RID: 7004
	public DDRManager DanceManager;

	// Token: 0x04001B5D RID: 7005
	public PromptScript Prompt;

	// Token: 0x04001B5E RID: 7006
	public ClockScript Clock;

	// Token: 0x04001B5F RID: 7007
	public GameObject DanceMinigame;

	// Token: 0x04001B60 RID: 7008
	public Transform PlayerLocation;
}
