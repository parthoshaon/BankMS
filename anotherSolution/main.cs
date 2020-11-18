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
            
            	
            	public string GetAddress() 
            	{ 
            		return ("Road No: " + this.roadNo 
            				+ "\nHouse No: " + this.houseNo 
            				+ "\nCity: " + this.city + "\nCountry: " + this.country); 
            	}
    
}

public class Account { 

            	int accountNumber;
                string accountName;
                double balance;
                Address address;
            
            	public Account(int accountNumber, string accountName, 
            				double balance, Address address) 
            	{ 
            		this.accountNumber = accountNumber; 
            		this.accountName = accountName; 
            		this.balance = balance;
            		this.address = address; 
            	} 
                
                public void Withdraw(int amount)
                {
                    if(balance > amount)
                    {
                        balance -= amount;
                        Console.WriteLine(this.accountName + " Withdraw: " + amount + "\nNew balance: " + this.balance);
                    }
                    
                    else
            	    {
            	        Console.WriteLine("Sorry insufficient balance.\n");
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
            	        Console.WriteLine("Sorry transfer failed!\n");
            	    }
            	}
            	
            	public void ShowAccountInformation() 
            	{ 
            		Console.WriteLine("\nAccount No: " + this.accountNumber 
            				+ "\nAccount Name: " + this.accountName 
            				+ "\nBalance: " + this.balance + "\n" + address.GetAddress()); 
            	} 
    
}

public class Bank {
                string bankName;
                int number = 0;
                Account[] myBank = new Account[2];
                
                public Bank(string name) {
                    this.bankName = name;
                }
                
                public void AddAccount() {
                    Random rnd = new Random();
                    int num1 = rnd.Next(22222222, 999999999);
            
                    Console.WriteLine("accountName?");
                    string accountName = Console.ReadLine();
                    Console.WriteLine("balance?");
                    double balance = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("roadNo?");
                    string roadNo = Console.ReadLine();
                    Console.WriteLine("houseNo?");
                    string houseNo = Console.ReadLine();
                    Console.WriteLine("city?");
                    string city = Console.ReadLine();
                    Console.WriteLine("country?");
                    string country = Console.ReadLine();
                    
                    Address ad1 = new Address(roadNo, houseNo, city, country);
                    myBank[number++] = new Account(num1, accountName, balance, ad1);
                }
                
                public void DeleteAccount(int ac) {
                    myBank[ac] = null;
                    Console.WriteLine("This account has been deleted!");
                }
                
                public void Transaction(int ac, int bc, int opt, int amount) {
                    if(opt == 1) {
                        myBank[ac].Withdraw(amount);
                    }
                    
                    if(opt == 2) {
                        myBank[ac].Diposit(amount);
                    }
                    
                    else myBank[ac].Transfer(myBank[bc], amount);
                }
                
                public void PrintAccountDetails(int ac)
                {
                    Console.WriteLine("Bank Name: " + this.bankName);
                    myBank[ac].ShowAccountInformation();
                }
    
    public static void Main(string[] args) 
    { 
                Console.WriteLine("Enter a bank bame");
                Bank myBank = new Bank(Console.ReadLine());
                myBank.AddAccount();

                Console.WriteLine("Type 'deposit' for make a deposit");
                Console.WriteLine("Type 'withdraw' for Make a withdrawal");
                Console.WriteLine("Type 'transfer' for Make a transfer");
                Console.WriteLine("Type 'delete' for Delete the account");
                Console.WriteLine("Type 'show' for Show the number transactions");
                Console.WriteLine("Type 'quit' for Exit the application");
                
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "deposit":
                        Console.WriteLine("Amount?");
                        int amount1 = Convert.ToInt32(Console.ReadLine());
                        myBank.Transaction(0, 1, 2, amount1);
                        break;
                        
                    case "withdraw":
                        Console.WriteLine("Amount?");
                        int amount2 = Convert.ToInt32(Console.ReadLine());
                        myBank.Transaction(0, 1, 1, amount2);
                        break;
                        
                    case "transfer":
                        Console.WriteLine("\n\n\nATTENTION!!!!!\n\nYou have to make another account to trnfer money to that account");
                        Console.WriteLine("\n\nDo you want? Type YES / NO");
                        string flag = Console.ReadLine();
                        if(flag == "YES") myBank.AddAccount();
                        else break;
                        
                        Console.WriteLine("Enter amount to transfer the money");
                        int amount3 = Convert.ToInt32(Console.ReadLine());
                        myBank.Transaction(0, 1, 3, amount3);
                        myBank.PrintAccountDetails(1);
                        break;
                    
                    case "delete":
                        myBank.DeleteAccount(0);
                        break;
                    
                    case "show":
                        Console.WriteLine("showing");
                        myBank.PrintAccountDetails(0);
                        break;
                    
                    case "quit":
                        Console.WriteLine("Quiting");
                        break;
                }

    } 
}
