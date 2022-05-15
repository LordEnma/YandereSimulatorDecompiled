using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000527 RID: 1319
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x060021B6 RID: 8630 RVA: 0x001F1D74 File Offset: 0x001EFF74
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

		// Token: 0x060021B7 RID: 8631 RVA: 0x001F1E74 File Offset: 0x001F0074
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

		// Token: 0x04004A2D RID: 18989
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004A2E RID: 18990
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004A2F RID: 18991
		public UILabel TagLabel;

		// Token: 0x04004A30 RID: 18992
		public UITexture ProfilPictureTexture;

		// Token: 0x04004A31 RID: 18993
		public UITexture StatusTexture;

		// Token: 0x04004A32 RID: 18994
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
