using UnityEngine;
using UnityEngine.PostProcessing;

public class SpyScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public PostProcessingProfile Profile;

	public ModernRivalEventScript Event;

	public PromptBarScript PromptBar;

	public MouseOrbitAndZoom Orbit;

	public AudioListener Listener;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SpyCamera;

	public Transform SpyTarget;

	public Transform SpySpot;

	public float OriginalDOF;

	public float Timer;

	public bool OsanaSpecific;

	public bool MovingPivot;

	public bool RecordEvent;

	public bool CanRecord;

	public bool Recording;

	public bool Invert;

	public int[] StudentID;

	public int Phase;

	private void Start()
	{
		if (OsanaSpecific && DateGlobals.Week > 1)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (!Invert)
			{
				Yandere.CharacterAnimation.CrossFade("f02_spying_00");
			}
			else
			{
				Yandere.CharacterAnimation.CrossFade("f02_spyingRight_00");
			}
			Yandere.YandereVision = false;
			Yandere.ResetYandereEffects();
			Yandere.CanMove = false;
			Phase++;
		}
		if (Phase == 1)
		{
			Quaternion b = Quaternion.LookRotation(new Vector3(SpyTarget.transform.position.x, Yandere.transform.position.y, SpyTarget.transform.position.z) - Yandere.transform.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, b, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(SpySpot.position);
			if (!Recording && RecordEvent && Yandere.Inventory.DirectionalMic)
			{
				Yandere.CharacterAnimation.CrossFade("f02_spyRecord_00");
				Yandere.Microphone.SetActive(value: true);
				Recording = true;
			}
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				PromptBar.Label[1].text = "Stop";
				PromptBar.Label[2].text = "";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				OriginalDOF = Yandere.RPGCamera.distance;
				if (Orbit == null)
				{
					Debug.Log("AHHHHH, ORBIT IS NULL!!!!!");
				}
				else
				{
					UpdateDOF(Orbit.distance, 5.6f);
				}
				if (StudentManager == null)
				{
					StudentManager = Prompt.Yandere.StudentManager;
				}
				if (Listener != null)
				{
					Yandere.MyListener.enabled = false;
					Listener.enabled = true;
				}
				Yandere.MainCamera.enabled = false;
				SpyCamera.SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (MovingPivot && Event.Phase > 1)
			{
				Orbit.target.position = (StudentManager.Students[StudentID[1]].transform.position + StudentManager.Students[StudentID[2]].transform.position) * 0.5f;
				Orbit.target.position += new Vector3(0f, 1f, 0f);
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				End();
			}
		}
		if (Event != null && Event.EventID == RivalEventType.AmaiCookingEvent && Event.Phase > 6)
		{
			Orbit.target.localPosition = new Vector3(-2f, 1.25f, -3.25f);
		}
	}

	public void End()
	{
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		Yandere.Microphone.SetActive(value: false);
		Yandere.MainCamera.enabled = true;
		Yandere.CanMove = true;
		SpyCamera.SetActive(value: false);
		Timer = 0f;
		Phase = 0;
		UpdateDOF(OriginalDOF, 5.6f);
		if (Listener != null)
		{
			Yandere.MyListener.enabled = true;
			Listener.enabled = false;
		}
	}

	public void UpdateDOF(float Value, float Aperture)
	{
		if (Profile != null)
		{
			DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
			settings.focusDistance = Value;
			Profile.depthOfField.settings = settings;
			UpdateAperture(Aperture);
		}
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}
}
