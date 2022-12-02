using UnityEngine;

public class TextureCycleScript : MonoBehaviour
{
	public UITexture Sprite;

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

	[SerializeField]
	private Texture[] Textures;

	public int ID;

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
		ID++;
		if (ID > 1)
		{
			ID = 0;
			Frame++;
			if (Frame > Limit)
			{
				Frame = Start;
			}
		}
		Sprite.mainTexture = Textures[Frame];
	}
}
