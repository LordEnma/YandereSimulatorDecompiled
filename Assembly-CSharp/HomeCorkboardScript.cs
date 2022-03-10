using System;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x06001871 RID: 6257 RVA: 0x000ECBE8 File Offset: 0x000EADE8
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

	// Token: 0x04002480 RID: 9344
	public InputManagerScript InputManager;

	// Token: 0x04002481 RID: 9345
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002482 RID: 9346
	public HomeYandereScript HomeYandere;

	// Token: 0x04002483 RID: 9347
	public HomeCameraScript HomeCamera;

	// Token: 0x04002484 RID: 9348
	public HomeWindowScript HomeWindow;

	// Token: 0x04002485 RID: 9349
	public bool Loaded;
}
