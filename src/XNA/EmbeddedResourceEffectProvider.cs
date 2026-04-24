using System;
using Microsoft.Xna.Framework.Graphics;

namespace NvgSharp
{
	public sealed class EmbeddedResourceEffectProvider : INvgEffectProvider
	{
		public EmbeddedResourceEffectProvider()
			: this(NvgGraphicsBackend.Auto)
		{
		}

		public EmbeddedResourceEffectProvider(NvgGraphicsBackend graphicsBackend)
		{
			GraphicsBackend = graphicsBackend;
		}

		public NvgGraphicsBackend GraphicsBackend { get; }

		public Effect CreateEffect(GraphicsDevice device, bool edgeAntiAlias)
		{
			if (device == null)
			{
				throw new ArgumentNullException(nameof(device));
			}

			return new Effect(device, Resources.GetNvgEffectSource(edgeAntiAlias, GraphicsBackend));
		}
	}
}
