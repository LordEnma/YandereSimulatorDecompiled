using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000524 RID: 1316
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x06002193 RID: 8595 RVA: 0x001EE210 File Offset: 0x001EC410
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

		// Token: 0x06002194 RID: 8596 RVA: 0x001EE310 File Offset: 0x001EC510
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

		// Token: 0x040049DA RID: 18906
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040049DB RID: 18907
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040049DC RID: 18908
		public UILabel TagLabel;

		// Token: 0x040049DD RID: 18909
		public UITexture ProfilPictureTexture;

		// Token: 0x040049DE RID: 18910
		public UITexture StatusTexture;

		// Token: 0x040049DF RID: 18911
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
