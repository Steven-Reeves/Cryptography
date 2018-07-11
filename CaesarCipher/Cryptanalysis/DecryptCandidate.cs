namespace Cryptanalysis
{
    public class DecryptCandidate
    {
        public DecryptCandidate(string text, int decryptKey = 0)
        {
            plainText = text;
            key = decryptKey;
        }
        public string plainText { get; set; }
        public int fitness{ get; set; }
        public int key = -1;
    }
}
