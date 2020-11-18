using System; 

public class Address { 

	string roadNo;
    string houseNo;
    string city;
    string country;

	public Address(string roadNo, string houseNo, 
				string city, string country) 
	{ 
		this.roadNo = roadNo; 
		this.houseNo = houseNo; 
		this.city = city; 
		this.country = country; 
	} 

	
	public string getAddress() 
	{ 
		return ("Road No: " + this.roadNo 
				+ "\nHouse No: " + this.houseNo 
				+ "\nCity: " + this.city + "\nCountry: " + this.country); 
	}
	
	public void changee(string roadNo, string houseNo, string city, string country) {
	    this.roadNo =  roadNo; 
		this.houseNo =  houseNo; 
		this.city =  city; 
		this.country = country; 
	}
    
}

public class Account { 

	int accountNumber;
    string accountName;
    double balance;
    int type;
    
    Address address;

	public Account(int accountNumber, string accountName, 
				double balance, Address address, int type) 
	{ 
		this.accountNumber = accountNumber; 
		this.accountName = accountName; 
		this.balance = balance;
		this.address = address; 
		this.type = type;
	} 
    
    public void Withdraw(int amount)
    {
        if(type == 1)
        {
            if(balance > amount) {
                balance -= amount;
                Console.WriteLine(this.accountName + " Withdraw: " + amount + "\nNew balance: " + this.balance);
            }
            else Console.WriteLine("balance cant be zero");
        }
        
        
        else
	    {
	        if(balance >= amount) {
                balance -= amount;
                Console.WriteLine(this.accountName + " Withdraw: " + amount + "\nNew balance: " + this.balance);
            }
	        else Console.WriteLine("Sorry! Transfer failed! Reason: Insufficient Balance.\n");
	    }
        
    }
    
	public void Diposit(int amount)
    {
        this.balance += amount;
        Console.WriteLine(this.accountName + " Diposit: " + amount + "\nNew balance: " + this.balance);


    }
    public void Transfer(Account A2, int tbalance)
	{
	    if (balance > tbalance)
	    {
	        balance -= tbalance;
	        A2.balance += tbalance;
	        Console.WriteLine(this.accountName + " Transfer: " + tbalance + "\nNew balance: " + this.balance);

	    }
	    else
	    {
	        Console.WriteLine("Sorry! Transfer failed! Reason: Insufficient Balance.\n");
	    }
	}
	
	public void ShowAccountInformation() 
	{ 
		Console.WriteLine("Account No: " + this.accountNumber 
				+ "\nAccount Name: " + this.accountName 
				+ "\nBalance: " + this.balance + "\nAccount Type: " + this.type + "\n" + address.getAddress()); 
	} 
    
    public void change(string accountName, int type, string roadNo, string houseNo, string city, string country)
    {
        this.accountName = accountName;
        this.type = type;
        address.changee(roadNo, houseNo, city, country);
    }
    
}

public class Bank {
    string bankName;
    Account[] myBank = new Account[2];
    
    public Bank(string name) {
        this.bankName = name;
    }
    
    public void AddAccount(int type) {
        Random rnd = new Random();
        int num1 = rnd.Next(22222222, 999999999);
        int num2 = rnd.Next(22222222, 999999999);
        
        Console.WriteLine("roadNo?");
        string roadNo = Console.ReadLine();
        Console.WriteLine("houseNo?");
        string houseNo = Console.ReadLine();
        Console.WriteLine("city?");
        string city = Console.ReadLine();
        Console.WriteLine("country?");
        string country = Console.ReadLine();
        Address ad1 = new Address(roadNo, houseNo, city, country);
        Address ad2 = new Address(roadNo, houseNo, city, country);
    	
    	
    	Console.WriteLine("accountName?");
        string accountName = Console.ReadLine();
        Console.WriteLine("balance?");
        double balance = Convert.ToDouble(Console.ReadLine());
        
        myBank[0] = new Account(num1, accountName, balance, ad1, type);
        Console.WriteLine("\n\n");
        myBank[1] = new Account(num2, accountName, balance, ad2, type);
    }
    
    public void changeAccount(int ac, string accountName, int type, string roadNo, string houseNo, string city,string country) {
        Console.WriteLine("Account Changed!");
        myBank[ac].change(accountName, type, roadNo, houseNo, city, country);
    }
    
