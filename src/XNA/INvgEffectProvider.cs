using Microsoft.Xna.Framework.Graphics;

namespace NvgSharp
{
	public interface INvgEffectProvider
	{
		Effect CreateEffect(GraphicsDevice device, bool edgeAntiAlias);
	}
}
