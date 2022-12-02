using UnityEngine;

public class HomePantyChangerScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	private GameObject NewPanties;

	public UILabel PantyNameLabel;

	public UILabel PantyDescLabel;

	public UILabel PantyBuffLabel;

	public UILabel ButtonLabel;

	public Transform PantyParent;

	public bool DestinationReached;

	public float TargetRotation;

	public float Rotation;

	public int TotalPanties;

	public int Selected;

	public GameObject[] PantyModels;

	public string[] PantyNames;

	public string[] PantyDescs;

	public string[] PantyBuffs;

	public AudioClip ChangeSelection;

	public AudioClip MakeSelection;

	public AudioClip CloseDrawer;

	private void Start()
	{
		for (int i = 0; i < TotalPanties; i++)
		{
			NewPanties = Object.Instantiate(PantyModels[i], new Vector3(base.transform.position.x, base.transform.position.y - 0.85f, base.transform.position.z - 1f), Quaternion.identity);
			NewPanties.transform.parent = PantyParent;
			NewPanties.GetComponent<HomePantiesScript>().PantyChanger = this;
			NewPanties.GetComponent<HomePantiesScript>().ID = i;
			PantyParent.transform.localEulerAngles = new Vector3(PantyParent.transform.localEulerAngles.x, PantyParent.transform.localEulerAngles.y + 360f / (float)TotalPanties, PantyParent.transform.localEulerAngles.z);
		}
		PantyParent.transform.localEulerAngles = new Vector3(PantyParent.transform.localEulerAngles.x, 0f, PantyParent.transform.localEulerAngles.z);
		PantyParent.transform.localPosition = new Vector3(PantyParent.transform.localPosition.x, PantyParent.transform.localPosition.y, 1.8f);
		UpdatePantyLabels();
		PantyParent.transform.localScale = Vector3.zero;
		PantyParent.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (HomeWindow.Show)
		{
			PantyParent.localScale = Vector3.Lerp(PantyParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			PantyParent.gameObject.SetActive(true);
			if (InputManager.TappedRight)
			{
				DestinationReached = false;
				TargetRotation += 360f / (float)TotalPanties;
				Selected++;
				if (Selected > TotalPanties - 1)
				{
					Selected = 0;
				}
				AudioSource.PlayClipAtPoint(ChangeSelection, base.transform.position);
				UpdatePantyLabels();
			}
			if (InputManager.TappedLeft)
			{
				DestinationReached = false;
				TargetRotation -= 360f / (float)TotalPanties;
				Selected--;
				if (Selected < 0)
				{
					Selected = TotalPanties - 1;
				}
				AudioSource.PlayClipAtPoint(ChangeSelection, base.transform.position);
				UpdatePantyLabels();
			}
			Rotation = Mathf.Lerp(Rotation, TargetRotation, Time.deltaTime * 10f);
			PantyParent.localEulerAngles = new Vector3(PantyParent.localEulerAngles.x, Rotation, PantyParent.localEulerAngles.z);
			if (Input.GetButtonDown("A"))
			{
				if (Selected == 0 || CollectibleGlobals.GetPantyPurchased(Selected))
				{
					PlayerGlobals.PantiesEquipped = Selected;
					Debug.Log("Yandere-chan should now be equipped with Panties #" + PlayerGlobals.PantiesEquipped);
					AudioSource.PlayClipAtPoint(MakeSelection, base.transform.position);
				}
				else
				{
					Debug.Log("Yandere-chan doesn't own those panties.");
				}
				UpdatePantyLabels();
			}
			if (Input.GetButtonDown("B"))
			{
				HomeCamera.Destination = HomeCamera.Destinations[0];
				HomeCamera.Target = HomeCamera.Targets[0];
				HomeYandere.CanMove = true;
				HomeWindow.Show = false;
				AudioSource.PlayClipAtPoint(CloseDrawer, base.transform.position);
			}
			if (Input.GetKeyDown("z"))
			{
				CollectibleGlobals.SetPantyPurchased(1, true);
				CollectibleGlobals.SetPantyPurchased(2, true);
				CollectibleGlobals.SetPantyPurchased(3, true);
				CollectibleGlobals.SetPantyPurchased(4, true);
				CollectibleGlobals.SetPantyPurchased(5, true);
				CollectibleGlobals.SetPantyPurchased(6, true);
				CollectibleGlobals.SetPantyPurchased(7, true);
				CollectibleGlobals.SetPantyPurchased(8, true);
				CollectibleGlobals.SetPantyPurchased(9, true);
				CollectibleGlobals.SetPantyPurchased(10, true);
				CollectibleGlobals.SetPantyPurchased(11, true);
			}
		}
		else
		{
			PantyParent.localScale = Vector3.Lerp(PantyParent.localScale, Vector3.zero, Time.deltaTime * 10f);
			if (PantyParent.localScale.x < 0.01f)
			{
				PantyParent.gameObject.SetActive(false);
			}
		}
	}

	private void UpdatePantyLabels()
	{
		if (Selected == 0 || CollectibleGlobals.GetPantyPurchased(Selected))
		{
			PantyNameLabel.text = PantyNames[Selected];
			PantyDescLabel.text = PantyDescs[Selected];
			PantyBuffLabel.text = PantyBuffs[Selected];
		}
		else
		{
			PantyNameLabel.text = "?????";
			PantyBuffLabel.text = "?????";
			if (Selected < 11)
			{
				PantyDescLabel.text = "Unlock these panties by purchasing them from the lingerie store in town!";
			}
			else
			{
				PantyDescLabel.text = "Unlock these panties by locating them and picking them up!";
			}
		}
		if (Selected == 0 || CollectibleGlobals.GetPantyPurchased(Selected))
		{
			ButtonLabel.text = ((Selected == PlayerGlobals.PantiesEquipped) ? "Equipped" : "Wear");
		}
		else
		{
			ButtonLabel.text = "Unavailable";
		}
	}
}