    public void Transaction(int ac, int bc, int opt, int amount) {
        if(opt == 1) {
            myBank[ac].Withdraw(amount);
        }
        
        else if(opt == 2) {
            myBank[ac].Diposit(amount);
        }
        
        else myBank[ac].Transfer(myBank[bc], amount);
    }
    
    public void PrintAccountDetails(int ac)
    {
        myBank[ac].ShowAccountInformation();
    }
    
    public static int Main() {
        Bank b1 = new Bank("Krishi Bank");
        
        Console.WriteLine("Type 'open' for Open an account");
        Console.WriteLine("Type 'account' for Perform transactions on an account");
        Console.WriteLine("Type 'quit' for Exit the application");
         
        //  b1.DeleteAccount(0);
        //  b1.PrintAccountDetails(0);
         
        string first = Console.ReadLine(); 
  
        switch (first) 
        { 
            case "open": 
                Console.WriteLine("Opening Account");
                Console.WriteLine("Type 'saving' for open a savings account");
                Console.WriteLine("Type 'checking' for open a checking account");
                Console.WriteLine("Type 'quit' for exit the application");
                
                string second = Console.ReadLine();
                switch (second)
                {
                    case "saving":
                        Console.WriteLine("saving");
                        Console.WriteLine("Opening Account");
                        b1.AddAccount(1);
                        
                        break;
                        
                        
                    case "checking":
                        Console.WriteLine("checking");
                        Console.WriteLine("Opening Account");
                        b1.AddAccount(0);
                        b1.PrintAccountDetails(0);
                        break;
                        
                        
                    case "quit":
                        Console.WriteLine("Quiting");
                        return 0;
                }
                
                goto default; 
                
                
            case "account": 
                Console.WriteLine("Transaction");
                Console.WriteLine("Type 'deposit' for make a deposit");
                Console.WriteLine("Type 'withdraw' for Make a withdrawal");
                Console.WriteLine("Type 'transfer' for Make a transfer");
                Console.WriteLine("Type 'change' for Change owner name");
                Console.WriteLine("Type 'show' for Show the number transactions");
                Console.WriteLine("Type 'quit' for Exit the application");
                
                string third = Console.ReadLine();
                
                switch (third)
                {
                    case "deposit":
                        Console.WriteLine("Amount?");
                        int amount1 = Convert.ToInt32(Console.ReadLine());
                        b1.Transaction(0, 1, 2, amount1);
                        break;
                        
                    case "withdraw":
                        Console.WriteLine("Amount?");
                        int amount2 = Convert.ToInt32(Console.ReadLine());
                        b1.Transaction(0, 1, 1, amount2);
                        break;
                        
                    case "transfer":
                        Console.WriteLine("Amount?");
                        int amount3 = Convert.ToInt32(Console.ReadLine());
                        b1.Transaction(0, 1, 3, amount3);
                        break;
                    
                    case "change":
                        Console.WriteLine("accountName?");
                        string accountName = Console.ReadLine();
                        Console.WriteLine("Account type?");
                        int type = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("roadNo?");
                        string roadNo = Console.ReadLine();
                        Console.WriteLine("houseNo?");
                        string houseNo = Console.ReadLine();
                        Console.WriteLine("city?");
                        string city = Console.ReadLine();
                        Console.WriteLine("country?");
                        string country = Console.ReadLine();

                        Console.WriteLine("change name");
                        b1.changeAccount(0, accountName, type, roadNo, houseNo, city, country);
                        break;
                    
                    case "show":
                        Console.WriteLine("showing");
                        b1.PrintAccountDetails(0);
                        break;
                    
                    case "quit":
                        Console.WriteLine("Quiting");
                        return 0;
                }
                
                goto default; 
                
                
            case "quit": 
                Console.WriteLine("Exiting the application"); 
                return 0; 
                
                
            default:
                Console.WriteLine("Type 'open' for Open an account");
                Console.WriteLine("Type 'account' for Perform transactions on an account");
                Console.WriteLine("Type 'quit' for Exit the application"); 
                
                string again = Console.ReadLine();
                if(again == "open") goto case "open";
                else if(again == "account") goto case "account";
                return 0;
        }
        
        return 0;

    }  
}
