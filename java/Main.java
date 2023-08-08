/**
 * @author : gtoscano
 * @created : 2023-08-08
**/

public class Main {
    static {
        System.loadLibrary("factorial");
    }

    public static void main(String[] args) {
        System.out.println(factorial.factorial(5));
    }
}

