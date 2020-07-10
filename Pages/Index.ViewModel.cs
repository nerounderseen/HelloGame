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

        private Canvas2DContext _context;
        protected BECanvasComponent _canvasReference;
        protected ElementReference ashRef;
        protected override async Task OnAfterRenderAsync(bool f)
        {
            this._context = await this._canvasReference.CreateCanvas2DAsync();
            await this._context.SetFillStyleAsync("cornflowerblue");
            await this._context.FillRectAsync(0, 0, 1024, 768);
            await this._context.DrawImageAsync(ashRef, (currentFrame - 1) * 64, yCor, 64, 64, AD, WS, 64, 64);
        }

        protected void OnKeypress(KeyboardEventArgs e)
        {
            switch (e.Key.ToLower())
            {
                //Move Up
                case "w":
                    yCor = 192;
                    currentFrame++;
                    if (currentFrame > maxFrames)
                        currentFrame = 1;
                    WS -= 5;
                    break;
                //Move Down
                case "s":
                    yCor = 0;
                    currentFrame++;
                    if (currentFrame > maxFrames)
                        currentFrame = 1;
                    WS += 5;
                    break;
                //Move Left
                case "a":
                    yCor = 64;
                    currentFrame++;
                    if (currentFrame > maxFrames)
                        currentFrame = 1;
                    AD -= 5;
                    break;
                //Move Right
                case "d":
                    yCor = 128;
                    currentFrame++;
                    if (currentFrame > maxFrames)
                        currentFrame = 1;
                    AD += 5;
                    break;
            }
        }
    }
}
