package DarrenIsLearningJava;
import java.util.ArrayList;
import java.util.Date;

/* import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.awt.Point; */


public class App {
    public static void main(String[] args) throws Exception {
        
      /*   System.out.println("Hello, World!");
        int a = 15;
        String answer = "42";
        System.out.println(answer.hashCode());
        String sanswer = answer;
        sanswer = "darren";
        System.out.println(sanswer.hashCode() + sanswer + answer);
        System.out.println(a);

        SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
        Date ttday = new Date();
        ttday.toString();
        System.out.println(formatter.format(ttday));

        Circle C1 = new Circle();
        System.out.println("Point Values are set to =  "+ C1.centre);

        Circle C2 = new Circle(new Point(10,12),9);
        System.out.println("Point Values are set to =  "+ C2.centre);
        //System.out.println("NewCircle Area =  "+newCircle.getArea());
        //System.out.println("new Circle Perimeter = " + newCircle.getPerimeter());

        System.out.println(C2);
        System.out.println(C1);

        System.out.println(Integer.MIN_VALUE);
        System.out.println(Integer.MAX_VALUE);

         double[] doubleArray = {1.0,-5.0,3.5,2.7,8.0,9.8,4.5};
            for(int i = 0; i < doubleArray.length; i++)
            
                System.out.println("Integer at array index " + i + " = " + doubleArray[i]);
                System.out.println(doubleArray.hashCode());
        //double[] doubleArray = new double[2];

        Arrays.sort(doubleArray);
        System.out.println(doubleArray[0]);

        System.out.println("--------------------");

        int[][] twoDArrays = new int[3][3];
        twoDArrays[0][0] = 00;
        twoDArrays[0][1] = 01;
        twoDArrays[0][2] = 02;
        twoDArrays[1][0] = 10;
        twoDArrays[1][1] = 12;
        twoDArrays[1][2] = 13;
        twoDArrays[2][0] = 20;
        twoDArrays[2][1] = 22;
        twoDArrays[2][2] = 23;

        //System.out.println(twoDArrays[1][2]);
        for(int i=0;i <twoDArrays.length;i++)
            for(int j = 0; j < twoDArrays.length;j++)
                System.out.println(twoDArrays[i][j]);

        int circleCount = Circle.getCircleCount();
        int circleCountObject = C1.getCircleCountObject();
        System.out.println("No of circle objects created = " + circleCount);
        System.out.println("No of circle objects proc 2 result = " + circleCountObject);

        new Circle().setRadius(98);
        System.out.println();
        System.out.println("---------------------------");
        
        Account darrenAcct = new Account(1122, 20000, 4.5);
        System.out.println("ID : " + darrenAcct.getId());
        System.out.println("Account Balance : " + darrenAcct.getBalance());
            double withdrawingAmount = 25000;
            System.out.println("Withdrawing : " + withdrawingAmount);
            if (darrenAcct.withdraw(withdrawingAmount))
                System.out.println("Withdraw successful");
            else
                System.out.println("withdraw unsuccessful");

       
        System.out.println("Account Balance : " + darrenAcct.getBalance());

        darrenAcct.deposit(3000);
        System.out.println("Account Balance after new deposit : " + darrenAcct.getBalance());
        System.out.println(darrenAcct.getCreatedDate().toString());

        System.out.println("---------------------------");
        clients[1] = new Client(002, "Aislinn", "9769082522");        
        clients[1].addAccount(new Account(1, 40000, 5.6));
        clients[1].addAccount(new Account(2, 50000, 5.6));
        
        System.out.println(clients[0].toString());
        System.out.println(clients[1].toString());

        System.out.println("---------------------------"); 

        Account A1 = new Account(001, 23000, 4.5);
        System.out.println(A1);
        A1.withdraw(5000);
        System.out.println(A1);

        Client[] clients = new Client[2];
        clients[0] = new Client(001, "Darren", "9821487005");
        clients[0].addAccount(new Account(1, 20000, 4.7,clients[0]));
        clients[0].addAccount(new Account(2, 30000, 4.7,clients[0]));
        System.out.println(clients[0].toString());

        Client Cl1 = new Client(002, "Aislinn", "987");
        Cl1.addAccount(new Account(001, 25000, 4.5,Cl1));
        Cl1.addAccount(new Account(002, 45000, 4.7,Cl1));
        System.out.println(Cl1.toString());
        //Cl1.

        Transaction T1 = new Transaction('W', 2000, 14000, "Withdrawl",new Date() );
        System.out.println(T1);
 */     
        ArrayList<Account> accounts = new ArrayList<>();
        Client Cl1 = new Client(001, "Darren Quadros", "9821487005");
        accounts.add(new Account(01, 25000, 4.5, Cl1));
        accounts.add(new Account(02, 35000, 5.5, Cl1));
        accounts.get(0).withdraw(50000);
        accounts.get(0).withdraw(2500);
        accounts.get(0).deposit(3500);
        
        Client Cl2 = new Client(002, "Aislinn", "9769082522");
        accounts.add(new Account(01, 55000, 4.5, Cl2));
        accounts.add(new Account(02, 65000, 4.5, Cl2));

        for (Account acc : accounts){
            System.out.println(acc.toString());
                System.out.println("Withdrawls : " + acc.countTran('W'));
                System.out.println("Deposits   : " + acc.countTran('D'));
        }

        String testString = new String();
        testString = "Darren";
        System.out.println(testString.charAt(2));
        System.out.println(testString.length());

        


    }


}
