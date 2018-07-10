namespace Cryptanalysis
{
    public class DecryptCandidate
    {
        public DecryptCandidate(string text, int score = 0)
        {
            plainText = text;
            fitness = score;
        }
        public string plainText { get; set; }
        public int fitness{ get; set; }
    }
}
