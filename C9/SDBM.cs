namespace C9
{
    class SDBM
    {
        public static uint GetHash(string str)
        {
            uint hash = 5381;
            uint i = 0;

            for (i = 0; i < str.Length; i++)
            {
                hash = (hash << 6) + ((byte)str[(int)i]) + (hash << 16) - hash;
            }

            return hash;
        }
    }
}
