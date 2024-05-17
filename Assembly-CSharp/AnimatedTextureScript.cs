using UnityEngine;

public class AnimatedTextureScript : MonoBehaviour
{
	[SerializeField]
	private Renderer MyRenderer;

	[SerializeField]
	private int Start;

	[SerializeField]
	private int Frame;

	[SerializeField]
	private int Limit;

	[SerializeField]
	private float FramesPerSecond;

	[SerializeField]
	private float CurrentSeconds;

	public Texture[] Image;

	public bool PauseWhenPaused;

	private float SecondsPerFrame => 1f / FramesPerSecond;

	private void Awake()
	{
	}

	private void Update()
	{
		if (!PauseWhenPaused)
		{
			CurrentSeconds += Time.unscaledDeltaTime;
		}
		else
		{
			CurrentSeconds += Time.deltaTime;
		}
		while (CurrentSeconds >= SecondsPerFrame)
		{
			CurrentSeconds -= SecondsPerFrame;
			Frame++;
			if (Frame > Limit)
			{
				Frame = Start;
			}
		}
		MyRenderer.material.mainTexture = Image[Frame];
	}
}
