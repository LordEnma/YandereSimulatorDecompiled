using System;
using UnityEngine;

// Token: 0x0200026E RID: 622
public class DanceMinigamePromptScript : MonoBehaviour
{
	// Token: 0x06001335 RID: 4917 RVA: 0x000ABC6C File Offset: 0x000A9E6C
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

	// Token: 0x04001B8B RID: 7051
	public StudentManagerScript StudentManager;

	// Token: 0x04001B8C RID: 7052
	public Renderer OriginalRenderer;

	// Token: 0x04001B8D RID: 7053
	public DDRManager DanceManager;

	// Token: 0x04001B8E RID: 7054
	public PromptScript Prompt;

	// Token: 0x04001B8F RID: 7055
	public ClockScript Clock;

	// Token: 0x04001B90 RID: 7056
	public GameObject DanceMinigame;

	// Token: 0x04001B91 RID: 7057
	public Transform PlayerLocation;
}
