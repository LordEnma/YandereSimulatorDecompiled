using UnityEngine;

public class HomeSenpaiShrineScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public GameObject[] Collectibles;

	public Transform[] Destinations;

	public Transform[] Targets;

	public Transform RightDoor;

	public Transform LeftDoor;

	public UILabel NameLabel;

	public UILabel DescLabel;

	public string[] Names;

	public string[] Descs;

	public float Rotation;

	private int Rows = 5;

	private int Columns = 3;

	private int X = 1;

	private int Y = 3;

	public AudioClip ShrineClose;

	public AudioClip ShrineOpen;

	public bool Open;

	public void Start()
	{
		UpdateText(GetCurrentIndex());
		for (int i = 1; i < 11; i++)
		{
			if (PlayerGlobals.GetShrineCollectible(i))
			{
				Collectibles[i].SetActive(value: true);
			}
		}
	}

	private bool InUpperHalf()
	{
		return Y < 2;
	}

	private int GetCurrentIndex()
	{
		if (InUpperHalf())
		{
			return Y;
		}
		return 2 + (X + (Y - 2) * Columns);
	}

	private void Update()
	{
		if (!HomeYandere.CanMove && !PauseScreen.Show)
		{
			if (HomeCamera.ID == 6)
			{
				Rotation = Mathf.Lerp(Rotation, 135f, Time.deltaTime * 10f);
				RightDoor.localEulerAngles = new Vector3(RightDoor.localEulerAngles.x, Rotation, RightDoor.localEulerAngles.z);
				LeftDoor.localEulerAngles = new Vector3(LeftDoor.localEulerAngles.x, 0f - Rotation, LeftDoor.localEulerAngles.z);
				if (InputManager.TappedUp)
				{
					Y = ((Y > 0) ? (Y - 1) : (Rows - 1));
				}
				if (InputManager.TappedDown)
				{
					Y = ((Y < Rows - 1) ? (Y + 1) : 0);
				}
				if (InputManager.TappedRight && !InUpperHalf())
				{
					X = ((X < Columns - 1) ? (X + 1) : 0);
				}
				if (InputManager.TappedLeft && !InUpperHalf())
				{
					X = ((X > 0) ? (X - 1) : (Columns - 1));
				}
				if (InUpperHalf())
				{
					X = 1;
				}
				int currentIndex = GetCurrentIndex();
				HomeCamera.Destination = Destinations[currentIndex];
				HomeCamera.Target = Targets[currentIndex];
				if (InputManager.TappedUp || InputManager.TappedDown || InputManager.TappedRight || InputManager.TappedLeft)
				{
					UpdateText(currentIndex - 1);
				}
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					HomeCamera.Destination = HomeCamera.Destinations[0];
					HomeCamera.Target = HomeCamera.Targets[0];
					HomeYandere.CanMove = true;
					HomeYandere.gameObject.SetActive(value: true);
					HomeWindow.Show = false;
					AudioSource.PlayClipAtPoint(ShrineClose, HomeCamera.transform.position);
				}
			}
		}
		else if (!Open)
		{
			Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 10f);
			RightDoor.localEulerAngles = new Vector3(RightDoor.localEulerAngles.x, Rotation, RightDoor.localEulerAngles.z);
			LeftDoor.localEulerAngles = new Vector3(LeftDoor.localEulerAngles.x, Rotation, LeftDoor.localEulerAngles.z);
		}
		if (Open)
		{
			Rotation = Mathf.Lerp(Rotation, 135f, Time.deltaTime * 10f);
			RightDoor.localEulerAngles = new Vector3(RightDoor.localEulerAngles.x, Rotation, RightDoor.localEulerAngles.z);
			LeftDoor.localEulerAngles = new Vector3(LeftDoor.localEulerAngles.x, 0f - Rotation, LeftDoor.localEulerAngles.z);
		}
	}

	private void UpdateText(int newIndex)
	{
		if (newIndex == -1)
		{
			newIndex = 10;
		}
		if (newIndex == 0)
		{
			NameLabel.text = Names[newIndex];
			DescLabel.text = Descs[newIndex];
		}
		else if (PlayerGlobals.GetShrineCollectible(newIndex))
		{
			NameLabel.text = Names[newIndex];
			DescLabel.text = Descs[newIndex];
		}
		else
		{
			NameLabel.text = "???";
			DescLabel.text = "I'd like to find something that Senpai touched and keep it here...";
		}
	}
}
