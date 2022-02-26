using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051A RID: 1306
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x06002165 RID: 8549 RVA: 0x001EA060 File Offset: 0x001E8260
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

		// Token: 0x06002166 RID: 8550 RVA: 0x001EA160 File Offset: 0x001E8360
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

		// Token: 0x0400492C RID: 18732
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x0400492D RID: 18733
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x0400492E RID: 18734
		public UILabel TagLabel;

		// Token: 0x0400492F RID: 18735
		public UITexture ProfilPictureTexture;

		// Token: 0x04004930 RID: 18736
		public UITexture StatusTexture;

		// Token: 0x04004931 RID: 18737
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
