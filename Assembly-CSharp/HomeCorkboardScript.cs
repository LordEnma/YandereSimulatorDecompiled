using System;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x0600185F RID: 6239 RVA: 0x000EBD74 File Offset: 0x000E9F74
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

	// Token: 0x04002454 RID: 9300
	public InputManagerScript InputManager;

	// Token: 0x04002455 RID: 9301
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002456 RID: 9302
	public HomeYandereScript HomeYandere;

	// Token: 0x04002457 RID: 9303
	public HomeCameraScript HomeCamera;

	// Token: 0x04002458 RID: 9304
	public HomeWindowScript HomeWindow;

	// Token: 0x04002459 RID: 9305
	public bool Loaded;
}
