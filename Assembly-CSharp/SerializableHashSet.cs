using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004B2 RID: 1202
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001FAC RID: 8108 RVA: 0x001BFCB0 File Offset: 0x001BDEB0
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001FAD RID: 8109 RVA: 0x001BFCC4 File Offset: 0x001BDEC4
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001FAE RID: 8110 RVA: 0x001BFD24 File Offset: 0x001BDF24
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001FAF RID: 8111 RVA: 0x001BFD60 File Offset: 0x001BDF60
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001FB0 RID: 8112 RVA: 0x001BFD64 File Offset: 0x001BDF64
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

	// Token: 0x06001FB1 RID: 8113 RVA: 0x001BFDC8 File Offset: 0x001BDFC8
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
