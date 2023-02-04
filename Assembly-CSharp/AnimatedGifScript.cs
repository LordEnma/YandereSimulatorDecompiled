using UnityEngine;

public class AnimatedGifScript : MonoBehaviour
{
	[SerializeField]
	private UISprite Sprite;

	[SerializeField]
	private string SpriteName;

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

	private float SecondsPerFrame => 1f / FramesPerSecond;

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
		Sprite.spriteName = SpriteName + Frame;
	}
}
