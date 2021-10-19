using Encryption;
using System;
using Xunit;

namespace EncryptionTest
{
    public class UnitTest1
    {
        [Fact]
        public void EncryptCeasar()
        {
            Assert.Equal("XZHHJXXKZQ ZSNY YJXY", Ceasar.Encrypt("Successful unit test", 5));
            Assert.Equal("SVANYYL QBAR", Ceasar.Encrypt("Finally done!", 13));
            Assert.Equal("FCHXYL", Ceasar.Encrypt("Linder", 20));
        }

        [Fact]
        public void DecryptCeasar()
        {
            Assert.Equal("SUCCESSFUL UNIT TEST", Ceasar.Decrypt("XZHHJXXKZQ ZSNY YJXY", 5));
            Assert.Equal("FINALLY DONE", Ceasar.Decrypt("SVANYYL QBAR", 13));
        }

        [Fact]
        public void EncryptVigenere()
        {
            Assert.Equal("TIKV MX G TFUW", Vigenere.Encrypt("This is a test", "abcdefg"));
            Assert.Equal("KER GNCU HEM VPEEH AGY HJ AVH BJIT PDN AEET OL", Vigenere.Encrypt("Hey guys, are there any of you that can help me?", "datatechnician"));
        }

        [Fact]
        public void DecryptVigenere()
        {
            Assert.Equal("THIS IS THE CRAPPYPATTY SECRET FORMULAR", Vigenere.Decrypt("DYCK BQ DYE DBRJHRNKKTZ CVWJXR PFRNECUJ", "krustykrab"));
            Assert.Equal("HAVE A WONDERFUL DAY", Vigenere.Decrypt("TUXL L KJRPYTMFZ YEK", "muchlove"));
        }
    }
}
