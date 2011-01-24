using System;
using Android.Content;
using Android.Util;
using Android.Views;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES11;
using OpenTK.Platform.Android;

namespace MonoDroidSamples.DemoActivities.OpenGL
{
	public class CubeView : AndroidGameView
	{
		#region Matrices
		float[] _cube = {
			-0.5f, 0.5f, 0.5f,
			0.5f, 0.5f, 0.5f,
			0.5f, -0.5f, 0.5f,
			-0.5f, -0.5f, 0.5f,
			-0.5f, 0.5f, -0.5f,
			0.5f, 0.5f, -0.5f,
			0.5f, -0.5f, -0.5f,
			-0.5f, -0.5f, -0.5f,
		};

		byte[] _triangles = {
			1, 0, 2, // front
			3, 2, 0,
			6, 4, 5, // back
			4, 6, 7,
			4, 7, 0, // left
			7, 3, 0,
			1, 2, 5, //right
			2, 6, 5,
			0, 1, 5, // top
			0, 5, 4,
			2, 3, 6, // bottom
			3, 7, 6,
		};

		float[] _cubeColors = {
			1.0f, 0.0f, 0.0f, 1.0f,
			0.0f, 1.0f, 0.0f, 1.0f,
			0.0f, 0.0f, 1.0f, 1.0f,
			0.0f, 1.0f, 1.0f, 1.0f,
			1.0f, 0.0f, 0.0f, 1.0f,
			0.0f, 1.0f, 0.0f, 1.0f,
			0.0f, 0.0f, 1.0f, 1.0f,
			0.0f, 1.0f, 1.0f, 1.0f,
		};
		#endregion

		private float[] _rotation;
		private float[] _rateOfRotation;
		private float _translate;

		public CubeView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			GLContextVersion = GLContextVersion.Gles1_1;

			_rateOfRotation = new float[] { 30, 45, 0 };
			_rotation = new float[] { 0, 0, 0 };
			_translate = 0;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Run(30);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			base.OnUpdateFrame(e);

			for (int i = 0; i < 3; i++)
			{
				_rotation[i] += (float)(_rateOfRotation[i] * e.Time);
			}
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			base.OnRenderFrame(e);

			GL.Enable(All.CullFace);
			GL.MatrixMode(All.Projection);
			GL.LoadIdentity();
			GL.Ortho(-1.0f, 1.0f, -1.5f, 1.5f, -1.0f, 1.0f);

			GL.MatrixMode(All.Modelview);
			GL.LoadIdentity();
			GL.Translate(_translate, _translate, 0.0f);
			GL.Rotate(_rotation[0], 1.0f, 0.0f, 0.0f);
			GL.Rotate(_rotation[1], 0.0f, 1.0f, 0.0f);
			GL.Rotate(_rotation[2], 0.0f, 1.0f, 0.0f);

			GL.ClearColor(0, 0, 0, 1.0f);
			GL.Clear((uint)All.ColorBufferBit);

			GL.VertexPointer(3, All.Float, 0, _cube);
			GL.EnableClientState(All.VertexArray);
			GL.ColorPointer(4, All.Float, 0, _cubeColors);
			GL.EnableClientState(All.ColorArray);
			GL.DrawElements(All.Triangles, 36, All.UnsignedByte, _triangles);

			SwapBuffers();
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			_translate += 0.1f;

			return base.OnTouchEvent(e);
		}
	}
}