using UnityEngine;

public class HomeInteractionScript : MonoBehaviour
{
	public GameObject ObjectToActivate;

	public HomeYandereScript Yandere;

	public HomeExitScript Exit;

	public UILabel Label;

	public float MinDistance;

	public float Timer;

	public bool Move;

	public int ID;

	private void Update()
	{
		if (Vector3.Distance(Yandere.transform.position, base.transform.position) < MinDistance && !Move)
		{
			Label.alpha = Mathf.MoveTowards(Label.alpha, 1f, Time.deltaTime * 5f);
		}
		else
		{
			Label.alpha = Mathf.MoveTowards(Label.alpha, 0f, Time.deltaTime * 5f);
		}
		if (Label.alpha == 1f && Yandere.CanMove && Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (ID == 1)
			{
				Move = true;
			}
			else if (ID == 2)
			{
				Exit.HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
				Exit.HomeDarkness.FadeOut = true;
				Exit.HomeWindow.Show = false;
				Exit.enabled = false;
				Exit.ID = 3;
				Yandere.CanMove = false;
			}
		}
		if (Move)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-3.163333f, -2.893059f, -1.386f), Time.deltaTime * 5f);
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				ObjectToActivate.SetActive(value: true);
				Label.alpha = 0f;
				base.enabled = false;
			}
		}
	}
}
