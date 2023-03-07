using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DistrictHeating
{
    public interface IPanel
    {
        IGraphics CreateGraphics();
    }

    public interface IGraphics: IDisposable
    {
        void Clear(int color);
        void DrawLine(int color, float x1, float y1, float x2, float y2);
    }
}
