using System;
using UnityEngine;

// Token: 0x02000270 RID: 624
public class DayNightController : MonoBehaviour
{
	// Token: 0x0600133B RID: 4923 RVA: 0x000AD6A4 File Offset: 0x000AB8A4
	private void Initialize()
	{
		this.quarterDay = this.dayCycleLength * 0.25f;
		this.dawnTime = 0f;
		this.dayTime = this.dawnTime + this.quarterDay;
		this.duskTime = this.dayTime + this.quarterDay;
		this.nightTime = this.duskTime + this.quarterDay;
		Light component = base.GetComponent<Light>();
		if (component != null)
		{
			this.lightIntensity = component.intensity;
		}
	}

	// Token: 0x0600133C RID: 4924 RVA: 0x000AD724 File Offset: 0x000AB924
	private void Reset()
	{
		this.dayCycleLength = 120f;
		this.hoursPerDay = 24f;
		this.dawnTimeOffset = 3f;
		this.fullDark = new Color(0.1254902f, 0.10980392f, 0.18039216f);
		this.fullLight = new Color(0.99215686f, 0.972549f, 0.8745098f);
		this.dawnDuskFog = new Color(0.52156866f, 0.4862745f, 0.4f);
		this.dayFog = new Color(0.7058824f, 0.8156863f, 0.81960785f);
		this.nightFog = new Color(0.047058824f, 0.05882353f, 0.35686275f);
		foreach (Skybox skybox in Resources.FindObjectsOfTypeAll<Skybox>())
		{
			if (skybox.name == "DawnDusk Skybox")
			{
				this.dawnDuskSkybox = skybox.material;
			}
			else if (skybox.name == "StarryNight Skybox")
			{
				this.nightSkybox = skybox.material;
			}
			else if (skybox.name == "Sunny2 Skybox")
			{
				this.daySkybox = skybox.material;
			}
		}
	}

	// Token: 0x0600133D RID: 4925 RVA: 0x000AD84A File Offset: 0x000ABA4A
	private void Start()
	{
		this.Initialize();
	}

	// Token: 0x0600133E RID: 4926 RVA: 0x000AD854 File Offset: 0x000ABA54
	private void Update()
	{
		if (this.currentCycleTime > this.nightTime && this.currentPhase == DayNightController.DayPhase.Dusk)
		{
			this.SetNight();
		}
		else if (this.currentCycleTime > this.duskTime && this.currentPhase == DayNightController.DayPhase.Day)
		{
			this.SetDusk();
		}
		else if (this.currentCycleTime > this.dayTime && this.currentPhase == DayNightController.DayPhase.Dawn)
		{
			this.SetDay();
		}
		else if (this.currentCycleTime > this.dawnTime && this.currentCycleTime < this.dayTime && this.currentPhase == DayNightController.DayPhase.Night)
		{
			this.SetDawn();
		}
		this.UpdateWorldTime();
		this.UpdateDaylight();
		this.UpdateFog();
		this.currentCycleTime += Time.deltaTime;
		this.currentCycleTime %= this.dayCycleLength;
	}

	// Token: 0x0600133F RID: 4927 RVA: 0x000AD920 File Offset: 0x000ABB20
	public void SetDawn()
	{
		RenderSettings.skybox = this.dawnDuskSkybox;
		Light component = base.GetComponent<Light>();
		if (component != null)
		{
			component.enabled = true;
		}
		this.currentPhase = DayNightController.DayPhase.Dawn;
	}

	// Token: 0x06001340 RID: 4928 RVA: 0x000AD958 File Offset: 0x000ABB58
	public void SetDay()
	{
		RenderSettings.skybox = this.daySkybox;
		RenderSettings.ambientLight = this.fullLight;
		Light component = base.GetComponent<Light>();
		if (component != null)
		{
			component.intensity = this.lightIntensity;
		}
		this.currentPhase = DayNightController.DayPhase.Day;
	}

	// Token: 0x06001341 RID: 4929 RVA: 0x000AD99E File Offset: 0x000ABB9E
	public void SetDusk()
	{
		RenderSettings.skybox = this.dawnDuskSkybox;
		this.currentPhase = DayNightController.DayPhase.Dusk;
	}

	// Token: 0x06001342 RID: 4930 RVA: 0x000AD9B4 File Offset: 0x000ABBB4
	public void SetNight()
	{
		RenderSettings.skybox = this.nightSkybox;
		RenderSettings.ambientLight = this.fullDark;
		Light component = base.GetComponent<Light>();
		if (component != null)
		{
			component.enabled = false;
		}
		this.currentPhase = DayNightController.DayPhase.Night;
	}

