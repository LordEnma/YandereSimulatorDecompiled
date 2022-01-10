using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000517 RID: 1303
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x0600214A RID: 8522 RVA: 0x001E7540 File Offset: 0x001E5740
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

		// Token: 0x0600214B RID: 8523 RVA: 0x001E7640 File Offset: 0x001E5840
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

		// Token: 0x040048F8 RID: 18680
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040048F9 RID: 18681
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040048FA RID: 18682
		public UILabel TagLabel;

		// Token: 0x040048FB RID: 18683
		public UITexture ProfilPictureTexture;

		// Token: 0x040048FC RID: 18684
		public UITexture StatusTexture;

		// Token: 0x040048FD RID: 18685
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
