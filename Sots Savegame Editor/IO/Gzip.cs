using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.Editor
{
    public static class Gzip
    {
        //internal const String saveGameFileName = @"D:\test\kill them all.sav";
        //internal const String saveGameFileName = @"D:\test\Space Olympics.sav";
        //internal const String saveGameFileName = @"E:\Test Data\Cheat 2.sav";
        //internal const String saveGameFileName = @"E:\Test Data\Cheat.sav";
        //internal const String saveGameFileName = @"E:\Test Data\Cheaters Never Prosper.sav";
        internal const String saveGameFileName = @"E:\Test Data\Dolphins in Space!.sav";


        public static void Uncompress()
        {
            FileInfo saveInfo = new FileInfo(saveGameFileName);

            using (FileStream saveGame = saveInfo.OpenRead())
            {
                using (GZipStream compressedFile = new GZipStream(saveGame, CompressionMode.Decompress))
                {
                    using (FileStream decompressed = new FileStream(String.Format("{0}.inflate.dat", saveGameFileName), FileMode.CreateNew, FileAccess.Write))
                    {
                        Byte[] buffer = new Byte[4096];     //buffer
                        Int32 bufferFilled = 0;

                        while ( (bufferFilled = compressedFile.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            decompressed.Write(buffer, 0, bufferFilled);
                        }
                    }
                }
            }
        }


        public static Stream Uncompress(Stream Source)
        {
            MemoryStream memStrm = new MemoryStream();
            using (GZipStream gzip = new GZipStream(Source, CompressionMode.Decompress))
            {
                gzip.CopyTo(memStrm);
            }

            memStrm.Seek(0L, SeekOrigin.Begin);
            return memStrm;
        }

        public static Stream Compress(Stream Source)
        {
            MemoryStream memStrm = new MemoryStream(), memStrmRet = new MemoryStream();
            using(GZipStream gzip = new GZipStream(memStrm, CompressionMode.Compress, true))
            {
                Source.Seek(0L, SeekOrigin.Begin);
                Source.CopyTo(gzip);
                Source.Dispose();   //needs to be done somewhere.
            }
            memStrm.Seek(0L, SeekOrigin.Begin);
            memStrm.CopyTo(memStrmRet);

            memStrmRet.Seek(0L, SeekOrigin.Begin);
            return memStrmRet;
        }

        //private static MemoryStream CopyStream(Stream Source, CompressionMode Mode)
        //{
        //    MemoryStream memStrm = new MemoryStream();
        //    using (GZipStream gzip = new GZipStream(Source, Mode))
        //    {
        //        gzip.CopyTo(memStrm);
        //    }

        //    memStrm.Seek(0L, SeekOrigin.Begin);
        //    return memStrm;
        //}

        private static void Test(Stream Compressed, Stream Orig)
        {
            Stream uc = Uncompress(Compressed);
        }
    }
}