	// Token: 0x06001343 RID: 4931 RVA: 0x000AD9F8 File Offset: 0x000ABBF8
	private void UpdateDaylight()
	{
		if (this.currentPhase == DayNightController.DayPhase.Dawn)
		{
			float num = this.currentCycleTime - this.dawnTime;
			RenderSettings.ambientLight = Color.Lerp(this.fullDark, this.fullLight, num / this.quarterDay);
			Light component = base.GetComponent<Light>();
			if (component != null)
			{
				component.intensity = this.lightIntensity * (num / this.quarterDay);
			}
		}
		else if (this.currentPhase == DayNightController.DayPhase.Dusk)
		{
			float num2 = this.currentCycleTime - this.duskTime;
			RenderSettings.ambientLight = Color.Lerp(this.fullLight, this.fullDark, num2 / this.quarterDay);
			Light component2 = base.GetComponent<Light>();
			if (component2 != null)
			{
				component2.intensity = this.lightIntensity * ((this.quarterDay - num2) / this.quarterDay);
			}
		}
		base.transform.Rotate(Vector3.up * (Time.deltaTime / this.dayCycleLength * 360f), Space.Self);
	}

	// Token: 0x06001344 RID: 4932 RVA: 0x000ADAEC File Offset: 0x000ABCEC
	private void UpdateFog()
	{
		if (this.currentPhase == DayNightController.DayPhase.Dawn)
		{
			float num = this.currentCycleTime - this.dawnTime;
			RenderSettings.fogColor = Color.Lerp(this.dawnDuskFog, this.dayFog, num / this.quarterDay);
			return;
		}
		if (this.currentPhase == DayNightController.DayPhase.Day)
		{
			float num2 = this.currentCycleTime - this.dayTime;
			RenderSettings.fogColor = Color.Lerp(this.dayFog, this.dawnDuskFog, num2 / this.quarterDay);
			return;
		}
		if (this.currentPhase == DayNightController.DayPhase.Dusk)
		{
			float num3 = this.currentCycleTime - this.duskTime;
			RenderSettings.fogColor = Color.Lerp(this.dawnDuskFog, this.nightFog, num3 / this.quarterDay);
			return;
		}
		if (this.currentPhase == DayNightController.DayPhase.Night)
		{
			float num4 = this.currentCycleTime - this.nightTime;
			RenderSettings.fogColor = Color.Lerp(this.nightFog, this.dawnDuskFog, num4 / this.quarterDay);
		}
	}

	// Token: 0x06001345 RID: 4933 RVA: 0x000ADBCF File Offset: 0x000ABDCF
	private void UpdateWorldTime()
	{
		this.worldTimeHour = (int)((Mathf.Ceil(this.currentCycleTime / this.dayCycleLength * this.hoursPerDay) + this.dawnTimeOffset) % this.hoursPerDay) + 1;
	}

	// Token: 0x04001BC3 RID: 7107
	public float dayCycleLength;

	// Token: 0x04001BC4 RID: 7108
	public float currentCycleTime;

	// Token: 0x04001BC5 RID: 7109
	public DayNightController.DayPhase currentPhase;

	// Token: 0x04001BC6 RID: 7110
	public float hoursPerDay;

	// Token: 0x04001BC7 RID: 7111
	public float dawnTimeOffset;

	// Token: 0x04001BC8 RID: 7112
	public int worldTimeHour;

	// Token: 0x04001BC9 RID: 7113
	public Color fullLight;

	// Token: 0x04001BCA RID: 7114
	public Color fullDark;

	// Token: 0x04001BCB RID: 7115
	public Material dawnDuskSkybox;

	// Token: 0x04001BCC RID: 7116
	public Color dawnDuskFog;

	// Token: 0x04001BCD RID: 7117
	public Material daySkybox;

	// Token: 0x04001BCE RID: 7118
	public Color dayFog;

	// Token: 0x04001BCF RID: 7119
	public Material nightSkybox;

	// Token: 0x04001BD0 RID: 7120
	public Color nightFog;

	// Token: 0x04001BD1 RID: 7121
	private float dawnTime;

	// Token: 0x04001BD2 RID: 7122
	private float dayTime;

	// Token: 0x04001BD3 RID: 7123
	private float duskTime;

	// Token: 0x04001BD4 RID: 7124
	private float nightTime;

	// Token: 0x04001BD5 RID: 7125
	private float quarterDay;

	// Token: 0x04001BD6 RID: 7126
	private float lightIntensity;

	// Token: 0x02000650 RID: 1616
	public enum DayPhase
	{
		// Token: 0x04004EAA RID: 20138
		Night,
		// Token: 0x04004EAB RID: 20139
		Dawn,
		// Token: 0x04004EAC RID: 20140
		Day,
		// Token: 0x04004EAD RID: 20141
		Dusk
	}
}
