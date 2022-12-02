using UnityEngine;

public class MGPMWaterScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Texture[] Sprite;

	public float Speed;

	public float Timer;

	public float FPS;

	public int Frame;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > FPS)
		{
			Timer = 0f;
			Frame++;
			if (Frame == Sprite.Length)
			{
				Frame = 0;
			}
			MyRenderer.material.mainTexture = Sprite[Frame];
		}
		base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y - Speed * Time.deltaTime, 3f);
		if (base.transform.localPosition.y < -640f)
		{
			base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y + 1280f, 3f);
		}
	}
}
