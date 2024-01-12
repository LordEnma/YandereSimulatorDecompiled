using System.IO;
using UnityEngine;

public class ScreenshotTestScript : MonoBehaviour
{
	public Camera SenpaiCamera;

	public Texture EightiesBG;

	public GameObject Petals;

	public GameObject Tree;

	public Renderer Target;

	public UITexture BG;

	public int StartFrame;

	public int Frames;

	public string PortraitName = "SenpaiPortrait";

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			BG.mainTexture = EightiesBG;
			Petals.SetActive(value: false);
			Tree.SetActive(value: false);
		}
	}

	private void LateUpdate()
	{
		if (Frames > StartFrame)
		{
			if (!HomeGlobals.Night)
			{
				OnPostRenderCallback(SenpaiCamera);
			}
			WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/" + PortraitName + ".png");
			Target.materials[0].mainTexture = wWW.texture;
			base.gameObject.SetActive(value: false);
			base.enabled = false;
		}
		Frames++;
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
		File.WriteAllBytes(Application.streamingAssetsPath + "/" + PortraitName + ".png", bytes);
	}
}
