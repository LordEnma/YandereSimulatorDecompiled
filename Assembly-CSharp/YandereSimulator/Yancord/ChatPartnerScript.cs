using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000525 RID: 1317
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x060021A2 RID: 8610 RVA: 0x001EF19C File Offset: 0x001ED39C
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

		// Token: 0x060021A3 RID: 8611 RVA: 0x001EF29C File Offset: 0x001ED49C
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

		// Token: 0x040049F0 RID: 18928
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040049F1 RID: 18929
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040049F2 RID: 18930
		public UILabel TagLabel;

		// Token: 0x040049F3 RID: 18931
		public UITexture ProfilPictureTexture;

		// Token: 0x040049F4 RID: 18932
		public UITexture StatusTexture;

		// Token: 0x040049F5 RID: 18933
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
