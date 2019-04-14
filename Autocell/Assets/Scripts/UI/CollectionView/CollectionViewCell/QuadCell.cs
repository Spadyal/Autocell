using System;
using UnityEngine;
using UnityEngine.UI;

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
        private Text m_text;
        public Text MainText
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
    Text m_cellCategory;

    public override void SetData(object data)
    {
        base.SetData(data);

        if(m_renderer==null)
            m_renderer = GetComponent<Renderer>();

        if(m_renderer!=null && m_material==null)
        {
            m_material = m_renderer.material;
        }

        //Set Color
        if(m_material!=null)
        {
            QuadCellData quadData = data as QuadCellData;
            if(quadData!=null && quadData.MainColor != null)
            {
                m_material.color = quadData.MainColor;
                m_renderer.material = m_material;
            }
            if(quadData!=null && quadData.MainText != null)
            {
                m_cellCategory = quadData.MainText;
            }
        }
    }

}

