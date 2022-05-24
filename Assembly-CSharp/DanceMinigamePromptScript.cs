using System;
using UnityEngine;

// Token: 0x0200026F RID: 623
public class DanceMinigamePromptScript : MonoBehaviour
{
	// Token: 0x06001337 RID: 4919 RVA: 0x000ABF4C File Offset: 0x000AA14C
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

	// Token: 0x04001B92 RID: 7058
	public StudentManagerScript StudentManager;

	// Token: 0x04001B93 RID: 7059
	public Renderer OriginalRenderer;

	// Token: 0x04001B94 RID: 7060
	public DDRManager DanceManager;

	// Token: 0x04001B95 RID: 7061
	public PromptScript Prompt;

	// Token: 0x04001B96 RID: 7062
	public ClockScript Clock;

	// Token: 0x04001B97 RID: 7063
	public GameObject DanceMinigame;

	// Token: 0x04001B98 RID: 7064
	public Transform PlayerLocation;
}
