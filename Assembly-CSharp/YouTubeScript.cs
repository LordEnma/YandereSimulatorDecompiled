using RetroAesthetics;
using UnityEngine;

public class YouTubeScript : MonoBehaviour
{
	public RetroCameraEffect EightiesEffects;

	public CameraEffectsScript CameraEffects;

	public NormalBufferView VaporwaveVisuals;

	public Camera MyCamera;

	public YandereScript Yandere;

	public GameObject[] Label;

	public GameObject[] Trees;

	public Animation Girl;

	public float Strength;

	public float Focus = 1f;

	public float Bloom = 60f;

	public float Knee = 1f;

	public float Radius = 7f;

	public float Threshold;

	public float Speed;

	public float Timer;

	public bool Begin;

	public int Phase;

	public int Type;

	private void Start()
	{
		if (Girl != null)
		{
			Girl["OkaTurn1"].time = 15f;
		}
	}

	private void Update()
	{
		if (Type == 6)
		{
			MyCamera.orthographicSize -= Time.deltaTime * (1f / 30f);
		}
		if (Input.GetKeyDown("z"))
		{
			Phase++;
			if (Type == 5)
			{
				Label[Phase].SetActive(true);
			}
		}
		if (Phase > 0)
		{
			if (Type == 1)
			{
				base.transform.position += new Vector3(0f, 0f, Time.deltaTime * -0.1f);
			}
			else if (Type == 2)
			{
				base.transform.Translate(Vector3.forward * Time.deltaTime * -1f * Speed);
			}
			else if (Type == 3)
			{
				base.transform.Translate(Vector3.forward * Time.deltaTime * -1f);
				Begin = true;
			}
			else if (Type == 4)
			{
				Begin = true;
			}
		}
		if (!Begin)
		{
			return;
		}
		if (Type != 4)
		{
			Timer += Time.deltaTime;
			if (!(Timer > 1f))
			{
				return;
			}
			if (Phase == 1)
			{
				VaporwaveVisuals.ApplyNormalView();
				RenderSettings.skybox = Yandere.VaporwaveSkybox;
				Phase++;
				Bloom = 5f;
				Threshold = 0f;
				Knee = 1f;
				Radius = 7f;
				CameraEffects.UpdateBloom(Bloom);
				CameraEffects.UpdateThreshold(Threshold);
				CameraEffects.UpdateBloomKnee(Knee);
				CameraEffects.UpdateBloomRadius(Radius);
				for (int i = 1; i < Trees.Length; i++)
				{
					Debug.Log("Deactivating trees...or trying to.");
					Trees[i].SetActive(false);
				}
				EightiesEffects.enabled = true;
			}
			else
			{
				Bloom = Mathf.Lerp(Bloom, 1f, Time.deltaTime);
				Threshold = Mathf.Lerp(Bloom, 1.1f, Time.deltaTime);
				Knee = Mathf.Lerp(Bloom, 0.5f, Time.deltaTime);
				Radius = Mathf.Lerp(Bloom, 4f, Time.deltaTime);
				CameraEffects.UpdateBloom(Bloom);
				CameraEffects.UpdateThreshold(Threshold);
				CameraEffects.UpdateBloomKnee(Knee);
				CameraEffects.UpdateBloomRadius(Radius);
			}
		}
		else
		{
			Speed += Time.deltaTime;
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.3f, 0f, 0.4f), Time.deltaTime * Speed);
		}
	}
}
