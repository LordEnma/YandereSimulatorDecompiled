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

	private float SecondsPerFrame
	{
		get
		{
			return 1f / FramesPerSecond;
		}
	}

	private void Awake()
	{
	}

	private void Update()
	{
		CurrentSeconds += Time.unscaledDeltaTime;
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
