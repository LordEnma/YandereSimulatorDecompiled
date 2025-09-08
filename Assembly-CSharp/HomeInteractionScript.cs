using UnityEngine;

public class HomeInteractionScript : MonoBehaviour
{
	public HardwareMenuScript HardwareMenu;

	public CookingMenuScript CookingMenu;

	public CarrotMenuScript CarrotMenu;

	public GameObject ObjectToActivate;

	public GameObject[] ObjectsToActivate;

	public HomeYandereScript Yandere;

	public PromptBarScript PromptBar;

	public HomeExitScript Exit;

	public UILabel Label;

	public Transform[] Door;

	public Vector3 OriginalPos;

	public Vector3 OriginalRot;

	public float MinDistance;

	public float Timer;

	public bool DisableInEighties;

	public bool SlideInOut;

	public bool Move;

	public int ID;

	public AudioSource MyAudio;

	private void Start()
	{
		if (ID == 6 && TaskGlobals.GetTaskStatus(22) != 1)
		{
			Label.enabled = false;
			base.enabled = false;
			if (TaskGlobals.GetTaskStatus(22) == 3)
			{
				ObjectToActivate.SetActive(value: false);
			}
		}
		if (DisableInEighties && GameGlobals.Eighties)
		{
			base.gameObject.SetActive(value: false);
			Label.alpha = 0f;
			Label.enabled = false;
			base.enabled = false;
		}
	}

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
				if (ID == 3)
				{
					MyAudio.Play();
				}
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
			else if (ID == 4)
			{
				HardwareMenu.PlayerPosition = Yandere.transform.position;
				Yandere.transform.position = new Vector3(-18.5685f, -3.112333f, 10.1977f);
				Yandere.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
				Yandere.MyController.enabled = false;
				Yandere.CanMove = false;
				HardwareMenu.ZoomPos[9] = new Vector3(0f, -0.5f, -0.5f);
				HardwareMenu.ZoomRot[9] = new Vector3(-45f, -45f, 90f);
				HardwareMenu.Panel.enabled = true;
				HardwareMenu.UpdateHighlight();
				HardwareMenu.Show = true;
				Yandere.HomeCamera.UpdateDOF(1f);
			}
			else if (ID == 5)
			{
				Yandere.CanMove = false;
				CookingMenu.HomeWindow.Show = true;
				CookingMenu.UpdateLabels();
				CookingMenu.Show = true;
			}
			else if (ID == 6)
			{
				Yandere.CanMove = false;
				CarrotMenu.Show = true;
			}
			else if (ID == 7)
			{
				ObjectToActivate.SetActive(value: true);
				Yandere.HomeCamera.PromptBar.ClearButtons();
				Yandere.HomeCamera.PromptBar.Label[1].text = "Back";
				Yandere.HomeCamera.PromptBar.Label[4].text = "Change Selection";
				Yandere.HomeCamera.PromptBar.Label[5].text = "Change Hair";
				Yandere.HomeCamera.PromptBar.UpdateButtons();
				Yandere.HomeCamera.PromptBar.Show = true;
				Yandere.CanMove = false;
				Yandere.HomeCamera.enabled = false;
				Yandere.MyController.enabled = false;
				Yandere.HomeCamera.RoomJukebox.volume = 0f;
				Yandere.HomeCamera.DayLight.SetActive(value: false);
				Yandere.CharacterAnimation.Play(Yandere.IdleAnim);
				OriginalPos = Yandere.transform.position;
				OriginalRot = Yandere.transform.eulerAngles;
				Yandere.transform.position = new Vector3(0f, 200f, 0f);
				Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
			}
		}
		if (Move)
		{
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
		if (SlideInOut)
		{
			Timer += Time.deltaTime;
			if (ObjectToActivate.transform.localPosition.x < -1250f)
			{
				ObjectToActivate.transform.localPosition = new Vector3(1251f, 0f, 0f);
				ObjectToActivate.SetActive(value: false);
				SlideInOut = false;
			}
			if (Timer < 2f)
			{
				ObjectToActivate.transform.localPosition = Vector3.Lerp(ObjectToActivate.transform.localPosition, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			}
			else
			{
				ObjectToActivate.transform.localPosition += new Vector3((2f - Timer) * 5f, 0f, 0f);
			}
		}
	}
}
