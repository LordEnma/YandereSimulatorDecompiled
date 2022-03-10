using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051B RID: 1307
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x0600216B RID: 8555 RVA: 0x001EAA38 File Offset: 0x001E8C38
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

		// Token: 0x0600216C RID: 8556 RVA: 0x001EAB38 File Offset: 0x001E8D38
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

		// Token: 0x04004949 RID: 18761
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x0400494A RID: 18762
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x0400494B RID: 18763
		public UILabel TagLabel;

		// Token: 0x0400494C RID: 18764
		public UITexture ProfilPictureTexture;

		// Token: 0x0400494D RID: 18765
		public UITexture StatusTexture;

		// Token: 0x0400494E RID: 18766
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
