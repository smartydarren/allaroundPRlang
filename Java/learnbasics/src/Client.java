package DarrenIsLearningJava;
import java.util.ArrayList;

public class Client {
    private int id;
    private String name;
    private String phone;
    private ArrayList<Account> accountsArray;

    Client(int cId, String cName, String cPhone){
        this.id = cId;
        this. name = cName;
        this.phone = cPhone;

        accountsArray = new ArrayList<>();

    }

    public boolean addAccount(Account cAccounts){
        this.accountsArray.add(cAccounts);
        return true;
    }

    public boolean removeAccount(int accountId){
        for(Account fAccounts : accountsArray)
            if(fAccounts.getId() == accountId){
                accountsArray.remove(accountId);
                return true;
            }       
            return false;
    }

    public boolean withdraw(double amount){
        for(Account ar : accountsArray)
            ar.withdraw(amount);
            return true;
    }
    
    public String toString(){
        String s = this.id + " " + this.name+ " " + this.phone  +  "\n";

        for(Account stringAccounts : accountsArray)
            s += stringAccounts.toString() + "\n";

        return s;
    }

    /**
     * @param id the id to set
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * @return String return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return String return the phone
     */
    public String getPhone() {
        return phone;
    }

    /**
     * @param phone the phone to set
     */
    public void setPhone(String phone) {
        this.phone = phone;
    }

}
