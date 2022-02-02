using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000518 RID: 1304
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x06002150 RID: 8528 RVA: 0x001E8AB0 File Offset: 0x001E6CB0
		private void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.TagLabel != null)
				{
					this.TagLabel.text = this.MyProfile.GetTag(true);
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				if (this.StatusTexture != null)
				{
					this.StatusTexture.mainTexture = this.GetStatusTexture(this.MyProfile.CurrentStatus);
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Profile";
				return;
			}
			Debug.LogError("[ChatPartnerScript] MyProfile wasn't assgined!");
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x06002151 RID: 8529 RVA: 0x001E8BB0 File Offset: 0x001E6DB0
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
				return null;
			}
		}

		// Token: 0x0400490A RID: 18698
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x0400490B RID: 18699
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x0400490C RID: 18700
		public UILabel TagLabel;

		// Token: 0x0400490D RID: 18701
		public UITexture ProfilPictureTexture;

		// Token: 0x0400490E RID: 18702
		public UITexture StatusTexture;

		// Token: 0x0400490F RID: 18703
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
