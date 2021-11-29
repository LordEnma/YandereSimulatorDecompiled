using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x06001851 RID: 6225 RVA: 0x000EA9D8 File Offset: 0x000E8BD8
	private void Update()
	{
		if (!this.HomeYandere.CanMove)
		{
			if (!this.Loaded)
			{
				this.PhotoGallery.LoadingScreen.SetActive(false);
				this.PhotoGallery.UpdateButtonPrompts();
				this.PhotoGallery.enabled = true;
				this.PhotoGallery.gameObject.SetActive(true);
				this.Loaded = true;
			}
			if (!this.PhotoGallery.Adjusting && !this.PhotoGallery.Viewing && !this.PhotoGallery.LoadingScreen.activeInHierarchy && Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeCamera.CorkboardLabel.SetActive(true);
				this.PhotoGallery.PromptBar.Show = false;
				this.PhotoGallery.enabled = false;
				this.HomeYandere.CanMove = true;
				this.HomeYandere.gameObject.SetActive(true);
				this.HomeWindow.Show = false;
				base.enabled = false;
				this.Loaded = false;
				this.PhotoGallery.SaveAllPhotographs();
				this.PhotoGallery.SaveAllStrings();
			}
		}
	}

	// Token: 0x04002423 RID: 9251
	public InputManagerScript InputManager;

	// Token: 0x04002424 RID: 9252
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002425 RID: 9253
	public HomeYandereScript HomeYandere;

	// Token: 0x04002426 RID: 9254
	public HomeCameraScript HomeCamera;

	// Token: 0x04002427 RID: 9255
	public HomeWindowScript HomeWindow;

	// Token: 0x04002428 RID: 9256
	public bool Loaded;
}
