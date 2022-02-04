using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000518 RID: 1304
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x06002152 RID: 8530 RVA: 0x001E8DC8 File Offset: 0x001E6FC8
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

		// Token: 0x06002153 RID: 8531 RVA: 0x001E8EC8 File Offset: 0x001E70C8
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

		// Token: 0x04004910 RID: 18704
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004911 RID: 18705
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004912 RID: 18706
		public UILabel TagLabel;

		// Token: 0x04004913 RID: 18707
		public UITexture ProfilPictureTexture;

		// Token: 0x04004914 RID: 18708
		public UITexture StatusTexture;

		// Token: 0x04004915 RID: 18709
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
