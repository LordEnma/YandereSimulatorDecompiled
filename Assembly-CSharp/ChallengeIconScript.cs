using UnityEngine;

public class ChallengeIconScript : MonoBehaviour
{
	public UITexture LargeIcon;

	public UISprite IconFrame;

	public UISprite NameFrame;

	public UITexture Icon;

	public UILabel Name;

	public float Dark;

	private float R;

	private float G;

	private float B;

	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			R = 1f;
			G = 0f;
			B = 0f;
		}
		else
		{
			R = 1f;
			G = 1f;
			B = 1f;
		}
	}

	private void Update()
	{
		if (base.transform.position.x > -0.125f && base.transform.position.x < 0.125f)
		{
			if (Icon != null)
			{
				LargeIcon.mainTexture = Icon.mainTexture;
			}
			Dark -= Time.deltaTime * 10f;
			if (Dark < 0f)
			{
				Dark = 0f;
			}
		}
		else
		{
			Dark += Time.deltaTime * 10f;
			if (Dark > 1f)
			{
				Dark = 1f;
			}
		}
		IconFrame.color = new Color(Dark * R, Dark * G, Dark * B, 1f);
		NameFrame.color = new Color(Dark * R, Dark * G, Dark * B, 1f);
		Name.color = new Color(Dark * R, Dark * G, Dark * B, 1f);
		if (GameGlobals.LoveSick)
		{
			if (base.transform.position.x > -0.125f && base.transform.position.x < 0.125f)
			{
				IconFrame.color = Color.white;
				NameFrame.color = Color.white;
				Name.color = Color.white;
			}
			else
			{
				IconFrame.color = new Color(R, G, B, 1f);
				NameFrame.color = new Color(R, G, B, 1f);
				Name.color = new Color(R, G, B, 1f);
			}
		}
	}
}
