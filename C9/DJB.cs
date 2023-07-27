namespace C9
{
    class DJB
    {
        public static uint GetHash(string str)
        {
            uint hash = 5381;
            uint i = 0;

            for (i = 0; i < str.Length; i++)
            {
                hash = ((hash << 5) + hash) + ((byte)str[(int)i]);
            }

            return hash;
        }
    }
}
