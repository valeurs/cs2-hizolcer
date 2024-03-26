using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClickableTransparentOverlay;
using ImGuiNET;

namespace CS2HizOlcer
{
    public class Renderer : Overlay
    {
        public int speed = 0;
        int maxSpeed = 0;

        Vector4 white = new Vector4(1, 1, 1, 1);
        Vector4 green = new Vector4(0, 1, 0, 1);
        Vector4 yellow = new Vector4(1, 1, 0, 1);
        Vector4 red = new Vector4(1, 0, 0, 1);

        protected override void Render()
        {
            if (speed > maxSpeed)
                maxSpeed = speed;

            ImGui.Begin("Hiz Olcer");

            ImGui.TextColored(GetSpeedColor(maxSpeed), $"Max Hiz: {maxSpeed}");
            ImGui.TextColored(GetSpeedColor(speed), $"Simdiki hiz: {speed}");
            ImGui.TextColored(red, "Yazar: scarew");
        }

        Vector4 GetSpeedColor(int speed)
        {
            if (speed > 500)
                return red;
            if (speed > 400)
                return yellow;
            if (speed > 300)
                return green;
            return white;
        }

    }
}
