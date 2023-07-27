namespace C9
{
    class LoseLose
    {
        public static uint GetHash(string str)
        {
            uint hash = 5381;
            uint i = 0;

            for (i = 0; i < str.Length; i++)
            {
                hash = (byte)str[(int)i];
            }

            return hash;
        }
    }
}
