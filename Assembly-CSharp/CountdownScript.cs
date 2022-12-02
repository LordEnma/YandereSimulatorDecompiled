using UnityEngine;

public class CountdownScript : MonoBehaviour
{
	public UISprite Sprite;

	public float Speed = 0.05f;

	public bool MaskedPhoto;

	private void Update()
	{
		Sprite.fillAmount = Mathf.MoveTowards(Sprite.fillAmount, 0f, Time.deltaTime * Speed);
	}
}
