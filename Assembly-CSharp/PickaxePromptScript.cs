using UnityEngine;
using UnityEngine.SceneManagement;

public class PickaxePromptScript : MonoBehaviour
{
	public PassTimeBookScript PassTimeBook;

	public Collider CutsceneStarter;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public GameObject[] Rocks;

	public UISprite Darkness;

	public float Progress;

	public bool FadeOut;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
			base.gameObject.SetActive(value: false);
		}
		else
		{
			Progress = GameGlobals.RockProgress;
			UpdateRocks();
		}
	}

	private void Update()
	{
		if (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.WeaponID == 46 && Progress < 100f)
		{
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				PassTimeBook.IncreaseRockProgress = true;
				PassTimeBook.TryToPassTime();
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
			if (Progress >= 100f && CutsceneStarter.bounds.Contains(Prompt.Yandere.transform.position))
			{
				if (!FadeOut)
				{
					Prompt.Yandere.CharacterAnimation.CrossFade(Prompt.Yandere.IdleAnim);
					Prompt.Yandere.CanMove = false;
					Prompt.Yandere.EmptyHands();
					FadeOut = true;
				}
				else
				{
					Prompt.Yandere.Jukebox.Volume -= Time.deltaTime * 0.2f;
					Darkness.alpha += Time.deltaTime * 0.2f;
					Darkness.enabled = true;
					if (Darkness.alpha >= 1f)
					{
						SceneManager.LoadScene("SwordScene");
					}
				}
			}
		}
		if (!Prompt.Yandere.NoDebug && Vector3.Distance(base.transform.position, Prompt.Yandere.transform.position) < 2f && Input.GetKeyDown("z"))
		{
			Progress += 4f;
			UpdateRocks();
			DisplayProgress();
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	public void UpdateRocks()
	{
		int num = Mathf.FloorToInt(Progress / 10f);
		for (int i = 1; i <= num && i < Rocks.Length; i++)
		{
			Rocks[i].SetActive(value: false);
		}
	}

	public void DisplayProgress()
	{
		if (Progress > 100f)
		{
			Progress = 100f;
		}
		Prompt.Yandere.NotificationManager.CustomText = "Progress: " + Progress + "/100";
	}
}
