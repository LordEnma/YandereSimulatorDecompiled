using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class PantyDetectorScript : MonoBehaviour
{
	// Token: 0x06001A61 RID: 6753 RVA: 0x00118922 File Offset: 0x00116B22
	private void Update()
	{
		if (this.Frame == 1)
		{
			this.Yandere.StudentManager.UpdatePanties(false);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x06001A62 RID: 6754 RVA: 0x00118958 File Offset: 0x00116B58
	private void OnTriggerEnter(Collider other)
	{
		if (this.Student == null && other.gameObject.name == "Panties")
		{
			this.Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
			this.Yandere.ResetYandereEffects();
			this.Yandere.Shutter.PhotoDescLabel.text = "Photo of: " + this.Student.Name + "'s Panties";
			this.Yandere.Shutter.PhotoIcons.SetActive(true);
			this.Yandere.Shutter.PantiesX.SetActive(false);
			this.Yandere.Shutter.InfoX.SetActive(true);
			this.Yandere.Shutter.Student = this.Student;
			Time.timeScale = 0f;
			this.Yandere.Shutter.Panel.SetActive(true);
			this.Yandere.Shutter.MainMenu.SetActive(false);
			this.Yandere.PauseScreen.Show = true;
			this.Yandere.PauseScreen.Panel.enabled = true;
			this.Yandere.PromptBar.ClearButtons();
			this.Yandere.PromptBar.Label[1].text = "Exit";
			this.Yandere.PromptBar.UpdateButtons();
			this.Yandere.PromptBar.Show = true;
			this.Yandere.PauseScreen.Sideways = false;
			this.Yandere.Shutter.TextMessages.gameObject.SetActive(true);
			this.Yandere.Shutter.SpawnMessage();
		}
	}

	// Token: 0x04002B5D RID: 11101
	public YandereScript Yandere;

	// Token: 0x04002B5E RID: 11102
	public StudentScript Student;

	// Token: 0x04002B5F RID: 11103
	public int Frame;
}
