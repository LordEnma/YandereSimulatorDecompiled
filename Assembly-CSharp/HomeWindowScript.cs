using UnityEngine;

public class HomeWindowScript : MonoBehaviour
{
	public UISprite Sprite;

	public bool Show;

	private void Start()
	{
		Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 0f);
	}

	private void Update()
	{
		Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, Mathf.Lerp(Sprite.color.a, Show ? 1f : 0f, Time.deltaTime * 10f));
	}
}
