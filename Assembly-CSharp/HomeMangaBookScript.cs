using UnityEngine;

public class HomeMangaBookScript : MonoBehaviour
{
	public HomeMangaScript Manga;

	public float RotationSpeed;

	public int ID;

	public Renderer MyRenderer;

	public Texture EightiesCover;

	public Texture EightiesBack;

	public Texture EightiesSpine;

	private void Start()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
		if (MyRenderer != null && ID < 10 && GameGlobals.Eighties)
		{
			MyRenderer.materials[0].mainTexture = EightiesCover;
			MyRenderer.materials[1].mainTexture = EightiesBack;
			MyRenderer.materials[2].mainTexture = EightiesSpine;
		}
	}

	private void Update()
	{
		float y = ((Manga.Selected == ID) ? (base.transform.eulerAngles.y + Time.deltaTime * RotationSpeed) : 0f);
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}
}
