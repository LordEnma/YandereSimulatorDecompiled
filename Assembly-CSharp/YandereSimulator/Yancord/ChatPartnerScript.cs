using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000518 RID: 1304
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x06002155 RID: 8533 RVA: 0x001E8FCC File Offset: 0x001E71CC
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

		// Token: 0x06002156 RID: 8534 RVA: 0x001E90CC File Offset: 0x001E72CC
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

		// Token: 0x04004913 RID: 18707
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004914 RID: 18708
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004915 RID: 18709
		public UILabel TagLabel;

		// Token: 0x04004916 RID: 18710
		public UITexture ProfilPictureTexture;

		// Token: 0x04004917 RID: 18711
		public UITexture StatusTexture;

		// Token: 0x04004918 RID: 18712
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
