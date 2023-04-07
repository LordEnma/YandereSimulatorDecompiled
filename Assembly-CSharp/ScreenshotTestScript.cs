using System.IO;
using UnityEngine;

public class ScreenshotTestScript : MonoBehaviour
{
	public Camera SenpaiCamera;

	public int Frames;

	private void LateUpdate()
	{
		if (Frames > 0)
		{
			OnPostRenderCallback(SenpaiCamera);
			base.enabled = false;
		}
		Frames++;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnPostRenderCallback(SenpaiCamera);
		}
	}

	private void OnPostRenderCallback(Camera cam)
	{
		RenderTexture active = (cam.targetTexture = new RenderTexture(512, 512, 16));
		RenderTexture.active = active;
		cam.Render();
		Texture2D texture2D = new Texture2D(512, 512);
		texture2D.ReadPixels(new Rect(0f, 0f, 512f, 512f), 0, 0);
		RenderTexture.active = null;
		byte[] bytes = texture2D.EncodeToPNG();
		File.WriteAllBytes(Application.streamingAssetsPath + "/SenpaiPortrait.png", bytes);
	}
}
