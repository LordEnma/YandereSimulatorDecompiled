using UnityEngine;

public class DropsScript : MonoBehaviour
{
	public InfoChanWindowScript InfoChanWindow;

	public InputManagerScript InputManager;

	public InventoryScript Inventory;

	public PromptBarScript PromptBar;

	public SchemesScript Schemes;

	public GameObject FavorMenu;

	public Transform Highlight;

	public UILabel ExplanationLabel;

	public UILabel PantyCount;

	public UITexture DropIcon;

	public UILabel DropDesc;

	public UILabel[] CostLabels;

	public UILabel[] NameLabels;

	public bool[] InfiniteSupply;

	public bool[] Purchased;

	public Texture[] DropIcons;

	public int[] DropCosts;

	public string[] DropDescs;

	public string[] DropNames;

	public int Selected = 1;

	public int ID = 1;

	public AudioClip InfoUnavailable;

	public AudioClip InfoPurchase;

	public AudioClip InfoAfford;

	public float HeldDown;

	public float HeldUp;

	private void Start()
	{
		for (ID = 1; ID < DropNames.Length; ID++)
		{
			NameLabels[ID].text = DropNames[ID];
		}
		if (MissionModeGlobals.MissionMode)
		{
			CostLabels[5].text = "10";
			InfiniteSupply[5] = true;
			DropCosts[5] = 10;
			CostLabels[6].text = "10";
			InfiniteSupply[6] = true;
			DropCosts[6] = 10;
			ExplanationLabel.color = Color.white;
			DropDesc.color = Color.white;
		}
	}

	private void Update()
	{
		if (InputManager.DPadUp || InputManager.StickUp || Input.GetKey("w") || Input.GetKey("up"))
		{
			HeldUp += Time.unscaledDeltaTime;
		}
		else
		{
			HeldUp = 0f;
		}
		if (InputManager.DPadDown || InputManager.StickDown || Input.GetKey("s") || Input.GetKey("down"))
		{
			HeldDown += Time.unscaledDeltaTime;
		}
		else
		{
			HeldDown = 0f;
		}
		if (InputManager.TappedUp || HeldUp > 0.5f)
		{
			if (HeldUp > 0.5f)
			{
				HeldUp = 0.45f;
			}
			Selected--;
			if (Selected < 1)
			{
				Selected = DropNames.Length - 1;
			}
			UpdateDesc();
		}
		if (InputManager.TappedDown || HeldDown > 0.5f)
		{
			if (HeldDown > 0.5f)
			{
				HeldDown = 0.45f;
			}
			Selected++;
			if (Selected > DropNames.Length - 1)
			{
				Selected = 1;
			}
			UpdateDesc();
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			AudioSource component = GetComponent<AudioSource>();
			if (!Purchased[Selected] && InfoChanWindow.Orders < 11)
			{
				if (PromptBar.Label[0].text != string.Empty)
				{
					if (Inventory.PantyShots >= DropCosts[Selected])
					{
						Inventory.PantyShots -= DropCosts[Selected];
						if (!InfiniteSupply[Selected])
						{
							Purchased[Selected] = true;
						}
						InfoChanWindow.Orders++;
						InfoChanWindow.ItemsToDrop[InfoChanWindow.Orders] = Selected;
						InfoChanWindow.DropObject();
						UpdateList();
						UpdateDesc();
						component.clip = InfoPurchase;
						component.Play();
						if (Selected == 2 && SchemeGlobals.GetSchemeStage(3) < 2)
						{
							SchemeGlobals.SetSchemeStage(3, 2);
							Schemes.UpdateInstructions();
						}
					}
				}
				else if (Inventory.PantyShots < DropCosts[Selected])
				{
					Inventory.Yandere.PauseScreen.FavorMenu.Flicker = true;
					component.clip = InfoAfford;
					component.Play();
				}
				else
				{
					component.clip = InfoUnavailable;
					component.Play();
				}
			}
			else
			{
				component.clip = InfoUnavailable;
				component.Play();
			}
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[5].text = "Choose";
			PromptBar.UpdateButtons();
			FavorMenu.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateList()
	{
		for (ID = 1; ID < DropNames.Length; ID++)
		{
			UILabel uILabel = NameLabels[ID];
			if (!Purchased[ID])
			{
				CostLabels[ID].text = DropCosts[ID].ToString();
				uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 1f);
			}
			else
			{
				CostLabels[ID].text = string.Empty;
				uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
			}
		}
	}

	public void UpdateDesc()
	{
		if (!Purchased[Selected])
		{
			if (Inventory.PantyShots >= DropCosts[Selected])
			{
				PromptBar.Label[0].text = "Purchase";
				PromptBar.UpdateButtons();
			}
			else
			{
				PromptBar.Label[0].text = string.Empty;
				PromptBar.UpdateButtons();
			}
		}
		else
		{
			PromptBar.Label[0].text = string.Empty;
			PromptBar.UpdateButtons();
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 200f - 25f * (float)Selected, Highlight.localPosition.z);
		DropIcon.mainTexture = DropIcons[Selected];
		DropDesc.text = DropDescs[Selected];
		UpdatePantyCount();
	}

	public void UpdatePantyCount()
	{
		PantyCount.text = Inventory.PantyShots.ToString();
	}
}
