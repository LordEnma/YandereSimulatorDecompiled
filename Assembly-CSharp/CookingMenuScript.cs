using System.Globalization;
using UnityEngine;

public class CookingMenuScript : MonoBehaviour
{
	public HomeInteractionScript Interaction;

	public InputManagerScript InputManager;

	public HomeWindowScript HomeWindow;

	public HomeYandereScript Yandere;

	public GameObject[] Chopsticks;

	public UILabel[] MealLabels;

	public UILabel[] CostLabels;

	public Transform Highlight;

	public UISprite EatingDesc;

	public UISprite Darkness;

	public UISprite Menu;

	public UILabel MoneyLabel;

	public GameObject Plate;

	public int EatingPhase;

	public int Selected;

	public float[] Costs;

	public bool Eating;

	public bool Show;

	public void UpdateLabels()
	{
		for (int i = 1; i < MealLabels.Length; i++)
		{
			if (PlayerGlobals.Money < Costs[Selected])
			{
				MealLabels[i].alpha = 0.5f;
				CostLabels[i].alpha = 0.5f;
			}
			else
			{
				MealLabels[i].alpha = 1f;
				CostLabels[i].alpha = 1f;
			}
		}
	}

	private void Update()
	{
		if (!Show || !(HomeWindow.Sprite.alpha > 0.99f))
		{
			return;
		}
		if (!Eating)
		{
			if (InputManager.TappedDown)
			{
				Selected++;
				if (Selected > 10)
				{
					Selected = 1;
				}
				UpdateHighlight();
			}
			else if (InputManager.TappedUp)
			{
				Selected--;
				if (Selected < 1)
				{
					Selected = 10;
				}
				UpdateHighlight();
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (MealLabels[Selected].alpha == 1f)
				{
					PlayerGlobals.Money -= Costs[Selected];
					MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
					EatingPhase = 1;
					Eating = true;
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				HomeWindow.Show = false;
				Yandere.CanMove = true;
				Show = false;
			}
		}
		else if (EatingPhase == 1)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha > 0.999f)
			{
				EatingDesc.alpha = 1f;
				Darkness.alpha = 1f;
				Menu.alpha = 0f;
				Yandere.MyController.enabled = false;
				Yandere.HomeCamera.enabled = false;
				Yandere.enabled = false;
				Yandere.transform.position = new Vector3(-5f, -3.033333f, 9.44f);
				Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				Yandere.HomeCamera.transform.position = new Vector3(-5.5f, -1.933333f, 8.75f);
				Yandere.HomeCamera.transform.eulerAngles = new Vector3(15f, 45f, 0f);
				Yandere.CharacterAnimation.Play("f02_eatAtHome_00");
				Yandere.HomeCamera.UpdateDOF(1f);
				Chopsticks[0].SetActive(value: true);
				Chopsticks[1].SetActive(value: true);
				Plate.SetActive(value: true);
				EatingPhase++;
			}
		}
		else if (EatingPhase == 2)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha < 0.0001f && Input.GetButtonDown(InputNames.Xbox_A))
			{
				EatingPhase++;
			}
		}
		else if (EatingPhase == 3)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha > 0.999f)
			{
				EatingDesc.alpha = 0f;
				Darkness.alpha = 1f;
				Yandere.CharacterAnimation.Play(Yandere.IdleAnim);
				Yandere.MyController.enabled = true;
				Yandere.HomeCamera.enabled = true;
				Yandere.enabled = true;
				Yandere.CanMove = true;
				Interaction.Label.enabled = false;
				Interaction.enabled = false;
				Yandere.HomeCamera.UpdateDOF(2f);
				Chopsticks[0].SetActive(value: false);
				Chopsticks[1].SetActive(value: false);
				Plate.SetActive(value: false);
				EatingPhase++;
			}
		}
		else if (EatingPhase == 4)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha < 0.0001f)
			{
				HomeWindow.Sprite.alpha = 0f;
				HomeWindow.Show = false;
				Darkness.alpha = 0f;
				base.enabled = false;
			}
		}
	}

	private void UpdateHighlight()
	{
		Highlight.transform.localPosition = new Vector3(-566.6667f, 300 - 50 * Selected, 0f);
	}
}
