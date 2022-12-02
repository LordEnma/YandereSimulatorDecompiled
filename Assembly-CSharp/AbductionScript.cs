using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class AbductionScript : MonoBehaviour
{
	public SkinnedMeshRenderer Renderer;

	public Texture[] RivalStockings;

	public AudioSource MyAudio;

	public UISprite Darkness;

	public Camera MainCamera;

	public float StartTimer;

	public float Timer;

	public bool PlayedAudio;

	public int Phase;

	public Animation Anim1;

	public Animator Anim2;

	public PostProcessingProfile Profile;

	private void Start()
	{
		if (SchoolGlobals.SchoolAtmosphere > 0.5f)
		{
			Darkness.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			Darkness.color = new Color(0f, 0f, 0f, 1f);
		}
		UpdateDOF(1f);
		if (GameGlobals.AbductionTarget > 0)
		{
			Renderer.material.SetTexture("_OverlayTex", RivalStockings[GameGlobals.AbductionTarget - 10]);
		}
	}

	private void Update()
	{
		StartTimer += Time.deltaTime;
		if (!(StartTimer > 1f))
		{
			return;
		}
		if ((double)StartTimer > 2.5 && !MyAudio.isPlaying && !PlayedAudio)
		{
			PlayedAudio = true;
			MyAudio.Play();
		}
		if (Phase == 0)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.33333f);
			if (Darkness.alpha == 0f)
			{
				Anim1.Play();
				Anim2.enabled = true;
				Phase++;
			}
		}
		else
		{
			if (!(Anim1["Scene"].time >= Anim1["Scene"].length))
			{
				return;
			}
			Timer += Time.deltaTime;
			if (Timer > 2f)
			{
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 0.33333f);
				if (Darkness.alpha == 1f)
				{
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
	}

	private void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
	}
}
