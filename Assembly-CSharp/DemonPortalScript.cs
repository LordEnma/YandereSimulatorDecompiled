using UnityEngine;

public class DemonPortalScript : MonoBehaviour
{
	public YandereScript Yandere;

	public JukeboxScript Jukebox;

	public PromptScript Prompt;

	public ClockScript Clock;

	public AudioSource DemonRealmAudio;

	public GameObject HeartbeatCamera;

	public GameObject DarkAura;

	public GameObject FPS;

	public GameObject HUD;

	public UISprite Darkness;

	public float Timer;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Yandere.Character.GetComponent<Animation>().CrossFade(Yandere.IdleAnim);
			Yandere.CanMove = false;
			Object.Instantiate(DarkAura, Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			Timer += Time.deltaTime;
		}
		DemonRealmAudio.volume = Mathf.MoveTowards(DemonRealmAudio.volume, (Yandere.transform.position.y > 1000f) ? 0.5f : 0f, Time.deltaTime * 0.1f);
		if (!(Timer > 0f))
		{
			return;
		}
		if (Yandere.transform.position.y > 1000f)
		{
			Timer += Time.deltaTime;
			if (Timer > 4f)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				if (Darkness.color.a == 1f)
				{
					Yandere.transform.position = new Vector3(12f, 0f, 28f);
					Yandere.Character.SetActive(true);
					Yandere.SetAnimationLayers();
					HeartbeatCamera.SetActive(true);
					FPS.SetActive(true);
					HUD.SetActive(true);
				}
			}
			else if (Timer > 1f)
			{
				Yandere.Character.SetActive(false);
			}
			return;
		}
		Jukebox.Volume = Mathf.MoveTowards(Jukebox.Volume, 0.5f, Time.deltaTime * 0.5f);
		if (Jukebox.Volume == 0.5f)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			if (Darkness.color.a == 0f)
			{
				base.transform.parent.gameObject.SetActive(false);
				Darkness.enabled = false;
				Yandere.CanMove = true;
				Clock.StopTime = false;
				Timer = 0f;
			}
		}
	}
}
