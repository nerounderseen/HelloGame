using System;
using System.Threading.Tasks;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HelloGame
{
    public class IndexViewModel : ComponentBase
    {

        int maxFrames = 4;
        int currentFrame = 1;
        int AD = 0;
        int WS = 0;
        int yCor;
        int xBound = 1024;
        int yBound = 768;
        private Canvas2DContext _context;
        protected BECanvasComponent _canvasReference;
        protected ElementReference ashRef;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this._context = await this._canvasReference.CreateCanvas2DAsync();
                await this._context.SetFillStyleAsync("cornflowerblue");
                await this._context.FillRectAsync(0, 0, xBound, yBound);
                await this._context.DrawImageAsync(ashRef, 0, 0, 64, 64, 0, 0, 64, 64);
            }
            else
            {
                await Task.Delay(17);
                await this._context.SetFillStyleAsync("cornflowerblue");
                await this._context.FillRectAsync(0, 0, xBound, yBound);
                await this._context.DrawImageAsync(ashRef, (currentFrame - 1) * 64, yCor, 64, 64, AD, WS, 64, 64);
                if (currentFrame > maxFrames)
                    currentFrame = 1;
            }
        }

        protected void OnKeypress(KeyboardEventArgs e)
        {
            switch (e.Key.ToLower())
            {
                //Move Up
                case "w":
                    yCor = 192;
                    currentFrame++;
                    WS -= 5;
                    if (WS < 0)
                        WS = 0;
                    break;
                //Move Down
                case "s":
                    yCor = 0;
                    currentFrame++;
                    WS += 5;
                    if (WS > yBound - 64)
                        WS = 706;
                    break;
                //Move Left
                case "a":
                    yCor = 64;
                    currentFrame++;
                    AD -= 5;
                    if (AD < 0)
                        AD = 0;
                    break;
                //Move Right
                case "d":
                    yCor = 128;
                    currentFrame++;
                    AD += 5;
                    if (AD > xBound - 64)
                        AD = 960;
                    break;
            }
        }
    }
}
