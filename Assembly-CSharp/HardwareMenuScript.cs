using UnityEngine;

public class HardwareMenuScript : MonoBehaviour
{
	public HomeDarknessScript HomeDarkness;

	public InputManagerScript InputManager;

	public HomeYandereScript Yandere;

	public PromptBarScript PromptBar;

	public UILabel DescLabel;

	public UIPanel Panel;

	public GameObject ConfirmationWindow;

	public GameObject DuffleWindow;

	public Transform Highlight;

	public Transform CloseUp;

	public GameObject[] Hardware;

	public UILabel[] Labels;

	public Vector3[] OriginalPos;

	public Vector3[] OriginalRot;

	public Vector3[] ZoomPos;

	public Vector3[] ZoomRot;

	public string[] Descriptions;

	public Vector3 PlayerPosition;

	public bool Show;

	public Vector3 Rotation;

	public int Selected;

	private void Start()
	{
		Panel.enabled = false;
		for (int i = 1; i < 11; i++)
		{
			OriginalRot[i] = Hardware[i].transform.eulerAngles;
			OriginalPos[i] = Hardware[i].transform.position;
			if (!CollectibleGlobals.GetHardwarePurchased(i))
			{
				Hardware[i].gameObject.SetActive(value: false);
				Labels[i].alpha = 0.5f;
			}
		}
		Selected = 1;
		UpdateHighlight();
	}

	private void Update()
	{
		if (Show && !HomeDarkness.FadeOut)
		{
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 1f, Time.deltaTime * 10f);
			int num = 1;
			if (!ConfirmationWindow.activeInHierarchy)
			{
				for (num = 1; num < 11; num++)
				{
					if (num != Selected)
					{
						Hardware[num].transform.eulerAngles = OriginalRot[num];
						Hardware[num].transform.position = Vector3.Lerp(Hardware[num].transform.position, OriginalPos[num], Time.deltaTime * 10f);
					}
					else
					{
						Rotation = Vector3.Lerp(Rotation, ZoomRot[num], Time.deltaTime * 10f);
						Hardware[num].transform.eulerAngles = Rotation;
						Hardware[num].transform.position = Vector3.Lerp(Hardware[num].transform.position, CloseUp.position + ZoomPos[num], Time.deltaTime * 10f);
					}
				}
				if (InputManager.TappedDown)
				{
					Selected++;
					if (Selected > 10)
					{
						Selected = 1;
					}
					UpdateHighlight();
				}
				if (InputManager.TappedUp)
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
					if (Panel.alpha > 0.999f && Hardware[Selected].activeInHierarchy && Selected < 10)
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Confirm";
						PromptBar.Label[1].text = "Back";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						ConfirmationWindow.SetActive(value: true);
					}
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					Yandere.transform.localScale = new Vector3(1f, 1f, 1f);
					Yandere.transform.position = PlayerPosition;
					Yandere.MyController.enabled = true;
					Yandere.HomeCamera.UpdateDOF(2f);
					Yandere.CanMove = true;
					PromptBar.ClearButtons();
					PromptBar.Show = false;
					for (num = 1; num < 11; num++)
					{
						Hardware[num].transform.eulerAngles = OriginalRot[num];
						Hardware[num].transform.position = OriginalPos[num];
					}
					Show = false;
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (Hardware[Selected].activeInHierarchy)
				{
					PlayerGlobals.BringingHardware = Selected;
					HomeDarkness.FadeOut = true;
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				ConfirmationWindow.SetActive(value: false);
				UpdateHighlight();
			}
			if (!Input.GetKeyDown("z"))
			{
				return;
			}
			if (PlayerGlobals.Money == 10f)
			{
				PlayerGlobals.Money = 100f;
				for (num = 1; num < 11; num++)
				{
					CollectibleGlobals.SetHardwarePurchased(num, value: true);
				}
			}
			else if (PlayerGlobals.Money == 100f)
			{
				PlayerGlobals.Money = 1000f;
				CollectibleGlobals.SetHardwarePurchased(1, value: true);
				CollectibleGlobals.SetHardwarePurchased(2, value: false);
				CollectibleGlobals.SetHardwarePurchased(3, value: true);
				CollectibleGlobals.SetHardwarePurchased(4, value: false);
				CollectibleGlobals.SetHardwarePurchased(5, value: true);
				CollectibleGlobals.SetHardwarePurchased(6, value: false);
				CollectibleGlobals.SetHardwarePurchased(7, value: true);
				CollectibleGlobals.SetHardwarePurchased(8, value: false);
				CollectibleGlobals.SetHardwarePurchased(9, value: true);
				CollectibleGlobals.SetHardwarePurchased(10, value: false);
			}
			else if (PlayerGlobals.Money == 1000f)
			{
				PlayerGlobals.Money = 10f;
				for (num = 1; num < 11; num++)
				{
					CollectibleGlobals.SetHardwarePurchased(num, value: false);
				}
			}
		}
		else
		{
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 0f, Time.deltaTime * 10f);
		}
	}

	public void UpdateHighlight()
	{
		Highlight.transform.localPosition = new Vector3(-825f, 440 - 80 * Selected, 0f);
		if (!Input.GetButtonDown(InputNames.Xbox_B))
		{
			Rotation = Hardware[Selected].transform.eulerAngles;
		}
		DescLabel.text = Descriptions[Selected];
		if (Selected == 1)
		{
			DuffleWindow.SetActive(value: false);
		}
		else
		{
			DuffleWindow.SetActive(value: true);
		}
		if (!ConfirmationWindow.activeInHierarchy)
		{
			PromptBar.ClearButtons();
			if (Hardware[Selected].activeInHierarchy && Selected < 10)
			{
				PromptBar.Label[0].text = "Select";
			}
			PromptBar.Label[1].text = "Back";
			PromptBar.Label[4].text = "Change";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
		}
	}
}
