using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000527 RID: 1319
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x060021B7 RID: 8631 RVA: 0x001F22DC File Offset: 0x001F04DC
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

		// Token: 0x060021B8 RID: 8632 RVA: 0x001F23DC File Offset: 0x001F05DC
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

		// Token: 0x04004A36 RID: 18998
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004A37 RID: 18999
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004A38 RID: 19000
		public UILabel TagLabel;

		// Token: 0x04004A39 RID: 19001
		public UITexture ProfilPictureTexture;

		// Token: 0x04004A3A RID: 19002
		public UITexture StatusTexture;

		// Token: 0x04004A3B RID: 19003
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
