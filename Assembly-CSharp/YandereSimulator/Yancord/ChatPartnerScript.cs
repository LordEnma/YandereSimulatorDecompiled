using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000519 RID: 1305
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x0600215C RID: 8540 RVA: 0x001E9480 File Offset: 0x001E7680
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

		// Token: 0x0600215D RID: 8541 RVA: 0x001E9580 File Offset: 0x001E7780
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

		// Token: 0x0400491C RID: 18716
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x0400491D RID: 18717
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x0400491E RID: 18718
		public UILabel TagLabel;

		// Token: 0x0400491F RID: 18719
		public UITexture ProfilPictureTexture;

		// Token: 0x04004920 RID: 18720
		public UITexture StatusTexture;

		// Token: 0x04004921 RID: 18721
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
