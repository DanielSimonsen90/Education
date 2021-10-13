using Encryption;
using System;
using Xunit;

namespace EncryptionTest
{
    public class UnitTest1
    {
        [Fact]
        public void Encrypt()
        {
            Assert.Equal("XZHHJXXKZQ ZSNY YJXY", Vigenere.Encrypt("Successful unit test", 5));
            Assert.Equal("SVANYYL QBAR", Vigenere.Encrypt("Finally done!", 13));

            Assert.Equal("TGGP DM Z QANN", Vigenere.Encrypt("This is a test", "abcdefg"));
        }

        [Fact]
        public void Decrypt()
        {
            Assert.Equal("SUCCESSFUL UNIT TEST", Vigenere.Decrypt("XZHHJXXKZQ ZSNY YJXY", 5));
            Assert.Equal("FINALLY DONE", Vigenere.Decrypt("SVANYYL QBAR", 13));
        }

        //[Fact]
        //public void FindKey()
        //{
        //    Assert.Equal(5, Vigenere.FindKey("Successful unit test"));
        //    Assert.Equal(13, Vigenere.FindKey("Finally done!"));
        //}

        //[Fact]
        //public void EncryptNoKey()
        //{
        //    Assert.Equal("XZHHJXXKZQ ZSNY YJXY", Vigenere.Encrypt("Successful unit test"));
        //    Assert.Equal("SVANYYL QBAR", Vigenere.Encrypt("Finally done!"));
        //}

        //[Fact]
        //public void DecryptNoKey()
        //{
        //    Assert.Equal("SUCCESSFUL UNIT TEST", Vigenere.Decrypt("XZHHJXXKZQ ZSNY YJXY"));
        //    Assert.Equal("FINALLY DONE", Vigenere.Decrypt("SVANYYL QBAR"));
        //}
    }
}
