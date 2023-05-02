using UnityEngine;

public class ChallengeScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public CalendarScript Calendar;

	public GameObject ViewButton;

	public Transform Arrows;

	public Transform[] ChallengeList;

	public int[] Challenges;

	public UIPanel[] Panels;

	public UIPanel ChallengePanel;

	public UIPanel CalendarPanel;

	public UITexture LargeIcon;

	public UISprite Shadow;

	public bool Viewing;

	public bool Switch;

	public int Phase = 1;

	public int List;

	private void Update()
	{
		if (!Viewing)
		{
			if (!Switch)
			{
				if (InputManager.TappedUp || InputManager.TappedDown)
				{
					if (List == 0)
					{
						Arrows.localPosition = new Vector3(Arrows.localPosition.x, -300f, Arrows.localPosition.z);
						ViewButton.SetActive(value: true);
						Panels[0].alpha = 0.5f;
						Panels[1].alpha = 1f;
						List = 1;
					}
					else
					{
						Arrows.localPosition = new Vector3(Arrows.localPosition.x, 200f, Arrows.localPosition.z);
						ViewButton.SetActive(value: false);
						Panels[0].alpha = 1f;
						Panels[1].alpha = 0.5f;
						List = 0;
					}
				}
				Transform transform = ChallengeList[List];
				if (InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
				{
					transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * 1000f, transform.localPosition.y, transform.localPosition.z);
				}
				if (InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
				{
					transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime * 1000f, transform.localPosition.y, transform.localPosition.z);
				}
				transform.localPosition = new Vector3(transform.localPosition.x + Input.GetAxis("Horizontal") * -10f, transform.localPosition.y, transform.localPosition.z);
				if (transform.localPosition.x > 500f)
				{
					transform.localPosition = new Vector3(500f, transform.localPosition.y, transform.localPosition.z);
				}
				else if (transform.localPosition.x < -250f * ((float)Challenges[List] - 3f))
				{
					transform.localPosition = new Vector3(-250f * ((float)Challenges[List] - 3f), transform.localPosition.y, transform.localPosition.z);
				}
				if (LargeIcon.color.a > 0f)
				{
					LargeIcon.color = new Color(LargeIcon.color.r, LargeIcon.color.g, LargeIcon.color.b, LargeIcon.color.a - Time.deltaTime * 10f);
					if (LargeIcon.color.a < 0f)
					{
						LargeIcon.color = new Color(LargeIcon.color.r, LargeIcon.color.g, LargeIcon.color.b, 0f);
					}
				}
			}
		}
		else if (LargeIcon.color.a < 1f)
		{
			LargeIcon.color = new Color(LargeIcon.color.r, LargeIcon.color.g, LargeIcon.color.b, LargeIcon.color.a + Time.deltaTime * 10f);
			if (LargeIcon.color.a > 1f)
			{
				LargeIcon.color = new Color(LargeIcon.color.r, LargeIcon.color.g, LargeIcon.color.b, 1f);
			}
		}
		Shadow.color = new Color(Shadow.color.r, Shadow.color.g, Shadow.color.b, LargeIcon.color.a * 0.75f);
		if (!Switch && Input.GetButtonDown(InputNames.Xbox_A) && List == 1)
		{
			Viewing = true;
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			if (Viewing)
			{
				Viewing = false;
			}
			else
			{
				Switch = true;
			}
		}
		if (!Switch)
		{
			return;
		}
		if (Phase == 1)
		{
			ChallengePanel.alpha -= Time.deltaTime;
			if (ChallengePanel.alpha <= 0f)
			{
				Phase++;
			}
			return;
		}
		CalendarPanel.alpha += Time.deltaTime;
		if (CalendarPanel.alpha >= 1f)
		{
			Calendar.enabled = true;
			base.enabled = false;
			Switch = false;
			Phase = 1;
		}
	}
}
