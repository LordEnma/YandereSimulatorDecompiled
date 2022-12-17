using UnityEngine;

public class CautionScript : MonoBehaviour
{
	public YandereScript Yandere;

	public UISprite Sprite;

	private void Start()
	{
		Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 0f);
		if (GameGlobals.EightiesTutorial || GameGlobals.KokonaTutorial)
		{
			base.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if ((Yandere.Armed && Yandere.EquippedWeapon.Suspicious) || Yandere.Bloodiness > 0f || Yandere.Sanity < 33.333332f || Yandere.NearBodies > 0)
		{
			Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, Sprite.color.a + Time.deltaTime);
			if (Sprite.color.a > 1f)
			{
				Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 1f);
			}
		}
		else
		{
			Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, Sprite.color.a - Time.deltaTime);
			if (Sprite.color.a < 0f)
			{
				Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 0f);
			}
		}
	}
}
