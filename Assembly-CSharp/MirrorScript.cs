// Decompiled with JetBrains decompiler
// Type: MirrorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MirrorScript : MonoBehaviour
{
  public PromptScript Prompt;
  public string[] Personas;
  public string[] Idles;
  public string[] Walks;
  public bool Started;
  public int Limit;

  private void Start()
  {
    this.Started = true;
    this.Limit = this.Idles.Length - 1;
    if (this.Prompt.Yandere.Club == ClubType.Delinquent)
    {
      this.Prompt.Yandere.PersonaID = 10;
      if (this.Prompt.Yandere.Persona != YanderePersonaType.Tough)
        this.UpdatePersona();
    }
    if (!GameGlobals.Eighties)
      return;
    this.Idles[0] = "f02_ryobaIdle_00";
    this.Walks[0] = "f02_ryobaWalk_00";
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      if (this.Prompt.Yandere.Health > 0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        ++this.Prompt.Yandere.PersonaID;
        if (this.Prompt.Yandere.PersonaID == this.Limit)
          this.Prompt.Yandere.PersonaID = 0;
        this.UpdatePersona();
      }
    }
    else if ((double) this.Prompt.Circle[1].fillAmount == 0.0 && this.Prompt.Yandere.Health > 0)
    {
      this.Prompt.Circle[1].fillAmount = 1f;
      --this.Prompt.Yandere.PersonaID;
      if (this.Prompt.Yandere.PersonaID < 0)
        this.Prompt.Yandere.PersonaID = this.Limit - 1;
      this.UpdatePersona();
    }
    if (!this.Prompt.InSight)
      return;
    this.Prompt.Yandere.StudentManager.TutorialWindow.ShowPersonaMessage = true;
  }

  public void UpdatePersona()
  {
    if (!this.Started)
      this.Start();
    int personaId = this.Prompt.Yandere.PersonaID;
    if (!this.Prompt.Yandere.Carrying)
    {
      if (!this.Prompt.Yandere.Resting)
      {
        this.Prompt.Yandere.NotificationManager.PersonaName = this.Personas[personaId];
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Persona);
      }
      this.Prompt.Yandere.IdleAnim = this.Idles[personaId];
      this.Prompt.Yandere.WalkAnim = this.Walks[personaId];
      this.Prompt.Yandere.UpdatePersona(personaId);
    }
    this.Prompt.Yandere.OriginalIdleAnim = this.Idles[personaId];
    this.Prompt.Yandere.OriginalWalkAnim = this.Walks[personaId];
    this.Prompt.Yandere.StudentManager.UpdatePerception();
  }
}
