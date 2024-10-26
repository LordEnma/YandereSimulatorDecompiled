using UnityEngine;

public class CameraDistanceDisableScript : MonoBehaviour
{
	public Transform RenderTarget;

	public Transform Yandere;

	public Renderer MirrorBlocker;

	public Renderer MyRenderer;

	public Camera MyCamera;

	public bool Disable;

	private void Start()
	{
		CheckIfShouldDisable();
	}

	private void Update()
	{
		if (!Disable)
		{
			if (Vector3.Distance(Yandere.position, RenderTarget.position) > 15f)
			{
				MyRenderer.enabled = false;
				MyCamera.enabled = false;
			}
			else
			{
				MyRenderer.enabled = true;
				MyCamera.enabled = true;
			}
		}
	}

	public void CheckIfShouldDisable()
	{
		if (MirrorBlocker != null)
		{
			Disable = OptionGlobals.DisableMirrors;
			MirrorBlocker.enabled = Disable;
			MyRenderer.enabled = !Disable;
		}
	}
}
