using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000525 RID: 1317
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x0600219B RID: 8603 RVA: 0x001EE740 File Offset: 0x001EC940
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

		// Token: 0x0600219C RID: 8604 RVA: 0x001EE840 File Offset: 0x001ECA40
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

		// Token: 0x040049DE RID: 18910
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040049DF RID: 18911
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040049E0 RID: 18912
		public UILabel TagLabel;

		// Token: 0x040049E1 RID: 18913
		public UITexture ProfilPictureTexture;

		// Token: 0x040049E2 RID: 18914
		public UITexture StatusTexture;

		// Token: 0x040049E3 RID: 18915
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
