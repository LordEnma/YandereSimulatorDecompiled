using UnityEngine;

public class MusicRippleScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Texture[] Sprite;

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
				Object.Destroy(base.gameObject);
			}
			else
			{
				MyRenderer.material.mainTexture = Sprite[Frame];
			}
		}
	}
}
