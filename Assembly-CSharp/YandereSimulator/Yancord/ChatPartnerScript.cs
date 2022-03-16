using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051F RID: 1311
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x06002183 RID: 8579 RVA: 0x001EC9A0 File Offset: 0x001EABA0
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

		// Token: 0x06002184 RID: 8580 RVA: 0x001ECAA0 File Offset: 0x001EACA0
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

		// Token: 0x040049A8 RID: 18856
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040049A9 RID: 18857
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040049AA RID: 18858
		public UILabel TagLabel;

		// Token: 0x040049AB RID: 18859
		public UITexture ProfilPictureTexture;

		// Token: 0x040049AC RID: 18860
		public UITexture StatusTexture;

		// Token: 0x040049AD RID: 18861
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
