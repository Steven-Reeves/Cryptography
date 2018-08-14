using PlayfairCryptanalysis;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        AnnealingAlgorithm testAlgorithm = new AnnealingAlgorithm();
        Playfair playfair = new Playfair("stary");
        string ciphertext = "";

        [TestInitialize]
        public void TestInit()
        {
            string plaintext = "Whoever misleads the upright into an evil way will fall into his own pit but the blameless will have a goodly inheritance To the King of ages, immortal, invisible, the only God, be honor and glory forever and ever Therefore God has highly exalted him and bestowed on him the name that is above every name so that at the name of Jesus every knee should bow, in heaven and on earth and under the earth and every tongue confess that Jesus Christ is Lord to the glory of God the Father";
            //ciphertext = playfair.Encrypt(plaintext);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var translation = testAlgorithm.SimulatedAnnealingAnalysis("VIPDXCSPGAKFDITAKCXMAKHIAHVCWDPCWHIZRSAOKZQLYIGKVCNIGAWAOQHAGSRVCNFCIYPBKFRUAUKGGITWDRIMWIQFHOKCAKARVHCRNAKCLKMHQDSIBRGONPYAYIHOWHAGFGCRKCPOQFIMECCKPOPATOBIIQYSDQEKXCYROCCXKECNKEFBPABKWIITTGKHIGRFWRHYFEIKOSOCCFTAWAFEPOIKNSKCOTPBCNRAGASDNWKRCXKETQSOBRNAITARRVCNCPSODPBFBSRBXCYSHPKRBRINZGECWAHOKCTWCPTOIWPCRYCNTOBWOCKECNKRDRYAITOCCXKESAPOMSFDPOBFRUTAITRCBSTBKTGAAHYGPACANAKCHGPAAQBLWICNFBRAKCER");

            File.WriteAllText("output.txt", translation[0] + "\n" + translation[1] + "\n" + translation[2]);
        }
    }
}
