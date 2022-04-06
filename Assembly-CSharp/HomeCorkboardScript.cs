using System;
using UnityEngine;

// Token: 0x0200031B RID: 795
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x06001882 RID: 6274 RVA: 0x000ED760 File Offset: 0x000EB960
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

	// Token: 0x040024A7 RID: 9383
	public InputManagerScript InputManager;

	// Token: 0x040024A8 RID: 9384
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x040024A9 RID: 9385
	public HomeYandereScript HomeYandere;

	// Token: 0x040024AA RID: 9386
	public HomeCameraScript HomeCamera;

	// Token: 0x040024AB RID: 9387
	public HomeWindowScript HomeWindow;

	// Token: 0x040024AC RID: 9388
	public bool Loaded;
}
