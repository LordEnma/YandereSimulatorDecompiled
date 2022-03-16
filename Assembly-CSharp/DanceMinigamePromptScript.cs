using System;
using UnityEngine;

// Token: 0x0200026E RID: 622
public class DanceMinigamePromptScript : MonoBehaviour
{
	// Token: 0x06001330 RID: 4912 RVA: 0x000AB5AC File Offset: 0x000A97AC
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

	// Token: 0x04001B7F RID: 7039
	public StudentManagerScript StudentManager;

	// Token: 0x04001B80 RID: 7040
	public Renderer OriginalRenderer;

	// Token: 0x04001B81 RID: 7041
	public DDRManager DanceManager;

	// Token: 0x04001B82 RID: 7042
	public PromptScript Prompt;

	// Token: 0x04001B83 RID: 7043
	public ClockScript Clock;

	// Token: 0x04001B84 RID: 7044
	public GameObject DanceMinigame;

	// Token: 0x04001B85 RID: 7045
	public Transform PlayerLocation;
}
