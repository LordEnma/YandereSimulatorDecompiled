using UnityEngine;

public class HomeInteractionScript : MonoBehaviour
{
	public GameObject ObjectToActivate;

	public HomeYandereScript Yandere;

	public HomeExitScript Exit;

	public UILabel Label;

	public Transform[] Door;

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
			if (ID == 1 || ID == 3)
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
		if (!Move)
		{
			return;
		}
		if (ID == 1)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-3.163333f, -2.893059f, -1.386f), Time.deltaTime * 5f);
		}
		else
		{
			Door[0].localPosition = Vector3.Lerp(Door[0].localPosition, new Vector3(-0.059f, -0.09082f, 0.00141f), Time.deltaTime * 5f);
			Door[1].localPosition = Vector3.Lerp(Door[1].localPosition, new Vector3(-0.0345f, -0.09082f, 0.00141f), Time.deltaTime * 5f);
		}
		Timer += Time.deltaTime;
		if (Timer > 1f)
		{
			if (ObjectToActivate != null)
			{
				ObjectToActivate.SetActive(value: true);
			}
			Label.alpha = 0f;
			base.enabled = false;
		}
	}
}
