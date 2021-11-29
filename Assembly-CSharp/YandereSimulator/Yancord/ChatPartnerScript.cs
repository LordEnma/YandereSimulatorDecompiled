using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000513 RID: 1299
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x0600212B RID: 8491 RVA: 0x001E4E7C File Offset: 0x001E307C
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

		// Token: 0x0600212C RID: 8492 RVA: 0x001E4F7C File Offset: 0x001E317C
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

		// Token: 0x0400489C RID: 18588
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x0400489D RID: 18589
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x0400489E RID: 18590
		public UILabel TagLabel;

		// Token: 0x0400489F RID: 18591
		public UITexture ProfilPictureTexture;

		// Token: 0x040048A0 RID: 18592
		public UITexture StatusTexture;

		// Token: 0x040048A1 RID: 18593
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
