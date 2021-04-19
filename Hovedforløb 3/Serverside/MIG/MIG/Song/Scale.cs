using DanhoLibrary;
using DanhoLibrary.Extensions;

namespace MIG.Song
{
    public class Scale
    {
        public static string[] Keys => new string[] { "A", "A#/B♭", "B", "C", "C#/D♭", "D", "D#/E♭", "E", "F", "F#/G♭", "G" };
        public static string[] Types => new string[] { "Major", "Minor" };

        public string Type, Key;
        public readonly int Percentage;
        public bool SpecificType, SpecificKey;

        /// <param name="percentage">
        /// Percentage to get Major
        /// </param>
        public Scale(int percentage)
        {
            Type = GenerateType(Percentage = percentage);
            Key = GenerateKey();
        }

        private static string GenerateType(int percentage) => ConsoleItems.RandomNumber(100) >= percentage ? "Major" : "Minor";
        private static string GenerateKey() => Keys.GetRandomItem();

        public override string ToString() => $"{Key} {Type}";
        public string GetSpecifics() =>
            SpecificKey && SpecificType ? $"{Key} {Type}" :
            SpecificKey ? Key :
            Type;
    }

}