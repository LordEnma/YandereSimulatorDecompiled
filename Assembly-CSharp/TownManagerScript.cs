using UnityEngine;
using UnityEngine.SceneManagement;

public class TownManagerScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public TownMapScript TownMap;

	public UISprite Darkness;

	public int DestinationID;

	public int MapTimer;

	public AudioSource BGM;

	public bool FadeIn;

	public Transform[] TeleportPoints;

	private void Start()
	{
		Darkness.alpha = 1f;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		if (FadeIn)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.2f);
		}
		else
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			BGM.volume = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 2f);
			Time.timeScale = 1f;
			if (Darkness.alpha > 0.999f)
			{
				if (DestinationID == 1)
				{
					SceneManager.LoadScene("LoadingScene");
				}
				else if (DestinationID == 2)
				{
					SceneManager.LoadScene("HomeScene");
				}
				else if (DestinationID == 3)
				{
					SceneManager.LoadScene("StreetScene");
				}
			}
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale = 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale++;
		}
		if ((Yandere.CanMove && !Yandere.PausePanel.enabled && MapTimer < 1 && Input.GetButtonDown(InputNames.Xbox_Back)) || (Yandere.CanMove && !Yandere.PausePanel.enabled && MapTimer < 1 && Input.GetKeyDown("space")))
		{
			Debug.Log("Now entering the map screen.");
			Yandere.CanMove = false;
			TownMap.transform.parent.gameObject.SetActive(value: true);
		}
		if (Yandere.CanMove)
		{
			MapTimer--;
		}
		if (Input.GetKeyDown("1"))
		{
			Yandere.transform.position = TeleportPoints[1].position;
			Physics.SyncTransforms();
		}
		if (Input.GetKeyDown("2"))
		{
			Yandere.transform.position = TeleportPoints[2].position;
			Physics.SyncTransforms();
		}
		if (Input.GetKeyDown("3"))
		{
			Yandere.transform.position = TeleportPoints[3].position;
			Physics.SyncTransforms();
		}
		if (Input.GetKeyDown("4"))
		{
			Yandere.transform.position = TeleportPoints[4].position;
			Physics.SyncTransforms();
		}
		if (Input.GetKeyDown("5"))
		{
			Yandere.transform.position = TeleportPoints[5].position;
			Physics.SyncTransforms();
		}
		if (Input.GetKeyDown("6"))
		{
			Yandere.transform.position = TeleportPoints[6].position;
			Physics.SyncTransforms();
		}
	}
}
