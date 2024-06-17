using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OPENTKTEST
{
    public class Game : GameWindow
    {
        float[] vertices = {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
         0.5f, -0.5f, 0.0f, //Bottom-right vertex
         0.0f,  0.5f, 0.0f  //Top vertex
        };

        int VertexBufferObject; //stores vertex buffer

        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }
        //load
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f,0.3f,0.4f,1.0f);
            //all this stores buffers on your graphics card witihin it's memory
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VertexBufferObject);
        }
        //update
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            base.OnUpdateFrame(args);
        }
        //draw
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args); 
            GL.Clear(ClearBufferMask.ColorBufferBit);
            SwapBuffers();
        }
        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);
            base.OnFramebufferResize(e);
        }
    }
}
