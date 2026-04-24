using Microsoft.Xna.Framework.Graphics;

namespace NvgSharp
{
	public sealed class XNARendererOptions
	{
		public Effect Effect { get; set; }

		public INvgEffectProvider EffectProvider { get; set; }

		public NvgGraphicsBackend GraphicsBackend { get; set; } = NvgGraphicsBackend.Auto;
	}
}
