using UnityEngine;
using UnityEngine.PostProcessing;

public class YanvaniaCameraScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public YanvaniaYanmontScript Yanmont;

	public GameObject Jukebox;

	public bool Cutscene;

	public bool StopMusic = true;

	public float TargetZoom;

	public float Zoom;

	private void Start()
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		Profile.depthOfField.settings = settings;
		base.transform.position = Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	private void FixedUpdate()
	{
		TargetZoom += Input.GetAxis("Mouse ScrollWheel") * 10f;
		if (TargetZoom < 0f)
		{
			TargetZoom = 0f;
		}
		if (TargetZoom > 3.85f)
		{
			TargetZoom = 3.85f;
		}
		Zoom = Mathf.Lerp(Zoom, TargetZoom, Time.deltaTime);
		if (!Cutscene)
		{
			TargetZoom += Input.GetAxis("Mouse ScrollWheel") * 10f;
			base.transform.position = Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f + Zoom);
			if (base.transform.position.x > 47.9f)
			{
				base.transform.position = new Vector3(47.9f, base.transform.position.y, base.transform.position.z);
			}
			return;
		}
		if (StopMusic)
		{
			if (Yanmont.Dracula.Health > 0f)
			{
				TargetZoom = 3.85f;
			}
			AudioSource component = Jukebox.GetComponent<AudioSource>();
			component.volume -= Time.deltaTime * ((Yanmont.Health > 0f) ? 0.2f : 0.025f);
			if (component.volume <= 0f)
			{
				StopMusic = false;
			}
		}
		base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34.675f, Time.deltaTime * Yanmont.walkSpeed), 8f, -5.85f + Zoom);
	}
}
