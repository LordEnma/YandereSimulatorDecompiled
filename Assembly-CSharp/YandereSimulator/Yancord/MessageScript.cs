using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000515 RID: 1301
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002130 RID: 8496 RVA: 0x001E5008 File Offset: 0x001E3208
		public void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Message";
			}
		}

		// Token: 0x040048A2 RID: 18594
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040048A3 RID: 18595
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040048A4 RID: 18596
		public UILabel MessageLabel;

		// Token: 0x040048A5 RID: 18597
		public UITexture ProfilPictureTexture;
	}
}
