using System;
using System.Collections.Generic;

class Account
{
    public string AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal Balance { get; private set; }
    private List<string> TransactionHistory { get; }
    public string Password { get; }

    public Account(string accountNumber, string accountHolder, decimal balance, string password)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = balance;
        Password = password;
        TransactionHistory = new List<string>();
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            TransactionHistory.Add($"{amount} TL yatırıldı. Yeni bakiye: {Balance} TL");
        }
        else
        {
            Console.WriteLine("Geçersiz miktar. Lütfen pozitif bir miktar girin.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount >= 50 && amount <= 10000)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                TransactionHistory.Add($"{amount} TL çekildi. Yeni bakiye: {Balance} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye veya geçersiz miktar. İşlem gerçekleştirilemedi.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz miktar. Çekilecek para 50 ile 10,000 TL arasında olmalıdır.");
        }
    }

    public void CheckAccount()
    {
        Console.WriteLine($"Hesap Numarası: {AccountNumber}");
        Console.WriteLine($"Hesap Sahibi: {AccountHolder}");
        Console.WriteLine($"Bakiye: {Balance} TL");
    }

    public void AccountActivities()
    {
        Console.WriteLine("Hesap hareketleri listeleniyor...");
        foreach (var transaction in TransactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }

    public bool VerifyPassword(string passwordToVerify)
    {
        return Password == passwordToVerify;
    }
}
