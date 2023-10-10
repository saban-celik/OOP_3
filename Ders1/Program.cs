
class Program
{
    static void Main()
    {
        List<Account> accounts = new List<Account>
        {
            new Account("12345", "John Doe", 1000, "password1"),
            new Account("67890", "Jane Smith", 500, "password2"),
            // Diğer hesaplar burada...
        };

        Console.WriteLine("Hesap Numarası: ");
        string accountNumber = Console.ReadLine();

        Console.WriteLine("Şifre: ");
        string password = Console.ReadLine();

        Account loggedInAccount = null;

        foreach (var account in accounts)
        {
            if (account.AccountNumber == accountNumber && account.VerifyPassword(password))
            {
                loggedInAccount = account;
                break;
            }
        }

        if (loggedInAccount == null)
        {
            Console.WriteLine("Geçersiz hesap numarası veya şifre.");
            return;
        }

        Console.WriteLine($"Hoş geldiniz, {loggedInAccount.AccountHolder}!");

        while (true)
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1. Para Yatırma");
            Console.WriteLine("2. Para Çekme");
            Console.WriteLine("3. Hesap Bilgilerini Gösterme");
            Console.WriteLine("4. Hesap Hareketlerini Gösterme");
            Console.WriteLine("5. Çıkış");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Yatırmak istediğiniz miktarı girin: ");
                    decimal depositAmount;
                    if (decimal.TryParse(Console.ReadLine(), out depositAmount))
                    {
                        loggedInAccount.Deposit(depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz miktar. Lütfen pozitif bir miktar girin.");
                    }
                    break;

                case "2":
                    Console.Write("Çekmek istediğiniz miktarı girin: ");
                    decimal withdrawAmount;
                    if (decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                    {
                        loggedInAccount.Withdraw(withdrawAmount);
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz miktar. Lütfen pozitif bir miktar girin.");
                    }
                    break;

                case "3":
                    loggedInAccount.CheckAccount();
                    break;

                case "4":
                    loggedInAccount.AccountActivities();
                    break;

                case "5":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
