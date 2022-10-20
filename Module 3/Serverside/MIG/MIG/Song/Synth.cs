using DanhoLibrary;
using DanhoLibrary.Extensions;
using System.Collections.Generic;

namespace MIG.Song
{
    public class Synth
    {
        public List<SynthLayer> Layers { get; private set; }
        public List<string> Effects { get; private set; }

        public Synth(bool effects = true, bool multipleLayers = true, int maxLayers = 3)
        {
            if (effects) InitializeEffects();
            if (multipleLayers) InitializeLayers(maxLayers);
        }

        private List<string> InitializeEffects()
        {
            Effects = new List<string>();
            int amountOfEffects = ConsoleItems.RandomNumber(Effect.AllEffects.Length);

            for (int i = 0; i < amountOfEffects; i++)
            {
                string effect = string.Empty;
                while (string.IsNullOrEmpty(effect) || Effects.Contains(effect)) 
                    effect = Effect.AllEffects.GetRandomItem();
                Effects.Add(effect);
            }

            return Effects;
        }
        private List<SynthLayer> InitializeLayers(int maxLayers)
        {
            Layers = new List<SynthLayer>();
            int amountOfLayers = ConsoleItems.RandomNumber(maxLayers);

            for (int i = 0; i < amountOfLayers; i++)
            {
                SynthLayer layer = new();
                while (Layers.Contains(layer))
                    layer = new();
                Layers.Add(layer);
            }

            return Layers;
        }
    }
}