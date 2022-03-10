using System;
using UnityEngine;

// Token: 0x0200026E RID: 622
public class DanceMinigamePromptScript : MonoBehaviour
{
	// Token: 0x0600132D RID: 4909 RVA: 0x000AB060 File Offset: 0x000A9260
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

	// Token: 0x04001B71 RID: 7025
	public StudentManagerScript StudentManager;

	// Token: 0x04001B72 RID: 7026
	public Renderer OriginalRenderer;

	// Token: 0x04001B73 RID: 7027
	public DDRManager DanceManager;

	// Token: 0x04001B74 RID: 7028
	public PromptScript Prompt;

	// Token: 0x04001B75 RID: 7029
	public ClockScript Clock;

	// Token: 0x04001B76 RID: 7030
	public GameObject DanceMinigame;

	// Token: 0x04001B77 RID: 7031
	public Transform PlayerLocation;
}
