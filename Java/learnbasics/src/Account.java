package DarrenIsLearningJava;
import java.util.Date;
import java.util.ArrayList;

public class Account {

    private int id;
    private double balance;
    private double annualInterestrate = 4.5;
    private Date CreatedDate;
    private Client clientsList;
    private ArrayList<Transaction> transList;


    public Account(int accountID, double accountBalance, double accountInterestrate, Client varClients){
        this.id = accountID;
        this.balance = accountBalance;
        this.annualInterestrate = accountInterestrate;
        this.clientsList = varClients;
        
        transList = new ArrayList<>();

        CreatedDate = new Date();       
        CreatedDate.getTime();
    }

    public boolean withdraw(double amount){
        if(balance < amount) return false;
        
            balance -= amount;
            this.transList.add(new Transaction('W', amount, this.balance, "Withdrawn "+amount,new Date()));
            
            return true;
    }

    public void deposit(double amount){
        balance += amount;
        this.transList.add(new Transaction('D', amount, this.balance, "Deposited "+amount,new Date()));
    }

    public int countTran(char type){
        int count = 0;
        for(Transaction tran : transList)
            if(tran.getType() == type)
                count++;
        
        return count;
    }

    public String toString(){
        String s = "Client Details : " + this.clientsList + "\n" + "Account ID : " + " "  + this.id + " " + this.balance + " " + this.annualInterestrate +  " " + CreatedDate;
        return s;
    }

    /**
     * @return int return the id
     */
    public int getId() {
        return this.id;
    }

    /**
     * @param id the id to set
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * @return double return the balance
     */
    public double getBalance() {
        return this.balance;
    }

    /**
     * @param balance the balance to set
     */
    public void setBalance(double balance) {
        this.balance = balance;
    }

    /**
     * @return double return the annualInterestrate
     */
    public double getAnnualInterestrate() {
        return this.annualInterestrate;
    }

    /**
     * @param annualInterestrate the annualInterestrate to set
     */
    public void setAnnualInterestrate(double annualInterestrate) {
        this.annualInterestrate = annualInterestrate;
    }

    /**
     * @return Date return the CreatedDate
     */
    public Date getCreatedDate() {
        return this.CreatedDate;
    }

}
