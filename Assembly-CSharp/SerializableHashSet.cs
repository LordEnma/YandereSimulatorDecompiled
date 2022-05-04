using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004B2 RID: 1202
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001FAD RID: 8109 RVA: 0x001BFDAC File Offset: 0x001BDFAC
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001FAE RID: 8110 RVA: 0x001BFDC0 File Offset: 0x001BDFC0
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001FAF RID: 8111 RVA: 0x001BFE20 File Offset: 0x001BE020
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001FB0 RID: 8112 RVA: 0x001BFE5C File Offset: 0x001BE05C
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001FB1 RID: 8113 RVA: 0x001BFE60 File Offset: 0x001BE060
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001FB2 RID: 8114 RVA: 0x001BFEC4 File Offset: 0x001BE0C4
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004249 RID: 16969
	[SerializeField]
	private List<T> elements;

	// Token: 0x0400424A RID: 16970
	private const string XML_Element = "Element";
}
