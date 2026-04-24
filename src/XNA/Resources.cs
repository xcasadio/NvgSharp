using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;

namespace NvgSharp
{
	internal static class Resources
	{
		private static readonly Dictionary<string, byte[]> _effectSources = new Dictionary<string, byte[]>();

#if MONOGAME
		private static bool? _isOpenGL;
#endif

		public static byte[] GetNvgEffectSource(bool edgeAntiAlias)
		{
			return GetNvgEffectSource(edgeAntiAlias, NvgGraphicsBackend.Auto);
		}

		public static byte[] GetNvgEffectSource(bool edgeAntiAlias, NvgGraphicsBackend graphicsBackend)
		{
			var path = GetEffectResourcePath(edgeAntiAlias, graphicsBackend);

			if (_effectSources.TryGetValue(path, out var cachedEffectSource))
			{
				return cachedEffectSource;
			}

			var assembly = typeof(Resources).Assembly;
			using (var ms = new MemoryStream())
			using (var stream = assembly.GetManifestResourceStream(path))
			{
				if (stream == null)
				{
					throw new InvalidOperationException("Unable to find embedded effect resource '" + path + "'.");
				}

				stream.CopyTo(ms);
				var result = ms.ToArray();
				_effectSources[path] = result;
				return result;
			}
		}

		private static string GetEffectResourcePath(bool edgeAntiAlias, NvgGraphicsBackend graphicsBackend)
		{
			var name = "Effect";
			if (edgeAntiAlias)
			{
				name += "_AA";
			}

#if MONOGAME
			var resolvedBackend = graphicsBackend == NvgGraphicsBackend.Auto
				? (IsOpenGL ? NvgGraphicsBackend.OpenGL : NvgGraphicsBackend.DirectX)
				: graphicsBackend;

			return resolvedBackend switch
			{
				NvgGraphicsBackend.DirectX => "NvgSharp.Resources." + name + ".dx11.mgfxo",
				NvgGraphicsBackend.OpenGL => "NvgSharp.Resources." + name + ".ogl.mgfxo",
				NvgGraphicsBackend.OpenGLES => "NvgSharp.Resources." + name + ".ogl.mgfxo",
				_ => throw new InvalidOperationException("Unsupported graphics backend '" + resolvedBackend + "'.")
			};
#elif FNA
			return "NvgSharp.Resources." + name + ".fxb";
#endif
		}

#if MONOGAME		
		public static bool IsOpenGL
		{
			get
			{
				if (_isOpenGL == null)
				{
					_isOpenGL = (from f in typeof(GraphicsDevice).GetFields(BindingFlags.NonPublic |
						 BindingFlags.Instance)
							 where f.Name == "glFramebuffer"
							 select f).FirstOrDefault() != null;
				}

				return _isOpenGL.Value;
			}
		}
#endif
	}
}
