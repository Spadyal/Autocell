using System;
using UnityEngine;

public class QuadCell : iCollectionViewCell
{
    //This was needed as Color can't be null
    public class QuadCellData
    {
        private Color m_color;
        public Color MainColor
        {
            get { return m_color; }
            set { m_color = value; }
        }
        private string m_text;
        public string MainText
        {
            get { return m_text; }
            set { m_text = value; }
        }
    }

    public int index;

    public void Update()
    {
        index = Index;
    }

    public override string NibName
    {
        get
        {
            return "QuadCell";
        }
    } 

    Material m_material;
    Renderer m_renderer;
    TextMesh m_sign;

    public override void SetData(object data)
    {
        base.SetData(data);

        if(m_renderer==null)
            m_renderer = GetComponent<Renderer>();

        if(m_renderer!=null && m_material==null)
        {
            m_material = m_renderer.material;
        }

        if(m_sign!=null)
            // m_sign = GetComponent<TextMesh>();
            // m_sign = GameObject.Find("CellCategory");
            m_sign = (TextMesh)GetComponent(typeof(TextMesh));

        //Set Color
        if(m_material!=null)
        {
            QuadCellData quadData = data as QuadCellData;
            if(quadData!=null && quadData.MainColor != null)
            {
                m_material.color = quadData.MainColor;
                m_renderer.material = m_material;
            }
        }

        //Set Text
        if(m_sign!=null)
        {
            QuadCellData quadData = data as QuadCellData;
            if(quadData!=null && quadData.MainText != null)
            {
                m_sign.text = quadData.MainText;
            }
        }
    }

}

