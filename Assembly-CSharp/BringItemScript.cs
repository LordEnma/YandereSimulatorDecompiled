using UnityEngine;

public class BringItemScript : MonoBehaviour
{
	public HardwareMenuScript HardwareMenu;

	public InputManagerScript InputManager;

	public HomeWindowScript HomeWindow;

	public HomeExitScript HomeExit;

	public GameObject HardwareButton;

	public GameObject Checkmark;

	public string[] Descriptions;

	public UILabel[] Labels;

	public Transform Highlight;

	public UILabel DescLabel;

	public bool Initialized;

	public int Limit = 12;

	public int ID = 1;

	private void Initialize()
	{
		for (int i = 1; i < 8; i++)
		{
			if (PlayerGlobals.GetCannotBringItem(i))
			{
				Labels[i].color = new Color(1f, 1f, 1f, 0.5f);
			}
			else
			{
				Labels[i].color = new Color(1f, 1f, 1f, 1f);
			}
		}
		if (PlayerGlobals.BringingItem != 0)
		{
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 50f - (float)PlayerGlobals.BringingItem * 50f, Highlight.localPosition.z);
			Checkmark.transform.localPosition = new Vector3(300f, Highlight.localPosition.y, 0f);
			Checkmark.SetActive(value: true);
		}
		if (PlayerGlobals.BoughtLockpick)
		{
			Labels[8].alpha = 1f;
		}
		if (PlayerGlobals.BoughtSedative)
		{
			Labels[9].alpha = 1f;
		}
		if (PlayerGlobals.BoughtNarcotics)
		{
			Labels[10].alpha = 1f;
		}
		if (PlayerGlobals.BoughtPoison)
		{
			Labels[11].alpha = 1f;
		}
		if (PlayerGlobals.BoughtExplosive)
		{
			Labels[12].alpha = 1f;
		}
		DescLabel.text = Descriptions[ID];
	}

	private void Update()
	{
		if (!Initialized)
		{
			Initialize();
			Initialized = true;
		}
		if (!(HomeWindow.Sprite.color.a > 0.9f))
		{
			return;
		}
		if (InputManager.TappedDown)
		{
			ID++;
			if (ID > Limit)
			{
				ID = 1;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 50f - (float)ID * 50f, Highlight.localPosition.z);
			DescLabel.text = Descriptions[ID];
		}
		if (InputManager.TappedUp)
		{
			ID--;
			if (ID < 1)
			{
				ID = Limit;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 50f - (float)ID * 50f, Highlight.localPosition.z);
			DescLabel.text = Descriptions[ID];
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (Labels[ID].color.a == 1f)
			{
				if (PlayerGlobals.BringingItem != ID)
				{
					Checkmark.transform.localPosition = new Vector3(300f, Highlight.localPosition.y, 0f);
					Checkmark.SetActive(value: true);
					PlayerGlobals.BringingItem = ID;
				}
				else
				{
					Checkmark.SetActive(value: false);
					PlayerGlobals.BringingItem = 0;
				}
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			HomeExit.HomeWindow.Show = true;
			HomeWindow.Show = false;
		}
		else if (Input.GetButtonDown(InputNames.Xbox_X))
		{
			HomeExit.HomeWindow.Show = true;
			HomeWindow.Show = false;
			HomeExit.GoToSchool();
		}
		else if (HardwareButton.activeInHierarchy && Input.GetButtonDown(InputNames.Xbox_Y))
		{
			HardwareMenu.PlayerPosition = HomeExit.HomeYandere.transform.position;
			if (HomeExit.HomeYandere.transform.position.y > -4f)
			{
				HomeExit.HomeYandere.transform.position = new Vector3(-18.5685f, -3.112333f, 10.1977f);
			}
			else
			{
				HomeExit.HomeYandere.transform.position = new Vector3(-18.5685f, -10f, 10.1977f);
			}
			HomeExit.HomeYandere.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			HomeExit.HomeYandere.MyController.enabled = false;
			HomeExit.HomeYandere.CanMove = false;
			HardwareMenu.ZoomPos[9] = new Vector3(-0.1f, -0.05f, -0.15f);
			HardwareMenu.ZoomRot[9] = new Vector3(-30f, -45f, 90f);
			HardwareMenu.Panel.enabled = true;
			HardwareMenu.UpdateHighlight();
			HardwareMenu.Show = true;
			HomeExit.HomeYandere.HomeCamera.UpdateDOF(1f);
			HomeExit.HomeWindow.Show = false;
			HomeWindow.Show = false;
		}
	}
}
