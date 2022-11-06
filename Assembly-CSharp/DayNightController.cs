// Decompiled with JetBrains decompiler
// Type: DayNightController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DayNightController : MonoBehaviour
{
  public float dayCycleLength;
  public float currentCycleTime;
  public DayNightController.DayPhase currentPhase;
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
    this.quarterDay = this.dayCycleLength * 0.25f;
    this.dawnTime = 0.0f;
    this.dayTime = this.dawnTime + this.quarterDay;
    this.duskTime = this.dayTime + this.quarterDay;
    this.nightTime = this.duskTime + this.quarterDay;
    Light component = this.GetComponent<Light>();
    if (!((Object) component != (Object) null))
      return;
    this.lightIntensity = component.intensity;
  }

  private void Reset()
  {
    this.dayCycleLength = 120f;
    this.hoursPerDay = 24f;
    this.dawnTimeOffset = 3f;
    this.fullDark = new Color(0.1254902f, 0.109803922f, 0.180392161f);
    this.fullLight = new Color(0.992156863f, 0.972549f, 0.8745098f);
    this.dawnDuskFog = new Color(0.521568656f, 0.4862745f, 0.4f);
    this.dayFog = new Color(0.7058824f, 0.8156863f, 0.819607854f);
    this.nightFog = new Color(0.0470588244f, 0.05882353f, 0.356862754f);
    foreach (Skybox skybox in Resources.FindObjectsOfTypeAll<Skybox>())
    {
      if (skybox.name == "DawnDusk Skybox")
        this.dawnDuskSkybox = skybox.material;
      else if (skybox.name == "StarryNight Skybox")
        this.nightSkybox = skybox.material;
      else if (skybox.name == "Sunny2 Skybox")
        this.daySkybox = skybox.material;
    }
  }

  private void Start() => this.Initialize();

  private void Update()
  {
    if ((double) this.currentCycleTime > (double) this.nightTime && this.currentPhase == DayNightController.DayPhase.Dusk)
      this.SetNight();
    else if ((double) this.currentCycleTime > (double) this.duskTime && this.currentPhase == DayNightController.DayPhase.Day)
      this.SetDusk();
    else if ((double) this.currentCycleTime > (double) this.dayTime && this.currentPhase == DayNightController.DayPhase.Dawn)
      this.SetDay();
    else if ((double) this.currentCycleTime > (double) this.dawnTime && (double) this.currentCycleTime < (double) this.dayTime && this.currentPhase == DayNightController.DayPhase.Night)
      this.SetDawn();
    this.UpdateWorldTime();
    this.UpdateDaylight();
    this.UpdateFog();
    this.currentCycleTime += Time.deltaTime;
    this.currentCycleTime %= this.dayCycleLength;
  }

  public void SetDawn()
  {
    RenderSettings.skybox = this.dawnDuskSkybox;
    Light component = this.GetComponent<Light>();
    if ((Object) component != (Object) null)
      component.enabled = true;
    this.currentPhase = DayNightController.DayPhase.Dawn;
  }

  public void SetDay()
  {
    RenderSettings.skybox = this.daySkybox;
    RenderSettings.ambientLight = this.fullLight;
    Light component = this.GetComponent<Light>();
    if ((Object) component != (Object) null)
      component.intensity = this.lightIntensity;
    this.currentPhase = DayNightController.DayPhase.Day;
  }

  public void SetDusk()
  {
    RenderSettings.skybox = this.dawnDuskSkybox;
    this.currentPhase = DayNightController.DayPhase.Dusk;
  }

  public void SetNight()
  {
    RenderSettings.skybox = this.nightSkybox;
    RenderSettings.ambientLight = this.fullDark;
    Light component = this.GetComponent<Light>();
    if ((Object) component != (Object) null)
      component.enabled = false;
    this.currentPhase = DayNightController.DayPhase.Night;
  }

  private void UpdateDaylight()
  {
    if (this.currentPhase == DayNightController.DayPhase.Dawn)
    {
      float num = this.currentCycleTime - this.dawnTime;
      RenderSettings.ambientLight = Color.Lerp(this.fullDark, this.fullLight, num / this.quarterDay);
      Light component = this.GetComponent<Light>();
      if ((Object) component != (Object) null)
        component.intensity = this.lightIntensity * (num / this.quarterDay);
    }
    else if (this.currentPhase == DayNightController.DayPhase.Dusk)
    {
      float num = this.currentCycleTime - this.duskTime;
      RenderSettings.ambientLight = Color.Lerp(this.fullLight, this.fullDark, num / this.quarterDay);
      Light component = this.GetComponent<Light>();
      if ((Object) component != (Object) null)
        component.intensity = this.lightIntensity * ((this.quarterDay - num) / this.quarterDay);
    }
    this.transform.Rotate(Vector3.up * (float) ((double) Time.deltaTime / (double) this.dayCycleLength * 360.0), Space.Self);
  }

  private void UpdateFog()
  {
    if (this.currentPhase == DayNightController.DayPhase.Dawn)
      RenderSettings.fogColor = Color.Lerp(this.dawnDuskFog, this.dayFog, (this.currentCycleTime - this.dawnTime) / this.quarterDay);
    else if (this.currentPhase == DayNightController.DayPhase.Day)
      RenderSettings.fogColor = Color.Lerp(this.dayFog, this.dawnDuskFog, (this.currentCycleTime - this.dayTime) / this.quarterDay);
    else if (this.currentPhase == DayNightController.DayPhase.Dusk)
    {
      RenderSettings.fogColor = Color.Lerp(this.dawnDuskFog, this.nightFog, (this.currentCycleTime - this.duskTime) / this.quarterDay);
    }
    else
    {
      if (this.currentPhase != DayNightController.DayPhase.Night)
        return;
      RenderSettings.fogColor = Color.Lerp(this.nightFog, this.dawnDuskFog, (this.currentCycleTime - this.nightTime) / this.quarterDay);
    }
  }

  private void UpdateWorldTime() => this.worldTimeHour = (int) (((double) Mathf.Ceil(this.currentCycleTime / this.dayCycleLength * this.hoursPerDay) + (double) this.dawnTimeOffset) % (double) this.hoursPerDay) + 1;

  public enum DayPhase
  {
    Night,
    Dawn,
    Day,
    Dusk,
  }
}
