// Decompiled with JetBrains decompiler
// Type: YandereSimulator.Yancord.MessageScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace YandereSimulator.Yancord
{
  public class MessageScript : MonoBehaviour
  {
    [Header("== Partner Informations ==")]
    public Profile MyProfile;
    [Space(20f)]
    public UILabel NameLabel;
    public UILabel MessageLabel;
    public UITexture ProfilPictureTexture;

    public void Awake()
    {
      if (!((Object) this.MyProfile != (Object) null))
        return;
      if ((Object) this.NameLabel != (Object) null)
        this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
      if ((Object) this.ProfilPictureTexture != (Object) null)
        this.ProfilPictureTexture.mainTexture = (Texture) this.MyProfile.ProfilePicture;
      this.gameObject.name = this.MyProfile.FirstName + "_Message";
    }
  }
}
