package DarrenIsLearningJava;
import java.util.Date;

public class Transaction {
    private char type;
    private double amount;
    private double balance;
    private Date tDate;
    private String desc;

    public Transaction(char cType,double cAmount,double cBalance,String cDesc,Date tDate){
        this.type = cType;
        this.amount = cAmount;
        this.balance = cBalance;
        this.desc = cDesc;
        this.tDate = tDate;
    }
    
    public String toString(){
        String s1 = this.type + " " + this.amount + " " + this.desc + " " + tDate;
        return s1;
    }
     
    public char getType() {return type;}
    public void setdate(Date tdate) {this.tDate = tdate;}
    /* public void setType(char type) {this.type = type;}
    
    public double getAmount() {return amount;}
    public void setAmount(double amount) {this.amount = amount;}

    public double getBalance() {return balance;}
    public void setBalance(double balance) {this.balance = balance;}
  
    public String getDesc() {return desc;}
    public void setDesc(String desc) {this.desc = desc;} */

}
