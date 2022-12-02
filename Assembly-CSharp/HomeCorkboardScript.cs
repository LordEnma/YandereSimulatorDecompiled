using UnityEngine;

public class HomeCorkboardScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PhotoGalleryScript PhotoGallery;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public bool Loaded;

	private void Update()
	{
		if (!HomeYandere.CanMove)
		{
			if (!Loaded)
			{
				PhotoGallery.LoadingScreen.SetActive(false);
				PhotoGallery.UpdateButtonPrompts();
				PhotoGallery.enabled = true;
				PhotoGallery.gameObject.SetActive(true);
				Loaded = true;
			}
			if (!PhotoGallery.Adjusting && !PhotoGallery.Viewing && !PhotoGallery.LoadingScreen.activeInHierarchy && Input.GetButtonDown("B"))
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				HomeCamera.Destination = HomeCamera.Destinations[0];
				HomeCamera.Target = HomeCamera.Targets[0];
				HomeCamera.CorkboardLabel.SetActive(true);
				PhotoGallery.PromptBar.Show = false;
				PhotoGallery.enabled = false;
				HomeYandere.CanMove = true;
				HomeYandere.gameObject.SetActive(true);
				HomeWindow.Show = false;
				base.enabled = false;
				Loaded = false;
				PhotoGallery.SaveAllPhotographs();
				PhotoGallery.SaveAllStrings();
			}
		}
	}
}
