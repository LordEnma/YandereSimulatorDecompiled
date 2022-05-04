using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000526 RID: 1318
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x060021AC RID: 8620 RVA: 0x001F0724 File Offset: 0x001EE924
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

		// Token: 0x060021AD RID: 8621 RVA: 0x001F0824 File Offset: 0x001EEA24
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

		// Token: 0x04004A06 RID: 18950
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004A07 RID: 18951
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004A08 RID: 18952
		public UILabel TagLabel;

		// Token: 0x04004A09 RID: 18953
		public UITexture ProfilPictureTexture;

		// Token: 0x04004A0A RID: 18954
		public UITexture StatusTexture;

		// Token: 0x04004A0B RID: 18955
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
