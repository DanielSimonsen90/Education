namespace oofoop
{
    public class SmartPhone
    {
        public SmartPhone(string Brand, string Model, MobilePay MobilePayApp)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.MobilePayApp = MobilePayApp;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        private MobilePay MobilePayApp { get; set; }

        public string UseMobilePay(float amount)
        {
            if (!MobilePayApp.HasApp)
                return "Your Smart Phone doesn't have MobilePay installed!";
            else if (!MobilePayApp.HasConnection)
                return "MobilePay doesn't have connection to your Card!";

            if (MobilePayApp.AttemptPayment(amount) != "successful")
                return "Payment failed! Do you have enough money on card?";
            return $"successful";
        }
    }
}