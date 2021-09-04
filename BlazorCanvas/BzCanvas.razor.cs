﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public partial class BzCanvas
    {
        public Viewer Viewer { get; set; }

        /// <summary>
        /// 控件宽度
        /// </summary>
        [Parameter] public string Width { get; set; }
        /// <summary>
        /// 控件高度
        /// </summary>
        [Parameter] public string Height { get; set; }


        //TODO:此处需要通过JS交互获得证实的Svg尺寸，应为宽度可以设置百分比，或者界面发生调整，目前假设不使用百分比
        private int _SvgWidth;
        public int SvgWidth
        {
            get
            {
                int.TryParse(Width, out int _SvgWidth);
                return _SvgWidth;
            }
            set => _SvgWidth = value;
        }

        private int _SvgHeight;
        public int SvgHeight
        {
            get
            {
                int.TryParse(Height, out int _SvgHeight);
                return _SvgHeight;
            }
            set => _SvgHeight = value;
        }

        public BzCanvas()
        {
            Viewer = new Viewer(this);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Viewer.Init();
        }



        public void OnMouseDown(MouseEventArgs e)
        {
            Viewer.MouseDown(e);
        }
        public void OnMouseUp(MouseEventArgs e)
        {
            Viewer.MouseUp(e);
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            Viewer.MouseMove(e);
        }

        public void OnWheel(WheelEventArgs e)
        {
            Viewer.MouseWheel(e);
        }

        //      /// <summary>
        //      /// 获得一些
        //      /// </summary>
        //      void string GetDebugInfo()
        //{

        //}

    }
}