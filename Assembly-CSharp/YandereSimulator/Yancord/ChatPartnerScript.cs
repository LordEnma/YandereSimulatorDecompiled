using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000518 RID: 1304
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x0600214C RID: 8524 RVA: 0x001E8210 File Offset: 0x001E6410
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

		// Token: 0x0600214D RID: 8525 RVA: 0x001E8310 File Offset: 0x001E6510
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

		// Token: 0x040048FF RID: 18687
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004900 RID: 18688
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004901 RID: 18689
		public UILabel TagLabel;

		// Token: 0x04004902 RID: 18690
		public UITexture ProfilPictureTexture;

		// Token: 0x04004903 RID: 18691
		public UITexture StatusTexture;

		// Token: 0x04004904 RID: 18692
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
