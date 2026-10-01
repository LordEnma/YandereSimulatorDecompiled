using UnityEngine;

public class DayNightController : MonoBehaviour
{
	public enum DayPhase
	{
		Night = 0,
		Dawn = 1,
		Day = 2,
		Dusk = 3
	}

	public float dayCycleLength;

	public float currentCycleTime;

	public DayPhase currentPhase;

	public float hoursPerDay;

	public float dawnTimeOffset;

	public int worldTimeHour;

	public Color fullLight;

	public Color fullDark;

	public Material dawnDuskSkybox;

	public Color dawnDuskFog;

	public Material daySkybox;

	public Color dayFog;

	public Material nightSkybox;

	public Color nightFog;

	private float dawnTime;

	private float dayTime;

	private float duskTime;

	private float nightTime;

	private float quarterDay;

	private float lightIntensity;

	private void Initialize()
	{
		quarterDay = dayCycleLength * 0.25f;
		dawnTime = 0f;
		dayTime = dawnTime + quarterDay;
		duskTime = dayTime + quarterDay;
		nightTime = duskTime + quarterDay;
		Light component = GetComponent<Light>();
		if (component != null)
		{
			lightIntensity = component.intensity;
		}
	}

	private void Reset()
	{
		dayCycleLength = 120f;
		hoursPerDay = 24f;
		dawnTimeOffset = 3f;
		fullDark = new Color(32f / 255f, 28f / 255f, 46f / 255f);
		fullLight = new Color(253f / 255f, 248f / 255f, 223f / 255f);
		dawnDuskFog = new Color(133f / 255f, 124f / 255f, 0.4f);
		dayFog = new Color(180f / 255f, 208f / 255f, 209f / 255f);
		nightFog = new Color(12f / 255f, 1f / 17f, 91f / 255f);
		Skybox[] array = Resources.FindObjectsOfTypeAll<Skybox>();
		foreach (Skybox skybox in array)
		{
			if (skybox.name == "DawnDusk Skybox")
			{
				dawnDuskSkybox = skybox.material;
			}
			else if (skybox.name == "StarryNight Skybox")
			{
				nightSkybox = skybox.material;
			}
			else if (skybox.name == "Sunny2 Skybox")
			{
				daySkybox = skybox.material;
			}
		}
	}

	private void Start()
	{
		Initialize();
	}

	private void Update()
	{
		if (currentCycleTime > nightTime && currentPhase == DayPhase.Dusk)
		{
			SetNight();
		}
		else if (currentCycleTime > duskTime && currentPhase == DayPhase.Day)
		{
			SetDusk();
		}
		else if (currentCycleTime > dayTime && currentPhase == DayPhase.Dawn)
		{
			SetDay();
		}
		else if (currentCycleTime > dawnTime && currentCycleTime < dayTime && currentPhase == DayPhase.Night)
		{
			SetDawn();
		}
		UpdateWorldTime();
		UpdateDaylight();
		UpdateFog();
		currentCycleTime += Time.deltaTime;
		currentCycleTime %= dayCycleLength;
	}

	public void SetDawn()
	{
		RenderSettings.skybox = dawnDuskSkybox;
		Light component = GetComponent<Light>();
		if (component != null)
		{
			component.enabled = true;
		}
		currentPhase = DayPhase.Dawn;
	}

	public void SetDay()
	{
		RenderSettings.skybox = daySkybox;
		RenderSettings.ambientLight = fullLight;
		Light component = GetComponent<Light>();
		if (component != null)
		{
			component.intensity = lightIntensity;
		}
		currentPhase = DayPhase.Day;
	}

	public void SetDusk()
	{
		RenderSettings.skybox = dawnDuskSkybox;
		currentPhase = DayPhase.Dusk;
	}

	public void SetNight()
	{
		RenderSettings.skybox = nightSkybox;
		RenderSettings.ambientLight = fullDark;
		Light component = GetComponent<Light>();
		if (component != null)
		{
			component.enabled = false;
		}
		currentPhase = DayPhase.Night;
	}

	private void UpdateDaylight()
	{
		if (currentPhase == DayPhase.Dawn)
		{
			float num = currentCycleTime - dawnTime;
			RenderSettings.ambientLight = Color.Lerp(fullDark, fullLight, num / quarterDay);
			Light component = GetComponent<Light>();
			if (component != null)
			{
				component.intensity = lightIntensity * (num / quarterDay);
			}
		}
		else if (currentPhase == DayPhase.Dusk)
		{
			float num2 = currentCycleTime - duskTime;
			RenderSettings.ambientLight = Color.Lerp(fullLight, fullDark, num2 / quarterDay);
			Light component2 = GetComponent<Light>();
			if (component2 != null)
			{
				component2.intensity = lightIntensity * ((quarterDay - num2) / quarterDay);
			}
		}
		base.transform.Rotate(Vector3.up * (Time.deltaTime / dayCycleLength * 360f), Space.Self);
	}

	private void UpdateFog()
	{
		if (currentPhase == DayPhase.Dawn)
		{
			float num = currentCycleTime - dawnTime;
			RenderSettings.fogColor = Color.Lerp(dawnDuskFog, dayFog, num / quarterDay);
		}
		else if (currentPhase == DayPhase.Day)
		{
			float num2 = currentCycleTime - dayTime;
			RenderSettings.fogColor = Color.Lerp(dayFog, dawnDuskFog, num2 / quarterDay);
		}
		else if (currentPhase == DayPhase.Dusk)
		{
			float num3 = currentCycleTime - duskTime;
			RenderSettings.fogColor = Color.Lerp(dawnDuskFog, nightFog, num3 / quarterDay);
		}
		else if (currentPhase == DayPhase.Night)
		{
			float num4 = currentCycleTime - nightTime;
			RenderSettings.fogColor = Color.Lerp(nightFog, dawnDuskFog, num4 / quarterDay);
		}
	}

	private void UpdateWorldTime()
	{
		worldTimeHour = (int)((Mathf.Ceil(currentCycleTime / dayCycleLength * hoursPerDay) + dawnTimeOffset) % hoursPerDay) + 1;
	}
}
