using UnityEngine;
using UnityEngine.SceneManagement;

public class ThanksForPlayingScript : MonoBehaviour
{
	public CameraEffectsScript CameraEffects;

	public ParticleSystem[] Hearts;

	public UIPanel ThankYouPanel;

	public UIPanel FinalGamePanel;

	public UIPanel RivalPanel;

	public UIPanel QualityPanel;

	public UIPanel WeaponsPanel;

	public UIPanel StoryPanel;

	public UIPanel MorePanel;

	public UIPanel CrowdfundPanel;

	public UIPanel SkipPanel;

	public AudioSource Jukebox;

	public Transform Yandere;

	public UISprite SkipCircle;

	public UISprite Darkness;

	public Animation YandereKun;

	public Animation Ryoba;

	public bool FadeOut;

	public float Alpha;

	private void Start()
	{
		Ryoba["f02_faceCouncilGrace_00"].layer = 1;
		Ryoba.Play("f02_faceCouncilGrace_00");
		YandereKun["AltYanKunFace"].layer = 1;
		YandereKun.Play("AltYanKunFace");
		Darkness.color = new Color(0f, 0f, 0f, 1f);
		SkipPanel.alpha = 0f;
		Alpha = 1f;
		CameraEffects.UpdateDOF(2f);
		CameraEffects.UpdateBloom(1f);
		CameraEffects.UpdateBloomKnee(0.5f);
		CameraEffects.UpdateBloomRadius(4f);
	}

	private void Update()
	{
		if (!FadeOut)
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.5f);
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
			if (Alpha == 0f)
			{
				SkipPanel.alpha += Time.deltaTime;
			}
		}
		else
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.5f);
			Darkness.color = new Color(1f, 1f, 1f, Alpha);
			Jukebox.volume -= Time.deltaTime * 0.5f;
			if (Alpha == 1f)
			{
				SceneManager.LoadScene("NewTitleScene");
			}
		}
		if (SkipPanel.alpha == 1f)
		{
			if (Input.GetButton(InputNames.Xbox_X))
			{
				SkipCircle.fillAmount -= Time.deltaTime;
				if (SkipCircle.fillAmount == 0f)
				{
					FadeOut = true;
				}
			}
			else
			{
				SkipCircle.fillAmount = 1f;
			}
		}
		if (Input.GetKeyDown("=") && Time.timeScale < 10f)
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("-") && Time.timeScale > 1f)
		{
			Time.timeScale -= 1f;
		}
		if (Yandere.position.z > 1f && Yandere.position.z < 10f)
		{
			ThankYouPanel.alpha = Mathf.MoveTowards(ThankYouPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			ThankYouPanel.alpha = Mathf.MoveTowards(ThankYouPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (Yandere.position.z > 20f && Yandere.position.z < 120f)
		{
			FinalGamePanel.alpha = Mathf.MoveTowards(FinalGamePanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			FinalGamePanel.alpha = Mathf.MoveTowards(FinalGamePanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (Yandere.position.z > 30f && Yandere.position.z < 40f)
		{
			RivalPanel.alpha = Mathf.MoveTowards(RivalPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			RivalPanel.alpha = Mathf.MoveTowards(RivalPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (Yandere.position.z > 50f && Yandere.position.z < 60f)
		{
			QualityPanel.alpha = Mathf.MoveTowards(QualityPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			QualityPanel.alpha = Mathf.MoveTowards(QualityPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (Yandere.position.z > 70f && Yandere.position.z < 80f)
		{
			WeaponsPanel.alpha = Mathf.MoveTowards(WeaponsPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			WeaponsPanel.alpha = Mathf.MoveTowards(WeaponsPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (Yandere.position.z > 90f && Yandere.position.z < 100f)
		{
			StoryPanel.alpha = Mathf.MoveTowards(StoryPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			StoryPanel.alpha = Mathf.MoveTowards(StoryPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (Yandere.position.z > 110f && Yandere.position.z < 120f)
		{
			MorePanel.alpha = Mathf.MoveTowards(MorePanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			MorePanel.alpha = Mathf.MoveTowards(MorePanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (Yandere.position.z > 130f && Yandere.position.z < 140f)
		{
			CrowdfundPanel.alpha = Mathf.MoveTowards(CrowdfundPanel.alpha, 1f, Time.deltaTime * 0.5f);
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				FadeOut = true;
			}
			if (!Hearts[1].isPlaying)
			{
				Hearts[1].Play();
				Hearts[2].Play();
			}
		}
		else
		{
			CrowdfundPanel.alpha = Mathf.MoveTowards(CrowdfundPanel.alpha, 0f, Time.deltaTime * 0.5f);
			Hearts[1].Stop();
			Hearts[2].Stop();
		}
	}
}
