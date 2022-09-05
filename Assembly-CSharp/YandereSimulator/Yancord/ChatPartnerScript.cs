// Decompiled with JetBrains decompiler
// Type: YandereSimulator.Yancord.ChatPartnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
  public class ChatPartnerScript : MonoBehaviour
  {
    [Header("== Partner Informations ==")]
    public Profile MyProfile;
    [Space(20f)]
    public UILabel NameLabel;
    public UILabel TagLabel;
    public UITexture ProfilPictureTexture;
    public UITexture StatusTexture;
    [Space(20f)]
    public List<Texture2D> StatusTextures = new List<Texture2D>();

    private void Awake()
    {
      if ((Object) this.MyProfile != (Object) null)
      {
        if ((Object) this.NameLabel != (Object) null)
          this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
        if ((Object) this.TagLabel != (Object) null)
          this.TagLabel.text = this.MyProfile.GetTag(true);
        if ((Object) this.ProfilPictureTexture != (Object) null)
          this.ProfilPictureTexture.mainTexture = (Texture) this.MyProfile.ProfilePicture;
        if ((Object) this.StatusTexture != (Object) null)
          this.StatusTexture.mainTexture = (Texture) this.GetStatusTexture(this.MyProfile.CurrentStatus);
        this.gameObject.name = this.MyProfile.FirstName + "_Profile";
      }
      else
      {
        Debug.LogError((object) "[ChatPartnerScript] MyProfile wasn't assgined!");
        Object.Destroy((Object) this.gameObject);
      }
    }

    private Texture2D GetStatusTexture(Status currentStatus)
    {
      switch (currentStatus)
      {
        case Status.Online:
          return this.StatusTextures[1];
        case Status.Idle:
          return this.StatusTextures[2];
        case Status.DontDisturb:
          return this.StatusTextures[3];
        case Status.Invisible:
          return this.StatusTextures[4];
        default:
          return (Texture2D) null;
      }
    }
  }
}
