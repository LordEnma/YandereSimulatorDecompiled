using UnityEngine;

public class CautionScript : MonoBehaviour
{
	public YandereScript Yandere;

	public UISprite Sprite;

	private void Start()
	{
		Sprite.alpha = 0f;
		if (GameGlobals.EightiesTutorial || GameGlobals.KokonaTutorial)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if ((Yandere.Armed && Yandere.EquippedWeapon.Suspicious) || Yandere.Bloodiness > 0f || Yandere.Sanity < 33.333332f || Yandere.NearBodies > 0)
		{
			if (Sprite.alpha < 1f)
			{
				Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 1f, Time.deltaTime * 10f);
			}
		}
		else if (Sprite.alpha > 0f)
		{
			Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 0f, Time.deltaTime * 10f);
		}
	}
}
